Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Web.Mail

Namespace UserControls947
    Partial Class AgencyInformation
        Inherits System.Web.UI.UserControl
        Private xmlConfig As XmlUtils.XmlConfig
        Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
        Private Const COMP_GQS_AgentLogin = "AgentLogin"
        Private Const xmlCONTEXT = "GarageQuoteSheet"
        Private Shared logger As log4net.ILog = _
              log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            logger.Debug("Entering CreateQuote.Page_Load")

            If Not IsPostBack Then
                Try
                 

                    If Request.QueryString("AgentCode") <> "" Then
                        Session("AgentCode") = Request.QueryString("AgentCode")
                    End If
                    If Session("AgentCode") = "" Then
                        Response.Redirect("agentlogin.aspx")
                    End If

                    Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
                    Dim oAgent As GarageQuoteSheetDLL.Agent
                    oAgent = CType(objAgent.GetData(Session("AgentCode")).Item(0), Agent)
                    If IsNothing(oAgent.AgentCode) Then
                        Response.Redirect("agentlogin.aspx")
                    Else
                        txtPhone.Text = Session("AgentPhone")
                        txtContact.Text = Session("AgentPersonRequesting")
                        txtFaxNo.Text = Session("AgentEmailFax")
                        'txtEmail.Text = Session("AgentEmail")
                        lblAgency.Text = oAgent.AgentCode
                        lblAgencyName.Text = oAgent.LegalName
                        If Not Session("AgentQuoteReplyOption") Is Nothing Then
                            If Session("AgentQuoteReplyOption").ToString = "Email" Then
                                ddlReplyOptions.SelectedIndex = 0
                                regxvEmailOption.Enabled = True
                                regxvFaxOption.Enabled = False
                            Else
                                ddlReplyOptions.SelectedIndex = 1
                                regxvEmailOption.Enabled = False
                                regxvFaxOption.Enabled = True
                            End If
                        End If
                    End If
                    oAgent = Nothing
                    objAgent = Nothing
                    If Not IsNothing(Session("AgentStatusTypeValue")) Then
                        trAgentStatus.Visible = True
                        lblAgentStatus.Text = Session("AgentStatusTypeValue")
                    Else : trAgentStatus.Visible = True
                    End If
                Catch ex As Exception
                    'lblMessage.Visible = True
                    'lblMessage.Text = ".NET Exception: " & ex.Message
                End Try
            End If
            logger.Debug("Exiting CreateQuote.Page_Load")
        End Sub


    End Class
End Namespace
