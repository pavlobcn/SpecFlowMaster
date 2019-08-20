using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BoDi;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Parser;
using ScenarioBlock = TechTalk.SpecFlow.Parser.ScenarioBlock;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class MasterClassGenerator
    {

        private readonly SpecFlowDocument _document;
        private readonly CodeNamespace _codeNamespace;

        public MasterClassGenerator(SpecFlowDocument document, CodeNamespace codeNamespace)
        {
            _document = document;
            _codeNamespace = codeNamespace;
        }

        public void Generate()
        {
            var testClass = GetTypeDeclaration();
            _codeNamespace.Types.Add(testClass);

            foreach (var scenario in _document.SpecFlowFeature.Children.OfType<Scenario>())
            {
                foreach (SpecFlowStep step in scenario.Steps.OfType<SpecFlowStep>().Where(x =>
                    x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.Then))
                {
                    CodeMemberMethod testMethod = GetLineTest(testClass, scenario, step);
                    testClass.Members.Add(testMethod);
                }
            }
        }

        private CodeMemberMethod GetLineTest(CodeTypeDeclaration testClass, Scenario scenario, SpecFlowStep step)
        {
            var testMethod = new CodeMemberMethod();

            testMethod.Name = NamingHelper.GetTestName(step);
            testMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(bool),
                NamingHelper.NoExceptionOccuredVariableName, new CodePrimitiveExpression(true)));
            var tryCatchStatement = new CodeTryCatchFinallyStatement
            {
                CatchClauses =
                {
                    new CodeCatchClause()
                    {
                        Statements =
                        {
                            new CodeAssignStatement(
                                new CodeVariableReferenceExpression(NamingHelper.NoExceptionOccuredVariableName),
                                new CodePrimitiveExpression(false))
                        }
                    }
                }
            };
            tryCatchStatement.TryStatements.AddRange(GetActionStatements(scenario, step));
            testMethod.Statements.Add(tryCatchStatement);
            var exceptionValidationStatement = GetAssertStatement(step, NamingHelper.NoExceptionOccuredVariableName);
            testMethod.Statements.Add(exceptionValidationStatement);

            return testMethod;
        }

        private CodeStatement GetAssertStatement(SpecFlowStep step, string noExceptionOccuredVariableName)
        {
            var exceptionValidationStatement = new CodeConditionStatement
            {
                Condition = new CodeVariableReferenceExpression(NamingHelper.NoExceptionOccuredVariableName),
                TrueStatements =
                {
                    new CodeThrowExceptionStatement
                    {
                        ToThrow = new CodeObjectCreateExpression(typeof(Exception),
                            new CodePrimitiveExpression($"Line {step.Location.Line} is suspicious."))
                    }
                }
            };

            return exceptionValidationStatement;
        }

        private CodeStatement[] GetActionStatements(Scenario scenario, SpecFlowStep step)
        {
            var statements = new List<CodeStatement>
            {
                // testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
                new CodeVariableDeclarationStatement(typeof(ITestRunner),
                    NamingHelper.TestRunnerVariableName,
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(TestRunnerManager)),
                            nameof(TestRunnerManager.CreateTestRunner)))),
                // TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                new CodeVariableDeclarationStatement(typeof(FeatureInfo),
                    NamingHelper.FeatureInfoVariableName,
                    new CodeObjectCreateExpression(typeof(FeatureInfo),
                        new CodeObjectCreateExpression(typeof(CultureInfo), new CodePrimitiveExpression("en-US")),
                        new CodePrimitiveExpression(_document.Feature.Name),
                        new CodePrimitiveExpression(_document.Feature.Description),
                        new CodeFieldReferenceExpression(
                            new CodeTypeReferenceExpression(nameof(ProgrammingLanguage)),
                            nameof(ProgrammingLanguage.CSharp)),
                        new CodePrimitiveExpression(null))),
                // testRunner.OnFeatureStart(featureInfo);
                new CodeMethodReturnStatement(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                            nameof(ITestRunner.OnFeatureStart)),
                        new CodeVariableReferenceExpression(NamingHelper.FeatureInfoVariableName))),
                // TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two numbers new12345", null, new string[] { "mytag"});
                new CodeVariableDeclarationStatement(typeof(ScenarioInfo),
                    NamingHelper.FeatureInfoVariableName,
                    new CodeObjectCreateExpression(typeof(ScenarioInfo),
                        new CodePrimitiveExpression(_document.Feature.Name),
                        new CodePrimitiveExpression(null))),
                //testRunner.OnScenarioInitialize(scenarioInfo);
                new CodeMethodReturnStatement(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                            nameof(ITestRunner.OnScenarioInitialize)),
                        new CodeVariableReferenceExpression(NamingHelper.FeatureInfoVariableName))),
                //testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
                new CodeMethodReturnStatement(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodePropertyReferenceExpression(
                                new CodePropertyReferenceExpression(
                                    new CodeFieldReferenceExpression(null, NamingHelper.TestRunnerVariableName),
                                    nameof(ScenarioContext)),
                                nameof(ScenarioContext.ScenarioContainer)),
                            nameof(IObjectContainer.RegisterInstanceAs),
                            new CodeTypeReference(typeof(NUnit.Framework.TestContext))),
                        new CodeVariableReferenceExpression("NUnit.Framework.TestContext.CurrentContext"))),
                // testRunner.OnScenarioStart();
                new CodeMethodReturnStatement(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                            nameof(ITestRunner.OnScenarioStart))))
            };

            foreach (var scenarioStep in scenario.Steps.Where(x => x != step))
            {
                statements.Add(GenerateStep(scenarioStep));
            }

            return statements.ToArray();
        }

        private CodeStatement GenerateStep(Step scenarioStep, ParameterSubstitution paramToIdentifier)
        {
            //var testRunnerField = GetTestRunnerExpression();
            //var scenarioStep = AsSpecFlowStep(gherkinStep);

            //testRunner.Given("something");
            var arguments = new List<CodeExpression>
            {
                GetSubstitutedString(scenarioStep.Text, paramToIdentifier),
                GetDocStringArgExpression(scenarioStep.Argument as DocString, paramToIdentifier),
                GetTableArgExpression(scenarioStep.Argument as DataTable, statements, paramToIdentifier),
                new CodePrimitiveExpression(scenarioStep.Keyword)
            };


            using (new SourceLineScope(_specFlowConfiguration, _codeDomHelper, statements, generationContext.Document.SourceFilePath, gherkinStep.Location))
            {
                return new CodeExpressionStatement(
                    new CodeMethodInvokeExpression(
                        testRunnerField,
                        scenarioStep.StepKeyword.ToString(),
                        arguments.ToArray()));
            }
        }

        private CodeTypeDeclaration GetTypeDeclaration()
        {
            var testClass = new CodeTypeDeclaration(NamingHelper.TestsClassName);
            return testClass;
        }

        private void TestTemplate()
        {
            /*
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                                                                                                                                                           "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);


            bool expectedExceptionOccured = false;
            try
            {

            }
            catch
            {
                expectedExceptionOccured = true;
            }

            if (!expectedExceptionOccured)
            {
                throw new Exception("Suspicious statement at line #");
            }
            */
        }
    }

    internal static class NamingHelper
    {
        public const string TestsClassName = "MasterTests";
        public const string NoExceptionOccuredVariableName = "noExceptionOccured";
        public const string TestRunnerVariableName = "testRunner";
        public const string FeatureInfoVariableName = "testRunner";
        public const string ScenarioInfoVariableName = "scenarioInfo";

        public static string GetTestName(SpecFlowStep step)
        {
            return "TestLine" + step.Location.Line;
        }
    }

}
