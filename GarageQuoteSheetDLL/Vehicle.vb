Imports System
Imports System.Diagnostics

Namespace GarageQuoteSheetDLL
	Public Class Vehicle
		Implements IEntity
		Private intId As Integer

		Private strGarageQuoteId As String

		Private intYear As Integer

		Private strMake As String

		Private strGVW As String

		Private strVehicleType As String

		Private strSTatedvalue As String

		Private strDeductible As String

		Public Property Deductible As String
			Get
				Return Me.strDeductible
			End Get
			Set(ByVal value As String)
				Me.strDeductible = value
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

		Public Property GVW As String
			Get
				Return Me.strGVW
			End Get
			Set(ByVal value As String)
				Me.strGVW = value
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

		Public Property Make As String
			Get
				Return Me.strMake
			End Get
			Set(ByVal value As String)
				Me.strMake = value
			End Set
		End Property

		Public Property StatedValue As String
			Get
				Return Me.strSTatedvalue
			End Get
			Set(ByVal value As String)
				Me.strSTatedvalue = value
			End Set
		End Property

		Public Property VehicleType As String
			Get
				Return Me.strVehicleType
			End Get
			Set(ByVal value As String)
				Me.strVehicleType = value
			End Set
		End Property

		Public Property Year As Integer
			Get
				Return Me.intYear
			End Get
			Set(ByVal value As Integer)
				Me.intYear = value
			End Set
		End Property

		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace