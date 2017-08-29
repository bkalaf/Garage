Imports GarageQuoteSheetDLL.DAL
Imports log4net
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports XmlUtils

Namespace GarageQuoteSheetDLL
	Public Class GarageLookupDataModel
		Private xmlConfig As XmlUtils.XmlConfig

		Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"

		Private Const COMP_VBridge As String = "GarageQuoteSheet"

		Private Const CONTEXT As String = "GarageQuoteSheet"

		Private Shared logger As ILog

		Private type As System.Type

		Private methodInfo As System.Reflection.MethodInfo

		Shared Sub New()
			GarageLookupDataModel.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
		End Sub

		Public Sub New()
			MyBase.New()
			Me.xmlConfig = New XmlUtils.XmlConfig("GarageQuoteSheet", "GarageQuoteSheetXML.xml")
		End Sub

		Public Function getLookup(ByVal TypeID As String) As ICollection
			GarageLookupDataModel.logger.Debug("Entering GarageLookupDataModel.getLookup")
			Dim dataAccessModel As GarageQuoteSheetDLL.DAL.DataAccessModel = New GarageQuoteSheetDLL.DAL.DataAccessModel(Me.xmlConfig.GetComponentProperty("GarageQuoteSheet", "ConnectionString"), False)
			Dim sqlParameterArray(0) As System.Data.SqlClient.SqlParameter
			Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter() With
			{
				.ParameterName = "@intTypeID",
				.Value = TypeID
			}
			sqlParameterArray(0) = sqlParameter
			Dim dataSet As System.Data.DataSet = dataAccessModel.ReadDataSet("SIU_p_getGarageLookupDetails", sqlParameterArray, True)
			Return New DataView(dataSet.Tables(0))
		End Function
	End Class
End Namespace