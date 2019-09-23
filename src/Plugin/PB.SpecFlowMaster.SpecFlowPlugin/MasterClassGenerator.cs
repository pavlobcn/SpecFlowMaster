using System;
using System.CodeDom;
using System.Collections;
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
using TableRow = Gherkin.Ast.TableRow;

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
            if (string.Equals(config.UnitTestProvider, "nunit", StringComparison.InvariantCultureIgnoreCase))
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
            var metadata = _container.Resolve<FeatureMetadataProvider>()[_context.Document];

            if (_context.Document.SpecFlowFeature.Background != null)
            {
                // Generate tests only for GIVEN and WHEN statements
                // because THEN statements are not actions and usually can be safely removed
                foreach (SpecFlowStep step in _context.Document.SpecFlowFeature.Children
                    .OfType<Background>()
                    .First()
                    .Steps
                    .OfType<SpecFlowStep>()
                    .Where(x => x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.When)
                    .Where(x => !metadata.IsIgnored(x)))
                {
                    AddBackgroundLineTest(_context.Document.SpecFlowFeature, step);
                }
            }

            foreach (Scenario scenario in _context.Document.SpecFlowFeature.Children
                .OfType<Scenario>()
                .Where(x => !metadata.IsIgnored(x)))
            {
                ParameterSubstitution paramToIdentifier = null;
                if (scenario is ScenarioOutline scenarioOutline)
                {
                    paramToIdentifier = CreateParamToIdentifierMapping(scenarioOutline);
                }

                // Generate tests only for GIVEN and WHEN statements
                // because THEN statements are not actions and usually can be safely removed
                foreach (SpecFlowStep step in scenario.Steps
                    .OfType<SpecFlowStep>()
                    .Where(x => x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.When)
                    .Where(x => !metadata.IsIgnored(x)))
                {
                    AddScenarioLineTest(_context.Document.SpecFlowFeature, scenario, step, paramToIdentifier);
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

        private void AddScenarioLineTest(
            SpecFlowFeature feature,
            Scenario scenario,
            SpecFlowStep step,
            ParameterSubstitution paramToIdentifier)
        {
            // Test method
            var testMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = NamingHelper.GetTestName(feature, step)
            };

            testMethod.Statements.Add(new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                    new CodeThisReferenceExpression(),
                    NamingHelper.TestWrapperMethodName),
                new CodeMethodReferenceExpression(new CodeThisReferenceExpression(),
                    NamingHelper.GetTestStepsName(feature, step)), new CodePrimitiveExpression(step.Location.Line)));

            _context.UnitTestGeneratorProvider.SetTestMethod(_context, testMethod, NamingHelper.GetTestName(feature, step));

            _context.TestClass.Members.Add(testMethod);

            // Test steps
            var stepsMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Private,
                Name = NamingHelper.GetTestStepsName(feature, step)
            };

            AddActionStatementsForScenarioStep(feature, stepsMethod.Statements, scenario, step, paramToIdentifier);

            _context.TestClass.Members.Add(stepsMethod);

        }

        private void AddBackgroundLineTest(SpecFlowFeature feature, SpecFlowStep step)
        {
            // Test method
            var testMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = NamingHelper.GetTestName(feature, step)
            };

            testMethod.Statements.Add(new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                    new CodeThisReferenceExpression(),
                    NamingHelper.TestWrapperMethodName),
                new CodeMethodReferenceExpression(new CodeThisReferenceExpression(),
                    NamingHelper.GetTestStepsName(feature, step)), new CodePrimitiveExpression(step.Location.Line)));

            _context.UnitTestGeneratorProvider.SetTestMethod(_context, testMethod, NamingHelper.GetTestName(feature, step));

            _context.TestClass.Members.Add(testMethod);

            // Test steps
            var stepsMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Private,
                Name = NamingHelper.GetTestStepsName(feature, step)
            };

            AddActionStatementsForBackgroundStep(feature, stepsMethod.Statements, step);

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

        private void AddActionStatementsForScenarioStep(
            SpecFlowFeature feature,
            CodeStatementCollection statements,
            Scenario scenario,
            SpecFlowStep step,
            ParameterSubstitution paramToIdentifier)
        {
            IEnumerable<TableRow> rows = new List<TableRow> { null };
            if (scenario is ScenarioOutline scenarioOutline)
            {
                rows = scenario.Examples.SelectMany(exampleSet => exampleSet.TableBody);
            }

            foreach (TableRow row in rows)
            {
                if (feature.Background != null)
                {
                    foreach (SpecFlowStep backgroundStep in feature.Background.Steps)
                    {
                        GenerateStep(statements, backgroundStep, null, null, backgroundStep.StepKeyword,
                            backgroundStep.Keyword);
                    }
                }

                foreach (SpecFlowStep scenarioStep in scenario.Steps.Where(x => x != step))
                {
                    FixStepKeyWordForScenarioStep(scenario, scenarioStep, step, out StepKeyword stepKeyWord,
                        out string keyWord);

                    GenerateStep(statements, scenarioStep, paramToIdentifier, row, stepKeyWord, keyWord);
                }
            }
        }

        private void FixStepKeyWordForScenarioStep(Scenario scenario, SpecFlowStep executionStep, SpecFlowStep testingStep, out StepKeyword stepKeyWord, out string keyWord)
        {
            stepKeyWord = executionStep.StepKeyword;
            keyWord = executionStep.Keyword;
            if (executionStep.StepKeyword == StepKeyword.And)
            {
                int scenarioStepIndex = scenario.Steps.ToList().IndexOf(executionStep);
                int stepIndex = scenario.Steps.ToList().IndexOf(testingStep);
                if (scenarioStepIndex == stepIndex + 1)
                {
                    stepKeyWord = testingStep.StepKeyword;
                    keyWord = testingStep.Keyword;
                }
            }
        }

        private void FixStepKeyWordForScenarioStep(SpecFlowFeature feature, SpecFlowStep executionStep, SpecFlowStep testingStep, out StepKeyword stepKeyWord, out string keyWord)
        {
            stepKeyWord = executionStep.StepKeyword;
            keyWord = executionStep.Keyword;
            if (executionStep.StepKeyword == StepKeyword.And)
            {
                int scenarioStepIndex = feature.Background.Steps.ToList().IndexOf(executionStep);
                int stepIndex = feature.Background.Steps.ToList().IndexOf(testingStep);
                if (scenarioStepIndex == stepIndex + 1)
                {
                    stepKeyWord = testingStep.StepKeyword;
                    keyWord = testingStep.Keyword;
                }
            }
        }

        private void AddActionStatementsForBackgroundStep(
            SpecFlowFeature feature,
            CodeStatementCollection statements,
            SpecFlowStep step)
        {
            foreach (Scenario scenario in feature.Children.OfType<Scenario>())
            {
                IEnumerable<TableRow> rows = new List<TableRow> { null };
                if (scenario is ScenarioOutline scenarioOutline)
                {
                    rows = scenario.Examples.SelectMany(exampleSet => exampleSet.TableBody);
                }

                foreach (TableRow row in rows)
                {
                    foreach (SpecFlowStep backgroundStep in feature.Background.Steps.Where(x => x != step))
                    {
                        FixStepKeyWordForScenarioStep(feature, backgroundStep, step, out StepKeyword stepKeyWord,
                            out string keyWord);

                        GenerateStep(statements, backgroundStep, null, null, stepKeyWord, keyWord);
                    }

                    foreach (SpecFlowStep scenarioStep in scenario.Steps)
                    {
                        GenerateStep(statements, scenarioStep, null, row, scenarioStep.StepKeyword, scenarioStep.Keyword);
                    }
                }
            }
        }

        private void GenerateStep(CodeStatementCollection statements,
            Step scenarioStep,
            ParameterSubstitution paramToIdentifier,
            TableRow row,
            StepKeyword stepKeyWord,
            string keyWord)
        {
            var specFlowStep = AsSpecFlowStep(scenarioStep);

            //testRunner.Given("something");
            var arguments = new List<CodeExpression>
            {
                GetSubstitutedString(scenarioStep.Text, paramToIdentifier, row),
                GetDocStringArgExpression(scenarioStep.Argument as DocString, paramToIdentifier, row),
                GetTableArgExpression(scenarioStep.Argument as DataTable, statements, paramToIdentifier, row),
                new CodePrimitiveExpression(keyWord)
            };

            AddLineDirective(statements, scenarioStep);
            statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeVariableReferenceExpression(NamingHelper.TestRunnerVariableName),
                        stepKeyWord.ToString()),
                    arguments.ToArray())));
        }

        private SpecFlowStep AsSpecFlowStep(Step step)
        {
            var specFlowStep = step as SpecFlowStep;
            if (specFlowStep == null)
                throw new TestGeneratorException("The step must be a SpecFlowStep.");
            return specFlowStep;
        }

        private CodeExpression GetTableArgExpression(
            DataTable tableArg,
            CodeStatementCollection statements,
            ParameterSubstitution paramToIdentifier,
            TableRow parametersRow)
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
                        GetStringArrayExpression(header.Cells.Select(c => c.Value), paramToIdentifier, null))));

            foreach (var row in body)
            {
                //table0.AddRow(cells...);
                statements.Add(
                    new CodeMethodInvokeExpression(
                        tableVar,
                        "AddRow",
                        GetStringArrayExpression(row.Cells.Select(cell => GetCellValue(cell, paramToIdentifier, parametersRow)), paramToIdentifier, 
                            null)));
            }

            return tableVar;
        }

        private static string GetCellValue(TableCell cell, ParameterSubstitution paramToIdentifier,
            TableRow parametersRow)
        {
            var cellValue = cell.Value.Trim();
            if (parametersRow == null)
            {
                return cellValue;
            }

            if (cellValue.StartsWith("<") && cellValue.EndsWith(">") &&
                paramToIdentifier.TryGetIdentifier(cellValue.Substring(1, cellValue.Length - 2), out int paramIndex))
            {
                cellValue = parametersRow.Cells.ElementAt(paramToIdentifier[paramIndex].Value).Value;
                return cellValue;
            }

            return cellValue;
        }

        private CodeExpression GetStringArrayExpression(IEnumerable<string> items, ParameterSubstitution paramToIdentifier, TableRow row)
        {
            return new CodeArrayCreateExpression(typeof(string[]), items.Select(item => GetSubstitutedString(item, paramToIdentifier, row)).ToArray());
        }


        private CodeExpression GetDocStringArgExpression(DocString docString, ParameterSubstitution paramToIdentifier, TableRow row)
        {
            return GetSubstitutedString(docString == null ? null : docString.Content, paramToIdentifier, row);
        }

        private CodeExpression GetSubstitutedString(string text, ParameterSubstitution paramToIdentifier, TableRow row)
        {
            if (text == null)
                return new CodeCastExpression(typeof(string), new CodePrimitiveExpression(null));
            if (paramToIdentifier == null)
                return new CodePrimitiveExpression(text);
            if (row == null)
                return new CodePrimitiveExpression(text);

            Regex paramRe = new Regex(@"\<(?<param>[^\>]+)\>");
            string formatText = text.Replace("{", "{{").Replace("}", "}}");
            List<int> arguments = new List<int>();

            formatText = paramRe.Replace(formatText, match =>
            {
                string param = match.Groups["param"].Value;
                int id;
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
            formatArguments.AddRange(arguments.Select(id => new CodePrimitiveExpression(row.Cells.ElementAt(id).Value)));

            return new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(typeof(string)),
                "Format",
                formatArguments.ToArray());
        }

        private ParameterSubstitution CreateParamToIdentifierMapping(ScenarioOutline scenarioOutline)
        {
            ParameterSubstitution paramToIdentifier = new ParameterSubstitution();
            int index = 0;
            foreach (var param in scenarioOutline.Examples.First().TableHeader.Cells)
            {
                paramToIdentifier.Add(param.Value, index);
                index++;
            }

            return paramToIdentifier;
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

        public static string GetTestName(SpecFlowFeature feature, SpecFlowStep step)
        {
            int digitCountInTotalLines =
                feature.ScenarioDefinitions.Last().Steps.Last().Location.Line.ToString().Length;

            string lineNumberLeadingZeros =
                new string('0', digitCountInTotalLines - step.Location.Line.ToString().Length);
            return $"TestLine{lineNumberLeadingZeros}{step.Location.Line}{step.Text.ToIdentifier()}";
        }

        public static string GetTestStepsName(SpecFlowFeature feature, SpecFlowStep step)
        {
            return GetTestName(feature, step) + "Steps";
        }
    }

    internal class ParameterSubstitution : List<KeyValuePair<string, int>>
    {
        public void Add(string parameter, int index)
        {
            Add(new KeyValuePair<string, int>(parameter.Trim(), index));
        }

        public bool TryGetIdentifier(string param, out int index)
        {
            param = param.Trim();
            foreach (var pair in this)
            {
                if (pair.Key.Equals(param))
                {
                    index = pair.Value;
                    return true;
                }
            }

            // Indicate invalid indexing
            index = -1;
            return false;
        }
    }
}
