using TechTalk.SpecFlow;

namespace PB.SpecFlowMaster.TargetTests
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowTarget")]
    public partial class MasterTests2
    {
        private TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SpecFlowTarget.feature"
#line hidden

        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                                                                                                                                                           "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine8")]
        public virtual void TestLine8()
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
                this.ScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
                testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
                testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 7
this.ScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
#line 8
testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
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
        [NUnit.Framework.DescriptionAttribute("TestLine11")]
        public virtual void TestLine11()
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ITestRunner testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
                TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                                                                                                                                                               "f two numbers", ProgrammingLanguage.CSharp, null);
                testRunner.OnFeatureStart(featureInfo);
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
                testRunner.OnScenarioInitialize(scenarioInfo);
                testRunner.OnScenarioStart();
                testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
                testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
                testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
            }
            catch (System.Exception )
            {
                noExceptionOccured = false;
            }
            if (noExceptionOccured)
            {
                throw new System.Exception("Line 11 is suspicious.");
            }
        }
    }
}