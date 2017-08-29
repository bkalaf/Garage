Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class H03AdditionalNotes
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intId As Integer

		Private intQuoteID As Integer

		Private strAdditionalNotes As String

		Public Property AdditionalNotes As String
			Get
				Return Me.strAdditionalNotes
			End Get
			Set(ByVal value As String)
				Me.strAdditionalNotes = value
			End Set
		End Property

		Public Property AdditionId As Integer Implements IEntity.Id
			Get
				Return Me.intId
			End Get
			Set(ByVal value As Integer)
				Me.intId = value
			End Set
		End Property

		Public Property QuoteId As Integer
			Get
				Return Me.intQuoteID
			End Get
			Set(ByVal value As Integer)
				Me.intQuoteID = value
			End Set
		End Property

		Shared Sub New()
			H03AdditionalNotes.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace