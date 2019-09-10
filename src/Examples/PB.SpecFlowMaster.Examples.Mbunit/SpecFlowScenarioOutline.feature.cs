// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PB.SpecFlowMaster.Examples.Mbunit
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [MbUnit.Framework.TestFixtureAttribute()]
    [MbUnit.Framework.DescriptionAttribute("\tTest to check which steps in scenario outline execution are really needed for go" +
        "od tests")]
    public partial class SpecFlowScenarioOutlineFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutline.feature"
#line hidden
        
        [MbUnit.Framework.FixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutline", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [MbUnit.Framework.FixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [MbUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [MbUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [MbUnit.Framework.RowTestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("Test without unnecessary steps")]
        [MbUnit.Framework.RowAttribute("10", "20", new string[0])]
        [MbUnit.Framework.RowAttribute("20", "30", new string[0])]
        public virtual void TestWithoutUnnecessarySteps(string param1, string param2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test without unnecessary steps", null, exampleTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given(string.Format("step with parameter {0}", param1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.When(string.Format("execute with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then(string.Format("executed Given step with parameter {0}", param1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And(string.Format("executed Given step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [MbUnit.Framework.RowTestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("Test with unnecessary steps")]
        [MbUnit.Framework.RowAttribute("10", "20", new string[0])]
        [MbUnit.Framework.RowAttribute("20", "30", new string[0])]
        public virtual void TestWithUnnecessarySteps(string param1, string param2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test with unnecessary steps", null, exampleTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 16
 testRunner.Given(string.Format("step with parameter {0}", param1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When(string.Format("execute with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("executed Given step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
    
    [MbUnit.Framework.TestFixtureAttribute()]
    [MbUnit.Framework.DescriptionAttribute("\tTest to check which steps in scenario outline execution are really needed for go" +
        "od tests")]
    public partial class SpecFlowScenarioOutlineFeatureMaster
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutline.feature"
#line hidden
        
        [MbUnit.Framework.FixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutline", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, null);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [MbUnit.Framework.FixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [MbUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [MbUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
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
        
        public virtual void Test(System.Action steps, int lineNumber)
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowScenarioOutline", null);
                testRunner.OnScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
                steps();
                this.ScenarioCleanup();
            }
            catch (System.Exception )
            {
                noExceptionOccured = false;
            }
            if (noExceptionOccured)
            {
                throw new System.Exception(string.Format("Line {0} is suspicious.", lineNumber));
            }
        }
        
        [MbUnit.Framework.TestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("TestLine05StepWithParameterParam1")]
        public virtual void TestLine05StepWithParameterParam1()
        {
            this.Test(this.TestLine05StepWithParameterParam1Steps, 5);
        }
        
        private void TestLine05StepWithParameterParam1Steps()
        {
#line 6
 testRunner.When("execute with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then("executed Given step with parameter <Param1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And("executed Given step with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
        }
        
        [MbUnit.Framework.TestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("TestLine06ExecuteWithParameterParam2")]
        public virtual void TestLine06ExecuteWithParameterParam2()
        {
            this.Test(this.TestLine06ExecuteWithParameterParam2Steps, 6);
        }
        
        private void TestLine06ExecuteWithParameterParam2Steps()
        {
#line 5
 testRunner.Given("step with parameter <Param1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.Then("executed Given step with parameter <Param1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And("executed Given step with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
        }
        
        [MbUnit.Framework.TestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("TestLine16StepWithParameterParam1")]
        public virtual void TestLine16StepWithParameterParam1()
        {
            this.Test(this.TestLine16StepWithParameterParam1Steps, 16);
        }
        
        private void TestLine16StepWithParameterParam1Steps()
        {
#line 17
 testRunner.When("execute with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("executed Given step with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [MbUnit.Framework.TestAttribute()]
        [MbUnit.Framework.DescriptionAttribute("TestLine17ExecuteWithParameterParam2")]
        public virtual void TestLine17ExecuteWithParameterParam2()
        {
            this.Test(this.TestLine17ExecuteWithParameterParam2Steps, 17);
        }
        
        private void TestLine17ExecuteWithParameterParam2Steps()
        {
#line 16
 testRunner.Given("step with parameter <Param1>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Then("executed Given step with parameter <Param2>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
    }
}
#pragma warning restore
#endregion
