Imports GarageQuoteSheetDLL
Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL.H03
	Public Class H03Coverage
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intId As Integer

		Private decCoverageA As Decimal

		Private decCoverageB As Decimal

		Private decCoverageC As Decimal

		Private decCoverageD As Decimal

		Private decCoverageE As Decimal

		Private decCoverageF As Decimal

		Private decDeductible As Decimal

		Private intWindHailEx As Integer

		Private decWindDeductible As Decimal

		Private intSinkHole As Integer

		Private intOrdinance As Integer

		Private intH03QuoteID As Integer

		Public Property CoverageA As Decimal
			Get
				Return Me.decCoverageA
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageA = value
			End Set
		End Property

		Public Property CoverageB As Decimal
			Get
				Return Me.decCoverageB
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageB = value
			End Set
		End Property

		Public Property CoverageC As Decimal
			Get
				Return Me.decCoverageC
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageC = value
			End Set
		End Property

		Public Property CoverageD As Decimal
			Get
				Return Me.decCoverageD
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageD = value
			End Set
		End Property

		Public Property CoverageE As Decimal
			Get
				Return Me.decCoverageE
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageE = value
			End Set
		End Property

		Public Property CoverageF As Decimal
			Get
				Return Me.decCoverageF
			End Get
			Set(ByVal value As Decimal)
				Me.decCoverageF = value
			End Set
		End Property

		Public Property Deductible As Decimal
			Get
				Return Me.decDeductible
			End Get
			Set(ByVal value As Decimal)
				Me.decDeductible = value
			End Set
		End Property

		Public Property H03CoverageId As Integer Implements IEntity.Id
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

		Public Property HasSinkHole As Integer
			Get
				Return Me.intSinkHole
			End Get
			Set(ByVal value As Integer)
				Me.intSinkHole = value
			End Set
		End Property

		Public Property Ordinance As Integer
			Get
				Return Me.intOrdinance
			End Get
			Set(ByVal value As Integer)
				Me.intOrdinance = value
			End Set
		End Property

		Public Property WindDeductible As Decimal
			Get
				Return Me.decWindDeductible
			End Get
			Set(ByVal value As Decimal)
				Me.decWindDeductible = value
			End Set
		End Property

		Public Property WindHailEx As Integer
			Get
				Return Me.intWindHailEx
			End Get
			Set(ByVal value As Integer)
				Me.intWindHailEx = value
			End Set
		End Property

		Shared Sub New()
			H03Coverage.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace