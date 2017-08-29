Imports System
Imports System.Diagnostics

Namespace GarageQuoteSheetDLL
	Public Class Driver
		Implements IEntity
		Private intId As Integer

		Private strGarageQuoteId As String

		Private strName As String

		Private dtDOB As DateTime

		Private intYrsExp As Integer

		Private dtHireDate As DateTime

		Private objAccidentTicketColl As GenericCollection(Of DriverTicket)

		Public Property DOB As DateTime
			Get
				Return Me.dtDOB
			End Get
			Set(ByVal value As DateTime)
				Me.dtDOB = value
			End Set
		End Property

		Public Property DrverTickets As GenericCollection(Of DriverTicket)
			Get
				Return Me.objAccidentTicketColl
			End Get
			Set(ByVal value As GenericCollection(Of DriverTicket))
				Me.objAccidentTicketColl = value
			End Set
		End Property

		Public Property GarageQuoteId As String
			Get
				Return Me.strGarageQuoteId
			End Get
			Set(ByVal value As String)
				Me.strGarageQuoteId = value
			End Set
		End Property

		Public Property HireDate As DateTime
			Get
				Return Me.dtHireDate
			End Get
			Set(ByVal value As DateTime)
				Me.dtHireDate = value
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

		Public Property Name As String
			Get
				Return Me.strName
			End Get
			Set(ByVal value As String)
				Me.strName = value
			End Set
		End Property

		Public Property YearsExperience As Integer
			Get
				Return Me.intYrsExp
			End Get
			Set(ByVal value As Integer)
				Me.intYrsExp = value
			End Set
		End Property

		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace