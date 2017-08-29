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
	Public Class GarageOperationsDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			GarageOperationsDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function CheckStateforCommAuto(ByVal pv_strStateCode As String) As Boolean
			Dim flag As Boolean
			Dim flag1 As Boolean
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Try
				GarageOperationsDataModel.logger.Debug("Entering GarageOperationDataModel.CheckStateForCommAuto")
				Dim sqlParameterArray(1) As System.Data.SqlClient.SqlParameter
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteTypeID",
					.Value = 2
				}
				sqlParameterArray(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrStateCode",
					.Value = pv_strStateCode.ToUpper().Trim()
				}
				sqlParameterArray(1) = sqlParameter
				Dim garageOperation As IEntity = New GarageOperations()
				flag = If(dataAccessModel.ReadDataSet("SIU_p_CheckElligibaleStatesForQuoteType", sqlParameterArray, True).Tables(0).Rows.Count <= 0, False, True)
				flag1 = flag
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageOperationsDataModel.logger.[Error]("Exception occurred while checking state for Commercial Auto: ", exception)
				GarageOperationsDataModel.logger.[Error](String.Concat("Exception Details", exception.StackTrace))
				Throw New System.Exception("Exception occurred while validating state")
			End Try
			Return flag1
		End Function

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Private Function GetCommercialTransportOperations(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			GarageOperationsDataModel.logger.Debug("Entering GarageOperationDataModel.GetCommercialTransportOpertaions")
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Try
				Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteID",
					.Value = pstrQuoteId
				}
				sqlParameterArray(0) = sqlParameter
				Dim garageOperation As GarageOperations = New GarageOperations()
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetCommercialTransportOperations", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					garageOperation = New GarageOperations() With
					{
						.GarageOperationId = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("Id_pk").ToString()),
						.GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("garageQuoteId_Fk").ToString()),
						.BusinessType = dataSet.Tables(0).Rows(i)("BusinessType").ToString(),
						.YrsInBusiness = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("YearsInBusiness").ToString()),
						.ApplicantName = dataSet.Tables(0).Rows(i)("ApplicantName").ToString(),
						.BusinessName = dataSet.Tables(0).Rows(i)("BusinessName").ToString(),
						.GarageAddress = dataSet.Tables(0).Rows(i)("GaragingAddress").ToString(),
						.City = dataSet.Tables(0).Rows(i)("City").ToString(),
						.County = dataSet.Tables(0).Rows(i)("County").ToString(),
						.State = dataSet.Tables(0).Rows(i)("State").ToString(),
						.ZipCode = dataSet.Tables(0).Rows(i)("ZipCode").ToString()
					}
					If (Not Conversions.ToBoolean(dataSet.Tables(0).Rows(i)("IsFillingRequired"))) Then
						garageOperation.IsFillingRequired = 0
					Else
						garageOperation.IsFillingRequired = 1
					End If
					garageOperation.FillingDetails = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("FillingDetails"))), "", dataSet.Tables(0).Rows(i)("FillingDetails").ToString()))
					If (Not Conversions.ToBoolean(dataSet.Tables(0).Rows(i)("AreVehiclesListed"))) Then
						garageOperation.AreAllVehiclesListed = 0
					Else
						garageOperation.AreAllVehiclesListed = 1
					End If
					garageOperation.ListedVehicleDetails = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("NotListedDetails"))), "", dataSet.Tables(0).Rows(i)("NotListedDetails").ToString()))
					garageOperation.CommoditiesHauled = dataSet.Tables(0).Rows(i)("Commodities").ToString()
					garageOperation.OperationRadius = dataSet.Tables(0).Rows(i)("OperationRadius").ToString()
					garageOperation.OperationCities = dataSet.Tables(0).Rows(i)("OperationCities").ToString()
					garageOperation.YearsInsured = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("YearsInsured").ToString())
					garageOperation.YearsSameTypeVehicles = dataSet.Tables(0).Rows(i)("YearsHavingSameTypeVehicles").ToString()
					garageOperation.OperationInsured = dataSet.Tables(0).Rows(i)("OperationInsured").ToString()
					genericCollection.Add(garageOperation)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageOperationsDataModel.logger.[Error]("Exception occurred while fetching operation details for Commerical Transport Quote", exception)
				GarageOperationsDataModel.logger.[Error](String.Concat("Exception Details : ", exception.StackTrace))
				Throw exception
			End Try
			GarageOperationsDataModel.logger.Debug("Exiting GarageOperationDataModel.GetCommercialTransportOpertaions")
			Return genericCollection
		End Function

		Public Function Getdata(ByVal pv_QuoteID As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialTransportOperations As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, Conversions.ToString(1), False) = 0) Then
				commercialTransportOperations = Me.GetCommercialTransportOperations(pv_QuoteID)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, Conversions.ToString(2), False) <> 0) Then
				commercialTransportOperations = New GenericCollection(Of IEntity)() From
				{
					Me.GetOperationDetails(pv_QuoteID)
				}
			End If
			Return commercialTransportOperations
		End Function

		Private Function GetOperationDetails(ByVal pv_QuoteID As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			Dim garageOperation As IEntity = New GarageOperations()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getGarageOperationDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				DirectCast(garageOperation, GarageOperations).BusinessType = dataSet.Tables(0).Rows(0)("BusinessType").ToString()
				DirectCast(garageOperation, GarageOperations).DollieOrTrailerDetails = dataSet.Tables(0).Rows(0)("DollieOrTrailerDetails").ToString()
				DirectCast(garageOperation, GarageOperations).FurnishedAutoDetails = dataSet.Tables(0).Rows(0)("FurnishedAutoDetails").ToString()
				DirectCast(garageOperation, GarageOperations).GarageOperationId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK").ToString())
				DirectCast(garageOperation, GarageOperations).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID_FK").ToString())
				DirectCast(garageOperation, GarageOperations).HasDollieOrTrailer = Common.getBit(dataSet.Tables(0).Rows(0)("HasDollieOrTrailer").ToString())
				DirectCast(garageOperation, GarageOperations).HasRollback = Common.getBit(dataSet.Tables(0).Rows(0)("HasRollback").ToString())
				DirectCast(garageOperation, GarageOperations).HasWrecker = Common.getBit(dataSet.Tables(0).Rows(0)("HasWrecker").ToString())
				DirectCast(garageOperation, GarageOperations).OperateOtherLocation = Common.getBit(dataSet.Tables(0).Rows(0)("OperateOtherLocation").ToString())
				DirectCast(garageOperation, GarageOperations).OperateSalvageYard = Common.getBit(dataSet.Tables(0).Rows(0)("OperateSalvageYard").ToString())
				DirectCast(garageOperation, GarageOperations).otherBusinessOperation = Common.getBit(dataSet.Tables(0).Rows(0)("otherBusinessOperation").ToString())
				DirectCast(garageOperation, GarageOperations).SellAutoParts = Common.getBit(dataSet.Tables(0).Rows(0)("SellAutoParts").ToString())
				DirectCast(garageOperation, GarageOperations).SellPercentage = Conversions.ToInteger(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("SellPercentage").ToString()), dataSet.Tables(0).Rows(0)("SellPercentage").ToString().Trim(), 0))
				DirectCast(garageOperation, GarageOperations).YrsInBusiness = Conversions.ToInteger(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("YearsInBusiness").ToString()), dataSet.Tables(0).Rows(0)("YearsInBusiness").ToString().Trim(), 0))
				DirectCast(garageOperation, GarageOperations).YrsExperience_NewVenture = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("YearsofExperience"))), "", dataSet.Tables(0).Rows(0)("YearsofExperience").ToString().Trim()))
				DirectCast(garageOperation, GarageOperations).FurnishedAutoDetails = dataSet.Tables(0).Rows(0)("FurnishedAutoDetails").ToString().Trim()
				DirectCast(garageOperation, GarageOperations).GarageAddress = dataSet.Tables(0).Rows(0)("GaragingAddress").ToString().Trim()
				DirectCast(garageOperation, GarageOperations).City = dataSet.Tables(0).Rows(0)("City").ToString().Trim()
				DirectCast(garageOperation, GarageOperations).YearsInsured = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("YearsInsured").ToString().Trim())
				Dim insuredOperation As GarageQuoteSheetDLL.InsuredOperation = New GarageQuoteSheetDLL.InsuredOperation() With
				{
					.OperationDetails = Conversions.ToString(dataSet.Tables(0).Rows(0)("OperationDetails"))
				}
				Dim genericCollection As GenericCollection(Of GarageQuoteSheetDLL.InsuredOperation) = New GenericCollection(Of GarageQuoteSheetDLL.InsuredOperation)() From
				{
					insuredOperation
				}
				DirectCast(garageOperation, GarageOperations).InsuredOperations = genericCollection
				Dim otherBusiness As GarageQuoteSheetDLL.OtherBusiness = New GarageQuoteSheetDLL.OtherBusiness() With
				{
					.OtherBusinessDetail = Conversions.ToString(dataSet.Tables(0).Rows(0)("OtherBusinessDetail"))
				}
				Dim genericCollection1 As GenericCollection(Of GarageQuoteSheetDLL.OtherBusiness) = New GenericCollection(Of GarageQuoteSheetDLL.OtherBusiness)() From
				{
					otherBusiness
				}
				DirectCast(garageOperation, GarageOperations).OtherBusinesses = genericCollection1
				Dim otherLocation As GarageQuoteSheetDLL.OtherLocation = New GarageQuoteSheetDLL.OtherLocation() With
				{
					.OperationLocation = Conversions.ToString(dataSet.Tables(0).Rows(0)("OperationLocation"))
				}
				Dim genericCollection2 As GenericCollection(Of GarageQuoteSheetDLL.OtherLocation) = New GenericCollection(Of GarageQuoteSheetDLL.OtherLocation)() From
				{
					otherLocation
				}
				DirectCast(garageOperation, GarageOperations).OtherLocations = genericCollection2
			End If
			Return garageOperation
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			GarageOperationsDataModel.logger.Debug("Entering GarageOperationsDataModel.Save")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(20) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).GarageOperationId), "", DirectCast(objData.Item(0), GarageOperations).GarageOperationId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageQuoteId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).GarageQuoteID), "", DirectCast(objData.Item(0), GarageOperations).GarageQuoteID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrBusinessType",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).BusinessType), "", DirectCast(objData.Item(0), GarageOperations).BusinessType)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intYearsInBusiness",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).YrsInBusiness), "", DirectCast(objData.Item(0), GarageOperations).YrsInBusiness)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(3) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@SellAutoParts",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).SellAutoParts), "", DirectCast(objData.Item(0), GarageOperations).SellAutoParts)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(4) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@SellPercentage",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).SellPercentage), "", DirectCast(objData.Item(0), GarageOperations).SellPercentage)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(5) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@OperateSalvageyard",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).OperateSalvageYard), "0", DirectCast(objData.Item(0), GarageOperations).OperateSalvageYard)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(6) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@OperateOtherLocation",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).OperateOtherLocation), "0", DirectCast(objData.Item(0), GarageOperations).OperateOtherLocation)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(7) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@OtherBusinessOperation",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).otherBusinessOperation), "", DirectCast(objData.Item(0), GarageOperations).otherBusinessOperation)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(8) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@HasDollieOrTrailer",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).HasDollieOrTrailer), "0", DirectCast(objData.Item(0), GarageOperations).HasDollieOrTrailer)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(9) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@txtDollieOrTrailerDetails",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).DollieOrTrailerDetails), "0", DirectCast(objData.Item(0), GarageOperations).DollieOrTrailerDetails)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(10) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@txtFurnishedAutoDetails",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), GarageOperations).FurnishedAutoDetails), "", DirectCast(objData.Item(0), GarageOperations).FurnishedAutoDetails)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(11) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@OperationDetails"
			}
			Try
				sqlParameter.Value = DirectCast(objData.Item(0), GarageOperations).InsuredOperations.Item(0).OperationDetails
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				sqlParameter.Value = String.Empty
				ProjectData.ClearProjectError()
			End Try
			sqlParameter.DbType = DbType.[String]
			sqlParameterArray(12) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@BusinessDetails"
			}
			Try
				sqlParameter.Value = DirectCast(objData.Item(0), GarageOperations).OtherBusinesses.Item(0).OtherBusinessDetail
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				sqlParameter.Value = String.Empty
				ProjectData.ClearProjectError()
			End Try
			sqlParameter.DbType = DbType.[String]
			sqlParameterArray(13) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@OperationLocation"
			}
			Try
				sqlParameter.Value = DirectCast(objData.Item(0), GarageOperations).OtherLocations.Item(0).OperationLocation
			Catch exception2 As System.Exception
				ProjectData.SetProjectError(exception2)
				sqlParameter.Value = String.Empty
				ProjectData.ClearProjectError()
			End Try
			sqlParameter.DbType = DbType.[String]
			sqlParameterArray(14) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@HasRollback",
				.Value = DirectCast(objData.Item(0), GarageOperations).HasRollback,
				.DbType = DbType.[String]
			}
			sqlParameterArray(15) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@HasWrecker",
				.Value = DirectCast(objData.Item(0), GarageOperations).HasWrecker,
				.DbType = DbType.[String]
			}
			sqlParameterArray(16) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrYrsExperience",
				.Value = DirectCast(objData.Item(0), GarageOperations).YrsExperience_NewVenture,
				.DbType = DbType.[String]
			}
			sqlParameterArray(17) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrgaragingadd",
				.Value = DirectCast(objData.Item(0), GarageOperations).GarageAddress,
				.DbType = DbType.[String]
			}
			sqlParameterArray(18) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrcity",
				.Value = DirectCast(objData.Item(0), GarageOperations).City,
				.DbType = DbType.[String]
			}
			sqlParameterArray(19) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrYrsInsured",
				.Value = DirectCast(objData.Item(0), GarageOperations).YearsInsured,
				.DbType = DbType.[String]
			}
			sqlParameterArray(20) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageOperations", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace