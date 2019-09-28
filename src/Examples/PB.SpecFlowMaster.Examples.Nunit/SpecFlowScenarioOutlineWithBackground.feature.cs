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
namespace PB.SpecFlowMaster.Examples.Nunit
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowScenarioOutlineWithBackground")]
    public partial class SpecFlowScenarioOutlineWithBackgroundFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutlineWithBackground.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutlineWithBackground", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 4
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test without unnecessary steps")]
        [NUnit.Framework.TestCaseAttribute("10", "20", "21", null)]
        [NUnit.Framework.TestCaseAttribute("20", "30", "21", null)]
        public virtual void TestWithoutUnnecessarySteps(string param1, string param2, string param3, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test without unnecessary steps", null, exampleTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table2.AddRow(new string[] {
                        string.Format("{0}", param1)});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table2, "Given ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", param1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", param2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", param3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
    
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SpecFlowScenarioOutlineWithBackground")]
    public partial class SpecFlowScenarioOutlineWithBackgroundFeatureMaster
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowScenarioOutlineWithBackground.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowScenarioOutlineWithBackground", "\tTest to check which steps in scenario outline execution are really needed for go" +
                    "od tests", ProgrammingLanguage.CSharp, null);
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
        
        public virtual void FeatureBackground()
        {
        }
        
        public virtual void Test(System.Action steps, int lineNumber)
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowScenarioOutlineWithBackground", null);
                testRunner.OnScenarioInitialize(scenarioInfo);
                this.ScenarioStart();
                NUnit.Framework.Internal.TestExecutionContext.IsolatedContext testExecutionContext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                try
                {
                    steps();
                }
                finally
                {
                    testExecutionContext.Dispose();
                }
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
        [NUnit.Framework.DescriptionAttribute("TestLine06StepWithParameter9")]
        public virtual void TestLine06StepWithParameter9()
        {
            this.Test(new System.Action(this.TestLine06StepWithParameter9Steps), 6);
        }
        
        private void TestLine06StepWithParameter9Steps()
        {
#line 7
 testRunner.Given("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table1.AddRow(new string[] {
                        "10"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table1, "Given ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.Given("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table2.AddRow(new string[] {
                        "20"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table2, "Given ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine07StepWithParameter21")]
        public virtual void TestLine07StepWithParameter21()
        {
            this.Test(new System.Action(this.TestLine07StepWithParameter21Steps), 7);
        }
        
        private void TestLine07StepWithParameter21Steps()
        {
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table3.AddRow(new string[] {
                        "10"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table3, "Given ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table4.AddRow(new string[] {
                        "20"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table4, "Given ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine10StepWithParameters")]
        public virtual void TestLine10StepWithParameters()
        {
            this.Test(new System.Action(this.TestLine10StepWithParametersSteps), 10);
        }
        
        private void TestLine10StepWithParametersSteps()
        {
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TestLine13ExecuteWithParameterParam2")]
        public virtual void TestLine13ExecuteWithParameterParam2()
        {
            this.Test(new System.Action(this.TestLine13ExecuteWithParameterParam2Steps), 13);
        }
        
        private void TestLine13ExecuteWithParameterParam2Steps()
        {
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table5.AddRow(new string[] {
                        "10"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table5, "Given ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.Given("step with parameter 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("step with parameter 21", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParamValue"});
            table6.AddRow(new string[] {
                        "20"});
#line 10
 testRunner.Given("step with parameters", ((string)(null)), table6, "Given ");
#line 14
 testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("executed When step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("executed Given step with parameter {0}", "21"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
    }
}
#pragma warning restore
#endregion
