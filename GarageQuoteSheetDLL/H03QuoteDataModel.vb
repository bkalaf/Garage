Imports GarageQuoteSheetDLL.DAL
Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class H03QuoteDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			H03QuoteDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		''' <summary>
		''' 'Get Agency Information Based On AgencyId
		''' </summary>
		''' <param name="strAgencyId"></param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Function GetAgencyInformation(ByVal strAgencyId As String) As System.Data.DataSet
			Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "AgencyID",
				.Value = Strings.Right(String.Concat("000000", strAgencyId), 6)
			}
			sqlParameterArray(0) = sqlParameter
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("H03", "ConnectionString"), False)
			Return dataAccessModel.ReadDataSet("SIU_P_H03GetAgentInformation", sqlParameterArray, True)
		End Function

		Public Function GetQuoteDetails(ByVal _intQuoteId As Integer) As System.Data.DataSet
			Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "HomeOwnerQuoteId",
				.Value = _intQuoteId
			}
			sqlParameterArray(0) = sqlParameter
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("H03", "ConnectionString"), False)
			Return dataAccessModel.ReadDataSet("SIU_P_H03GetPersonalPropertyData", sqlParameterArray, True)
		End Function

		Public Function save(ByVal objQuoteData As GenericCollection(Of IEntity), ByVal objRisk As GenericCollection(Of IEntity), ByVal objInsuranceHistroy As GenericCollection(Of IEntity), ByVal objCoverage As GenericCollection(Of IEntity), ByVal objH03Quote As GenericCollection(Of IEntity), ByVal objAdditionalNotes As GenericCollection(Of IEntity)) As String
			Dim str As String
			H03QuoteDataModel.logger.Debug("Entering H03QuoteDataModel.Save")
			Try
				Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("H03", "ConnectionString"), True)
				Dim sqlParameterArray(13) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray1(15) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray2(5) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray3(12) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray4(13) As System.Data.SqlClient.SqlParameter
				H03QuoteDataModel.logger.Debug("Saving Quote Info with Agency Details...")
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPQuoteId",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).GarageQuoteID), "", DirectCast(objQuoteData.Item(0), GarageQuote).GarageQuoteID)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrQuoteNumber",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).GarageQuoteNumber), "", DirectCast(objQuoteData.Item(0), GarageQuote).GarageQuoteNumber)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAgentId",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).AgentID), "", DirectCast(objQuoteData.Item(0), GarageQuote).AgentID)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrContact",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).Contact), "", DirectCast(objQuoteData.Item(0), GarageQuote).Contact)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrPhone",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).Phone), "", DirectCast(objQuoteData.Item(0), GarageQuote).Phone)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrFax",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).Fax), "", DirectCast(objQuoteData.Item(0), GarageQuote).Fax)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrEmail",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).Email), "", DirectCast(objQuoteData.Item(0), GarageQuote).Email)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCreatedORModifiedBY",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).CreatedORModifiedBY), "", DirectCast(objQuoteData.Item(0), GarageQuote).CreatedORModifiedBY)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intParentQuoteId",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).ParentQuoteID), 0, DirectCast(objQuoteData.Item(0), GarageQuote).ParentQuoteID)),
					.DbType = DbType.Int32
				}
				sqlParameterArray(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@txtAdditionNotes"
				}
				If (Not (Not Information.IsNothing(objAdditionalNotes) And objAdditionalNotes.Count > 0)) Then
					sqlParameter.Value = ""
				Else
					sqlParameter.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objAdditionalNotes.Item(0), AdditionNotes).AdditionalNotes), 0, DirectCast(objAdditionalNotes.Item(0), AdditionNotes).AdditionalNotes))
				End If
				sqlParameter.DbType = DbType.[String]
				sqlParameterArray(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrUnderwriterName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).UnderwriterName), "", DirectCast(objQuoteData.Item(0), GarageQuote).UnderwriterName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@AgentFName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).AgentFname), "", DirectCast(objQuoteData.Item(0), GarageQuote).AgentFname)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@AgentLName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).AgentLName), "", DirectCast(objQuoteData.Item(0), GarageQuote).AgentLName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@AgentSSN",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).AgentSSN), "", DirectCast(objQuoteData.Item(0), GarageQuote).AgentSSN)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(13) = sqlParameter
				Dim [integer] As Integer = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_H03TransQuotes", sqlParameterArray, True))
				H03QuoteDataModel.logger.Debug("Quote Info with Agency Details... Saved")
				Dim arrayLists As ArrayList = New ArrayList()
				Dim transactionalContainer As GarageQuoteSheetDLL.DAL.TransactionalContainer = New GarageQuoteSheetDLL.DAL.TransactionalContainer()
				H03QuoteDataModel.logger.Debug("Submitting Risk Details...for saving in transaction")
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPId",
					.Value = 0,
					.DbType = DbType.Int32
				}
				sqlParameterArray1(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPQuoteId",
					.Value = [integer],
					.DbType = DbType.Int32
				}
				sqlParameterArray1(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAppicantFName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantFName), "", DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantFName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAppicantLName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantLName), "", DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantLName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAppicantMName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantMName), "", DirectCast(objRisk.Item(0), H03RiskDetails).ApplicantMName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrLocationAddLine1",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationAddLineOne), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationAddLineOne)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrLocationAddLine2",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationAddLineTwo), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationAddLineTwo)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCity",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationCity), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationCity)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrState",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationState), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationState)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrZipCode",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationZipcode), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationZipcode)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCounty",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).LocationCounty), "", DirectCast(objRisk.Item(0), H03RiskDetails).LocationCounty)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrTerritoryname",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).TerritoryName), "", DirectCast(objRisk.Item(0), H03RiskDetails).TerritoryName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrTerritorycode",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).TerritoryCode), "", DirectCast(objRisk.Item(0), H03RiskDetails).TerritoryCode)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrworkphone",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).WorkPhone), "", DirectCast(objRisk.Item(0), H03RiskDetails).WorkPhone)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(13) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrHomephone",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).HomePhone), "", DirectCast(objRisk.Item(0), H03RiskDetails).HomePhone)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(14) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter("vchrHomedesc", SqlDbType.Image) With
				{
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objRisk.Item(0), H03RiskDetails).HomeDescription), "", DirectCast(objRisk.Item(0), H03RiskDetails).HomeDescription))
				}
				sqlParameterArray1(15) = sqlParameter
				Dim num As Integer = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_H03Risk", sqlParameterArray1, True))
				H03QuoteDataModel.logger.Debug("Submitted Risk Details...for saving in transaction")
				If (Not Information.IsNothing(objInsuranceHistroy) And objInsuranceHistroy.Count > 0) Then
					H03QuoteDataModel.logger.Debug("Submitting H03 Insurance History Details...for saving in transaction")
					Dim count As Integer = objInsuranceHistroy.Count - 1
					For i As Integer = 0 To count
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intPId",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).WindHailLossHistoryId), "", DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).WindHailLossHistoryId)),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(0) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intPQuoteId",
							.Value = Integer.Parse(Conversions.ToString([integer])),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(1) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@LossesDescription",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).Description), "", DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).Description)),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(2) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@Amount",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).Amount), "", DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).Amount)),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(3) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@OutCome",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).OutComeLosses), "", DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).OutComeLosses)),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(4) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@TypeOfLosses",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).TypeofLosses), "", DirectCast(objInsuranceHistroy.Item(i), WindHailLossHistory).TypeofLosses)),
							.DbType = DbType.[String]
						}
						sqlParameterArray2(5) = sqlParameter
						num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_H03InsuranceHistory", sqlParameterArray2, True))
						H03QuoteDataModel.logger.Debug("Submitted H03LossHistory Details...for saving in transaction")
					Next

				End If
				H03QuoteDataModel.logger.Debug("Submitting Coverage Details...for saving in transaction")
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPId",
					.Value = 0,
					.DbType = DbType.Int32
				}
				sqlParameterArray3(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPQuoteId",
					.Value = Integer.Parse(Conversions.ToString([integer])),
					.DbType = DbType.Int32
				}
				sqlParameterArray3(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@A_DwellingAmount",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageA), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageA)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@C_PersonalProperty",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageC), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageC)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@E_Liability",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageE), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageE)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@F_MedPay",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageF), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageF)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@DeductibleAmount",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).Deductible), "", DirectCast(objCoverage.Item(0), H03Coverage).Deductible)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@WindandHailExclusion",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).WindHailEx), "", DirectCast(objCoverage.Item(0), H03Coverage).WindHailEx)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@Sinkholeexclusion",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).HasSinkHole), "", DirectCast(objCoverage.Item(0), H03Coverage).HasSinkHole)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@Ordinance",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).Ordinance), "", DirectCast(objCoverage.Item(0), H03Coverage).Ordinance)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@WindDeductible",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).WindDeductible), "", DirectCast(objCoverage.Item(0), H03Coverage).WindDeductible)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@B_AdjacentStructure",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageB), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageB)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@D_LossofUse",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverage.Item(0), H03Coverage).CoverageD), "", DirectCast(objCoverage.Item(0), H03Coverage).CoverageD)),
					.DbType = DbType.[String]
				}
				sqlParameterArray3(12) = sqlParameter
				num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_H03Coverage", sqlParameterArray3, True))
				H03QuoteDataModel.logger.Debug("Submitted Coverage Details...for saving in transaction")
				H03QuoteDataModel.logger.Debug("Submitting Quote Details...for saving in transaction")
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPId",
					.Value = 0,
					.DbType = DbType.Int32
				}
				sqlParameterArray4(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPQuoteId",
					.Value = Integer.Parse(Conversions.ToString([integer])),
					.DbType = DbType.Int32
				}
				sqlParameterArray4(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@BaseRate",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).TotalBase), "", DirectCast(objH03Quote.Item(0), H03Quote).TotalBase)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@AdditionalPremiums",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).SumAddPre), "", DirectCast(objH03Quote.Item(0), H03Quote).SumAddPre)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@TotalPremium",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).TotPre), "", DirectCast(objH03Quote.Item(0), H03Quote).TotPre)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@Surcharges",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).TotCredit), "", DirectCast(objH03Quote.Item(0), H03Quote).TotCredit)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@Discretion",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).UnderWriterDis), "", DirectCast(objH03Quote.Item(0), H03Quote).UnderWriterDis)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@InspectionFee",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).Policy), "", DirectCast(objH03Quote.Item(0), H03Quote).Policy)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@SalesTax",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).SalesTax), "", DirectCast(objH03Quote.Item(0), H03Quote).SalesTax)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@FSLSO",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).Fslso), "", DirectCast(objH03Quote.Item(0), H03Quote).Fslso)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@FHCF",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).Fhcf), "", DirectCast(objH03Quote.Item(0), H03Quote).Fhcf)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@CPICA",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).Cpica), "", DirectCast(objH03Quote.Item(0), H03Quote).Cpica)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@EMG",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).Emg), "", DirectCast(objH03Quote.Item(0), H03Quote).Emg)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@GrandTotal",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objH03Quote.Item(0), H03Quote).GrandTotal), "", DirectCast(objH03Quote.Item(0), H03Quote).GrandTotal)),
					.DbType = DbType.[String]
				}
				sqlParameterArray4(13) = sqlParameter
				num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_H03QuoteDetails", sqlParameterArray4, True))
				H03QuoteDataModel.logger.Debug("Submitted Coverage Details...for saving in transaction")
				str = Conversions.ToString([integer])
				dataAccessModel.CommitTransaction()
				dataAccessModel.CloseConnection()
				H03QuoteDataModel.logger.Debug("Exiting H03lQuoteDataModel.Save")
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				H03QuoteDataModel.logger.[Error]("Exception occurred while saving H03 transportation Quote ", exception)
				H03QuoteDataModel.logger.[Error](String.Concat("Exception Details ", exception.StackTrace))
				Throw exception
			End Try
			Return str
		End Function
	End Class
End Namespace