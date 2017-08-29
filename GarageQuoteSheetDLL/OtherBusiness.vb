Imports log4net
Imports System
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class OtherBusiness
		Implements IEntity
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Private _intID As Integer

		Private _intGarageOperationID As Integer

		Private _strOtherBusinessDetail As String

		Public Property GarageOperationID As Integer
			Get
				Return Me._intGarageOperationID
			End Get
			Set(ByVal value As Integer)
				Me._intGarageOperationID = value
			End Set
		End Property

		Public Property OtherBusinessDetail As String
			Get
				Return Me._strOtherBusinessDetail
			End Get
			Set(ByVal value As String)
				Me._strOtherBusinessDetail = value
			End Set
		End Property

		Public Property OtherBusinessId As Integer Implements IEntity.Id
			Get
				Return Me._intID
			End Get
			Set(ByVal value As Integer)
				Me._intID = value
			End Set
		End Property

		Shared Sub New()
			OtherBusiness.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub
	End Class
End Namespace