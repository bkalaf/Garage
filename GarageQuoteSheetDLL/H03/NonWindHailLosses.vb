Imports GarageQuoteSheetDLL
Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL.H03
	Public Class NonWindHailLosses
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

		Private strDescription As String

		Private strOutComeLosses As String

		Private decAmount As Decimal

		Public Property Amount As Decimal
			Get
				Return Me.decAmount
			End Get
			Set(ByVal value As Decimal)
				Me.decAmount = value
			End Set
		End Property

		Public Property Description As String
			Get
				Return Me.strDescription
			End Get
			Set(ByVal value As String)
				Me.strDescription = value
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

		Public Property NonWindHailLossHistoryId As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property OutComeLosses As String
			Get
				Return Me.strOutComeLosses
			End Get
			Set(ByVal value As String)
				Me.strOutComeLosses = value
			End Set
		End Property

		Shared Sub New()
			NonWindHailLosses.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace