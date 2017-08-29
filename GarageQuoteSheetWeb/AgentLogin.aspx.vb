Imports log4net
Partial Class AgentLogin
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_AgentLogin As String = "AgentLogin"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
    End Sub
    ''' <summary>
    ''' this event checks Agent Code, and if right then fills up session variables with Agent related information
    ''' these information are needed for CreateQuote Page where page gets redirected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        logger.Debug("Entering AgentLogin.btnSubmit_Click")
        If Not checkAgentCode() Then
            Exit Sub
        End If
        Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
        Dim oAgent As GarageQuoteSheetDLL.Agent
        oAgent = CType(objAgent.GetData(txtCode.Text.Trim).Item(0), GarageQuoteSheetDLL.Agent)
        If IsNothing(oAgent.AgentCode) Then
            If Not IsNothing(oAgent.Department) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(comp_gqs_agentlogin, "ACCLockMsg") & " Please contact " & oAgent.Department & " for further assistance"
            Else : lblMessage.Text = xmlConfig.GetComponentProperty(comp_gqs_agentlogin, "ACCLockMsg") & " Please contact SIU for further assistance"
            End If
            lblMessage.ForeColor = Drawing.Color.Red
        Else
            If txtPhone.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty(comp_gqs_agentlogin, "ReqPhone")
                lblMessage.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
            Session("AgentPhone") = txtPhone.Text.Trim
            Session("AgentPersonRequesting") = txtRequester.Text.Trim
            'Session("QuoteRepliedMode") = ddlReplyOptions.SelectedItem.Text
            Session("AgentCode") = txtCode.Text.Trim
            If txtFaxNo.Text.Trim = "" Then
                If ddlReplyOptions.SelectedItem.Text.Trim = "Fax" Then
                    lblMessage.Text = xmlConfig.GetComponentProperty(comp_gqs_agentlogin, "ReqFax")
                Else
                    lblMessage.Text = xmlConfig.GetComponentProperty(comp_gqs_agentlogin, "ReqEmail")
                End If
                lblMessage.ForeColor = Drawing.Color.Red
                Exit Sub

            End If

            Session("AgentQuoteReplyOption") = ddlReplyOptions.SelectedItem.Text.Trim
            Session("AgentEmailFax") = txtFaxNo.Text.Trim
            Dim strASV() As String = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "AgentStatusValue").Split(";")
            For i As Int16 = 0 To strASV.Length - 1
                If StrComp(strASV(i).Trim, oAgent.StatusTypeValue.Trim, CompareMethod.Text) = 0 Then
                    Session("AgentStatusTypeValue") = oAgent.StatusTypeValue
                End If
            Next
            Response.Redirect("createquote.aspx?agentcode=" & txtCode.Text.Trim)
        End If
        oAgent = Nothing
        objAgent = Nothing
        logger.Debug("Exiting AgentLogin.btnSubmit_Click")
    End Sub

    Protected Sub ddlReplyOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReplyOptions.SelectedIndexChanged
        If ddlReplyOptions.SelectedItem.Text = "Fax" Then
            regxvEmailOption.Enabled = False
            regxvFaxOption.Enabled = True
        Else
            regxvFaxOption.Enabled = False
            regxvEmailOption.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' called by Submit button click
    ''' for prefixing 0 to Agent code as Agent code should be of length=6
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkAgentCode() As Boolean
        Dim strCode As String = txtCode.Text.Trim
        If strCode.Length = 4 Then
            strCode = "00" & strCode
            txtCode.Text = strCode
            Return True
        End If
        If strCode.Length = 5 Then
            strCode = "0" & strCode
            txtCode.Text = strCode
            Return True
        End If
        If strCode.Length = 6 Then 'And Mid(strCode, 1, 2) = "00" Then
            Return True
        End If
        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "AgentCodeFormat")
        lblMessage.Visible = True
        Return False
    End Function

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub

   
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim strContentUrl As String
        Dim strQueryString As String

        If Request.QueryString("fb") IsNot Nothing Then
            If Request.QueryString("fb").ToUpper() = "FL" Then
                Response.Redirect("http://www.siuffb.com", True)
            End If
        Else
            If Not (IsNothing(Session("TAG"))) And Session("TAG") = "922HOMEPAGE" Then
                strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                strQueryString = "?Title=" & Session("TAG").ToString
                Response.Redirect(strContentUrl & strQueryString)
            End If
        End If

    End Sub
End Class
