using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.Examples
{
    [Binding]
    public class SpecFlowTargetSteps : Steps
    {
        private readonly HashSet<int> _givenExecutionParameters;
        private readonly HashSet<int> _whenExecutionParameters;

        public SpecFlowTargetSteps()
        {
            _givenExecutionParameters = new HashSet<int>();
            _whenExecutionParameters = new HashSet<int>();
        }

        [Given(@"step with parameter (.*)")]
        public void GivenStepWithParameter(int parameter)
        {
            _givenExecutionParameters.Add(parameter);
        }

        [Given(@"step with parameters")]
        public void GivenStepWithParameter(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _givenExecutionParameters.Add(int.Parse(row["ParamValue"]));
            }
        }

        [When(@"execute with parameter (.*)")]
        public void WhenExecuteWithParameter(int parameter)
        {
            _whenExecutionParameters.Add(parameter);
        }

        [Then(@"executed Given step with parameter (.*)")]
        public void ThenExecutedGivenStepWithParameter(int parameter)
        {
            AreEqual(true, _givenExecutionParameters.Contains(parameter));
        }

        [Then(@"executed When step with parameter (.*)")]
        public void ThenExecutedWhenStepWithParameter(int parameter)
        {
            AreEqual(true, _whenExecutionParameters.Contains(parameter));
        }
    }
}
