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
	Public Class GaragePersonalDetailDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			GaragePersonalDetailDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Public Function GetData(ByVal pv_QuoteID As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Return New GenericCollection(Of IEntity)() From
			{
				Me.getPersonDetails(pv_QuoteID)
			}
		End Function

		Private Function getPersonDetails(ByVal pv_QuoteID As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			Dim garagePerson As IEntity = New GarageQuoteSheetDLL.GaragePerson()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getPersonDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).GaragePersonId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID_FK"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).IsChildHouseHold = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsChildHouseHold")))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).NameAge = Conversions.ToString(dataSet.Tables(0).Rows(0)("NameAge"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).IsDriver = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsDriver")))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).IsEmployee = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsEmployee")))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).IsOwner = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsOwner")))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).IsOwnerSpouse = Common.getBit(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("IsOwnerSpouse")))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).DriverNameAge = Conversions.ToString(dataSet.Tables(0).Rows(0)("DriverNameAge"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).EmployeeNameAge = Conversions.ToString(dataSet.Tables(0).Rows(0)("EmpNameAge"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).PersonFurnishedAutos = Conversions.ToString(dataSet.Tables(0).Rows(0)("PersonFurnishedAutos"))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).AllAges = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("AllAges"))), "", RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("AllAges"))))
				DirectCast(garagePerson, GarageQuoteSheetDLL.GaragePerson).Comments = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("Comments"))), "", RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("Comments"))))
			End If
			Return garagePerson
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(12) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).GaragePersonId), "", DirectCast(objData.Item(0), GaragePerson).GaragePersonId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageQuoteId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).GarageQuoteID), "", DirectCast(objData.Item(0), GaragePerson).GarageQuoteID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrNameAge",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).NameAge), "", DirectCast(objData.Item(0), GaragePerson).NameAge)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsOwner",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).IsOwner), "", DirectCast(objData.Item(0), GaragePerson).IsOwner)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(3) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsOwnerSpouse",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).IsOwnerSpouse), "", DirectCast(objData.Item(0), GaragePerson).IsOwnerSpouse)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(4) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsEmployee",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).IsEmployee), "0", DirectCast(objData.Item(0), GaragePerson).IsEmployee)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(5) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsChildHouseHold",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).IsChildHouseHold), "0", DirectCast(objData.Item(0), GaragePerson).IsChildHouseHold)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(6) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsDriver",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).IsDriver), "", DirectCast(objData.Item(0), GaragePerson).IsDriver)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(7) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@DriverNameAge",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).DriverNameAge), "", DirectCast(objData.Item(0), GaragePerson).DriverNameAge)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(8) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@EmpNameAge",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).EmployeeNameAge), "", DirectCast(objData.Item(0), GaragePerson).EmployeeNameAge)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(9) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@PersonFurnishedAutos",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).PersonFurnishedAutos), "", DirectCast(objData.Item(0), GaragePerson).PersonFurnishedAutos)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(10) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@AllAges",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).AllAges), "", DirectCast(objData.Item(0), GaragePerson).AllAges)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(11) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@Comments",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GaragePerson).Comments), "", DirectCast(objData.Item(0), GaragePerson).Comments)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(12) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GaragePersonDetails", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace