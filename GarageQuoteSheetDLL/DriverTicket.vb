Imports System
Imports System.Diagnostics

Namespace GarageQuoteSheetDLL
	Public Class DriverTicket
		Implements IEntity
		Private intId As Integer

		Private intDriverId As Integer

		Private strTicketDetails As String

		Public Property DriverId As Integer
			Get
				Return Me.intDriverId
			End Get
			Set(ByVal value As Integer)
				Me.intDriverId = value
			End Set
		End Property

		Public Property Id As Integer Implements IEntity.Id
			Get
				Return Me.intId
			End Get
			Set(ByVal value As Integer)
				Me.intId = value
			End Set
		End Property

		Public Property TicketDetails As String
			Get
				Return Me.strTicketDetails
			End Get
			Set(ByVal value As String)
				Me.strTicketDetails = value
			End Set
		End Property

		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace