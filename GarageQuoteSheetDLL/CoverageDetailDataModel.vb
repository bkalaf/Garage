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
	Public Class CoverageDetailDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			CoverageDetailDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal key As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Private Function GetCommercialTransportCoverages(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			CoverageDetailDataModel.logger.Debug("Entering GarageOperationDataModel.GetCommercialTransportCoverages")
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
				Dim coverageDetail As GarageQuoteSheetDLL.CoverageDetail = New GarageQuoteSheetDLL.CoverageDetail()
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetCommercialTransportCoverages", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					coverageDetail = New GarageQuoteSheetDLL.CoverageDetail() With
					{
						.CoverageId = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("Id_pk").ToString()),
						.GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("garageQuoteId_Fk").ToString()),
						.LibilityLimit_Csl = dataSet.Tables(0).Rows(i)("LiabilityLimit_Csl").ToString(),
						.LiabilityLimit_Split = dataSet.Tables(0).Rows(i)("LiabilityLimit_Split").ToString(),
						.UnInsuredMotorist_Csl = dataSet.Tables(0).Rows(i)("UnInsuredMotorist_Csl").ToString(),
						.UnInsuredMotorist_Split = dataSet.Tables(0).Rows(i)("UnInsuredMotorist_Split").ToString(),
						.IsHired = Conversions.ToInteger(Interaction.IIf(Conversions.ToBoolean(dataSet.Tables(0).Rows(i)("IsHired")), 1, 0)),
						.HiredDetails = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("HiredDetails"))), "", dataSet.Tables(0).Rows(i)("HiredDetails").ToString())),
						.IsNonOwned = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("IsNonOwned").ToString()),
						.NonOwnedDetails = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("NonOwnedDetails"))), "", dataSet.Tables(0).Rows(i)("NonOwnedDetails").ToString())),
						.MedPayLimit = dataSet.Tables(0).Rows(i)("MedPayLimit").ToString(),
						.TruckCargoDetails = dataSet.Tables(0).Rows(i)("TruckCargoDetails").ToString(),
						.IsReeferBreaking = Conversions.ToInteger(Interaction.IIf(Conversions.ToBoolean(dataSet.Tables(0).Rows(i)("IsReeferBreakDown")), 1, 0)),
						.ReeferBreaking = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("ReeferBreakDownDetails"))), "", dataSet.Tables(0).Rows(i)("ReeferBreakDownDetails").ToString())),
						.ISAddtnlInsured = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("ISAdditionalInsured").ToString()),
						.AddtnlInsuerdDetails = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("AdditionalInsuredDetails"))), "", dataSet.Tables(0).Rows(i)("AdditionalInsuredDetails").ToString())),
						.Deductible = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("Deductible"))), "", dataSet.Tables(0).Rows(i)("Deductible").ToString())),
						.DeductibleCargo = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("DeductibleCargo"))), "", dataSet.Tables(0).Rows(i)("DeductibleCargo").ToString())),
						.NoOfDealerTags = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("noofDealerTags"))), "", dataSet.Tables(0).Rows(i)("noofDealertags").ToString())),
						.AdditionalInfo = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("AdditionalInfo"))), "", dataSet.Tables(0).Rows(i)("AdditionalInfo").ToString())),
						.PIP = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("PIP"))), "", dataSet.Tables(0).Rows(i)("PIP").ToString()))
					}
					If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(i)("IsCargo")))) Then
						coverageDetail.IsCargo = Conversions.ToBoolean(dataSet.Tables(0).Rows(i)("IsCargo"))
					Else
						coverageDetail.IsCargo = False
					End If
					genericCollection.Add(coverageDetail)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				CoverageDetailDataModel.logger.[Error]("Exception occurred while fetching Coverage details for Commerical Transport Quote", exception)
				CoverageDetailDataModel.logger.[Error](String.Concat("Exception Details : ", exception.StackTrace))
				Throw exception
			End Try
			CoverageDetailDataModel.logger.Debug("Exiting GarageOperationDataModel.GetCommercialTransportCoverages")
			Return genericCollection
		End Function

		Private Function getCoverageDetails(ByVal pv_QuoteNo As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteNo
			}
			sqlParameterArray(0) = sqlParameter
			Dim coverageDetail As IEntity = New GarageQuoteSheetDLL.CoverageDetail()
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getCoverageDetails", sqlParameterArray, True)
			If (dataSet.Tables(0).Rows.Count > 0) Then
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsCollision = Common.getBit(dataSet.Tables(0).Rows(0)("IsCollision").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsComprehensive = Common.getBit(dataSet.Tables(0).Rows(0)("IsComprehensive").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsPerils = Common.getBit(dataSet.Tables(0).Rows(0)("IsPerils").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalIsCollision = Common.getBit(dataSet.Tables(0).Rows(0)("Physical_IsCollision").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalIsComprehensive = Common.getBit(dataSet.Tables(0).Rows(0)("Physical_IsComprehensive").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalIsPerils = Common.getBit(dataSet.Tables(0).Rows(0)("Physical_IsPerils").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsDirectPrimary = Common.getBit(dataSet.Tables(0).Rows(0)("IsDirectPrimary").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLegalLiability = Common.getBit(dataSet.Tables(0).Rows(0)("IsLegalLiability").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLotChained = Common.getBit(dataSet.Tables(0).Rows(0)("IsLotChained").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLotFenced = Common.getBit(dataSet.Tables(0).Rows(0)("IsLotFenced").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLotLightedNight = Common.getBit(dataSet.Tables(0).Rows(0)("IsLotLightedNight").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLotLightedNight = Common.getBit(dataSet.Tables(0).Rows(0)("IsLotLightedNight").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsLotOpen = Common.getBit(dataSet.Tables(0).Rows(0)("IsLotOpen").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).IsUninsuredMotorist = Common.getBit(dataSet.Tables(0).Rows(0)("IsUninsuredMotorist").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).LiabiltyLimit = dataSet.Tables(0).Rows(0)("LiabilityLimit").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).MaxLimitPerUnit = Conversions.ToDecimal(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("MaxLimitPerUnit").ToString()), dataSet.Tables(0).Rows(0)("MaxLimitPerUnit").ToString().Trim(), 0))
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).MedPayLimit = dataSet.Tables(0).Rows(0)("MedPayLimit").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).NoofDealerPlates = Conversions.ToInteger(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("NoofDealerPlates").ToString()), dataSet.Tables(0).Rows(0)("NoofDealerPlates").ToString().Trim(), 0))
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).OperationRadius = dataSet.Tables(0).Rows(0)("OperationRadius").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalDeductible = dataSet.Tables(0).Rows(0)("Physical_Deductible").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalMaxUnitPerLimit = Conversions.ToDecimal(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("Physical_MaxLimitPerUnit").ToString()), dataSet.Tables(0).Rows(0)("Physical_MaxLimitPerUnit").ToString().Trim(), 0))
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PhysicalValuePerLot = Conversions.ToDecimal(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("Physical_ValuePerLot").ToString()), dataSet.Tables(0).Rows(0)("Physical_ValuePerLot").ToString().Trim(), 0))
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).Reject = dataSet.Tables(0).Rows(0)("Reject").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).ValuePerLot = Conversions.ToDecimal(Interaction.IIf(Versioned.IsNumeric(dataSet.Tables(0).Rows(0)("ValuePerLot").ToString()), dataSet.Tables(0).Rows(0)("ValuePerLot").ToString().Trim(), 0))
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).CoverageId = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("ID_PK").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID_FK").ToString())
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).Deductible = dataSet.Tables(0).Rows(0)("Deductible").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).NoOfDealerTags = dataSet.Tables(0).Rows(0)("NoofDealerTags").ToString()
				DirectCast(coverageDetail, GarageQuoteSheetDLL.CoverageDetail).PIP = dataSet.Tables(0).Rows(0)("PIP").ToString()
			End If
			Return coverageDetail
		End Function

		Public Function getdata(ByVal pv_QuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialTransportCoverages As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				commercialTransportCoverages = Me.GetCommercialTransportCoverages(pv_QuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				commercialTransportCoverages = New GenericCollection(Of IEntity)() From
				{
					Me.getCoverageDetails(pv_QuoteId)
				}
			End If
			Return commercialTransportCoverages
		End Function

		Public Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			CoverageDetailDataModel.logger.Debug("Entering CoverageDetailDataModel.Save")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(27) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).CoverageId), "", DirectCast(objData.Item(0), CoverageDetail).CoverageId)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intPGarageQuoteId",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).GarageQuoteID), "", DirectCast(objData.Item(0), CoverageDetail).GarageQuoteID)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(1) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrLiabilityLimit",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).LiabiltyLimit), "", DirectCast(objData.Item(0), CoverageDetail).LiabiltyLimit)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(2) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsUnInsuredMotorist",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsUninsuredMotorist), "", DirectCast(objData.Item(0), CoverageDetail).IsUninsuredMotorist)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(3) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrReject",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).Reject), "", DirectCast(objData.Item(0), CoverageDetail).Reject)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(4) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrmedPayLimit",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).MedPayLimit), "", DirectCast(objData.Item(0), CoverageDetail).MedPayLimit)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(5) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrOperationRadius",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).OperationRadius), "0", DirectCast(objData.Item(0), CoverageDetail).OperationRadius)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(6) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intNoOfDealerPlates",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).NoofDealerPlates), "0", DirectCast(objData.Item(0), CoverageDetail).NoofDealerPlates)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(7) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IslegelLiability",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsLegalLiability), "", DirectCast(objData.Item(0), CoverageDetail).IsLegalLiability)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(8) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsDirectPrimary",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsDirectPrimary), "", DirectCast(objData.Item(0), CoverageDetail).IsDirectPrimary)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(9) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dcmValuePerLot",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).ValuePerLot), "", DirectCast(objData.Item(0), CoverageDetail).ValuePerLot)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(10) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrDeductible",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).Deductible), "", DirectCast(objData.Item(0), CoverageDetail).Deductible)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(11) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dcmMaxLimitPerUnit",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).MaxLimitPerUnit), "", DirectCast(objData.Item(0), CoverageDetail).MaxLimitPerUnit)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(12) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPerils",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsPerils), "", DirectCast(objData.Item(0), CoverageDetail).IsPerils)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(13) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsCollision",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsCollision), "", DirectCast(objData.Item(0), CoverageDetail).IsCollision)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(14) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsComprehensive",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(DirectCast(objData.Item(0), CoverageDetail).IsComprehensive)), "0", RuntimeHelpers.GetObjectValue(DirectCast(objData.Item(0), CoverageDetail).IsComprehensive))),
				.DbType = DbType.[String]
			}
			sqlParameterArray(15) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dcmPhysicalValuePerLot",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalValuePerLot), "0", DirectCast(objData.Item(0), CoverageDetail).PhysicalValuePerLot)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(16) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrPhysicalDeductible",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalDeductible), "", DirectCast(objData.Item(0), CoverageDetail).PhysicalDeductible)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(17) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@dcmPhysicalMaxLimitPerUnit",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalMaxUnitPerLimit), "0", DirectCast(objData.Item(0), CoverageDetail).PhysicalMaxUnitPerLimit)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(18) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPhysicalPerils",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalIsPerils), "0", DirectCast(objData.Item(0), CoverageDetail).PhysicalIsPerils)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(19) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPhysicalCollision",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalIsCollision), "", DirectCast(objData.Item(0), CoverageDetail).PhysicalIsCollision)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(20) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsPhysicalComprehensive",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PhysicalIsComprehensive), "0", DirectCast(objData.Item(0), CoverageDetail).PhysicalIsComprehensive)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(21) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsLotLightedNight",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsLotLightedNight), "0", DirectCast(objData.Item(0), CoverageDetail).IsLotLightedNight)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(22) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsLotChained",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsLotChained), "", DirectCast(objData.Item(0), CoverageDetail).IsLotChained)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(23) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsLotFenced",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsLotFenced), "0", DirectCast(objData.Item(0), CoverageDetail).IsLotFenced)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(24) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@IsLotOpen",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).IsLotOpen), "0", DirectCast(objData.Item(0), CoverageDetail).IsLotOpen)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(25) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrDealerTags",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).NoOfDealerTags), "0", DirectCast(objData.Item(0), CoverageDetail).NoOfDealerTags)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(26) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@vchrPIP",
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objData.Item(0), CoverageDetail).PIP), "0", DirectCast(objData.Item(0), CoverageDetail).PIP)),
				.DbType = DbType.[String]
			}
			sqlParameterArray(27) = sqlParameter
			Return Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_CoverageDetails", sqlParameterArray))
		End Function

		Public Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace