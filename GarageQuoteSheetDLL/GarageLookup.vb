Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageLookup
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intID As Integer

		Private strValue As String

		Private oLookupType As GarageLookupType

		Public Property ID As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property LookupType As GarageLookupType
			Get
				Return Me.oLookupType
			End Get
			Set(ByVal value As GarageLookupType)
				Me.oLookupType = value
			End Set
		End Property

		Public Property Value As String
			Get
				Return Me.strValue
			End Get
			Set(ByVal value As String)
				Me.strValue = value
			End Set
		End Property

		Shared Sub New()
			GarageLookup.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace