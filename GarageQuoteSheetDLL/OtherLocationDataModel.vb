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
	Public Class OtherLocationDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			OtherLocationDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Public Function GetData(ByVal pv_operationID As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Return DirectCast(Me.getDetails(pv_operationID), GenericCollection(Of IEntity))
		End Function

		Private Function getDetails(ByVal pv_OperationID As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageOperationID",
				.Value = pv_OperationID
			}
			sqlParameterArray(0) = sqlParameter
			Dim otherLocation As IEntity = New GarageQuoteSheetDLL.OtherLocation()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getOtherLocationDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				DirectCast(otherLocation, GarageQuoteSheetDLL.OtherLocation).GarageOperationID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageOperationID_FK"))
				DirectCast(otherLocation, GarageQuoteSheetDLL.OtherLocation).OtherLocationId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK"))
				DirectCast(otherLocation, GarageQuoteSheetDLL.OtherLocation).OperationLocation = Conversions.ToString(dataSet.Tables(0).Rows(0)("OperationLocation"))
			End If
			Return otherLocation
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			OtherLocationDataModel.logger.Debug("Entering OtherLocationDataModel.Save")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(2) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), OtherLocation).OtherLocationId), "", DirectCast(objData.Item(0), OtherLocation).OtherLocationId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageOperationId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), OtherLocation).GarageOperationID), "", DirectCast(objData.Item(0), OtherLocation).GarageOperationID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrOperationLocation",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), OtherLocation).OperationLocation), "", DirectCast(objData.Item(0), OtherLocation).OperationLocation)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_OtherLocations", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace