using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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
                }
            }
        }

        private CodeTypeDeclaration GetTypeDeclaration()
        {
            var testClass = new CodeTypeDeclaration("MasterTests");
            return testClass;
        }
    }
}
