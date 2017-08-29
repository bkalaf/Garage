Imports GarageQuoteSheetDLL.DAL
Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class RiskDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			RiskDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		<Obsolete("Not Implemented")>
		Public Function Delete(ByVal strQuoteId As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Public Function GetData(ByVal pstrQuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim h03RiskDetails As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				h03RiskDetails = Me.GetH03RiskDetails(pstrQuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				h03RiskDetails = New GenericCollection(Of IEntity)()
			End If
			Return h03RiskDetails
		End Function

		Private Function GetH03RiskDetails(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			RiskDataModel.logger.Debug("Entering RiskDataModel.GetH03RiskDetails")
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Try
				Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteId",
					.Value = pstrQuoteId
				}
				sqlParameterArray(0) = sqlParameter
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetRiskDetailsByQuoteId", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim h03RiskDetail As H03RiskDetails = New H03RiskDetails() With
					{
						.H03RiskId = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("Id_Pk").ToString()),
						.ApplicantFName = dataSet.Tables(0).Rows(i)("ApplicanFname").ToString(),
						.ApplicantLName = dataSet.Tables(0).Rows(i)("ApplicanLname").ToString(),
						.ApplicantMName = dataSet.Tables(0).Rows(i)("ApplicanMname").ToString()
					}
					genericCollection.Add(h03RiskDetail)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				RiskDataModel.logger.[Error](String.Concat("Exception occurred while fetching Risk Details for QuoteId :", pstrQuoteId), exception)
				RiskDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			RiskDataModel.logger.Debug("Exiting RiskDataModel.GetH03RiskDetails")
			Return genericCollection
		End Function

		<Obsolete("Not Implemented")>
		Public Function Save(ByVal objVehicles As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim num As Integer = 0
			Return num
		End Function

		<Obsolete("Not Implemented")>
		Public Function Update(ByVal objVehicles As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace