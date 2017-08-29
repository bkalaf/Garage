
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports GarageQuoteSheetDLL
Imports log4net
Imports System.Collections.Generic



Namespace UserControl947

    Partial Class CommAutoOperationControl
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Implements IPublisher
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Dim vaidatemsg As String
        Dim strName As String = "OperationDetails"
        Dim genOperationCollection As GenericCollection(Of IEntity)
        Dim subscribers As New List(Of ISubscriber)

#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"

        Private objOperation As GarageOperations

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            txtCity.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
            txtCountry.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")

            txtZIP.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
            txtyrs.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
            txtyrs.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
            txtZIP.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
            txtState.Attributes.Add("onkeypress", "Javascript:return AllowAlphabet();")


            logger.Debug("Entering CommAutoOperationControl.Page_Load")

            If Not IsPostBack Then
                Try
                    txtmultfilings.Enabled = False
                    txtMplVehicleslisted.Enabled = False

                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            Else

                If rdfilingsAnsYes.Checked = True Then

                    txtmultfilings.Enabled = True

                Else
                    txtmultfilings.Enabled = False


                End If


                If rdovehivlesListesAnsYes.Checked Then

                    txtMplVehicleslisted.Enabled = True
                Else
                    txtMplVehicleslisted.Enabled = False

                End If


            End If



            logger.Debug("Exiting CommAutoOperationControl.Page_Load")


        End Sub

        Private Function Validate() As String Implements ISubscriber.Validate
            'Validation Part Here
            logger.Debug("Entering CommAutoOperationControl.Validate")
            Try

                Dim objCommQuoteDM As New GarageOperationsDataModel
                If Not objCommQuoteDM.CheckStateforCommAuto(txtState.Text.Trim.ToUpper) Then
                    lblStateMsg.Text = "Invalid State"
                    vaidatemsg = "Please enter valid state)"
                    txtState.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)
                Else

                    lblStateMsg.Text = ""

                End If

                If rdfilingsAnsYes.Checked = True Then

                    txtmultfilings.Enabled = True

                Else
                    txtmultfilings.Enabled = False


                End If


                If rdovehivlesListesAnsYes.Checked Then

                    txtMplVehicleslisted.Enabled = True
                Else
                    txtMplVehicleslisted.Enabled = False

                End If

                If ddlYearsInBusiness.SelectedValue = -1 Then


                    vaidatemsg = "Select Number of  years  in Business (Operations)"
                    ddlYearsInBusiness.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)

                End If







                If rdoIndivudual.Checked = False And rdoCorporation.Checked = False And rdoPartnerShip.Checked = False And rdollc.Checked = False Then

                    vaidatemsg = "Select Type of Business (Operations)"
                    rdoIndivudual.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)



                End If

                If rdfilingsAnsYes.Checked = False And rdfilingsAnsNo.Checked = False Then

                    vaidatemsg = "Select Filings Sequired (Operations)"
                    rdfilingsAnsYes.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)



                End If
                If rdovehivlesListesAnsYes.Checked = False And rdovehivlesListesAnsNo.Checked = False Then

                    vaidatemsg = "Select Vehicle Listed (Operations)"
                    rdovehivlesListesAnsYes.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)


                End If
                If rdfilingsAnsNo.Checked = False Then

                    If txtmultfilings.Text = "" Then
                        txtmultfilings.Enabled = True
                        vaidatemsg = "Please explain filings(Operations)"
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoOperationControl.Validate")
                        Return (vaidatemsg)
                    End If

                    'Else


                    '    Return (vaidatemsg)
                End If






                If rdovehivlesListesAnsNo.Checked = False Then


                    If txtMplVehicleslisted.Text = "" Then
                        txtMplVehicleslisted.Enabled = True
                        vaidatemsg = "if No,Please explain Vehicles Listed (Operations)"
                        txtMplVehicleslisted.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoOperationControl.Validate")
                        Return (vaidatemsg)

                    End If
                    'Else

                    '    Return (vaidatemsg)


                End If

                If (txtaddress.Text = "") Then
                    txtaddress.Enabled = True
                    vaidatemsg = "if No,Please explain Vehicles Listed (Operations)"
                    txtaddress.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)

                End If

                If (txtCity.Text = "") Then
                    txtCity.Enabled = True
                    vaidatemsg = "if No,Please explain Vehicles Listed (Operations)"
                    txtCity.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoOperationControl.Validate")
                    Return (vaidatemsg)

                End If




            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try

            logger.Info(vaidatemsg)
            logger.Debug("Exiting CommAutoOperationControl.Validate")
            Return (vaidatemsg)





        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData

            genOperationCollection = New GenericCollection(Of IEntity)

            objOperation = New GarageOperations()
            objOperation.GarageOperationId = 0
            objOperation.ApplicantName = txtApplicantName.Text.Trim
            objOperation.BusinessName = txtTradeName.Text.Trim
            objOperation.GarageAddress = txtaddress.Text.Trim
            objOperation.State = txtState.Text.Trim

            objOperation.City = txtCity.Text.Trim
            objOperation.ZipCode = txtZIP.Text.Trim

            objOperation.County = txtCountry.Text.Trim


            If rdoIndivudual.Checked = True Then

                objOperation.BusinessType = "Individual"



            ElseIf rdoPartnerShip.Checked = True Then
                objOperation.BusinessType = "Partnership"

            ElseIf rdoCorporation.Checked = True Then
                objOperation.BusinessType = "Corporation"


            ElseIf rdollc.Checked = True Then
                objOperation.BusinessType = "LLC"
            End If

            logger.Info("Quote is being submitted for " & vbCrLf & " Applicant Name : " & objOperation.ApplicantName _
                      & vbCrLf & " Trade Name : " & objOperation.BusinessName _
                        & vbCrLf & " BusinessType : " & objOperation.BusinessType _
            & vbCrLf & " Garage Address : " & objOperation.GarageAddress _
            & vbCrLf & " State : " & objOperation.State _
            & vbCrLf & " City : " & objOperation.City _
            & vbCrLf & " ZIP Code : " & objOperation.ZipCode)

            objOperation.OperationInsured = txtMplOperations.Text


            objOperation.YearsInsured = txtyrs.Text.Trim


            objOperation.YrsInBusiness = Int32.Parse(ddlYearsInBusiness.SelectedValue.ToString())



            Dim IO As New InsuredOperation
            IO.OperationDetails = txtMplOperations.Text
            Dim objGInsuredOprations As New GenericCollection(Of InsuredOperation)
            objGInsuredOprations.Add(IO)
            CType(objOperation, GarageOperations).InsuredOperations = objGInsuredOprations


            objOperation.YearsSameTypeVehicles = txtnumyrs.Text.Trim

            If rdfilingsAnsYes.Checked = True Then

                objOperation.IsFillingRequired = 1
                objOperation.FillingDetails = txtmultfilings.Text.Trim

            Else

                objOperation.IsFillingRequired = 0
            End If
            If rdovehivlesListesAnsYes.Checked = True Then

                objOperation.AreAllVehiclesListed = 1
                objOperation.ListedVehicleDetails = txtMplVehicleslisted.Text.Trim

            Else

                objOperation.AreAllVehiclesListed = 0
            End If


            objOperation.CommoditiesHauled = txtMplCommoditieshauled.Text.Trim

            objOperation.OperationRadius = txtradius.Text.Trim

            objOperation.OperationCities = txtmulticities.Text.Trim






            genOperationCollection.Add(objOperation)

            Return genOperationCollection
        End Function

        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory


        End Sub

        Protected Sub ddlYearsInBusiness_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYearsInBusiness.SelectedIndexChanged


            SetInsuranceHistoryVisibility(ddlYearsInBusiness.SelectedIndex)
            'txtyrs.TabIndex = 16
            'txtyrs.Focus()
            ddlYearsInBusiness.Focus()

        End Sub
        Private Sub SetInsuranceHistoryVisibility(ByVal intIndex As Integer)
            AttachSubscriber()
            Dim subscriber As ISubscriber
            For Each subscriber In subscribers
                If subscriber.Name = "InsuranceDetails" Then
                    subscriber.ShowHideHistory(intIndex)
                End If
            Next
        End Sub
        Sub AttachSubscriber()
            Dim ctrl As Control
            Dim Insuctrl As Control

            For Each ctrl In Me.Parent.Parent.Controls
                ' ForEach ctrl In Me.Parent.Controls
                ' If Me.Parent.ClientID.ToString = "InsuranceHistoryPh" Then
                'Response.Write(ctrl.ID)
                If ctrl.ClientID.ToString().Contains("InsuranceHistoryPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("AutoCommInsuranceHistorycontrol") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
            Next
        End Sub
        Private Sub Attach(ByVal Subscriber As ISubscriber) Implements IPublisher.Attach
            subscribers.Add(Subscriber)
        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoOperationControl.FillControls")
            Dim objOperations As GenericCollection(Of IEntity)
            Dim objOperationDM As GarageOperationsDataModel
            Dim objOperation As GarageOperations

            Try
                objOperations = New GenericCollection(Of IEntity)
                objOperationDM = New GarageOperationsDataModel()
                objOperations = objOperationDM.Getdata(strQuoteId, "1")
                If objOperations.Count > 0 Then
                    objOperation = CType(objOperations.Item(0), GarageOperations)
                    txtApplicantName.Text = objOperation.ApplicantName
                    txtTradeName.Text = objOperation.BusinessName
                    txtaddress.Text = objOperation.GarageAddress
                    txtCity.Text = objOperation.City
                    txtCountry.Text = objOperation.County
                    txtState.Text = objOperation.State
                    Session("State") = objOperation.State.ToUpper
                    txtZIP.Text = objOperation.ZipCode
                    Select Case objOperation.BusinessType
                        Case "Individual"
                            rdoIndivudual.Checked = True
                            rdoPartnerShip.Checked = False
                            rdoCorporation.Checked = False
                            rdollc.Checked = False
                        Case "Partnership"
                            rdoPartnerShip.Checked = True
                            rdoIndivudual.Checked = False
                            rdoCorporation.Checked = False
                            rdollc.Checked = False
                        Case "Corporation"
                            rdoCorporation.Checked = True
                            rdoIndivudual.Checked = False
                            rdoPartnerShip.Checked = False
                            rdollc.Checked = False
                        Case "LLC"
                            rdollc.Checked = True
                            rdoIndivudual.Checked = False
                            rdoPartnerShip.Checked = False
                            rdoCorporation.Checked = False

                    End Select
                    ddlYearsInBusiness.SelectedIndex = -1

                    ddlYearsInBusiness.Items.FindByValue(objOperation.YrsInBusiness).Selected = True

                    SetInsuranceHistoryVisibility(ddlYearsInBusiness.SelectedIndex)
                    txtyrs.Text = objOperation.YearsInsured

                    txtMplOperations.Text = objOperation.OperationInsured

                    'If Not (objOperation.InsuredOperations Is Nothing) Then
                    '    If objOperation.InsuredOperations.Count > 0 Then
                    '        txtMplOperations.Text = CType(objOperation.InsuredOperations.Item(0), InsuredOperation).OperationDetails
                    '    End If
                    'End If
                    'If Not IsNothing(objOperation.InsuredOperations) And objOperation.InsuredOperations.Count > 0 Then
                    '    txtMplOperations.Text = CType(objOperation.InsuredOperations.Item(0), InsuredOperation).OperationDetails
                    'End If
                    txtnumyrs.Text = objOperation.YearsSameTypeVehicles

                    If objOperation.IsFillingRequired = 1 Then
                        rdfilingsAnsYes.Checked = True
                        rdfilingsAnsNo.Checked = False
                        txtmultfilings.Text = objOperation.FillingDetails
                        txtmultfilings.Enabled = True

                    Else
                        rdfilingsAnsYes.Checked = False
                        rdfilingsAnsNo.Checked = True
                        txtmultfilings.Text = ""
                        txtmultfilings.Enabled = False
                    End If

                    If objOperation.AreAllVehiclesListed = 1 Then
                        rdovehivlesListesAnsYes.Checked = True
                        rdovehivlesListesAnsNo.Checked = False
                        txtMplVehicleslisted.Text = objOperation.ListedVehicleDetails
                        txtMplVehicleslisted.Enabled = True
                    Else
                        rdovehivlesListesAnsYes.Checked = False
                        rdovehivlesListesAnsNo.Checked = True
                        txtMplVehicleslisted.Text = ""
                        txtMplVehicleslisted.Enabled = False

                    End If

                    txtMplCommoditieshauled.Text = objOperation.CommoditiesHauled
                    txtmulticities.Text = objOperation.OperationCities
                    txtradius.Text = objOperation.OperationRadius

                End If
            Catch ex As Exception
                logger.Error("Exception occurred while Setting values in Operation Details for Quote ID :" & strQuoteId, ex)
                logger.Error("Exception Details :" & ex.StackTrace)
                Throw ex
            End Try
            logger.Debug("Exiting CommAutoOperationControl.FillControls")

        End Function

        Protected Sub txtState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtState.TextChanged
            Dim objCommQoteDM As New GarageOperationsDataModel

            If objCommQoteDM.CheckStateforCommAuto(txtState.Text.Trim.ToUpper) Then
                lblStateMsg.Text = ""
                SetState(txtState.Text.ToString.ToUpper)
            Else
                lblStateMsg.Text = "Invalid State"
                Exit Sub
            End If


        End Sub
        Private Sub SetState(ByVal state As String)
            AttachSubscriberstate()
            Dim subscriber As ISubscriber
            For Each subscriber In subscribers
                If subscriber.Name = "CoverageDetails" Then
                    subscriber.ShowState(state)
                End If
            Next
        End Sub
        Sub AttachSubscriberstate()
            Dim ctrl As Control
            Dim Insuctrl As Control

            For Each ctrl In Me.Parent.Parent.Controls
                ' ForEach ctrl In Me.Parent.Controls
                ' If Me.Parent.ClientID.ToString = "InsuranceHistoryPh" Then
                'Response.Write(ctrl.ID)
                If ctrl.ClientID.ToString().Contains("Coverageph") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("Coverage") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
            Next
        End Sub
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub
    End Class




End Namespace

