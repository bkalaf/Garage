Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GaragePerson
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

		Private _strNameAge As String

		Private _intIsOwner As Integer

		Private _intIsOwnerSpouse As Integer

		Private _intIsEmployee As Integer

		Private _intIsDriver As Integer

		Private _intIsChildHouseHold As Integer

		Private _strDriverNameAge As String

		Private _strEmpNameAge As String

		Private _strPersonFurnisfedautos As String

		Private _strAllAges As String

		Private _strComments As String

		Public Property AllAges As String
			Get
				Return Me._strAllAges
			End Get
			Set(ByVal value As String)
				Me._strAllAges = value
			End Set
		End Property

		Public Property Comments As String
			Get
				Return Me._strComments
			End Get
			Set(ByVal value As String)
				Me._strComments = value
			End Set
		End Property

		Public Property DriverNameAge As String
			Get
				Return Me._strDriverNameAge
			End Get
			Set(ByVal value As String)
				Me._strDriverNameAge = value
			End Set
		End Property

		Public Property EmployeeNameAge As String
			Get
				Return Me._strEmpNameAge
			End Get
			Set(ByVal value As String)
				Me._strEmpNameAge = value
			End Set
		End Property

		Public Property GaragePersonId As Integer Implements IEntity.Id
			Get
				Return Me._intID
			End Get
			Set(ByVal value As Integer)
				Me._intID = value
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

		Public Property IsChildHouseHold As Integer
			Get
				Return Me._intIsChildHouseHold
			End Get
			Set(ByVal value As Integer)
				Me._intIsChildHouseHold = value
			End Set
		End Property

		Public Property IsDriver As Integer
			Get
				Return Me._intIsDriver
			End Get
			Set(ByVal value As Integer)
				Me._intIsDriver = value
			End Set
		End Property

		Public Property IsEmployee As Integer
			Get
				Return Me._intIsEmployee
			End Get
			Set(ByVal value As Integer)
				Me._intIsEmployee = value
			End Set
		End Property

		Public Property IsOwner As Integer
			Get
				Return Me._intIsOwner
			End Get
			Set(ByVal value As Integer)
				Me._intIsOwner = value
			End Set
		End Property

		Public Property IsOwnerSpouse As Integer
			Get
				Return Me._intIsOwnerSpouse
			End Get
			Set(ByVal value As Integer)
				Me._intIsOwnerSpouse = value
			End Set
		End Property

		Public Property NameAge As String
			Get
				Return Me._strNameAge
			End Get
			Set(ByVal value As String)
				Me._strNameAge = value
			End Set
		End Property

		Public Property PersonFurnishedAutos As String
			Get
				Return Me._strPersonFurnisfedautos
			End Get
			Set(ByVal value As String)
				Me._strPersonFurnisfedautos = value
			End Set
		End Property

		Shared Sub New()
			GaragePerson.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace