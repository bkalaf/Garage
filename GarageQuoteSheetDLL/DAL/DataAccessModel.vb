Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Xml

Namespace GarageQuoteSheetDLL.DAL
	''' <summary>
	''' </summary>
	''' <remarks></remarks>
	Public Class DataAccessModel
		Private cmd As SqlCommand

		Private tr As SqlTransaction

		Private bUseTransaction As Boolean

		Private bOpenConnection As Boolean

		Private cnnString As String

		Private cnn As SqlConnection

		Public ReadOnly Property Command As SqlCommand
			Get
				Return Me.cmd
			End Get
		End Property

		Public ReadOnly Property Connection As SqlConnection
			Get
				Return Me.cnn
			End Get
		End Property

		Public Property ConnectionString As String
			Get
				Return Me.cnnString
			End Get
			Set(ByVal value As String)
				Me.cnnString = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.bUseTransaction = False
			Me.bOpenConnection = False
			Me.cnn = New SqlConnection()
			Me.cmd = New SqlCommand()
		End Sub

		Public Sub New(ByVal cnnString As String, Optional ByVal blnUseTransaction As Boolean = False)
			MyClass.New()
			Me.bUseTransaction = blnUseTransaction
			Me.cnnString = cnnString
			Me.OpenConnection()
		End Sub

		Public Sub CloseConnection()
			Me.cnn.Close()
			Me.bOpenConnection = False
		End Sub

		Public Function CommitTransaction() As Object
			Dim obj As Object
			If (Me.tr.Connection.State <> ConnectionState.Open) Then
				obj = False
			Else
				Me.tr.Commit()
				obj = True
			End If
			Return obj
		End Function

		Private Function ExecuteOperation(ByVal objDAC As DataAccessContainer, ByVal bConnected As Boolean) As Boolean
			Dim flag As Boolean = False
			If (bConnected) Then
				Me.cmd = Me.cnn.CreateCommand()
				objDAC.Connection = Me.cnn
				objDAC.Command = Me.cmd
				If (Me.bUseTransaction) Then
					objDAC.Command.Transaction = Me.tr
				End If
				Select Case objDAC.RowState
					Case DataRowState.Added
						flag = objDAC.Add()
						Exit Select
					Case DataRowState.Detached Or DataRowState.Added
					Case DataRowState.Unchanged Or DataRowState.Added
					Case DataRowState.Detached Or DataRowState.Unchanged Or DataRowState.Added
					Case DataRowState.Detached Or DataRowState.Deleted
					Case DataRowState.Unchanged Or DataRowState.Deleted
					Case DataRowState.Detached Or DataRowState.Unchanged Or DataRowState.Deleted
					Case DataRowState.Added Or DataRowState.Deleted
					Case DataRowState.Detached Or DataRowState.Added Or DataRowState.Deleted
					Case DataRowState.Unchanged Or DataRowState.Added Or DataRowState.Deleted
					Case DataRowState.Detached Or DataRowState.Unchanged Or DataRowState.Added Or DataRowState.Deleted
					Label0:
						Exit Select
					Case DataRowState.Deleted
						flag = objDAC.Delete()
						Exit Select
					Case DataRowState.Modified
						flag = objDAC.Edit()
						Exit Select
					Case Else
						GoTo Label0
				End Select
			End If
			Return flag
		End Function

		Public Function ExecuteOperation(ByVal objDAC As DataAccessContainer) As Boolean
			Dim flag As Boolean = False
			Try
				Try
					Me.OpenConnection()
					flag = Me.ExecuteOperation(objDAC, True)
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Throw exception
				End Try
			Finally
				Me.CloseConnection()
			End Try
			Return flag
		End Function

		Public Function ExecuteOperation(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean) As Boolean
			Dim num As Integer = -1
			Try
				Me.OpenConnection()
				Me.cmd.Connection = Me.cnn
				Me.cmd.CommandTimeout = 0
				Me.cmd.Parameters.Clear()
				If (parameters IsNot Nothing) Then
					Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
					Dim num1 As Integer = 0
					While num1 < CInt(sqlParameterArray.Length)
						Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num1)
						Me.cmd.Parameters.Add(sqlParameter)
						num1 = num1 + 1
					End While
				End If
				If (Not bIsSP) Then
					Me.cmd.CommandType = CommandType.Text
				Else
					Me.cmd.CommandType = CommandType.StoredProcedure
				End If
				Me.cmd.CommandTimeout = 0
				Me.cmd.CommandText = sql_OR_spName
				num = Me.cmd.ExecuteNonQuery()
				Me.CloseConnection()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Throw exception
			End Try
			Return num > 0
		End Function

		Public Function ExecuteOperations(ByVal arrObjectsDAC As ArrayList) As Boolean
			Dim flag As Boolean
			Dim enumerator As IEnumerator = Nothing
			Dim flag1 As Boolean = False
			Try
				Try
					Me.OpenConnection()
					Try
						enumerator = arrObjectsDAC.GetEnumerator()
						While enumerator.MoveNext()
							flag1 = Me.ExecuteOperation(DirectCast(enumerator.Current, DataAccessContainer), True)
							If (Not flag1) Then
								Me.CloseConnection()
								flag = False
								Return flag
							End If
						End While
					Finally
						If (TypeOf enumerator Is IDisposable) Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Throw exception
				End Try
			Finally
				Me.CloseConnection()
			End Try
			flag = flag1
			Return flag
		End Function

		Public Function ExecuteOperations(ByVal arrObjectsDAC As ArrayList, ByVal bUseTransaction As Boolean) As Boolean
			Dim flag As Boolean
			Dim enumerator As IEnumerator = Nothing
			Me.bUseTransaction = bUseTransaction
			If (bUseTransaction) Then
				Dim flag1 As Boolean = False
				Try
					Try
						Me.OpenConnection()
						Me.tr = Me.cnn.BeginTransaction(IsolationLevel.ReadCommitted, "ExecuteOperations")
						Try
							enumerator = arrObjectsDAC.GetEnumerator()
							While enumerator.MoveNext()
								flag1 = Me.ExecuteOperation(DirectCast(enumerator.Current, DataAccessContainer), True)
								If (Not flag1) Then
									Me.tr.Rollback("ExecuteOperations")
									Me.CloseConnection()
									flag = False
									Return flag
								End If
							End While
						Finally
							If (TypeOf enumerator Is IDisposable) Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.tr.Commit()
						bUseTransaction = False
					Catch exception2 As System.Exception
						ProjectData.SetProjectError(exception2)
						Dim exception As System.Exception = exception2
						Try
							Me.tr.Rollback("ExecuteOperations")
						Catch sqlException1 As System.Data.SqlClient.SqlException
							ProjectData.SetProjectError(sqlException1)
							Dim sqlException As System.Data.SqlClient.SqlException = sqlException1
							If (Me.tr.Connection IsNot Nothing) Then
								Throw sqlException
							End If
							ProjectData.ClearProjectError()
						Catch exception1 As System.Exception
							ProjectData.SetProjectError(exception1)
							Throw exception1
						End Try
						Throw exception
					End Try
				Finally
					bUseTransaction = False
					Me.CloseConnection()
				End Try
				flag = flag1
			Else
				flag = Me.ExecuteOperations(arrObjectsDAC)
			End If
			Return flag
		End Function

		Public Function ExecuteSP(ByVal spName As String, ByVal parameters As SqlParameter()) As Boolean
			Return Me.ExecuteOperation(spName, parameters, True)
		End Function

		Public Function ExecuteSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As Boolean
			Return Me.ExecuteOperation(sql, parameters, False)
		End Function

		Private Function ExecuteTransaction(ByVal objDAC As TransactionalContainer, ByVal bConnected As Boolean) As Boolean
			Dim flag As Boolean = False
			If (bConnected) Then
				Me.cmd.Connection = Me.cnn
				Me.cmd.CommandTimeout = 0
				Me.cmd.Transaction = Me.tr
				Me.cmd.Parameters.Clear()
				Dim params As System.Data.SqlClient.SqlParameter() = objDAC.Params
				If (params IsNot Nothing) Then
					Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = params
					Dim num As Integer = 0
					While num < CInt(sqlParameterArray.Length)
						Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
						Me.cmd.Parameters.Add(sqlParameter)
						num = num + 1
					End While
				End If
				If (Not objDAC.isSP) Then
					Me.cmd.CommandType = CommandType.Text
				Else
					Me.cmd.CommandType = CommandType.StoredProcedure
				End If
				Me.cmd.CommandTimeout = 0
				Me.cmd.CommandText = objDAC.sql_OR_spName
				flag = Me.cmd.ExecuteNonQuery() <> 0
			End If
			Return flag
		End Function

		Public Function ExecuteTransactionalOperation(ByVal arrObjectsDAC As ArrayList) As Boolean
			Dim flag As Boolean
			Dim enumerator As IEnumerator = Nothing
			Dim num As Integer = -1
			Try
				Try
					Try
						enumerator = arrObjectsDAC.GetEnumerator()
						While enumerator.MoveNext()
							Dim current As TransactionalContainer = DirectCast(enumerator.Current, TransactionalContainer)
							num = -Me.ExecuteTransaction(current, True)
							If (Not num <> 0) Then
								Me.tr.Rollback("ExecuteOperations")
								Me.CloseConnection()
								flag = False
								Return flag
							End If
						End While
					Finally
						If (TypeOf enumerator Is IDisposable) Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.tr.Commit()
					Me.bUseTransaction = False
				Catch exception2 As System.Exception
					ProjectData.SetProjectError(exception2)
					Dim exception As System.Exception = exception2
					Try
						Me.tr.Rollback("ExecuteOperations")
					Catch sqlException1 As System.Data.SqlClient.SqlException
						ProjectData.SetProjectError(sqlException1)
						Dim sqlException As System.Data.SqlClient.SqlException = sqlException1
						If (Me.tr.Connection IsNot Nothing) Then
							Throw sqlException
						End If
						ProjectData.ClearProjectError()
					Catch exception1 As System.Exception
						ProjectData.SetProjectError(exception1)
						Throw exception1
					End Try
					Throw exception
				End Try
			Finally
				Me.bUseTransaction = False
				Me.CloseConnection()
			End Try
			flag = num <> 0
			Return flag
		End Function

		Public Function GetValue(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean, ByVal blnUseTransaction As Boolean) As Object
			If (Not Me.bOpenConnection) Then
				Me.OpenConnection()
			End If
			Me.cmd.Connection = Me.cnn
			If (Me.bUseTransaction) Then
				Me.cmd.Transaction = Me.tr
			End If
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			Me.cmd.CommandTimeout = 0
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandText = sql_OR_spName
			Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.cmd.ExecuteScalar())
			If (Not blnUseTransaction) Then
				Me.CloseConnection()
			End If
			Return objectValue
		End Function

		Public Function GetValue(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean) As Object
			Me.OpenConnection()
			Me.cmd.Connection = Me.cnn
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			Me.cmd.CommandTimeout = 0
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandText = sql_OR_spName
			Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.cmd.ExecuteScalar())
			Me.CloseConnection()
			Return objectValue
		End Function

		Public Function GetValueSP(ByVal spName As String, ByVal parameters As SqlParameter(), ByVal blnUseTransaction As Boolean) As Object
			Return Me.GetValue(spName, parameters, True, blnUseTransaction)
		End Function

		Public Function GetValueSP(ByVal spName As String, ByVal parameters As SqlParameter()) As Object
			Return Me.GetValue(spName, parameters, True)
		End Function

		Public Function GetValueSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As Object
			Return Me.GetValue(sql, parameters, False)
		End Function

		Public Sub OpenConnection()
			If (Not Me.bOpenConnection) Then
				Me.cnn = New SqlConnection(Me.cnnString)
				Me.cnn.Open()
				If (Me.bUseTransaction) Then
					Me.tr = Me.cnn.BeginTransaction(IsolationLevel.ReadCommitted, "ExecuteOperations")
				End If
				Me.bOpenConnection = True
			End If
		End Sub

		Public Sub OpenConnection(ByVal bForce As Boolean)
			If (bForce) Then
				Me.bOpenConnection = False
			End If
			Me.OpenConnection()
		End Sub

		Public Function Read(ByVal objDAC As DataAccessContainer) As Boolean
			objDAC.Connection = Me.cnn
			objDAC.Command = Me.cmd
			Return objDAC.Read()
		End Function

		Public Function Read(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean) As System.Data.SqlClient.SqlDataReader
			Me.OpenConnection()
			Me.cmd.Connection = Me.cnn
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			Me.cmd.CommandTimeout = 0
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandText = sql_OR_spName
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = Me.cmd.ExecuteReader()
			Me.CloseConnection()
			Return sqlDataReader
		End Function

		Public Function ReadDataSet(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean) As System.Data.DataSet
			Me.OpenConnection()
			Me.cmd.Connection = Me.cnn
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandTimeout = 0
			Me.cmd.CommandText = sql_OR_spName
			Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter() With
			{
				.SelectCommand = Me.cmd
			}
			Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
			sqlDataAdapter.Fill(dataSet)
			Me.CloseConnection()
			Return dataSet
		End Function

		Public Function ReadDataSetSP(ByVal spName As String, ByVal parameters As SqlParameter()) As DataSet
			Return Me.ReadDataSet(spName, parameters, True)
		End Function

		Public Function ReadDataSetSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As DataSet
			Return Me.ReadDataSet(sql, parameters, False)
		End Function

		Public Function ReadDataTable(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean) As System.Data.DataTable
			Me.OpenConnection()
			Me.cmd.Connection = Me.cnn
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandTimeout = 0
			Me.cmd.CommandText = sql_OR_spName
			Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter() With
			{
				.SelectCommand = Me.cmd
			}
			Dim dataTable As System.Data.DataTable = New System.Data.DataTable()
			sqlDataAdapter.Fill(dataTable)
			Me.CloseConnection()
			Return dataTable
		End Function

		Public Function ReadDataTableSP(ByVal spName As String, ByVal parameters As SqlParameter()) As DataTable
			Return Me.ReadDataTable(spName, parameters, True)
		End Function

		Public Function ReadDataTableSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As DataTable
			Return Me.ReadDataTable(sql, parameters, False)
		End Function

		Public Function ReadSP(ByVal spName As String, ByVal parameters As SqlParameter()) As SqlDataReader
			Return Me.Read(spName, parameters, True)
		End Function

		Public Function ReadSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As SqlDataReader
			Return Me.Read(sql, parameters, False)
		End Function

		Public Function ReadXml(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean, ByVal documentElementName As String) As System.Xml.XmlDocument
			Me.OpenConnection()
			Me.cmd.Connection = Me.cnn
			Me.cmd.Parameters.Clear()
			If (parameters IsNot Nothing) Then
				Dim sqlParameterArray As System.Data.SqlClient.SqlParameter() = parameters
				Dim num As Integer = 0
				While num < CInt(sqlParameterArray.Length)
					Dim sqlParameter As System.Data.SqlClient.SqlParameter = sqlParameterArray(num)
					Me.cmd.Parameters.Add(sqlParameter)
					num = num + 1
				End While
			End If
			If (Not bIsSP) Then
				Me.cmd.CommandType = CommandType.Text
			Else
				Me.cmd.CommandType = CommandType.StoredProcedure
			End If
			Me.cmd.CommandTimeout = 0
			Me.cmd.CommandText = sql_OR_spName
			Dim xmlReader As System.Xml.XmlReader = Me.cmd.ExecuteXmlReader()
			Dim xmlDocument As System.Xml.XmlDocument = New System.Xml.XmlDocument()
			Dim empty As String = String.Empty
			Dim num1 As Integer = 0
			Dim str As String = String.Empty
			xmlReader.Read()
			While Not xmlReader.EOF
				empty = String.Concat(empty, xmlReader.ReadOuterXml())
				num1 = num1 + 1
			End While
			If (num1 <> 1) Then
				Dim strArrays() As String = { "<", documentElementName, ">", empty, "</", documentElementName, ">" }
				empty = String.Concat(strArrays)
			End If
			xmlDocument.LoadXml(empty)
			Me.CloseConnection()
			Return xmlDocument
		End Function

		Public Function ReadXmlSP(ByVal spName As String, ByVal parameters As SqlParameter(), ByVal documentElementName As String) As XmlDocument
			Return Me.ReadXml(spName, parameters, True, documentElementName)
		End Function

		Public Function ReadXmlSP(ByVal spName As String, ByVal parameters As SqlParameter()) As XmlDocument
			Return Me.ReadXml(spName, parameters, True, "root")
		End Function

		Public Function ReadXmlSQL(ByVal sql As String, ByVal parameters As SqlParameter(), ByVal documentElementName As String) As XmlDocument
			Return Me.ReadXml(sql, parameters, False, documentElementName)
		End Function

		Public Function ReadXmlSQL(ByVal sql As String, ByVal parameters As SqlParameter()) As XmlDocument
			Return Me.ReadXml(sql, parameters, False, "root")
		End Function
	End Class
End Namespace