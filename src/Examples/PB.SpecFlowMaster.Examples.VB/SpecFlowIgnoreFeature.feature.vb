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
     NUnit.Framework.DescriptionAttribute("SpecFlowIgnoreFeature")>  _
    Partial Public Class SpecFlowIgnoreFeatureFeature
        
        Private testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("SpecFlowIgnoreFeature.feature",1)
#End ExternalSource
        
        <NUnit.Framework.OneTimeSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "SpecFlowIgnoreFeature", ""&Global.Microsoft.VisualBasic.ChrW(9)&"Test how feature can be ignored", ProgrammingLanguage.VB, CType(Nothing,String()))
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
#ExternalSource("SpecFlowIgnoreFeature.feature",5)
#End ExternalSource
#ExternalSource("SpecFlowIgnoreFeature.feature",6)
 testRunner.Given("step with parameter 10", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreFeature.feature",7)
 testRunner.When("execute with parameter 20", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Test with unnecessary steps. Will fail if not ignored")>  _
        Public Overridable Sub TestWithUnnecessarySteps_WillFailIfNotIgnored()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Test with unnecessary steps. Will fail if not ignored", Nothing, CType(Nothing,String()))
#ExternalSource("SpecFlowIgnoreFeature.feature",9)
Me.ScenarioInitialize(scenarioInfo)
            Me.ScenarioStart
#End ExternalSource
#ExternalSource("SpecFlowIgnoreFeature.feature",5)
Me.FeatureBackground
#End ExternalSource
#ExternalSource("SpecFlowIgnoreFeature.feature",10)
 testRunner.Given("step with parameter 110", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "Given ")
#End ExternalSource
#ExternalSource("SpecFlowIgnoreFeature.feature",11)
 testRunner.When("execute with parameter 130", CType(Nothing,String), CType(Nothing,TechTalk.SpecFlow.Table), "When ")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
    End Class
End Namespace
'#pragma warning restore
#End Region
