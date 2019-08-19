using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Ast;
using TechTalk.SpecFlow.Parser;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class MasterClassGenerator
    {
        private SpecFlowDocument _document;
        private CodeNamespace _codeNamespace;

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
                foreach (SpecFlowStep step in scenario.Steps.OfType<SpecFlowStep>().Where(x => x.ScenarioBlock == ScenarioBlock.Given || x.ScenarioBlock == ScenarioBlock.Then))
                {
                    var testMethod = new CodeMemberMethod();
                    testClass.Members.Add(testMethod);

                    testMethod.Name = "TestLine" + step.Location.Line;
                    testMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(bool),
                        "expectedExceptionOccured", new CodePrimitiveExpression(false)));
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
                                        new CodeVariableReferenceExpression("expectedExceptionOccured"),
                                        new CodePrimitiveExpression(true))
                                }
                            }
                        }
                    };
                    testMethod.Statements.Add(tryCatchStatement);
                    var exceptionValidationStatement = new CodeConditionStatement
                    {
                        Condition = new UnaryExpression
                        {
                            
                        }
                    }
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
