Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class H03InsuranceHistory
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

		Private strWindHailLosses As String

		Private strWindNonHailLosses As Integer

		Private objWindHailLosshistoryColl As GenericCollection(Of GarageQuoteSheetDLL.H03.WindHailLossHistory)

		Public Property H03QuoteID As Integer
			Get
				Return Me.intH03QuoteID
			End Get
			Set(ByVal value As Integer)
				Me.intH03QuoteID = value
			End Set
		End Property

		Public Property InsuranceHistoryId As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property WindHailLosses As String
			Get
				Return Me.strWindHailLosses
			End Get
			Set(ByVal value As String)
				Me.strWindHailLosses = value
			End Set
		End Property

		Public Property WindHailLosshistory As GenericCollection(Of GarageQuoteSheetDLL.H03.WindHailLossHistory)
			Get
				Return Me.objWindHailLosshistoryColl
			End Get
			Set(ByVal value As GenericCollection(Of GarageQuoteSheetDLL.H03.WindHailLossHistory))
				Me.objWindHailLosshistoryColl = value
			End Set
		End Property

		Public Property WindNonHailLosses As String
			Get
				Return Conversions.ToString(Me.strWindNonHailLosses)
			End Get
			Set(ByVal value As String)
				Me.strWindNonHailLosses = Conversions.ToInteger(value)
			End Set
		End Property

		Shared Sub New()
			H03InsuranceHistory.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace