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
namespace PB.SpecFlowMaster.Examples.Nunit2
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowScenarioOutline")]
    public partial class SpecFlowScenarioOutlineFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutline.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutline", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
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
        [NUnit.Framework.DescriptionAttribute("Test without unnecessary steps")]
        [NUnit.Framework.TestCaseAttribute("10", "20", null)]
        [NUnit.Framework.TestCaseAttribute("20", "30", null)]
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
 testRunner.And(string.Format("executed When step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test with unnecessary steps")]
        [NUnit.Framework.TestCaseAttribute("10", "20", null)]
        [NUnit.Framework.TestCaseAttribute("20", "30", null)]
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
 testRunner.Then(string.Format("executed When step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test with unnecessary steps and table as a parameter")]
        [NUnit.Framework.TestCaseAttribute("10", "20", null)]
        [NUnit.Framework.TestCaseAttribute("20", "30", null)]
        public virtual void TestWithUnnecessaryStepsAndTableAsAParameter(string param1, string param2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test with unnecessary steps and table as a parameter", null, exampleTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table1.AddRow(new string[] {
                        string.Format("{0}", param1)});
#line 26
 testRunner.Given("step with parameters", ((string)(null)), table1, "Given ");
#line 29
 testRunner.When(string.Format("execute with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then(string.Format("executed When step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
    
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowScenarioOutline")]
    public partial class SpecFlowScenarioOutlineFeatureMaster
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutline.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutline", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, null);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine05StepWithParameterParam1")]
        public virtual void TestLine05StepWithParameterParam1()
        {
            this.Test(new System.Action(this.TestLine05StepWithParameterParam1Steps), 5);
        }
        
        private void TestLine05StepWithParameterParam1Steps()
        {
#line 6
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine06ExecuteWithParameterParam2")]
        public virtual void TestLine06ExecuteWithParameterParam2()
        {
            this.Test(new System.Action(this.TestLine06ExecuteWithParameterParam2Steps), 6);
        }
        
        private void TestLine06ExecuteWithParameterParam2Steps()
        {
#line 5
 testRunner.Given(string.Format("step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 5
 testRunner.Given(string.Format("step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine16StepWithParameterParam1")]
        public virtual void TestLine16StepWithParameterParam1()
        {
            this.Test(new System.Action(this.TestLine16StepWithParameterParam1Steps), 16);
        }
        
        private void TestLine16StepWithParameterParam1Steps()
        {
#line 17
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine17ExecuteWithParameterParam2")]
        public virtual void TestLine17ExecuteWithParameterParam2()
        {
            this.Test(new System.Action(this.TestLine17ExecuteWithParameterParam2Steps), 17);
        }
        
        private void TestLine17ExecuteWithParameterParam2Steps()
        {
#line 16
 testRunner.Given(string.Format("step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Then(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.Given(string.Format("step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Then(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine26StepWithParameters")]
        public virtual void TestLine26StepWithParameters()
        {
            this.Test(new System.Action(this.TestLine26StepWithParametersSteps), 26);
        }
        
        private void TestLine26StepWithParametersSteps()
        {
#line 29
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine29ExecuteWithParameterParam2")]
        public virtual void TestLine29ExecuteWithParameterParam2()
        {
            this.Test(new System.Action(this.TestLine29ExecuteWithParameterParam2Steps), 29);
        }
        
        private void TestLine29ExecuteWithParameterParam2Steps()
        {
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table1.AddRow(new string[] {
                        "10"});
#line 26
 testRunner.Given("step with parameters", ((string)(null)), table1, "Given ");
#line 30
 testRunner.Then(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table2.AddRow(new string[] {
                        "20"});
#line 26
 testRunner.Given("step with parameters", ((string)(null)), table2, "Given ");
#line 30
 testRunner.Then(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
    }
}
#pragma warning restore
#endregion
