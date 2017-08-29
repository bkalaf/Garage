Imports GarageQuoteSheetDLL
Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL.H03
	Public Class HomeDetails
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intId As Integer

		Private strOccupancy As String

		Private strConstructionType As String

		Private strYearBuilt As String

		Private strProtectiveDevices As String

		Private strProtectiveClass As String

		Private strFamilies As String

		Private strMilestoCoastal As String

		Private strPool As String

		Private intTrampoline As Integer

		Private intPets As Integer

		Private strPetsDetails As String

		Private strRoofAge As String

		Private strSquareFootage As String

		Private strStories As String

		Private strFeetFrmHydrant As String

		Private strMilesToFireStation As String

		Private strFireDistrict As String

		Private strWindProtectiveDevices As String

		Private intH03QuoteID As Integer

		Public Property ConstructionType As String
			Get
				Return Me.strConstructionType
			End Get
			Set(ByVal value As String)
				Me.strConstructionType = value
			End Set
		End Property

		Public Property Families As String
			Get
				Return Me.strFamilies
			End Get
			Set(ByVal value As String)
				Me.strFamilies = value
			End Set
		End Property

		Public Property FeetFrmHydrant As String
			Get
				Return Me.strFeetFrmHydrant
			End Get
			Set(ByVal value As String)
				Me.strFeetFrmHydrant = value
			End Set
		End Property

		Public Property FireDistrict As String
			Get
				Return Me.strFireDistrict
			End Get
			Set(ByVal value As String)
				Me.strFireDistrict = value
			End Set
		End Property

		Public Property H03HomeId As Integer Implements IEntity.Id
			Get
				Return Me.intId
			End Get
			Set(ByVal value As Integer)
				Me.intId = value
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

		Public Property HasPets As Integer
			Get
				Return Me.intPets
			End Get
			Set(ByVal value As Integer)
				Me.intPets = value
			End Set
		End Property

		Public Property MilestoCoastal As String
			Get
				Return Me.strMilestoCoastal
			End Get
			Set(ByVal value As String)
				Me.strMilestoCoastal = value
			End Set
		End Property

		Public Property MilesToFireStation As String
			Get
				Return Me.strMilesToFireStation
			End Get
			Set(ByVal value As String)
				Me.strMilesToFireStation = value
			End Set
		End Property

		Public Property Occupancy As String
			Get
				Return Me.strOccupancy
			End Get
			Set(ByVal value As String)
				Me.strOccupancy = value
			End Set
		End Property

		Public Property Pets As String
			Get
				Return Me.strPetsDetails
			End Get
			Set(ByVal value As String)
				Me.strPetsDetails = value
			End Set
		End Property

		Public Property Pool As String
			Get
				Return Me.strPool
			End Get
			Set(ByVal value As String)
				Me.strPool = value
			End Set
		End Property

		Public Property ProtectiveClass As String
			Get
				Return Me.strProtectiveClass
			End Get
			Set(ByVal value As String)
				Me.strProtectiveClass = value
			End Set
		End Property

		Public Property ProtectiveDevices As String
			Get
				Return Me.strProtectiveDevices
			End Get
			Set(ByVal value As String)
				Me.strProtectiveDevices = value
			End Set
		End Property

		Public Property RoofAge As String
			Get
				Return Me.strRoofAge
			End Get
			Set(ByVal value As String)
				Me.strRoofAge = value
			End Set
		End Property

		Public Property SquareFootage As String
			Get
				Return Me.strSquareFootage
			End Get
			Set(ByVal value As String)
				Me.strSquareFootage = value
			End Set
		End Property

		Public Property Stories As String
			Get
				Return Me.strStories
			End Get
			Set(ByVal value As String)
				Me.strStories = value
			End Set
		End Property

		Public Property Trampoline As Integer
			Get
				Return Me.intTrampoline
			End Get
			Set(ByVal value As Integer)
				Me.intTrampoline = value
			End Set
		End Property

		Public Property WindProtectiveDevices As String
			Get
				Return Me.strWindProtectiveDevices
			End Get
			Set(ByVal value As String)
				Me.strWindProtectiveDevices = value
			End Set
		End Property

		Public Property YearBuilt As String
			Get
				Return Me.strYearBuilt
			End Get
			Set(ByVal value As String)
				Me.strYearBuilt = value
			End Set
		End Property

		Shared Sub New()
			HomeDetails.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace