Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class DriverDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			DriverDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
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

		Public Function GetCommercialDriverDetails(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			Dim driver As GarageQuoteSheetDLL.Driver
			Dim current As DriverTicket
			Dim enumerator As IEnumerator = Nothing
			DriverDataModel.logger.Debug("Entering DriverDataModel.GetCommercialDriverDetails")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim genericCollection As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Dim data As GenericCollection(Of IEntity) = New GenericCollection(Of IEntity)()
			Dim genericCollection1 As GenericCollection(Of DriverTicket) = New GenericCollection(Of DriverTicket)()
			Dim driverTicketDataModel As GarageQuoteSheetDLL.DriverTicketDataModel = New GarageQuoteSheetDLL.DriverTicketDataModel()
			Try
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
				{
					.ParameterName = "@intQuoteId",
					.Value = pstrQuoteId
				}
				sqlParameterArray(0) = sqlParameter
				Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_GetDriverDetailsByQuoteId", sqlParameterArray, True)
				Dim count As Integer = dataSet.Tables(0).Rows.Count - 1
				Dim num As Integer = 0
				Do
					driver = New GarageQuoteSheetDLL.Driver() With
					{
						.Name = dataSet.Tables(0).Rows(num)("DriverName").ToString(),
						.HireDate = Convert.ToDateTime(dataSet.Tables(0).Rows(num)("HireDate").ToString()),
						.DOB = Convert.ToDateTime(dataSet.Tables(0).Rows(num)("DOB").ToString()),
						.YearsExperience = Convert.ToInt32(dataSet.Tables(0).Rows(num)("YrsExperience").ToString()),
						.Id = Convert.ToInt32(dataSet.Tables(0).Rows(num)("Id_pk").ToString())
					}
					data = driverTicketDataModel.GetData(Conversions.ToString(driver.Id), Conversions.ToString(1))
					genericCollection1 = New GenericCollection(Of DriverTicket)()
					Try
						enumerator = data.GetEnumerator()
						While enumerator.MoveNext()
							current = DirectCast(enumerator.Current, DriverTicket)
							genericCollection1.Add(current)
						End While
					Finally
						If (TypeOf enumerator Is IDisposable) Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					driver.DrverTickets = genericCollection1
					genericCollection.Add(driver)
					num = num + 1
				Loop While num <= count
				driver = Nothing
				current = Nothing
				genericCollection1 = Nothing
				data = Nothing
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				DriverDataModel.logger.[Error](String.Concat("Exception occurred while fetching Driver details for QuoteId :", pstrQuoteId), exception)
				DriverDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				ProjectData.ClearProjectError()
			End Try
			DriverDataModel.logger.Debug("Exiting DriverDataModel.GetCommercialDriverDetails")
			Return genericCollection
		End Function

		Public Function GetData(ByVal pstrQuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialDriverDetails As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				commercialDriverDetails = Me.GetCommercialDriverDetails(pstrQuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				commercialDriverDetails = New GenericCollection(Of IEntity)()
			End If
			Return commercialDriverDetails
		End Function

		<Obsolete("Not Implemented")>
		Public Function Save(ByVal objDrivers As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim num As Integer = 0
			Return num
		End Function

		<Obsolete("Not Implemented")>
		Public Function Update(ByVal objDrivers As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace