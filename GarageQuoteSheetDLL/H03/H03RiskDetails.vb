Imports GarageQuoteSheetDLL
Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL.H03
	Public Class H03RiskDetails
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intId As Integer

		Private strApplicantFName As String

		Private strApplicantMName As String

		Private strApplicantLName As String

		Private strLocationAddLineOne As String

		Private strLocationAddLineTwo As String

		Private strLocationCity As String

		Private strLocationState As String

		Private strLocationZipcode As String

		Private strLocationCounty As String

		Private strTerritoryName As String

		Private strTerritoryCode As String

		Private strHomePhone As String

		Private strWorkPhone As String

		Private strMailingAddLineOne As String

		Private strMailingAddLineTwo As String

		Private strMailingCity As String

		Private strMailingState As String

		Private strMailingZipcode As String

		Private strMailingCounty As String

		Private strLienHolder As String

		Private strComments As String

		Private byteHomeDesc As Byte()

		Private intSameMailingAddress As Integer

		Private intH03QuoteID As Integer

		Private objInsuredOperationColl As GenericCollection(Of InsuredOperation)

		Private objOtherBusinessColl As GenericCollection(Of OtherBusiness)

		Private objOtherLocationColl As GenericCollection(Of OtherLocation)

		Private objGaragePersonColl As GenericCollection(Of GaragePerson)

		Public Property ApplicantFName As String
			Get
				Return Me.strApplicantFName
			End Get
			Set(ByVal value As String)
				Me.strApplicantFName = value
			End Set
		End Property

		Public Property ApplicantLName As String
			Get
				Return Me.strApplicantLName
			End Get
			Set(ByVal value As String)
				Me.strApplicantLName = value
			End Set
		End Property

		Public Property ApplicantMName As String
			Get
				Return Me.strApplicantMName
			End Get
			Set(ByVal value As String)
				Me.strApplicantMName = value
			End Set
		End Property

		Public Property Commnets As String
			Get
				Return Me.strComments
			End Get
			Set(ByVal value As String)
				Me.strComments = value
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

		Public Property H03RiskId As Integer Implements IEntity.Id
			Get
				Return Me.intId
			End Get
			Set(ByVal value As Integer)
				Me.intId = value
			End Set
		End Property

		Public Property HomeDescription As Byte()
			Get
				Return Me.byteHomeDesc
			End Get
			Set(ByVal value As Byte())
				Me.byteHomeDesc = value
			End Set
		End Property

		Public Property HomePhone As String
			Get
				Return Me.strHomePhone
			End Get
			Set(ByVal value As String)
				Me.strHomePhone = value
			End Set
		End Property

		Public Property InsuredOperations As GenericCollection(Of InsuredOperation)
			Get
				Return Me.objInsuredOperationColl
			End Get
			Set(ByVal value As GenericCollection(Of InsuredOperation))
				Me.objInsuredOperationColl = value
			End Set
		End Property

		Public Property LienHolder As String
			Get
				Return Me.strLienHolder
			End Get
			Set(ByVal value As String)
				Me.strLienHolder = value
			End Set
		End Property

		Public Property LocationAddLineOne As String
			Get
				Return Me.strLocationAddLineOne
			End Get
			Set(ByVal value As String)
				Me.strLocationAddLineOne = value
			End Set
		End Property

		Public Property LocationAddLineTwo As String
			Get
				Return Me.strLocationAddLineTwo
			End Get
			Set(ByVal value As String)
				Me.strLocationAddLineTwo = value
			End Set
		End Property

		Public Property LocationCity As String
			Get
				Return Me.strLocationCity
			End Get
			Set(ByVal value As String)
				Me.strLocationCity = value
			End Set
		End Property

		Public Property LocationCounty As String
			Get
				Return Me.strLocationCounty
			End Get
			Set(ByVal value As String)
				Me.strLocationCounty = value
			End Set
		End Property

		Public Property LocationState As String
			Get
				Return Me.strLocationState
			End Get
			Set(ByVal value As String)
				Me.strLocationState = value
			End Set
		End Property

		Public Property LocationZipcode As String
			Get
				Return Me.strLocationZipcode
			End Get
			Set(ByVal value As String)
				Me.strLocationZipcode = value
			End Set
		End Property

		Public Property MailingAddLineOne As String
			Get
				Return Me.strMailingAddLineOne
			End Get
			Set(ByVal value As String)
				Me.strMailingAddLineOne = value
			End Set
		End Property

		Public Property MailingAddLineTwo As String
			Get
				Return Me.strMailingAddLineTwo
			End Get
			Set(ByVal value As String)
				Me.strMailingAddLineTwo = value
			End Set
		End Property

		Public Property MailingCity As String
			Get
				Return Me.strMailingCity
			End Get
			Set(ByVal value As String)
				Me.strMailingCity = value
			End Set
		End Property

		Public Property MailingCounty As String
			Get
				Return Me.strMailingCounty
			End Get
			Set(ByVal value As String)
				Me.strMailingCounty = value
			End Set
		End Property

		Public Property MailingState As String
			Get
				Return Me.strMailingState
			End Get
			Set(ByVal value As String)
				Me.strMailingState = value
			End Set
		End Property

		Public Property MailingZipcode As String
			Get
				Return Me.strMailingZipcode
			End Get
			Set(ByVal value As String)
				Me.strMailingZipcode = value
			End Set
		End Property

		Public Property OtherBusinesses As GenericCollection(Of OtherBusiness)
			Get
				Return Me.objOtherBusinessColl
			End Get
			Set(ByVal value As GenericCollection(Of OtherBusiness))
				Me.objOtherBusinessColl = value
			End Set
		End Property

		Public Property OtherLocations As GenericCollection(Of OtherLocation)
			Get
				Return Me.objOtherLocationColl
			End Get
			Set(ByVal value As GenericCollection(Of OtherLocation))
				Me.objOtherLocationColl = value
			End Set
		End Property

		Public Property PersonDetails As GenericCollection(Of GaragePerson)
			Get
				Return Me.objGaragePersonColl
			End Get
			Set(ByVal value As GenericCollection(Of GaragePerson))
				Me.objGaragePersonColl = value
			End Set
		End Property

		Public Property SameMailingAddress As Integer
			Get
				Return Me.intSameMailingAddress
			End Get
			Set(ByVal value As Integer)
				Me.intSameMailingAddress = value
			End Set
		End Property

		Public Property TerritoryCode As String
			Get
				Return Me.strTerritoryCode
			End Get
			Set(ByVal value As String)
				Me.strTerritoryCode = value
			End Set
		End Property

		Public Property TerritoryName As String
			Get
				Return Me.strTerritoryName
			End Get
			Set(ByVal value As String)
				Me.strTerritoryName = value
			End Set
		End Property

		Public Property WorkPhone As String
			Get
				Return Me.strWorkPhone
			End Get
			Set(ByVal value As String)
				Me.strWorkPhone = value
			End Set
		End Property

		Shared Sub New()
			H03RiskDetails.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace