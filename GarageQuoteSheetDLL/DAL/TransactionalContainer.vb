Imports System
Imports System.Data.SqlClient

Namespace GarageQuoteSheetDLL.DAL
	Public Class TransactionalContainer
		Private xSPName As String

		Private parameters As SqlParameter()

		Private xisSP As Boolean

		Public Property isSP As Boolean
			Get
				Return Me.xisSP
			End Get
			Set(ByVal value As Boolean)
				Me.xisSP = value
			End Set
		End Property

		Public Property Params As SqlParameter()
			Get
				Return Me.parameters
			End Get
			Set(ByVal value As SqlParameter())
				Me.parameters = value
			End Set
		End Property

		Public Property sql_OR_spName As String
			Get
				Return Me.xSPName
			End Get
			Set(ByVal value As String)
				Me.xSPName = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.xSPName = String.Empty
			Me.xisSP = True
		End Sub
	End Class
End Namespace