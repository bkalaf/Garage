Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class CoverageDetail
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

		Private _strLiabilityLimit As String

		Private _intIsUnInsuredMotorist As Integer

		Private _strReject As String

		Private _strMedPayLimit As String

		Private _strOperationRadius As String

		Private _intNoOfDealerPlates As Integer

		Private _intIsLegalLiability As Integer

		Private _intIsDirectPrimary As Integer

		Private _decValuePerLot As Decimal

		Private _strDeductible As String

		Private _decMaxLimitPerUnit As Decimal

		Private _intIsPerils As Integer

		Private _intIsCollision As Integer

		Private _intIsComprehensive As Integer

		Private _decPhysical_ValuePerLot As Decimal

		Private _strPhysical_Deductible As String

		Private _decPhysical_MaxLimitPerUnit As Decimal

		Private _intPhysical_IsPerils As Integer

		Private _intPhysical_IsCollision As Integer

		Private _intPhysical_IsComprehensive As Integer

		Private _intIsLotLightedNight As Integer

		Private _intIsLotChained As Integer

		Private _intIsLotFenced As Integer

		Private _intIsLotOpen As Integer

		Private _blnKeepersCoverage As Boolean

		Private _blnPhysicalCoverage As Boolean

		Private _strNoOfDealerTags As String

		Private _strPIP As String

		Private _strLiabilityLimit_Csl As String

		Private _strliabilityLimit_Split As String

		Private _strUnInsuredMotorist_Csl As String

		Private _strUninsuredMotorist_Split As String

		Private _intIsHired As Integer

		Private _intIsNonOwned As Integer

		Private _strHiredDetails As String

		Private _strNonOwnedDetails As String

		Private _strTruckCargoDetail As String

		Private _intIsreeferBreaking As Integer

		Private _strReeferBreakingDetail As String

		Private _intIsAddtnlInsured As Integer

		Private _strIsAddtnlInsuredDetail As String

		Private _strAdditionalInfo As String

		Private _strdeductiblecargo As String

		Private _blnIsCargo As Boolean

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property AdditionalInfo As String
			Get
				Return Me._strAdditionalInfo
			End Get
			Set(ByVal value As String)
				Me._strAdditionalInfo = value
			End Set
		End Property

		Public Property AddtnlInsuerdDetails As String
			Get
				Return Me._strIsAddtnlInsuredDetail
			End Get
			Set(ByVal value As String)
				Me._strIsAddtnlInsuredDetail = value
			End Set
		End Property

		Public Property CoverageId As Integer Implements IEntity.Id
			Get
				Return Me._intID
			End Get
			Set(ByVal value As Integer)
				Me._intID = value
			End Set
		End Property

		Public Property Deductible As String
			Get
				Return Me._strDeductible
			End Get
			Set(ByVal value As String)
				Me._strDeductible = value
			End Set
		End Property

		Public Property DeductibleCargo As String
			Get
				Return Me._strdeductiblecargo
			End Get
			Set(ByVal value As String)
				Me._strdeductiblecargo = value
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

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property HiredDetails As String
			Get
				Return Me._strHiredDetails
			End Get
			Set(ByVal value As String)
				Me._strHiredDetails = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property ISAddtnlInsured As Integer
			Get
				Return Me._intIsAddtnlInsured
			End Get
			Set(ByVal value As Integer)
				Me._intIsAddtnlInsured = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property IsCargo As Boolean
			Get
				Return Me._blnIsCargo
			End Get
			Set(ByVal value As Boolean)
				Me._blnIsCargo = value
			End Set
		End Property

		Public Property IsCollision As Integer
			Get
				Return Me._intIsCollision
			End Get
			Set(ByVal value As Integer)
				Me._intIsCollision = value
			End Set
		End Property

		Public Property IsComprehensive As Object
			Get
				Return Me._intIsComprehensive
			End Get
			Set(ByVal value As Object)
				Me._intIsComprehensive = Conversions.ToInteger(value)
			End Set
		End Property

		Public Property IsDirectPrimary As Integer
			Get
				Return Me._intIsDirectPrimary
			End Get
			Set(ByVal value As Integer)
				Me._intIsDirectPrimary = value
			End Set
		End Property

		Public Property IsHired As Integer
			Get
				Return Me._intIsHired
			End Get
			Set(ByVal value As Integer)
				Me._intIsHired = value
			End Set
		End Property

		Public Property IsKeeperCoverage As Boolean
			Get
				Return Me._blnKeepersCoverage
			End Get
			Set(ByVal value As Boolean)
				Me._blnKeepersCoverage = value
			End Set
		End Property

		Public Property IsLegalLiability As Integer
			Get
				Return Me._intIsLegalLiability
			End Get
			Set(ByVal value As Integer)
				Me._intIsLegalLiability = value
			End Set
		End Property

		Public Property IsLotChained As Integer
			Get
				Return Me._intIsLotChained
			End Get
			Set(ByVal value As Integer)
				Me._intIsLotChained = value
			End Set
		End Property

		Public Property IsLotFenced As Integer
			Get
				Return Me._intIsLotFenced
			End Get
			Set(ByVal value As Integer)
				Me._intIsLotFenced = value
			End Set
		End Property

		Public Property IsLotLightedNight As Integer
			Get
				Return Me._intIsLotLightedNight
			End Get
			Set(ByVal value As Integer)
				Me._intIsLotLightedNight = value
			End Set
		End Property

		Public Property IsLotOpen As Integer
			Get
				Return Me._intIsLotOpen
			End Get
			Set(ByVal value As Integer)
				Me._intIsLotOpen = value
			End Set
		End Property

		Public Property IsNonOwned As Integer
			Get
				Return Me._intIsNonOwned
			End Get
			Set(ByVal value As Integer)
				Me._intIsNonOwned = value
			End Set
		End Property

		Public Property IsPerils As Integer
			Get
				Return Me._intIsPerils
			End Get
			Set(ByVal value As Integer)
				Me._intIsPerils = value
			End Set
		End Property

		Public Property IsPhysicalCoverage As Boolean
			Get
				Return Me._blnPhysicalCoverage
			End Get
			Set(ByVal value As Boolean)
				Me._blnPhysicalCoverage = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property IsReeferBreaking As Integer
			Get
				Return Me._intIsreeferBreaking
			End Get
			Set(ByVal value As Integer)
				Me._intIsreeferBreaking = value
			End Set
		End Property

		Public Property IsUninsuredMotorist As Integer
			Get
				Return Me._intIsUnInsuredMotorist
			End Get
			Set(ByVal value As Integer)
				Me._intIsUnInsuredMotorist = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property LiabilityLimit_Split As String
			Get
				Return Me._strliabilityLimit_Split
			End Get
			Set(ByVal value As String)
				Me._strliabilityLimit_Split = value
			End Set
		End Property

		Public Property LiabiltyLimit As String
			Get
				Return Me._strLiabilityLimit
			End Get
			Set(ByVal value As String)
				Me._strLiabilityLimit = value
			End Set
		End Property

		Public Property LibilityLimit_Csl As String
			Get
				Return Me._strLiabilityLimit_Csl
			End Get
			Set(ByVal value As String)
				Me._strLiabilityLimit_Csl = value
			End Set
		End Property

		Public Property MaxLimitPerUnit As Decimal
			Get
				Return Me._decMaxLimitPerUnit
			End Get
			Set(ByVal value As Decimal)
				Me._decMaxLimitPerUnit = value
			End Set
		End Property

		Public Property MedPayLimit As String
			Get
				Return Me._strMedPayLimit
			End Get
			Set(ByVal value As String)
				Me._strMedPayLimit = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property NonOwnedDetails As String
			Get
				Return Me._strNonOwnedDetails
			End Get
			Set(ByVal value As String)
				Me._strNonOwnedDetails = value
			End Set
		End Property

		Public Property NoofDealerPlates As Integer
			Get
				Return Me._intNoOfDealerPlates
			End Get
			Set(ByVal value As Integer)
				Me._intNoOfDealerPlates = value
			End Set
		End Property

		Public Property NoOfDealerTags As String
			Get
				Return Me._strNoOfDealerTags
			End Get
			Set(ByVal value As String)
				Me._strNoOfDealerTags = value
			End Set
		End Property

		Public Property OperationRadius As String
			Get
				Return Me._strOperationRadius
			End Get
			Set(ByVal value As String)
				Me._strOperationRadius = value
			End Set
		End Property

		Public Property PhysicalDeductible As String
			Get
				Return Me._strPhysical_Deductible
			End Get
			Set(ByVal value As String)
				Me._strPhysical_Deductible = value
			End Set
		End Property

		Public Property PhysicalIsCollision As Integer
			Get
				Return Me._intPhysical_IsCollision
			End Get
			Set(ByVal value As Integer)
				Me._intPhysical_IsCollision = value
			End Set
		End Property

		Public Property PhysicalIsComprehensive As Integer
			Get
				Return Me._intPhysical_IsComprehensive
			End Get
			Set(ByVal value As Integer)
				Me._intPhysical_IsComprehensive = value
			End Set
		End Property

		Public Property PhysicalIsPerils As Integer
			Get
				Return Me._intPhysical_IsPerils
			End Get
			Set(ByVal value As Integer)
				Me._intPhysical_IsPerils = value
			End Set
		End Property

		Public Property PhysicalMaxUnitPerLimit As Decimal
			Get
				Return Me._decPhysical_MaxLimitPerUnit
			End Get
			Set(ByVal value As Decimal)
				Me._decPhysical_MaxLimitPerUnit = value
			End Set
		End Property

		Public Property PhysicalValuePerLot As Decimal
			Get
				Return Me._decPhysical_ValuePerLot
			End Get
			Set(ByVal value As Decimal)
				Me._decPhysical_ValuePerLot = value
			End Set
		End Property

		Public Property PIP As String
			Get
				Return Me._strPIP
			End Get
			Set(ByVal value As String)
				Me._strPIP = value
			End Set
		End Property

		Public Property ReeferBreaking As String
			Get
				Return Me._strReeferBreakingDetail
			End Get
			Set(ByVal value As String)
				Me._strReeferBreakingDetail = value
			End Set
		End Property

		Public Property Reject As String
			Get
				Return Me._strReject
			End Get
			Set(ByVal value As String)
				Me._strReject = value
			End Set
		End Property

		Public Property TruckCargoDetails As String
			Get
				Return Me._strTruckCargoDetail
			End Get
			Set(ByVal value As String)
				Me._strTruckCargoDetail = value
			End Set
		End Property

		Public Property UnInsuredMotorist_Csl As String
			Get
				Return Me._strUnInsuredMotorist_Csl
			End Get
			Set(ByVal value As String)
				Me._strUnInsuredMotorist_Csl = value
			End Set
		End Property

		''' <summary>
		'''  For Commercial Quote
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property UnInsuredMotorist_Split As String
			Get
				Return Me._strUninsuredMotorist_Split
			End Get
			Set(ByVal value As String)
				Me._strUninsuredMotorist_Split = value
			End Set
		End Property

		Public Property ValuePerLot As Decimal
			Get
				Return Me._decValuePerLot
			End Get
			Set(ByVal value As Decimal)
				Me._decValuePerLot = value
			End Set
		End Property

		Shared Sub New()
			CoverageDetail.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace