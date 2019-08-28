using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.Examples
{
    [Binding]
    public class SpecFlowTargetSteps : Steps
    {
        private readonly List<int> _numbers = new List<int>();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _numbers.Add(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _numbers[_numbers.Count - 2] + _numbers[_numbers.Count - 1];
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            AreEqual(p0, _result);
        }
    }
}
