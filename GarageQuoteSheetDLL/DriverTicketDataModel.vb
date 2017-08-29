Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class DriverTicketDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			DriverTicketDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		<Obsolete("Not Implemented")>
		Public Function Delete(ByVal strDriverId As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Public Function GetData(ByVal pstrDriverId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim driverTickets As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				driverTickets = Me.GetDriverTickets(pstrDriverId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				driverTickets = New GenericCollection(Of IEntity)()
			End If
			Return driverTickets
		End Function

		Private Function GetDriverTickets(ByVal pstrDriverId As String) As GenericCollection(Of IEntity)
			DriverTicketDataModel.logger.Debug("Entering DriverTicketDataModel.GetData")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Try
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intDriverId",
					.Value = pstrDriverId
				}
				sqlParameterArray(0) = sqlParameter
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetDriverTicketsByDriverId", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				For i As Integer = 0 To count
					Dim driverTicket As GarageQuoteSheetDLL.DriverTicket = New GarageQuoteSheetDLL.DriverTicket() With
					{
						.Id = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("Id_Pk").ToString()),
						.TicketDetails = dataSet.Tables(0).Rows(i)("Accident_ticket").ToString(),
						.DriverId = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("DriverId_Fk").ToString())
					}
					genericCollection.Add(driverTicket)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				DriverTicketDataModel.logger.[Error](String.Concat("Exception occurred while fetcjhing DriverTicketDetails for QuoteId :", pstrDriverId), exception)
				DriverTicketDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			DriverTicketDataModel.logger.Debug("Exiting DriverTicketDataModel.GetData")
			Return genericCollection
		End Function

		<Obsolete("Not Implemented")>
		Public Function Save(ByVal objDriverTickets As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim num As Integer = 0
			Return num
		End Function

		<Obsolete("Not Implemented")>
		Public Function Update(ByVal objDriverTickets As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace