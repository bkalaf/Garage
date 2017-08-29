Imports GarageQuoteSheetDLL
Imports log4net

Namespace UserControl947
    Partial Class CommAutoCoverageControl
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Dim vaidatemsg As String
        Dim strsate As String
        Dim strName As String = "CoverageDetails"
        'Dim genCoverageCollection As GenericCollection(Of IEntity)
        Private Shared logger As log4net.ILog = _
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"
        Private genCoverageColl As GenericCollection(Of IEntity)
        Private objCoverage As CoverageDetail



#End Region
        Private Function Validate() As String Implements ISubscriber.Validate
            'Validation Part Here
            logger.Debug("Entering CommAutoCoverageControl.Validate")
            Try
                'If rdohiredCnAnsYes.Checked = True Then

                '    txtmultcostofhire.Enabled = True
                'Else

                '    txtmultcostofhire.Enabled = False


                'End If
                'If rdononownedCnAnsYes.Checked = True Then

                '    txtmulttotnumemployees.Enabled = True
                'Else
                '    txtmulttotnumemployees.Enabled = False

                'End If

                'If ddlLimitsliabilitycsl.SelectedValue = 0 Then


                '    vaidatemsg = "Select Limits of Liability CSL(Coverage details)"
                '    ddlLimitsliabilitycsl.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If

                If ddlLimitsliabilitycsl.SelectedValue = 0 And ddllimitsliasplit.SelectedValue = 0 Then


                    vaidatemsg = "Select Limits of Liability Csl or Split(Coverage details)"
                    ddllimitsliasplit.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoCoverageControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)

                End If

                If ddlLimitsliabilitycsl.SelectedValue > 0 And ddllimitsliasplit.SelectedValue > 0 Then


                    vaidatemsg = "Select Limits of Liability either Csl or Split(Coverage details)"
                    ddllimitsliasplit.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoCoverageControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)

                End If

                'If ddluninsuredMotoristcsl.SelectedValue = 0 Then


                '    vaidatemsg = "Select Uninsured Motorist CSL (Coverage details)"
                '    ddluninsuredMotoristcsl.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If

                'If ddluninsuredMotoristcsl.SelectedValue = 0 And ddluninsuredMotoristsplit.SelectedValue = 0 Then


                '    vaidatemsg = "Select Uninsured Motorist Csl or Split (Coverage details)"
                '    ddluninsuredMotoristsplit.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If
                If ddluninsuredMotoristcsl.SelectedValue > 0 And ddluninsuredMotoristsplit.SelectedValue > 0 Then


                    vaidatemsg = "Select Uninsured Motorist either Csl or Split (Coverage details)"
                    ddluninsuredMotoristsplit.Focus()
                    logger.Info(vaidatemsg)
                    logger.Debug("Exiting CommAutoCoverageControl.Validate")
                    Return (vaidatemsg)
                    'Else
                    '    Return (vaidatemsg)

                End If

                'If ddluninsuredMotoristsplit.SelectedIndex > 0 And ddlmedicalpayments.SelectedValue = 0 Then


                '    vaidatemsg = "Select Medical Payments (Coverage details)"
                '    ddlmedicalpayments.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If

                'If ddllimitsliasplit.SelectedIndex > 0 And ddlmedicalpayments.SelectedValue = 0 Then


                '    vaidatemsg = "Select Medical Payments (Coverage details)"
                '    ddlmedicalpayments.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If
                'If ddldedutible.SelectedValue = 0 Then


                '    vaidatemsg = "Select Deductible (Coverage details)"
                '    ddldedutible.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)

                'End If
                'If rdohiredCnAnsYes.Checked = False And rdohiredCnAnsNo.Checked = False Then

                '    vaidatemsg = "Select one option in Hire(Coverage Details)"
                '    rdohiredCnAnsYes.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)



                'End If
                If rdohiredCnAnsYes.Checked Then

                    If txtmultcostofhire.Text = "" Then

                        vaidatemsg = "If Yes,Provide Cost of Hire(Coverage Details)"
                        txtmultcostofhire.Enabled = True
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoCoverageControl.Validate")
                        Return (vaidatemsg)

                    End If

                    'Else
                    '    Return (vaidatemsg)



                End If

                'If rdononownedCnAnsYes.Checked = False And rdononownedCnAnsNo.Checked = False Then

                '    vaidatemsg = "Select one option in Non - Owned(Coverage Details)"
                '    rdononownedCnAnsYes.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)



                'End If




                If rdononownedCnAnsYes.Checked Then


                    If txtmulttotnumemployees.Text = "" Then

                        vaidatemsg = "If Yes, Provide total number of employees (Coverage Details)"
                        txtmulttotnumemployees.Enabled = True
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoCoverageControl.Validate")
                        Return (vaidatemsg)

                    End If

                    'Else
                    '    Return (vaidatemsg)



                End If



                'If txtmotortrukcargo.Text = "" Then
                '    vaidatemsg = "Motor truck cargo/On-Hook cannot be blank (Coverage Details)"
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)


                'End If

                'If rdoreeferbrdwnCnYes.Checked = False And rdoreeferbrdwnCnNo.Checked = False Then

                '    vaidatemsg = "Select one option in Reefer Breakdown(Coverage Details)"
                '    rdoreeferbrdwnCnYes.Focus()
                '    Return (vaidatemsg)
                '    'Else
                '    '    Return (vaidatemsg)



                'End If

                'If rdoaddInsuredCnYes.Checked = False And rdoaddInsuredCnNo.Checked = False Then

                '    vaidatemsg = "Select one option in Additional Insured(Coverage Details)"
                '    rdoaddInsuredCnYes.Focus()
                '    Return (vaidatemsg)

                'Else

                '    vaidatemsg = ""
                '    Return (vaidatemsg)



                'End If




            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try
            logger.Info(vaidatemsg)
            logger.Debug("Exiting CommAutoCoverageControl.Validate")
            Return (vaidatemsg)


        End Function
        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            logger.Debug("Entering CommAutoCoverageControl.GetInputData")
            Try


                genCoverageColl = New GenericCollection(Of IEntity)
                objCoverage = New CoverageDetail()

                objCoverage.CoverageId = 0
                objCoverage.LibilityLimit_Csl = ddlLimitsliabilitycsl.SelectedItem.Text
                objCoverage.LiabilityLimit_Split = ddllimitsliasplit.SelectedItem.Text
                objCoverage.UnInsuredMotorist_Csl = ddluninsuredMotoristcsl.SelectedItem.Text
                objCoverage.UnInsuredMotorist_Split = ddluninsuredMotoristsplit.SelectedItem.Text
                objCoverage.MedPayLimit = ddlmedicalpayments.SelectedItem.Text
                objCoverage.Deductible = ddldedutible.SelectedItem.Text

                If Session("State") = "FL" Then
                    objCoverage.NoOfDealerTags = numofdealertags.Text.Trim
                    objCoverage.PIP = txtpip.Text.Trim
                    objCoverage.AdditionalInfo = txtcargoAI.Text.Trim
                   
                End If
                If chkcargo.Checked Then
                    objCoverage.DeductibleCargo = DeductibleCargo.SelectedItem.Text
                End If

                objCoverage.IsCargo = chkcargo.Checked
                If rdohiredCnAnsYes.Checked = True Then

                    objCoverage.IsHired = 1
                    objCoverage.HiredDetails = txtmultcostofhire.Text.Trim

                Else

                    objCoverage.HiredDetails = 0
                End If



                If rdononownedCnAnsYes.Checked = True Then

                    objCoverage.IsNonOwned = 1
                    objCoverage.NonOwnedDetails = txtmulttotnumemployees.Text.Trim

                Else

                    objCoverage.IsNonOwned = 0
                End If

                objCoverage.TruckCargoDetails = txtmotortrukcargo.Text

                objCoverage.Deductible = ddldedutible.SelectedItem.Text

                If rdoreeferbrdwnCnYes.Checked = True Then

                    objCoverage.IsReeferBreaking = 1


                Else

                    objCoverage.IsReeferBreaking = 0
                End If

                If rdoaddInsuredCnYes.Checked = True Then

                    objCoverage.ISAddtnlInsured = 1


                Else

                    objCoverage.ISAddtnlInsured = 0
                End If
                objCoverage.ReeferBreaking = txtmultlnreeferbrkdwn.Text.Trim
                objCoverage.AddtnlInsuerdDetails = txtmultaddinsured.Text.Trim



                genCoverageColl.Add(objCoverage)
            Catch ex As Exception


                logger.Error("Exception occurred while loadding Coverage Details ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally

                'objCoverage = Nothing

            End Try






            Return genCoverageColl
            logger.Debug("Exiting CommAutoCoverageControl.GetInputData")
        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then
                Try
                    txtmultcostofhire.Enabled = False
                    txtmulttotnumemployees.Enabled = False

                    numdealer.Visible = False
                    trpip.Visible = False
                    cargoaddinfo.Visible = False
                    trdeductiblecargo.Visible = False
                    ddlLimitsliabilitycsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlLimitsliabilitycsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("30,000", "1"))
                    ddlLimitsliabilitycsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("50,000", "2"))
                    ddlLimitsliabilitycsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("75,000", "3"))
                    ddlLimitsliabilitycsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("100,000", "4"))
                    ddlLimitsliabilitycsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("300,000", "5"))
                    ddlLimitsliabilitycsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("350,000", "6"))
                    ddlLimitsliabilitycsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("500,000", "7"))
                    ddlLimitsliabilitycsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("750,000", "8"))
                    ddlLimitsliabilitycsl.Items.Insert(9, New System.Web.UI.WebControls.ListItem("1,000,000", "9"))

                    ddluninsuredMotoristcsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddluninsuredMotoristcsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("20,000", "1"))
                    ddluninsuredMotoristcsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("75,000", "2"))
                    ddluninsuredMotoristcsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("100,000", "3"))
                    ddluninsuredMotoristcsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("300,000", "4"))
                    ddluninsuredMotoristcsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("350,000", "5"))
                    ddluninsuredMotoristcsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("500,000", "6"))
                    ddluninsuredMotoristcsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("750,000", "7"))
                    ddluninsuredMotoristcsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("1,000,000", "8"))



                    ddllimitsliasplit.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))

                    ddluninsuredMotoristsplit.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlmedicalpayments.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddldedutible.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))


                Catch ex As Exception
                    logger.Error("Exception occurred while loading Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            Else

                If rdohiredCnAnsYes.Checked = True Then

                    txtmultcostofhire.Enabled = True

                End If
                If rdononownedCnAnsYes.Checked = True Then

                    txtmulttotnumemployees.Enabled = True

                End If

            End If






        End Sub
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoCoverageControl.FillControls")
            Dim objCoverages As GenericCollection(Of IEntity)
            Dim objCoverageDM As CoverageDetailDataModel
            Dim objCoverage As CoverageDetail
            Dim iCount As Integer
            Try
                objCoverages = New GenericCollection(Of IEntity)
                objCoverageDM = New CoverageDetailDataModel()
                objCoverages = objCoverageDM.getdata(strQuoteId, "1")
                If objCoverages.Count > 0 Then


                    objCoverage = CType(objCoverages.Item(0), CoverageDetail)
                    ddlLimitsliabilitycsl.SelectedIndex = -1
                    ddllimitsliasplit.SelectedIndex = -1
                    ddluninsuredMotoristcsl.SelectedIndex = -1
                    ddluninsuredMotoristsplit.SelectedIndex = -1
                    ddlmedicalpayments.SelectedIndex = -1
                    ddldedutible.SelectedIndex = -1
                    'If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                    '    If objCoverage.LibilityLimit_Csl <> "" Then
                    '        ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True
                    '    End If
                    'End If
                    If Not (objCoverage.LiabilityLimit_Split Is Nothing) Then
                        If objCoverage.LiabilityLimit_Split <> "" Then
                            ddllimitsliasplit.Items.FindByText(objCoverage.LiabilityLimit_Split).Selected = True
                            If ddllimitsliasplit.SelectedIndex > 0 Then
                                ddlLimitsliabilitycsl.SelectedIndex = 0
                                ddlLimitsliabilitycsl.Enabled = False
                            End If
                        End If
                    End If
                    'If Not (objCoverage.UnInsuredMotorist_Csl Is Nothing) Then
                    '    If objCoverage.UnInsuredMotorist_Csl <> "" Then
                    '        ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                    '    End If
                    'End If
                    If Not (objCoverage.UnInsuredMotorist_Split Is Nothing) Then
                        If objCoverage.UnInsuredMotorist_Split <> "" Then
                            ddluninsuredMotoristsplit.Items.FindByText(objCoverage.UnInsuredMotorist_Split).Selected = True
                            If ddluninsuredMotoristsplit.SelectedIndex > 0 Then

                                ddluninsuredMotoristcsl.SelectedIndex = 0

                                ddluninsuredMotoristcsl.Enabled = False
                            End If
                        End If
                    End If
                    If Not (objCoverage.MedPayLimit Is Nothing) Then
                        If objCoverage.MedPayLimit <> "" Then
                            ddlmedicalpayments.Items.FindByText(objCoverage.MedPayLimit).Selected = True
                        End If
                    End If

                    If Not (objCoverage.Deductible Is Nothing) Then
                        If objCoverage.Deductible <> "" Then
                            ddldedutible.Items.FindByText(objCoverage.Deductible).Selected = True
                        End If
                    End If


                    'ddllimitsliasplit.Items.FindByText(objCoverage.LiabilityLimit_Split).Selected = True
                    'ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                    'ddluninsuredMotoristsplit.Items.FindByText(objCoverage.UnInsuredMotorist_Split).Selected = True
                    'ddlmedicalpayments.Items.FindByText(objCoverage.MedPayLimit).Selected = True
                    'ddldedutible.Items.FindByText(objCoverage.Deductible).Selected = True
                    If objCoverage.IsHired = 1 Then
                        rdohiredCnAnsYes.Checked = True
                        rdohiredCnAnsNo.Checked = False
                        txtmultcostofhire.Text = objCoverage.HiredDetails
                        txtmultcostofhire.Enabled = True
                    Else
                        rdohiredCnAnsYes.Checked = False
                        rdohiredCnAnsNo.Checked = True
                        txtmultcostofhire.Text = ""
                        txtmultcostofhire.Enabled = False

                    End If
                    If objCoverage.IsNonOwned = 1 Then
                        rdononownedCnAnsYes.Checked = True
                        rdononownedCnAnsNo.Checked = False
                        txtmulttotnumemployees.Text = objCoverage.NonOwnedDetails
                        txtmulttotnumemployees.Enabled = True
                    Else
                        rdononownedCnAnsYes.Checked = False
                        rdononownedCnAnsNo.Checked = True
                        txtmulttotnumemployees.Text = ""
                        txtmulttotnumemployees.Enabled = False

                    End If

                    If objCoverage.IsReeferBreaking = 1 Then
                        rdoreeferbrdwnCnYes.Checked = True
                        rdoreeferbrdwnCnNo.Checked = False
                    Else
                        rdoreeferbrdwnCnYes.Checked = False
                        rdoreeferbrdwnCnNo.Checked = True
                    End If

                    txtmultlnreeferbrkdwn.Text = objCoverage.ReeferBreaking
                    If objCoverage.ISAddtnlInsured = 1 Then
                        rdoaddInsuredCnYes.Checked = True
                        rdoaddInsuredCnNo.Checked = False
                    Else
                        rdoaddInsuredCnYes.Checked = False
                        rdoaddInsuredCnNo.Checked = True
                    End If
                    txtmotortrukcargo.Text = objCoverage.TruckCargoDetails
                    txtmultaddinsured.Text = objCoverage.AddtnlInsuerdDetails
                    chkcargo.Checked = objCoverage.IsCargo
                    SetCargoItemsVisibility(objCoverage.IsCargo)
                    If Not (Session("State") Is Nothing) And Session("State").ToString.ToUpper = "FL" Then

                        txtpip.Text = objCoverage.PIP
                        numofdealertags.Text = objCoverage.NoOfDealerTags

                        txtcargoAI.Text = objCoverage.AdditionalInfo
                        ddluninsuredMotoristcsl.SelectedIndex = -1
                        If Not (objCoverage.UnInsuredMotorist_Csl Is Nothing) Then
                            If objCoverage.UnInsuredMotorist_Csl <> "" Then
                                ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                            End If
                        End If
                        If objCoverage.IsCargo Then
                            FillLimitLiabilityCSLCargo()
                            DeductibleCargo.SelectedIndex = -1
                            If Not (objCoverage.DeductibleCargo Is Nothing) Then
                                If objCoverage.DeductibleCargo <> "" Then
                                    DeductibleCargo.Items.FindByText(objCoverage.DeductibleCargo).Selected = True
                                End If
                            End If
                            If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                                If objCoverage.LibilityLimit_Csl <> "" Then
                                    ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True

                                    If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                                        ddllimitsliasplit.SelectedIndex = 0
                                        ddllimitsliasplit.Enabled = False
                                    End If
                                End If
                            End If
                        Else
                            FillLimitLiabilityCslOther()
                            If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                                If objCoverage.LibilityLimit_Csl <> "" Then
                                    ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True

                                    If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                                        ddllimitsliasplit.SelectedIndex = 0
                                        ddllimitsliasplit.Enabled = False
                                    End If
                                End If
                            End If
                        End If

                    Else

                        'DeductibleCargo.SelectedIndex = -1
                        If objCoverage.IsCargo Then
                            FillLimitLiabilityCSLCargo()
                            DeductibleCargo.SelectedIndex = -1
                            If Not (objCoverage.DeductibleCargo Is Nothing) Then
                                If objCoverage.DeductibleCargo <> "" Then
                                    DeductibleCargo.Items.FindByText(objCoverage.DeductibleCargo).Selected = True
                                End If
                            End If
                            If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                                If objCoverage.LibilityLimit_Csl <> "" Then
                                    ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True

                                    If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                                        ddllimitsliasplit.SelectedIndex = 0
                                        ddllimitsliasplit.Enabled = False
                                    End If
                                End If
                            End If
                        Else
                            FillLimitLiabilityCslOther()
                            If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                                If objCoverage.LibilityLimit_Csl <> "" Then
                                    ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True

                                    If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                                        ddllimitsliasplit.SelectedIndex = 0
                                        ddllimitsliasplit.Enabled = False
                                    End If
                                End If
                            End If
                        End If
                        If Not (objCoverage.UnInsuredMotorist_Csl Is Nothing) Then
                            If objCoverage.UnInsuredMotorist_Csl <> "" Then
                                ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                                If ddluninsuredMotoristcsl.SelectedIndex > 0 Then

                                    ddluninsuredMotoristsplit.SelectedIndex = 0

                                    ddluninsuredMotoristsplit.Enabled = False
                                End If
                            End If
                        End If
                        'If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                        '    If objCoverage.LibilityLimit_Csl <> "" Then
                        '        ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True

                        '        If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                        '            ddllimitsliasplit.SelectedIndex = 0
                        '            ddllimitsliasplit.Enabled = False
                        '        End If
                        '    End If
                        'End If


                    End If


                    'If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                    '    ddllimitsliasplit.SelectedIndex = 0
                    '    ddllimitsliasplit.Enabled = False

                    '    'ddlLimitsliabilitycsl.Focus()
                    'ElseIf ddlLimitsliabilitycsl.SelectedIndex = 0 Then
                    '    ddllimitsliasplit.Enabled = True
                    '    ddllimitsliasplit.SelectedIndex = 0

                    'End If





                    'If ddluninsuredMotoristcsl.SelectedIndex > 0 Then

                    '    ddluninsuredMotoristsplit.SelectedIndex = 0

                    '    ddluninsuredMotoristsplit.Enabled = False
                    '    'ddluninsuredMotoristcsl.Focus()
                    'ElseIf ddluninsuredMotoristcsl.SelectedIndex = 0 Then

                    '    ddluninsuredMotoristsplit.Enabled = True

                    '    ddluninsuredMotoristsplit.SelectedIndex = 0
                    'End If







                    'If ddllimitsliasplit.SelectedIndex > 0 Then
                    '    ddlLimitsliabilitycsl.SelectedIndex = 0
                    '    ddlLimitsliabilitycsl.Enabled = False
                    'ElseIf ddllimitsliasplit.SelectedIndex = 0 Then
                    '    ddlLimitsliabilitycsl.Enabled = True
                    '    ddlLimitsliabilitycsl.SelectedIndex = 0
                    'End If






                    'If ddluninsuredMotoristsplit.SelectedIndex > 0 Then

                    '    ddluninsuredMotoristcsl.SelectedIndex = 0

                    '    ddluninsuredMotoristcsl.Enabled = False
                    '    'ddluninsuredMotoristsplit.Focus()
                    'ElseIf ddluninsuredMotoristsplit.SelectedIndex = 0 Then

                    '    ddluninsuredMotoristcsl.Enabled = True

                    '    ddluninsuredMotoristcsl.SelectedIndex = 0
                    'End If


                    'If Not (Session("State") Is Nothing) And Session("State").ToString.ToUpper = "FL" Then
                    '    numdealer.Visible = True
                    '    trpip.Visible = True
                    '    Uninsured.Visible = True
                    '    FillUnInsuredMotoristFL()
                    '    txtpip.Text = objCoverage.PIP
                    '    numofdealertags.Text = objCoverage.NoOfDealerTags

                    '    txtcargoAI.Text = objCoverage.AdditionalInfo
                    '    ddluninsuredMotoristcsl.SelectedIndex = -1
                    '    If Not (objCoverage.UnInsuredMotorist_Csl Is Nothing) Then
                    '        If objCoverage.UnInsuredMotorist_Csl <> "" Then
                    '            ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                    '        End If
                    '    End If
                    '    If chkcargo.Checked = False Then
                    '        numofdealertags.Height = 40
                    '        numofdealertags.Width = 150
                    '        deductible.Visible = True
                    '        DeductibleCargo.Items.Clear()
                    '        FillLimitLiabilityCslOther()

                    '    Else
                    '        numofdealertags.Height = 60
                    '        numofdealertags.Width = 300
                    '        FillDeductibleCargo()
                    '        FillLimitLiabilityCSLCargo()


                    '    End If
                    '    DeductibleCargo.SelectedIndex = -1
                    '    If Not (objCoverage.DeductibleCargo Is Nothing) Then
                    '        If objCoverage.DeductibleCargo <> "" Then
                    '            DeductibleCargo.Items.FindByText(objCoverage.DeductibleCargo).Selected = True
                    '        End If
                    '    End If

                    'Else
                    '    numdealer.Visible = False
                    '    trpip.Visible = False
                    '    FillUnInsuredMotoristOther()
                    '    DeductibleCargo.SelectedIndex = -1
                    '    If Not (objCoverage.UnInsuredMotorist_Csl Is Nothing) Then
                    '        If objCoverage.UnInsuredMotorist_Csl <> "" Then
                    '            ddluninsuredMotoristcsl.Items.FindByText(objCoverage.UnInsuredMotorist_Csl).Selected = True
                    '        End If
                    '    End If
                    'End If
                    'If Not (objCoverage.LibilityLimit_Csl Is Nothing) Then
                    '    If objCoverage.LibilityLimit_Csl <> "" Then
                    '        ddlLimitsliabilitycsl.Items.FindByText(objCoverage.LibilityLimit_Csl).Selected = True
                    '    End If
                    'End If

                End If
            Catch ex As Exception
                logger.Error("Exception occurred while Setting values in Coverage Details for Quote ID :" & strQuoteId, ex)
                logger.Error("Exception Details :" & ex.StackTrace)
                Throw ex
            End Try
            logger.Debug("Exiting CommAutoCoverageControl.FillControls")

        End Function

        Protected Sub ddlLimitsliabilitycsl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLimitsliabilitycsl.SelectedIndexChanged

            If ddlLimitsliabilitycsl.SelectedIndex > 0 Then
                ddllimitsliasplit.SelectedIndex = 0
                ddllimitsliasplit.Enabled = False

                ' ddlLimitsliabilitycsl.Focus()
            ElseIf ddlLimitsliabilitycsl.SelectedIndex = 0 Then
                ddllimitsliasplit.Enabled = True
                ddllimitsliasplit.SelectedIndex = 0
                ddlLimitsliabilitycsl.Focus()
            End If
            ddlLimitsliabilitycsl.Focus()


        End Sub

        Protected Sub ddluninsuredMotoristcsl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddluninsuredMotoristcsl.SelectedIndexChanged
            If ddluninsuredMotoristcsl.SelectedIndex > 0 Then

                ddluninsuredMotoristsplit.SelectedIndex = 0

                ddluninsuredMotoristsplit.Enabled = False
                'ddluninsuredMotoristcsl.Focus()
            ElseIf ddluninsuredMotoristcsl.SelectedIndex = 0 Then

                ddluninsuredMotoristsplit.Enabled = True

                ddluninsuredMotoristsplit.SelectedIndex = 0
                'ddluninsuredMotoristsplit.Focus()
            End If
            ddluninsuredMotoristcsl.Focus()

        End Sub



        Protected Sub ddllimitsliasplit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If ddllimitsliasplit.SelectedIndex > 0 Then
                ddlLimitsliabilitycsl.SelectedIndex = 0
                ddlLimitsliabilitycsl.Enabled = False
                'ddllimitsliasplit.Focus()
            ElseIf ddllimitsliasplit.SelectedIndex = 0 Then
                ddlLimitsliabilitycsl.Enabled = True
                ddlLimitsliabilitycsl.SelectedIndex = 0
                ' ddllimitsliasplit.Focus()
            End If
            ddllimitsliasplit.Focus()

        End Sub


        Protected Sub ddluninsuredMotoristsplit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If ddluninsuredMotoristsplit.SelectedIndex > 0 Then

                ddluninsuredMotoristcsl.SelectedIndex = 0

                ddluninsuredMotoristcsl.Enabled = False
                'ddluninsuredMotoristsplit.Focus()
            ElseIf ddluninsuredMotoristsplit.SelectedIndex = 0 Then

                ddluninsuredMotoristcsl.Enabled = True

                ddluninsuredMotoristcsl.SelectedIndex = 0
                'ddluninsuredMotoristsplit.Focus()
            End If
            ddluninsuredMotoristsplit.Focus()
        End Sub

        Protected Sub chkcargo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcargo.CheckedChanged

            SetCargoItemsVisibility(chkcargo.Checked)


        End Sub
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState
            If State = "FL" Then
                numdealer.Visible = True
                trpip.Visible = True
                Uninsured.Visible = True
                FillUnInsuredMotoristFL()
                If chkcargo.Checked = False Then
                    'numofdealertags.Height = 40
                    'numofdealertags.Width = 150


                Else
                    'numofdealertags.Height = 60
                    'numofdealertags.Width = 300

                End If


            Else
                numdealer.Visible = False
                trpip.Visible = False
                FillUnInsuredMotoristOther()
            End If
            Session("State") = State
        End Sub

        Private Sub FillUnInsuredMotoristFL()
            ddluninsuredMotoristcsl.Items.Clear()
            ddluninsuredMotoristcsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
            ddluninsuredMotoristcsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("10,000", "1"))
            ddluninsuredMotoristcsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("20,000", "2"))
            ddluninsuredMotoristcsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("75,000", "3"))
            ddluninsuredMotoristcsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("100,000", "4"))
            ddluninsuredMotoristcsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("300,000", "5"))
            ddluninsuredMotoristcsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("350,000", "6"))
            ddluninsuredMotoristcsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("500,000", "7"))
            ddluninsuredMotoristcsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("750,000", "8"))
            ddluninsuredMotoristcsl.Items.Insert(9, New System.Web.UI.WebControls.ListItem("1,000,000", "9"))
        End Sub

        Private Sub FillUnInsuredMotoristOther()
            ddluninsuredMotoristcsl.Items.Clear()
            ddluninsuredMotoristcsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
            ddluninsuredMotoristcsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("20,000", "1"))
            ddluninsuredMotoristcsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("75,000", "2"))
            ddluninsuredMotoristcsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("100,000", "3"))
            ddluninsuredMotoristcsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("300,000", "4"))
            ddluninsuredMotoristcsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("350,000", "5"))
            ddluninsuredMotoristcsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("500,000", "6"))
            ddluninsuredMotoristcsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("750,000", "7"))
            ddluninsuredMotoristcsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("1,000,000", "8"))
        End Sub

        Private Sub FillLimitLiabilityCSLCargo()
            ddlLimitsliabilitycsl.Items.Clear()
            ddlLimitsliabilitycsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
            ddlLimitsliabilitycsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("5,000", "1"))
            ddlLimitsliabilitycsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("10,000", "2"))
            ddlLimitsliabilitycsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("25,000", "3"))
            ddlLimitsliabilitycsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("30,000", "4"))
            ddlLimitsliabilitycsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("40,000", "5"))
            ddlLimitsliabilitycsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("50,000", "6"))
            ddlLimitsliabilitycsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("100,000", "7"))
            ddlLimitsliabilitycsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("150,000", "8"))
            ddlLimitsliabilitycsl.Items.Insert(9, New System.Web.UI.WebControls.ListItem("200,000", "9"))
            ddlLimitsliabilitycsl.Items.Insert(10, New System.Web.UI.WebControls.ListItem("250,000", "10"))
            ddlLimitsliabilitycsl.Items.Insert(11, New System.Web.UI.WebControls.ListItem("300,000", "11"))

        End Sub

        Private Sub FillLimitLiabilityCslOther()
            ddlLimitsliabilitycsl.Items.Clear()
            ddlLimitsliabilitycsl.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
            ddlLimitsliabilitycsl.Items.Insert(1, New System.Web.UI.WebControls.ListItem("30,000", "1"))
            ddlLimitsliabilitycsl.Items.Insert(2, New System.Web.UI.WebControls.ListItem("50,000", "2"))
            ddlLimitsliabilitycsl.Items.Insert(3, New System.Web.UI.WebControls.ListItem("75,000", "3"))
            ddlLimitsliabilitycsl.Items.Insert(4, New System.Web.UI.WebControls.ListItem("100,000", "4"))
            ddlLimitsliabilitycsl.Items.Insert(5, New System.Web.UI.WebControls.ListItem("300,000", "5"))
            ddlLimitsliabilitycsl.Items.Insert(6, New System.Web.UI.WebControls.ListItem("350,000", "6"))
            ddlLimitsliabilitycsl.Items.Insert(7, New System.Web.UI.WebControls.ListItem("500,000", "7"))
            ddlLimitsliabilitycsl.Items.Insert(8, New System.Web.UI.WebControls.ListItem("750,000", "8"))
            ddlLimitsliabilitycsl.Items.Insert(9, New System.Web.UI.WebControls.ListItem("1,000,000", "9"))

        End Sub

        Private Sub FillDeductibleCargo()
            DeductibleCargo.Items.Clear()
            DeductibleCargo.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
            DeductibleCargo.Items.Insert(1, New System.Web.UI.WebControls.ListItem("500", "1"))
            DeductibleCargo.Items.Insert(2, New System.Web.UI.WebControls.ListItem("1,000", "2"))
            DeductibleCargo.Items.Insert(3, New System.Web.UI.WebControls.ListItem("2,500", "3"))
            DeductibleCargo.Items.Insert(4, New System.Web.UI.WebControls.ListItem("5,000", "4"))
        End Sub

        Private Sub SetCargoItemsVisibility(ByVal IsCargo As Boolean)
            If IsCargo Then
                csl.Visible = False
                ddllimitsliasplit.Visible = False
                ddluninsuredMotoristsplit.Visible = False
                trmedical.Visible = False
                yes.Visible = False
                hired.Visible = False
                Non.Visible = False
                motortruck.Visible = False
                reefer.Visible = False
                secyes.Visible = False
                addinfo.Visible = False
                trdeductiblecargo.Visible = True
                deductible.Visible = False
                cargoaddinfo.Visible = False 'True
                FillDeductibleCargo()
                FillLimitLiabilityCSLCargo()
                If Session("State") = "FL" Then
                    Uninsured.Visible = False ' True
                    numdealer.Visible = False ' True
                    trpip.Visible = False 'True
                    'numofdealertags.Height = 60
                    'numofdealertags.Width = 300
                    'FillUnInsuredMotoristFL()
                Else
                    Uninsured.Visible = False
                    numdealer.Visible = False
                    trpip.Visible = False
                    'FillUnInsuredMotoristOther()
                End If

            Else
                csl.Visible = True
                ddllimitsliasplit.Visible = True
                ddluninsuredMotoristsplit.Visible = True
                trmedical.Visible = True
                yes.Visible = True
                hired.Visible = True
                Non.Visible = True
                motortruck.Visible = True
                reefer.Visible = True
                secyes.Visible = True
                addinfo.Visible = True
                cargoaddinfo.Visible = False
                trdeductiblecargo.Visible = False
                deductible.Visible = True
                FillLimitLiabilityCslOther()
                numdealer.Visible = False
                trpip.Visible = False
                Uninsured.Visible = True
                If Session("State") = "FL" Then
                    Uninsured.Visible = True
                    numdealer.Visible = True
                    trpip.Visible = True
                    'numofdealertags.Height = 40
                    'numofdealertags.Width = 150
                    FillUnInsuredMotoristFL()

                Else
                    'numofdealertags.Height = 60
                    'numofdealertags.Width = 300
                    numdealer.Visible = False
                    trpip.Visible = False
                    FillUnInsuredMotoristOther()
                End If


            End If
        End Sub


    End Class
End Namespace
