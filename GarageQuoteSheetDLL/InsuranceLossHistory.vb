Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class InsuranceLossHistory
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private _intID As Integer

		Private _intGarageQuoteID As Integer

		Private _dtTermFrom As DateTime

		Private _dtTermTo As DateTime

		Private _strCarrier As String

		Private _decCover As Decimal

		Private _decAmount As Decimal

		Private _strDetails As String

		Public Property Amount As Decimal
			Get
				Return Me._decAmount
			End Get
			Set(ByVal value As Decimal)
				Me._decAmount = value
			End Set
		End Property

		Public Property Carrier As String
			Get
				Return Me._strCarrier
			End Get
			Set(ByVal value As String)
				Me._strCarrier = value
			End Set
		End Property

		Public Property Cover As Decimal
			Get
				Return Me._decCover
			End Get
			Set(ByVal value As Decimal)
				Me._decCover = value
			End Set
		End Property

		Public Property Details As String
			Get
				Return Me._strDetails
			End Get
			Set(ByVal value As String)
				Me._strDetails = value
			End Set
		End Property

		Public Property GarageQuoteID As Integer
			Get
				Return Me._intGarageQuoteID
			End Get
			Set(ByVal value As Integer)
				Me._intGarageQuoteID = value
			End Set
		End Property

		Public Property LossHistoryId As Integer Implements IEntity.Id
			Get
				Return Me._intID
			End Get
			Set(ByVal value As Integer)
				Me._intID = value
			End Set
		End Property

		Public Property TermFrom As DateTime
			Get
				Return Me._dtTermFrom
			End Get
			Set(ByVal value As DateTime)
				Me._dtTermFrom = value
			End Set
		End Property

		Public Property TermTo As DateTime
			Get
				Return Me._dtTermTo
			End Get
			Set(ByVal value As DateTime)
				Me._dtTermTo = value
			End Set
		End Property

		Shared Sub New()
			InsuranceLossHistory.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace