'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by SpecFlow (http://www.specflow.org/).
'     SpecFlow Version:3.0.0.0
'     SpecFlow Generator Version:3.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
#Region "Designer generated code"
'#pragma warning disable
Imports TechTalk.SpecFlow

Namespace Global.PB.SpecFlowMaster.Examples.VB
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0"),  _
     System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     NUnit.Framework.TestFixtureAttribute(),  _
     NUnit.Framework.DescriptionAttribute("SpecFlowIgnoreStep")>  _
    Partial Public Class SpecFlowIgnoreStepFeature
        
        Private testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("SpecFlowIgnoreStep.feature",1)
#End ExternalSource
        
        <NUnit.Framework.OneTimeSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "SpecFlowIgnoreStep", ""&Global.Microsoft.VisualBasic.ChrW(9)&"Test how step can be ignored", ProgrammingLanguage.VB, CType(Nothing,String()))
            testRunner.OnFeatureStart(featureInfo)
        End Sub
        
        <NUnit.Framework.OneTimeTearDownAttribute()>  _
        Public Overridable Sub FeatureTearDown()
            testRunner.OnFeatureEnd
            testRunner = Nothing
        End Sub
        
        <NUnit.Framework.SetUpAttribute()>  _
        Public Overridable Sub TestInitialize()
        End Sub
        
        <NUnit.Framework.TearDownAttribute()>  _
        Public Overridable Sub ScenarioTearDown()
            testRunner.OnScenarioEnd
        End Sub
        
        Public Overridable Sub ScenarioInitialize(ByVal scenarioInfo As TechTalk.SpecFlow.ScenarioInfo)
            testRunner.OnScenarioInitialize(scenarioInfo)
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs(Of NUnit.Framework.TestContext)(NUnit.Framework.TestContext.CurrentContext)
        End Sub
        
        Public Overridable Sub ScenarioStart()
            testRunner.OnScenarioStart
        End Sub
        
        Public Overridable Sub ScenarioCleanup()
            testRunner.CollectScenarioErrors
        End Sub
        
        Public Overridable Sub FeatureBackground()
#ExternalSource("SpecFlowIgnoreStep.feature",4)
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",5)
 testRunner.Given("step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",7)
 testRunner.And("step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",8)
 testRunner.When("execute with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Test with unnecessary steps. Will fails if steps are not ignored")>  _
        Public Overridable Sub TestWithUnnecessarySteps_WillFailsIfStepsAreNotIgnored()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Test with unnecessary steps. Will fails if steps are not ignored", Nothing, CType(Nothing,String()))
