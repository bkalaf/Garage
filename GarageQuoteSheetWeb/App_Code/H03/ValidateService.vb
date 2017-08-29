Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Net
Imports System
Imports System.Text

Public Class ValidateService
#Region "Function IsServiceRunning to check the service status"
    ''' <summary>
    ''' Validate Whether WebService is running Or Not
    ''' </summary>
    ''' <param name="_serviceName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsServiceRunning(ByVal _serviceName As String) As Boolean
        Dim _serviceUP As Boolean = False
        Dim _serviceURL As String = String.Empty

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        _serviceURL = ConfigurationManager.AppSettings(_serviceName).Trim()

        Try
            Dim respBody As New StringBuilder()
            request = DirectCast(WebRequest.Create(_serviceURL), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            If response.StatusCode.ToString() = "OK" Then
                _serviceUP = True
            End If
            response.Close()
        Catch ex As Exception
            _serviceUP = False
            'throw (ex); 
        Finally
            response = Nothing
            request = Nothing
        End Try
        Return _serviceUP
    End Function
#End Region
End Class
