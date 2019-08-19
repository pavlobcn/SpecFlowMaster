using System;
using System.CodeDom;
using System.Linq;
using Gherkin.Ast;
using TechTalk.SpecFlow.Parser;

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
                    var testMethod = new CodeMemberMethod();
                    testClass.Members.Add(testMethod);

                    testMethod.Name = "TestLine" + step.Location.Line;
                    testMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(bool),
                        "noExceptionOccured", new CodePrimitiveExpression(true)));
                    var tryCatchStatement = new CodeTryCatchFinallyStatement
                    {
                        TryStatements = { },
                        CatchClauses =
                        {
                            new CodeCatchClause()
                            {
                                Statements =
                                {
                                    new CodeAssignStatement(
                                        new CodeVariableReferenceExpression("noExceptionOccured"),
                                        new CodePrimitiveExpression(false))
                                }
                            }
                        }
                    };
                    testMethod.Statements.Add(tryCatchStatement);
                    var exceptionValidationStatement = new CodeConditionStatement
                    {
                        Condition = new CodeVariableReferenceExpression("noExceptionOccured"),
                        TrueStatements =
                        {
                            new CodeThrowExceptionStatement
                            {
                                ToThrow = new CodeObjectCreateExpression(typeof(Exception),
                                    new CodePrimitiveExpression($"Line {step.Location.Line} is suspicious."))
                            }
                        }
                    };
                    testMethod.Statements.Add(exceptionValidationStatement);
                }
            }
        }

        private CodeTypeDeclaration GetTypeDeclaration()
        {
            var testClass = new CodeTypeDeclaration("MasterTests");
            return testClass;
        }

        private void TestTemplate()
        {
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
        }
    }
}
