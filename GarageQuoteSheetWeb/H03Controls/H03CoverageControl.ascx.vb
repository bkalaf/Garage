Imports GarageQuoteSheetDLL.H03
Imports GarageQuoteSheetDLL
Imports log4net
Namespace UserControlH03
    Partial Class H03CoverageControl
        Inherits System.Web.UI.UserControl
        ' Implements ISubscriber
        Implements H03ISubscriber
        Dim vaidatemsg As String
        Dim coverageE As String
        Dim coverageF As String
        Dim winddeductible As String

        Dim strName As String = "CoverageDescriptiondetails"
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
#Region "Properties"
        ' ''ReadOnly Property Name() As String Implements ISubscriber.Name
        ' ''    Get
        ' ''        Return strName
        ' ''    End Get
        ' ''End Property
        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"
        Private genHomeCoverageColl As GenericCollection(Of IEntity)
        Private objH03Coverage As H03Coverage



#End Region


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            logger.Debug("Entering H03CoverageControl.Page_Load")

            If Not IsPostBack Then
                Try
                    ddlperils.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlCoverageEliability.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlwinddeductible.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlwinddeductible.Enabled = False
                Catch ex As Exception



                End Try
            Else
                'If rdoWindandHailExAnsYes.Checked Then
                '    ddlwinddeductible.Enabled = True
                'Else
                '    ddlwinddeductible.Enabled = False
                'End If
            End If
            logger.Debug("Entering H03CoverageControl.Page_Load")
        End Sub
        
        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            'Validation Part Here
            logger.Debug("Entering H03CoverageControl.Validate")
            Try

                If ddlCoverageEliability.SelectedIndex = 0 Then

                    vaidatemsg = "Select Coverage E-liability (Coverage Details)"
                    ddlCoverageEliability.Focus()
                    Return (vaidatemsg)

                End If

                If ddlperils.SelectedIndex = 0 Then

                    vaidatemsg = "Select Deductible for all perils (Coverage Details)"
                    ddlperils.Focus()
                    Return (vaidatemsg)

                End If

                If rdoWindandHailExAnsNo.Checked = False And rdoWindandHailExAnsYes.Checked = False Then

                    vaidatemsg = "Select one option in Wind and Hail Exclusion(Coverage Details)"
                    rdoWindandHailExAnsNo.Focus()
                    Return (vaidatemsg)

                End If
                If rdoWindandHailExAnsYes.Checked Then

                    If ddlwinddeductible.SelectedIndex = 0 Then

                        vaidatemsg = "If No,Please Select deductible(Coverage Details)"
                        ddlwinddeductible.Enabled = True
                        ddlwinddeductible.Focus()
                        Return (vaidatemsg)

                    End If

                End If


                If rdosinkholeexlusionYes.Checked = False And rdosinkholeexlusionNo.Checked = False Then

                    vaidatemsg = "Select one option in sink hole exclusion(Coverage Details)"
                    rdosinkholeexlusionYes.Focus()
                    Return (vaidatemsg)

                End If
                If rdoOrdinanceLimitsyes.Checked = False And rdoOrdinanceLimitsNo.Checked = False Then

                    vaidatemsg = "Select one option in Ordinance or law limits coverage A(Coverage Details)"
                    rdoOrdinanceLimitsyes.Focus()
                    Return (vaidatemsg)

                End If
                If rdoWindandHailExAnsYes.Checked Then
                    ddlwinddeductible.Enabled = True
                Else
                    ddlwinddeductible.Enabled = False
                End If


            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try


            Return (vaidatemsg)

            logger.Debug("Exiting H03CoverageControl.Validate")


        End Function
        ''Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
        ''    logger.Debug("Entering H03CoverageControl.GetInputData")

        ''    logger.Debug("Exiting H03CoverageControl.GetInputData")
        ''End Function
        ' ''Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        ' ''End Sub
        ''Private Function FillControls(ByVal pstrQuoteId As String) As Boolean Implements ISubscriber.FillControls
        ''    Return True
        ''End Function
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            ''<NumericFact id="dwelling">150000</NumericFact>
            ''<NumericFact id="persProp">100000</NumericFact>
            ''<NumericFact id="liability">500000</NumericFact>
            ''<NumericFact id="deductible"> 1000</NumericFact>
            ''<LiteralFact id="windHailExclusion">No</LiteralFact>
            ''<NumericFact id="windDeductible">0.05</NumericFact>
            ''<LiteralFact id="sinkholeExcluded">No</LiteralFact>
            ''<LiteralFact id="alarmCredit">Monitored Central Station</LiteralFact>
            ''<LiteralFact id="lawLimitCoverageA">Yes</LiteralFact>
            Dim _strInputData As String
            Dim _strwindHailExclusion As String = "No"
            If (rdoWindandHailExAnsNo.Checked) Then
                _strwindHailExclusion = "Yes"
            End If
            Dim _strSinkHole As String = "No"
            If (rdosinkholeexlusionYes.Checked) Then
                _strSinkHole = "Yes"
            End If
            Dim _strLawLimitCoverageA As String = "No"
            If (rdoOrdinanceLimitsyes.Checked) Then
                _strLawLimitCoverageA = "Yes"
            End If
            'Dim _strAlarmCredit As String = "Monitored Central Station"
            _strInputData = "<NumericFact id='dwelling'>" + txtcoverageA.Text.Trim() + "</NumericFact>"
            _strInputData += "<NumericFact id='persProp'>" + txtCoverageC.Text.Trim() + "</NumericFact>"
            _strInputData += "<NumericFact id='medPay'>" + txtcoverageFmed.Text.Trim() + "</NumericFact>"
            _strInputData += "<NumericFact id='liability'>" + ddlCoverageEliability.Items(ddlCoverageEliability.SelectedIndex).Text.Trim().Replace("$", "").Replace(",", "") + "</NumericFact>"
            _strInputData += "<NumericFact id='deductible'>" + ddlperils.Items(ddlperils.SelectedIndex).Text.Trim() + "</NumericFact>"
            _strInputData += "<LiteralFact id='windHailExclusion'>" + _strwindHailExclusion + "</LiteralFact>"
            If rdoWindandHailExAnsNo.Checked = False Then
                _strInputData += "<NumericFact id='windDeductible'>" + (Val(ddlwinddeductible.Items(ddlwinddeductible.SelectedIndex).Text.Trim().Replace("%", "")) / 100).ToString() + "</NumericFact>"
            Else
                _strInputData += "<NumericFact id='windDeductible'>0</NumericFact>"
            End If
            _strInputData += "<LiteralFact id='sinkholeExcluded'>" + _strSinkHole + "</LiteralFact>"

            _strInputData += "<LiteralFact id='lawLimitCoverageA'>" + _strLawLimitCoverageA + "</LiteralFact>"

            Return _strInputData
        End Function
        ''' <summary>
        ''' Implements GetH03InputData Method
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            logger.Debug("Entering H03CoverageControl.GetH03InputData")
            Try
                genHomeCoverageColl = New GenericCollection(Of IEntity)
                objH03Coverage = New H03Coverage()
                objH03Coverage.H03CoverageId = 0
                objH03Coverage.CoverageA = txtcoverageA.Text.Trim
                objH03Coverage.CoverageB = txtCoverageB.Text.Trim
                objH03Coverage.CoverageC = txtCoverageC.Text.Trim
                objH03Coverage.CoverageD = txtCoverageD.Text.Trim
                coverageE = ddlCoverageEliability.SelectedItem.Text
                coverageE = coverageE.Replace("$", "")

                objH03Coverage.CoverageE = Decimal.Parse(coverageE)
                coverageF = txtcoverageFmed.Text.Trim
                coverageF = coverageF.Replace("$", "")
                objH03Coverage.CoverageF = Decimal.Parse(coverageF)
                objH03Coverage.Deductible = ddlperils.SelectedItem.Text

                If rdoWindandHailExAnsYes.Checked Then
                    objH03Coverage.WindHailEx = 1
                    winddeductible = ddlwinddeductible.SelectedItem.Text
                    winddeductible = winddeductible.Replace("%", "")
                    objH03Coverage.WindDeductible = Decimal.Parse(winddeductible)

                Else
                    objH03Coverage.WindHailEx = 0
                    ddlwinddeductible.Enabled = False

                End If

                If rdosinkholeexlusionYes.Checked Then
                    objH03Coverage.HasSinkHole = 1

                Else
                    objH03Coverage.HasSinkHole = 0
                End If
                If rdoOrdinanceLimitsyes.Checked Then
                    objH03Coverage.Ordinance = 1
                Else
                    objH03Coverage.Ordinance = 0

                End If
                genHomeCoverageColl.Add(objH03Coverage)


            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally

            End Try
            Return genHomeCoverageColl
            logger.Debug("Exiting H03CoverageControl.GetH03InputData")
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
            txtCoverageB.Text = CoverageB
            txtCoverageD.Text = CoverageD
        End Sub
    End Class
End Namespace

