Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class VehicleDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			VehicleDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
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

		Private Function GetCommercialVehicleDetails(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			VehicleDataModel.logger.Debug("Exiting VehicledataModel.GetCommercialVehicleDetails")
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
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetVehicleDetailsByQuoteId", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim vehicle As GarageQuoteSheetDLL.Vehicle = New GarageQuoteSheetDLL.Vehicle() With
					{
						.Id = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("Id_Pk").ToString()),
						.Make = dataSet.Tables(0).Rows(i)("Make").ToString(),
						.Year = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("VehicleYear").ToString()),
						.VehicleType = dataSet.Tables(0).Rows(i)("Type").ToString(),
						.GVW = dataSet.Tables(0).Rows(i)("GVW").ToString(),
						.StatedValue = dataSet.Tables(0).Rows(i)("StatedValue").ToString(),
						.Deductible = dataSet.Tables(0).Rows(i)("Deductible").ToString()
					}
					genericCollection.Add(vehicle)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				VehicleDataModel.logger.[Error](String.Concat("Exception occurred while fetching VehicleDetails for QuoteId :", pstrQuoteId), exception)
				VehicleDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			VehicleDataModel.logger.Debug("Exiting VehicledataModel.GetCommercialVehicleDetails")
			Return genericCollection
		End Function

		Public Function GetData(ByVal pstrQuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialVehicleDetails As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				commercialVehicleDetails = Me.GetCommercialVehicleDetails(pstrQuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				commercialVehicleDetails = New GenericCollection(Of IEntity)()
			End If
			Return commercialVehicleDetails
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