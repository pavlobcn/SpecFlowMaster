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
namespace PB.SpecFlowMaster.Examples.XUnit
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SpecFlowTargetFeature : Xunit.IClassFixture<SpecFlowTargetFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SpecFlowTarget.feature"
#line hidden
        
        public SpecFlowTargetFeature(SpecFlowTargetFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
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
#line 6
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Add two numbers123456789QW1abcd")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "Add two numbers123456789QW1abcd")]
        [Xunit.TraitAttribute("Category", "mytag")]
        public virtual void AddTwoNumbers123456789QW1Abcd()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two numbers123456789QW1abcd", null, new string[] {
                        "mytag"});
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SpecFlowTargetFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SpecFlowTargetFeature.FeatureTearDown();
            }
        }
    }
    
    public partial class SpecFlowTargetFeatureMaster : Xunit.IClassFixture<SpecFlowTargetFeatureMaster.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SpecFlowTarget.feature"
#line hidden
        
        public SpecFlowTargetFeatureMaster(SpecFlowTargetFeatureMaster.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowTarget", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, null);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
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
#line 6
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        public virtual void Test(System.Action steps, int lineNumber)
        {
            bool noExceptionOccured = true;
            try
            {
                TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlowTarget", null);
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
        
        [Xunit.FactAttribute(DisplayName="TestLine07IHaveEntered15IntoTheCalculator")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine07IHaveEntered15IntoTheCalculator")]
        public virtual void TestLine07IHaveEntered15IntoTheCalculator()
        {
            this.Test(this.TestLine07IHaveEntered15IntoTheCalculatorSteps, 7);
        }
        
        private void TestLine07IHaveEntered15IntoTheCalculatorSteps()
        {
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine08IHaveEntered25IntoTheCalculator")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine08IHaveEntered25IntoTheCalculator")]
        public virtual void TestLine08IHaveEntered25IntoTheCalculator()
        {
            this.Test(this.TestLine08IHaveEntered25IntoTheCalculatorSteps, 8);
        }
        
        private void TestLine08IHaveEntered25IntoTheCalculatorSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine09IPressAdd")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine09IPressAdd")]
        public virtual void TestLine09IPressAdd()
        {
            this.Test(this.TestLine09IPressAddSteps, 9);
        }
        
        private void TestLine09IPressAddSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine13IHaveEntered10IntoTheCalculator")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine13IHaveEntered10IntoTheCalculator")]
        public virtual void TestLine13IHaveEntered10IntoTheCalculator()
        {
            this.Test(this.TestLine13IHaveEntered10IntoTheCalculatorSteps, 13);
        }
        
        private void TestLine13IHaveEntered10IntoTheCalculatorSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine14IHaveEntered50IntoTheCalculator")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine14IHaveEntered50IntoTheCalculator")]
        public virtual void TestLine14IHaveEntered50IntoTheCalculator()
        {
            this.Test(this.TestLine14IHaveEntered50IntoTheCalculatorSteps, 14);
        }
        
        private void TestLine14IHaveEntered50IntoTheCalculatorSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine15IHaveEntered70IntoTheCalculator")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine15IHaveEntered70IntoTheCalculator")]
        public virtual void TestLine15IHaveEntered70IntoTheCalculator()
        {
            this.Test(this.TestLine15IHaveEntered70IntoTheCalculatorSteps, 15);
        }
        
        private void TestLine15IHaveEntered70IntoTheCalculatorSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [Xunit.FactAttribute(DisplayName="TestLine16IPressAdd")]
        [Xunit.TraitAttribute("FeatureTitle", "SpecFlowTarget")]
        [Xunit.TraitAttribute("Description", "TestLine16IPressAdd")]
        public virtual void TestLine16IPressAdd()
        {
            this.Test(this.TestLine16IPressAddSteps, 16);
        }
        
        private void TestLine16IPressAddSteps()
        {
#line 7
 testRunner.Given("I have entered 15 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have entered 25 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Given("I have entered 10 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SpecFlowTargetFeatureMaster.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SpecFlowTargetFeatureMaster.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
