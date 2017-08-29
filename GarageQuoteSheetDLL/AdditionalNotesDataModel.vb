Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class AdditionalNotesDataModel
		Implements IDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Shared Sub New()
			AdditionalNotesDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function Delete(ByVal pv_QuoteNo As String) As Boolean Implements IDataModel.Delete
			Dim flag As Boolean = False
			Return flag
		End Function

		Private Function GetCommercialAdditionNotes(ByVal pstrQuoteId As String) As GenericCollection(Of IEntity)
			AdditionalNotesDataModel.logger.Debug("Entering GarageQuoteDataModel.GetCommercialAdditionNotes")
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
					Dim additionNote As AdditionNotes = New AdditionNotes() With
					{
						.AdditionalNotes = dataSet.Tables(0).Rows(i)("AdditionalNotes").ToString(),
						.QuoteId = Conversions.ToInteger(dataSet.Tables(0).Rows(i)("GarageQuoteID").ToString())
					}
					genericCollection.Add(additionNote)
				Next

			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				AdditionalNotesDataModel.logger.[Error](String.Concat("Exception occurred while fetcjhing Quote-Agency details for QuoteId :", pstrQuoteId), exception)
				AdditionalNotesDataModel.logger.[Error](String.Concat("Exception Details :", exception.StackTrace))
				Throw exception
			End Try
			AdditionalNotesDataModel.logger.Debug("Exiting GarageQuoteDataModel.GetCommercialAdditionNotes")
			Return genericCollection
		End Function

		Public Function GetData(ByVal pstrQuoteId As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity) Implements IDataModel.GetData
			Dim commercialAdditionNotes As GenericCollection(Of IEntity) = Nothing
			Dim str As String = pstrQuoteType
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
				commercialAdditionNotes = Me.GetCommercialAdditionNotes(pstrQuoteId)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) <> 0) Then
				commercialAdditionNotes = New GenericCollection(Of IEntity)()
			End If
			Return commercialAdditionNotes
		End Function

		Public Function Save(ByVal pobjGarageQuote As GenericCollection(Of IEntity)) As Integer Implements IDataModel.Save
			Dim num As Integer = 0
			Return num
		End Function

		Public Function Update(ByVal pobjGarageQuote As GenericCollection(Of IEntity)) As Boolean Implements IDataModel.Update
			Dim flag As Boolean = False
			Return flag
		End Function
	End Class
End Namespace