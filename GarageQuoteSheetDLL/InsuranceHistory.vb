Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class InsuranceHistory
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

		Private _intIsPrevPolicyCncl As Integer

		Private _intIsPrevPolicyNotRenewed As Integer

		Private _strCnclDetails As String

		Private _strNotRenewelDetails As String

		Private objLosshistoryColl As GenericCollection(Of GarageQuoteSheetDLL.InsuranceLossHistory)

		Public Property CancellationDetails As String
			Get
				Return Me._strCnclDetails
			End Get
			Set(ByVal value As String)
				Me._strCnclDetails = value
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

		Public Property InsuranceHistoryId As Integer Implements IEntity.Id
			Get
				Return Me._intID
			End Get
			Set(ByVal value As Integer)
				Me._intID = value
			End Set
		End Property

		Public Property InsuranceLossHIstory As GenericCollection(Of GarageQuoteSheetDLL.InsuranceLossHistory)
			Get
				Return Me.objLosshistoryColl
			End Get
			Set(ByVal value As GenericCollection(Of GarageQuoteSheetDLL.InsuranceLossHistory))
				Me.objLosshistoryColl = value
			End Set
		End Property

		Public Property IsPreviousPolicyCancelled As Integer
			Get
				Return Me._intIsPrevPolicyCncl
			End Get
			Set(ByVal value As Integer)
				Me._intIsPrevPolicyCncl = value
			End Set
		End Property

		Public Property IsPreviousPolicyNotRenewed As Integer
			Get
				Return Me._intIsPrevPolicyNotRenewed
			End Get
			Set(ByVal value As Integer)
				Me._intIsPrevPolicyNotRenewed = value
			End Set
		End Property

		Public Property NotRenewalDetails As String
			Get
				Return Me._strNotRenewelDetails
			End Get
			Set(ByVal value As String)
				Me._strNotRenewelDetails = value
			End Set
		End Property

		Shared Sub New()
			InsuranceHistory.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace