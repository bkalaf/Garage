Imports log4net
Namespace UserControls947
    Partial Class LoginControl
        Inherits System.Web.UI.UserControl
        Dim applogin As String
        Dim business1 As String
        Private xmlConfig As XmlUtils.XmlConfig
        Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
        Private Const COMP_GQS_AgentLogin = "AgentLogin"
        Private Const xmlCONTEXT = "GarageQuoteSheet"
        Private Shared logger As log4net.ILog = _
              log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblMessage.Text = String.Empty
            txtFaxNo.Visible = False
        End Sub

        Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
            business1 = 1
            logger.Debug("Entering AgentLogin.btnSubmit_Click")
            Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
            Dim oAgent As GarageQuoteSheetDLL.Agent
            Try
           

                If Not checkAgentCode() Then
                    Exit Sub
                End If
              
                oAgent = CType(objAgent.GetData(txtCode.Text.Trim).Item(0), GarageQuoteSheetDLL.Agent)
                If IsNothing(oAgent.AgentCode) Then
                    If Not IsNothing(oAgent.Department) Then
                        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ACCLockMsg") & " Please contact " & oAgent.Department & " for further assistance"
                    Else : lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ACCLockMsg") & " Please contact SIU for further assistance"
                    End If
                    lblMessage.ForeColor = Drawing.Color.Red
                Else
                    If txtPhone.Text.Trim = "" Then
                        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ReqPhone")
                        lblMessage.ForeColor = Drawing.Color.Red
                        Exit Sub
                    End If
                    Session("AgentPhone") = txtPhone.Text.Trim
                    Session("AgentPersonRequesting") = txtRequester.Text.Trim
                    'Session("QuoteRepliedMode") = ddlReplyOptions.SelectedItem.Text
                    Session("AgentCode") = txtCode.Text.Trim

                    If ddlReplyOptions.SelectedItem.Text.Trim = "Fax" Then
                        If txtFaxNo.Text.Trim = "" Then
                            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ReqFax")
                            lblMessage.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If

                    Else
                        If txtemail.Text.Trim = "" Then
                            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ReqEmail")
                            lblMessage.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If


                    End If


                    Session("AgentQuoteReplyOption") = ddlReplyOptions.SelectedItem.Text.Trim
                    If ddlReplyOptions.SelectedItem.Text.Trim = "Fax" Then
                        Session("AgentEmailFax") = txtFaxNo.Text.Trim
                    Else
                        Session("AgentEmailFax") = txtemail.Text.Trim
                    End If

                    Dim strASV() As String = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "AgentStatusValue").Split(";")
                    For i As Int16 = 0 To strASV.Length - 1
                        If StrComp(strASV(i).Trim, oAgent.StatusTypeValue.Trim, CompareMethod.Text) = 0 Then
                            Session("AgentStatusTypeValue") = oAgent.StatusTypeValue
                        End If
                    Next
                    applogin = ddlappchosen.SelectedValue.ToString()

                    logger.Info("Agent " & txtCode.Text.Trim & " is proceeding to " & ddlappchosen.SelectedItem.Text & " QuotePage")

                    logger.Debug("Exiting AgentLogin.btnSubmit_Click")

                    If ddlappchosen.SelectedValue.ToString() = "1" Then


                        Response.Redirect("Appication.aspx?agentcode=" & txtCode.Text.Trim & "&app=" & applogin)
                    ElseIf ddlappchosen.SelectedValue.ToString() = "2" Then

                        Response.Redirect("createquote.aspx?agentcode=" & txtCode.Text.Trim)
                    Else
                        Response.Redirect("Appication.aspx?agentcode=" & txtCode.Text.Trim + "&app=" + applogin)


                    End If

                    'Response.Redirect("appication.aspx?AgentCode=001073&USR=350&pw=000350&LOGIN_ID=350&LOGIN_TYPE=1&TAG=SIURATE&type=commercial&app=1")


                End If

               
            Catch tex As System.Threading.ThreadAbortException
                'do nothing
            Catch ex As Exception
            Finally
                oAgent = Nothing
                objAgent = Nothing
            End Try

        End Sub

        Protected Sub ddlReplyOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReplyOptions.SelectedIndexChanged
            If ddlReplyOptions.SelectedItem.Text = "Fax" Then
                txtFaxNo.Visible = True
                txtemail.Visible = False
                regxvEmailOption.Enabled = False
                regxvFaxOption.Enabled = True
                txtFaxNo.Text = ""
                ddlappchosen.Focus()

                ddlappchosen.TabIndex = 5
            Else
                txtFaxNo.Visible = False
                txtemail.Visible = True
                regxvFaxOption.Enabled = False
                regxvEmailOption.Enabled = True
                txtemail.Text = ""
                ddlappchosen.Focus()
                ddlappchosen.TabIndex = 5
            End If
        End Sub
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
            Try
            
                Dim strContentUrl As String
                Dim strQueryString As String
                If Request.QueryString("fb") IsNot Nothing Then
                    If Request.QueryString("fb").ToUpper() = "FL" Then
                        Response.Redirect("http://www.siuffb.com", True)
                    End If
                Else
                    strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                    If Not (IsNothing(Session("TAG"))) And Session("TAG") = "922HOMEPAGE" Then
                        strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                        strQueryString = "?Title=" & Session("TAG").ToString
                        Response.Redirect(strContentUrl & strQueryString)
                    Else
                        Response.Redirect(strContentUrl & "?Title=922HOMEPAGE")
                    End If
                End If
            Catch tex As System.Threading.ThreadAbortException
                'do nothing
            Catch ex As Exception
                logger.Error("Exxception occurred ", ex)
            End Try
        End Sub
    End Class

End Namespace
