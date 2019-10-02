Imports NUnit.Framework

' ReSharper disable once CheckNamespace
Namespace PB.SpecFlowMaster.Examples
    Public Class Steps
        Protected Sub AreEqual(ByVal expected As Object, ByVal actual As Object)
            Assert.AreEqual(expected, actual)
        End Sub
    End Class
End Namespace