#ExternalSource("SpecFlowIgnoreStep.feature",10)
Me.ScenarioInitialize(scenarioInfo)
            Me.ScenarioStart
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",4)
Me.FeatureBackground
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",11)
 testRunner.Given("step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",12)
 testRunner.When("execute with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",14)
 testRunner.And("execute with parameter 131", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",15)
 testRunner.Then("executed Given step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",16)
 testRunner.And("executed Given step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",17)
 testRunner.And("executed When step with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",18)
 testRunner.And("executed Given step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",19)
 testRunner.And("executed When step with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
    End Class
    
    <NUnit.Framework.TestFixtureAttribute(),  _
     NUnit.Framework.DescriptionAttribute("SpecFlowIgnoreStep")>  _
    Partial Public Class SpecFlowIgnoreStepFeatureMaster
        
        Private testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("SpecFlowIgnoreStep.feature",1)
#End ExternalSource
        
        <NUnit.Framework.OneTimeSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(Nothing, 0)
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "SpecFlowIgnoreStep", ""&Global.Microsoft.VisualBasic.ChrW(9)&"Test how step can be ignored", ProgrammingLanguage.VB, Nothing)
            testRunner.OnFeatureStart(featureInfo)
        End Sub
        
        <NUnit.Framework.OneTimeTearDownAttribute()>  _
        Public Overridable Sub FeatureTearDown()
            testRunner.OnFeatureEnd
            testRunner = Nothing
        End Sub
        
        <NUnit.Framework.SetUpAttribute()>  _
        Public Overridable Sub TestInitialize()
        End Sub
        
        <NUnit.Framework.TearDownAttribute()>  _
        Public Overridable Sub ScenarioTearDown()
            testRunner.OnScenarioEnd
        End Sub
        
        Public Overridable Sub ScenarioInitialize(ByVal scenarioInfo As TechTalk.SpecFlow.ScenarioInfo)
            testRunner.OnScenarioInitialize(scenarioInfo)
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs(Of NUnit.Framework.TestContext)(NUnit.Framework.TestContext.CurrentContext)
        End Sub
        
        Public Overridable Sub ScenarioStart()
            testRunner.OnScenarioStart
        End Sub
        
        Public Overridable Sub ScenarioCleanup()
            testRunner.CollectScenarioErrors
        End Sub
        
        Public Overridable Sub FeatureBackground()
        End Sub
        
        Public Overridable Sub Test(ByVal steps As System.Action, ByVal lineNumber As Integer)
            Dim noExceptionOccured As Boolean = true
            Try 
                Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("SpecFlowIgnoreStep", Nothing)
                testRunner.OnScenarioInitialize(scenarioInfo)
                Me.ScenarioStart
                Dim testExecutionContext As NUnit.Framework.Internal.TestExecutionContext.IsolatedContext = New NUnit.Framework.Internal.TestExecutionContext.IsolatedContext()
                Try 
                    steps
                Finally
                    testExecutionContext.Dispose
                End Try
                Me.ScenarioCleanup
            Catch __exception As System.Exception
                noExceptionOccured = false
            End Try
            If noExceptionOccured Then
                Throw New System.Exception(String.Format("Line {0} is suspicious.", lineNumber))
            End If
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("TestLine05StepWithParameter10")>  _
        Public Overridable Sub TestLine05StepWithParameter10()
            Me.Test(AddressOf Me.TestLine05StepWithParameter10Steps, 5)
        End Sub
        
        Private Sub TestLine05StepWithParameter10Steps()
#ExternalSource("SpecFlowIgnoreStep.feature",7)
 testRunner.Given("step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",8)
 testRunner.When("execute with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",11)
 testRunner.Given("step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",12)
 testRunner.When("execute with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",14)
 testRunner.And("execute with parameter 131", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",15)
 testRunner.Then("executed Given step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",16)
 testRunner.And("executed Given step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",17)
 testRunner.And("executed When step with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",18)
 testRunner.And("executed Given step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",19)
 testRunner.And("executed When step with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("TestLine08ExecuteWithParameter20")>  _
        Public Overridable Sub TestLine08ExecuteWithParameter20()
            Me.Test(AddressOf Me.TestLine08ExecuteWithParameter20Steps, 8)
        End Sub
        
        Private Sub TestLine08ExecuteWithParameter20Steps()
#ExternalSource("SpecFlowIgnoreStep.feature",5)
 testRunner.Given("step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",7)
 testRunner.And("step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",11)
 testRunner.Given("step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",12)
 testRunner.When("execute with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",14)
 testRunner.And("execute with parameter 131", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",15)
 testRunner.Then("executed Given step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",16)
 testRunner.And("executed Given step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",17)
 testRunner.And("executed When step with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",18)
 testRunner.And("executed Given step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",19)
 testRunner.And("executed When step with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("TestLine11StepWithParameter110")>  _
        Public Overridable Sub TestLine11StepWithParameter110()
            Me.Test(AddressOf Me.TestLine11StepWithParameter110Steps, 11)
        End Sub
        
        Private Sub TestLine11StepWithParameter110Steps()
#ExternalSource("SpecFlowIgnoreStep.feature",5)
 testRunner.Given("step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",7)
 testRunner.And("step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",8)
 testRunner.When("execute with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",12)
 testRunner.When("execute with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",14)
 testRunner.And("execute with parameter 131", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",15)
 testRunner.Then("executed Given step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",16)
 testRunner.And("executed Given step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",17)
 testRunner.And("executed When step with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",18)
 testRunner.And("executed Given step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",19)
 testRunner.And("executed When step with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("TestLine12ExecuteWithParameter130")>  _
        Public Overridable Sub TestLine12ExecuteWithParameter130()
            Me.Test(AddressOf Me.TestLine12ExecuteWithParameter130Steps, 12)
        End Sub
        
        Private Sub TestLine12ExecuteWithParameter130Steps()
#ExternalSource("SpecFlowIgnoreStep.feature",5)
 testRunner.Given("step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",7)
 testRunner.And("step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",8)
 testRunner.When("execute with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",11)
 testRunner.Given("step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",14)
 testRunner.When("execute with parameter 131", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",15)
 testRunner.Then("executed Given step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Then ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",16)
 testRunner.And("executed Given step with parameter 11", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",17)
 testRunner.And("executed When step with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",18)
 testRunner.And("executed Given step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreStep.feature",19)
 testRunner.And("executed When step with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "And ")
#End ExternalSource
        End Sub
    End Class
End Namespace
'#pragma warning restore
#End Region
