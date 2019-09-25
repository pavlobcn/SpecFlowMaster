Imports TechTalk.SpecFlow

' ReSharper disable once CheckNamespace
Namespace PB.SpecFlowMaster.Examples
    <Binding>
    Public Class SpecFlowTargetSteps
        Inherits Steps

        Private ReadOnly _givenExecutionParameters As HashSet(Of Integer)
        Private ReadOnly _whenExecutionParameters As HashSet(Of Integer)

        Public Sub New()
            _givenExecutionParameters = New HashSet(Of Integer)()
            _whenExecutionParameters = New HashSet(Of Integer)()
        End Sub

        <Given("step with parameter (.*)")>
        Public Sub GivenStepWithParameter(ByVal parameter As Integer)
            _givenExecutionParameters.Add(parameter)
        End Sub

        <Given("step with parameters")>
        Public Sub GivenStepWithParameter(ByVal table As Table)
            For Each row As TableRow In table.Rows
                _givenExecutionParameters.Add(Integer.Parse(row("ParamValue")))
            Next
        End Sub

        <[When]("execute with parameter (.*)")>
        Public Sub WhenExecuteWithParameter(ByVal parameter As Integer)
            _whenExecutionParameters.Add(parameter)
        End Sub

        <[Then]("executed Given step with parameter (.*)")>
        Public Sub ThenExecutedGivenStepWithParameter(ByVal parameter As Integer)
            AreEqual(True, _givenExecutionParameters.Contains(parameter))
        End Sub

        <[Then]("executed When step with parameter (.*)")>
        Public Sub ThenExecutedWhenStepWithParameter(ByVal parameter As Integer)
            AreEqual(True, _whenExecutionParameters.Contains(parameter))
        End Sub
    End Class
End Namespace
