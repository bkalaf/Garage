Imports GarageQuoteSheetDLL
Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL.H03
	Public Class H03Quote
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intID As Integer

		Private intH03QuoteID As Integer

		Private decTotalBase As Decimal

		Private decSumAddPre As Decimal

		Private decTotPre As Decimal

		Private decTotCredit As Decimal

		Private decUnderWriterDis As Decimal

		Private decTotPremium As Decimal

		Private decPolicy As Decimal

		Private decSalesTax As Decimal

		Private decFslso As Decimal

		Private decFhcf As Decimal

		Private decCpica As Decimal

		Private decEmg As Decimal

		Private decGrandTotal As Decimal

		Public Property Cpica As Decimal
			Get
				Return Me.decCpica
			End Get
			Set(ByVal value As Decimal)
				Me.decCpica = value
			End Set
		End Property

		Public Property Emg As Decimal
			Get
				Return Me.decEmg
			End Get
			Set(ByVal value As Decimal)
				Me.decEmg = value
			End Set
		End Property

		Public Property Fhcf As Decimal
			Get
				Return Me.decFhcf
			End Get
			Set(ByVal value As Decimal)
				Me.decFhcf = value
			End Set
		End Property

		Public Property Fslso As Decimal
			Get
				Return Me.decFslso
			End Get
			Set(ByVal value As Decimal)
				Me.decFslso = value
			End Set
		End Property

		Public Property GrandTotal As Decimal
			Get
				Return Me.decGrandTotal
			End Get
			Set(ByVal value As Decimal)
				Me.decGrandTotal = value
			End Set
		End Property

		Public Property H03QuoteID As Integer
			Get
				Return Me.intH03QuoteID
			End Get
			Set(ByVal value As Integer)
				Me.intH03QuoteID = value
			End Set
		End Property

		Public Property Policy As Decimal
			Get
				Return Me.decPolicy
			End Get
			Set(ByVal value As Decimal)
				Me.decPolicy = value
			End Set
		End Property

		Public Property quotequoteId As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property SalesTax As Decimal
			Get
				Return Me.decSalesTax
			End Get
			Set(ByVal value As Decimal)
				Me.decSalesTax = value
			End Set
		End Property

		Public Property SumAddPre As Decimal
			Get
				Return Me.decSumAddPre
			End Get
			Set(ByVal value As Decimal)
				Me.decSumAddPre = value
			End Set
		End Property

		Public Property TotalBase As Decimal
			Get
				Return Me.decTotalBase
			End Get
			Set(ByVal value As Decimal)
				Me.decTotalBase = value
			End Set
		End Property

		Public Property TotCredit As Decimal
			Get
				Return Me.decTotCredit
			End Get
			Set(ByVal value As Decimal)
				Me.decTotCredit = value
			End Set
		End Property

		Public Property TotPre As Decimal
			Get
				Return Me.decTotPre
			End Get
			Set(ByVal value As Decimal)
				Me.decTotPre = value
			End Set
		End Property

		Public Property TotPremium As Decimal
			Get
				Return Me.decTotPremium
			End Get
			Set(ByVal value As Decimal)
				Me.decTotPremium = value
			End Set
		End Property

		Public Property UnderWriterDis As Decimal
			Get
				Return Me.decUnderWriterDis
			End Get
			Set(ByVal value As Decimal)
				Me.decUnderWriterDis = value
			End Set
		End Property

		Shared Sub New()
			H03Quote.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace