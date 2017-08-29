Imports UserControls947
Imports log4net
Imports System.Collections
Imports System.Collections.Specialized

Partial Class _Default
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_AgentLogin As String = "AgentLogin"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

Page.MaintainScrollPositionOnPostBack = True


        'check whether user comes from authenticated source

        If Len(Trim(Request.QueryString("USR"))) > 0 And Len(Trim(Request.QueryString("PW"))) > 0 And Len(Trim(Request.QueryString("LOGIN_ID"))) > 0 And Len(Trim(Request.QueryString("LOGIN_TYPE"))) > 0 And Len(Trim(Request.QueryString("TAG"))) > 0 Then
            Session("USR") = Trim(Request.QueryString("USR"))
            Session("PW") = Trim(Request.QueryString("PW"))
            Session("LOGIN_ID") = Trim(Request.QueryString("LOGIN_ID"))
            Session("LOGIN_TYPE") = Trim(Request.QueryString("LOGIN_TYPE"))
            Session("TAG") = Trim(Request.QueryString("TAG"))
        End If

        Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
        Dim oAgent As GarageQuoteSheetDLL.Agent
        Dim controls As Collection
        'Dim cnt As Microsoft.VisualBasic.Collection.KeyValuePair()
        'Response.Write(IpAddress())
        controls = xmlConfig.GetComponentPropertyCollection("AgentLoginControls")
        If controls.Contains("Header").ToString = "True" Then
            Dim uc As UserControls947.HeaderControl = DirectCast(Page.LoadControl("UserControls/HeaderControl.ascx"), UserControls947.HeaderControl)
            'accessing the user control header property dynamically 
            uc.Title = "Agent Login"
            HeaderPh.Controls.Add(uc)

        Else
        End If
        If controls.Contains("Login").ToString = "True" Then
            Dim LoginControl As Control = LoadControl("UserControls/LoginControl.ascx")
            LoginPh.Controls.Add(LoginControl)
        Else

        End If
        If controls.Contains("Footer").ToString = "True" Then
            Dim FooterControl As Control = LoadControl("UserControls/FooterControl.ascx")
            FooterPh.Controls.Add(FooterControl)
        Else
        End If
    End Sub

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub
End Class
