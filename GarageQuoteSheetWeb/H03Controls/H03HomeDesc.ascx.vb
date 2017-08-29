Imports GarageQuoteSheetDLL
Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports System.Data
Namespace UserControlH03
    Partial Class H03HomeDesc
        Inherits System.Web.UI.UserControl
        ''Implements ISubscriber
        Implements H03ISubscriber
        Dim vaidatemsg As String
        Dim strName As String = "HomeDescriptiondetails"
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
#Region "Properties"
        '' ''ReadOnly Property Name() As String Implements ISubscriber.Name
        '' ''    Get
        '' ''        Return strName
        '' ''    End Get
        '' ''End Property

        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property

#End Region
#Region "DataMembers"
        Private genhomedescColl As GenericCollection(Of IEntity)
        Private objHome As HomeDetails

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            logger.Debug("Entering H03HomeDesc.Page_Load")
            If Not IsPostBack Then
                Try
                    BindLookupData()
                    ddlprotection.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddloccupany.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlconstructiontype.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlyearbuilt.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlprotectivedevices.Items.Insert(0, New System.Web.UI.WebControls.ListItem("select One", "0"))
                    ddlfamilies.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlpool.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlroofage.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlstories.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlprotectivedeviceswind.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            Else
                If rdoh03petsAnsYes.Checked Then
                    txtpets.Enabled = True
                Else
                    txtpets.Enabled = False
                End If

            End If
            logger.Debug("Exiting H03HomeDesc.Page_Load")

        End Sub
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            ''<LiteralFact id="county">CALHOUN</LiteralFact>
            ''<LiteralFact id="construction">Frame</LiteralFact>
            ''<LiteralFact id="yearBuilt">1977</LiteralFact>
            ''<NumericFact id="protectionClass">7</NumericFact>
            ''<LiteralFact id="pool">No</LiteralFact>
            ''<LiteralFact id="trampoline">Yes</LiteralFact>
            ''<LiteralFact id="pets">No</LiteralFact>
            ''<NumericFact id="miToTidalWater">7</NumericFact>
            ''<LiteralFact id="roofAge">7</LiteralFact>
            ''<LiteralFact id="windProtectiveDevices">Impact Resistant Glass</LiteralFact>
            Dim _strInputData As String
            Dim _strTrampoline As String = "No"
            If (rdoH03trampolineYes.Checked) Then
                _strTrampoline = "Yes"
            End If
            Dim _strPets As String = "No"
            If (rdoh03petsAnsNo.Checked = False) Then
                _strPets = "Yes"
            End If
            _strInputData = "<LiteralFact id='occupancy'>" + ddloccupany.Items(ddloccupany.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<LiteralFact id='construction'>" + ddlconstructiontype.Items(ddlconstructiontype.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<LiteralFact id='yearBuilt'>" + ddlyearbuilt.Items(ddlyearbuilt.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<NumericFact id='protectionClass'>" + ddlprotection.Items(ddlprotection.SelectedIndex).Text + "</NumericFact>"
            _strInputData += "<LiteralFact id='pool'>" + ddlpool.Items(ddlpool.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<LiteralFact id='trampoline'>" + _strTrampoline + "</LiteralFact>"
            _strInputData += "<LiteralFact id='pets'>" + _strPets + "</LiteralFact>"
            _strInputData += "<NumericFact id='miToTidalWater'>" + txtmiles.Text + "</NumericFact>"
            _strInputData += "<NumericFact id='miToFireStation'>" + txtmilestofirestation.Text + "</NumericFact>"
            _strInputData += "<LiteralFact id='roofAge'>" + (DateTime.Now.Year - Val(ddlroofage.Items(ddlroofage.SelectedIndex).Text)).ToString() + "</LiteralFact>"
            _strInputData += "<LiteralFact id='windProtectiveDevices'>" + ddlprotectivedeviceswind.Items(ddlprotectivedeviceswind.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<LiteralFact id='alarmCredit'>" + ddlprotectivedevices.Items(ddlprotectivedevices.SelectedIndex).Text + "</LiteralFact>"
            Return _strInputData
        End Function
        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            'Validation Part Here
            logger.Debug("Entering H03HomeDesc.Validate")
            Try
                If ddloccupany.SelectedIndex = 0 Then

                    vaidatemsg = "Select occupancy (Home description)"
                    ddloccupany.Focus()
                    Return (vaidatemsg)

                End If
                If ddloccupany.SelectedItem.Text = "Tenant Occupied" Then

                    vaidatemsg = "Refer to Underwriter (Home description)"
                    ddloccupany.Focus()
                    Return (vaidatemsg)

                End If
                If ddlconstructiontype.SelectedIndex = 0 Then

                    vaidatemsg = "Select construction type (Home description)"
                    ddlconstructiontype.Focus()
                    Return (vaidatemsg)

                End If
                If ddlyearbuilt.SelectedIndex = 0 Then

                    vaidatemsg = "Select year built (Home description)"
                    ddlyearbuilt.Focus()
                    Return (vaidatemsg)

                End If
                If ddlprotection.SelectedIndex = 0 Then

                    vaidatemsg = "Select protection class (Home description)"
                    ddlprotection.Focus()
                    Return (vaidatemsg)

                End If
                If ddlprotectivedevices.SelectedIndex = 0 Then

                    vaidatemsg = "Select protective devices (Home description)"
                    ddlprotectivedevices.Focus()
                    Return (vaidatemsg)

                End If
                If ddlfamilies.SelectedIndex = 0 Then

                    vaidatemsg = "Select families (Home description)"
                    ddlfamilies.Focus()
                    Return (vaidatemsg)

                End If
                If ddlpool.SelectedIndex = 0 Then

                    vaidatemsg = "Select pool (Home description)"
                    ddlpool.Focus()
                    Return (vaidatemsg)

                End If
                If rdoH03trampolineYes.Checked = False And rdoH03trampolineNo.Checked = False Then

                    vaidatemsg = "Select one option in trampoline(Home description)"
                    rdoH03trampolineYes.Focus()
                    Return (vaidatemsg)


                End If
                If rdoh03petsAnsYes.Checked = False And rdoh03petsAnsNo.Checked = False Then

                    vaidatemsg = "Select one option in pets(Home description)"
                    rdoh03petsAnsYes.Focus()
                    Return (vaidatemsg)

                End If
                If rdoh03petsAnsYes.Checked Then

                    If txtpets.Text = "" Then

                        vaidatemsg = "If Yes,Provide pet's breed(Home decription)"
                        txtpets.Enabled = True
                        Return (vaidatemsg)
                    Else

                        txtpets.Enabled = False

                    End If

                End If

                If ddlroofage.SelectedIndex = 0 Then

                    vaidatemsg = "Select roof age (Home description)"
                    ddlroofage.Focus()
                    Return (vaidatemsg)

                End If
                If ddlstories.SelectedIndex = 0 Then

                    vaidatemsg = "Select stories (Home description)"
                    ddlstories.Focus()
                    Return (vaidatemsg)

                End If
                If ddlprotectivedeviceswind.SelectedIndex = 0 Then

                    vaidatemsg = "Select wind protective devices (Home description)"
                    ddlprotectivedeviceswind.Focus()
                    Return (vaidatemsg)

                End If
                If rdoh03petsAnsYes.Checked Then
                    txtpets.Enabled = True
                Else
                    txtpets.Enabled = False
                End If



            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try


            Return (vaidatemsg)

            logger.Debug("Exiting H03HomeDesc.Validate")


        End Function
        ' ''Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
        ' ''    logger.Debug("Entering H03HomeDesc.GetInputData")

        ' ''    logger.Debug("Exiting H03HomeDesc.GetInputData")
        ' ''End Function
        ' ''Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        ' ''End Sub
        ' ''Private Function FillControls(ByVal pstrQuoteId As String) As Boolean Implements ISubscriber.FillControls
        ' ''    Return True
        ' ''End Function
        ''' <summary>
        ''' Bind All lookup Data
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub BindLookupData()
            Dim objService As New SIUService.ServiceSoapClient()
            Dim DsLookupData As New DataSet()
            DsLookupData = objService.GetConstructionType("GA")
            ddlconstructiontype.Items.Clear()
            If DsLookupData.Tables(0).Rows.Count > 0 Then
                ddlconstructiontype.DataTextField = "ConstructionType"
                ddlconstructiontype.DataValueField = "ConstructionTypeCode"
                ddlconstructiontype.DataSource = DsLookupData.Tables(0)
                ddlconstructiontype.DataBind()
            End If

            'DsLookupData = Nothing
            'DsLookupData = objService.GetBuiltYearCreditSurcharge()
            'ddlyearbuilt.Items.Clear()
            'If DsLookupData.Tables(0).Rows.Count > 0 Then
            '    ddlyearbuilt.DataTextField = "YearBuilt"
            '    ddlyearbuilt.DataValueField = "CreditSurcharge"
            '    ddlyearbuilt.DataSource = DsLookupData.Tables(0)
            '    ddlyearbuilt.DataBind()
            'End If
            ddlyearbuilt.Items.Clear()
            For i As Integer = 1976 To DateTime.Now.Year
                ddlyearbuilt.Items.Add(i.ToString())
            Next

            For i As Integer = 1 To 10
                ddlprotection.Items.Add(i.ToString())
            Next

            'DsLookupData = Nothing
            'DsLookupData = objService.GetProtectionClass()
            'ddlprotection.Items.Clear()
            'If DsLookupData.Tables(0).Rows.Count > 0 Then
            '    ddlprotection.DataTextField = "ProtectionName"
            '    ddlprotection.DataValueField = "ProtectionCode"
            '    ddlprotection.DataSource = DsLookupData.Tables(0)
            '    ddlprotection.DataBind()
            'End If

            DsLookupData = Nothing
            DsLookupData = objService.GetProtectiveDevice("GA")
            ddlprotectivedevices.Items.Clear()
            If DsLookupData.Tables(0).Rows.Count > 0 Then
                ddlprotectivedevices.DataTextField = "ProtectiveDevice"
                ddlprotectivedevices.DataValueField = "ProtectiveDeviceCode"
                ddlprotectivedevices.DataSource = DsLookupData.Tables(0)
                ddlprotectivedevices.DataBind()
            End If

            'DsLookupData = Nothing
            'DsLookupData = objService.GetRoofAgeCreditSurcharge()
            'ddlroofage.Items.Clear()
            'If DsLookupData.Tables(0).Rows.Count > 0 Then
            '    ddlroofage.DataTextField = "RoofAge"
            '    ddlroofage.DataValueField = "CreditSurcharge"
            '    ddlroofage.DataSource = DsLookupData.Tables(0)
            '    ddlroofage.DataBind()
            'End If
            For i As Integer = DateTime.Now.Year To 1976 Step -1
                ddlroofage.Items.Add(i.ToString())
            Next



            DsLookupData = Nothing
            DsLookupData = objService.GetOccupancy("GA")
            ddloccupany.Items.Clear()
            If DsLookupData.Tables(0).Rows.Count > 0 Then
                ddloccupany.DataTextField = "Occupancy"
                ddloccupany.DataValueField = "OccupancyCode"
                ddloccupany.DataSource = DsLookupData.Tables(0)
                ddloccupany.DataBind()
            End If


            DsLookupData = Nothing
            DsLookupData = objService.GetPool("GA")
            ddlpool.Items.Clear()
            If DsLookupData.Tables(0).Rows.Count > 0 Then
                ddlpool.DataTextField = "Pool"
                ddlpool.DataValueField = "PoolId"
                ddlpool.DataSource = DsLookupData.Tables(0)
                ddlpool.DataBind()
            End If

        End Sub
        ''' <summary>
        ''' Implements GetH03InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            logger.Debug("Entering H03HomeDesc.GetH03InputData")
            Try

                genhomedescColl = New GenericCollection(Of IEntity)

                objHome = New HomeDetails()
                objHome.H03HomeId = 0
                objHome.Occupancy = ddloccupany.SelectedItem.Text.Trim
                objHome.ConstructionType = ddlconstructiontype.SelectedItem.Text
                objHome.ProtectiveClass = ddlprotection.SelectedItem.Text
                objHome.YearBuilt = ddlyearbuilt.SelectedItem.Text
                objHome.ProtectiveDevices = ddlprotectivedevices.SelectedItem.Text
                objHome.Families = ddlfamilies.SelectedItem.Text
                objHome.MilestoCoastal = txtmiles.Text
                objHome.Pool = ddlpool.SelectedItem.Text
                If rdoH03trampolineYes.Checked Then
                    objHome.Trampoline = 1
                Else
                    objHome.Trampoline = 0

                End If
                If rdoh03petsAnsYes.Checked Then
                    objHome.HasPets = 1
                    objHome.Pets = txtpets.Text
                    txtpets.Enabled = True
                Else
                    objHome.HasPets = 0
                    txtpets.Enabled = False

                End If
                objHome.RoofAge = ddlroofage.SelectedItem.Text
                objHome.SquareFootage = txtsqfootage.Text.Trim
                objHome.Stories = ddlstories.SelectedItem.Text
                objHome.FeetFrmHydrant = txtfirehydrant.Text
                objHome.MilesToFireStation = txtmilestofirestation.Text
                objHome.FireDistrict = txtfiredistrict.Text
                objHome.WindProtectiveDevices = ddlprotectivedeviceswind.SelectedItem.Text
                genhomedescColl.Add(objHome)

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally

            End Try

            Return genhomedescColl
            logger.Debug("Exiting H03HomeDesc.GetH03InputData")
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
        ''' Set CoverageB & CoverageD 
        ''' </summary>
        ''' <param name="CoverageB"></param>
        ''' <param name="CoverageD"></param>
        ''' <remarks></remarks>
        Sub SetCoverage(ByVal CoverageB As String, ByVal CoverageD As String) Implements H03ISubscriber.SetCoverage

        End Sub
    End Class
End Namespace
