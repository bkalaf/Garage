Imports System
Imports System.Diagnostics

Namespace GarageQuoteSheetDLL
	Public Class ControllerBase
		Implements IController
		Private iobjDataModel As IDataModel

		Private iobjView As IView

		Public Property DataModel As IDataModel Implements IController.DataModel
			Get
				Return Me.iobjDataModel
			End Get
			Set(ByVal value As IDataModel)
				Me.iobjDataModel = value
			End Set
		End Property

		Public Property View As IView Implements IController.View
			Get
				Return Me.iobjView
			End Get
			Set(ByVal value As IView)
				Me.iobjView = value
			End Set
		End Property

		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace