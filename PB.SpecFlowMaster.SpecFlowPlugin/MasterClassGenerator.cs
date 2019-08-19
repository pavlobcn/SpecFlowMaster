using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                    CodeMemberMethod testMethod = GetLineTest(testClass, step);
                    testClass.Members.Add(testMethod);
                }
            }
        }

        private CodeMemberMethod GetLineTest(CodeTypeDeclaration testClass, SpecFlowStep step)
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
            tryCatchStatement.TryStatements.AddRange(GetActionStatements());
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

        private CodeStatement[] GetActionStatements()
        {
            return new CodeStatement[]
            {
                new CodeVariableDeclarationStatement(typeof(ITestRunner),
                    NamingHelper.TestRunnerVariableName,
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(typeof(TestRunnerManager)),
                            nameof(TestRunnerManager.CreateTestRunner)))),
                new CodeVariableDeclarationStatement(typeof(FeatureInfo),
                    NamingHelper.FeatureInfoVariableName,
                    new CodeObjectCreateExpression(typeof(FeatureInfo),
                        new CodeObjectCreateExpression(typeof(CultureInfo), new CodePrimitiveExpression("en-US")),
                        new CodePrimitiveExpression(_document.Feature.Name),
                        new CodePrimitiveExpression(_document.Feature.Description),
                        new CodePrimitiveExpression(ProgrammingLanguage.CSharp),
                        new CodePrimitiveExpression(null)))
            };
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

        public static string GetTestName(SpecFlowStep step)
        {
            return "TestLine" + step.Location.Line;
        }
    }

}
