using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Parser;
using ScenarioBlock = TechTalk.SpecFlow.Parser.ScenarioBlock;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class MasterClassGenerator
    {
        private readonly TestClassGenerationContext _context;
        private int _tableCounter;

        public MasterClassGenerator(TestClassGenerationContext context)
        {
            _context = context;
        }

        public void Generate()
        {
            _context.UnitTestGeneratorProvider.SetTestClass(_context, _context.Document.Feature.Name, _context.Document.Feature.Description);

            foreach (var scenario in _context.Document.SpecFlowFeature.Children.OfType<Scenario>())
            {
                foreach (SpecFlowStep step in scenario.Steps.OfType<SpecFlowStep>().Where(x =>
                    x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.Then))
                {
                    AddLineTest(scenario, step);
                }
            }
        }

        private void AddLineTest(Scenario scenario, SpecFlowStep step)
        {
            var testMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = NamingHelper.GetTestName(step)
            };

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
            AddActionStatements(tryCatchStatement.TryStatements, scenario, step);
            testMethod.Statements.Add(tryCatchStatement);
            var exceptionValidationStatement = GetAssertStatement(step);
            testMethod.Statements.Add(exceptionValidationStatement);

            _context.UnitTestGeneratorProvider.SetTestMethod(_context, testMethod, NamingHelper.GetTestName(step));

            _context.TestClass.Members.Add(testMethod);
        }

        private CodeStatement GetAssertStatement(SpecFlowStep step)
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

        private void AddActionStatements(CodeStatementCollection statements, Scenario scenario, SpecFlowStep step)
        {
            // testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            statements.Add(
                new CodeVariableDeclarationStatement(typeof(ITestRunner),
                    NamingHelper.TestRunnerVariableName,
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodeTypeReferenceExpression(typeof(TestRunnerManager)),
                            nameof(TestRunnerManager.GetTestRunner)))));
            // TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
            statements.Add(
                new CodeVariableDeclarationStatement(typeof(FeatureInfo),
                    NamingHelper.FeatureInfoVariableName,
                    new CodeObjectCreateExpression(typeof(FeatureInfo),
                        new CodeObjectCreateExpression(typeof(CultureInfo), new CodePrimitiveExpression("en-US")),
                        new CodePrimitiveExpression(_context.Document.Feature.Name),
                        new CodePrimitiveExpression(_context.Document.Feature.Description),
                        new CodeFieldReferenceExpression(
                            new CodeTypeReferenceExpression(nameof(ProgrammingLanguage)),
                            nameof(ProgrammingLanguage.CSharp)),
                        new CodePrimitiveExpression(null))));
            // testRunner.OnFeatureStart(featureInfo);
            statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        nameof(ITestRunner.OnFeatureStart)),
                    new CodeVariableReferenceExpression(NamingHelper.FeatureInfoVariableName)));
            // TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two numbers new12345", null, new string[] { "mytag"});
            statements.Add(
                new CodeVariableDeclarationStatement(typeof(ScenarioInfo),
                    NamingHelper.ScenarioInfoVariableName,
                    new CodeObjectCreateExpression(typeof(ScenarioInfo),
                        new CodePrimitiveExpression(_context.Document.Feature.Name),
                        new CodePrimitiveExpression(null))));
            //testRunner.OnScenarioInitialize(scenarioInfo);
            statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        nameof(ITestRunner.OnScenarioInitialize)),
                    new CodeVariableReferenceExpression(NamingHelper.ScenarioInfoVariableName)));
            //testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
            // TODO: fix this
            /*
            _unitTestGeneratorProvider.FinalizeTestClass(new TestClassGenerationContext())
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
                    */
            // testRunner.OnScenarioStart();
            statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        nameof(ITestRunner.OnScenarioStart))));

            foreach (var scenarioStep in scenario.Steps.Where(x => x != step))
            {
                statements.Add(GenerateStep(statements, scenarioStep, null));
            }
        }

        private CodeStatement GenerateStep(CodeStatementCollection statements, Step scenarioStep, ParameterSubstitution paramToIdentifier)
        {
            var specFlowStep = AsSpecFlowStep(scenarioStep);

            //testRunner.Given("something");
            var arguments = new List<CodeExpression>
            {
                GetSubstitutedString(scenarioStep.Text, paramToIdentifier),
                GetDocStringArgExpression(scenarioStep.Argument as DocString, paramToIdentifier),
                GetTableArgExpression(scenarioStep.Argument as DataTable, statements, paramToIdentifier),
                new CodePrimitiveExpression(scenarioStep.Keyword)
            };

            return new CodeExpressionStatement(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        specFlowStep.StepKeyword.ToString()),
                    arguments.ToArray()));
        }

        private SpecFlowStep AsSpecFlowStep(Step step)
        {
            var specFlowStep = step as SpecFlowStep;
            if (specFlowStep == null)
                throw new TestGeneratorException("The step must be a SpecFlowStep.");
            return specFlowStep;
        }

        private CodeExpression GetTableArgExpression(DataTable tableArg, CodeStatementCollection statements, ParameterSubstitution paramToIdentifier)
        {
            if (tableArg == null)
                return new CodeCastExpression(typeof(Table), new CodePrimitiveExpression(null));

            _tableCounter++;

            //TODO[Gherkin3]: remove dependency on having the first row as header
            var header = tableArg.Rows.First();
            var body = tableArg.Rows.Skip(1).ToArray();

            //Table table0 = new Table(header...);
            var tableVar = new CodeVariableReferenceExpression("table" + _tableCounter);
            statements.Add(
                new CodeVariableDeclarationStatement(typeof(Table), tableVar.VariableName,
                    new CodeObjectCreateExpression(
                        typeof(Table),
                        GetStringArrayExpression(header.Cells.Select(c => c.Value), paramToIdentifier))));

            foreach (var row in body)
            {
                //table0.AddRow(cells...);
                statements.Add(
                    new CodeMethodInvokeExpression(
                        tableVar,
                        "AddRow",
                        GetStringArrayExpression(row.Cells.Select(c => c.Value), paramToIdentifier)));
            }

            return tableVar;
        }

        private CodeExpression GetStringArrayExpression(IEnumerable<string> items, ParameterSubstitution paramToIdentifier)
        {
            return new CodeArrayCreateExpression(typeof(string[]), items.Select(item => GetSubstitutedString(item, paramToIdentifier)).ToArray());
        }


        private CodeExpression GetDocStringArgExpression(DocString docString, ParameterSubstitution paramToIdentifier)
        {
            return GetSubstitutedString(docString == null ? null : docString.Content, paramToIdentifier);
        }

        private CodeExpression GetSubstitutedString(string text, ParameterSubstitution paramToIdentifier)
        {
            if (text == null)
                return new CodeCastExpression(typeof(string), new CodePrimitiveExpression(null));
            if (paramToIdentifier == null)
                return new CodePrimitiveExpression(text);

            Regex paramRe = new Regex(@"\<(?<param>[^\>]+)\>");
            string formatText = text.Replace("{", "{{").Replace("}", "}}");
            List<string> arguments = new List<string>();

            formatText = paramRe.Replace(formatText, match =>
            {
                string param = match.Groups["param"].Value;
                string id;
                if (!paramToIdentifier.TryGetIdentifier(param, out id))
                    return match.Value;
                int argIndex = arguments.IndexOf(id);
                if (argIndex < 0)
                {
                    argIndex = arguments.Count;
                    arguments.Add(id);
                }

                return "{" + argIndex + "}";
            });

            if (arguments.Count == 0)
                return new CodePrimitiveExpression(text);

            List<CodeExpression> formatArguments = new List<CodeExpression>();
            formatArguments.Add(new CodePrimitiveExpression(formatText));
            formatArguments.AddRange(arguments.Select(id => new CodeVariableReferenceExpression(id)));

            return new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(typeof(string)),
                "Format",
                formatArguments.ToArray());
        }
    }

    public static class NamingHelper
    {
        public const string TestsClassName = "MasterTests";
        public const string NoExceptionOccuredVariableName = "noExceptionOccured";
        public const string TestRunnerVariableName = "testRunner";
        public const string FeatureInfoVariableName = "featureInfo";
        public const string ScenarioInfoVariableName = "scenarioInfo";

        public static string GetTestName(SpecFlowStep step)
        {
            return "TestLine" + step.Location.Line;
        }
    }

    // TODO: replace with existing class from TechTalk.SpecFlow.Generator
    internal class ParameterSubstitution : List<KeyValuePair<string, string>>
    {
        public void Add(string parameter, string identifier)
        {
            Add(new KeyValuePair<string, string>(parameter.Trim(), identifier));
        }

        public bool TryGetIdentifier(string param, out string id)
        {
            param = param.Trim();
            foreach (var pair in this)
            {
                if (pair.Key.Equals(param))
                {
                    id = pair.Value;
                    return true;
                }
            }

            id = null;
            return false;
        }
    }
}
