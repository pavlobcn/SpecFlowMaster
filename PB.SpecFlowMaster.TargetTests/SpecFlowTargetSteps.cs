using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.TargetTests
{
    [Binding]
    public class SpecFlowTargetSteps
    {
        private List<int> numbers = new List<int>();
        private int result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            numbers.Add(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = numbers[numbers.Count - 2] + numbers[numbers.Count - 1];
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, result);
        }
    }
}
