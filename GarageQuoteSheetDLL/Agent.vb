Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	''' <summary>
	''' This class represents entity Agent's contact details.
	''' </summary>
	''' <remarks></remarks>
	Public Class Agent
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private intID As Integer

		Private strCode As String

		Private strLegalName As String

		Private strDBAName As String

		Private strFName As String

		Private strLName As String

		Private strAddress1 As String

		Private strAddress2 As String

		Private strPhone As String

		Private strEmailId As String

		Private strFax As String

		Private strQuoteReplyOption As String

		Private strStatusValue As String

		Private strDept As String

		Public Property AgentAddress1 As String
			Get
				Return Me.strAddress1
			End Get
			Set(ByVal value As String)
				Me.strAddress1 = value
			End Set
		End Property

		Public Property AgentAddress2 As String
			Get
				Return Me.strAddress2
			End Get
			Set(ByVal value As String)
				Me.strAddress2 = value
			End Set
		End Property

		Public Property AgentCode As String
			Get
				Return Me.strCode
			End Get
			Set(ByVal value As String)
				Me.strCode = value
			End Set
		End Property

		''' <summary>
		''' Agent's EmailId
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property AgentEmailId As String
			Get
				Return Me.strEmailId
			End Get
			Set(ByVal value As String)
				Me.strEmailId = value
			End Set
		End Property

		''' <summary>
		''' Agent's Fax Number
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property AgentFax As String
			Get
				Return Me.strFax
			End Get
			Set(ByVal value As String)
				Me.strFax = value
			End Set
		End Property

		''' <summary>
		''' Agent's Name
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property AgentFirstName As String
			Get
				Return Me.strFName
			End Get
			Set(ByVal value As String)
				Me.strFName = value
			End Set
		End Property

		Public Property AgentLastName As String
			Get
				Return Me.strLName
			End Get
			Set(ByVal value As String)
				Me.strLName = value
			End Set
		End Property

		Public Property AgentPhone As String
			Get
				Return Me.strPhone
			End Get
			Set(ByVal value As String)
				Me.strPhone = value
			End Set
		End Property

		Public Property DBAName As String
			Get
				Return Me.strDBAName
			End Get
			Set(ByVal value As String)
				Me.strDBAName = value
			End Set
		End Property

		Public Property Department As String
			Get
				Return Me.strDept
			End Get
			Set(ByVal value As String)
				Me.strDept = value
			End Set
		End Property

		Public Property ID As Integer Implements IEntity.Id
			Get
				Return Me.intID
			End Get
			Set(ByVal value As Integer)
				Me.intID = value
			End Set
		End Property

		Public Property LegalName As String
			Get
				Return Me.strLegalName
			End Get
			Set(ByVal value As String)
				Me.strLegalName = value
			End Set
		End Property

		Public Property QuoteReplyOption As String
			Get
				Return Me.strQuoteReplyOption
			End Get
			Set(ByVal value As String)
				Me.strQuoteReplyOption = value
			End Set
		End Property

		Public Property StatusTypeValue As String
			Get
				Return Me.strStatusValue
			End Get
			Set(ByVal value As String)
				Me.strStatusValue = value
			End Set
		End Property

		Shared Sub New()
			Agent.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace