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
	Public Class InsuranceLossHistoryDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			InsuranceLossHistoryDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Public Function GetData(ByVal pstrQuoteID As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			InsuranceLossHistoryDataModel.logger.Debug("Entering InsuranceLossHistoryDataModel.GetData")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Try
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@GarageQuoteID",
					.DbType = DbType.Int32,
					.Value = pstrQuoteID
				}
				sqlParameterArray(0) = sqlParameter
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getInsuranceLossHistoryDetails", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim insuranceLossHistory As GarageQuoteSheetDLL.InsuranceLossHistory = New GarageQuoteSheetDLL.InsuranceLossHistory() With
					{
						.Carrier = dataSet.Tables(0).Rows(i)("Carrier").ToString(),
						.Amount = Convert.ToDecimal(dataSet.Tables(0).Rows(i)("Amount").ToString()),
						.Details = dataSet.Tables(0).Rows(i)("Details").ToString(),
						.TermFrom = Convert.ToDateTime(dataSet.Tables(0).Rows(i)("TermFrom").ToString()),
						.TermTo = Convert.ToDateTime(dataSet.Tables(0).Rows(i)("TermTo").ToString())
					}
					genericCollection.Add(insuranceLossHistory)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				InsuranceLossHistoryDataModel.logger.[Error](String.Concat("Exception occurred while fetcjhing Insurance LossHistory Details for QuoteId :", pstrQuoteID), exception)
				InsuranceLossHistoryDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			InsuranceLossHistoryDataModel.logger.Debug("Exiting InsuranceLossHistoryDataModel.GetData")
			Return genericCollection
		End Function

		Public Function getDetails(ByVal pv_QuoteID As String, ByVal cnt As Integer) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			Dim insuranceLossHistory As IEntity = New GarageQuoteSheetDLL.InsuranceLossHistory()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getInsuranceLossHistoryDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > cnt) Then
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(cnt)("GarageQuoteID_FK"))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).LossHistoryId = Conversions.ToInteger(dataSet.Tables(0).Rows(cnt)("ID_PK"))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).Amount = Conversions.ToDecimal(Interaction.IIf(Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(cnt)("Amount"))), RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(cnt)("Amount")), 0))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).Carrier = Conversions.ToString(dataSet.Tables(0).Rows(cnt)("Carrier"))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).Details = Conversions.ToString(dataSet.Tables(0).Rows(cnt)("Details"))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).TermFrom = Conversions.ToDate(dataSet.Tables(0).Rows(cnt)("TermFrom"))
				DirectCast(insuranceLossHistory, GarageQuoteSheetDLL.InsuranceLossHistory).TermTo = Conversions.ToDate(dataSet.Tables(0).Rows(cnt)("TermTo"))
			End If
			Return insuranceLossHistory
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			InsuranceLossHistoryDataModel.logger.Debug("Entering InsuranceLossHistoryDataModel.Save")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(6) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceLossHistory).LossHistoryId), "-1", DirectCast(objData.Item(0), InsuranceLossHistory).LossHistoryId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageQuoteId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceLossHistory).GarageQuoteID), "-1", DirectCast(objData.Item(0), InsuranceLossHistory).GarageQuoteID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dtTermFrom",
				.Value = DirectCast(objData.Item(0), InsuranceLossHistory).TermFrom,
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dtTermTo",
				.Value = DirectCast(objData.Item(0), InsuranceLossHistory).TermTo,
				.DbType = DbType.[String]
			}
			sqlParameterArray(3) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrCarrier",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceLossHistory).Carrier), "", DirectCast(objData.Item(0), InsuranceLossHistory).Carrier)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(4) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dcmAmount",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceLossHistory).Amount), "", DirectCast(objData.Item(0), InsuranceLossHistory).Amount)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(5) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@txtDetails",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceLossHistory).Details), "0", DirectCast(objData.Item(0), InsuranceLossHistory).Details)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(6) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageInsuranceLossHistory", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace