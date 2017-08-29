Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace GarageQuoteSheetDLL.SIUService
	''' <remarks />
	<DebuggerStepThrough>
	<DesignerCategory("code")>
	<GeneratedCode("System.Web.Services", "2.0.50727.3053")>
	Public Class GetWindDeductableCreditSurchargeCompletedEventArgs
		Inherits AsyncCompletedEventArgs
		Private results As Object()

		Public ReadOnly Property Result As DataSet
			Get
				Me.RaiseExceptionIfNecessary()
				Return DirectCast(Me.results(0), DataSet)
			End Get
		End Property

		Friend Sub New(ByVal results As Object(), ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
			MyBase.New(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
			Me.results = results
		End Sub
	End Class
End Namespace