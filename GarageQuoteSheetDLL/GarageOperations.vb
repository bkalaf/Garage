Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageOperations
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intId As Integer

		Private strbusinessType As String

		Private intYrsInBusiness As Integer

		Private strYrExperience_NewVenture As String

		Private intnSellAutoParts As Integer

		Private intSellPercentage As Integer

		Private intnOperateSalvageYard As Integer

		Private intn_OperateOtherLocation As Integer

		Private intnOtherBusinessOperation As Integer

		Private intnHasWrecker As Integer

		Private intnHasRollback As Integer

		Private intnHasDollieOrTrailer As Integer

		Private strFurnishedAutoDetails As String

		Private intGarageQuoteID As Integer

		Private strDollieOrTrailerDetails As String

		Private objInsuredOperationColl As GenericCollection(Of InsuredOperation)

		Private objOtherBusinessColl As GenericCollection(Of OtherBusiness)

		Private objOtherLocationColl As GenericCollection(Of OtherLocation)

		Private objGaragePersonColl As GenericCollection(Of GaragePerson)

		Private strApplicantName As String

		Private strBusinessName As String

		Private strGarageAddress As String

		Private strCity As String

		Private strZip As String

		Private strCounty As String

		Private strState As String

		Private intYearsInsured As Integer

		Private strYearsSameTypeVehicles As String

		Private intIsFilling As Integer

		Private intAreVehiclesListed As Integer

		Private strListedVehiclesDetails As String

		Private strFillingDetails As String

		Private strCommoditiesHauled As String

		Private strOperationRadius As String

		Private strOperationCities As String

		Private strOperationInsured As String

		Public Property ApplicantName As String
			Get
				Return Me.strApplicantName
			End Get
			Set(ByVal value As String)
				Me.strApplicantName = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property AreAllVehiclesListed As Integer
			Get
				Return Me.intAreVehiclesListed
			End Get
			Set(ByVal value As Integer)
				Me.intAreVehiclesListed = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property BusinessName As String
			Get
				Return Me.strBusinessName
			End Get
			Set(ByVal value As String)
				Me.strBusinessName = value
			End Set
		End Property

		Public Property BusinessType As String
			Get
				Return Me.strbusinessType
			End Get
			Set(ByVal value As String)
				Me.strbusinessType = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property City As String
			Get
				Return Me.strCity
			End Get
			Set(ByVal value As String)
				Me.strCity = value
			End Set
		End Property

		Public Property CommoditiesHauled As String
			Get
				Return Me.strCommoditiesHauled
			End Get
			Set(ByVal value As String)
				Me.strCommoditiesHauled = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property County As String
			Get
				Return Me.strCounty
			End Get
			Set(ByVal value As String)
				Me.strCounty = value
			End Set
		End Property

		Public Property DollieOrTrailerDetails As String
			Get
				Return Me.strDollieOrTrailerDetails
			End Get
			Set(ByVal value As String)
				Me.strDollieOrTrailerDetails = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property FillingDetails As String
			Get
				Return Me.strFillingDetails
			End Get
			Set(ByVal value As String)
				Me.strFillingDetails = value
			End Set
		End Property

		Public Property FurnishedAutoDetails As String
			Get
				Return Me.strFurnishedAutoDetails
			End Get
			Set(ByVal value As String)
				Me.strFurnishedAutoDetails = value
			End Set
		End Property

		Public Property GarageAddress As String
			Get
				Return Me.strGarageAddress
			End Get
			Set(ByVal value As String)
				Me.strGarageAddress = value
			End Set
		End Property

		Public Property GarageOperationId As Integer Implements IEntity.Id
			Get
				Return Me.intId
			End Get
			Set(ByVal value As Integer)
				Me.intId = value
			End Set
		End Property

		Public Property GarageQuoteID As Integer
			Get
				Return Me.intGarageQuoteID
			End Get
			Set(ByVal value As Integer)
				Me.intGarageQuoteID = value
			End Set
		End Property

		Public Property HasDollieOrTrailer As Integer
			Get
				Return Me.intnHasDollieOrTrailer
			End Get
			Set(ByVal value As Integer)
				Me.intnHasDollieOrTrailer = value
			End Set
		End Property

		Public Property HasRollback As Integer
			Get
				Return Me.intnHasRollback
			End Get
			Set(ByVal value As Integer)
				Me.intnHasRollback = value
			End Set
		End Property

		Public Property HasWrecker As Integer
			Get
				Return Me.intnHasWrecker
			End Get
			Set(ByVal value As Integer)
				Me.intnHasWrecker = value
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

		Public Property IsFillingRequired As Integer
			Get
				Return Me.intIsFilling
			End Get
			Set(ByVal value As Integer)
				Me.intIsFilling = value
			End Set
		End Property

		Public Property ListedVehicleDetails As String
			Get
				Return Me.strListedVehiclesDetails
			End Get
			Set(ByVal value As String)
				Me.strListedVehiclesDetails = value
			End Set
		End Property

		Public Property OperateOtherLocation As Integer
			Get
				Return Me.intn_OperateOtherLocation
			End Get
			Set(ByVal value As Integer)
				Me.intn_OperateOtherLocation = value
			End Set
		End Property

		Public Property OperateSalvageYard As Integer
			Get
				Return Me.intnOperateSalvageYard
			End Get
			Set(ByVal value As Integer)
				Me.intnOperateSalvageYard = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property OperationCities As String
			Get
				Return Me.strOperationCities
			End Get
			Set(ByVal value As String)
				Me.strOperationCities = value
			End Set
		End Property

		''' <summary>
		''' For Commerical Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property OperationInsured As String
			Get
				Return Me.strOperationInsured
			End Get
			Set(ByVal value As String)
				Me.strOperationInsured = value
			End Set
		End Property

		Public Property OperationRadius As String
			Get
				Return Me.strOperationRadius
			End Get
			Set(ByVal value As String)
				Me.strOperationRadius = value
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

		Public Property otherBusinessOperation As Integer
			Get
				Return Me.intnOtherBusinessOperation
			End Get
			Set(ByVal value As Integer)
				Me.intnOtherBusinessOperation = value
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

		Public Property SellAutoParts As Integer
			Get
				Return Me.intnSellAutoParts
			End Get
			Set(ByVal value As Integer)
				Me.intnSellAutoParts = value
			End Set
		End Property

		Public Property SellPercentage As Integer
			Get
				Return Me.intSellPercentage
			End Get
			Set(ByVal value As Integer)
				Me.intSellPercentage = value
			End Set
		End Property

		Public Property State As String
			Get
				Return Me.strState
			End Get
			Set(ByVal value As String)
				Me.strState = value
			End Set
		End Property

		''' <summary>
		''' For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property YearsInsured As Integer
			Get
				Return Me.intYearsInsured
			End Get
			Set(ByVal value As Integer)
				Me.intYearsInsured = value
			End Set
		End Property

		Public Property YearsSameTypeVehicles As String
			Get
				Return Me.strYearsSameTypeVehicles
			End Get
			Set(ByVal value As String)
				Me.strYearsSameTypeVehicles = value
			End Set
		End Property

		Public Property YrsExperience_NewVenture As String
			Get
				Return Me.strYrExperience_NewVenture
			End Get
			Set(ByVal value As String)
				Me.strYrExperience_NewVenture = value
			End Set
		End Property

		Public Property YrsInBusiness As Integer
			Get
				Return Me.intYrsInBusiness
			End Get
			Set(ByVal value As Integer)
				Me.intYrsInBusiness = value
			End Set
		End Property

		Public Property ZipCode As String
			Get
				Return Me.strZip
			End Get
			Set(ByVal value As String)
				Me.strZip = value
			End Set
		End Property

		Shared Sub New()
			GarageOperations.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace