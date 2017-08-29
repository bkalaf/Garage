Imports GarageQuoteSheetDLL.DAL
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
	Public Class CommercialQuoteDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			CommercialQuoteDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function save(ByVal objQuoteData As GenericCollection(Of IEntity), ByVal objOperations As GenericCollection(Of IEntity), ByVal objCoverages As GenericCollection(Of IEntity), ByVal objInsuranceHistroy As GenericCollection(Of IEntity), ByVal objVehicles As GenericCollection(Of IEntity), ByVal objDrivers As GenericCollection(Of IEntity), ByVal objAdditionalNotes As GenericCollection(Of IEntity)) As String
			Dim str As String
			Dim enumerator As IEnumerator = Nothing
			CommercialQuoteDataModel.logger.Debug("Entering CommercialQuoteDataModel.Save")
			Try
				Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), True)
				Dim sqlParameterArray(11) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray1(20) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray2(21) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray3(5) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray4(6) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray5(7) As System.Data.SqlClient.SqlParameter
				Dim sqlParameterArray6(5) As System.Data.SqlClient.SqlParameter
				CommercialQuoteDataModel.logger.Debug("Saving Quote Info with Agency Details...")
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
					.ParameterName = "@vchrUnderwriterEmail",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objQuoteData.Item(0), GarageQuote).UnderwriterEmail), "", DirectCast(objQuoteData.Item(0), GarageQuote).UnderwriterEmail)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(11) = sqlParameter
				Dim [integer] As Integer = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_CommercialTransQuotes", sqlParameterArray, True))
				CommercialQuoteDataModel.logger.Debug("Quote Info with Agency Details... Saved")
				Dim arrayLists As ArrayList = New ArrayList()
				Dim transactionalContainer As GarageQuoteSheetDLL.DAL.TransactionalContainer = New GarageQuoteSheetDLL.DAL.TransactionalContainer()
				CommercialQuoteDataModel.logger.Debug("Submitting Operation Details...for saving in transaction")
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
					.ParameterName = "@vchrBusinessType",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).BusinessType), "", DirectCast(objOperations.Item(0), GarageOperations).BusinessType)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intYearsInBusiness",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).YrsInBusiness), "", DirectCast(objOperations.Item(0), GarageOperations).YrsInBusiness)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrApplicantName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).ApplicantName), "", DirectCast(objOperations.Item(0), GarageOperations).ApplicantName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrBusinessName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).BusinessName), "", DirectCast(objOperations.Item(0), GarageOperations).BusinessName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrgaragingAddress",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).GarageAddress), "", DirectCast(objOperations.Item(0), GarageOperations).GarageAddress)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCity",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).City), "", DirectCast(objOperations.Item(0), GarageOperations).City)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCounty",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).County), "", DirectCast(objOperations.Item(0), GarageOperations).County)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrState",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).State), "", DirectCast(objOperations.Item(0), GarageOperations).State)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrZipCode",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).ZipCode), "", DirectCast(objOperations.Item(0), GarageOperations).ZipCode)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitIsFilling",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).IsFillingRequired), "", DirectCast(objOperations.Item(0), GarageOperations).IsFillingRequired)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrFillingDetail",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).FillingDetails), "", DirectCast(objOperations.Item(0), GarageOperations).FillingDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitAreVehicleListed",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).AreAllVehiclesListed), "", DirectCast(objOperations.Item(0), GarageOperations).AreAllVehiclesListed)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(13) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrNotListedDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).ListedVehicleDetails), "", DirectCast(objOperations.Item(0), GarageOperations).ListedVehicleDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(14) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCommodities",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).CommoditiesHauled), "", DirectCast(objOperations.Item(0), GarageOperations).CommoditiesHauled)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(15) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrOperationRadius",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).OperationRadius), "", DirectCast(objOperations.Item(0), GarageOperations).OperationRadius)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(16) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrOperationCities",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).OperationCities), "", DirectCast(objOperations.Item(0), GarageOperations).OperationCities)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(17) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intYearsInsured",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).YearsInsured), "", DirectCast(objOperations.Item(0), GarageOperations).YearsInsured)),
					.DbType = DbType.Int32
				}
				sqlParameterArray1(18) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrYrsSameTypeVehicles",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).YearsSameTypeVehicles), "", DirectCast(objOperations.Item(0), GarageOperations).YearsSameTypeVehicles)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(19) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchoperationInsured",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objOperations.Item(0), GarageOperations).OperationInsured), "", DirectCast(objOperations.Item(0), GarageOperations).OperationInsured)),
					.DbType = DbType.[String]
				}
				sqlParameterArray1(20) = sqlParameter
				Dim num As Integer = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_TransportOperations", sqlParameterArray1, True))
				CommercialQuoteDataModel.logger.Debug("Submitted Operation Details...for saving in transaction")
				CommercialQuoteDataModel.logger.Debug("Submitting Coverage Details...for saving in transaction")
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPId",
					.Value = 0,
					.DbType = DbType.Int32
				}
				sqlParameterArray2(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPGarageQuoteId",
					.Value = Integer.Parse(Conversions.ToString([integer])),
					.DbType = DbType.Int32
				}
				sqlParameterArray2(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrLiabilityLimit_CSL",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl), "", DirectCast(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrLiabilityLimit_SPLIT",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl), "", DirectCast(objCoverages.Item(0), CoverageDetail).LiabilityLimit_Split)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrUnInsuredMotorist_CSL",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl), "", DirectCast(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrUnInsuredMotorist_SPLIT",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Split), "", DirectCast(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Split)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrmedPayLimit",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).MedPayLimit), "", DirectCast(objCoverages.Item(0), CoverageDetail).MedPayLimit)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitIsHired",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).IsHired), "", DirectCast(objCoverages.Item(0), CoverageDetail).IsHired)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrHiredDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).HiredDetails), "", DirectCast(objCoverages.Item(0), CoverageDetail).HiredDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitIsNonOwned",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).IsNonOwned), "", DirectCast(objCoverages.Item(0), CoverageDetail).IsNonOwned)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrNonOwnedDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).NonOwnedDetails), "", DirectCast(objCoverages.Item(0), CoverageDetail).NonOwnedDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitIsReeferBreakDown",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).IsReeferBreaking), "", DirectCast(objCoverages.Item(0), CoverageDetail).IsReeferBreaking)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrReeferBreakDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).ReeferBreaking), "", DirectCast(objCoverages.Item(0), CoverageDetail).ReeferBreaking)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@bitIsAdditionalInsured",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).ISAddtnlInsured), "", DirectCast(objCoverages.Item(0), CoverageDetail).ISAddtnlInsured)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(13) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAdtnlInsuredDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).AddtnlInsuerdDetails), "", DirectCast(objCoverages.Item(0), CoverageDetail).AddtnlInsuerdDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(14) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrTruckCargoDetails",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).TruckCargoDetails), "", DirectCast(objCoverages.Item(0), CoverageDetail).TruckCargoDetails)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(15) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrDeductible",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).Deductible), "", DirectCast(objCoverages.Item(0), CoverageDetail).Deductible)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(16) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrDeductibleCargo",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).DeductibleCargo), "", DirectCast(objCoverages.Item(0), CoverageDetail).DeductibleCargo)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(17) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrPIP",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).PIP), "", DirectCast(objCoverages.Item(0), CoverageDetail).PIP)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(18) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrNoofDealerTags",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).NoOfDealerTags), "", DirectCast(objCoverages.Item(0), CoverageDetail).NoOfDealerTags)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(19) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@blnIsCargo",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).IsCargo), 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(DirectCast(objCoverages.Item(0), CoverageDetail).IsCargo, 1, 0)))),
					.DbType = DbType.[Boolean]
				}
				sqlParameterArray2(20) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAdditionalInfo",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objCoverages.Item(0), CoverageDetail).AdditionalInfo), "", DirectCast(objCoverages.Item(0), CoverageDetail).AdditionalInfo)),
					.DbType = DbType.[String]
				}
				sqlParameterArray2(21) = sqlParameter
				num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_transportCoverageDetails", sqlParameterArray2, True))
				CommercialQuoteDataModel.logger.Debug("Submitted Coverage Details...for saving in transaction")
				If (Not Information.IsNothing(objInsuranceHistroy) And objInsuranceHistroy.Count > 0) Then
					CommercialQuoteDataModel.logger.Debug("Submitting Insurance History Details...for saving in transaction")
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@intPId",
						.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).InsuranceHistoryId), "", DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).InsuranceHistoryId)),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(0) = sqlParameter
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@intPGarageQuoteId",
						.Value = Integer.Parse(Conversions.ToString([integer])),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(1) = sqlParameter
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@IsPrevPolicyCancelled",
						.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyCancelled), "", DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyCancelled)),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(2) = sqlParameter
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@IsPrevPolicyNotRenewed",
						.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyNotRenewed), "", DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).IsPreviousPolicyNotRenewed)),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(3) = sqlParameter
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@vchrCancellationDetails",
						.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).CancellationDetails), "", DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).CancellationDetails)),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(4) = sqlParameter
					sqlParameter = New System.Data.SqlClient.SqlParameter() With
					{
						.ParameterName = "@vchrNotRenewalDetails",
						.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).NotRenewalDetails), "", DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory).NotRenewalDetails)),
						.DbType = DbType.[String]
					}
					sqlParameterArray3(5) = sqlParameter
					num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageInsuranceHistory", sqlParameterArray3, True))
					CommercialQuoteDataModel.logger.Debug("Submitted InsuranceHistory Details...for saving in transaction")
					Dim insuranceLossHistory As GarageQuoteSheetDLL.InsuranceLossHistory = New GarageQuoteSheetDLL.InsuranceLossHistory()
					Dim insuranceHistory As GarageQuoteSheetDLL.InsuranceHistory = DirectCast(objInsuranceHistroy.Item(0), GarageQuoteSheetDLL.InsuranceHistory)
					If (insuranceHistory.InsuranceLossHIstory.Count >= 1) Then
						Dim count As Integer = insuranceHistory.InsuranceLossHIstory.Count - 1
						For i As Integer = 0 To count
							CommercialQuoteDataModel.logger.Debug("Submitting Insurance Loss History Details...for saving in transaction")
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@intPId",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).LossHistoryId,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(0) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@intPGarageQuoteId",
								.Value = Integer.Parse(Conversions.ToString([integer])),
								.DbType = DbType.[String]
							}
							sqlParameterArray4(1) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@dtTermFrom",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).TermFrom,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(2) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@dtTermTo",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).TermTo,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(3) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@vchrCarrier",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).Carrier,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(4) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@dcmAmount",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).Amount,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(5) = sqlParameter
							sqlParameter = New System.Data.SqlClient.SqlParameter() With
							{
								.ParameterName = "@txtDetails",
								.Value = insuranceHistory.InsuranceLossHIstory.Item(i).Details,
								.DbType = DbType.[String]
							}
							sqlParameterArray4(6) = sqlParameter
							num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageInsuranceLossHistory", sqlParameterArray4, True))
							CommercialQuoteDataModel.logger.Debug("Submitted Operation Details...for saving in transaction")
						Next

					End If
				End If
				If (Not Information.IsNothing(objVehicles) And objVehicles.Count > 0) Then
					CommercialQuoteDataModel.logger.Debug("Submitting Vehicle Details...for saving in transaction")
					Dim count1 As Integer = objVehicles.Count - 1
					Dim num1 As Integer = 0
					Do
						Dim log As ILog = CommercialQuoteDataModel.logger
						Dim num2 As Integer = num1 + 1
						log.Debug(String.Concat("Submitting Vehicle Details...for Vehicle ", num2.ToString(), " for saving in transaction"))
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intPId",
							.Value = 0,
							.DbType = DbType.Int32
						}
						sqlParameterArray5(0) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intQuoteID_Fk",
							.Value = Integer.Parse(Conversions.ToString([integer])),
							.DbType = DbType.Int32
						}
						sqlParameterArray5(1) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@chrVehicleYear",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).Year), "", DirectCast(objVehicles.Item(num1), Vehicle).Year)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(2) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@chrMake",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).Make), "", DirectCast(objVehicles.Item(num1), Vehicle).Make)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(3) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@chrGVW",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).GVW), "", DirectCast(objVehicles.Item(num1), Vehicle).GVW)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(4) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@chrType",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).VehicleType), "", DirectCast(objVehicles.Item(num1), Vehicle).VehicleType)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(5) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@vchrStatedValue",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).StatedValue), "", DirectCast(objVehicles.Item(num1), Vehicle).StatedValue)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(6) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@vchrDeductible",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objVehicles.Item(num1), Vehicle).Deductible), "", DirectCast(objVehicles.Item(num1), Vehicle).Deductible)),
							.DbType = DbType.[String]
						}
						sqlParameterArray5(7) = sqlParameter
						num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_VehicleDetails", sqlParameterArray5, True))
						num1 = num1 + 1
					Loop While num1 <= count1
					CommercialQuoteDataModel.logger.Debug("Submitted Vehicle Details...for saving in transaction")
				End If
				If (Not Information.IsNothing(objDrivers) And objDrivers.Count > 0) Then
					CommercialQuoteDataModel.logger.Debug("Saving Driver Details...")
					Dim count2 As Integer = objDrivers.Count - 1
					For j As Integer = 0 To count2
						CommercialQuoteDataModel.logger.Debug(String.Concat("Saving Driver Details...row ", Conversions.ToString(j)))
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intPId",
							.Value = 0,
							.DbType = DbType.Int32
						}
						sqlParameterArray6(0) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intPQuoteID",
							.Value = Integer.Parse(Conversions.ToString([integer])),
							.DbType = DbType.[String]
						}
						sqlParameterArray6(1) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@vchrDriverName",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objDrivers.Item(j), Driver).Name), "", DirectCast(objDrivers.Item(j), Driver).Name)),
							.DbType = DbType.[String]
						}
						sqlParameterArray6(2) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@dtDOB",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objDrivers.Item(j), Driver).DOB), "", DirectCast(objDrivers.Item(j), Driver).DOB)),
							.DbType = DbType.[Date]
						}
						sqlParameterArray6(3) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@intYrsExperience",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objDrivers.Item(j), Driver).YearsExperience), "", DirectCast(objDrivers.Item(j), Driver).YearsExperience)),
							.DbType = DbType.[String]
						}
						sqlParameterArray6(4) = sqlParameter
						sqlParameter = New System.Data.SqlClient.SqlParameter() With
						{
							.ParameterName = "@dtHireDate",
							.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(objDrivers.Item(j), Driver).HireDate), "", DirectCast(objDrivers.Item(j), Driver).HireDate)),
							.DbType = DbType.[Date]
						}
						sqlParameterArray6(5) = sqlParameter
						Dim integer1 As Integer = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_Insertupdate_transportDriverDetails", sqlParameterArray6, True))
						CommercialQuoteDataModel.logger.Debug(String.Concat("Saved Driver Details...row ", Conversions.ToString(j)))
						CommercialQuoteDataModel.logger.Debug(String.Concat("Saving DriverTicket Details...row ", Conversions.ToString(j)))
						Dim sqlParameterArray7(2) As System.Data.SqlClient.SqlParameter
						If (Not Information.IsNothing(DirectCast(objDrivers.Item(j), Driver).DrverTickets)) Then
							Try
								enumerator = DirectCast(objDrivers.Item(j), Driver).DrverTickets.GetEnumerator()
								While enumerator.MoveNext()
									Dim current As DriverTicket = DirectCast(enumerator.Current, DriverTicket)
									CommercialQuoteDataModel.logger.Debug("submitting DriverTicket Details...for saving to transaction")
									sqlParameter = New System.Data.SqlClient.SqlParameter() With
									{
										.ParameterName = "@intPId",
										.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(current), 0, current.Id)),
										.DbType = DbType.Int32
									}
									sqlParameterArray7(0) = sqlParameter
									sqlParameter = New System.Data.SqlClient.SqlParameter() With
									{
										.ParameterName = "@intDriverID",
										.Value = Integer.Parse(Conversions.ToString(integer1)),
										.DbType = DbType.[String]
									}
									sqlParameterArray7(1) = sqlParameter
									sqlParameter = New System.Data.SqlClient.SqlParameter() With
									{
										.ParameterName = "@vchrTicketDetails",
										.Value = current.TicketDetails,
										.DbType = DbType.[String]
									}
									sqlParameterArray7(2) = sqlParameter
									num = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_TransportDriverTickets", sqlParameterArray7, True))
									CommercialQuoteDataModel.logger.Debug("submitted DriverTicket Details...for saving to transaction")
								End While
							Finally
								If (TypeOf enumerator Is IDisposable) Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
						End If
					Next

				End If
				str = Conversions.ToString([integer])
				dataAccessModel.CommitTransaction()
				dataAccessModel.CloseConnection()
				CommercialQuoteDataModel.logger.Debug("Exiting CommercialQuoteDataModel.Save")
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				CommercialQuoteDataModel.logger.[Error]("Exception occurred while saving Commerical transportation Quote ", exception)
				CommercialQuoteDataModel.logger.[Error](String.Concat("Exception Details ", exception.StackTrace))
				Throw exception
			End Try
			Return str
		End Function
	End Class
End Namespace