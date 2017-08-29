Imports GarageQuoteSheetDLL
Imports log4net
Imports System.Web.Mail
Imports System.Data
Namespace UserControl947
    Partial Class AgencyInformation
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Implements H03ISubscriber
        Private Shared logger As log4net.ILog = _
              log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
        Dim strName As String = "AgencyDetails"
        Dim ValidateMsg As String
        Dim genAgencyColl As GenericCollection(Of IEntity)

#Region "DataMembers"

        Private objAgency As GarageQuote


#End Region

#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property

        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property
#End Region
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            logger.Debug("Entering AgencyInformation.Page_Load")
            
            If Not IsPostBack Then
                Try
                    Dim app As String = Request.QueryString("app")
                    If app = "3" Then
                        pnlAgentInformation.Visible = True
                        BindAgentCSR(Session("AgentCode"))
                    End If
                    Dim objService As New SIUService.ServiceSoapClient()
                    If objService.isUnderwriter(IpAddress) = True Then
                        lblUnderwriter.Visible = True
                        txtUnderwriteName.Visible = True
                        lblUWEmail.Visible = True
                        txtunderwriteremail.Visible = True
                        rgvUWEmail.Enabled = True
                        rgvUWEmail.Visible = True
                        reqvUWEmail.Enabled = True
                        reqvUWEmail.Visible = True
                    Else
                        lblUnderwriter.Visible = False
                        txtUnderwriteName.Visible = False
                        lblUWEmail.Visible = False
                        txtunderwriteremail.Visible = False
                        rgvUWEmail.Enabled = False
                        rgvUWEmail.Visible = False
                        reqvUWEmail.Enabled = False
                        reqvUWEmail.Visible = False

                    End If
                    If Request.QueryString("AgentCode") <> "" Then
                        Session("AgentCode") = Request.QueryString("AgentCode")
                    End If
                    If Session("AgentCode") = "" Then
                        Response.Redirect("Default.aspx")
                    End If
                    '=================
                    Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
                    Dim oAgent As GarageQuoteSheetDLL.Agent
                    oAgent = CType(objAgent.GetData(Session("AgentCode")).Item(0), Agent)
                    If IsNothing(oAgent.AgentCode) Then
                        Response.Redirect("Default.aspx")
                    Else

                        If Not IsNothing(Session("AgentPhone")) Then
                            txtPhone.Text = Session("AgentPhone")
                        End If
                        If Not IsNothing(Session("AgentPersonRequesting")) Then
                            txtContact.Text = Session("AgentPersonRequesting")
                        End If
                        lblAgency.Text = oAgent.AgentCode
                        If oAgent.LegalName.Trim <> "" Then
                            lblAgencyName.Text = oAgent.LegalName
                        Else
                            lblAgencyName.Text = oAgent.DBAName
                        End If
                        If Not IsNothing(Session("AgentStatusTypeValue")) Then
                            trAgentStatus.Visible = True
                            lblAgentStatus.Text = Session("AgentStatusTypeValue")
                        Else
                            trAgentStatus.Visible = True
                            lblAgentStatus.Text = oAgent.StatusTypeValue
                            Session("AgentStatusTypeValue") = oAgent.StatusTypeValue
                        End If
                        If Not Session("AgentQuoteReplyOption") Is Nothing Then
                            If Session("AgentQuoteReplyOption").ToString = "Email" Then
                                ddlReplyOptions.SelectedIndex = 0
                                txtemail.Visible = True
                                txtFaxNo.Visible = False
                                txtemail.Text = Session("AgentEmailFax")

                                regxvEmailOption.Enabled = True
                                regxvFaxOption.Enabled = False
                            Else
                                ddlReplyOptions.SelectedIndex = 1
                                txtemail.Visible = False
                                txtFaxNo.Visible = True
                                txtFaxNo.Text = Session("AgentEmailFax")
                                regxvEmailOption.Enabled = False
                                regxvFaxOption.Enabled = True
                            End If
                        End If
                    End If
                    oAgent = Nothing
                    objAgent = Nothing

                    '===============

                    'Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
                    'Dim oAgent As GarageQuoteSheetDLL.Agent
                    'oAgent = CType(objAgent.GetData(Session("AgentCode")).Item(0), Agent)
                    'If IsNothing(oAgent.AgentCode) Then
                    '    Response.Redirect("agentlogin.aspx")
                    'Else
                    '    txtPhone.Text = Session("AgentPhone")
                    '    txtContact.Text = Session("AgentPersonRequesting")


                    '    lblAgency.Text = oAgent.AgentCode
                    '    lblAgencyName.Text = oAgent.LegalName


                    '    If Not Session("AgentQuoteReplyOption") Is Nothing Then
                    '        If Session("AgentQuoteReplyOption").ToString = "Email" Then
                    '            ddlReplyOptions.SelectedIndex = 0
                    '            txtemail.Visible = True
                    '            txtFaxNo.Visible = False
                    '            txtemail.Text = Session("AgentEmailFax")

                    '            regxvEmailOption.Enabled = True
                    '            regxvFaxOption.Enabled = False
                    '        Else
                    '            ddlReplyOptions.SelectedIndex = 1
                    '            txtemail.Visible = False
                    '            txtFaxNo.Visible = True
                    '            txtFaxNo.Text = Session("AgentEmailFax")
                    '            regxvEmailOption.Enabled = False
                    '            regxvFaxOption.Enabled = True
                    '        End If
                    '    End If
                    'End If
                    'oAgent = Nothing
                    'objAgent = Nothing
                    'If Not IsNothing(Session("AgentStatusTypeValue")) Then
                    '    trAgentStatus.Visible = True
                    '    lblAgentStatus.Text = Session("AgentStatusTypeValue")
                    'Else : trAgentStatus.Visible = True
                    'End If
                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            End If
            logger.Debug("Exiting AgencyInformation.Page_Load")
        End Sub


        Private Function Validate() As String Implements ISubscriber.Validate
            logger.Debug("Entering AgencyInformation.Validate")
            If ddlReplyOptions.SelectedItem.Text = "Email" Then
                If txtemail.Text = "" Then
                    ValidateMsg = "Please provide the email(Agency Details)"
                    logger.Info(ValidateMsg)
                    logger.Debug("Exiting AgencyInformation.Validate")
                    Return (ValidateMsg)
                End If
            Else

                If txtFaxNo.Text = "" Then
                    ValidateMsg = "Please provide the Fax No(Agency Details)"
                    logger.Info(ValidateMsg)
                    logger.Debug("Exiting AgencyInformation.Validate")
                    Return (ValidateMsg)
                End If
            End If
            If txtUnderwriteName.Visible = True Then
                If txtUnderwriteName.Text.Trim = "" Then
                    ValidateMsg = "Please provide the SIU internal User name(Agency Details)"
                    logger.Info(ValidateMsg)
                    logger.Debug("Exiting AgencyInformation.Validate")
                    Return (ValidateMsg)
                End If
            End If

            If txtunderwriteremail.Visible = True Then
                If txtunderwriteremail.Text.Trim = "" Then
                    ValidateMsg = "Please provide the SIU internal User's Email ID"
                    logger.Info(ValidateMsg)
                    logger.Debug("Exiting AgencyInformation.Validate")
                    Return (ValidateMsg)
                End If
            End If
            logger.Info(ValidateMsg)
            logger.Debug("Exiting AgencyInformation.Validate")
            Return (ValidateMsg)

        End Function
        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            logger.Debug("Entering AgencyInformation.Validate")
            If ddlReplyOptions.SelectedItem.Text = "Email" Then
                If txtemail.Text = "" Then
                    ValidateMsg = "Please provide the email(Agency Details)"
                    Return (ValidateMsg)
                End If
            Else

                If txtFaxNo.Text = "" Then
                    ValidateMsg = "Please provide the Fax No(Agency Details)"
                    Return (ValidateMsg)
                End If
            End If
            If txtUnderwriteName.Visible = True Then
                If txtUnderwriteName.Text.Trim = "" Then
                    ValidateMsg = "Please provide the SIU internal User name(Agency Details)"
                    Return (ValidateMsg)
                End If
            End If
            If txtFName.Visible = True Then
                If txtFName.Text.Trim = "" Then
                    ValidateMsg = "Please Enter First Name(Agency Details)"
                    Return (ValidateMsg)
                End If
            End If
            If txtLName.Visible = True Then
                If txtLName.Text.Trim = "" Then
                    ValidateMsg = "Please Enter Last Name(Agency Details)"
                    Return (ValidateMsg)
                End If
            End If
            If txtSSN.Visible = True Then
                If txtSSN.Text.Trim = "" Then
                    ValidateMsg = "Please Enter Last 4 disgits SSN(Agency Details)"
                    Return (ValidateMsg)
                End If
            End If
            Return (ValidateMsg)
            logger.Debug("Exiting AgencyInformation.Validate")
        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            Return GetCollection("Commercial")
        End Function
        Public Function GetCollection(ByVal strControl As String) As GenericCollection(Of IEntity)
            logger.Debug("Entering AgencyInformation.GetInputData For " + strControl)
            Try

                genAgencyColl = New GenericCollection(Of IEntity)
                objAgency = New GarageQuote()
                objAgency.GarageQuoteID = 0
                objAgency.AgentID = lblAgency.Text
                objAgency.Phone = txtPhone.Text
                objAgency.Contact = txtContact.Text.Trim
                objAgency.UnderwriterName = txtUnderwriteName.Text.Trim
                objAgency.UnderwriterEmail = txtunderwriteremail.Text.Trim
                If pnlAgentInformation.Visible = True Then
                    objAgency.AgentFname = txtFName.Text
                    objAgency.AgentLName = txtLName.Text
                    objAgency.AgentSSN = txtSSN.Text
                End If
                If ddlReplyOptions.SelectedItem.Text = "Fax" Then
                    objAgency.Fax = txtFaxNo.Text.Trim
                Else
                    objAgency.Email = txtemail.Text
                End If
                objAgency.CreatedORModifiedBY = lblAgencyName.Text.Trim
                If Not (Session("SearchedQuoteid") Is Nothing) Then
                    If Session("SearchedQuoteid").ToString <> "" Then
                        objAgency.ParentQuoteID = Int32.Parse(Session("SearchedQuoteid").ToString)
                    End If
                End If
                genAgencyColl.Add(objAgency)
            Catch ex As Exception

                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try
            Return genAgencyColl
            logger.Debug("Exiting AgencyInformation.GetInputData For " + strControl)
        End Function
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        End Sub
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering AgencyInformation.FillControls")
            Dim objQuoteColl As GenericCollection(Of IEntity)
            Dim objQuoteDM As GarageQuoteDataModel
            Dim objQuote As GarageQuote

            Dim iCount As Integer
            Try
                objQuoteColl = New GenericCollection(Of IEntity)
                objQuoteDM = New GarageQuoteDataModel()
                objQuoteColl = objQuoteDM.GetData(strQuoteId, "1")
                objQuote = New GarageQuote()

                If objQuoteColl.Count > 0 Then
                    lblAgency.Text = CType(objQuoteColl.Item(0), GarageQuote).AgentID
                    lblAgencyName.Text = CType(objQuoteColl.Item(0), GarageQuote).CreatedORModifiedBY
                    txtContact.Text = CType(objQuoteColl.Item(0), GarageQuote).Contact

                    If CType(objQuoteColl.Item(0), GarageQuote).Email <> "" Then
                        ddlReplyOptions.SelectedIndex = -1
                        ddlReplyOptions.Items.FindByText("Email").Selected = True
                        txtemail.Visible = True
                        txtFaxNo.Visible = False
                        txtemail.Text = CType(objQuoteColl.Item(0), GarageQuote).Email
                        regxvEmailOption.Enabled = True
                        regxvFaxOption.Enabled = False

                    Else
                        ddlReplyOptions.SelectedIndex = -1
                        ddlReplyOptions.Items.FindByText("Fax").Selected = True
                        txtemail.Visible = False
                        txtFaxNo.Visible = True
                        txtFaxNo.Text = CType(objQuoteColl.Item(0), GarageQuote).Fax
                        regxvEmailOption.Enabled = False
                        regxvFaxOption.Enabled = True

                    End If


                    txtPhone.Text = CType(objQuoteColl.Item(0), GarageQuote).Phone
                    txtUnderwriteName.Text = CType(objQuoteColl.Item(0), GarageQuote).UnderwriterName
                    txtunderwriteremail.Text = CType(objQuoteColl.Item(0), GarageQuote).UnderwriterEmail
                    'If lblParentQuoteNo.Text <> "" Then
                    '    fldParentQuote.Visible = True
                    'Else : fldParentQuote.Visible = False
                    'End If

                End If


            Catch ex As Exception
                logger.Error("Exception occurred while setting values in Quote-Agency Details :", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
                Throw ex

            End Try
            logger.Debug("Exiting AgencyInformation.FillControls")

        End Function


        Protected Sub ddlReplyOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReplyOptions.SelectedIndexChanged
            If ddlReplyOptions.SelectedItem.Text = "Fax" Then
                txtFaxNo.Visible = True
                txtemail.Visible = False
                regxvEmailOption.Enabled = False
                regxvFaxOption.Enabled = True
                txtFaxNo.Text = ""
                ddlReplyOptions.Focus()
                'txtFaxNo.TabIndex = 4





            Else
                txtFaxNo.Visible = False
                txtemail.Visible = True
                regxvFaxOption.Enabled = False
                regxvEmailOption.Enabled = True
                txtemail.Text = ""
                ddlReplyOptions.Focus()
                'txtemail.TabIndex = 4



            End If

        End Sub
        ''' <summary>
        ''' Implements GetH03InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            Return GetCollection("H03")
        End Function
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            Return ""
        End Function
        ''' <summary>
        ''' Get ProxyIp Address of Visitor '216.235.149.254
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IpAddress() As String
            Dim strIpAddress As String
            strIpAddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If strIpAddress Is Nothing Then
                strIpAddress = Request.ServerVariables("REMOTE_ADDR")
            End If
            Return strIpAddress
        End Function
        ''' <summary>
        ''' Show Error Message
        ''' </summary>
        ''' <param name="strMessage"></param>
        ''' <remarks></remarks>
        Sub ShowMessage(ByVal strMessage As String) Implements H03ISubscriber.ShowMessage
            Exit Sub
        End Sub
        ''' <summary>
        ''' Set CoverageB and CoverageD 
        ''' </summary>
        ''' <param name="CoverageB"></param>
        ''' <param name="CoverageD"></param>
        ''' <remarks></remarks>
        Sub SetCoverage(ByVal CoverageB As String, ByVal CoverageD As String) Implements H03ISubscriber.SetCoverage

        End Sub
        ''' <summary>
        ''' Bind Agent/CSR information Based On Agent Id
        ''' </summary>
        ''' <param name="strAgentId"></param>
        ''' <remarks></remarks>
        Private Sub BindAgentCSR(ByVal strAgentId As String)
            Dim objH03Quote As New GarageQuoteSheetDLL.H03QuoteDataModel
            Dim DsAgentCSR As System.Data.DataSet = objH03Quote.GetAgencyInformation(strAgentId)
            Session("AgentCSR") = DsAgentCSR
            
            If DsAgentCSR.Tables(0).Rows.Count > 0 Then
                ddlAgentCSR.DataTextField = "AgentName"
                ddlAgentCSR.DataValueField = "SSN"
                ddlAgentCSR.DataSource = DsAgentCSR.Tables(0)
                ddlAgentCSR.DataBind()
            End If
            ddlAgentCSR.Items.Insert(0, New System.Web.UI.WebControls.ListItem("New", "1"))
            ddlAgentCSR.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))

        End Sub

        Protected Sub ddlAgentCSR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim DsAgentCSR As System.Data.DataSet = CType(Session("AgentCSR"), DataSet)
            ClearTextBoxes()
            EnabledControl(True)
            Dim DR As DataRow() = DsAgentCSR.Tables(0).Select("SSN =" & ddlAgentCSR.Items(ddlAgentCSR.SelectedIndex).Value)
            If DR.Length > 0 Then
                txtFName.Text = DR(0)("FIRSTNAME").ToString()
                txtLName.Text = DR(0)("LASTNAME").ToString()
                txtSSN.Text = DR(0)("SSN").ToString()
            Else
                If ddlAgentCSR.SelectedIndex <> 0 Then
                    ClearTextBoxes()
                    EnabledControl(False)
                End If
            End If
        End Sub
        ''' <summary>
        ''' ''' Enabled AgencyInfo Controls
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <remarks></remarks>
        Sub EnabledControl(ByVal Flag As Boolean)
            txtFName.ReadOnly = Flag
            txtLName.ReadOnly = Flag
            txtSSN.ReadOnly = Flag
        End Sub
        ''' <summary>
        ''' Clear All TextBoxes
        ''' </summary>
        ''' <remarks></remarks>
        Sub ClearTextBoxes()
            txtFName.Text = ""
            txtLName.Text = ""
            txtSSN.Text = ""
        End Sub
    End Class
End Namespace
