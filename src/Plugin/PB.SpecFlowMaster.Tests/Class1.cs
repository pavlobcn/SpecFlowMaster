

using TechTalk.SpecFlow;

public class FeatureTest
{
}

[NUnit.Framework.TestFixtureAttribute()]
[NUnit.Framework.DescriptionAttribute("SpecFlowScenarioOutline")]
public partial class SpecFlowScenarioOutlineFeatureMaster
{

    private TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "SpecFlowTarget.feature.txt"
#line hidden

    [NUnit.Framework.OneTimeSetUpAttribute()]
    public virtual void FeatureSetup()
    {
        testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
        TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "SpecFlowScenarioOutline", "\tTest to check which steps in scenario outline execution are really needed for go" +
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
        catch (System.Exception)
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
        this.Test(this.TestLine05StepWithParameterParam1Steps, 5);
    }

    private void TestLine05StepWithParameterParam1Steps()
    {
#line 6
        //#indentnext 1
        testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
        //#indentnext 1
        testRunner.And(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
        //#indentnext 1
        testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
        //#indentnext 1
        testRunner.And(string.Format("executed Given step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
    }

    [NUnit.Framework.TestAttribute()]
    [NUnit.Framework.DescriptionAttribute("TestLine06ExecuteWithParameterParam2")]
    public virtual void TestLine06ExecuteWithParameterParam2()
    {
        this.Test(this.TestLine06ExecuteWithParameterParam2Steps, 6);
    }

    private void TestLine06ExecuteWithParameterParam2Steps()
    {
#line 5
        //#indentnext 1
        testRunner.Given(string.Format("step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
        //#indentnext 1
        testRunner.And(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 5
        //#indentnext 1
        testRunner.Given(string.Format("step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
        //#indentnext 1
        testRunner.And(string.Format("executed Given step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
    }

    [NUnit.Framework.TestAttribute()]
    [NUnit.Framework.DescriptionAttribute("TestLine16StepWithParameterParam1")]
    public virtual void TestLine16StepWithParameterParam1()
    {
        this.Test(this.TestLine16StepWithParameterParam1Steps, 16);
    }

    private void TestLine16StepWithParameterParam1Steps()
    {
#line 17
        //#indentnext 1
        testRunner.When(string.Format("execute with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
        //#indentnext 1
        testRunner.When(string.Format("execute with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
    }

    [NUnit.Framework.TestAttribute()]
    [NUnit.Framework.DescriptionAttribute("TestLine17ExecuteWithParameterParam2")]
    public virtual void TestLine17ExecuteWithParameterParam2()
    {
        this.Test(this.TestLine17ExecuteWithParameterParam2Steps, 17);
    }

    private void TestLine17ExecuteWithParameterParam2Steps()
    {
#line 16
        //#indentnext 1
        testRunner.Given(string.Format("step with parameter {0}", "10"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
        //#indentnext 1
        testRunner.Given(string.Format("step with parameter {0}", "20"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
        //#indentnext 1
        testRunner.Then(string.Format("executed Given step with parameter {0}", "30"), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
    }
}
