﻿using System;
using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.TargetTests
{
    [Binding]
    public class SpecFlowTargetSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Tmp();
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        public static void Tmp()
        {
            //var a = new SampleGeneratorPlugin();
        }
    }
}
