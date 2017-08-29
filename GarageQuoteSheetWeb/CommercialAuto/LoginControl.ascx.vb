Imports log4net
Namespace UserControl947
    Partial Class LoginControl
        Inherits System.Web.UI.UserControl
        Private xmlConfig As XmlUtils.XmlConfig
        Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
        Private Const COMP_GQS_AgentLogin = "AgentLogin"
        Private Const xmlCONTEXT = "GarageQuoteSheet"
        Private Shared logger As log4net.ILog = _
              log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblMessage.Text = String.Empty
        End Sub

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
                If txtFaxNo.Text.Trim = "" Then
                    If ddlReplyOptions.SelectedItem.Text.Trim = "Fax" Then
                        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ReqFax")
                    Else
                        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_AgentLogin, "ReqEmail")
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
                Response.Redirect("CommercialAuto.aspx?agentcode=" & txtCode.Text.Trim)
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
    End Class

End Namespace
