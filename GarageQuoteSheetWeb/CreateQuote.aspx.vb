Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Web.Mail
Imports System
Imports System.IO
Imports System.Collections.Generic

Partial Class CreateQuote
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote As String = "CreateQuote"
    Private Const COMP_GQS_SearchQuote As String = "SearchQuotes"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Public MMDDYYYY As String = DateTime.Now.Month.ToString() & "/" & DateTime.Now.Day.ToString() & "/" & DateTime.Now.Year.ToString()
    Dim objService As New SIUService.ServiceSoapClient()
    Dim fyear1, fyear2, fyear3 As Integer
    Dim tyear1, tyear2, tyear3 As Integer
    Dim frmyear1, frmyear2, frmyear3 As String
    Dim toyear1, toyear2, toyear3 As String
    Dim frmdate1, todate1, frmdate2, frmdate3, todate2, todate3 As DateTime

    Protected Function Custom_base2(yesButton As RadioButton, noButton As RadioButton) As Boolean
        If yesButton.Checked Then
            Custom_base2 = True
        ElseIf noButton.Checked Then
            Custom_base2 = True
        Else
            Custom_base2 = False
        End If
    End Function

    Protected Function Custom_base(yesButton As RadioButton, noButton As RadioButton, textBox As TextBox) As Boolean
        If yesButton.Checked Then
            Custom_base = True
        ElseIf noButton.Checked And String.IsNullOrEmpty(textBox.Text) Then
            Custom_base = False
        Else
            Custom_base = True
        End If
    End Function

    Protected Sub Custom_rdoGarageOperation(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base(rdoGarageOperationOtherLocationYes, rdoGarageOperationOtherLocationNo, txtMplOtherLocations)
    End Sub
    Protected Sub Custom_rdoAutoParts(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base(rdAutoPartsYes, rdAutoPartsNo, txtSellPercentage)
    End Sub
    Protected Sub Custom_rdoHasWrecker(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base2(rdOwnWreckerYes, rdOwnWreckerNo)
    End Sub
    Protected Sub Custom_rdoHasRollback(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base2(rdOwnRollbackYes, rdOwnRollbackNo)
    End Sub
    Protected Sub Custom_rdoOwnTowBar(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base(rdTowBarDollieTrailerYes, rdTowBarDollieTrailerNo, txtMplDollie)
    End Sub
    Protected Sub Custom_rdoOperateSalvage(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base2(rdoOperateSalvageYardYes, rdoOperateSalvageYardNo)
    End Sub
    Protected Sub Custom_rdoOtherBusiness(sender As Object, e As ServerValidateEventArgs)
        e.IsValid = Custom_base(rdOtherBusinessOperationYes, rdOtherBusinessOperationNo, txtMplOtherBusiness)
    End Sub
    Public Property DriverSet As DataSet = New DataSet()
    ''' <summary>
    ''' Load event for first time, will fill up the Agent information and Garage Lookups
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Debug("Entering CreateQuote.Page_Load")
        txtState.Attributes.Add("onkeypress", "Javascript:return AllowAlphabet();")
        Dim oGarageLookupData As New GarageQuoteSheetDLL.GarageLookupDataModel
        lblMessage.Visible = False
        txtFaxNo.Visible = False
        dealertags.Visible = False
        Label1.Visible = False
        Label1.Text = lblMessage.Text
        If Not IsPostBack Then
            Try


                If objService.isUnderwriter(IpAddress) = True Then
                    lblUnderwriter.Visible = True
                    txtUnderwriteName.Visible = True
                    lblUnderwriteremail.Visible = True
                    txtuwemail.Visible = True

                Else
                    lblUnderwriter.Visible = False
                    txtUnderwriteName.Visible = False
                    lblUnderwriteremail.Visible = False
                    txtuwemail.Visible = False
                End If

                trYrsExp.Visible = False
                fldParentQuote.Visible = False
                setClientScripts()
                If Len(Trim(Request.QueryString("TAG"))) > 0 Then
                    Session("TAG") = Trim(Request.QueryString("TAG"))
                End If
                If Request.QueryString("AgentCode") <> "" Then
                    Session("AgentCode") = Request.QueryString("AgentCode")
                End If
                If Len(Trim(Request.QueryString("USR"))) > 0 And Len(Trim(Request.QueryString("PW"))) > 0 And Len(Trim(Request.QueryString("LOGIN_ID"))) > 0 And Len(Trim(Request.QueryString("LOGIN_TYPE"))) > 0 And Len(Trim(Request.QueryString("TAG"))) > 0 Then
                    Session("USR") = Trim(Request.QueryString("USR"))
                    Session("PW") = Trim(Request.QueryString("PW"))
                    Session("LOGIN_ID") = Trim(Request.QueryString("LOGIN_ID"))
                    Session("LOGIN_TYPE") = Trim(Request.QueryString("LOGIN_TYPE"))
                    Session("TAG") = Trim(Request.QueryString("TAG"))
                    'Session("AgentCode") = Trim(Request.QueryString("USR"))
                    logger.Info("Information coming forward from previous page : " _
            & vbCrLf & " Session(USR) = " & Trim(Request.QueryString("USR")) _
                  & vbCrLf & " Session(PW) = " & Trim(Request.QueryString("PW")) _
                  & vbCrLf & " Session(LOGIN_ID) = " & Trim(Request.QueryString("LOGIN_ID")) _
                   & vbCrLf & " Session(LOGIN_TYPE) = " & Trim(Request.QueryString("LOGIN_TYPE")) & vbCrLf & " Session(TAG) = " & Trim(Request.QueryString("TAG")) _
                   & vbCrLf & " Session(TAG) = " & Trim(Request.QueryString("TAG")) _
                  )

                End If
                'Commercial url from siurate 
                'http://garage.siuins.com/garagequotesheet/appication.aspx.com?AgentCode=1073&USR=1073&pw=1073&LOGIN_ID=1073&LOGIN_TYPE=USR&TAG=SIURATE&type=commercial&app=1
                'garage url
                'http://garage.siuins.com/garagequotesheet/appication.aspx.com?AgentCode=1073&USR=1073&pw=1073&LOGIN_ID=1073&LOGIN_TYPE=USR&TAG=SIURATE&type=commercial&app=2
                Try
                    If Session("AgentCode") = "" Then
                        Response.Redirect("Default.aspx")
                    End If
                Catch tex As System.Threading.ThreadAbortException

                End Try





                If Not (Session("TAG") Is Nothing) Then
                    If Session("TAG") = "SIURATE" Then

                    End If
                End If


                pnlInsuranceHistory.Visible = 1
                Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
                Dim oAgent As GarageQuoteSheetDLL.Agent
                oAgent = CType(objAgent.GetData(Session("AgentCode")).Item(0), Agent)
                If IsNothing(oAgent.AgentCode) Then
                    Response.Redirect("Default.aspx")
                Else

                    If Not IsNothing(Session("AgentPhone")) Then
                        txtPhone.Text = Session("AgentPhone")
                    End If
                    If Not IsNothing(Session("AgentPhone")) Then
                        txtContact.Text = Session("AgentPersonRequesting")
                    End If
                    If Not IsNothing(Session("AgentPhone")) Then
                        'txtFaxNo.Text = Session("AgentEmailFax")
                        txtemail.Text = Session("AgentEmailFax")
                    End If
                    'txtEmail.Text = Session("AgentEmail")
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


                'Following fills Garage Limits Liability
                ddlGarageLimit.Items.Clear()
                ddlGarageLimit.DataSource = oGarageLookupData.getLookup(1)
                ddlGarageLimit.DataTextField = "Value"
                ddlGarageLimit.DataValueField = "ID"
                ddlGarageLimit.DataBind()
                ddlGarageLimit.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'Following fills Reject
                ddlReject.Items.Clear()
                ddlReject.DataSource = oGarageLookupData.getLookup(2)
                ddlReject.DataTextField = "Value"
                ddlReject.DataValueField = "ID"
                ddlReject.DataBind()
                ddlReject.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'If txtState.Text = "FL" Then
                'ddlReject.Items.Insert(1, New System.Web.UI.WebControls.ListItem("10,000", "0"))
                ' Else
                ddlReject.Items.Clear()
                ddlReject.DataSource = oGarageLookupData.getLookup(2)
                ddlReject.DataTextField = "Value"
                ddlReject.DataValueField = "ID"
                ddlReject.DataBind()
                ddlReject.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'End If
                'Following fills Medical Patment Limit
                ddlMedPay.Items.Clear()
                ddlMedPay.DataSource = oGarageLookupData.getLookup(3)
                ddlMedPay.DataTextField = "Value"
                ddlMedPay.DataValueField = "ID"
                ddlMedPay.DataBind()
                ddlMedPay.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'Following fills Radius of Operation
                ddlRadius.Items.Clear()
                ddlRadius.DataSource = oGarageLookupData.getLookup(4)
                ddlRadius.DataTextField = "Value"
                ddlRadius.DataValueField = "ID"
                ddlRadius.DataBind()
                ddlRadius.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'Following fills GKL Deductibles
                ddlGKLLDeductible.Items.Clear()
                ddlGKLLDeductible.DataSource = oGarageLookupData.getLookup(5)
                ddlGKLLDeductible.DataTextField = "Value"
                ddlGKLLDeductible.DataValueField = "ID"
                ddlGKLLDeductible.DataBind()
                ddlGKLLDeductible.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                'Following fills Dealer Plates
                ddlDealerPlates.Items.Clear()
                ddlDealerPlates.DataSource = oGarageLookupData.getLookup(6)
                ddlDealerPlates.DataTextField = "Value"
                ddlDealerPlates.DataValueField = "ID"
                ddlDealerPlates.DataBind()
                ddlDealerPlates.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select if you want", "0"))
                'Following fills Dealer Deductibles
                ddlDealerPhyDamDeductible.Items.Clear()
                ddlDealerPhyDamDeductible.DataSource = oGarageLookupData.getLookup(7)
                ddlDealerPhyDamDeductible.DataTextField = "Value"
                ddlDealerPhyDamDeductible.DataValueField = "ID"
                ddlDealerPhyDamDeductible.DataBind()
                ddlDealerPhyDamDeductible.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))

                'oGarageLookupData = Nothing
                lblMessage.Visible = False
                Label1.Visible = False
                ' changes on 11 June 09 start
                If ddlDealerPlates.SelectedItem.Text.ToUpper.ToString = "SELECT IF YOU WANT" Or ddlDealerPlates.SelectedIndex = 0 Then
                    txtpip.Enabled = False
                    txtpip.Text = ""
                    ddlReject.Enabled = False
                    ddlReject.SelectedIndex = 0
                Else
                    txtpip.Enabled = True
                    txtpip.Text = ""
                    ddlReject.Enabled = True
                    ddlReject.SelectedIndex = 0
                End If
                ' changes on 11 June 09 end
            Catch ex As Exception
                lblMessage.Visible = True
                Label1.Visible = True

                Label1.Visible = True
                lblMessage.Text = ".NET Exception: " & ex.Message
                logger.Info(lblMessage.Text)
                Label1.Text = lblMessage.Text
            End Try
        End If
        'Following fills Reject
        'ddlReject.Items.Clear()
        'ddlReject.DataSource = oGarageLookupData.getLookup(2)
        'ddlReject.DataTextField = "Value"
        'ddlReject.DataValueField = "ID"
        'ddlReject.DataBind()
        'ddlReject.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
        Dim intcount As Integer = oGarageLookupData.getLookup(2).Count
        If txtState.Text = "FL" Then

            If ddlReject.Items.FindByValue(9999) Is Nothing Then
                ddlReject.Items.Insert(intcount, New System.Web.UI.WebControls.ListItem("10,000", "9999"))
            End If
        Else
            'ddlReject.Items.Clear()
            'ddlReject.DataSource = oGarageLookupData.getLookup(2)
            'ddlReject.DataTextField = "Value"
            'ddlReject.DataValueField = "ID"
            'ddlReject.DataBind()
            'ddlReject.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
        End If


        If txtState.Text.ToUpper.ToString = "FL" Then
            dealertags.Visible = True
            Trpip.Visible = True
            trVehicleCoverage.Visible = True
        End If



        logger.Debug("Exiting CreateQuote.Page_Load")
    End Sub
    ''' <summary>
    ''' called by selection of Years in Business option
    ''' this is Insurance History panel enabled/disabled based on whether business
    ''' is new or has a history
    ''' </summary>
    ''' <param name="blnAction"></param>
    ''' <remarks></remarks>
    Private Sub EnableDisableInsuranceHistory(ByVal blnAction As Boolean)
        logger.Debug("Entering CreateQuote.EnableDisableInsuranceHistory")
        rdoPrePolicyCnNo.Enabled = blnAction
        rdoPrePolicyCnYes.Enabled = blnAction
        rdoPrePolicyNonRenewedNo.Enabled = blnAction
        rdoPrePolicyNonRenewedYes.Enabled = blnAction

        txtMplPolicyCancelledDetails.Enabled = blnAction
        txtMplPolicyNotRenewalDetail.Enabled = blnAction

        txtTermFrom1.Enabled = blnAction
        txtTermto1.Enabled = blnAction
        txtCarrier1.Enabled = blnAction
        txtAmtpaid1.Enabled = blnAction
        txtMplDetails1.Enabled = blnAction

        txtTermFrom2.Enabled = blnAction
        txtTermto2.Enabled = blnAction
        txtCarrier2.Enabled = blnAction
        txtAmtpaid2.Enabled = blnAction
        txtMplDetails2.Enabled = blnAction

        txtTermFrom3.Enabled = blnAction
        txtTermto3.Enabled = blnAction
        txtCarrier3.Enabled = blnAction
        txtAmtpaid3.Enabled = blnAction
        txtMplDetails3.Enabled = blnAction

        logger.Debug("Exiting CreateQuote.EnableDisableInsuranceHistory")
    End Sub
    ''' <summary>
    ''' Years in Business selection change event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlYearsInBusiness_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYearsInBusiness.SelectedIndexChanged
        If ddlYearsInBusiness.SelectedItem.Text = "New Venture" Then
            'EnableDisableInsuranceHistory(False)
            pnlInsuranceHistory.Visible = 0
            trYrsExp.Visible = True
        Else
            'EnableDisableInsuranceHistory(True)
            pnlInsuranceHistory.Visible = 1
            trYrsExp.Visible = False
        End If
        ddlYearsInBusiness.Focus()


    End Sub
    Private Function CreateNameAge(name As String, age As String) As String
        Return "{" + name + "," + age + "}"
    End Function
    ''' <summary>
    ''' after validating all inputs assigns input-values to its respective Object Classes
    ''' these object classes are passed for Data entry, when values are assigned.
    ''' after the data entry PDF file is generated, mail is sent to the agent and finally IDX file is created
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Me.txtMplDriversNameAge.Text = CreateNameAge(inputOwnerName.Text, inputOwnerAge.Text)
        Me.txtMplOwnerSpouseNameAge.Text = CreateNameAge(inputSpouseName.Text, inputSpouseAge.Text)

        Dim sb As StringBuilder = New StringBuilder()
        For index = 1 To CInt(Me.tbDriverCount.Text)
            Dim nameTb As TextBox = Me.FindControl("inputDriverName" + CStr(index))
            Dim ageTb As TextBox = Me.FindControl("inputDriverAge" + CStr(index))
            sb.Append(CreateNameAge(nameTb.Text, ageTb.Text))
        Next
        Me.txtMplDriversNameAge.Text = sb.ToString()

        Dim sb2 As StringBuilder = New StringBuilder()
        For index = 1 To CInt(Me.tbDriverCount.Text)
            Dim nameTb As TextBox = Me.FindControl("inputEmployeeName" + CStr(index))
            Dim ageTb As TextBox = Me.FindControl("inputEmployeeAge" + CStr(index))
            sb2.Append(CreateNameAge(nameTb.Text, ageTb.Text))
        Next
        Me.txtMplEmployeeNameAge.Text = sb2.ToString()

        Dim sb3 As StringBuilder = New StringBuilder()
        For index = 1 To CInt(Me.tbDriverCount.Text)
            Dim nameTb As TextBox = Me.FindControl("inputDriverName" + CStr(index))
            Dim ageTb As TextBox = Me.FindControl("inputDriverAge" + CStr(index))
            sb3.Append(CreateNameAge(nameTb.Text, ageTb.Text))
        Next
        Me.txtMplPersonFurnishedAutoName.Text = sb3.ToString()

        logger.Debug("Entering CreateQuote.btnSubmit_Click")
        If Not chkValidations() Then
            Exit Sub
        End If
        Page.Validate()
        If (Page.IsValid = False) Then
            Exit Sub
        End If
        System.Threading.Thread.Sleep(5000)
        Dim strGarageQuoteNumber As String = String.Empty

        Dim objGenericIEntity As New GenericCollection(Of IEntity)
        Dim objDummyGenericIEntity As New GenericCollection(Of IEntity)

        Dim objQuoteDataCol As New GenericCollection(Of IEntity)
        Dim objOperationCol As New GenericCollection(Of IEntity)
        Dim objCoverageCol As New GenericCollection(Of IEntity)
        Dim objInsuranceHistroyCol As New GenericCollection(Of IEntity)
        Dim objInsuranceLossHistroyCol As New GenericCollection(Of IEntity)
        Dim objPersonCol As New GenericCollection(Of IEntity)
        Dim objAdditionnotes As New GenericCollection(Of IEntity)

        Dim objQuote As IEntity
        Dim objDMGarageQuote As New GarageQuoteDataModel
        Try
            objQuote = New GarageQuote

            CType(objQuote, GarageQuote).AgentID = lblAgency.Text.Trim
            CType(objQuote, GarageQuote).ApplicantName = txtApplicantName.Text
            CType(objQuote, GarageQuote).Contact = txtContact.Text
            CType(objQuote, GarageQuote).County = txtCounty.Text
            If ddlReplyOptions.SelectedItem.Text = "Email" Then
                CType(objQuote, GarageQuote).Email = txtemail.Text
                CType(objQuote, GarageQuote).Fax = ""
            Else
                CType(objQuote, GarageQuote).Email = ""
                CType(objQuote, GarageQuote).Fax = txtFaxNo.Text
            End If

            CType(objQuote, GarageQuote).GarageQuoteID = "-1"
            CType(objQuote, GarageQuote).GarageQuoteNumber = String.Empty
            CType(objQuote, GarageQuote).Phone = txtPhone.Text
            CType(objQuote, GarageQuote).State = txtState.Text
            CType(objQuote, GarageQuote).ZIP = txtZIP.Text
            CType(objQuote, GarageQuote).TradeName = txtTradeName.Text
            CType(objQuote, GarageQuote).AdditionalNotes = txtAdditionalNotes.Text
            CType(objQuote, GarageQuote).CreatedORModifiedBY = lblAgencyName.Text
            CType(objQuote, GarageQuote).CreatedORModifiedDate = Format(Now, "MM/dd/yyyy")
            CType(objQuote, GarageQuote).ParentQuoteID = txtGQID.Text.Trim

            logger.Info("Garage Quote is being submitted for Applicant Name : " & txtApplicantName.Text & vbCrLf & _
          " Trade Name : " & txtTradeName.Text & vbCrLf & _
            " Garage Address : " & txtgaragingadd.Text & vbCrLf & _
           " City Name : " & txtcity.Text & vbCrLf & _
            " ZIP code : " & txtZIP.Text)

            If txtUnderwriteName.Visible = True Then

                CType(objQuote, GarageQuote).UnderwriterName = txtUnderwriteName.Text.Trim()
                logger.Info("Underwriter Name : " & txtUnderwriteName.Text.Trim())
            End If

            If txtuwemail.Visible = True Then

                CType(objQuote, GarageQuote).UnderwriterEmail = txtuwemail.Text.Trim()
                logger.Info("Underwriter email : " & txtuwemail.Text.Trim())
            End If

            objGenericIEntity.Add(objQuote)
            objQuote.Id = objDMGarageQuote.Save(objGenericIEntity)
            objDummyGenericIEntity.Add(objQuote)
            objGenericIEntity.Clear()
            objQuoteDataCol.Add(objQuote)

            strGarageQuoteNumber = objDMGarageQuote.getGarageQuoteNo(objQuote.Id)

            If txtGQID.Text.Trim <> "0" Then
                lblParentQuoteNo.Text = objDMGarageQuote.getGarageQuoteNo(txtGQID.Text.Trim)
                'fldParentQuote.Visible = True
            Else : lblParentQuoteNo.Text = ""
                'fldParentQuote.Visible = False
            End If
            txtGQID.Text = objQuote.Id
        Catch ex As Exception
            lblMessage.Text = "Error occurred while saving Quote"
            logger.Info(lblMessage.Text)
            logger.Error("Exception occurred while saving QuoteDetails", ex)
            logger.Error("Exception Details" & ex.StackTrace)
            Exit Sub
        Finally
            objDMGarageQuote = Nothing
        End Try

        'Following saves GarageOperation record
        Dim objOperation As IEntity
        Dim objDMGarageOperation As New GarageOperationsDataModel
        Try
            objOperation = New GarageOperations

            If rdoCorporation.Checked Then CType(objOperation, GarageOperations).BusinessType = "Corporation"
            If rdoIndivudual.Checked Then CType(objOperation, GarageOperations).BusinessType = "Individual"
            If rdoPartnerShip.Checked Then CType(objOperation, GarageOperations).BusinessType = "PartnerShip"
            CType(objOperation, GarageOperations).DollieOrTrailerDetails = txtMplDollie.Text
            CType(objOperation, GarageOperations).FurnishedAutoDetails = txtMplPersonFurnishedAutoName.Text
            CType(objOperation, GarageOperations).GarageOperationId = "-1"
            CType(objOperation, GarageOperations).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
            If rdTowBarDollieTrailerYes.Checked Then CType(objOperation, GarageOperations).HasDollieOrTrailer = 1
            If rdTowBarDollieTrailerNo.Checked Then CType(objOperation, GarageOperations).HasDollieOrTrailer = 0
            If rdOwnRollbackYes.Checked Then CType(objOperation, GarageOperations).HasRollback = 1
            If rdOwnRollbackNo.Checked Then CType(objOperation, GarageOperations).HasRollback = 0
            If rdOwnWreckerYes.Checked Then CType(objOperation, GarageOperations).HasWrecker = 1
            If rdOwnWreckerNo.Checked Then CType(objOperation, GarageOperations).HasWrecker = 0
            If rdoGarageOperationOtherLocationYes.Checked Then CType(objOperation, GarageOperations).OperateOtherLocation = 1
            If rdoGarageOperationOtherLocationNo.Checked Then CType(objOperation, GarageOperations).OperateOtherLocation = 0
            If rdoOperateSalvageYardYes.Checked Then CType(objOperation, GarageOperations).OperateSalvageYard = 1
            If rdoOperateSalvageYardNo.Checked Then CType(objOperation, GarageOperations).OperateSalvageYard = 0
            If rdOtherBusinessOperationYes.Checked Then CType(objOperation, GarageOperations).otherBusinessOperation = 1
            If rdOtherBusinessOperationNo.Checked Then CType(objOperation, GarageOperations).otherBusinessOperation = 0
            If rdAutoPartsYes.Checked Then CType(objOperation, GarageOperations).SellAutoParts = 1
            If rdAutoPartsNo.Checked Then CType(objOperation, GarageOperations).SellAutoParts = 0
            CType(objOperation, GarageOperations).SellPercentage = IIf(txtSellPercentage.Text.Trim = "", "0", txtSellPercentage.Text.Trim)

            CType(objOperation, GarageOperations).GarageAddress = txtgaragingadd.Text.Trim
            CType(objOperation, GarageOperations).City = txtcity.Text.Trim

            CType(objOperation, GarageOperations).YearsInsured = txtyrsinsured.Text.Trim

            'CType(objOperation, GarageOperations).YrsInBusiness = ddlYearsInBusiness.SelectedItem.Value
            'If ddlYearsInBusiness.SelectedItem.Text = "New Venture" Then CType(objOperation, GarageOperations).YrsExperience_NewVenture = txtYrExp.Text
            If ddlYearsInBusiness.SelectedItem.Text = "New Venture" Then
                CType(objOperation, GarageOperations).YrsInBusiness = txtYrExp.Text
                CType(objOperation, GarageOperations).YrsExperience_NewVenture = ddlYearsInBusiness.SelectedItem.Value
            Else
                CType(objOperation, GarageOperations).YrsInBusiness = 0
                CType(objOperation, GarageOperations).YrsExperience_NewVenture = ddlYearsInBusiness.SelectedItem.Value
            End If

            ''CType(objOperation, GarageOperations).YrsInBusiness = ddlYearsInBusiness.SelectedItem.Value
            ''If ddlYearsInBusiness.SelectedItem.Text = "New Venture" Then CType(objOperation, GarageOperations).YrsExperience_NewVenture = txtYrExp.Text


            Dim clsIO As New InsuredOperation
            clsIO.OperationDetails = txtMplOperations.Text
            Dim objGInsuredOprations As New GenericCollection(Of InsuredOperation)
            objGInsuredOprations.Add(clsIO)
            CType(objOperation, GarageOperations).InsuredOperations = objGInsuredOprations
            'CType(CType(objOperation, GarageOperations).InsuredOperations.Item(0), InsuredOperation).OperationDetails = txtMplOperations.Text

            Dim clsOB As New OtherBusiness
            clsOB.OtherBusinessDetail = txtMplOtherBusiness.Text
            Dim objGOtherBusinesses As New GenericCollection(Of OtherBusiness)
            objGOtherBusinesses.Add(clsOB)
            CType(objOperation, GarageOperations).OtherBusinesses = objGOtherBusinesses
            'CType(CType(objOperation, GarageOperations).OtherBusinesses.Item(0), OtherBusiness).OtherBusinessDetail = txtMplOtherBusiness.Text

            Dim clsOL As New OtherLocation
            clsOL.OperationLocation = txtMplOtherLocations.Text
            Dim objGOtherLocations As New GenericCollection(Of OtherLocation)
            objGOtherLocations.Add(clsOL)
            CType(objOperation, GarageOperations).OtherLocations = objGOtherLocations
            'CType(CType(objOperation, GarageOperations).OtherLocations.Item(0), OtherLocation).OperationLocation = txtMplOtherLocations.Text

            objGenericIEntity.Add(objOperation)
            objOperation.Id = objDMGarageOperation.Save(objGenericIEntity)
            objDummyGenericIEntity.Add(objOperation)
            objOperationCol.Add(objOperation)
            objGenericIEntity.Clear()
        Catch ex As Exception
            lblMessage.Text = "Error occurred while saving Quote"
            logger.Info(lblMessage.Text)
            logger.Error("Exception occurred while saving QuoteDetails- Operation Details", ex)
            logger.Error("Exception Details" & ex.StackTrace)
            Exit Sub
        Finally
            objDMGarageOperation = Nothing
        End Try

        'Following saves Coverage record
        Dim objCoverage As IEntity
        Dim objDMCoverage As New CoverageDetailDataModel
        Try
            objCoverage = New CoverageDetail

            If chkDirectPrimary.Checked Then CType(objCoverage, CoverageDetail).IsDirectPrimary = 1
            If chkLegalLiability.Checked Then CType(objCoverage, CoverageDetail).IsLegalLiability = 1
            If rdoChianed.Checked Then CType(objCoverage, CoverageDetail).IsLotChained = 1
            If rdoFenced.Checked Then CType(objCoverage, CoverageDetail).IsLotFenced = 1
            If rdoLightedYes.Checked Then CType(objCoverage, CoverageDetail).IsLotLightedNight = 1
            If rdoLightedNo.Checked Then CType(objCoverage, CoverageDetail).IsLotLightedNight = 0
            If rdoOpen.Checked Then CType(objCoverage, CoverageDetail).IsLotOpen = 1
            'If chkReject.Checked Then CType(objCoverage, CoverageDetail).IsUninsuredMotorist = 1
            CType(objCoverage, CoverageDetail).LiabiltyLimit = ddlGarageLimit.SelectedItem.Text
            CType(objCoverage, CoverageDetail).MedPayLimit = ddlMedPay.SelectedItem.Text
            CType(objCoverage, CoverageDetail).NoofDealerPlates = IIf(IsNumeric(ddlDealerPlates.SelectedItem.Value), ddlDealerPlates.SelectedItem.Value, 0.0)
            CType(objCoverage, CoverageDetail).OperationRadius = ddlRadius.SelectedItem.Text
            If chkGarageKeeperCoverage.Checked Then
                CType(objCoverage, CoverageDetail).IsKeeperCoverage = True
                CType(objCoverage, CoverageDetail).Deductible = ddlGKLLDeductible.SelectedItem.Text
                CType(objCoverage, CoverageDetail).MaxLimitPerUnit = IIf(IsNumeric(txtMaxLimitperUnit1.Text), txtMaxLimitperUnit1.Text, 0.0)
                CType(objCoverage, CoverageDetail).ValuePerLot = IIf(IsNumeric(GKLLTotalValueperLot.Text), GKLLTotalValueperLot.Text.Trim, 0.0)
                If chkGKLLCollision.Checked Then CType(objCoverage, CoverageDetail).IsCollision = 1
                If chkGKLLComprehensive.Checked Then CType(objCoverage, CoverageDetail).IsComprehensive = 1
                If chkGKLLSpecifiedPerils.Checked Then CType(objCoverage, CoverageDetail).IsPerils = 1
            Else
                CType(objCoverage, CoverageDetail).IsKeeperCoverage = False
            End If
            If chkPhyDamageCoverage.Checked Then
                CType(objCoverage, CoverageDetail).IsPhysicalCoverage = True

                CType(objCoverage, CoverageDetail).PhysicalDeductible = ddlDealerPhyDamDeductible.SelectedItem.Text
                CType(objCoverage, CoverageDetail).PhysicalMaxUnitPerLimit = IIf(IsNumeric(txtDealersPhyDamMaxLimitanyUnit.Text), txtDealersPhyDamMaxLimitanyUnit.Text.Trim, 0.0)
                CType(objCoverage, CoverageDetail).PhysicalValuePerLot = IIf(IsNumeric(txtDealerPhyDamTotalValueperLot.Text), txtDealerPhyDamTotalValueperLot.Text.Trim, 0.0)
                If chkGKLLCollision1.Checked Then CType(objCoverage, CoverageDetail).PhysicalIsCollision = 1
                If chkGKLLComprehensive1.Checked Then CType(objCoverage, CoverageDetail).PhysicalIsComprehensive = 1
                If chkGKLLSpecifiedPerils1.Checked Then CType(objCoverage, CoverageDetail).PhysicalIsPerils = 1
            Else
                CType(objCoverage, CoverageDetail).IsPhysicalCoverage = False
            End If
            CType(objCoverage, CoverageDetail).Reject = ddlReject.SelectedItem.Text
            CType(objCoverage, CoverageDetail).CoverageId = "-1"
            CType(objCoverage, CoverageDetail).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
            If CType(objQuote, GarageQuote).State.ToUpper = "FL" Then
                CType(objCoverage, CoverageDetail).NoOfDealerTags = txtnumtags.Text
                CType(objCoverage, CoverageDetail).PIP = txtpip.Text
            End If
            objGenericIEntity.Add(objCoverage)
            objCoverage.Id = objDMCoverage.Save(objGenericIEntity)
            objDummyGenericIEntity.Add(objCoverage)
            objCoverageCol.Add(objCoverage)
            objGenericIEntity.Clear()
        Catch ex As Exception
            lblMessage.Text = "Error occurred while saving Quote"
            logger.Info(lblMessage.Text)
            logger.Error("Exception occurred while saving QuoteDetails- Coverage Details", ex)
            logger.Error("Exception Details" & ex.StackTrace)
            Exit Sub
        Finally
            objDMCoverage = Nothing
        End Try
        'Following saves GaragePersonal record
        Dim objPerson As IEntity
        Dim objDMPerson As New GaragePersonalDetailDataModel
        Try
            objPerson = New GaragePerson

            CType(objPerson, GaragePerson).GaragePersonId = "-1"
            CType(objPerson, GaragePerson).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
            If rdAnyChildreninHouseYes.Checked Then CType(objPerson, GaragePerson).IsChildHouseHold = 1
            If rdAnyChildreninHouseNo.Checked Then CType(objPerson, GaragePerson).IsChildHouseHold = 0
            CType(objPerson, GaragePerson).PersonFurnishedAutos = txtMplPersonFurnishedAutoName.Text
            CType(objPerson, GaragePerson).DriverNameAge = txtMplDriversNameAge.Text
            CType(objPerson, GaragePerson).EmployeeNameAge = txtMplEmployeeNameAge.Text

            CType(objPerson, GaragePerson).NameAge = txtMplOwnerSpouseNameAge.Text
            CType(objPerson, GaragePerson).AllAges = txtMplChildrenAges.Text
            CType(objPerson, GaragePerson).Comments = txtMplComments.Text

            objGenericIEntity.Add(objPerson)
            objPerson.Id = objDMPerson.Save(objGenericIEntity)
            objDummyGenericIEntity.Add(objPerson)
            objPersonCol.Add(objPerson)
            objGenericIEntity.Clear()
        Catch ex As Exception
            lblMessage.Text = "Error occurred while saving Quote"
            logger.Info(lblMessage.Text)
            logger.Error("Exception occurred while saving QuoteDetails", ex)
            logger.Error("Exception Details" & ex.StackTrace)
            Exit Sub
        Finally
            objDMPerson = Nothing
        End Try

        Dim objInsuranceHistory As IEntity
        Dim objInsuranceLossHistory1 As IEntity
        Dim objInsuranceLossHistory2 As IEntity
        Dim objInsuranceLossHistory3 As IEntity
        If ddlYearsInBusiness.SelectedItem.Text <> "New Venture" Then
            'Following saves Insurance History record
            Dim objDMIH As New InsuranceHistoryDataModel
            Try
                objInsuranceHistory = New InsuranceHistory

                CType(objInsuranceHistory, InsuranceHistory).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
                CType(objInsuranceHistory, InsuranceHistory).InsuranceHistoryId = "-1"
                If rdoPrePolicyCnYes.Checked Then CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyCancelled = 1
                If rdoPrePolicyCnNo.Checked Then CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyCancelled = 0
                If rdoPrePolicyNonRenewedYes.Checked Then CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyNotRenewed = 1
                If rdoPrePolicyNonRenewedNo.Checked Then CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyNotRenewed = 0
                CType(objInsuranceHistory, InsuranceHistory).NotRenewalDetails = txtMplPolicyNotRenewalDetail.Text
                CType(objInsuranceHistory, InsuranceHistory).CancellationDetails = txtMplPolicyCancelledDetails.Text

                objGenericIEntity.Add(objInsuranceHistory)
                objInsuranceHistory.Id = objDMIH.Save(objGenericIEntity)
                objDummyGenericIEntity.Add(objInsuranceHistory)
                objInsuranceHistroyCol.Add(objInsuranceHistory)
                objGenericIEntity.Clear()
            Catch ex As Exception
                lblMessage.Text = "Error occurred while saving Quote"
                logger.Info(lblMessage.Text)
                logger.Error("Exception occurred while saving QuoteDetails", ex)
                logger.Error("Exception Details" & ex.StackTrace)
                Exit Sub
            Finally
                objDMIH = Nothing
            End Try

            'Following saves Insurance Loss History record
            Dim objDMILH As New InsuranceLossHistoryDataModel
            Try
                If txtTermFrom1.Text <> "" Or txtTermto1.Text <> "" Or txtCarrier1.Text <> "" Or txtAmtpaid1.Text <> "" Then
                    If txtTermFrom1.Text = "" Or txtTermto1.Text = "" Or txtCarrier1.Text = "" Or txtAmtpaid1.Text = "" Then
                        lblMessage.Text = "Fill the entire row of insurance history row 1"
                        logger.Info(lblMessage.Text)
                        lblMessage.Visible = True
                        Label1.Visible = True
                        Label1.Text = lblMessage.Text

                        Return



                    Else


                        objInsuranceLossHistory1 = New InsuranceLossHistory

                        CType(objInsuranceLossHistory1, InsuranceLossHistory).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
                        CType(objInsuranceLossHistory1, InsuranceLossHistory).LossHistoryId = "-1"
                        CType(objInsuranceLossHistory1, InsuranceLossHistory).Amount = IIf(IsNumeric(txtAmtpaid1.Text), txtAmtpaid1.Text.Trim, 0.0)
                        CType(objInsuranceLossHistory1, InsuranceLossHistory).Carrier = txtCarrier1.Text
                        CType(objInsuranceLossHistory1, InsuranceLossHistory).Cover = 0.0
                        CType(objInsuranceLossHistory1, InsuranceLossHistory).Details = txtMplDetails1.Text
                        If txtTermFrom1.Text <> "" Then
                            If txtTermFrom1.Text <> "__/__/____" Then

                                Dim firstpart As String
                                firstpart = ""
                                Dim secpart As String
                                secpart = ""
                                Dim thrdpart As String
                                thrdpart = ""
                                Dim forthpart As String
                                forthpart = ""
                                Dim mon As Integer
                                Dim day As Integer

                                If txtTermFrom1.Text.Contains("/") Then

                                    firstpart = txtTermFrom1.Text.Substring(0, txtTermFrom1.Text.IndexOf("/"))
                                    secpart = txtTermFrom1.Text.Substring(txtTermFrom1.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                                End If
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString

                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txtTermFrom1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else


                                    frmyear1 = ""
                                    frmdate1 = txtTermFrom1.Text
                                    fyear1 = frmdate1.Year
                                    txtTermFrom1.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txtTermFrom1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 < 99 Then
                                        frmyear1 = "20" & fyear1
                                        txtTermFrom1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If


                                End If
                                CType(objInsuranceLossHistory1, InsuranceLossHistory).TermFrom = txtTermFrom1.Text.Trim
                            End If

                        End If
                        If txtTermto1.Text = "" Then
                            lbltoone.Text = ""
                            lbltoone.Visible = False
                        End If
                        If txtTermto1.Text <> "" Then


                            If txtTermto1.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""
                                Dim mon2 As Integer
                                Dim day2 As Integer
                                If txtTermto1.Text.Contains("/") Then

                                    firstpart = txtTermto1.Text.Substring(0, txtTermto1.Text.IndexOf("/"))
                                    secpart = txtTermto1.Text.Substring(txtTermto1.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                mon2 = Convert.ToInt32(firstpart)
                                day2 = Convert.ToInt32(thrdpart)
                                If mon2 >= 1 And mon2 <= 9 Then
                                    firstpart = "0" + mon2.ToString

                                End If
                                If day2 >= 1 And day2 <= 9 Then
                                    thrdpart = "0" + day2.ToString
                                End If
                                If forthpart = "0000" Then
                                    toyear1 = 2000
                                    txtTermto1.Text = firstpart & "/" + thrdpart & "/" + toyear1.ToString
                                    If txtTermFrom1.Text <> "" Then
                                        If frmdate1 >= todate1 Then
                                            lbltoone.Text = "ToDate1 should be greater than From Date1"
                                            lbltoone.Visible = True
                                            Return
                                        Else

                                            lbltoone.Text = ""
                                            lbltoone.Visible = False

                                        End If
                                    End If
                                Else
                                    toyear1 = ""
                                    todate1 = txtTermto1.Text
                                    If txtTermFrom1.Text <> "" Then
                                        frmdate1 = txtTermFrom1.Text
                                    End If

                                    tyear1 = todate1.Year
                                    txtTermto1.Text = firstpart & "/" + thrdpart & "/" + tyear1.ToString
                                    If tyear1 >= 1 And tyear1 <= 9 Then
                                        toyear1 = "200" & tyear1
                                        txtTermto1.Text = firstpart & "/" + thrdpart & "/" + toyear1.ToString
                                    End If

                                    If tyear1 > 9 And tyear1 <= 99 Then
                                        toyear1 = "20" & tyear1
                                        txtTermto1.Text = firstpart & "/" + thrdpart & "/" + toyear1.ToString
                                    End If
                                    todate1 = txtTermto1.Text
                                    If txtTermFrom1.Text <> "" Then
                                        If frmdate1 >= todate1 Then
                                            lbltoone.Text = "ToDate1 should be greater than From Date1"
                                            lbltoone.Visible = True
                                            Return
                                        Else

                                            lbltoone.Text = ""
                                            lbltoone.Visible = False

                                        End If
                                    End If

                                    CType(objInsuranceLossHistory1, InsuranceLossHistory).TermTo = txtTermto1.Text.Trim
                                End If
                            End If
                        End If
                        'CType(objInsuranceLossHistory1, InsuranceLossHistory).TermFrom = IIf(IsDate(txtTermFrom1.Text), txtTermFrom1.Text.Trim, Format(DateAdd(DateInterval.Day, -1, Today), "MM/dd/yyyy"))
                        'CType(objInsuranceLossHistory1, InsuranceLossHistory).TermTo = IIf(IsDate(txtTermto1.Text), txtTermto1.Text.Trim, Format(DateAdd(DateInterval.Day, 1, Today), "MM/dd/yyyy"))

                        objGenericIEntity.Add(objInsuranceLossHistory1)
                        Dim val As Integer = objDMILH.Save(objGenericIEntity)
                        objDummyGenericIEntity.Add(objInsuranceLossHistory1)
                        objInsuranceLossHistroyCol.Add(objInsuranceLossHistory1)
                        objGenericIEntity.Clear()
                    End If

                End If

                If txtTermFrom2.Text <> "" Or txtTermto2.Text <> "" Or txtCarrier2.Text <> "" Or txtAmtpaid2.Text <> "" Then
                    If txtTermFrom2.Text = "" Or txtTermto2.Text = "" Or txtCarrier2.Text = "" Or txtAmtpaid2.Text = "" Then
                        lblMessage.Text = "Fill the entire row of insurance history row 2"
                        logger.Info(lblMessage.Text)
                        lblMessage.Visible = True
                        Label1.Visible = True
                        Label1.Text = lblMessage.Text
                        Return



                    Else

                        'objInsuranceLossHistory = Nothing

                        objInsuranceLossHistory2 = New InsuranceLossHistory
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).LossHistoryId = "-1"
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).Amount = IIf(IsNumeric(txtAmtpaid2.Text), txtAmtpaid2.Text.Trim, 0.0)
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).Carrier = txtCarrier2.Text
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).Cover = 0.0
                        CType(objInsuranceLossHistory2, InsuranceLossHistory).Details = txtMplDetails2.Text
                        'CType(objInsuranceLossHistory2, InsuranceLossHistory).TermFrom = txtTermFrom2.Text.Trim 'IIf(IsDate(txtTermFrom2.Text), txtTermFrom2.Text.Trim, Format(DateAdd(DateInterval.Day, -1, Today), "MM/dd/yyyy"))
                        'CType(objInsuranceLossHistory2, InsuranceLossHistory).TermTo = txtTermto2.Text.Trim 'IIf(IsDate(txtTermto2.Text), txtTermto2.Text.Trim, Format(DateAdd(DateInterval.Day, 1, Today), "MM/dd/yyyy"))
                        If txtTermFrom2.Text <> "" Then


                            If txtTermFrom2.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""
                                Dim mon As Integer
                                Dim day As Integer

                                If txtTermFrom2.Text.Contains("/") Then

                                    firstpart = txtTermFrom2.Text.Substring(0, txtTermFrom2.Text.IndexOf("/"))
                                    secpart = txtTermFrom2.Text.Substring(txtTermFrom2.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                                End If
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString

                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString

                                End If
                                If forthpart = "0000" Then
                                    frmyear2 = 2000
                                    txtTermFrom2.Text = firstpart & "/" + thrdpart & "/" + frmyear2.ToString
                                Else
                                    frmyear2 = ""
                                    frmdate2 = txtTermFrom2.Text
                                    frmyear2 = frmdate2.Year
                                    txtTermFrom2.Text = firstpart & "/" + thrdpart & "/" + frmyear2.ToString
                                    If fyear2 >= 1 And fyear2 <= 9 Then
                                        frmyear2 = "200" & fyear2
                                        txtTermFrom2.Text = firstpart & "/" + thrdpart & "/" + frmyear2.ToString
                                    End If
                                    If fyear2 > 9 And fyear2 < 99 Then
                                        frmyear2 = "20" & fyear2
                                        txtTermFrom2.Text = firstpart & "/" + thrdpart & "/" + frmyear2.ToString
                                    End If
                                End If
                                CType(objInsuranceLossHistory2, InsuranceLossHistory).TermFrom = txtTermFrom2.Text.Trim
                            End If
                        End If

                        If txtTermto2.Text = "" Then
                            lbltotwo.Text = ""
                            lbltotwo.Visible = False

                        End If
                        If txtTermto2.Text <> "" Then
                            If txtTermto2.Text <> "__/__/____" Then
                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""
                                Dim mon As Integer
                                Dim day As Integer


                                If txtTermto2.Text.Contains("/") Then

                                    firstpart = txtTermto2.Text.Substring(0, txtTermto2.Text.IndexOf("/"))
                                    secpart = txtTermto2.Text.Substring(txtTermto2.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                                End If
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString

                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString

                                End If
                                If forthpart = "0000" Then
                                    toyear2 = 2000
                                    txtTermto2.Text = firstpart & "/" + thrdpart & "/" + toyear2.ToString

                                    If txtTermFrom2.Text <> "" Then
                                        If frmdate2 >= todate2 Then
                                            lbltotwo.Text = "ToDate2 should be greater than From Date2"
                                            lbltotwo.Visible = True
                                            Return
                                        Else
                                            lbltotwo.Text = ""
                                            lbltotwo.Visible = False


                                        End If
                                    End If
                                Else
                                    toyear2 = ""
                                    todate2 = txtTermto2.Text
                                    If txtTermFrom2.Text <> "" Then
                                        frmdate2 = txtTermFrom2.Text
                                    End If

                                    tyear2 = todate2.Year
                                    txtTermto2.Text = firstpart & "/" + thrdpart & "/" + tyear2.ToString
                                    If tyear2 >= 1 And tyear2 <= 9 Then
                                        toyear2 = "200" & tyear2
                                        txtTermto2.Text = firstpart & "/" + thrdpart & "/" + toyear2.ToString
                                    End If

                                    If tyear2 > 9 And tyear2 <= 99 Then
                                        toyear2 = "20" & tyear2
                                        txtTermto2.Text = firstpart & "/" + thrdpart & "/" + toyear2.ToString
                                    End If
                                    todate2 = txtTermto2.Text
                                    If txtTermFrom2.Text <> "" Then
                                        If frmdate2 >= todate2 Then
                                            lbltotwo.Text = "ToDate2 should be greater than From Date2"
                                            lbltotwo.Visible = True
                                            Return
                                        Else
                                            lbltotwo.Text = ""
                                            lbltotwo.Visible = False


                                        End If
                                    End If

                                    CType(objInsuranceLossHistory2, InsuranceLossHistory).TermTo = txtTermto2.Text.Trim
                                End If
                            End If
                        End If


                        objGenericIEntity.Add(objInsuranceLossHistory2)
                        Dim val2 As Integer = objDMILH.Save(objGenericIEntity)
                        objDummyGenericIEntity.Add(objInsuranceLossHistory2)
                        objInsuranceLossHistroyCol.Add(objInsuranceLossHistory2)
                        objGenericIEntity.Clear()
                    End If

                End If

                'objInsuranceLossHistory = Nothing
                If txtTermFrom3.Text <> "" Or txtTermto3.Text <> "" Or txtCarrier3.Text <> "" Or txtAmtpaid3.Text <> "" Then
                    If txtTermFrom3.Text = "" Or txtTermto3.Text = "" Or txtCarrier3.Text = "" Or txtAmtpaid3.Text = "" Then
                        lblMessage.Text = "Fill the entire row of insurance history row 3"
                        logger.Info(lblMessage.Text)
                        lblMessage.Visible = True
                        Label1.Visible = True
                        Label1.Text = lblMessage.Text
                        Return



                    Else


                        objInsuranceLossHistory3 = New InsuranceLossHistory
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).LossHistoryId = "-1"
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).Amount = IIf(IsNumeric(txtAmtpaid3.Text), txtAmtpaid3.Text.Trim, 0.0)
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).Carrier = txtCarrier3.Text
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).Cover = 0.0
                        CType(objInsuranceLossHistory3, InsuranceLossHistory).Details = txtMplDetails3.Text
                        'CType(objInsuranceLossHistory3, InsuranceLossHistory).TermFrom = IIf(IsDate(txtTermFrom3.Text), txtTermFrom3.Text.Trim, Format(DateAdd(DateInterval.Day, -1, Today), "MM/dd/yyyy"))
                        'CType(objInsuranceLossHistory3, InsuranceLossHistory).TermTo = IIf(IsDate(txtTermto3.Text), txtTermto3.Text.Trim, Format(DateAdd(DateInterval.Day, 1, Today), "MM/dd/yyyy"))


                        If txtTermFrom3.Text <> "" Then
                            If txtTermFrom3.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                Dim mon As Integer
                                Dim day As Integer
                                If txtTermFrom3.Text.Contains("/") Then

                                    firstpart = txtTermFrom3.Text.Substring(0, txtTermFrom3.Text.IndexOf("/"))
                                    secpart = txtTermFrom3.Text.Substring(txtTermFrom3.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                                End If
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString

                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString

                                End If
                                If forthpart = "0000" Then
                                    frmyear3 = 2000
                                    txtTermFrom3.Text = firstpart & "/" + thrdpart & "/" + frmyear3.ToString
                                Else
                                    frmyear3 = ""
                                    frmdate3 = txtTermFrom3.Text
                                    fyear3 = frmdate3.Year
                                    txtTermFrom3.Text = firstpart & "/" + thrdpart & "/" + fyear3.ToString
                                    If fyear3 >= 1 And fyear3 <= 9 Then
                                        frmyear3 = "200" & fyear3
                                        txtTermFrom3.Text = firstpart & "/" + thrdpart & "/" + frmyear3.ToString
                                    End If
                                    If fyear3 > 9 And fyear3 < 99 Then
                                        frmyear3 = "20" & fyear3
                                        txtTermFrom3.Text = firstpart & "/" + thrdpart & "/" + frmyear3.ToString
                                    End If


                                End If
                                CType(objInsuranceLossHistory3, InsuranceLossHistory).TermFrom = txtTermFrom3.Text.Trim
                            End If
                        End If
                        If txtTermto3.Text = "" Then
                            lbltothree.Text = ""
                            lbltothree.Visible = False
                        End If
                        If txtTermto3.Text <> "" Then
                            If txtTermto3.Text <> "__/__/____" Then
                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                Dim mon As Integer
                                Dim day As Integer
                                If txtTermto3.Text.Contains("/") Then

                                    firstpart = txtTermto3.Text.Substring(0, txtTermto3.Text.IndexOf("/"))
                                    secpart = txtTermto3.Text.Substring(txtTermto3.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                                End If
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString

                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString

                                End If
                                If forthpart = "0000" Then
                                    toyear3 = 2000
                                    txtTermto3.Text = firstpart & "/" + thrdpart & "/" + toyear3.ToString
                                    If txtTermFrom3.Text <> "" Then
                                        If frmdate3 >= todate3 Then
                                            lbltothree.Text = "ToDate3 should be greater than From Date3"
                                            lbltothree.Visible = True
                                            Return
                                        Else
                                            lbltothree.Text = ""
                                            lbltothree.Visible = False

                                        End If
                                    End If
                                Else
                                    toyear3 = ""
                                    todate3 = txtTermto3.Text
                                    If txtTermFrom3.Text <> "" Then
                                        frmdate3 = txtTermFrom3.Text
                                    End If

                                    tyear3 = todate3.Year
                                    txtTermto3.Text = firstpart & "/" + thrdpart & "/" + tyear3.ToString
                                    If tyear3 >= 1 And tyear3 <= 9 Then
                                        toyear3 = "200" & tyear3
                                        txtTermto3.Text = firstpart & "/" + thrdpart & "/" + toyear3.ToString
                                    End If

                                    If tyear3 > 9 And tyear3 <= 99 Then
                                        toyear3 = "20" & tyear3
                                        txtTermto3.Text = firstpart & "/" + thrdpart & "/" + toyear3.ToString
                                    End If
                                    todate3 = txtTermto3.Text
                                    If txtTermFrom3.Text <> "" Then
                                        If frmdate3 >= todate3 Then
                                            lbltothree.Text = "ToDate3 should be greater than From Date3"
                                            lbltothree.Visible = True
                                            Return
                                        Else
                                            lbltothree.Text = ""
                                            lbltothree.Visible = False

                                        End If
                                    End If

                                    CType(objInsuranceLossHistory3, InsuranceLossHistory).TermTo = txtTermto3.Text.Trim
                                End If
                            End If
                        End If

                        objGenericIEntity.Add(objInsuranceLossHistory3)
                        Dim val3 As Integer = objDMILH.Save(objGenericIEntity)
                        'objInsuranceLossHistory = Nothing
                        objDummyGenericIEntity.Add(objInsuranceLossHistory3)
                        objInsuranceLossHistroyCol.Add(objInsuranceLossHistory3)
                        objGenericIEntity.Clear()

                    End If

                End If

            Catch tex As System.Threading.ThreadAbortException
                'do nothing

            Catch ex As Exception
                lblMessage.Text = "Error occurred while saving Quote"
                logger.Info(lblMessage.Text)
                logger.Error("Exception occurred while saving QuoteDetails", ex)
                logger.Error("Exception Details" & ex.StackTrace)
                Exit Sub
            Finally
                objDMILH = Nothing
            End Try
        End If

        logger.Debug("CreateQuote.btnSubmit_Click: GarageQuoteSheet Submitted in Database.")





        ''''''''Check For Underwriter Or Agent''''''''''''''''


        'If objService.isUnderwriter(IpAddress) = False Then
        '    logger.Debug("CreateQuote.btnSubmit_Click: Entering for creating PDF, mailing the PDF and finally creating IDX file")

        Dim strQuoteNumber As String
        strQuoteNumber = strGarageQuoteNumber.ToString
        logger.Debug("CreateQuote.btnSubmit_Click: Entering for creating PDF")
        Dim objPDF As New PDFCreater
        If Not objPDF.CreateGaragePDF(objQuoteDataCol, objOperationCol, objInsuranceHistroyCol, objInsuranceLossHistroyCol, objCoverageCol, objPersonCol, strQuoteNumber) Then
            logger.Error("Error in Creating PDF")
            lblMessage.Text = "Error occurred while creating pdf"
            logger.Info(lblMessage.Text)
        End If

        'rvig

        'If objService.isUnderwriter(IpAddress) = False Then
        logger.Debug("CreateQuote.btnSubmit_Click: Mailing the PDF and finally creating IDX file")
        lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "GQIDGenerated") & strGarageQuoteNumber 'objQuote.Id.ToString
        logger.Info(lblMessage.Text)
        Dim strAplicantname As String = CType(objQuote, GarageQuote).ApplicantName
        strAplicantname = strAplicantname.ToUpper

        Dim strBusinessName As String
        strBusinessName = CType(objQuote, GarageQuote).TradeName
        strBusinessName = strBusinessName.ToUpper
        If strBusinessName = "" Then
            strBusinessName = strAplicantname
        End If
        If (Convert.ToInt32(ConfigurationManager.AppSettings("VersionID") > 1)) Then
            Dim objWcfImageRightService = New WcfImageRightService.ImageRightServiceClient()
            If strQuoteNumber.Length >= 7 Then strQuoteNumber = strQuoteNumber & "0"

            If strQuoteNumber.Length = 6 Then strQuoteNumber = strQuoteNumber & "00"

            If strQuoteNumber.Length = 5 Then strQuoteNumber = strQuoteNumber & "000"

            If strQuoteNumber.Length = 4 Then strQuoteNumber = strQuoteNumber & "0000"

            If strQuoteNumber.Length = 3 Then strQuoteNumber = strQuoteNumber & "00000"

            If strQuoteNumber.Length = 2 Then strQuoteNumber = strQuoteNumber & "000000"

            If strQuoteNumber.Length = 1 Then strQuoteNumber = strQuoteNumber & "0000000"
            Dim Dictpara As New Dictionary(Of Object, Object)()

            Dictpara.Add("AppID", ConfigurationManager.AppSettings("AppID").ToString())
            Dictpara.Add("AppTaskID", ConfigurationManager.AppSettings("Taskid-btnSubmit_Click").ToString())

            Dictpara.Add("VersionID", ConfigurationManager.AppSettings("VersionID").ToString())

            Dictpara.Add("IMPORTFILENAME", strQuoteNumber + ".Pdf")
            Dictpara.Add("FILENUMBER", strBusinessName)
            Dictpara.Add("FILENAME", strBusinessName)
            Dictpara.Add("PAGEDESCRIPTION", "")
            Dictpara.Add("CategoryID", 0)
            Dim sDate As String = DateTime.Now.ToString("yyyyMMdd")
            Dictpara.Add("DATE", sDate)


            objWcfImageRightService.BuildIdxAssigned(Dictpara)


        Else
            CreateIDXfile(strQuoteNumber, CType(objQuote, GarageQuote).ApplicantName, CType(objQuote, GarageQuote).AgentID)
        End If


        'lblMessage.Visible = True
        'trYrsExp.Visible = True

        ' CreateIDXfile(strQuoteNumber, CType(objQuote, GarageQuote).ApplicantName, CType(objQuote, GarageQuote).AgentID)
        'End If


        'rvig
        'If objService.isUnderwriter(IpAddress) Then

        mail2Agent(strGarageQuoteNumber)
        'end if


        Try
            SaveToAIM()

            Dim strQueryString As String
            Dim strContentUrl As String = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString
            If Not IsNothing(Session("TAG")) Then
                If Session("TAG") = "922HOME" Then
                    strContentUrl = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString
                    strQueryString = "?USR=" & Session("usr").ToString & "&pw=" & Session("pw").ToString & "&LOGIN_ID=" & Session("LOGIN_ID").ToString & "&LOGIN_TYPE=" & Session("LOGIN_TYPE").ToString & "&TAG=" & Session("TAG").ToString
                    Session.Clear()
                    Response.Redirect(strContentUrl & strQueryString)
                End If
                If Session("TAG") = "922HOMEPAGE" Then
                    strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                    strQueryString = "?TITLE=" & Session("TAG").ToString
                    Session.Clear()
                    Response.Redirect(strContentUrl & strQueryString)
                End If
                If Session("TAG") = "SIURATE" Then
                    strContentUrl = ConfigurationManager.AppSettings("SIURateUrl").ToString
                    'strQueryString = "?TITLE=" & Session("TAG").ToString
                    Session.Clear()
                    Response.Redirect(strContentUrl)
                End If
            Else
                Session.Clear()
                ' Response.Redirect("default.aspx")
                mpeConfirm.Show()
            End If

        Catch tex As System.Threading.ThreadAbortException
            'donothing
        Catch ex As Exception
        End Try

        logger.Debug("Exiting CreateQuote.btnSubmit_Click")

    End Sub
    Sub SaveToAIM()
        Dim conn As New SqlConnection(ConfigurationManager.AppSettings("AIMConnectionString"))
        Dim comm As New SqlCommand("InsertIntoAIMFromGarageQuoteSheet", conn)
        Dim rs As SqlDataReader

        Dim Agency As Label = Page.FindControl("lblAgency")
        Dim Applicant As TextBox = Page.FindControl("txtApplicantName")
        Dim TradeName As TextBox = Page.FindControl("txtTradeName")
        Dim Address As TextBox = Page.FindControl("txtgaragingadd")
        Dim City As TextBox = Page.FindControl("txtCity")
        Dim State As TextBox = Page.FindControl("txtState")
        Dim Zip As TextBox = Page.FindControl("txtZIP")

        conn.Open()
        With comm
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@CoverageId", "GAR")
            .Parameters.AddWithValue("@ProductId", "GAR11")
            .Parameters.AddWithValue("@UserId", "")
            .Parameters.AddWithValue("@NamedInsured", Applicant.Text.Trim())
            .Parameters.AddWithValue("@DBAName", TradeName.Text.Trim())
            .Parameters.AddWithValue("@Exposures", "")
            .Parameters.AddWithValue("@ProducerId", Agency.Text.Trim())
            .Parameters.AddWithValue("@Address1", Address.Text.Trim())
            .Parameters.AddWithValue("@City", City.Text.Trim())
            .Parameters.AddWithValue("@State", State.Text.Trim().ToUpper())
            .Parameters.AddWithValue("@Zip", Zip.Text.Trim())
            .Parameters.AddWithValue("@Description", "")
            rs = .ExecuteReader(CommandBehavior.CloseConnection)
            .Dispose()
        End With
    End Sub
    ''' <summary>
    ''' called from Submit button event
    ''' after insertion of record, mail is sent to the agent.
    ''' </summary>
    ''' <param name="GarageQuoteNo"></param>
    ''' <remarks></remarks>
    Private Sub mail2Agent(ByVal GarageQuoteNo As String)
        If InStr(txtemail.Text.Trim, "@") > 0 Then
            Try
                Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
                Dim strBccemailID As String = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPBCC")
                Dim blnInternal As Boolean = objService.isUnderwriter(IpAddress)
                Message.To = txtemail.Text
                If txtuwemail.Text <> "" Then
                    If blnInternal Then
                        Message.Bcc = strBccemailID & ", " & txtuwemail.Text 'comment on 9 sep10 Keith shud get everytime mail with attachment' txtuwemail.Text ' no mail to Kieth  [ bcc to keith mentioned in config file]
                    Else
                        Message.Bcc = strBccemailID & ", " & txtuwemail.Text '"kstephenson@siuins.com"
                    End If

                Else

                    If Not blnInternal Then
                        Message.Bcc = strBccemailID '"kstephenson@siuins.com"
                    End If

                End If

                logger.Debug("BCC email id is : " & Message.Bcc.ToString)
                Message.From = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPFrom")
                Message.Subject = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPSubject")
                Message.Body = "Garage Quote Generated" & vbCrLf & "GarageQuoteNumber is: " & GarageQuoteNo & vbCrLf _
                & "Thank you for your submission, Someone in our transportation division will be contacting you " & vbCrLf _
                 & "within 24 to 48 hours. Should you have any questions, please feel free to give us a call. " & vbCrLf _
                 & vbCrLf & "Thank you again for choosing SIU."


                'Message.Attachments.Add(New MailAttachment("c:\\Chap0101.pdf"))
                'If blnInternal Then ' this condition has been removed on 13 april 2010
                If HttpContext.Current.Session("GarageAttachmentFileName") <> "" Then
                    'Message.Attachments.Add(HttpContext.Current.Session("GarageAttachmentFileName"))
                    Message.Attachments.Add(New MailAttachment(HttpContext.Current.Session("GarageAttachmentFileName").ToString))
                    logger.Debug("MailAttachment has been added")

                End If
                'End If



                Try
                    SmtpMail.SmtpServer = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPServer")
                    logger.Debug("mail is being sent")
                    SmtpMail.Send(Message)
                    logger.Debug("mail has been sent")
                Catch ehttp As System.Web.HttpException
                    lblMessage.Text = ehttp.Message
                    logger.Info(lblMessage.Text)
                    'Console.Write("0", ehttp.ToString())
                End Try
            Catch e As System.Exception
                lblMessage.Text = e.Message
                logger.Info(lblMessage.Text)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' called from Submit button event
    ''' after insertion of record, IDX file is created.
    ''' </summary>
    ''' <param name="pv_GQNo"></param>
    ''' <param name="pv_Aplicantname"></param>
    ''' <param name="pv_AgentLoginID"></param>
    ''' <remarks></remarks>
    Private Sub CreateIDXfile(ByVal pv_GQNo As String, ByVal pv_Aplicantname As String, ByVal pv_AgentLoginID As String)
        Dim strName() As String = pv_Aplicantname.Split(" ")
        Dim FName As String = String.Empty
        Dim LName As String = String.Empty
        If strName.Length > 1 Then
            FName = strName(0).Trim
            For i As Integer = 0 To strName.Length - 1
                LName = LName & strName(i)
            Next
        Else : FName = pv_Aplicantname
        End If
        Dim strQuoteNo As String = pv_GQNo.Trim
        If strQuoteNo.Length = 6 Then strQuoteNo = strQuoteNo & "0"

        If strQuoteNo.Length = 5 Then strQuoteNo = strQuoteNo & "00"

        If strQuoteNo.Length = 4 Then strQuoteNo = strQuoteNo & "000"

        If strQuoteNo.Length = 3 Then strQuoteNo = strQuoteNo & "0000"

        If strQuoteNo.Length = 2 Then strQuoteNo = strQuoteNo & "00000"

        If strQuoteNo.Length = 1 Then strQuoteNo = strQuoteNo & "000000"

        Dim objIDX As New ImageRightFileCreator.ImageWriterImpl
        objIDX.SetConfiguration(xmlCONTEXT, PROPERTIES)
        If txtTradeName.Text.Trim = "" Then
            txtTradeName.Text = pv_Aplicantname
        End If

        If Not objIDX.CreateIDXFile(xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "IDXDeptCode"), strQuoteNo, strQuoteNo, FName, LName, "N", pv_AgentLoginID, "garage", txtTradeName.Text.Trim) Then
            lblMessage.Text = "Error in creating IDX file"
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            logger.Error("Error in creating file for GarageQuoteNumber:" & strQuoteNo)
        End If


    End Sub
    Protected Sub ddlReplyOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReplyOptions.SelectedIndexChanged
        If ddlReplyOptions.SelectedItem.Text = "Fax" Then
            txtFaxNo.Visible = True
            txtemail.Visible = False
            regxvEmailOption.Enabled = False
            regxvFaxOption.Enabled = True
            txtFaxNo.Text = ""
        Else
            txtFaxNo.Visible = False
            txtemail.Visible = True
            regxvFaxOption.Enabled = False
            regxvEmailOption.Enabled = True
            txtemail.Text = ""
        End If
        ddlReplyOptions.Focus()


    End Sub
    ''' <summary>
    ''' called from page load event, when page first time called
    ''' set client scripts to enable/disable text-boxes associated with radio options of Yes/No
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setClientScripts()
        rdAutoPartsNo.Attributes.Add("OnClick", "document.form1.txtSellPercentage.value = ''; document.form1.txtSellPercentage.disabled = true;")
        rdAutoPartsYes.Attributes.Add("OnClick", "document.form1.txtSellPercentage.disabled = false;")
        rdoGarageOperationOtherLocationNo.Attributes.Add("OnClick", "document.form1.txtMplOtherLocations.value = ''; document.form1.txtMplOtherLocations.disabled = true;")
        rdoGarageOperationOtherLocationYes.Attributes.Add("OnClick", "document.form1.txtMplOtherLocations.disabled = false;")
        rdOtherBusinessOperationNo.Attributes.Add("OnClick", "document.form1.txtMplOtherBusiness.value = ''; document.form1.txtMplOtherBusiness.disabled = true;")
        rdOtherBusinessOperationYes.Attributes.Add("OnClick", "document.form1.txtMplOtherBusiness.disabled = false;")
        rdTowBarDollieTrailerNo.Attributes.Add("OnClick", "document.form1.txtMplDollie.value = ''; document.form1.txtMplDollie.disabled = true;")
        rdTowBarDollieTrailerYes.Attributes.Add("OnClick", "document.form1.txtMplDollie.disabled = false;")
        rdAnyChildreninHouseNo.Attributes.Add("OnClick", "document.form1.txtMplChildrenAges.value = ''; document.form1.txtMplChildrenAges.disabled = true;")
        rdAnyChildreninHouseYes.Attributes.Add("OnClick", "document.form1.txtMplChildrenAges.disabled = false;")
        rdoPrePolicyCnNo.Attributes.Add("OnClick", "document.form1.txtMplPolicyCancelledDetails.value = ''; document.form1.txtMplPolicyCancelledDetails.disabled = true;")
        rdoPrePolicyCnYes.Attributes.Add("OnClick", "document.form1.txtMplPolicyCancelledDetails.disabled = false;")
        rdoPrePolicyNonRenewedNo.Attributes.Add("OnClick", "document.form1.txtMplPolicyNotRenewalDetail.value = ''; document.form1.txtMplPolicyNotRenewalDetail.disabled = true;")
        rdoPrePolicyNonRenewedYes.Attributes.Add("OnClick", "document.form1.txtMplPolicyNotRenewalDetail.disabled = false;")
    End Sub
    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub
    ''' <summary>
    ''' this region has validation methods
    ''' called from Submit button click event
    ''' checcks all mandatory input value has been entered or not
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "INPUT VALIDATIONS"
    Private Function chkValidations() As Boolean
        Dim bl As Boolean
        ' bl = chkDates()
        'If bl = False Then
        '    Return False
        'End If
        bl = chkAgentDetails()
        If bl = False Then
            Return False
        End If
        bl = chkOperationDetails()
        If bl = False Then
            Return False
        End If
        bl = chkCoverageDetailsInputs()
        If bl = False Then
            Return False
        End If
        If ddlYearsInBusiness.SelectedValue > 0 Then
            bl = chkInsuranceHistory()
            If bl = False Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Function chkDates() As Boolean
        If txtTermFrom1.Text.Trim <> "" Then
            If Not IsDate(txtTermFrom1.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermFrom1")
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermFrom1.Focus()
                Return False
            End If
        End If
        If txtTermto1.Text.Trim <> "" Then
            If Not IsDate(txtTermto1.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermTo1")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermto1.Focus()
                Return False
            End If
        End If
        If txtTermFrom2.Text.Trim <> "" Then
            If Not IsDate(txtTermFrom2.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermFrom2")
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermFrom2.Focus()
                Return False
            End If
        End If
        If txtTermto2.Text.Trim <> "" Then
            If Not IsDate(txtTermto2.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermTo2")
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermto2.Focus()
                Return False
            End If
        End If
        If txtTermFrom3.Text.Trim <> "" Then
            If Not IsDate(txtTermFrom3.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermFrom3")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermFrom3.Focus()
                Return False
            End If
        End If
        If txtTermto3.Text.Trim <> "" Then
            If Not IsDate(txtTermto3.Text.Trim) Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TermTo3")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtTermto3.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Function chkAgentDetails() As Boolean
        If txtContact.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "AgentContact")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtContact.Focus()
            Return False
        Else
            If txtUnderwriteName.Visible = True Then
                If txtUnderwriteName.Text = "" Then
                    lblMessage.Visible = True
                    Label1.Visible = True
                    Label1.Text = lblMessage.Text
                    lblMessage.Text = "SIU Internal User Please Provide Your Name"
                    logger.Info(lblMessage.Text)
                    txtGQID.Focus()
                    Return False
                End If

            End If


        End If
        Return True
    End Function
    Private Function chkOperationDetails() As Boolean
        If txtApplicantName.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "Applicant")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtApplicantName.Focus()
            Return False
        End If
        If txtgaragingadd.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "GaragingAddress")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtgaragingadd.Focus()
            Return False
        End If
        If txtcity.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "City")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtcity.Focus()
            Return False
        End If
        If txtCounty.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "County")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtCounty.Focus()
            Return False
        End If
        If txtState.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "State")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtState.Focus()
            Return False
        End If
        Dim objGarageQoteDM As New GarageQuoteDataModel

        If Not objGarageQoteDM.CheckStateforGarage(txtState.Text.Trim.ToUpper) Then

            lblMessage.Text = "Please enter valid State"
            logger.Info(lblMessage.Text)
            lblstateMsg.Text = "Invalid State"
            txtState.Focus()
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False

        Else
            lblstateMsg.Text = ""

        End If
        If txtZIP.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "ZIP")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtZIP.Focus()
            Return False
        End If
        If rdoIndivudual.Checked = False And rdoCorporation.Checked = False And rdoPartnerShip.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "TypeBusiness")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        End If
        If ddlYearsInBusiness.SelectedIndex <= 0 Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "YrsInBusiness")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            ddlYearsInBusiness.Focus()
            Return False
        End If
        If txtyrsinsured.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "YrsInsured")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtyrsinsured.Focus()
            Return False
        End If
        If ddlYearsInBusiness.SelectedItem.Text.ToUpper = "NEW VENTURE" Then
            If txtYrExp.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "YrsInBusinessText")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtYrExp.Focus()
                Return False
            End If
        End If
        If txtMplOperations.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "OperationsInsured")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplOperations.Focus()
            Return False
        End If
        If rdAutoPartsNo.Checked = False And rdAutoPartsYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "rdSellAutoParts")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdAutoPartsYes.Checked And txtSellPercentage.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SellPercent")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtSellPercentage.Focus()
            Return False
        End If
        If rdoOperateSalvageYardNo.Checked = False And rdoOperateSalvageYardYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "OperateSalvageYard")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtSellPercentage.Focus()
            Return False
        End If
        If rdoGarageOperationOtherLocationNo.Checked = False And rdoGarageOperationOtherLocationYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "rdGOOLocation")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdoGarageOperationOtherLocationYes.Checked And txtMplOtherLocations.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "GOOLocations")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplOtherLocations.Focus()
            Return False
        End If
        If rdOtherBusinessOperationNo.Checked = False And rdOtherBusinessOperationYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "rdGOOBusiness")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdOtherBusinessOperationYes.Checked And txtMplOtherBusiness.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "GOOBusiness")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplOtherBusiness.Focus()
            Return False
        End If
        If rdOwnWreckerNo.Checked = False And rdOwnWreckerYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "OwnWrecker")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        End If
        If rdOwnRollbackNo.Checked = False And rdOwnRollbackYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "OwnRollback")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        End If
        If rdTowBarDollieTrailerNo.Checked = False And rdTowBarDollieTrailerYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "Dollie")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdTowBarDollieTrailerYes.Checked And txtMplDollie.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "DollieDetails")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplDollie.Focus()
            Return False
        End If
        If rdAnyChildreninHouseNo.Checked = False And rdAnyChildreninHouseYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "AnyChild")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        End If
        If txtMplOwnerSpouseNameAge.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "OwnerSpouseNameAge")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplOwnerSpouseNameAge.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function chkCoverageDetailsInputs() As Boolean
        If ddlGarageLimit.SelectedIndex <= 0 Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "GarageLimit")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            ddlGarageLimit.Focus()
            Return False
        End If
        If ddlMedPay.SelectedIndex <= 0 Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "MedPay")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            ddlMedPay.Focus()
            Return False
        End If
        If ddlRadius.SelectedIndex <= 0 Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "Radius")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            ddlRadius.Focus()
            Return False
        End If

        'If ddlReject.SelectedIndex <= 0 And txtState.Text.ToUpper.ToString <> "FL" Then
        'If ddlReject.SelectedIndex <= 0 Then
        '    lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "Reject")
        '    lblMessage.Visible = True
        '    ddlReject.Focus()
        '    Return False
        'End If


        If ddlReject.Enabled = True And ddlReject.SelectedItem.Text.ToUpper <> "REJECT" Then
            If ddlDealerPlates.SelectedIndex <= 0 Then
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "DealerPlatesUM")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                ddlDealerPlates.Focus()
                Return False
            End If
        End If

        If chkGarageKeeperCoverage.Checked Then
            If GKLLTotalValueperLot.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "CoverageTVPL")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                GKLLTotalValueperLot.Focus()
                Return False
            End If
            If txtMaxLimitperUnit1.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "CoverageMaxLimitPerUnit")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtMaxLimitperUnit1.Focus()
                Return False
            End If
            If ddlGKLLDeductible.SelectedIndex <= 0 Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "CoverageDeductible")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                ddlGKLLDeductible.Focus()
                Return False
            End If
            If chkGKLLCollision.Checked = False And chkGKLLComprehensive.Checked = False And chkGKLLSpecifiedPerils.Checked = False Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "checkGarageOptions")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                Return False
            End If
        End If
        If chkPhyDamageCoverage.Checked Then
            If txtDealerPhyDamTotalValueperLot.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "PhysicalTVPL")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtDealerPhyDamTotalValueperLot.Focus()
                Return False
            End If
            If txtDealersPhyDamMaxLimitanyUnit.Text.Trim = "" Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "PhysicalMLPU")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                txtDealersPhyDamMaxLimitanyUnit.Focus()
                Return False
            End If
            If ddlDealerPhyDamDeductible.SelectedIndex <= 0 Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "PhysicalDeductible")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                ddlDealerPhyDamDeductible.Focus()
                Return False
            End If
            If chkGKLLCollision1.Checked = False And chkGKLLComprehensive1.Checked = False And chkGKLLSpecifiedPerils1.Checked = False Then
                lblMessage.Text = xmlConfig.GetComponentProperty("CreateQuote", "checkPhyGarageOptions")
                logger.Info(lblMessage.Text)
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                Return False
            End If
        End If
        Return True
    End Function
    Private Function chkInsuranceHistory() As Boolean
        If rdoPrePolicyCnNo.Checked = False And rdoPrePolicyCnYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "PrePolicyCn")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdoPrePolicyCnYes.Checked And txtMplPolicyCancelledDetails.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "PrePolicyCndet")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True

            Label1.Text = lblMessage.Text = True
            txtMplPolicyCancelledDetails.Focus()
            Return False
        End If
        If rdoPrePolicyNonRenewedNo.Checked = False And rdoPrePolicyNonRenewedYes.Checked = False Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "PrePolicyNR")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            Return False
        ElseIf rdoPrePolicyNonRenewedYes.Checked And txtMplPolicyNotRenewalDetail.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "PrePolicyNRdet")
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtMplPolicyNotRenewalDetail.Focus()
            Return False
        End If
        If txtAmtpaid1.Text.Trim = "" Then
            lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "AmtPaid1")
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
            txtAmtpaid1.Focus()
        End If
        Return True
    End Function

#End Region
    ''' <summary>
    ''' called on Search button click
    ''' fills up of quotes from DB to Grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        logger.Debug("Entering CreateQuote.btnSubmit_Click")
        BindGrid()
        logger.Debug("Exiting CreateQuote.btnSubmit_Click")
        pnlSearch.Visible = True
    End Sub
    Private Sub BindGrid(Optional ByVal sortExpression As String = Nothing)
        Dim oGarageQuoteData As New GarageQuoteSheetDLL.GarageQuoteDataModel
        Dim iCol As ICollection
        Try
            gvQuote.DataSource = Nothing

            'Following fills Reject
            Dim strDays As String = xmlConfig.GetComponentProperty(COMP_GQS_SearchQuote, "RecordsFrom").Trim
            Dim intDays As Integer = -1
            If strDays <> "" Then
                If IsNumeric(strDays) Then
                    intDays = CInt(strDays)
                End If
            End If

            iCol = oGarageQuoteData.searchQuoteDetails(lblAgency.Text.Trim, intDays)
            Dim dv As DataView = iCol
            If Not IsNothing(sortExpression) Then
                dv.Sort = sortExpression
            End If
            iCol = dv
            If iCol.Count > 0 Then
                gvQuote.DataSource = iCol
                gvQuote.DataBind()
                gvQuote.Visible = True
            Else
                lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SearchAgent")
                lblMessage.Visible = True
                Label1.Visible = True
                Label1.Text = lblMessage.Text
                gvQuote.Visible = False
            End If
        Catch ex As Exception
            lblMessage.Text = ".NET Exception: " & ex.Message
            logger.Info(lblMessage.Text)
            lblMessage.Visible = True
            Label1.Visible = True
            Label1.Text = lblMessage.Text
        End Try
    End Sub

    Private Sub ddlSelect(ByRef ddl As DropDownList, ByVal val As String)
        ddl.SelectedIndex = -1
        For i As Integer = 0 To ddl.Items.Count - 1
            If StrComp(ddl.Items(i).Text, val, CompareMethod.Text) = 0 Then
                ddl.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ddl"></param>
    ''' <param name="val"></param>
    ''' <remarks></remarks>
    Private Sub SelectDropDownValue(ByRef ddl As DropDownList, ByVal val As String)
        ddl.SelectedIndex = -1
        For i As Integer = 0 To ddl.Items.Count - 1
            If StrComp(ddl.Items(i).Value, val, CompareMethod.Text) = 0 Then
                ddl.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub
    ''' <summary>
    ''' called on click of GarageQuoteNumber link in gvQuote GridView
    ''' </summary>
    ''' <param name="pv_QuoteNo"></param>
    ''' <remarks></remarks>
    Private Sub fillDetails(ByVal pv_QuoteNo As String)
        logger.Debug("Entering CreateQuote.fillDetails")
        Dim intGQID As Integer
        intGQID = pv_QuoteNo

        Dim intGOID As Integer
        Dim objQuote As IEntity
        Dim objDMGarageQuote As New GarageQuoteDataModel
        Dim objGenColl As New GenericCollection(Of IEntity)
        Try
            objQuote = New GarageQuote
            objGenColl = objDMGarageQuote.GetData(intGQID)
            'objQuote = objDMGarageQuote.GetData(pv_QuoteNo)
            If objGenColl.Count > 0 Then
                objQuote = CType(objGenColl.Item(0), GarageQuote)


                lblAgency.Text = CType(objQuote, GarageQuote).AgentID
                txtApplicantName.Text = CType(objQuote, GarageQuote).ApplicantName
                txtContact.Text = CType(objQuote, GarageQuote).Contact
                txtCounty.Text = CType(objQuote, GarageQuote).County
                If StrComp(ddlReplyOptions.SelectedItem.Text, "Email", CompareMethod.Text) = 0 Then
                    txtFaxNo.Text = CType(objQuote, GarageQuote).Email
                Else
                    txtFaxNo.Text = CType(objQuote, GarageQuote).Fax
                End If

                intGQID = CType(objQuote, GarageQuote).GarageQuoteID
                txtGQID.Text = intGQID
                lblParentQuoteNo.Text = CType(objQuote, GarageQuote).ParentQuoteNumber
                'If lblParentQuoteNo.Text <> "" Then
                '    fldParentQuote.Visible = True
                'Else : fldParentQuote.Visible = False
                'End If

                txtPhone.Text = CType(objQuote, GarageQuote).Phone
                txtState.Text = CType(objQuote, GarageQuote).State
                txtZIP.Text = CType(objQuote, GarageQuote).ZIP
                txtTradeName.Text = CType(objQuote, GarageQuote).TradeName
                txtAdditionalNotes.Text = CType(objQuote, GarageQuote).AdditionalNotes
                txtUnderwriteName.Text = CType(objQuote, GarageQuote).UnderwriterName
                txtuwemail.Text = CType(objQuote, GarageQuote).UnderwriterEmail
            End If

        Catch ex As Exception
        Finally
            objDMGarageQuote = Nothing
        End Try

        'Following Retrieves GarageOperation record
        Dim objOperation As IEntity

        Dim objDMGarageOperation As New GarageOperationsDataModel
        objGenColl = New GenericCollection(Of IEntity)
        Try
            objOperation = New GarageOperations
            objGenColl = objDMGarageOperation.Getdata(intGQID)

            If objGenColl.Count > 0 Then
                'objOperation = objDMGarageOperation.Getdata(intGQID)
                objOperation = CType(objGenColl.Item(0), GarageOperations)
                If CType(objOperation, GarageOperations).BusinessType = "Corporation" Then
                    rdoCorporation.Checked = True
                Else : rdoCorporation.Checked = False
                End If
                If CType(objOperation, GarageOperations).BusinessType = "Individual" Then
                    rdoIndivudual.Checked = True
                Else : rdoIndivudual.Checked = False
                End If
                If CType(objOperation, GarageOperations).BusinessType = "PartnerShip" Then
                    rdoPartnerShip.Checked = True
                Else : rdoPartnerShip.Checked = False
                End If
                txtMplDollie.Text = CType(objOperation, GarageOperations).DollieOrTrailerDetails
                txtMplPersonFurnishedAutoName.Text = CType(objOperation, GarageOperations).FurnishedAutoDetails
                intGOID = CType(objOperation, GarageOperations).GarageOperationId
                If CType(objOperation, GarageOperations).HasDollieOrTrailer = 1 Then
                    rdTowBarDollieTrailerYes.Checked = True
                Else : rdTowBarDollieTrailerYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).HasDollieOrTrailer = 0 Then
                    rdTowBarDollieTrailerNo.Checked = True
                Else : rdTowBarDollieTrailerNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).HasRollback = 1 Then
                    rdOwnRollbackYes.Checked = True
                Else : rdOwnRollbackYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).HasRollback = 0 Then
                    rdOwnRollbackNo.Checked = True
                Else : rdOwnRollbackNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).HasWrecker = 1 Then
                    rdOwnWreckerYes.Checked = True
                Else : rdOwnWreckerYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).HasWrecker = 0 Then
                    rdOwnWreckerNo.Checked = True
                Else : rdOwnWreckerNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).OperateOtherLocation = 1 Then
                    rdoGarageOperationOtherLocationYes.Checked = True
                Else : rdoGarageOperationOtherLocationYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).OperateOtherLocation = 0 Then
                    rdoGarageOperationOtherLocationNo.Checked = True
                Else : rdoGarageOperationOtherLocationNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).OperateSalvageYard = 1 Then
                    rdoOperateSalvageYardYes.Checked = True
                Else : rdoOperateSalvageYardYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).OperateSalvageYard = 0 Then
                    rdoOperateSalvageYardNo.Checked = True
                Else : rdoOperateSalvageYardNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).otherBusinessOperation = 1 Then
                    rdOtherBusinessOperationYes.Checked = True
                Else : rdOtherBusinessOperationYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).otherBusinessOperation = 0 Then
                    rdOtherBusinessOperationNo.Checked = True
                Else : rdOtherBusinessOperationNo.Checked = False
                End If
                If CType(objOperation, GarageOperations).SellAutoParts = 1 Then
                    rdAutoPartsYes.Checked = True
                Else : rdAutoPartsYes.Checked = False
                End If
                If CType(objOperation, GarageOperations).SellAutoParts = 0 Then
                    rdAutoPartsNo.Checked = True
                Else : rdAutoPartsNo.Checked = False
                End If
                txtSellPercentage.Text = IIf(CType(objOperation, GarageOperations).SellPercentage = 0, "", CType(objOperation, GarageOperations).SellPercentage)
                'ddlSelect(ddlYearsInBusiness, CType(objOperation, GarageOperations).YrsInBusiness)
                SelectDropDownValue(ddlYearsInBusiness, CType(objOperation, GarageOperations).YrsExperience_NewVenture)
                If ddlYearsInBusiness.SelectedItem.Text = "New Venture" Then
                    pnlInsuranceHistory.Visible = False
                    'txtYrExp.Text = CType(objOperation, GarageOperations).YrsExperience_NewVenture
                    txtYrExp.Text = CType(objOperation, GarageOperations).YrsInBusiness
                    trYrsExp.Visible = True
                Else
                    pnlInsuranceHistory.Visible = True
                    txtYrExp.Text = String.Empty
                    trYrsExp.Visible = False
                End If
                txtMplOperations.Text = CType(CType(objOperation, GarageOperations).InsuredOperations.Item(0), InsuredOperation).OperationDetails
                txtMplOtherBusiness.Text = CType(CType(objOperation, GarageOperations).OtherBusinesses.Item(0), OtherBusiness).OtherBusinessDetail
                txtMplOtherLocations.Text = CType(CType(objOperation, GarageOperations).OtherLocations.Item(0), OtherLocation).OperationLocation
                txtgaragingadd.Text = CType(objOperation, GarageOperations).GarageAddress
                txtcity.Text = CType(objOperation, GarageOperations).City
                txtyrsinsured.Text = CType(objOperation, GarageOperations).YearsInsured
            End If

        Catch ex As Exception
        Finally
            objDMGarageOperation = Nothing
        End Try

        'Following Retrieves Coverage record
        Dim objCoverage As IEntity
        Dim objDMCoverage As New CoverageDetailDataModel

        objGenColl = New GenericCollection(Of IEntity)

        Try
            objCoverage = New CoverageDetail

            objGenColl = objDMCoverage.getdata(intGQID)

            If objGenColl.Count > 0 Then


                objCoverage = CType(objGenColl.Item(0), CoverageDetail)
                If CType(objCoverage, CoverageDetail).IsCollision = 1 Then
                    chkGKLLCollision.Checked = True
                Else : chkGKLLCollision.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsComprehensive = 1 Then
                    chkGKLLComprehensive.Checked = True
                Else : chkGKLLComprehensive.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsPerils = 1 Then
                    chkGKLLSpecifiedPerils.Checked = True
                Else : chkGKLLSpecifiedPerils.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).PhysicalIsCollision = 1 Then
                    chkGKLLCollision1.Checked = True
                Else : chkGKLLCollision1.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).PhysicalIsComprehensive = 1 Then
                    chkGKLLComprehensive1.Checked = True
                Else : chkGKLLComprehensive1.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).PhysicalIsPerils = 1 Then
                    chkGKLLSpecifiedPerils1.Checked = True
                Else : chkGKLLSpecifiedPerils1.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsDirectPrimary = 1 Then
                    chkDirectPrimary.Checked = True
                Else : chkDirectPrimary.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLegalLiability = 1 Then
                    chkLegalLiability.Checked = True
                Else : chkLegalLiability.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLotChained = 1 Then
                    rdoChianed.Checked = True
                Else : rdoChianed.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLotFenced = 1 Then
                    rdoFenced.Checked = True
                Else : rdoFenced.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLotLightedNight = 1 Then
                    rdoLightedYes.Checked = True
                Else : rdoLightedYes.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLotLightedNight = 0 Then
                    rdoLightedNo.Checked = True
                Else : rdoLightedNo.Checked = False
                End If
                If CType(objCoverage, CoverageDetail).IsLotOpen = 1 Then
                    rdoOpen.Checked = True
                Else : rdoOpen.Checked = False
                End If
                ddlSelect(ddlGarageLimit, CType(objCoverage, CoverageDetail).LiabiltyLimit)
                txtMaxLimitperUnit1.Text = IIf(CType(objCoverage, CoverageDetail).MaxLimitPerUnit = 0, "", CType(objCoverage, CoverageDetail).MaxLimitPerUnit)
                ddlSelect(ddlMedPay, IIf(CType(objCoverage, CoverageDetail).MedPayLimit = 0, "", CType(objCoverage, CoverageDetail).MedPayLimit))
                SelectDropDownValue(ddlDealerPlates, IIf(CType(objCoverage, CoverageDetail).NoofDealerPlates = 0, "", CType(objCoverage, CoverageDetail).NoofDealerPlates))
                ddlSelect(ddlRadius, CType(objCoverage, CoverageDetail).OperationRadius)
                ddlSelect(ddlDealerPhyDamDeductible, CType(objCoverage, CoverageDetail).PhysicalDeductible)
                txtDealersPhyDamMaxLimitanyUnit.Text = IIf(CType(objCoverage, CoverageDetail).PhysicalMaxUnitPerLimit = 0, "", CType(objCoverage, CoverageDetail).PhysicalMaxUnitPerLimit)
                txtDealerPhyDamTotalValueperLot.Text = IIf(CType(objCoverage, CoverageDetail).PhysicalValuePerLot = 0, "", CType(objCoverage, CoverageDetail).PhysicalValuePerLot)
                Dim oGarageLookupData As New GarageLookupDataModel
                Dim intcount As Integer = oGarageLookupData.getLookup(2).Count
                If txtState.Text = "FL" Then

                    If ddlReject.Items.FindByValue(9999) Is Nothing Then
                        ddlReject.Items.Insert(intcount, New System.Web.UI.WebControls.ListItem("10,000", "9999"))
                    End If
                Else
                    ddlReject.Items.Clear()
                    ddlReject.DataSource = oGarageLookupData.getLookup(2)
                    ddlReject.DataTextField = "Value"
                    ddlReject.DataValueField = "ID"
                    ddlReject.DataBind()
                    ddlReject.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                End If



                ddlSelect(ddlReject, CType(objCoverage, CoverageDetail).Reject)
                GKLLTotalValueperLot.Text = IIf(CType(objCoverage, CoverageDetail).ValuePerLot = 0, "", CType(objCoverage, CoverageDetail).ValuePerLot)
                ddlSelect(ddlGKLLDeductible, CType(objCoverage, CoverageDetail).Deductible)

                If GKLLTotalValueperLot.Text.Trim <> "" Or ddlGKLLDeductible.SelectedIndex > 0 Or txtMaxLimitperUnit1.Text.Trim <> "" Then
                    chkGarageKeeperCoverage.Checked = True
                Else : chkGarageKeeperCoverage.Checked = False
                End If
                If txtDealersPhyDamMaxLimitanyUnit.Text.Trim <> "" Or txtDealerPhyDamTotalValueperLot.Text.Trim <> "" Or ddlDealerPhyDamDeductible.SelectedIndex > 0 Then
                    chkPhyDamageCoverage.Checked = True
                Else : chkPhyDamageCoverage.Checked = False
                End If

                If txtState.Text = "FL" Then
                    Trpip.Visible = True
                    trVehicleCoverage.Visible = True
                    dealertags.Visible = True
                    txtpip.Text = CType(objCoverage, CoverageDetail).PIP
                    txtnumtags.Text = CType(objCoverage, CoverageDetail).NoOfDealerTags
                Else
                    Trpip.Visible = False
                    trVehicleCoverage.Visible = False
                End If
            End If
        Catch ex As Exception
        Finally
            objDMCoverage = Nothing
        End Try

        'Following Retrieves GaragePersonal record



        Dim objPerson As IEntity

        Dim objDMPerson As New GaragePersonalDetailDataModel
        objGenColl = New GenericCollection(Of IEntity)
        Try
            objPerson = New GaragePerson
            objGenColl = objDMPerson.GetData(intGQID)

            If objGenColl.Count > 0 Then

                objPerson = CType(objGenColl.Item(0), GaragePerson)
                If CType(objPerson, GaragePerson).IsChildHouseHold = 1 Then
                    rdAnyChildreninHouseYes.Checked = True
                Else : rdAnyChildreninHouseYes.Checked = False
                End If
                If CType(objPerson, GaragePerson).IsChildHouseHold = 0 Then
                    rdAnyChildreninHouseNo.Checked = True
                Else : rdAnyChildreninHouseNo.Checked = False
                End If
                txtMplOwnerSpouseNameAge.Text = CType(objPerson, GaragePerson).NameAge
                txtMplDriversNameAge.Text = CType(objPerson, GaragePerson).DriverNameAge
                txtMplEmployeeNameAge.Text = CType(objPerson, GaragePerson).EmployeeNameAge
                'txtMplPersonFurnishedAutoName.Text = CType(objPerson, GaragePerson).PersonFurnishedAutos
                txtMplChildrenAges.Text = CType(objPerson, GaragePerson).AllAges
                txtMplComments.Text = CType(objPerson, GaragePerson).Comments
            End If

        Catch ex As Exception
        Finally
            objDMPerson = Nothing
        End Try

        'Following Retrieves Insurance History record
        Dim objInsuranceHistory As IEntity
        Dim objDMIH As New InsuranceHistoryDataModel
        objGenColl = New GenericCollection(Of IEntity)

        Try
            objInsuranceHistory = New InsuranceHistory
            objGenColl = objDMIH.GetData(intGQID)

            If objGenColl.Count > 0 Then
                objInsuranceHistory = CType(objGenColl.Item(0), InsuranceHistory)

                'objInsuranceHistory = objDMIH.GetData(intGQID)
                CType(objInsuranceHistory, InsuranceHistory).GarageQuoteID = IIf(IsNumeric(objQuote.Id), objQuote.Id, "-1")
                CType(objInsuranceHistory, InsuranceHistory).InsuranceHistoryId = "-1"
                If CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyCancelled = 1 Then
                    rdoPrePolicyCnYes.Checked = True
                Else : rdoPrePolicyCnYes.Checked = False
                End If
                If CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyCancelled = 0 Then
                    rdoPrePolicyCnNo.Checked = True
                Else : rdoPrePolicyCnNo.Checked = False
                End If
                If CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyNotRenewed = 1 Then
                    rdoPrePolicyNonRenewedYes.Checked = True
                Else : rdoPrePolicyNonRenewedYes.Checked = False
                End If
                If CType(objInsuranceHistory, InsuranceHistory).IsPreviousPolicyNotRenewed = 0 Then
                    rdoPrePolicyNonRenewedNo.Checked = True
                Else : rdoPrePolicyNonRenewedNo.Checked = False
                End If
                txtMplPolicyNotRenewalDetail.Text = CType(objInsuranceHistory, InsuranceHistory).NotRenewalDetails
                txtMplPolicyCancelledDetails.Text = CType(objInsuranceHistory, InsuranceHistory).CancellationDetails
            End If


        Catch ex As Exception
        Finally
            objDMIH = Nothing
        End Try

        'Following Retrieves Insurance Loss History record
        Dim objInsuranceLossHistory As IEntity
        Dim objDMILH As New InsuranceLossHistoryDataModel
        objGenColl = New GenericCollection(Of IEntity)

        Try
            objGenColl = objDMILH.GetData(intGQID)

            If objGenColl.Count > 0 Then


                objInsuranceLossHistory = New InsuranceLossHistory
                objInsuranceLossHistory = CType(objGenColl.Item(0), InsuranceLossHistory)

                objInsuranceLossHistory = objDMILH.getDetails(intGQID, 0)
                txtAmtpaid1.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Amount
                txtCarrier1.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Carrier
                txtMplDetails1.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Details
                txtTermFrom1.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermFrom
                txtTermto1.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermTo





                objInsuranceLossHistory = Nothing
                objInsuranceLossHistory = New InsuranceLossHistory
                objInsuranceLossHistory = objDMILH.getDetails(intGQID, 1)
                txtAmtpaid2.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Amount
                txtCarrier2.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Carrier
                txtMplDetails2.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Details
                txtTermFrom2.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermFrom
                txtTermto2.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermTo










                objInsuranceLossHistory = Nothing
                objInsuranceLossHistory = New InsuranceLossHistory
                objInsuranceLossHistory = objDMILH.getDetails(intGQID, 2)
                txtAmtpaid3.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Amount
                txtCarrier3.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Carrier
                txtMplDetails3.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).Details
                txtTermFrom3.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermFrom
                txtTermto3.Text = CType(objInsuranceLossHistory, InsuranceLossHistory).TermTo

                EmptyControl(txtTermFrom1)
                EmptyControl(txtTermto1)
                EmptyControl(txtTermFrom2)
                EmptyControl(txtTermto2)
                EmptyControl(txtTermFrom3)
                EmptyControl(txtTermto3)

                EmptyAmountControl(txtAmtpaid1)
                EmptyAmountControl(txtAmtpaid2)
                EmptyAmountControl(txtAmtpaid3)

            End If

        Catch ex As Exception
        Finally
            objDMILH = Nothing
        End Try
        pnlSearch.Visible = False
        logger.Debug("Exiting CreateQuote.fillDetails")
    End Sub
    Private Sub EmptyControl(ByVal txtControl As TextBox)
        If txtControl.Text.IndexOf("/") = -1 Then
            txtControl.Text = ""
        End If
    End Sub
    Private Sub EmptyAmountControl(ByVal txtControl As TextBox)
        If txtControl.Text.Trim = 0 Then
            txtControl.Text = ""
        End If
    End Sub
    Protected Sub gvQuote_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuote.RowCommand
        If e.CommandName = "FillDetails" Then
            fillDetails(e.CommandArgument)
        End If
    End Sub

    Protected Sub gvQuote_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvQuote.Sorting
        BindGrid(e.SortExpression.ToString)
    End Sub

    Protected Sub gvQuote_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvQuote.PageIndexChanging
        gvQuote.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub








    ' Private methods - rvig - 12/17/2008


    Public Sub SendForImaging()
        ' do this only if the output PDF still exists
        If File.Exists("c:\rohit.pdf") Then


            ' create index file at Imaging directory

            Dim idxpath As String = "\\imagesvr\sys1\images\oasis\test1"


            idxpath = Replace(idxpath, ".pdf", ".idx")

            Dim idxfs As FileStream
            Dim info2 As Byte()

            'create the idx file
            If File.Exists(idxpath) = True Then
                ' delete the file.
                File.Delete(idxpath)
            End If
            'create the file anew
            idxfs = File.Create(idxpath)
            idxfs.Close()

            idxfs = File.OpenWrite(idxpath)
            info2 = New UTF8Encoding(True).GetBytes(qIDXString())
            ' Add some information to the file.
            idxfs.Write(info2, 0, info2.Length)
            idxfs.Close()

            ' copy PDF from source into Imaging directory
            'File.Copy("test.pdf", Replace(idxpath, ".idx", ".pdf"))

        End If

    End Sub

    Private Sub qIDX()

        Dim strapplicantname As String = txtApplicantName.Text

        Dim idxpath As String = "\\imagesvr\Images\oasis\" ' & _Data.Insured_Name & ".idx"
        Dim idxfs As FileStream
        Dim info2 As Byte()
        Dim user As String = HttpContext.Current.Session.Item(SIUINS.Utils.Consts.LOGIN_ID)

        'If _Data.Insured_Name <> "" And Not _Data.Insured_Name Is Nothing Then
        If strapplicantname <> "" And Not strapplicantname Is Nothing Then
            'replace all the non-valid file symbols with valid symbols.
            idxpath &= CleanFileName(strapplicantname)
        Else
            idxpath &= "-" & CleanFileName(user)
        End If

        idxpath &= ".idx"
        'create the idx file
        If File.Exists(idxpath) = True Then
            ' delete the file.
            File.Delete(idxpath)
        End If
        'create the file anew
        idxfs = File.Create(idxpath)
        idxfs.Close()
        ' Open the stream and read it back.
        idxfs = File.OpenWrite(idxpath)
        info2 = New UTF8Encoding(True).GetBytes(qIDXString())
        ' Add some information to the file.
        idxfs.Write(info2, 0, info2.Length)
        idxfs.Close()

    End Sub


    Private Function qIDXString() As String

        Dim strinsuredname As String = txtApplicantName.Text


        Dim sIndex As String
        Dim argFileNum As String
        Dim sInsured As String
        Dim sdate As String 'will hold the currentdate
        Dim smonth As String 'will hold the month in MM format 
        Dim sday As String 'will hold the day in DD format from 
        Dim syear As String 'will hold the year in YYYY format 


        'sIndex = _Data.Insured_Name & ".pdf"
        sIndex = strinsuredname & ".pdf"


        'add a space after the file name
        sIndex = sIndex & " "
        'add required string "$#IY#$"	from spec
        sIndex = sIndex & "$#IY#$"

        'add policy number to index file
        argFileNum = strinsuredname & "" '_Data.Insured_Name & ""
        If Len(argFileNum) > 40 Then
            argFileNum = Left(argFileNum, 40) 'limit this field to 40 chars
        Else
            While Len(argFileNum) < 40
                argFileNum = argFileNum & " " 'add trailing spaces until the length is 40 chars
            End While
        End If
        sIndex = sIndex & argFileNum
        Dim code As String = "922" 'HttpContext.Current.Session.Item(SIUINS.Utils.Consts.LOGIN_DEPT)
        Select Case code
            Case "909"
                sIndex = sIndex & "D909" 'Drawer"
            Case "929"
                sIndex = sIndex & "D929" 'Drawer"
            Case "937"
                sIndex = sIndex & "D937" 'Drawer"
            Case Else
                sIndex = sIndex & "D922" 'Drawer"
        End Select

        sIndex = sIndex & "M" 'X or M
        sIndex = sIndex & "SUB " 'document type
        sIndex = sIndex & "     " 'page number
        sIndex = sIndex & "3    " 'folder type
        'the following was commented out as per S.Morgans request (through Robert) 4/28/2005
        'Select Case code
        '    Case SIU.DeptCodes.D909
        '        sIndex = sIndex & "44   " 'flow id
        '        sIndex = sIndex & "66   " 'step id
        '    Case SIU.DeptCodes.D929
        '        sIndex = sIndex & "44   " 'flow id
        '        sIndex = sIndex & "98   " 'step id
        '    Case Else
        '        sIndex = sIndex & "46   " 'flow id
        '        sIndex = sIndex & "3    " 'step id
        'End Select
        sIndex = sIndex & "     " 'flow id
        sIndex = sIndex & "     " 'step id

        sIndex = sIndex & "          " 'user id
        sIndex = sIndex & " " 'priority
        sIndex = sIndex & " " 'jpeg
        'get the "insured name 1" field node
        'sInsured = Left(_Data.Insured_Name, 30)
        sInsured = Left(strinsuredname, 30)
        While Len(sInsured) < 30
            sInsured = sInsured & " " 'add trailing spaces until the length is 30 chars
        End While
        sIndex = sIndex & sInsured

        'need to place date of file here (YYYYMMDD format)
        smonth = Month(Now)
        sday = Day(Now)
        syear = Year(Now)
        If Len(smonth) < 2 Then 'need MM format
            smonth = "0" & smonth 'make 0 padded month
        End If
        If Len(sday) < 2 Then 'need DD format
            sday = "0" & sday 'make 0 padded day
        End If
        sdate = syear & smonth & sday 'makes date string in YYYYMMDD format

        sIndex = sIndex & sdate 'date (YYYYMMDD)
        sIndex = sIndex & "        " 'date last opened
        sIndex = sIndex & "Y" 'use specified folder type
        sIndex = sIndex & "                                                  " 'page description
        sIndex = sIndex & "C" 'conversion flag
        sIndex = sIndex & "      " 'doc group number
        sIndex = sIndex & "          " 'long folder tpe
        sIndex = sIndex & "N" 'ref number flag
        sIndex = sIndex & "          " 'userdata1 (10 blank spaces)
        sIndex = sIndex & "                    " 'userdata2 (20 blank spaces)
        sIndex = sIndex & "                              " 'userdata3 (30 blank spaces)
        sIndex = sIndex & "                                        " 'userdata4 (40 blank spaces)
        sIndex = sIndex & "                                                  " 'userdata5 (50 blank spaces)
        Return sIndex
    End Function


    Private Function CleanFileName(ByVal input As String) As String
        Dim out As String = input.Replace("\", "-").Replace("/", "-").Replace(":", "-").Replace("*", "_").Replace("?", "-").Replace("""", "'").Replace("<", "-").Replace(">", "-").Replace("|", "_")
        Return out
    End Function




    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim strQueryString As String
        mpeConfirm.Hide()
        Dim strContentUrl As String = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString
        If Not IsNothing(Session("TAG")) Then
            If Session("TAG") = "922HOME" Then
                strContentUrl = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString
                strQueryString = "?USR=" & Session("usr").ToString & "&pw=" & Session("pw").ToString & "&LOGIN_ID=" & Session("LOGIN_ID").ToString & "&LOGIN_TYPE=" & Session("LOGIN_TYPE").ToString & "&TAG=" & Session("TAG").ToString
                Session.Clear()
                Response.Redirect(strContentUrl & strQueryString)
            End If
            If Session("TAG") = "922HOMEPAGE" Then
                strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                strQueryString = "?TITLE=" & Session("TAG").ToString
                Session.Clear()
                Response.Redirect(strContentUrl & strQueryString)
            End If
            If Session("TAG") = "SIURATE" Then
                strContentUrl = ConfigurationManager.AppSettings("SIURateUrl").ToString
                'strQueryString = "?TITLE=" & Session("TAG").ToString
                Session.Clear()
                Response.Redirect(strContentUrl)
            End If

        Else
            Session.Clear()
            Response.Redirect("default.aspx")
        End If
    End Sub
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

    Protected Sub txtState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtState.TextChanged

        Dim objGarageQoteDM As New GarageQuoteDataModel

        If objGarageQoteDM.CheckStateforGarage(txtState.Text.Trim.ToUpper) Then
            lblstateMsg.Text = ""
            If txtState.Text.ToUpper = "FL" Then
                dealertags.Visible = True
                Trpip.Visible = True
                trVehicleCoverage.Visible = True
            Else
                dealertags.Visible = False
                Trpip.Visible = False
                trVehicleCoverage.Visible = False
            End If
        Else
            lblMessage.Text = "Please enter valid State"
            logger.Info(lblMessage.Text)
            lblstateMsg.Text = "Invalid State"
            Exit Sub
        End If

    End Sub

    Protected Sub ddlDealerPlates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDealerPlates.SelectedIndexChanged
        If ddlDealerPlates.SelectedItem.Text.ToUpper.ToString = "SELECT IF YOU WANT" Or ddlDealerPlates.SelectedIndex = 0 Then
            txtpip.Enabled = False
            txtpip.Text = ""
            ddlReject.Enabled = False
            ddlReject.SelectedIndex = 0
        Else
            txtpip.Enabled = True
            txtpip.Text = ""
            ddlReject.Enabled = True
            ddlReject.SelectedIndex = 0
        End If
    End Sub

    'Protected Sub txtTermFrom1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermFrom1.TextChanged
    '    If txtTermFrom1.Text <> "" Then


    '        If txtTermFrom1.Text <> "__/__/____" Then

    '            Dim firstpart As String
    '            firstpart = ""
    '            Dim secpart As String
    '            secpart = ""
    '            Dim thrdpart As String
    '            thrdpart = ""
    '            Dim forthpart As String
    '            forthpart = ""

    '            If txtTermFrom1.Text.Contains("/") Then

    '                firstpart = txtTermFrom1.Text.Substring(0, txtTermFrom1.Text.IndexOf("/"))
    '                secpart = txtTermFrom1.Text.Substring(txtTermFrom1.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                frmyear1 = 2000
    '                txtTermFrom1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
    '            Else



    '                frmyear1 = ""
    '                frmdate1 = txtTermFrom1.Text
    '                fyear1 = frmdate1.Year
    '                txtTermFrom1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString

    '                If fyear1 >= 1 And fyear1 <= 9 Then
    '                    frmyear1 = "200" & fyear1
    '                    txtTermFrom1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
    '                End If
    '                If fyear1 > 9 And fyear1 < 99 Then
    '                    frmyear1 = "20" & fyear1
    '                    txtTermFrom1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
    '                End If


    '            End If
    '            txtTermFrom1.Focus()
    '        End If
    '    End If
    'End Sub

    'Protected Sub txtTermto1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermto1.TextChanged
    '    If txtTermto1.Text = "" Then
    '        lbltoone.Text = ""
    '        lbltoone.Visible = False
    '    End If
    '    If txtTermto1.Text <> "" Then


    '        If txtTermto1.Text <> "__/__/____" Then

    '            Dim firstpart As String = ""
    '            Dim secpart As String = ""
    '            Dim thrdpart As String = ""
    '            Dim forthpart As String = ""

    '            If txtTermto1.Text.Contains("/") Then

    '                firstpart = txtTermto1.Text.Substring(0, txtTermto1.Text.IndexOf("/"))
    '                secpart = txtTermto1.Text.Substring(txtTermto1.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                toyear1 = 2000
    '                txtTermto1.Text = firstpart & "/" + thrdpart & "/" + toyear1.ToString
    '                If txtTermFrom1.Text <> "" Then
    '                    If frmdate1 >= todate1 Then
    '                        lbltoone.Text = "ToDate1 should be greater than From Date1"
    '                        lbltoone.Visible = True
    '                        Return
    '                    Else

    '                        lbltoone.Text = ""
    '                        lbltoone.Visible = False

    '                    End If
    '                End If
    '            Else
    '                toyear1 = ""
    '                todate1 = txtTermto1.Text
    '                If txtTermFrom1.Text <> "" Then
    '                    frmdate1 = txtTermFrom1.Text
    '                End If

    '                tyear1 = todate1.Year
    '                txtTermto1.Text = todate1.Month.ToString & "/" + todate1.Day.ToString & "/" + tyear1.ToString
    '                If tyear1 >= 1 And tyear1 <= 9 Then
    '                    toyear1 = "200" & tyear1
    '                    txtTermto1.Text = todate1.Month.ToString & "/" + todate1.Day.ToString & "/" + toyear1.ToString
    '                End If

    '                If tyear1 > 9 And tyear1 <= 99 Then
    '                    toyear1 = "20" & tyear1
    '                    txtTermto1.Text = todate1.Month.ToString & "/" + todate1.Day.ToString & "/" + toyear1.ToString
    '                End If
    '                todate1 = txtTermto1.Text
    '                If txtTermFrom1.Text <> "" Then
    '                    If frmdate1 >= todate1 Then
    '                        lbltoone.Text = "ToDate1 should be greater than From Date1"
    '                        lbltoone.Visible = True
    '                        Return
    '                    Else

    '                        lbltoone.Text = ""
    '                        lbltoone.Visible = False

    '                    End If
    '                End If

    '                txtTermto1.Focus()
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Sub txtTermFrom2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermFrom2.TextChanged
    '    If txtTermFrom2.Text <> "" Then


    '        If txtTermFrom2.Text <> "__/__/____" Then

    '            Dim firstpart As String = ""
    '            Dim secpart As String = ""
    '            Dim thrdpart As String = ""
    '            Dim forthpart As String = ""


    '            If txtTermFrom2.Text.Contains("/") Then

    '                firstpart = txtTermFrom2.Text.Substring(0, txtTermFrom2.Text.IndexOf("/"))
    '                secpart = txtTermFrom2.Text.Substring(txtTermFrom2.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                frmyear2 = 2000
    '                txtTermFrom2.Text = firstpart & "/" + thrdpart & "/" + frmyear2.ToString
    '            Else
    '                frmyear2 = ""
    '                frmdate2 = txtTermFrom2.Text
    '                fyear2 = frmdate2.Year
    '                txtTermFrom2.Text = frmdate2.Month.ToString & "/" + frmdate2.Day.ToString & "/" + fyear2.ToString
    '                If fyear2 >= 1 And fyear2 <= 9 Then
    '                    frmyear2 = "200" & fyear2
    '                    txtTermFrom2.Text = frmdate2.Month.ToString & "/" + frmdate2.Day.ToString & "/" + frmyear2.ToString
    '                End If
    '                If fyear2 > 9 And fyear2 < 99 Then
    '                    frmyear2 = "20" & fyear2
    '                    txtTermFrom2.Text = frmdate2.Month.ToString & "/" + frmdate2.Day.ToString & "/" + frmyear2.ToString
    '                End If
    '            End If
    '            txtTermFrom2.Focus()
    '        End If
    '    End If

    'End Sub

    'Protected Sub txtTermto2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermto2.TextChanged
    '    If txtTermto2.Text = "" Then
    '        lbltotwo.Text = ""
    '        lbltotwo.Visible = False

    '    End If
    '    If txtTermto2.Text <> "" Then
    '        If txtTermto2.Text <> "__/__/____" Then
    '            Dim firstpart As String = ""
    '            Dim secpart As String = ""
    '            Dim thrdpart As String = ""
    '            Dim forthpart As String = ""


    '            If txtTermto2.Text.Contains("/") Then

    '                firstpart = txtTermto2.Text.Substring(0, txtTermto2.Text.IndexOf("/"))
    '                secpart = txtTermto2.Text.Substring(txtTermto2.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                toyear2 = 2000
    '                txtTermto2.Text = firstpart & "/" + thrdpart & "/" + toyear2.ToString

    '                If txtTermFrom2.Text <> "" Then
    '                    If frmdate2 >= todate2 Then
    '                        lbltotwo.Text = "ToDate2 should be greater than From Date2"
    '                        lbltotwo.Visible = True
    '                        Return
    '                    Else
    '                        lbltotwo.Text = ""
    '                        lbltotwo.Visible = False


    '                    End If
    '                End If
    '            Else
    '                toyear2 = ""
    '                todate2 = txtTermto2.Text
    '                If txtTermFrom2.Text <> "" Then
    '                    frmdate2 = txtTermFrom2.Text
    '                End If

    '                tyear2 = todate2.Year
    '                txtTermto2.Text = todate2.Month.ToString & "/" + todate2.Day.ToString & "/" + tyear2.ToString
    '                If tyear2 >= 1 And tyear2 <= 9 Then
    '                    toyear2 = "200" & tyear2
    '                    txtTermto2.Text = todate2.Month.ToString & "/" + todate2.Day.ToString & "/" + toyear2.ToString
    '                End If

    '                If tyear2 > 9 And tyear2 <= 99 Then
    '                    toyear2 = "20" & tyear2
    '                    txtTermto2.Text = todate2.Month.ToString & "/" + todate2.Day.ToString & "/" + toyear2.ToString
    '                End If
    '                todate2 = txtTermto2.Text
    '                If txtTermFrom2.Text <> "" Then
    '                    If frmdate2 >= todate2 Then
    '                        lbltotwo.Text = "ToDate2 should be greater than From Date2"
    '                        lbltotwo.Visible = True
    '                        Return
    '                    Else
    '                        lbltotwo.Text = ""
    '                        lbltotwo.Visible = False


    '                    End If
    '                End If

    '                txtTermto2.Focus()
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Sub txtTermFrom3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermFrom3.TextChanged
    '    If txtTermFrom3.Text <> "" Then
    '        If txtTermFrom3.Text <> "__/__/____" Then

    '            Dim firstpart As String = ""
    '            Dim secpart As String = ""
    '            Dim thrdpart As String = ""
    '            Dim forthpart As String = ""


    '            If txtTermFrom3.Text.Contains("/") Then

    '                firstpart = txtTermFrom3.Text.Substring(0, txtTermFrom3.Text.IndexOf("/"))
    '                secpart = txtTermFrom3.Text.Substring(txtTermFrom3.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                frmyear3 = 2000
    '                txtTermFrom3.Text = firstpart & "/" + thrdpart & "/" + frmyear3.ToString
    '            Else
    '                frmyear3 = ""
    '                frmdate3 = txtTermFrom3.Text
    '                fyear3 = frmdate3.Year
    '                txtTermFrom3.Text = frmdate3.Month.ToString & "/" + frmdate3.Day.ToString & "/" + fyear3.ToString
    '                If fyear3 >= 1 And fyear3 <= 9 Then
    '                    frmyear3 = "200" & fyear3
    '                    txtTermFrom3.Text = frmdate3.Month.ToString & "/" + frmdate3.Day.ToString & "/" + frmyear3.ToString
    '                End If
    '                If fyear3 > 9 And fyear3 < 99 Then
    '                    frmyear3 = "20" & fyear3
    '                    txtTermFrom3.Text = frmdate3.Month.ToString & "/" + frmdate3.Day.ToString & "/" + frmyear3.ToString
    '                End If

    '                txtTermFrom3.Focus()
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Sub txtTermto3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermto3.TextChanged
    '    If txtTermto3.Text = "" Then
    '        lbltothree.Text = ""
    '        lbltothree.Visible = False
    '    End If
    '    If txtTermto3.Text <> "" Then
    '        If txtTermto3.Text <> "__/__/____" Then
    '            Dim firstpart As String = ""
    '            Dim secpart As String = ""
    '            Dim thrdpart As String = ""
    '            Dim forthpart As String = ""


    '            If txtTermto3.Text.Contains("/") Then

    '                firstpart = txtTermto3.Text.Substring(0, txtTermto3.Text.IndexOf("/"))
    '                secpart = txtTermto3.Text.Substring(txtTermto3.Text.IndexOf("/") + 1)
    '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
    '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

    '            End If
    '            If forthpart = "0000" Then
    '                toyear3 = 2000
    '                txtTermto3.Text = firstpart & "/" + thrdpart & "/" + toyear3.ToString
    '                If txtTermFrom3.Text <> "" Then
    '                    If frmdate3 >= todate3 Then
    '                        lbltothree.Text = "ToDate3 should be greater than From Date3"
    '                        lbltothree.Visible = True
    '                        Return
    '                    Else
    '                        lbltothree.Text = ""
    '                        lbltothree.Visible = False

    '                    End If
    '                End If
    '            Else
    '                toyear3 = ""
    '                todate3 = txtTermto3.Text
    '                If txtTermFrom3.Text <> "" Then
    '                    frmdate3 = txtTermFrom3.Text
    '                End If

    '                tyear3 = todate3.Year
    '                txtTermto3.Text = todate3.Month.ToString & "/" + todate3.Day.ToString & "/" + tyear3.ToString
    '                If tyear3 >= 1 And tyear3 <= 9 Then
    '                    toyear3 = "200" & tyear3
    '                    txtTermto3.Text = todate3.Month.ToString & "/" + todate3.Day.ToString & "/" + toyear3.ToString
    '                End If

    '                If tyear3 > 9 And tyear3 <= 99 Then
    '                    toyear3 = "20" & tyear3
    '                    txtTermto3.Text = todate3.Month.ToString & "/" + todate3.Day.ToString & "/" + toyear3.ToString
    '                End If
    '                todate3 = txtTermto3.Text
    '                If txtTermFrom3.Text <> "" Then
    '                    If frmdate3 >= todate3 Then
    '                        lbltothree.Text = "ToDate3 should be greater than From Date3"
    '                        lbltothree.Visible = True
    '                        Return
    '                    Else
    '                        lbltothree.Text = ""
    '                        lbltothree.Visible = False

    '                    End If
    '                End If

    '                txtTermto3.Focus()
    '            End If
    '        End If
    '    End If
    'End Sub


End Class
