Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageLookupType
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intID As Integer

		Private strLookupName As String

		Public Property ID As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property LookupName As String
			Get
				Return Me.strLookupName
			End Get
			Set(ByVal value As String)
				Me.strLookupName = value
			End Set
		End Property

		Shared Sub New()
			GarageLookupType.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace