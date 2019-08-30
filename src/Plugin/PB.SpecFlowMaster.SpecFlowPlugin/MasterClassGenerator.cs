using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BoDi;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Parser;
using TechTalk.SpecFlow.Tracing;
using ScenarioBlock = TechTalk.SpecFlow.Parser.ScenarioBlock;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class MasterClassGenerator
    {
        private const string TESTCLASS_INITIALIZE_NAME = "FeatureSetup";
        private const string TESTCLASS_CLEANUP_NAME = "FeatureTearDown";
        private const string SCENARIO_START_NAME = "ScenarioStart";
        private const string SCENARIO_INITIALIZE_NAME = "ScenarioInitialize";
        private const string BACKGROUND_NAME = "FeatureBackground";
        private const string SCENARIO_CLEANUP_NAME = "ScenarioCleanup";
        private const string TEST_INITIALIZE_NAME = "TestInitialize";
        private const string TEST_CLEANUP_NAME = "ScenarioTearDown";
        private const string NunitTestExecutionContextClassName = "NUnit.Framework.Internal.TestExecutionContext.IsolatedContext";

        private readonly IObjectContainer _container;
        private readonly TestClassGenerationContext _context;
        private readonly CodeDomHelper _codeDomHelper;
        private int _tableCounter;

        public MasterClassGenerator(IObjectContainer container, TestClassGenerationContext context, CodeDomHelper codeDomHelper)
        {
            _context = context;
            _codeDomHelper = codeDomHelper;
            _container = container;
        }

        public static TestClassGenerationContext CreateContextFromOriginContext(
            TestClassGenerationContext originContext,
            IUnitTestGeneratorProvider baseUnitTestGeneratorProvider)
        {
            var testClass = new CodeTypeDeclaration(NamingHelper.GetTestClassName(originContext.Document.SpecFlowFeature));
            originContext.Namespace.Types.Add(testClass);

            var masterContext = new TestClassGenerationContext(
                unitTestGeneratorProvider: baseUnitTestGeneratorProvider,
                document: originContext.Document,
                ns: originContext.Namespace,
                testClass: testClass,
                testRunnerField: DeclareTestRunnerMember(testClass),
                testClassInitializeMethod: CreateMethod(testClass),
                testClassCleanupMethod: CreateMethod(testClass),
                testInitializeMethod: CreateMethod(testClass),
                testCleanupMethod: CreateMethod(testClass),
                scenarioInitializeMethod: CreateMethod(testClass),
                scenarioStartMethod: CreateMethod(testClass),
                scenarioCleanupMethod: CreateMethod(testClass),
                featureBackgroundMethod: CreateMethod(testClass),
                generateRowTests: false
            );

            return masterContext;
        }

        private static CodeMemberField DeclareTestRunnerMember(CodeTypeDeclaration type)
        {
            CodeMemberField testRunnerField = new CodeMemberField(typeof(ITestRunner), NamingHelper.TestRunnerVariableName);
            type.Members.Add(testRunnerField);
            return testRunnerField;
        }

        private static CodeMemberMethod CreateMethod(CodeTypeDeclaration type)
        {
            CodeMemberMethod method = new CodeMemberMethod();
            type.Members.Add(method);
            return method;
        }

        public void Generate()
        {
            SetupTestClass();
            SetupTestClassInitializeMethod();
            SetupTestClassCleanupMethod();

            SetupScenarioStartMethod();
            SetupScenarioInitializeMethod();
            SetupFeatureBackground();
            SetupScenarioCleanupMethod();

            SetupTestInitializeMethod();
            SetupTestCleanupMethod();

            SetupTestWrapper();

            SetupTests();

            SetupFinalizeTest();

        }

        private void SetupTestWrapper()
        {
            var testWrapperMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = NamingHelper.TestWrapperMethodName,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(typeof(Action), NamingHelper.TestActionParameterName),
                    new CodeParameterDeclarationExpression(typeof(int), NamingHelper.LineNumberParameterName)
                }
            };

            testWrapperMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(bool),
                NamingHelper.NoExceptionOccuredVariableName, new CodePrimitiveExpression(true)));
            var tryCatchStatement = new CodeTryCatchFinallyStatement
            {
                CatchClauses =
                {
                    new CodeCatchClause
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

            //TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two numbers new12345", null, new string[] { "mytag"});
            tryCatchStatement.TryStatements.Add(
                new CodeVariableDeclarationStatement(typeof(ScenarioInfo),
                    NamingHelper.ScenarioInfoVariableName,
                    new CodeObjectCreateExpression(typeof(ScenarioInfo),
                        new CodePrimitiveExpression(_context.Document.Feature.Name),
                        new CodePrimitiveExpression(null))));

            //testRunner.OnScenarioInitialize(scenarioInfo);
            tryCatchStatement.TryStatements.Add(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        nameof(ITestRunner.OnScenarioInitialize)),
                    new CodeVariableReferenceExpression(NamingHelper.ScenarioInfoVariableName)));

            //this.ScenarioStart();
            tryCatchStatement.TryStatements.Add(
                new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(),
                    _context.ScenarioStartMethod.Name));

            SetupCallAction(tryCatchStatement.TryStatements);

            //this.ScenarioCleanup();
            tryCatchStatement.TryStatements.Add(
                new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(),
                    _context.ScenarioCleanupMethod.Name));

            testWrapperMethod.Statements.Add(tryCatchStatement);
            var exceptionValidationStatement = GetAssertStatement();
            testWrapperMethod.Statements.Add(exceptionValidationStatement);

            _context.TestClass.Members.Add(testWrapperMethod);
        }

        private void SetupCallAction(CodeStatementCollection statements)
        {
            //action();
            var callActionStatement = new CodeDelegateInvokeExpression(
                new CodeVariableReferenceExpression(NamingHelper.TestActionParameterName));

            JsonConfig config = _container.Resolve<JsonConfig>();
            if (config.UnitTestProvider.Equals("nunit", StringComparison.InvariantCultureIgnoreCase))
            {
                /*
                var testExecutionContext = new TestExecutionContext.IsolatedContext();
                try
                {
                    action();
                }
                finally
                {
                    testExecutionContext.Dispose();
                }
                */
                statements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference(NunitTestExecutionContextClassName), 
                    NamingHelper.TestExecutionContextVariableName,
                    new CodeObjectCreateExpression(new CodeTypeReference(NunitTestExecutionContextClassName))));
                var tryFinallyStatement = new CodeTryCatchFinallyStatement();
                tryFinallyStatement.TryStatements.Add(callActionStatement);
                tryFinallyStatement.FinallyStatements.Add(new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(NamingHelper.TestExecutionContextVariableName),
                    nameof(IDisposable.Dispose)));
                statements.Add(tryFinallyStatement);
            }
            else
            {
                statements.Add(callActionStatement);
            }
        }

        private void SetupFinalizeTest()
        {
            _context.UnitTestGeneratorProvider.FinalizeTestClass(_context);
        }

        private void SetupTests()
        {
            foreach (var scenario in _context.Document.SpecFlowFeature.Children.OfType<Scenario>())
            {
                // Generate tests only for GIVEN and WHEN statements
                // because THEN statements are not actions and usually can be safely removed
                foreach (SpecFlowStep step in scenario.Steps.OfType<SpecFlowStep>().Where(x =>
                    x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.When))
                {
                    AddLineTest(scenario, step);
                }
            }
        }

        private void SetupTestClassInitializeMethod()
        {
            var testClassInitializeMethod = _context.TestClassInitializeMethod;

            testClassInitializeMethod.Attributes = MemberAttributes.Public;
            testClassInitializeMethod.Name = TESTCLASS_INITIALIZE_NAME;

            _context.UnitTestGeneratorProvider.SetTestClassInitializeMethod(_context);

            //testRunner = TestRunnerManager.GetTestRunner(null, 0); if not UnitTestGeneratorTraits.ParallelExecution
            var testRunnerField = GetTestRunnerExpression();

            var testRunnerParameters = new CodeExpression[]
                {new CodePrimitiveExpression(null), new CodePrimitiveExpression(0)};

            testClassInitializeMethod.Statements.Add(
                new CodeAssignStatement(
                    testRunnerField,
                    new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression(typeof(TestRunnerManager)),
                        nameof(TestRunnerManager.GetTestRunner), testRunnerParameters)));

            //FeatureInfo featureInfo = new FeatureInfo("xxxx");
            testClassInitializeMethod.Statements.Add(
                new CodeVariableDeclarationStatement(typeof(FeatureInfo), NamingHelper.FeatureInfoVariableName,
                    new CodeObjectCreateExpression(typeof(FeatureInfo),
                        new CodeObjectCreateExpression(typeof(CultureInfo),
                            new CodePrimitiveExpression(_context.Feature.Language)),
                        new CodePrimitiveExpression(_context.Feature.Name),
                        new CodePrimitiveExpression(_context.Feature.Description),
                        new CodeFieldReferenceExpression(
                            new CodeTypeReferenceExpression(nameof(ProgrammingLanguage)),
                            _codeDomHelper.TargetLanguage.ToString()),
                        new CodePrimitiveExpression(null))));

            //testRunner.OnFeatureStart(featureInfo);
            testClassInitializeMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    "OnFeatureStart",
                    new CodeVariableReferenceExpression(NamingHelper.FeatureInfoVariableName)));
        }

        private CodeExpression GetTestRunnerExpression()
        {
            return new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName);
        }

        private void SetupTestClassCleanupMethod()
        {
            CodeMemberMethod testClassCleanupMethod = _context.TestClassCleanupMethod;

            testClassCleanupMethod.Attributes = MemberAttributes.Public;
            testClassCleanupMethod.Name = TESTCLASS_CLEANUP_NAME;

            _context.UnitTestGeneratorProvider.SetTestClassCleanupMethod(_context);

            var testRunnerField = GetTestRunnerExpression();
            //            testRunner.OnFeatureEnd();
            testClassCleanupMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    "OnFeatureEnd"));
            //            testRunner = null;
            testClassCleanupMethod.Statements.Add(
                new CodeAssignStatement(
                    testRunnerField,
                    new CodePrimitiveExpression(null)));
        }

        private void SetupScenarioStartMethod()
        {
            var scenarioStartMethod = _context.ScenarioStartMethod;

            scenarioStartMethod.Attributes = MemberAttributes.Public;
            scenarioStartMethod.Name = SCENARIO_START_NAME;

            //testRunner.OnScenarioStart();
            var testRunnerField = GetTestRunnerExpression();
            scenarioStartMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    nameof(ITestExecutionEngine.OnScenarioStart)));
        }

        private void SetupScenarioInitializeMethod()
        {
            var scenarioInitializeMethod = _context.ScenarioInitializeMethod;

            scenarioInitializeMethod.Attributes = MemberAttributes.Public;
            scenarioInitializeMethod.Name = SCENARIO_INITIALIZE_NAME;
            scenarioInitializeMethod.Parameters.Add(
                new CodeParameterDeclarationExpression(typeof(ScenarioInfo), NamingHelper.ScenarioInfoVariableName));

            //testRunner.OnScenarioInitialize(scenarioInfo);
            var testRunnerField = GetTestRunnerExpression();
            scenarioInitializeMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    nameof(ITestExecutionEngine.OnScenarioInitialize),
                    new CodeVariableReferenceExpression(NamingHelper.ScenarioInfoVariableName)));
        }

        private void SetupFeatureBackground()
        {
            CodeMemberMethod backgroundMethod = _context.FeatureBackgroundMethod;
            backgroundMethod.Name = BACKGROUND_NAME;

            if (!HasFeatureBackground(_context.Feature))
                return;

            var background = _context.Feature.Background;

            backgroundMethod.Attributes = MemberAttributes.Public;

            AddLineDirective(backgroundMethod.Statements, background);

            // TODO: handle background steps
            /*
            foreach (var step in background.Steps)
                GenerateStep(backgroundMethod, step, null);
                */

            AddLineDirectiveHidden(backgroundMethod.Statements);
        }

        private void AddLineDirective(CodeStatementCollection statements, Background background)
        {
            AddLineDirective(statements, background.Location);
        }

        private void AddLineDirective(CodeStatementCollection statements, Location location)
        {
            _codeDomHelper.AddSourceLinePragmaStatement(statements, location.Line, location.Column);
        }

        private void AddLineDirective(CodeStatementCollection statements, Step step)
        {
            AddLineDirective(statements, step.Location);
        }

        private void AddLineDirectiveHidden(CodeStatementCollection statements)
        {
            _codeDomHelper.AddDisableSourceLinePragmaStatement(statements);
        }

        private static bool HasFeatureBackground(SpecFlowFeature feature)
        {
            return feature.Background != null;
        }

        private void SetupScenarioCleanupMethod()
        {
            CodeMemberMethod scenarioCleanupMethod = _context.ScenarioCleanupMethod;

            scenarioCleanupMethod.Attributes = MemberAttributes.Public;
            scenarioCleanupMethod.Name = SCENARIO_CLEANUP_NAME;

            // call collect errors
            var testRunnerField = GetTestRunnerExpression();
            //testRunner.CollectScenarioErrors();
            scenarioCleanupMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    nameof(TestRunner.CollectScenarioErrors)));
        }

        private void SetupTestInitializeMethod()
        {
            CodeMemberMethod testInitializeMethod = _context.TestInitializeMethod;

            testInitializeMethod.Attributes = MemberAttributes.Public;
            testInitializeMethod.Name = TEST_INITIALIZE_NAME;

            _context.UnitTestGeneratorProvider.SetTestInitializeMethod(_context);
        }

        private void SetupTestCleanupMethod()
        {
            CodeMemberMethod testCleanupMethod = _context.TestCleanupMethod;

            testCleanupMethod.Attributes = MemberAttributes.Public;
            testCleanupMethod.Name = TEST_CLEANUP_NAME;

            _context.UnitTestGeneratorProvider.SetTestCleanupMethod(_context);

            var testRunnerField = GetTestRunnerExpression();
            //testRunner.OnScenarioEnd();
            testCleanupMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    testRunnerField,
                    "OnScenarioEnd"));
        }

        private void SetupTestClass()
        {
            _context.TestClass.IsPartial = true;
            _context.TestClass.TypeAttributes |= TypeAttributes.Public;

            AddLinePragmaInitial(_context.TestClass, _context.Document.SourceFilePath);

            _context.UnitTestGeneratorProvider.SetTestClass(_context, _context.Document.Feature.Name, _context.Document.Feature.Description);
        }

        private void AddLinePragmaInitial(CodeTypeDeclaration testType, string sourceFile)
        {
            _codeDomHelper.BindTypeToSourceFile(testType, Path.GetFileName(sourceFile));
        }

        private void AddLineTest(Scenario scenario, SpecFlowStep step)
        {
            // Test method
            var testMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = NamingHelper.GetTestName(step)
            };

            testMethod.Statements.Add(new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                    new CodeThisReferenceExpression(),
                    NamingHelper.TestWrapperMethodName),
                new CodeMethodReferenceExpression(new CodeThisReferenceExpression(),
                    NamingHelper.GetTestStepsName(step)), new CodePrimitiveExpression(step.Location.Line)));

            _context.UnitTestGeneratorProvider.SetTestMethod(_context, testMethod, NamingHelper.GetTestName(step));

            _context.TestClass.Members.Add(testMethod);

            // Test steps
            var stepsMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Private,
                Name = NamingHelper.GetTestStepsName(step)
            };

            AddActionStatements(stepsMethod.Statements, scenario, step);

            _context.TestClass.Members.Add(stepsMethod);

        }

        private CodeStatement GetAssertStatement()
        {
            var exceptionValidationStatement = new CodeConditionStatement
            {
                //if (noExceptionOccured)
                Condition = new CodeVariableReferenceExpression(NamingHelper.NoExceptionOccuredVariableName),
                TrueStatements =
                {
                    new CodeThrowExceptionStatement
                    {
                        //throw new Exception(string.Format("Line {0} is suspicious.", lineNumber));
                        ToThrow = new CodeObjectCreateExpression(typeof(Exception),
                            new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(typeof(string)),
                                nameof(string.Format),
                                new CodePrimitiveExpression("Line {0} is suspicious."),
                                new CodeVariableReferenceExpression(NamingHelper.LineNumberParameterName)))
                    }
                }
            };

            return exceptionValidationStatement;
        }

        private void AddActionStatements(CodeStatementCollection statements, Scenario scenario, SpecFlowStep step)
        {
            foreach (var scenarioStep in scenario.Steps.Where(x => x != step))
            {
                GenerateStep(statements, scenarioStep, null);
            }
        }

        private void GenerateStep(CodeStatementCollection statements, Step scenarioStep, ParameterSubstitution paramToIdentifier)
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

            AddLineDirective(statements, scenarioStep);
            statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        specFlowStep.StepKeyword.ToString()),
                    arguments.ToArray())));
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
        public const string NoExceptionOccuredVariableName = "noExceptionOccured";
        public const string TestRunnerVariableName = "testRunner";
        public const string FeatureInfoVariableName = "featureInfo";
        public const string ScenarioInfoVariableName = "scenarioInfo";
        public const string TestWrapperMethodName = "Test";
        public const string TestActionParameterName = "steps";
        public const string LineNumberParameterName = "lineNumber";
        public const string TestExecutionContextVariableName = "testExecutionContext";

        public static string GetTestClassName(SpecFlowFeature feature)
        {
            return $"{feature.Name.ToIdentifier()}FeatureMaster";
        }

        public static string GetTestName(SpecFlowStep step)
        {
            return $"TestLine{step.Location.Line}{step.Text.ToIdentifier()}";
        }

        public static string GetTestStepsName(SpecFlowStep step)
        {
            return GetTestName(step) + "Steps";
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
