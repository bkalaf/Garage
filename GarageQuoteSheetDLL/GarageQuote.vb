Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageQuote
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private _intGarageQuoteID As Integer

		Private _strGarageQuoteNo As String

		Private _strAgentID As String

		Private _strApplicantName As String

		Private _strTradeName As String

		Private _strContact As String

		Private _decPhone As String

		Private _strCounty As String

		Private _strState As String

		Private strZIP As String

		Private strFax As String

		Private strEmail As String

		Private strAdditionalNotes As String

		Private objGarageOperation As GarageOperations

		Private objGarageInsuranceHistory As InsuranceHistory

		Private objGarageCoverageDetail As GarageQuoteSheetDLL.CoverageDetail

		Private strCreated_Modified_By As String

		Private dtCreated_Modified_Date As DateTime

		Private _intParentQuoteID As Integer

		Private _strParentQuoteNo As String

		Private _strUnderwriterName As String

		Private _strAgentFName As String

		Private _strAgentLName As String

		Private _strAgentSSN As String

		Private _strUnderwriterEmail As String

		Public Property AdditionalNotes As String
			Get
				Return Me.strAdditionalNotes
			End Get
			Set(ByVal value As String)
				Me.strAdditionalNotes = value
			End Set
		End Property

		Public Property AgentFname As String
			Get
				Return Me._strAgentFName
			End Get
			Set(ByVal value As String)
				Me._strAgentFName = value
			End Set
		End Property

		Public Property AgentID As String
			Get
				Return Me._strAgentID
			End Get
			Set(ByVal value As String)
				Me._strAgentID = value
			End Set
		End Property

		Public Property AgentLName As String
			Get
				Return Me._strAgentLName
			End Get
			Set(ByVal value As String)
				Me._strAgentLName = value
			End Set
		End Property

		Public Property AgentSSN As String
			Get
				Return Me._strAgentSSN
			End Get
			Set(ByVal value As String)
				Me._strAgentSSN = value
			End Set
		End Property

		Public Property ApplicantName As String
			Get
				Return Me._strApplicantName
			End Get
			Set(ByVal value As String)
				Me._strApplicantName = value
			End Set
		End Property

		Public Property Contact As String
			Get
				Return Me._strContact
			End Get
			Set(ByVal value As String)
				Me._strContact = value
			End Set
		End Property

		Public Property County As String
			Get
				Return Me._strCounty
			End Get
			Set(ByVal value As String)
				Me._strCounty = value
			End Set
		End Property

		Public Property CoverageDetail As GarageQuoteSheetDLL.CoverageDetail
			Get
				Return Me.objGarageCoverageDetail
			End Get
			Set(ByVal value As GarageQuoteSheetDLL.CoverageDetail)
				Me.objGarageCoverageDetail = value
			End Set
		End Property

		Public Property CreatedORModifiedBY As String
			Get
				Return Me.strCreated_Modified_By
			End Get
			Set(ByVal value As String)
				Me.strCreated_Modified_By = value
			End Set
		End Property

		Public Property CreatedORModifiedDate As DateTime
			Get
				Return Me.dtCreated_Modified_Date
			End Get
			Set(ByVal value As DateTime)
				Me.dtCreated_Modified_Date = value
			End Set
		End Property

		Public Property Email As String
			Get
				Return Me.strEmail
			End Get
			Set(ByVal value As String)
				Me.strEmail = value
			End Set
		End Property

		Public Property Fax As String
			Get
				Return Me.strFax
			End Get
			Set(ByVal value As String)
				Me.strFax = value
			End Set
		End Property

		Public Property Garageoperation As GarageOperations
			Get
				Return Me.objGarageOperation
			End Get
			Set(ByVal value As GarageOperations)
				Me.objGarageOperation = value
			End Set
		End Property

		Public Property GarageQuoteID As Integer Implements IEntity.Id
			Get
				Return Me._intGarageQuoteID
			End Get
			Set(ByVal value As Integer)
				Me._intGarageQuoteID = value
			End Set
		End Property

		Public Property GarageQuoteNumber As String
			Get
				Return Me._strGarageQuoteNo
			End Get
			Set(ByVal value As String)
				Me._strGarageQuoteNo = value
			End Set
		End Property

		Public Property InsuranceHistroy As InsuranceHistory
			Get
				Return Me.objGarageInsuranceHistory
			End Get
			Set(ByVal value As InsuranceHistory)
				Me.objGarageInsuranceHistory = value
			End Set
		End Property

		Public Property ParentQuoteID As Integer
			Get
				Return Me._intParentQuoteID
			End Get
			Set(ByVal value As Integer)
				Me._intParentQuoteID = value
			End Set
		End Property

		Public Property ParentQuoteNumber As String
			Get
				Return Me._strParentQuoteNo
			End Get
			Set(ByVal value As String)
				Me._strParentQuoteNo = value
			End Set
		End Property

		Public Property Phone As String
			Get
				Return Me._decPhone
			End Get
			Set(ByVal value As String)
				Me._decPhone = value
			End Set
		End Property

		Public Property State As String
			Get
				Return Me._strState
			End Get
			Set(ByVal value As String)
				Me._strState = value
			End Set
		End Property

		Public Property TradeName As String
			Get
				Return Me._strTradeName
			End Get
			Set(ByVal value As String)
				Me._strTradeName = value
			End Set
		End Property

		Public Property UnderwriterEmail As String
			Get
				Return Me._strUnderwriterEmail
			End Get
			Set(ByVal value As String)
				Me._strUnderwriterEmail = value
			End Set
		End Property

		Public Property UnderwriterName As String
			Get
				Return Me._strUnderwriterName
			End Get
			Set(ByVal value As String)
				Me._strUnderwriterName = value
			End Set
		End Property

		Public Property ZIP As String
			Get
				Return Me.strZIP
			End Get
			Set(ByVal value As String)
				Me.strZIP = value
			End Set
		End Property

		Shared Sub New()
			GarageQuote.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace