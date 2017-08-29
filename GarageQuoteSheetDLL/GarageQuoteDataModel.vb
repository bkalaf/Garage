Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageQuoteDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			GarageQuoteDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function CheckStateforGarage(ByVal pv_strStateCode As String) As Boolean
			Dim flag As Boolean
			Dim flag1 As Boolean
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Try
				GarageQuoteDataModel.logger.Debug("Entering GarageQuoteDataModel.CheckStateforGarage")
				Dim sqlParameterArray(1) As System.Data.SqlClient.SqlParameter
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteTypeID",
					.Value = 1
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
				GarageQuoteDataModel.logger.[Error]("Exception occurred while checking state for GarageQuote: ", exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception Details", exception.StackTrace))
				Throw New System.Exception("Exception occurred while validating state")
			End Try
			Return flag1
		End Function

		Public Function Delete(ByVal pv_QuoteNo As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Private Function GetCommercialQuoteDetails(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			GarageQuoteDataModel.logger.Debug("Entering GarageQuoteDataModel.GetCommercialQuoteDetails")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Try
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteId",
					.Value = pstrQuoteId
				}
				sqlParameterArray(0) = sqlParameter
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetCommercialTransQuoteDetails", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim garageQuote As GarageQuoteSheetDLL.GarageQuote = New GarageQuoteSheetDLL.GarageQuote() With
					{
						.GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("GarageQuoteID").ToString()),
						.GarageQuoteNumber = dataSet.Tables(0).Rows(i)("GarageQuoteNumber").ToString(),
						.AgentID = dataSet.Tables(0).Rows(i)("AgentId").ToString(),
						.Contact = dataSet.Tables(0).Rows(i)("Contact").ToString(),
						.Phone = dataSet.Tables(0).Rows(i)("Phone").ToString(),
						.Fax = dataSet.Tables(0).Rows(i)("Fax").ToString(),
						.Email = dataSet.Tables(0).Rows(i)("Email").ToString(),
						.CreatedORModifiedBY = dataSet.Tables(0).Rows(i)("CreatedBy").ToString(),
						.CreatedORModifiedDate = Conversions.ToDate(dataSet.Tables(0).Rows(i)("CreatedDate").ToString()),
						.AdditionalNotes = dataSet.Tables(0).Rows(i)("AdditionalNotes").ToString(),
						.ParentQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("ParentQuoteID").ToString()),
						.UnderwriterName = dataSet.Tables(0).Rows(i)("UnderwriterName").ToString(),
						.UnderwriterEmail = dataSet.Tables(0).Rows(i)("UnderwriterEmail").ToString()
					}
					genericCollection.Add(garageQuote)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception occurred while fetcjhing Quote-Agency details for QuoteId :", pstrQuoteId), exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				Throw exception
			End Try
			GarageQuoteDataModel.logger.Debug("Exiting GarageQuoteDataModel.GetCommercialQuoteDetails")
			Return genericCollection
		End Function

		Public Function GetData(ByVal pstrQuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialQuoteDetails As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				commercialQuoteDetails = Me.GetCommercialQuoteDetails(pstrQuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				commercialQuoteDetails = New GenericCollection(Of IEntity)() From
				{
					Me.getGarageQuoteDetails(pstrQuoteId)
				}
			End If
			Return commercialQuoteDetails
		End Function

		Private Function getGarageQuoteDetails(ByVal pv_QuoteID As String) As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteNo",
				.Value = Me.getGarageQuoteNo(pv_QuoteID)
			}
			sqlParameterArray(0) = sqlParameter
			Dim garageQuote As IEntity = New GarageQuoteSheetDLL.GarageQuote()
			Try
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getGarageQuoteDetails", sqlParameterArray, True)
				If (dataSet.Tables(0).Rows.Count > 0) Then
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).AgentID = dataSet.Tables(0).Rows(0)("AgentID").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ApplicantName = dataSet.Tables(0).Rows(0)("ApplicantName").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Contact = dataSet.Tables(0).Rows(0)("Contact").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).County = dataSet.Tables(0).Rows(0)("County").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Email = dataSet.Tables(0).Rows(0)("Email").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Fax = dataSet.Tables(0).Rows(0)("Fax").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID").ToString())
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).GarageQuoteNumber = dataSet.Tables(0).Rows(0)("GarageQuoteNumber").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Phone = dataSet.Tables(0).Rows(0)("Phone").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).State = dataSet.Tables(0).Rows(0)("State").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ZIP = dataSet.Tables(0).Rows(0)("ZipCode").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).TradeName = dataSet.Tables(0).Rows(0)("TradeName").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).AdditionalNotes = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("AdditionalNotes"))), "", dataSet.Tables(0).Rows(0)("AdditionalNotes").ToString()))
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ParentQuoteID = Conversions.ToInteger(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("ParentQuoteID"))), 0, dataSet.Tables(0).Rows(0)("ParentQuoteID").ToString()))
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).UnderwriterName = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("UnderwriterName"))), 0, dataSet.Tables(0).Rows(0)("UnderwriterName").ToString()))
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).UnderwriterEmail = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("UnderwriterEmail"))), 0, dataSet.Tables(0).Rows(0)("UnderwriterEmail").ToString()))
				End If
				If (dataSet.Tables(1).Rows.Count > 0) Then
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ParentQuoteNumber = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(1).Rows(0)("ParentQuoteNumber"))), 0, dataSet.Tables(1).Rows(0)("ParentQuoteNumber").ToString()))
				End If
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageQuoteDataModel.logger.[Error]("Exception occurred :", exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception details ", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			Return garageQuote
		End Function

		Public Function getGarageQuoteNo(ByVal pv_QuoteID As String) As String
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@GarageQuoteID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			Dim empty As String = String.Empty
			Try
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getGarageQuoteNumber", sqlParameterArray, True)
				If (dataSet.Tables(0).Rows.Count > 0) Then
					empty = Conversions.ToString(dataSet.Tables(0).Rows(0)("GarageQuoteNumber"))
				End If
				dataSet.Dispose()
				dataSet = Nothing
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageQuoteDataModel.logger.[Error]("Exception occurred :", exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception details ", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			Return empty
		End Function

		Public Function GetQuoteDetailsByQuoteId(ByVal strQuoteID As String, Optional ByVal strQuoteType As String = "") As IEntity
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(1) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intQuoteId",
				.DbType = DbType.Int32,
				.Value = strQuoteID
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intQuoteType",
				.DbType = DbType.Int32,
				.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strQuoteType, "", False) = 0, DBNull.Value, strQuoteType))
			}
			sqlParameterArray(1) = sqlParameter
			Dim garageQuote As IEntity = New GarageQuoteSheetDLL.GarageQuote()
			Try
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getQuoteDetailsByQuoteID", sqlParameterArray, True)
				If (dataSet.Tables(0).Rows.Count > 0) Then
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).AgentID = dataSet.Tables(0).Rows(0)("AgentID").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ApplicantName = dataSet.Tables(0).Rows(0)("ApplicantName").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Contact = dataSet.Tables(0).Rows(0)("Contact").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Email = dataSet.Tables(0).Rows(0)("Email").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Fax = dataSet.Tables(0).Rows(0)("Fax").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).GarageQuoteID = Conversions.ToInteger(dataSet.Tables(0).Rows(0)("GarageQuoteID").ToString())
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).GarageQuoteNumber = dataSet.Tables(0).Rows(0)("GarageQuoteNumber").ToString()
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).AdditionalNotes = Conversions.ToString(Interaction.IIf(Information.IsNothing(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("AdditionalNotes"))), "", dataSet.Tables(0).Rows(0)("AdditionalNotes").ToString()))
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).ParentQuoteID = Conversions.ToInteger(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("ParentQuoteID"))), 0, dataSet.Tables(0).Rows(0)("ParentQuoteID").ToString()))
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).UnderwriterEmail = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("UnderwriterEmail"))), "", dataSet.Tables(0).Rows(0)("UnderwriterEmail").ToString()))
					Dim garageOperation As GarageOperations = New GarageOperations() With
					{
						.BusinessName = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.Tables(0).Rows(0)("BusinessName"))), "", dataSet.Tables(0).Rows(0)("BusinessName").ToString()))
					}
					DirectCast(garageQuote, GarageQuoteSheetDLL.GarageQuote).Garageoperation = garageOperation
				End If
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageQuoteDataModel.logger.[Error]("Exception occurred :", exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception details ", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			Return garageQuote
		End Function

		Public Function Save(ByVal pobjGarageQuote As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim [integer] As Integer = 0
			Try
				Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
				Dim sqlParameterArray(16) As System.Data.SqlClient.SqlParameter
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intPQuoteId",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).GarageQuoteID
				}
				sqlParameterArray(0) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrQuoteNumber",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).GarageQuoteNumber
				}
				sqlParameterArray(1) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrAgentID",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).AgentID
				}
				sqlParameterArray(2) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrApplicantName",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).ApplicantName
				}
				sqlParameterArray(3) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrTradeName",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).TradeName
				}
				sqlParameterArray(4) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrContact",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).Contact
				}
				sqlParameterArray(5) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrPhone",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).Phone
				}
				sqlParameterArray(6) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCounty",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).County
				}
				sqlParameterArray(7) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrState",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).State
				}
				sqlParameterArray(8) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrFax",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).Fax
				}
				sqlParameterArray(9) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrEmail",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).Email
				}
				sqlParameterArray(10) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@AddNotes",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).AdditionalNotes
				}
				sqlParameterArray(11) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrCreatedORModifiedBY",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).CreatedORModifiedBY
				}
				sqlParameterArray(12) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intParentQuoteID",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).ParentQuoteID
				}
				sqlParameterArray(13) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrZIPCode",
					.Value = DirectCast(pobjGarageQuote.Item(0), GarageQuote).ZIP
				}
				sqlParameterArray(14) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrUnderwriterName",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(pobjGarageQuote.Item(0), GarageQuote).UnderwriterName), "", DirectCast(pobjGarageQuote.Item(0), GarageQuote).UnderwriterName)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(15) = sqlParameter
				sqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@vchrUnderwriterEmail",
					.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsNothing(DirectCast(pobjGarageQuote.Item(0), GarageQuote).UnderwriterEmail), "", DirectCast(pobjGarageQuote.Item(0), GarageQuote).UnderwriterEmail)),
					.DbType = DbType.[String]
				}
				sqlParameterArray(16) = sqlParameter
				[integer] = Conversions.ToInteger(dataAccessModel.GetValueSP("SIU_P_InsertUpdate_GarageQuotes", sqlParameterArray))
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				GarageQuoteDataModel.logger.[Error]("Exception occurred :", exception)
				GarageQuoteDataModel.logger.[Error](String.Concat("Exception details ", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			Return [integer]
		End Function

		Public Function searchQuoteDetails(ByVal pv_QuoteID As String, Optional ByVal pv_quoteType As String = "", Optional ByVal pv_daysBefore As Integer = -1) As ICollection
			Dim dataSet As System.Data.DataSet
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(1) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intAgentID",
				.Value = pv_QuoteID
			}
			sqlParameterArray(0) = sqlParameter
			sqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@DaysBefore",
				.Value = pv_daysBefore
			}
			sqlParameterArray(1) = sqlParameter
			Dim pvQuoteType As String = pv_quoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(pvQuoteType, "1", False) <> 0) Then
				dataSet = If(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(pvQuoteType, "2", False) <> 0, dataAccessModel.ReadDataSet("SIU_p_searchGarageQuoteDetails", sqlParameterArray, True), dataAccessModel.ReadDataSet("SIU_p_searchGarageQuoteDetails", sqlParameterArray, True))
			Else
				dataSet = dataAccessModel.ReadDataSet("SIU_p_searchCommercialTransQuotesByAgentID", sqlParameterArray, True)
			End If
			Return New DataView(dataSet.Tables(0))
		End Function

		Public Function Update(ByVal pobjGarageQuote As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace