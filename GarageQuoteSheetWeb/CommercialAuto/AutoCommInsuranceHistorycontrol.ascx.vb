Imports GarageQuoteSheetDLL
Imports log4net
Namespace UserControl947

    Partial Class AutoCommInsuranceHistorycontrol
        Inherits System.Web.UI.UserControl
        Implements ISubscriber

        Private Shared logger As log4net.ILog = _
             log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
        Dim fyear1, fyear2, fyear3 As Integer
        Dim tyear1, tyear2, tyear3 As Integer
        Dim frmyear1, frmyear2, frmyear3 As String
        Dim toyear1, toyear2, toyear3 As String
        Dim frmdate1, todate1, frmdate2, frmdate3, todate2, todate3 As DateTime
        Dim vaidatemsg As String
        Public MMDDYYYY As String = DateTime.Now.Month.ToString() & "/" & DateTime.Now.Day.ToString() & "/" & DateTime.Now.Year.ToString()


#Region "DataMembers"
        Public genInsuranceHistoryColl As GenericCollection(Of IEntity)
        Public genInsuranceLossHistoryColl As GenericCollection(Of InsuranceLossHistory)
        Public objInsuaranceHistory As InsuranceHistory
        Public objInsuarancelossHistory As InsuranceLossHistory
        Public strName As String = "InsuranceDetails"
#End Region
#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


            If Not IsPostBack Then
                Try
                    txtMplPolicyCancelledDetails.Enabled = False
                    txtMplPolicyNotRenewalDetail.Enabled = False

                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            Else

                'If rdoPrePolicyCnAnsYes.Checked = True Then

                '    txtMplPolicyCancelledDetails.Enabled = True

                'End If
                'If rdoPrePolicyNonRenewedAnsYes.Checked = True Then

                '    txtMplPolicyNotRenewalDetail.Enabled = True

                'End If

            End If



        End Sub

        Private Function Validate() As String Implements ISubscriber.Validate
            logger.Debug("Entering AutoCommInsuranceHistorycontrol.Validate")
            'Validation Part Here
            Try

                If rdoPrePolicyCnAnsYes.Checked = True Then

                    txtMplPolicyCancelledDetails.Enabled = True
                Else


                    txtMplPolicyCancelledDetails.Enabled = False
                End If

                If rdoPrePolicyNonRenewedAnsYes.Checked = True Then

                    txtMplPolicyNotRenewalDetail.Enabled = True
                Else

                    txtMplPolicyNotRenewalDetail.Enabled = False


                End If

                If txtTermFrom1.Text <> "" Or txtTermto1.Text <> "" Or txtCarrier1.Text <> "" Or txtAmtpaid1.Text <> "" Then
                    If txtTermFrom1.Text = "" Or txtTermto1.Text = "" Or txtCarrier1.Text = "" Or txtAmtpaid1.Text = "" Then
                        vaidatemsg = "Fill the entrire row 1 of Prior Coverage and Loss History (Insurance History)"
                        txtTermFrom1.Focus()

                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
                        Return (vaidatemsg)
                    End If
                Else
                    vaidatemsg = ""
                End If

                If txtTermFrom2.Text <> "" Or txtTermto2.Text <> "" Or txtCarrier2.Text <> "" Or txtAmtpaid2.Text <> "" Then

                    If txtTermFrom2.Text = "" Or txtTermto2.Text = "" Or txtCarrier2.Text = "" Or txtAmtpaid2.Text = "" Then

                        vaidatemsg = "Fill the entrire row 2 of Prior Coverage and Loss History (Insurance History)"
                        txtTermFrom2.Focus()

                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
                        Return (vaidatemsg)
                    End If
                Else
                    vaidatemsg = ""
                End If

                If txtTermFrom3.Text <> "" Or txtTermto3.Text <> "" Or txtCarrier3.Text <> "" Or txtAmtpaid3.Text <> "" Then

                    If txtTermFrom3.Text = "" Or txtTermto3.Text = "" Or txtCarrier3.Text = "" Or txtAmtpaid3.Text = "" Then

                        vaidatemsg = "Fill the entrire row 3 of Prior Coverage and Loss History (Insurance History)"
                        txtTermFrom3.Focus()

                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
                        Return (vaidatemsg)
                    End If

                Else
                    vaidatemsg = ""
                End If


                If rdoPrePolicyCnAnsYes.Checked Then

                    If txtMplPolicyCancelledDetails.Text = "" Then

                        vaidatemsg = "If Yes,Please explain Previous Policy Cancelled (Insurance History)"
                        txtMplPolicyCancelledDetails.Enabled = True

                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
                        Return (vaidatemsg)
                    End If

                    'Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)
                End If



                If rdoPrePolicyNonRenewedAnsYes.Checked Then

                    If txtMplPolicyNotRenewalDetail.Text = "" Then

                        vaidatemsg = "If Yes,Please explain Previous Policy Non-Renewed (Insurance History)"
                        txtMplPolicyNotRenewalDetail.Enabled = True


                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
                        Return (vaidatemsg)
                    End If


                    'Else
                    '    Return (vaidatemsg)
                End If




            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try

            logger.Info(vaidatemsg)
            logger.Debug("Exiting AutoCommInsuranceHistorycontrol.Validate")
            Return (vaidatemsg)


        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            logger.Debug("Entring AutoCommInsuranceHistorycontrol.GetInputData")
            Try
                'Dim fyear1, fyear2, fyear3 As Integer
                'Dim tyear1, tyear2, tyear3 As Integer
                'Dim frmyear1, frmyear2, frmyear3 As String
                'Dim toyear1, toyear2, toyear3 As String
                'Dim frmdate1, todate1, frmdate2, frmdate3, todate2, todate3 As DateTime
                'If txtTermFrom1.Text <> "" And txtTermto1.Text <> "" Then


                '    toyear1 = ""
                '    frmyear1 = ""
                '    frmdate1 = txtTermFrom1.Text
                '    todate1 = txtTermto1.Text
                '    fyear1 = frmdate1.Year
                '    tyear1 = todate1.Year
                '    If fyear1 > 1 And fyear1 <= 9 Then
                '        frmyear1 = "200" & fyear1
                '    End If

                '    If tyear1 > 1 And tyear1 <= 9 Then
                '        toyear1 = "200" & tyear1
                '    End If

                '    If tyear1 > 9 And tyear1 < 99 Then
                '        toyear1 = "20" & tyear1
                '    End If

                '    If fyear1 > 9 And fyear1 < 99 Then
                '        frmyear1 = "20" & fyear1
                '    End If
                '    txtTermFrom1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
                '    txtTermto1.Text = todate1.Month.ToString & "/" + todate1.Day.ToString & "/" + toyear1.ToString
                'End If
                'If txtTermFrom2.Text <> "" And txtTermto2.Text <> "" Then


                '    toyear2 = ""
                '    frmyear2 = ""
                '    frmdate2 = txtTermFrom2.Text
                '    todate2 = txtTermto2.Text
                '    fyear2 = frmdate2.Year
                '    tyear2 = todate2.Year
                '    If fyear2 > 1 And fyear2 <= 9 Then
                '        frmyear2 = "200" & fyear2
                '    End If

                '    If tyear2 > 1 And tyear2 <= 9 Then
                '        toyear2 = "200" & tyear2
                '    End If

                '    If tyear2 > 9 And tyear2 <= 99 Then
                '        toyear2 = "20" & tyear2
                '    End If

                '    If fyear2 > 9 And fyear2 <= 99 Then
                '        frmyear2 = "20" & fyear2
                '    End If
                '    txtTermFrom2.Text = frmdate2.Month.ToString & "/" + frmdate2.Day.ToString & "/" + frmyear2.ToString
                '    txtTermto2.Text = todate2.Month.ToString & "/" + todate2.Day.ToString & "/" + toyear2.ToString
                'End If
                'If txtTermFrom3.Text <> "" And txtTermto3.Text <> "" Then


                '    toyear3 = ""
                '    frmyear3 = ""
                '    frmdate3 = txtTermFrom3.Text
                '    todate3 = txtTermto3.Text
                '    fyear3 = frmdate3.Year
                '    tyear3 = todate3.Year
                '    If fyear3 > 1 And fyear3 <= 9 Then
                '        frmyear3 = "200" & fyear3
                '    End If

                '    If tyear3 > 1 And tyear3 <= 9 Then
                '        toyear3 = "200" & tyear3
                '    End If

                '    If tyear3 > 9 And tyear3 <= 99 Then
                '        toyear3 = "20" & tyear3
                '    End If

                '    If fyear3 > 9 And fyear3 <= 99 Then
                '        frmyear3 = "20" & fyear3
                '    End If
                '    txtTermFrom3.Text = frmdate3.Month.ToString & "/" + frmdate3.Day.ToString & "/" + frmyear3.ToString
                '    txtTermto3.Text = todate3.Month.ToString & "/" + todate3.Day.ToString & "/" + toyear3.ToString
                'End If

                genInsuranceHistoryColl = New GenericCollection(Of IEntity)
                genInsuranceLossHistoryColl = New GenericCollection(Of InsuranceLossHistory)
                objInsuaranceHistory = New InsuranceHistory()
                objInsuarancelossHistory = New InsuranceLossHistory()
                objInsuaranceHistory.InsuranceHistoryId = 0

                If rdoPrePolicyCnAnsYes.Checked = True Then
                    objInsuaranceHistory.IsPreviousPolicyCancelled = 1
                    objInsuaranceHistory.CancellationDetails = txtMplPolicyCancelledDetails.Text.Trim
                Else
                    objInsuaranceHistory.IsPreviousPolicyCancelled = 0
                End If
                If rdoPrePolicyNonRenewedAnsYes.Checked = True Then
                    objInsuaranceHistory.IsPreviousPolicyNotRenewed = 1
                    objInsuaranceHistory.NotRenewalDetails = txtMplPolicyNotRenewalDetail.Text.Trim
                Else
                    objInsuaranceHistory.IsPreviousPolicyNotRenewed = 0
                End If

                If txtTermFrom1.Text <> "" Or txtTermto1.Text <> "" Or txtCarrier1.Text <> "" Or txtAmtpaid1.Text <> "" Then
                    objInsuarancelossHistory.LossHistoryId = 0
                    objInsuarancelossHistory.TermFrom = ConvertToValidDateString(txtTermFrom1.Text.Trim)
                    objInsuarancelossHistory.TermTo = ConvertToValidDateString(txtTermto1.Text.Trim)
                    objInsuarancelossHistory.Carrier = txtCarrier1.Text.Trim
                    objInsuarancelossHistory.Amount = txtAmtpaid1.Text.Trim
                    If (txtMplDetails1.Text <> "") Then
                        objInsuarancelossHistory.Details = txtMplDetails1.Text.Trim
                    Else
                        objInsuarancelossHistory.Details = ""
                    End If
                    genInsuranceLossHistoryColl.Add(objInsuarancelossHistory)
                End If
                objInsuarancelossHistory = New InsuranceLossHistory()



                If txtTermFrom2.Text <> "" Or txtTermto2.Text <> "" Or txtCarrier2.Text <> "" Or txtAmtpaid2.Text <> "" Then
                    objInsuarancelossHistory.LossHistoryId = 0
                    objInsuarancelossHistory.TermFrom = ConvertToValidDateString(txtTermFrom2.Text.Trim)
                    objInsuarancelossHistory.TermTo = ConvertToValidDateString(txtTermto2.Text.Trim)
                    objInsuarancelossHistory.Carrier = txtCarrier2.Text.Trim
                    objInsuarancelossHistory.Amount = txtAmtpaid2.Text.Trim
                    If (txtMplDetails2.Text <> "") Then
                        objInsuarancelossHistory.Details = txtMplDetails2.Text.Trim
                    Else
                        objInsuarancelossHistory.Details = ""
                    End If
                    genInsuranceLossHistoryColl.Add(objInsuarancelossHistory)
                End If
                objInsuarancelossHistory = New InsuranceLossHistory()

                If txtTermFrom3.Text <> "" Or txtTermto3.Text <> "" Or txtCarrier3.Text <> "" Or txtAmtpaid3.Text <> "" Then
                    objInsuarancelossHistory.LossHistoryId = 0
                    objInsuarancelossHistory.TermFrom = ConvertToValidDateString(txtTermFrom3.Text.Trim)
                    objInsuarancelossHistory.TermTo = ConvertToValidDateString(txtTermto3.Text.Trim)
                    objInsuarancelossHistory.Carrier = txtCarrier3.Text.Trim
                    objInsuarancelossHistory.Amount = txtAmtpaid3.Text.Trim
                    If (txtMplDetails3.Text <> "") Then
                        objInsuarancelossHistory.Details = txtMplDetails2.Text.Trim
                    Else
                        objInsuarancelossHistory.Details = ""
                    End If
                    genInsuranceLossHistoryColl.Add(objInsuarancelossHistory)
                End If

                objInsuaranceHistory.InsuranceLossHIstory = genInsuranceLossHistoryColl
                genInsuranceHistoryColl.Add(objInsuaranceHistory)

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally
                'genInsuranceHistoryColl = Nothing

            End Try

            Return genInsuranceHistoryColl
            logger.Debug("Exiting AutoCommInsuranceHistorycontrol.GetInputData")
        End Function

        Public Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory
            If index = 1 Then
                pnlInsuranceHistory.Visible = False
            Else
                pnlInsuranceHistory.Visible = True
            End If
        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoVehicleControl.FillControls")
            Dim objInsHistory As GenericCollection(Of IEntity)
            Dim objInsLossHistory As GenericCollection(Of IEntity)
            Dim objInsHistoryDM As InsuranceHistoryDataModel
            Dim objInsLossHistoryDM As InsuranceLossHistoryDataModel
            Dim objHistory As InsuranceHistory
            Dim objLossHistory As InsuranceLossHistory
            Dim iCount As Integer
            Try
                objInsHistory = New GenericCollection(Of IEntity)
                objInsHistoryDM = New InsuranceHistoryDataModel()
                objInsHistory = objInsHistoryDM.GetData(strQuoteId, "1")
                objHistory = New InsuranceHistory
                objLossHistory = New InsuranceLossHistory
                For Each objHistory In objInsHistory

                    If CType(objHistory, InsuranceHistory).IsPreviousPolicyCancelled = 1 Then
                        rdoPrePolicyCnAnsYes.Checked = True
                        rdoPrePolicyCnAnsNo.Checked = False
                        txtMplPolicyCancelledDetails.Text = objHistory.CancellationDetails
                        txtMplPolicyCancelledDetails.Enabled = True
                    Else
                        rdoPrePolicyCnAnsYes.Checked = False
                        rdoPrePolicyCnAnsNo.Checked = True
                        txtMplPolicyCancelledDetails.Text = ""
                        txtMplPolicyCancelledDetails.Enabled = False

                    End If

                    If CType(objHistory, InsuranceHistory).IsPreviousPolicyNotRenewed = 1 Then
                        rdoPrePolicyNonRenewedAnsYes.Checked = True
                        rdoPrePolicyNonRenewedAnsNo.Checked = False
                        txtMplPolicyNotRenewalDetail.Text = objHistory.NotRenewalDetails
                        txtMplPolicyNotRenewalDetail.Enabled = True
                    Else
                        rdoPrePolicyNonRenewedAnsYes.Checked = False
                        rdoPrePolicyNonRenewedAnsNo.Checked = True
                        txtMplPolicyNotRenewalDetail.Text = ""
                        txtMplPolicyNotRenewalDetail.Enabled = False
                    End If
                Next
                objInsHistory = Nothing
                objHistory = Nothing

                objInsLossHistoryDM = New InsuranceLossHistoryDataModel()
                objLossHistory = New InsuranceLossHistory()
                objInsLossHistory = objInsLossHistoryDM.GetData(strQuoteId, "1")

                If objInsLossHistory.Count > 0 Then
                    For iCount = 0 To objInsLossHistory.Count - 1

                        Select Case iCount
                            Case 0
                                txtAmtpaid1.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Amount
                                txtCarrier1.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Carrier
                                txtMplDetails1.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Details
                                txtTermFrom1.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermFrom
                                txtTermto1.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermTo

                            Case 1
                                txtAmtpaid2.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Amount
                                txtCarrier2.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Carrier
                                txtMplDetails2.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Details
                                txtTermFrom2.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermFrom
                                txtTermto2.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermTo

                            Case 2
                                txtAmtpaid3.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Amount
                                txtCarrier3.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Carrier
                                txtMplDetails3.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).Details
                                txtTermFrom3.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermFrom
                                txtTermto3.Text = CType(objInsLossHistory.Item(iCount), InsuranceLossHistory).TermTo

                        End Select

                    Next
                End If


                objInsLossHistory = Nothing
                objLossHistory = Nothing


            Catch ex As Exception
                logger.Error("Exception occurred while setting values in Insurance History :", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
                Throw ex

            End Try
            logger.Debug("Exiting CommAutoInsuranceControl.FillControls")

        End Function
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        'Protected Sub txtTermFrom1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTermFrom1.TextChanged
        '    If txtTermFrom1.Text <> "" Then


        '        If txtTermFrom1.Text <> "__/__/____" Then

        '            Dim firstpart As String
        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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

        '            Dim firstpart As String
        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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

        '            Dim firstpart As String
        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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

        '            Dim firstpart As String
        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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

        '            Dim firstpart As String
        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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
        '            Dim firstpart As String

        '            Dim secpart As String
        '            Dim thrdpart As String
        '            Dim forthpart As String

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

        Private Function ConvertToValidDateString(ByVal pstrDate As String) As String
            Dim strOutDate As String = ""
            If pstrDate <> "__/__/____" Then
                Dim firstpart As String = ""
                Dim secpart As String = ""
                Dim thrdpart As String = ""
                Dim forthpart As String = ""
                Dim mon As Integer
                Dim day As Integer

                If pstrDate.Contains("/") Then
                    firstpart = pstrDate.Substring(0, pstrDate.IndexOf("/"))
                    secpart = pstrDate.Substring(pstrDate.IndexOf("/") + 1)
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
                    pstrDate = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                Else
                    frmyear1 = ""
                    frmdate1 = pstrDate
                    fyear1 = frmdate1.Year
                    strOutDate = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                    If fyear1 >= 1 And fyear1 <= 9 Then
                        frmyear1 = "200" & fyear1
                        strOutDate = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                    End If
                    If fyear1 > 9 And fyear1 <= 40 Then
                        frmyear1 = "20" & fyear1
                        strOutDate = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                    End If
                    If fyear1 > 40 And fyear1 < 99 Then
                        frmyear1 = "19" & fyear1
                        strOutDate = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                    End If
                End If

            End If

            Return strOutDate
        End Function

    End Class
End Namespace

