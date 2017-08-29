Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace GarageQuoteSheetDLL.DAL
	Public Class DataAccessContainer
		Private xRowState As DataRowState

		Private xTableName As String

		Private xAutoIncrement As Boolean

		Protected cmd As SqlCommand

		Protected cnn As SqlConnection

		Public Property AutoIncrement As Boolean
			Get
				Return Me.xAutoIncrement
			End Get
			Set(ByVal value As Boolean)
				Me.xAutoIncrement = value
			End Set
		End Property

		Public Property Command As SqlCommand
			Get
				Return Me.cmd
			End Get
			Set(ByVal value As SqlCommand)
				Me.cmd = value
			End Set
		End Property

		Public Property Connection As SqlConnection
			Get
				Return Me.cnn
			End Get
			Set(ByVal value As SqlConnection)
				Me.cnn = value
			End Set
		End Property

		Public Property RowState As DataRowState
			Get
				Return Me.xRowState
			End Get
			Set(ByVal value As DataRowState)
				Me.xRowState = value
			End Set
		End Property

		Public Property TableName As String
			Get
				Return Me.xTableName
			End Get
			Set(ByVal value As String)
				Me.xTableName = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.xRowState = DataRowState.Unchanged
			Me.xTableName = String.Empty
			Me.xAutoIncrement = False
		End Sub

		Public Overridable Function Add() As Boolean
			Return True
		End Function

		Public Function CommitTransaction(ByVal sqlTran As SqlTransaction) As Boolean
			Dim flag As Boolean
			Try
				sqlTran.Commit()
				sqlTran.Connection.Close()
				flag = True
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				flag = False
				ProjectData.ClearProjectError()
			End Try
			Return flag
		End Function

		Public Overridable Function Delete() As Boolean
			Return True
		End Function

		Public Overridable Function Edit() As Boolean
			Return True
		End Function

		Public Function ExecuteOperation(ByVal sql_OR_spName As String, ByVal parameters As System.Data.SqlClient.SqlParameter(), ByVal bIsSP As Boolean, ByVal conn As SqlConnection, ByVal sqlTran As SqlTransaction) As Boolean
			Dim num As Integer = -1
			Try
				Me.cmd.Connection = conn
				Me.cmd.CommandTimeout = 0
				Me.cmd.Parameters.Clear()
				Me.cmd.Transaction = sqlTran
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
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Throw exception
			End Try
			Return num > 0
		End Function

		Public Function GetNextID() As Integer
			Dim [integer] As Integer
			Try
				Me.cmd.Connection = Me.cnn
				Me.cmd.CommandText = "GET_NEXT_ID"
				Me.cmd.CommandType = CommandType.StoredProcedure
				Me.cmd.Parameters.Clear()
				Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@TableName", SqlDbType.VarChar, 255) With
				{
					.Value = Me.xTableName
				}
				Me.cmd.Parameters.Add(sqlParameter)
				sqlParameter = New System.Data.SqlClient.SqlParameter("@LastKey", SqlDbType.Int) With
				{
					.Direction = ParameterDirection.Output
				}
				Me.cmd.Parameters.Add(sqlParameter)
				Me.cmd.ExecuteNonQuery()
				[integer] = Conversions.ToInteger(sqlParameter.Value)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Throw exception
			End Try
			Return [integer]
		End Function

		Public Overridable Function Read() As Boolean
			Return True
		End Function

		Public Function RollBackTransaction(ByVal sqlTran As SqlTransaction) As Boolean
			Dim flag As Boolean
			Try
				sqlTran.Rollback()
				sqlTran.Connection.Close()
				flag = True
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				flag = False
				ProjectData.ClearProjectError()
			End Try
			Return flag
		End Function
	End Class
End Namespace