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
	Public Class InsuranceHistoryDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			InsuranceHistoryDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
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
			InsuranceHistoryDataModel.logger.Debug("Entering InsuranceHistoryDataModel.GetData")
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
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getInsuranceHistoryDetails", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim insuranceHistory As GarageQuoteSheetDLL.InsuranceHistory = New GarageQuoteSheetDLL.InsuranceHistory() With
					{
						.GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID_FK")),
						.InsuranceHistoryId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK")),
						.IsPreviousPolicyCancelled = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsPrevPolicyCancelled"))),
						.IsPreviousPolicyNotRenewed = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsPrevPolicyNotRenewed"))),
						.NotRenewalDetails = Conversions.ToString(dataSet.Tables(0).Rows(0)("NotRenewalDetails")),
						.CancellationDetails = Conversions.ToString(dataSet.Tables(0).Rows(0)("CancellationDetails"))
					}
					genericCollection.Add(insuranceHistory)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				InsuranceHistoryDataModel.logger.[Error](String.Concat("Exception occurred while fetching InsuranceHistory Details for QuoteId :", pstrQuoteID), exception)
				InsuranceHistoryDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			InsuranceHistoryDataModel.logger.Debug("Exiting InsuranceHistoryDataModel.GetData")
			Return genericCollection
		End Function

		Private Function getDetails(ByVal pv_QuoteID As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			Dim insuranceHistory As IEntity = New GarageQuoteSheetDLL.InsuranceHistory()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getInsuranceHistoryDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID_FK"))
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).InsuranceHistoryId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK"))
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyCancelled = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsPrevPolicyCancelled")))
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyNotRenewed = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("IsPrevPolicyNotRenewed"))
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).NotRenewalDetails = Conversions.ToString(dataSet.Tables(0).Rows(0)("NotRenewalDetails"))
				DirectCast(insuranceHistory, GarageQuoteSheetDLL.InsuranceHistory).CancellationDetails = Conversions.ToString(dataSet.Tables(0).Rows(0)("CancellationDetails"))
			End If
			Return insuranceHistory
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			InsuranceHistoryDataModel.logger.Debug("Entering InsuranceHistoryDataModel.Save")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(5) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).InsuranceHistoryId), "", DirectCast(objData.Item(0), InsuranceHistory).InsuranceHistoryId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageQuoteId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).GarageQuoteID), "", DirectCast(objData.Item(0), InsuranceHistory).GarageQuoteID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPrevPolicyCancelled",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).IsPreviousPolicyCancelled), "", DirectCast(objData.Item(0), InsuranceHistory).IsPreviousPolicyCancelled)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPrevPolicyNotRenewed",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).IsPreviousPolicyNotRenewed), "", DirectCast(objData.Item(0), InsuranceHistory).IsPreviousPolicyNotRenewed)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(3) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrCancellationDetails",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).CancellationDetails), "", DirectCast(objData.Item(0), InsuranceHistory).CancellationDetails)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(4) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrNotRenewalDetails",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), InsuranceHistory).NotRenewalDetails), "", DirectCast(objData.Item(0), InsuranceHistory).NotRenewalDetails)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(5) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageInsuranceHistory", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace