Imports UserControl947
Imports UserControlH03
Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Collections
Imports System.Web.Mail
Imports System.Collections.Generic
Imports UserControls947
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Diagnostics

Partial Class Appication
    Inherits System.Web.UI.Page
    Implements IPublisher
    Implements H03IPublisher
    Implements H03ISubscriber
    Dim app As String
    Dim Fileslst As New List(Of String)
    Dim NameLst As New List(Of String)
    Private PersonalProperty As New ReportDocument
    Private dsPersonalProperty As New DSPersonalProperty

    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote As String = "CreateQuote"
    Private Const COMP_GQS_SearchQuote As String = "SearchQuotes"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Dim subscribers As New List(Of ISubscriber)
    Dim H03subscribers As New List(Of H03ISubscriber)
    Public strTitle As String
    Dim cntr As Integer
    ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
        Get
            Return ""
        End Get
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.MaintainScrollPositionOnPostBack = True
        Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        scriptManager__1.RegisterPostBackControl(btnSubmit)
        logger.Debug("Entering Application.aspx_Page_Load")
        If Not IsPostBack Then
            cntr = 0
            'Dim script As String = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });"
            'ClientScript.RegisterStartupScript(Me.GetType, "load", script, True)
        Else

        End If
        If Len(Trim(Request.QueryString("USR"))) > 0 And Len(Trim(Request.QueryString("PW"))) > 0 And Len(Trim(Request.QueryString("LOGIN_ID"))) > 0 And Len(Trim(Request.QueryString("LOGIN_TYPE"))) > 0 And Len(Trim(Request.QueryString("TAG"))) > 0 Then
            Session("USR") = Trim(Request.QueryString("USR"))
            Session("PW") = Trim(Request.QueryString("PW"))
            Session("LOGIN_ID") = Trim(Request.QueryString("LOGIN_ID"))
            Session("LOGIN_TYPE") = Trim(Request.QueryString("LOGIN_TYPE"))
            Session("TAG") = Trim(Request.QueryString("TAG"))
            Session("AgentCode") = Trim(Request.QueryString("AgentCode"))
            app = Request.QueryString("app")
            logger.Info("Information coming forward from previous page : " _
             & vbCrLf & " Session(USR) = " & Trim(Request.QueryString("USR")) _
                   & vbCrLf & " Session(PW) = " & Trim(Request.QueryString("PW")) _
                   & vbCrLf & " Session(LOGIN_ID) = " & Trim(Request.QueryString("LOGIN_ID")) _
                    & vbCrLf & " Session(LOGIN_TYPE) = " & Trim(Request.QueryString("LOGIN_TYPE")) & vbCrLf & " Session(TAG) = " & Trim(Request.QueryString("TAG")) _
                    & vbCrLf & " Session(AgentCode) = " & Trim(Request.QueryString("AgentCode")) _
                    & vbCrLf & " app = " & Request.QueryString("app"))

        End If

        Dim objAgent As IDataModel
        Dim oAgent As GarageQuoteSheetDLL.Agent

        Dim controls As Collection

        Try
            lblMessage.Text = ""
            lblMessage.Visible = False
            lblmsg1.Text = ""
            lblmsg1.Visible = False

            lbl1.Visible = False
            lbl2.Visible = False


            objAgent = New GarageQuoteSheetDLL.AgentDataModel



            Dim str1 As String
            Dim str2 As String
            str1 = ""
            str2 = ""

            'btnSearch.Visible = False


            app = Request.QueryString("app")



            controls = xmlConfig.GetComponentPropertyCollection("AgentLoginControls")

            If app = "1" Then
                strTitle = "SIU - Commercial Transportation Quote Sheet"
                logger.Info("SIU - Commercial Transportation Quote Sheet has been loaded")
                If controls.Contains("Header").ToString = "True" Then
                    Dim uc As UserControls947.HeaderControl = DirectCast(Page.LoadControl("~/UserControls/HeaderControl.ascx"), UserControls947.HeaderControl)
                    'accessing the user control header property dynamically 
                    uc.Title = "Commercial Transportation Quote Sheet"
                    uc.AvailableFor = "(Only available for 5 power units/trailers)"
                    HeaderPh.Controls.Add(uc)
                    logger.Info("Header Control added")
                Else

                End If


                If controls.Contains("AgencyInfo").ToString = "True" Then
                    Dim AgencyInfo As Control = LoadControl("CommercialAuto/AgencyInformation.ascx")
                    AgencyInfo.ID = "AgencyInfo"
                    AgencyInfoPh.Controls.Add(AgencyInfo)

                    Attach(AgencyInfo)
                Else

                End If

                If controls.Contains("SearchQuotes").ToString = "True" Then
                    Dim pnlSearch As Control = LoadControl("CommercialAuto/CommAutoPanelSearch.ascx")
                    pnlSearch.ID = "SearchPanel"
                    SearchPh.Controls.Add(pnlSearch)
                    Attach(pnlSearch)
                End If

                If controls.Contains("Operation").ToString = "True" Then
                    Dim ucop As UserControl947.CommAutoOperationControl = DirectCast(Page.LoadControl("~/CommercialAuto/CommAutoOperationControl.ascx"), UserControl947.CommAutoOperationControl)
                    ucop.ID = "Operation"
                    OperationPh.Controls.Add(ucop)
                    Attach(ucop)


                Else
                End If

                If controls.Contains("Vehicle").ToString = "True" Then
                    Dim Vehicle As Control = LoadControl("CommercialAuto/CommAutoVehicleControl.ascx")
                    Vehicle.ID = "Vehicle"
                    Vehicleph.Controls.Add(Vehicle)
                    Attach(Vehicle)
                Else


                End If

                If controls.Contains("Driver").ToString = "True" Then
                    Dim driver As Control = LoadControl("CommercialAuto/CommAutoDriverControl.ascx")
                    driver.ID = "Driver"
                    DriverPh.Controls.Add(driver)
                    Attach(driver)
                Else

                End If


                If controls.Contains("InsuranceHistory").ToString = "True" Then

                    Dim AutoCommInsuranceHistorycontrol As Control = LoadControl("CommercialAuto/AutoCommInsuranceHistorycontrol.ascx")
                    AutoCommInsuranceHistorycontrol.ID = "AutoCommInsuranceHistorycontrol"
                    InsuranceHistoryPh.Controls.Add(AutoCommInsuranceHistorycontrol)
                    Attach(AutoCommInsuranceHistorycontrol)
                Else

                End If




                If controls.Contains("Coverage").ToString = "True" Then
                    Dim coverage As Control = LoadControl("CommercialAuto/CommAutoCoverageControl.ascx")
                    coverage.ID = "Coverage"
                    Coverageph.Controls.Add(coverage)
                    Attach(coverage)
                Else

                End If

                If controls.Contains("Additional").ToString = "True" Then
                    Dim Additional As Control = LoadControl("CommercialAuto/AdditionalNotes.ascx")
                    Additional.ID = "AdditionalNotes"
                    AdditionalPh.Controls.Add(Additional)
                    Attach(Additional)

                Else

                End If
                If controls.Contains("Footer").ToString = "True" Then
                    Dim FooterControl As Control = LoadControl("UserControls/FooterControl.ascx")
                    FooterPh.Controls.Add(FooterControl)

                Else

                End If


            Else
                strTitle = "SIU - HomeOwners Quote Sheet"
                If controls.Contains("Header").ToString = "True" Then
                    Dim uc As UserControls947.HeaderControl = DirectCast(Page.LoadControl("~/UserControls/HeaderControl.ascx"), UserControls947.HeaderControl)
                    uc.Title = "HomeOwners Quote Sheet"
                    HeaderPh.Controls.Add(uc)


                Else


                End If

                If controls.Contains("AgencyInfo").ToString = "True" Then
                    Dim AgencyInfo As Control = LoadControl("CommercialAuto/AgencyInformation.ascx")
                    AgencyInfo.ID = "AgencyDetails"
                    AgencyInfoPh.Controls.Add(AgencyInfo)
                    H03AttachSubscriber(AgencyInfo)
                    'AttachSubscriber(AgencyInfoPh.ID.ToString(), AgencyInfo.ID.ToString())
                Else

                End If

                'If controls.Contains("AgencyInfo").ToString = "True" Then
                '    Dim AgencyInfo As Control = LoadControl("H03Controls/H03AgencyInformation.ascx")
                '    AgencyInfoPh.Controls.Add(AgencyInfo)
                'Else

                'End If
                'If controls.Contains("SearchQuotes").ToString = "True" Then
                '    Dim pnlSearch As Control = LoadControl("CommercialAuto/CommAutoPanelSearch.ascx")
                '    SearchPh.Controls.Add(pnlSearch)
                '    Attach(pnlSearch)
                'End If

                If controls.Contains("Risk").ToString = "True" Then
                    Dim H03RiskDescriptionl As Control = LoadControl("H03Controls/H03RiskDescriptionl.ascx")
                    H03RiskDescriptionl.ID = "H03RiskDescriptionl"
                    OperationPh.Controls.Add(H03RiskDescriptionl)
                    H03AttachSubscriber(H03RiskDescriptionl)
                Else

                End If

                If controls.Contains("Home").ToString = "True" Then
                    Dim Vehicle As Control = LoadControl("H03Controls/H03HomeDesc.ascx")
                    Vehicle.ID = "HomeDescriptiondetails"
                    Vehicleph.Controls.Add(Vehicle)
                    H03AttachSubscriber(Vehicle)
                Else

                End If



                If controls.Contains("InsuranceHistory").ToString = "True" Then

                    Dim Insurancehistory As Control = LoadControl("H03Controls/H03InsuranceHistorycontrol.ascx")
                    Insurancehistory.ID = "HistoryDescriptiondetails"
                    DriverPh.Controls.Add(Insurancehistory)
                    H03AttachSubscriber(Insurancehistory)


                Else

                End If

                If controls.Contains("Coverage").ToString = "True" Then
                    Dim coverage As Control = LoadControl("H03Controls/H03CoverageControl.ascx")
                    coverage.ID = "CoverageDescriptiondetails"
                    InsuranceHistoryPh.Controls.Add(coverage)
                    H03AttachSubscriber(coverage)
                Else

                End If
                If controls.Contains("Quote").ToString = "True" Then
                    Dim coverage As Control = LoadControl("H03Controls/H03Quotecontrol.ascx")
                    coverage.ID = "H03Quotecontrol"
                    Coverageph.Controls.Add(coverage)
                    H03AttachSubscriber(coverage)
                Else

                End If


                If controls.Contains("Additional").ToString = "True" Then
                    Dim Additional As Control = LoadControl("CommercialAuto/AdditionalNotes.ascx")
                    AdditionalPh.Controls.Add(Additional)
                    H03AttachSubscriber(Additional)

                Else

                End If
                If controls.Contains("Footer").ToString = "True" Then
                    Dim FooterControl As Control = LoadControl("UserControls/FooterControl.ascx")
                    FooterPh.Controls.Add(FooterControl)



                Else

                End If

                btnSubmit.Text = "Submit for Approval"
                btnSearch.Visible = False





            End If
        Catch ex As Exception
            logger.Error("Exception occurred While loading page application.aspx", ex)
        End Try

        logger.Debug("Exiting Application.aspx_Page_Load")

    End Sub

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Page.Validate("Garage")
        If (Page.IsValid) Then
            If app = "1" Then

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "progress", "javascript:ShowProgress();", True)
                SaveCommercialQuoteData()

            ElseIf app = "3" Then
                SaveH03QuoteData()
            End If
        End If
    End Sub

    Sub SaveToAIM()
        Dim conn As New SqlConnection(ConfigurationManager.AppSettings("AIMConnectionString"))
        Dim comm As New SqlCommand("InsertIntoAIMFromGarageQuoteSheet", conn)
        Dim rs As SqlDataReader

        Dim AgencyInfo As UserControl = Page.FindControl("AgencyInfo")
        Dim Operation As UserControl = Page.FindControl("Operation")
        Dim Vehicle As UserControl = Page.FindControl("Vehicle")

        Dim Agency As Label = AgencyInfo.FindControl("lblAgency")
        Dim Applicant As TextBox = Operation.FindControl("txtApplicantName")
        Dim TradeName As TextBox = Operation.FindControl("txtTradeName")
        Dim Address As TextBox = Operation.FindControl("txtAddress")
        Dim City As TextBox = Operation.FindControl("txtCity")
        Dim State As TextBox = Operation.FindControl("txtState")
        Dim Zip As TextBox = Operation.FindControl("txtZip")
        Dim Radius As TextBox = Operation.FindControl("txtRadius")

        Dim DescriptionConcatenated As New StringBuilder
        Dim EmptySpaceChar As Char = " "

        Dim Year1 As TextBox = Vehicle.FindControl("txyear1")
        If Not Year1.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake1")
            Dim Type As TextBox = Vehicle.FindControl("txttype1")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue1")
            Dim TotalText As String = Year1.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If


        Dim Year2 As TextBox = Vehicle.FindControl("txyear2")
        If Not Year2.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake2")
            Dim Type As TextBox = Vehicle.FindControl("txttype2")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue2")
            Dim TotalText As String = Year2.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year3 As TextBox = Vehicle.FindControl("txyear3")
        If Not Year3.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake3")
            Dim Type As TextBox = Vehicle.FindControl("txttype3")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue3")
            Dim TotalText As String = Year3.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year4 As TextBox = Vehicle.FindControl("txyear4")
        If Not Year4.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake4")
            Dim Type As TextBox = Vehicle.FindControl("txttype4")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue4")
            Dim TotalText As String = Year4.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year5 As TextBox = Vehicle.FindControl("txyear5")
        If Not Year5.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake5")
            Dim Type As TextBox = Vehicle.FindControl("txttype5")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue5")
            Dim TotalText As String = Year5.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year6 As TextBox = Vehicle.FindControl("txyear6")
        If Not Year6.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake6")
            Dim Type As TextBox = Vehicle.FindControl("txttype6")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue6")
            Dim TotalText As String = Year6.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year7 As TextBox = Vehicle.FindControl("txyear7")
        If Not Year7.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake7")
            Dim Type As TextBox = Vehicle.FindControl("txttype7")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue7")
            Dim TotalText As String = Year7.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year8 As TextBox = Vehicle.FindControl("txyear8")
        If Not Year8.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake8")
            Dim Type As TextBox = Vehicle.FindControl("txttype8")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue8")
            Dim TotalText As String = Year8.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year9 As TextBox = Vehicle.FindControl("txyear9")
        If Not Year9.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake9")
            Dim Type As TextBox = Vehicle.FindControl("txttype9")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue9")
            Dim TotalText As String = Year9.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        Dim Year10 As TextBox = Vehicle.FindControl("txyear10")
        If Not Year10.Text.Trim() = "" Then
            Dim Make As TextBox = Vehicle.FindControl("txtmake10")
            Dim Type As TextBox = Vehicle.FindControl("txttype10")
            Dim StatedValue As TextBox = Vehicle.FindControl("txtstatedvalue10")
            Dim TotalText As String = Year10.Text.Trim() & " " & Make.Text.Trim() & " " & Type.Text.Trim() & " Stated Amount - $" & StatedValue.Text.Trim()
            Dim TotalTextLength As Int32 = TotalText.Length
            Dim FillerLength As Int32 = 99 - TotalTextLength
            DescriptionConcatenated.Append(TotalText)
            DescriptionConcatenated.Append(EmptySpaceChar, FillerLength)
        End If

        DescriptionConcatenated.Append(Radius.Text.Trim() & " Mile Radius")

        conn.Open()
        With comm
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@CoverageId", "AUT")
            .Parameters.AddWithValue("@ProductId", "AUT04")
            .Parameters.AddWithValue("@UserId", "")
            .Parameters.AddWithValue("@NamedInsured", Applicant.Text.Trim())
            .Parameters.AddWithValue("@DBAName", TradeName.Text.Trim())
            .Parameters.AddWithValue("@Exposures", DescriptionConcatenated.ToString())
            .Parameters.AddWithValue("@ProducerId", Agency.Text.Trim())
            .Parameters.AddWithValue("@Address1", Address.Text.Trim())
            .Parameters.AddWithValue("@City", City.Text.Trim())
            .Parameters.AddWithValue("@State", State.Text.Trim().ToUpper())
            .Parameters.AddWithValue("@Zip", Zip.Text.Trim())
            .Parameters.AddWithValue("@Description", Radius.Text.Trim() & " Mile Radius")
            rs = .ExecuteReader(CommandBehavior.CloseConnection)
            .Dispose()
        End With
    End Sub
    ''' <summary>
    ''' Save H03 QuoteData
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveH03QuoteData()
        logger.Debug("Entering Application.aspx.SaveH03QuoteData")
        Dim subscriber As H03ISubscriber
        Try

            For Each subscriber In H03subscribers
                Dim strReturn = subscriber.H03ValidateInputData()
                If (String.IsNullOrEmpty(strReturn) = False) Then
                    lblMessage.Visible = True
                    lblMessage.Text = strReturn
                    'If lblMessage.Text.Contains("Vehicle") Then
                    '    If cntr = 0 Then
                    '        lblMessage.Visible = True
                    '        lblMessage.Text = strReturn
                    '        cntr = cntr + 1
                    '    End If


                    'Else

                    'End If
                    Exit Sub

                Else

                    lblMessage.Visible = False
                    'lblMessage.Text = strReturn

                End If
            Next

            Dim objAgency As New GenericCollection(Of IEntity)
            Dim objRisk As New GenericCollection(Of IEntity)
            Dim objHome As New GenericCollection(Of IEntity)
            Dim objInsurance As New GenericCollection(Of IEntity)
            Dim objCoverage As New GenericCollection(Of IEntity)
            Dim objQuote As New GenericCollection(Of IEntity)
            Dim objAddition As New GenericCollection(Of IEntity)

            For Each subscriber In H03subscribers
                If subscriber.SubscriberName = "HistoryDescriptiondetails" Then
                    objInsurance = subscriber.GetH03InputData 'objInsurance.list.Item(3).TypeOfLosses	"NonWind-Hail" {String}	Object
                ElseIf subscriber.SubscriberName = "RiskDescriptiondetails" Then
                    objRisk = subscriber.GetH03InputData
                ElseIf subscriber.SubscriberName = "AgencyDetails" Then
                    objAgency = subscriber.GetH03InputData
                ElseIf subscriber.SubscriberName = "HomeDescriptiondetails" Then
                    objHome = subscriber.GetH03InputData
                ElseIf subscriber.SubscriberName = "CoverageDescriptiondetails" Then
                    objCoverage = subscriber.GetH03InputData
                ElseIf subscriber.SubscriberName = "QuoteDescriptiondetails" Then
                    objQuote = subscriber.GetH03InputData
                ElseIf subscriber.SubscriberName = "AdditionNotes" Then
                    objAddition = subscriber.GetH03InputData
                End If
            Next
            'Read RiskDescription & HomeDescription And CreateXML 
            Dim mybytearray As Byte() = CreateXML(objHome, objRisk)
            CType(objRisk.Item(0), GarageQuoteSheetDLL.H03.H03RiskDetails).HomeDescription = mybytearray

            Dim objH03QuoteDataModelDM As New H03QuoteDataModel

            Dim strQuoteNumber As String
            strQuoteNumber = objH03QuoteDataModelDM.save(objAgency, objRisk, objInsurance, objCoverage, objQuote, objAddition)
            lblMessage.Visible = True
            lblMessage.Text = "Quote has been submitted successfully; Quote Number is " & strQuoteNumber
            logger.Info("Quote has been submitted successfully; Quote Number is " & strQuoteNumber)

            'Send(Mail)

            Dim body As String
            Dim strAttachmentFileName As String = ""

            Dim objAgencyDesc As GarageQuoteSheetDLL.GarageQuote = CType(objAgency.Item(0), GarageQuoteSheetDLL.GarageQuote)
            'Create PdfFile
            ConfigureCrystalReports(strQuoteNumber, objAgencyDesc.AgentID)
            If objAgencyDesc.Email <> "" Then

                Dim objMail As New MailQuote
                body = "HomeOwners  Quote Generated" & vbCrLf & "QuoteNumber is: " & strQuoteNumber & vbCrLf _
                   & "Thank you for your submission, Someone in our transportation division will be contacting you " & vbCrLf _
                    & "within 24 to 48 hours. Should you have any questions, please feel free to give us a call. " & vbCrLf _
                    & vbCrLf & "Thank you again for choosing SIU."

                strAttachmentFileName = xmlConfig.GetComponentProperty("H03", "ExportPDFPath") & "/" & objAgencyDesc.AgentID & strQuoteNumber & ".pdf"
                Dim ArrayAsAttachment = New ArrayList
                ArrayAsAttachment.Add(strAttachmentFileName)
                objMail.Sendmail("H03@siuins.com", objAgencyDesc.Email, "Homeowner Quote Generated", body, ArrayAsAttachment)
                logger.Info("Mail for Quote Number : " & strQuoteNumber & " has been sent.")
            End If
            Dim strExportVirtualPath As String = xmlConfig.GetComponentProperty("H03", "ExportedPDFVirtualPath")
            'Diagnostics.Process.Start(strAttachmentFileName)
            Dim strFileToOpen As String = strExportVirtualPath & "/" & objAgencyDesc.AgentID & strQuoteNumber & ".pdf"
            Dim strScript = "<Script Language='JavaScript'>window.open('" & strFileToOpen & "','','status=0,toolbar=0');</Script>"
            Response.Write(strScript)
            'logger.Info("Redirecting to Default.aspx")
            'Session.Clear()
            'Response.Redirect("Default.aspx")

            'Response.Redirect(strExportVirtualPath & "/" & objAgencyDesc.AgentID & strQuoteNumber & ".pdf")
            ''Response.Redirect("./Report/ReportViewer.aspx?RptId=1&QuoteId=" + strQuoteNumber)

            'Dim objGenericIEntity As New GenericCollection(Of IEntity)
            'If Not (objAgency Is Nothing) Then
            '    If objAgency.Count > 0 Then
            '        objGenericIEntity.Add(objAgency.Item(0))
            '    End If
            'End If
            'If Not (objRisk Is Nothing) Then
            '    If objRisk.Count > 0 Then
            '        objGenericIEntity.Add(objRisk.Item(0))
            '    End If
            'End If
            'If Not (objHome Is Nothing) Then
            '    If objHome.Count > 0 Then
            '        objGenericIEntity.Add(objHome.Item(0))
            '    End If
            'End If
            'If Not (objInsurance Is Nothing) Then
            '    If objInsurance.Count > 0 Then
            '        objGenericIEntity.Add(objInsurance.Item(0))
            '    End If
            'End If
            'If Not (objCoverage Is Nothing) Then
            '    If objCoverage.Count > 0 Then
            '        objGenericIEntity.Add(objCoverage.Item(0))
            '    End If

            'End If
            'If Not (objQuote Is Nothing) Then
            '    If objQuote.Count > 0 Then
            '        objGenericIEntity.Add(objQuote.Item(0))
            '    End If

            'End If

        Catch ex As Exception
            lblMessage.Visible = True
            lblMessage.Text = "Quote could not be submitted.Please contact H03  Dept."
            logger.Error("Exception occurred while Savinsubmitting Quote", ex)
            logger.Error("Exception Details :" & ex.StackTrace)

        End Try
        logger.Debug("Exiting Application.aspx.SaveH03QuoteData")

    End Sub
    ''' <summary>
    ''' "CreateXml using Home & Risk Description Object"
    ''' </summary>
    ''' <param name="objHomeDesc"></param>
    ''' <param name="objRiskDesc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateXML(ByVal objHomeDesc As GenericCollection(Of IEntity), ByVal objRiskDesc As GenericCollection(Of IEntity)) As Byte()

        Dim objRisk As GarageQuoteSheetDLL.H03.H03RiskDetails = CType(objRiskDesc.Item(0), GarageQuoteSheetDLL.H03.H03RiskDetails)
        Dim XMLDoc As New XmlDocument
        Dim XmlDecl As XmlDeclaration
        XmlDecl = XMLDoc.CreateXmlDeclaration("1.0", "UTF-8", "")
        XMLDoc.AppendChild(XmlDecl)
        Dim strFileName As String = Server.MapPath("Home-RiskDescription.xml")

        Dim elmApplicantInformation As XmlElement = XMLDoc.CreateElement("ApplicantInfo")
        XMLDoc.AppendChild(elmApplicantInformation)
        '' Create XmlElements For RiskDescription
        Dim elmRiskDescription As XmlElement = XMLDoc.CreateElement("RiskDescription")
        elmApplicantInformation.AppendChild(elmRiskDescription)

        Dim elmFName As XmlElement = XMLDoc.CreateElement("FirstName")
        elmRiskDescription.AppendChild(elmFName)
        elmFName.InnerText = objRisk.ApplicantFName.ToString()

        Dim elmLName As XmlElement = XMLDoc.CreateElement("LastName")
        elmRiskDescription.AppendChild(elmLName)
        elmLName.InnerText = objRisk.ApplicantLName.ToString()

        Dim elmMInitial As XmlElement = XMLDoc.CreateElement("MInitial")
        elmRiskDescription.AppendChild(elmMInitial)
        elmMInitial.InnerText = objRisk.ApplicantMName.ToString()

        Dim elmLAddress1 As XmlElement = XMLDoc.CreateElement("LAddress1")
        elmRiskDescription.AppendChild(elmLAddress1)
        elmLAddress1.InnerText = objRisk.LocationAddLineOne.ToString()

        Dim elmLAddress2 As XmlElement = XMLDoc.CreateElement("LAddress2")
        elmRiskDescription.AppendChild(elmLAddress2)
        elmLAddress2.InnerText = objRisk.LocationAddLineTwo.ToString()

        Dim elmLCity As XmlElement = XMLDoc.CreateElement("LCity")
        elmRiskDescription.AppendChild(elmLCity)
        elmLCity.InnerText = objRisk.LocationCity.ToString()

        Dim elmLState As XmlElement = XMLDoc.CreateElement("LState")
        elmRiskDescription.AppendChild(elmLState)
        elmLState.InnerText = objRisk.LocationState.ToString()

        Dim elmLZipCode As XmlElement = XMLDoc.CreateElement("LZipCode")
        elmRiskDescription.AppendChild(elmLZipCode)
        elmLZipCode.InnerText = objRisk.LocationZipcode.ToString()

        Dim elmLCounty As XmlElement = XMLDoc.CreateElement("LCounty")
        elmRiskDescription.AppendChild(elmLCounty)
        elmLCounty.InnerText = objRisk.LocationCounty.ToString()

        Dim elmTerritory As XmlElement = XMLDoc.CreateElement("Territory")
        elmRiskDescription.AppendChild(elmTerritory)
        elmTerritory.SetAttribute("TerritoryCode", objRisk.TerritoryCode)
        elmTerritory.SetAttribute("TerritoryName", objRisk.TerritoryName)


        Dim elmLHomePhone As XmlElement = XMLDoc.CreateElement("LHomePhone")
        elmRiskDescription.AppendChild(elmLHomePhone)
        elmLHomePhone.InnerText = objRisk.HomePhone.ToString()

        Dim elmLWorkPhone As XmlElement = XMLDoc.CreateElement("LWorkPhone")
        elmRiskDescription.AppendChild(elmLWorkPhone)
        elmLWorkPhone.InnerText = objRisk.WorkPhone.ToString()

        Dim elmMailAddress As XmlElement = XMLDoc.CreateElement("MailingAddress")
        elmRiskDescription.AppendChild(elmMailAddress)
        elmMailAddress.SetAttribute("SameAsLocationAddress", objRisk.SameMailingAddress.ToString())

        Dim elmMAddress1 As XmlElement = XMLDoc.CreateElement("MAddress1")
        elmRiskDescription.AppendChild(elmMAddress1)
        elmMAddress1.InnerText = objRisk.MailingAddLineOne.ToString()

        Dim elmMAddress2 As XmlElement = XMLDoc.CreateElement("MAddress2")
        elmRiskDescription.AppendChild(elmMAddress2)
        elmMAddress2.InnerText = objRisk.MailingAddLineTwo.ToString()

        Dim elmMCity As XmlElement = XMLDoc.CreateElement("MCity")
        elmRiskDescription.AppendChild(elmMCity)
        elmMCity.InnerText = objRisk.MailingCity.ToString()

        Dim elmMState As XmlElement = XMLDoc.CreateElement("MState")
        elmRiskDescription.AppendChild(elmMState)
        elmMState.InnerText = objRisk.MailingState.ToString()

        Dim elmMZipCode As XmlElement = XMLDoc.CreateElement("MZipCode")
        elmRiskDescription.AppendChild(elmMZipCode)
        elmMZipCode.InnerText = objRisk.MailingZipcode.ToString()

        Dim elmMCounty As XmlElement = XMLDoc.CreateElement("MCounty")
        elmRiskDescription.AppendChild(elmMCounty)
        elmMCounty.InnerText = objRisk.MailingCounty.ToString()

        Dim elmLienHolder As XmlElement = XMLDoc.CreateElement("LienHolder")
        elmRiskDescription.AppendChild(elmLienHolder)
        elmLienHolder.InnerText = objRisk.LienHolder.ToString()

        Dim elmComments As XmlElement = XMLDoc.CreateElement("Comments")
        elmRiskDescription.AppendChild(elmComments)
        elmComments.InnerText = objRisk.Commnets.ToString()

        '' Create XmlElements For HomeDescription
        Dim elmHomeDescription As XmlElement = XMLDoc.CreateElement("HomeDescription")
        elmApplicantInformation.AppendChild(elmHomeDescription)

        Dim objHome As GarageQuoteSheetDLL.H03.HomeDetails = CType(objHomeDesc.Item(0), GarageQuoteSheetDLL.H03.HomeDetails)
        Dim elmOccupancy As XmlElement = XMLDoc.CreateElement("Occupancy")
        elmHomeDescription.AppendChild(elmOccupancy)
        elmOccupancy.InnerText = objHome.Occupancy.ToString()

        Dim elmConstruction As XmlElement = XMLDoc.CreateElement("ConstructionType")
        elmHomeDescription.AppendChild(elmConstruction)
        elmConstruction.InnerText = objHome.ConstructionType.ToString()

        Dim elmYearBuilt As XmlElement = XMLDoc.CreateElement("YearBuilt")
        elmHomeDescription.AppendChild(elmYearBuilt)
        elmYearBuilt.InnerText = objHome.YearBuilt.ToString()

        Dim elmProtectionClass As XmlElement = XMLDoc.CreateElement("ProtectionClass")
        elmHomeDescription.AppendChild(elmProtectionClass)
        elmProtectionClass.InnerText = objHome.ProtectiveClass.ToString()

        Dim elmProtectiveDevice As XmlElement = XMLDoc.CreateElement("ProtectiveDevice")
        elmHomeDescription.AppendChild(elmProtectiveDevice)
        elmProtectiveDevice.InnerText = objHome.ProtectiveDevices.ToString()

        Dim elmFamilies As XmlElement = XMLDoc.CreateElement("Families")
        elmHomeDescription.AppendChild(elmFamilies)
        elmFamilies.InnerText = objHome.Families.ToString()

        Dim elmCoastalWater As XmlElement = XMLDoc.CreateElement("MilesToCoastalWater")
        elmHomeDescription.AppendChild(elmCoastalWater)
        elmCoastalWater.InnerText = objHome.MilestoCoastal.ToString()

        Dim elmMilesToFireStation As XmlElement = XMLDoc.CreateElement("MilesToFireStation")
        elmHomeDescription.AppendChild(elmMilesToFireStation)
        elmMilesToFireStation.InnerText = objHome.MilesToFireStation.ToString()


        Dim elmPool As XmlElement = XMLDoc.CreateElement("Pool")
        elmHomeDescription.AppendChild(elmPool)
        elmPool.InnerText = objHome.Pool.ToString()

        Dim elmTrampoline As XmlElement = XMLDoc.CreateElement("Trampoline")
        elmHomeDescription.AppendChild(elmTrampoline)
        elmTrampoline.InnerText = objHome.Trampoline.ToString()

        Dim elmPets As XmlElement = XMLDoc.CreateElement("Pets")
        elmHomeDescription.AppendChild(elmPets)
        If Convert.ToBoolean(objHome.HasPets) = True Then
            elmPets.InnerText = objHome.Pets.ToString()
        Else
            elmPets.InnerText = ""

        End If
        'elmPets.InnerText = IIf(IsNothing(objHome.Pets), "", objHome.Pets.ToString())
        elmPets.SetAttribute("HasPets", objHome.HasPets.ToString())

        Dim elmRoofAge As XmlElement = XMLDoc.CreateElement("RoofAge")
        elmHomeDescription.AppendChild(elmRoofAge)
        elmRoofAge.InnerText = objHome.RoofAge.ToString()

        Dim elmFootage As XmlElement = XMLDoc.CreateElement("SquareFootage")
        elmHomeDescription.AppendChild(elmFootage)
        elmFootage.InnerText = objHome.SquareFootage.ToString()

        Dim elmStories As XmlElement = XMLDoc.CreateElement("Stories")
        elmHomeDescription.AppendChild(elmStories)
        elmStories.InnerText = objHome.Stories.ToString()

        Dim elmHydrant As XmlElement = XMLDoc.CreateElement("FireHydrant")
        elmHomeDescription.AppendChild(elmHydrant)
        elmHydrant.InnerText = objHome.FeetFrmHydrant.ToString()

        Dim elmFireStation As XmlElement = XMLDoc.CreateElement("FireStation")
        elmHomeDescription.AppendChild(elmFireStation)
        elmFireStation.InnerText = objHome.MilesToFireStation.ToString()

        Dim elmFireDistrict As XmlElement = XMLDoc.CreateElement("FireDistrict")
        elmHomeDescription.AppendChild(elmFireDistrict)
        elmFireDistrict.InnerText = objHome.FireDistrict.ToString()

        Dim elmWindProtectiveDevice As XmlElement = XMLDoc.CreateElement("WindProtectiveDevice")
        elmHomeDescription.AppendChild(elmWindProtectiveDevice)
        elmWindProtectiveDevice.InnerText = objHome.ProtectiveDevices.ToString()

        If File.Exists(strFileName) Then
            File.Delete(strFileName)
        End If
        XMLDoc.Save(strFileName)
        '' Read the xml file and convert into byte array & then delete the file
        Dim objfilestream As FileStream
        objfilestream = New FileStream(Server.MapPath("Home-RiskDescription.xml"), FileMode.Open, FileAccess.Read)
        Dim len As Integer
        len = CInt(objfilestream.Length)
        Dim mybytearray(len) As Byte
        mybytearray = New Byte(len - 1) {}
        objfilestream.Read(mybytearray, 0, len)
        objfilestream.Close()
        If File.Exists(strFileName) Then
            File.Delete(strFileName)
        End If

        Return mybytearray

    End Function

    Sub uploadedFiles()
        Dim SavePath As String = xmlConfig.GetComponentProperty("ImageRight", "IDXFilePath")
        Dim Ext As String = ""
        Dim Name As String = ""

        If upl1.HasFile Then
            Try
                Ext = Path.GetExtension(upl1.PostedFile.FileName)
                Name = Path.GetFileNameWithoutExtension(upl1.PostedFile.FileName)
                While (Name.Length < 10)
                    Name = String.Concat("0", Name)
                End While
                upl1.SaveAs(SavePath & _
                    Name + Ext)
                Dim filename As String = upl1.PostedFile.FileName
                If (filename.Contains("\")) Then
                    filename = filename.Substring(filename.LastIndexOf("\") + 1)
                End If
                Fileslst.Add(filename)
                NameLst.Add(Name)
                lblFile1.Text = upl1.PostedFile.FileName
            Catch ex As Exception
                lblFile1.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblFile1.Text = "You have not specified a file."
        End If
        If upl2.HasFile Then
            Try
                Ext = Path.GetExtension(upl2.PostedFile.FileName)
                Name = Path.GetFileNameWithoutExtension(upl2.PostedFile.FileName)
                While (Name.Length < 10)
                    Name = String.Concat("0", Name)
                End While
                upl2.SaveAs(SavePath & _
                    Name + Ext)
                Dim filename As String = upl2.PostedFile.FileName
                If (filename.Contains("\")) Then
                    filename = filename.Substring(filename.LastIndexOf("\") + 1)
                End If
                Fileslst.Add(filename)
                NameLst.Add(Name)
                lblFile2.Text = upl2.PostedFile.FileName
            Catch ex As Exception
                lblFile2.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblFile2.Text = "You have not specified a file."
        End If
        If upl3.HasFile Then
            Try
                Ext = Path.GetExtension(upl3.PostedFile.FileName)
                Name = Path.GetFileNameWithoutExtension(upl3.PostedFile.FileName)
                While (Name.Length < 10)
                    Name = String.Concat("0", Name)
                End While
                upl3.SaveAs(SavePath & _
                    Name + Ext)
                NameLst.Add(Name)
                Dim filename As String = upl3.PostedFile.FileName
                If (filename.Contains("\")) Then
                    filename = filename.Substring(filename.LastIndexOf("\") + 1)
                End If
                Fileslst.Add(filename)
                lblFile3.Text = upl3.PostedFile.FileName
            Catch ex As Exception
                lblFile3.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblFile3.Text = "You have not specified a file."
        End If
        If upl4.HasFile Then
            Try
                Ext = Path.GetExtension(upl4.PostedFile.FileName)
                Name = Path.GetFileNameWithoutExtension(upl4.PostedFile.FileName)
                While (Name.Length < 10)
                    Name = String.Concat("0", Name)
                    While (Name.Length < 10)
                        Name = String.Concat("0", Name)
                    End While
                End While
                upl4.SaveAs(SavePath & _
                    Name + Ext)
                NameLst.Add(Name)

                Dim filename As String = upl4.PostedFile.FileName
                If (filename.Contains("\")) Then
                    filename = filename.Substring(filename.LastIndexOf("\") + 1)
                End If
                Fileslst.Add(filename)
                lblFile4.Text = upl4.PostedFile.FileName
            Catch ex As Exception
                lblFile4.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblFile4.Text = "You have not specified a file."
        End If
        If upl5.HasFile Then
            Try
                Ext = Path.GetExtension(upl5.PostedFile.FileName)
                Name = Path.GetFileNameWithoutExtension(upl5.PostedFile.FileName)
                While (Name.Length < 10)
                    Name = String.Concat("0", Name)
                End While
                upl5.SaveAs(SavePath & _
                    Name + Ext)
                NameLst.Add(Name)
                Dim filename As String = upl5.PostedFile.FileName
                If (filename.Contains("\")) Then
                    filename = filename.Substring(filename.LastIndexOf("\") + 1)
                End If
                Fileslst.Add(filename)
                lblFile5.Text = upl5.PostedFile.FileName
            Catch ex As Exception
                lblFile5.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblFile5.Text = "You have not specified a file."
        End If
    End Sub
    ''' <summary>
    ''' Save CommercialAuto QuoteData
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveCommercialQuoteData()
        logger.Debug("Entering Application.aspx.SaveCommercialQuoteData")
        Dim subscriber As ISubscriber
        Try


            For Each subscriber In subscribers
                If subscriber.Name <> "VehicleDetails" Then
                    Dim strReturn = subscriber.Validate()
                    If (String.IsNullOrEmpty(strReturn) = False) Then
                        lblMessage.Visible = True
                        lblMessage.Text = strReturn
                        lbl1.Visible = True
                        lblmsg1.Visible = True
                        lblmsg1.Text = strReturn
                        lbl2.Visible = True
                        btnSubmit.Focus()
                        Exit Sub
                    Else
                        lblMessage.Visible = False
                        lblmsg1.Visible = False
                        lbl1.Visible = False
                        lbl2.Visible = False

                        'lblMessage.Text = strReturn
                    End If
                End If
            Next
            System.Threading.Thread.Sleep(5000)
            ' This warning section has been commented as per request by Paul on 01 NOV 2010
            'For warning on Vehicle
            'For Each subscriber In subscribers
            '    If subscriber.Name = "VehicleDetails" Then
            '        Dim strReturn = subscriber.Validate()
            '        If (String.IsNullOrEmpty(strReturn) = False) Then

            '            lblMessage.Visible = True
            '            lblMessage.Text = strReturn
            '            lbl1.Visible = True
            '            lblmsg1.Visible = True
            '            lblmsg1.Text = strReturn
            '            lbl2.Visible = True

            '            btnSubmit.Focus()
            '            Exit Sub
            '        Else
            '            lblMessage.Visible = False
            '            lblmsg1.Visible = False
            '            lbl1.Visible = False
            '            lbl2.Visible = False
            '            'lblMessage.Text = strReturn
            '        End If
            '    End If
            'Next

            Dim objQuoteData As New GenericCollection(Of IEntity)
            Dim objOperations As New GenericCollection(Of IEntity)
            Dim objCoverages As New GenericCollection(Of IEntity)
            Dim objInsuranceHistroy As New GenericCollection(Of IEntity)
            Dim objVehicles As New GenericCollection(Of IEntity)
            Dim objDrivers As New GenericCollection(Of IEntity)
            Dim objAdditionnotes As New GenericCollection(Of IEntity)

            For Each subscriber In subscribers
                If subscriber.Name = "VehicleDetails" Then
                    objVehicles = subscriber.GetInputData()
                End If
                If subscriber.Name = "AgencyDetails" Then
                    objQuoteData = subscriber.GetInputData()
                End If
                If subscriber.Name = "InsuranceDetails" Then
                    objInsuranceHistroy = subscriber.GetInputData()
                End If
                If subscriber.Name = "CoverageDetails" Then
                    objCoverages = subscriber.GetInputData()
                End If
                If subscriber.Name = "DriverDetails" Then
                    objDrivers = subscriber.GetInputData()
                End If
                If subscriber.Name = "OperationDetails" Then
                    objOperations = subscriber.GetInputData()
                End If
                If subscriber.Name = "AdditionNotes" Then
                    objAdditionnotes = subscriber.GetInputData()
                End If
            Next


            Dim objCommercialQuoteDM As New CommercialQuoteDataModel

            Dim STRQUOTENUMBER As String
            STRQUOTENUMBER = objCommercialQuoteDM.save(objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionnotes)
            hdnSubmit.Value = "0"
            lblMessage.Visible = True
            lblMessage.Text = "QUOTE HAS BEEN SUBMITTED SUCCESSFULLY; QUOTE NUMBER IS " & STRQUOTENUMBER
            logger.Info(lblMessage.Text)


            'Send Mail


            Dim objgarquot As GarageQuote
            objgarquot = objQuoteData.Item(0)
            'Dim stremail As String = objgarquot.Email.ToString
            'Dim objMail As New MailQuote
            'objMail.mail2Agent(Session("AgentCode") & strQuoteNumber, stremail)
            'logger.Info("Mail for Quote Number : " & strQuoteNumber & " has been sent.")

            Dim objGenericIEntity As New GenericCollection(Of IEntity)
            If Not (objQuoteData Is Nothing) Then
                If objQuoteData.Count > 0 Then
                    objGenericIEntity.Add(objQuoteData.Item(0))
                End If
            End If
            If Not (objOperations Is Nothing) Then
                If objOperations.Count > 0 Then
                    objGenericIEntity.Add(objOperations.Item(0))
                End If
            End If
            If Not (objCoverages Is Nothing) Then
                If objCoverages.Count > 0 Then
                    objGenericIEntity.Add(objCoverages.Item(0))
                End If
            End If
            If Not (objInsuranceHistroy Is Nothing) Then
                If objInsuranceHistroy.Count > 0 Then
                    objGenericIEntity.Add(objInsuranceHistroy.Item(0))
                    'objGenericIEntity.Add(CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory)
                End If
            End If
            If Not (objVehicles Is Nothing) Then
                If objVehicles.Count > 0 Then
                    objGenericIEntity.Add(objVehicles.Item(0))
                End If

            End If
            If Not (objDrivers Is Nothing) Then
                If objDrivers.Count > 0 Then
                    objGenericIEntity.Add(objDrivers.Item(0))
                End If
            End If

            '''''''''' ************** Save to AIM Databse *****************************************************
            Dim AgencyInfo As UserControl = Page.FindControl("AgencyInfo")
            Dim Agency As Label = AgencyInfo.FindControl("lblAgentStatus")
            If Agency.Text.Trim() = "ACCOUNT CURRENT" Then
                SaveToAIM()
            End If

            ''''''''''''******************* Save User Attachemnts to Shared Location***************
            uploadedFiles()

            ''''''''''''''create PDF file

            Dim blnPDFCreated As Boolean
            Dim objPDF As New PDFCreater
            Dim _isSuccess As Boolean = True
            blnPDFCreated = objPDF.CreatePDF(objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionnotes, STRQUOTENUMBER, "2", Fileslst)
            If Not blnPDFCreated Then
                _isSuccess = False
                lblMessage.Visible = True
                logger.Error("Error in Creating PDF")
                lblMessage.Text = "Quote Saved but error occurred while creating pdf"
                logger.Info(lblMessage.Text)
                Exit Sub
            Else
                logger.Info("PDF has been created for Quote Number : " & STRQUOTENUMBER)
            End If


            ''''''''''''send email''''''''''''''''''''''
            If Not objgarquot.Email = "" Or Not objgarquot.Email Is Nothing Then
                Dim stremail As String = objgarquot.Email.ToString
                Dim objMail As New MailQuote
                objMail.mail2Agent(STRQUOTENUMBER, stremail, Fileslst)
                logger.Info("Mail for Quote Number : " & STRQUOTENUMBER & " has been sent to : " & stremail)
            End If

            If Not objgarquot.Fax = "" Or Not objgarquot.Fax Is Nothing Then
                Dim objMailFax As New MailQuote
                objMailFax.mail2AgentwhenFax(Session("AgentCode") & STRQUOTENUMBER)
                logger.Info("Mail for Quote Number (fax to agent): " & STRQUOTENUMBER & " has been sent . ")
            End If


            'Dim objService As New SIUService.Service()
            'If objService.isUnderwriter(IpAddress) = False Then
            '    'Dim blnPDFCreated As Boolean
            '    'Dim blnImageRightCreated As Boolean
            '    'Dim objPDF As New PDFCreater
            '    'blnPDFCreated = objPDF.CreatePDF(objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionnotes, strQuoteNumber, "2")
            '    'If Not blnPDFCreated Then
            '    '    _isSuccess = False
            '    '    lblMessage.Visible = True
            '    '    logger.Error("Error in Creating PDF")
            '    '    lblMessage.Text = "Quote Saved but error occurred while creating pdf"
            '    '    Exit Sub
            '    'Else
            '    '    logger.Info("PDF has been created for Quote Number : " & strQuoteNumber)
            '    'End If


            '    '''''''''''''''''''''''create imageright
            '    Dim objIR As New CreateImageRight
            '    Dim blnImageRightCreated As Boolean
            '    blnImageRightCreated = objIR.CreateIDXfile(STRQUOTENUMBER, "2")
            '    If Not blnImageRightCreated Then
            '        _isSuccess = False
            '        lblMessage.Visible = True
            '        logger.Error("Error in Creating Imageright Task")
            '        lblMessage.Text = "Quote saved but error in Creating Imageright Task"
            '        Exit Sub
            '    Else
            '        logger.Info("Imageright task has been submitted for Quote Number : " & STRQUOTENUMBER)
            '    End If
            'End If






            Dim objService As New SIUService.ServiceSoapClient()
            'If objService.isUnderwriter(IpAddress) = False Then
            '    'Dim blnPDFCreated As Boolean
            '    'Dim blnImageRightCreated As Boolean
            '    'Dim objPDF As New PDFCreater
            '    'blnPDFCreated = objPDF.CreatePDF(objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionnotes, strQuoteNumber, "2")
            '    'If Not blnPDFCreated Then
            '    '    _isSuccess = False
            '    '    lblMessage.Visible = True
            '    '    logger.Error("Error in Creating PDF")
            '    '    lblMessage.Text = "Quote Saved but error occurred while creating pdf"
            '    '    Exit Sub
            '    'Else
            '    '    logger.Info("PDF has been created for Quote Number : " & strQuoteNumber)
            '    'End If
            'imageright task creation re-enabled on 21 april 2010

            '''''''''''''''''''''''create imageright

            Dim blnImageRightCreated As Boolean
            
            If (Convert.ToInt32(ConfigurationManager.AppSettings("VersionID") > 1)) Then
                Dim objWcfImageRightService = New WcfImageRightService.ImageRightServiceClient()

                Dim objQuote As New GarageQuoteDataModel
                Dim objQuoteData1 As IEntity
                objQuoteData1 = objQuote.GetQuoteDetailsByQuoteId(STRQUOTENUMBER, "2")
                Dim strAplicantname As String = String.Empty
                Dim strBusinessName As String = String.Empty
                If Not (objOperations Is Nothing) Then
                    If objOperations.Count > 0 Then
                        strAplicantname = CType(objOperations.Item(0), GarageOperations).ApplicantName
                        strAplicantname = strAplicantname.ToUpper


                        strBusinessName = CType(objOperations.Item(0), GarageOperations).BusinessName

                    End If
                End If

                strBusinessName = strBusinessName.ToUpper
                If strBusinessName = "" Then
                    strBusinessName = strAplicantname
                End If



                STRQUOTENUMBER = CType(objQuoteData1, GarageQuote).GarageQuoteNumber
                If STRQUOTENUMBER.Length >= 7 Then STRQUOTENUMBER = STRQUOTENUMBER & "0"

                If STRQUOTENUMBER.Length = 6 Then STRQUOTENUMBER = STRQUOTENUMBER & "00"

                If STRQUOTENUMBER.Length = 5 Then STRQUOTENUMBER = STRQUOTENUMBER & "000"

                If STRQUOTENUMBER.Length = 4 Then STRQUOTENUMBER = STRQUOTENUMBER & "0000"

                If STRQUOTENUMBER.Length = 3 Then STRQUOTENUMBER = STRQUOTENUMBER & "00000"

                If STRQUOTENUMBER.Length = 2 Then STRQUOTENUMBER = STRQUOTENUMBER & "000000"

                If STRQUOTENUMBER.Length = 1 Then STRQUOTENUMBER = STRQUOTENUMBER & "0000000"
                Dim Dictpara As New Dictionary(Of Object, Object)()

                Dictpara.Add("AppID", ConfigurationManager.AppSettings("AppID").ToString())
                Dictpara.Add("AppTaskID", ConfigurationManager.AppSettings("Taskid-SaveCommercialQuoteData").ToString())

                Dictpara.Add("VersionID", ConfigurationManager.AppSettings("VersionID").ToString())

                Dictpara.Add("IMPORTFILENAME", STRQUOTENUMBER + ".Pdf")
                Dictpara.Add("FILENUMBER", strBusinessName)
                Dictpara.Add("FILENAME", strBusinessName)
                Dictpara.Add("PAGEDESCRIPTION", "")
                Dictpara.Add("CategoryID", 0)
                Dim sDate As String = DateTime.Now.ToString("yyyyMMdd")
                Dictpara.Add("DATE", sDate)

                blnImageRightCreated = True
                objWcfImageRightService.BuildIdxAssigned(Dictpara)


            Else
                Dim objIR As New CreateImageRight

                blnImageRightCreated = objIR.CreateIDXfile(STRQUOTENUMBER, "2", NameLst)
            End If

            If Not blnImageRightCreated Then
                _isSuccess = False
                lblMessage.Visible = True
                logger.Error("Error in Creating Imageright Task")
                lblMessage.Text = "Quote saved but error in Creating Imageright Task"
                logger.Info(lblMessage.Text)
                Exit Sub
            Else
                logger.Info("Imageright task has been submitted for Quote Number : " & STRQUOTENUMBER)
            End If
            'End If

            'rvig





            Session("SearchedQuoteid") = "" 'strQuoteNumber
            Session("AgentCode") = ""
            Dim strQueryString As String
            Dim strContentUrl As String = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString


            logger.Debug("Exiting Application.SaveCommercialQuoteData")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            If _isSuccess = True Then

                If Not IsNothing(Session("TAG")) Then
                    If Session("TAG") = "922HOME" Then
                        strContentUrl = ConfigurationManager.AppSettings("922ContentHomeUrl").ToString
                        strQueryString = "?USR=" & Session("usr").ToString & "&pw=" & Session("pw").ToString & "&LOGIN_ID=" & Session("LOGIN_ID").ToString & "&LOGIN_TYPE=" & Session("LOGIN_TYPE").ToString & "&TAG=" & Session("TAG").ToString
                        logger.Info("Redirecting to  " & strContentUrl & strQueryString)
                        Session.Clear()
                        Response.Redirect(strContentUrl & strQueryString)
                    End If
                    If Session("TAG") = "922HOMEPAGE" Then
                        strContentUrl = ConfigurationManager.AppSettings("UnderwritingCommAutoHomeUrl").ToString
                        strQueryString = "?TITLE=" & Session("TAG").ToString
                        logger.Info("Redirecting to  " & strContentUrl & strQueryString)
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
                    'ScriptManager.RegisterStartupScript(Me, [GetType](), "Show Modal Popup", "showmodalpopup();", True)

                    'pnlpopup.Style.Add("display", "block")
                    'btnSubmit.Enabled = False
                    'btnSearch.Enabled = False

                    'logger.Info("Redirecting to Default.aspx")
                    'Session.Clear()
                    'Response.Redirect("Default.aspx")
                    mpeConfirm.Show()
                End If
            End If

        Catch tex As System.Threading.ThreadAbortException

        Catch ex As Exception
            lblMessage.Visible = True
            lblMessage.Text = "Quote could not be submitted.Please contact Commercial Transportation Dept."
            logger.Info(lblMessage.Text)
            logger.Error("Exception occurred while Savinsubmitting Quote", ex)
            logger.Error("Exception Details :" & ex.StackTrace)

        End Try
        logger.Debug("Exiting Application.SaveCommercialQuoteData")

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
    Private Sub Attach(ByVal Subscriber As ISubscriber) Implements IPublisher.Attach
        subscribers.Add(Subscriber)
    End Sub
    Private Sub H03AttachSubscriber(ByVal Subscriber As H03ISubscriber) Implements H03IPublisher.H03AttachSubscriber
        H03subscribers.Add(Subscriber)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        logger.Debug("Entering Application.btnSearch_Click")
        Dim subscriber As ISubscriber
        Try
            For Each subscriber In subscribers

                If subscriber.Name = "SearchQuotes" Then
                    subscriber.FillControls(Session("AgentCode").ToString)
                End If
            Next
            If Not (Session("SearchedQuoteid") Is Nothing) Then
                Session("SearchedQuoteid") = ""
            End If
        Catch ex As Exception

        End Try
        logger.Debug("Exiting application.btnSearch_Click")
    End Sub

    ''' <summary>
    ''' Validate InputData
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
        'Validation Part Here

        Dim strReturn As String = ""

        Return (strReturn)
        logger.Debug("Exiting H03Quotecontrol.Validate")


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
    ''' Implements GetH03InputData
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
        Return Nothing
    End Function
    ''' <summary>
    ''' Show Error Message
    ''' </summary>
    ''' <param name="strMessage"></param>
    ''' <remarks></remarks>
    Sub ShowMessage(ByVal strMessage As String) Implements H03ISubscriber.ShowMessage
        If (String.IsNullOrEmpty(strMessage) = False) Then
            lblMessage.Visible = True
            lblMessage.Text = strMessage
            Exit Sub
        End If
    End Sub

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
            'strContentUrl = ConfigurationManager.AppSettings("SIURateUrl").ToString
            Response.Redirect("~\default.aspx")
        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim myProcess As Process = New Process
        ''myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        'myProcess.StartInfo.FileName = HttpContext.Current.Session("CommercialAttachmentFileName").ToString
        'myProcess.StartInfo.Verb = "Print"
        'myProcess.StartInfo.UseShellExecute = True
        'myProcess.Start()
        'myProcess.WaitForInputIdle()

        'If myProcess.Responding Then
        '    myProcess.CloseMainWindow()
        'Else
        '    myProcess.Kill()
        'End If
        Dim stream As MemoryStream = DirectCast(HttpContext.Current.Session("MemStream"), MemoryStream)

        Response.ContentType = "Application/pdf"
        Response.AppendHeader("Content-Disposition", "attachment; filename=Test_PDF.pdf")
        Dim length As Integer = CInt(stream.Length)
        Response.OutputStream.Write(stream.GetBuffer(), 0, length)

        ' Finish.
        Response.Flush()

        ' This is required.
        Response.SuppressContent = True

        ' Response.ContentType = "Application/pdf"


        Response.End()
        'PrintFinalPDF()
        mpeConfirm.Show()
    End Sub
    Public Sub PrintFinalPDF()

        Dim strDefaultPrinterName As String
        Dim strPrinterName As String
        Dim strMergedFileToPrint As String = HttpContext.Current.Session("CommercialAttachmentFileName").ToString
        'If strDefaultPrinterName <> "" Then
        'Save Default Printer Name
        strDefaultPrinterName = System.Configuration.ConfigurationSettings.AppSettings("PrinterName")
        Debug.Print(strDefaultPrinterName)
        '----------------------------------------------------------------------------------------------------

        Dim pathToExecutable As String = "AcroRd32.exe"
        Dim sReport = strMergedFileToPrint              'Complete name/path of PDF file
        'Dim SPrinter = "iR5050"                         'Name Of printer
        Dim starter As New ProcessStartInfo
        Dim Process As New Process()

        strPrinterName = strDefaultPrinterName
        Debug.Print(strPrinterName)

        Process.StartInfo = starter
        Process.StartInfo.UseShellExecute = True
        Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.StartInfo.FileName = strMergedFileToPrint
        Process.StartInfo.Verb = "print"
        Process.Start()
        Process.WaitForInputIdle()
        Process.CloseMainWindow()

        '----------------------------------------------------------------------------------------------------
        'Restore Default Printer
        'DefaultPrinter.DefaultPrinterName = strDefaultPrinterName
        'End If

    End Sub

    ''' <summary>
    ''' Set CoverageB & CoverageD 
    ''' </summary>
    ''' <param name="CoverageB"></param>
    ''' <param name="CoverageD"></param>
    ''' <remarks></remarks>
    Sub SetCoverage(ByVal CoverageB As String, ByVal CoverageD As String) Implements H03ISubscriber.SetCoverage

    End Sub
    ''' <summary>
    ''' Configure Crystal Report Based on QuoteId
    ''' </summary>
    ''' <param name="_intQuoteid"></param>
    ''' <remarks></remarks>
    Private Sub ConfigureCrystalReports(ByVal _intQuoteid As Integer, ByVal strAgentId As String)
        Dim objH03Quote As New GarageQuoteSheetDLL.H03QuoteDataModel
        Dim DsProperty As System.Data.DataSet = objH03Quote.GetQuoteDetails(_intQuoteid)
        Dim Dr As DataRow = dsPersonalProperty.Tables(0).NewRow
        Dim _intCol As Integer = 0
        For _intCol = 0 To DsProperty.Tables(0).Columns.Count - 1
            If DsProperty.Tables(0).Columns(_intCol).ColumnName <> "HomeDescription" Then
                Select Case (DsProperty.Tables(0).Columns(_intCol).ColumnName)
                    Case "A_DwellingAmount", "C_PersonalProperty", "E_Liability", "F_MedPay", "B_AdjacentStructure", "D_LossofUse"
                        Dim strValue As String = Val(DsProperty.Tables(0).Rows(0)(_intCol)).ToString()
                        Dr(DsProperty.Tables(0).Columns(_intCol).ColumnName) = String.Format("{0:C0}", Double.Parse(strValue.Replace("'", ""))).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "")
                    Case Else
                        Dr(DsProperty.Tables(0).Columns(_intCol).ColumnName) = DsProperty.Tables(0).Rows(0)(_intCol)
                End Select
            Else
                ''Extract XML
                Dim docbinaryarray As Byte() = DirectCast(DsProperty.Tables(0).Rows(0)("HomeDescription"), Byte())
                Dim strFileName = System.Guid.NewGuid.ToString()
                Dim TargetPath As String = Server.MapPath(strFileName + ".xml")
                Dim objfilestream As New FileStream(TargetPath, FileMode.Create, FileAccess.ReadWrite)
                objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length)
                objfilestream.Close()
                Dim Tr As TextReader = New StreamReader(TargetPath)
                Dim _strMenuXml As String = Tr.ReadToEnd()
                Dim NList As XmlNodeList = GetXmlNodeList(_strMenuXml, "RiskDescription")
                For Each Node As XmlNode In NList.Item(0)
                    Select Case Node.Name.Trim()
                        Case "MAddress1"
                            Dr("MAddress1") = Node.InnerText.Trim()
                        Case "MAddress2"
                            Dr("MAddress2") = Node.InnerText.Trim()
                        Case "MCity"
                            Dr("MCity") = Node.InnerText.Trim()
                        Case "MState"
                            Dr("MState") = Node.InnerText.Trim()
                        Case "MZipCode"
                            Dr("MZip") = Node.InnerText.Trim()
                            'Case "MCounty"

                    End Select
                Next
                NList = GetXmlNodeList(_strMenuXml, "HomeDescription")
                For Each Node As XmlNode In NList.Item(0)
                    Select Case Node.Name.Trim()
                        Case "Occupancy"
                            Dr("Occupancy") = Node.InnerText.Trim()
                        Case "ConstructionType"
                            Dr("ConstructionType") = Node.InnerText.Trim()
                        Case "YearBuilt"
                            Dr("YearBuilt") = Node.InnerText.Trim()
                        Case "ProtectionClass"
                            Dr("ProtectionClass") = Node.InnerText.Trim()
                        Case "Families"
                            Dr("NumberOfFamilies") = Node.InnerText.Trim()
                        Case "MilesToCoastalWater"
                            Dr("MilestoCoastal") = Node.InnerText.Trim()
                        Case "Pool"
                            Dr("Pool") = Node.InnerText.Trim()
                        Case "Trampoline"
                            Dr("Trampoline") = Node.InnerText.Trim()
                        Case "SquareFootage"
                            Dr("SqFootage") = Node.InnerText.Trim()
                        Case "Stories"
                            Dr("Stories") = Node.InnerText.Trim()
                        Case "MilesToFireStation"
                            Dr("MilestoStation") = Node.InnerText.Trim()
                        Case "FireHydrant"
                            Dr("FeetFromHyd") = Node.InnerText.Trim()
                            'Case "Stories"
                            '    Dr("Stories") = Node.InnerText.Trim()
                            'Case "Stories"
                            '    Dr("Stories") = Node.InnerText.Trim()
                    End Select
                Next
                Tr.Close()
                If File.Exists(TargetPath) Then
                    File.Delete(TargetPath)
                End If
            End If
        Next
        dsPersonalProperty.Tables(0).Rows.Add(Dr)
        PersonalProperty.Load(Server.MapPath("./Report/CrptPersonalProperty.rpt"))
        PersonalProperty.SetDataSource(dsPersonalProperty)

        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
        Dim strExportPath As String = xmlConfig.GetComponentProperty("H03", "ExportPDFPath")
        Dim _strFileName As String = strAgentId & _intQuoteid.ToString() & ".pdf"

        SavePdfFile(strExportPath, _strFileName)
        'Export2Pdf()
        ''PrintPdf()
    End Sub
    ''' <summary>
    ''' SavePdf File using FileStreem
    ''' </summary>
    ''' <remarks></remarks>
    Sub SavePdfFile(ByVal strExportPath As String, ByVal _strFileName As String)
        'Dim rptSummary As ReportDocument
        If File.Exists(strExportPath & "\" & _strFileName) Then
            File.Delete(strExportPath & "\" & _strFileName)
        End If
        Dim objExOpt As ExportOptions
        Dim objDiskOpt As New DiskFileDestinationOptions
        ' ... process your report here ...

        objDiskOpt.DiskFileName = strExportPath & "\" & _strFileName
        objExOpt = PersonalProperty.ExportOptions
        objExOpt.ExportDestinationType = ExportDestinationType.DiskFile
        objExOpt.ExportFormatType = ExportFormatType.PortableDocFormat
        objExOpt.DestinationOptions = objDiskOpt
        PersonalProperty.Export()
        PersonalProperty.Close()




    End Sub
    ''' <summary>
    ''' Export2Pdf
    ''' </summary>
    ''' <remarks></remarks>
    Sub Export2Pdf()
        ''PersonalProperty.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "PersonalProperty")
        Dim oStream As New MemoryStream
        Try
            oStream = PersonalProperty.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(oStream.ToArray())
            Response.End()
        Catch ex As Exception

        End Try
    End Sub
    Sub PrintPdf()
        'Dim margins As PageMargins = PersonalProperty.PrintOptions.PageMargins
        'margins.bottomMargin = 200
        'margins.leftMargin = 200
        'margins.rightMargin = 50
        'margins.topMargin = 100
        'PersonalProperty.PrintOptions.ApplyPageMargins(margins)
        PersonalProperty.PrintToPrinter(1, False, 1, 1)
    End Sub
    ''' <summary>
    ''' GetXml NodeList
    ''' </summary>
    ''' <param name="_strXML"></param>
    ''' <param name="strElementName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetXmlNodeList(ByVal _strXML As String, ByVal strElementName As String) As XmlNodeList
        'ApplicantInfo/RiskDescriptionxmlDoc.SelectNodes("ApplicantInfo/RiskDescription")
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(_strXML)
        Dim _xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("ApplicantInfo/" + strElementName)
        Return _xmlNodeList
    End Function



    Protected Sub lbl1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl1.Init

    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

    End Sub
End Class

