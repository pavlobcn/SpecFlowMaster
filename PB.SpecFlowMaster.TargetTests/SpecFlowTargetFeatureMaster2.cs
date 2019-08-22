using NUnit.Framework.Internal;
using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.TargetTests
{
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowTarget")]
    public partial class SpecFlowTargetFeatureMaster2
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowTarget.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                                                                                                                                                           "f two numbers", ProgrammingLanguage.CSharp, null);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        private void FeatureBackground()
        {
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine8")]
        public virtual void TestLine8()
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
                testRunner.OnScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
#line 9
                testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
                testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
                testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
                this.ScenarioCleanup();
            }
            catch (System.Exception )
            {
                noExceptionOccured = false;
            }
            if (noExceptionOccured)
            {
                throw new System.Exception("Line 8 is suspicious.");
            }
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine9")]
        public virtual void TestLine9()
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
                testRunner.OnScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
#line 8
                testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
                testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
                testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
                this.ScenarioCleanup();
            }
            catch (System.Exception )
            {
                noExceptionOccured = false;
            }
            if (noExceptionOccured)
            {
                throw new System.Exception("Line 9 is suspicious.");
            }
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine10")]
        public virtual void TestLine10()
        {
            bool noExceptionOccured = true;
            try
            {
                using (new TestExecutionContext.IsolatedContext())
                {
                    TechTalk.SpecFlow.ScenarioInfo scenarioInfo =
                        new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
                    testRunner.OnScenarioInitialize(scenarioInfo);
                    this.ScenarioStart();
#line 8
                    testRunner.Given("I have entered 50 into the calculator", ((string) (null)),
                        ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 9
                    testRunner.And("I have entered 70 into the calculator", ((string) (null)),
                        ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 11
                    testRunner.Then("the result should be 120 on the screen", ((string) (null)),
                        ((TechTalk.SpecFlow.Table) (null)), "Then ");
                    this.ScenarioCleanup();
                }
            }
            catch (System.Exception )
            {
                noExceptionOccured = false;
            }
            if (noExceptionOccured)
            {
                throw new System.Exception("Line 10 is suspicious.");
            }
        }
    }
}