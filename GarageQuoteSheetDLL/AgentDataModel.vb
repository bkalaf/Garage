Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class AgentDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			AgentDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Private Function getAgentDetails(ByVal pv_AgentCode As String) As GarageQuoteSheetDLL.Agent
			AgentDataModel.logger.Debug("Entering AgentDataModel.getAgentDetails")
			Dim agent As GarageQuoteSheetDLL.Agent = New GarageQuoteSheetDLL.Agent()
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@AgentCode",
				.Value = pv_AgentCode
			}
			sqlParameterArray(0) = sqlParameter
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getAgentDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				Dim pvAgentCode As GarageQuoteSheetDLL.Agent = agent
				pvAgentCode.AgentCode = pv_AgentCode
				pvAgentCode.LegalName = Conversions.ToString(dataSet.Tables(0).Rows(0)("AgentLegalName"))
				pvAgentCode.DBAName = Conversions.ToString(dataSet.Tables(0).Rows(0)("AgentDBAName"))
				pvAgentCode.AgentFax = Conversions.ToString(dataSet.Tables(0).Rows(0)("Fax"))
				Dim dataRowArray As DataRow() = dataSet.Tables(1).[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("statustypeid='", dataSet.Tables(0).Rows(0)("StatusTypeID")), "'")))
				If (CInt(dataRowArray.Length) > 0) Then
					pvAgentCode.StatusTypeValue = Conversions.ToString(dataRowArray(0)("StatusTypeValue"))
				End If
				dataRowArray = Nothing
				If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("SuspensionSetBy")))) Then
					If (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataSet.Tables(0).Rows(0)("SuspensionSetBy"), "", False)) Then
						dataRowArray = dataSet.Tables(2).[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("userid='", dataSet.Tables(0).Rows(0)("SuspensionSetBy")), "'")))
						If (CInt(dataRowArray.Length) > 0) Then
							pvAgentCode.Department = Conversions.ToString(dataRowArray(0)("Dept"))
						End If
						dataRowArray = Nothing
					End If
				End If
				pvAgentCode = Nothing
			End If
			Return agent
		End Function

		Public Function GetData(ByVal pv_AgentCode As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim genericCollection As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) <> 0) Then
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) = 0) Then
					Return genericCollection
				End If
				genericCollection = New GenericCollection(Of IEntity)() From
				{
					Me.getAgentDetails(pv_AgentCode)
				}
			End If
			Return genericCollection
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim num As Integer = 0
			Return num
		End Function

		Public Function update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace