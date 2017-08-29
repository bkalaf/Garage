Imports GarageQuoteSheetDLL
Imports log4net
Imports System.Data
Namespace UserControlH03

    Partial Class H03InsuranceHistorycontrol
        Inherits System.Web.UI.UserControl
        ''Implements ISubscriber
        Implements H03ISubscriber
        Dim vaidatemsg As String
        Dim numrows As Integer
        Dim numrowsnon As Integer
        Dim strName As String = "HistoryDescriptiondetails"
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

#Region "Properties"
        'ReadOnly Property Name() As String Implements ISubscriber.Name
        '    Get
        '        Return strName
        '    End Get
        'End Property
        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"
        Private geninsuranceColl As GenericCollection(Of IEntity)
        Private objCoverage As CoverageDetail
        Private objWindHail As H03.WindHailLossHistory
        Private objNonWindHail As H03.NonWindHailLosses

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then
                Try
                    ddlnumberoflosses.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "-1"))
                    ddlnonwindhaillosses.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "-1"))
                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try


            End If

        End Sub

        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            'Validation Part Here
            logger.Debug("Entering H03InsuranceHistorycontrol.Validate")
            Try

                If ddlnumberoflosses.SelectedValue = -1 Then


                    vaidatemsg = "Select number of wind/hail losses in the last 3 years(Insurance History)"
                    ddlnumberoflosses.Focus()
                    Return (vaidatemsg)

                End If


                If ddlnonwindhaillosses.SelectedValue = -1 Then


                    vaidatemsg = "Select number of non-wind/hail losses in the last 3 years(Insurance History)"
                    ddlnonwindhaillosses.Focus()
                    Return (vaidatemsg)

                End If



            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try


            Return (vaidatemsg)

            logger.Debug("Exiting H03InsuranceHistorycontrol.Validate")


        End Function
        ' ''Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
        ' ''    logger.Debug("Entering H03InsuranceHistorycontrol.GetInputData")
        ' ''    Try


        ' ''    Catch ex As Exception


        ' ''        logger.Error("Exception occurred while loadding Agency Information ", ex)
        ' ''        logger.Error("Exception Details : " & ex.StackTrace)
        ' ''    Finally

        ' ''        'objCoverage = Nothing

        ' ''    End Try






        ' ''    Return geninsuranceColl
        ' ''    logger.Debug("Exiting H03InsuranceHistorycontrol.GetInputData")
        ' ''End Function
        ''Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        ''End Sub

        Protected Sub ddlnumberoflosses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlnumberoflosses.SelectedIndexChanged
            If ddlnumberoflosses.SelectedIndex = 0 Or ddlnumberoflosses.SelectedValue = 0 Then
                dgwindhaillosses.Visible = False

            Else
                numrows = Int32.Parse(ddlnumberoflosses.SelectedValue.ToString)
                dgwindhaillosses.Visible = True
                dgwindhaillosses.DataSource = GetDataTable(numrows)
                dgwindhaillosses.DataBind()

            End If
            ddlnumberoflosses.Focus()


        End Sub
        Private Function GetDataTable(ByVal intRow As Integer) As DataTable
            Dim Dt As New DataTable
            Dt.Columns.Add("Description")
            Dt.Columns.Add("Amount")
            Dt.Columns.Add("Outcomeloss")
            Dim Dr As DataRow
            Dim Row As Integer
            For Row = 1 To intRow
                Dr = Dt.NewRow
                Dr("Description") = ""
                Dr("Amount") = ""
                Dr("Outcomeloss") = ""
                Dt.Rows.Add(Dr)
            Next
            Return Dt
        End Function
        Private Function GetDataTableNonWind(ByVal intRow As Integer) As DataTable
            Dim Dt As New DataTable
            Dt.Columns.Add("txtDescriptionnon")
            Dt.Columns.Add("txtAmountnon")
            Dt.Columns.Add("txtoutcomenon")
            Dim Dr As DataRow
            Dim Row As Integer
            For Row = 1 To intRow
                Dr = Dt.NewRow
                Dr("txtDescriptionnon") = ""
                Dr("txtAmountnon") = ""
                Dr("txtoutcomenon") = ""
                Dt.Rows.Add(Dr)
            Next
            Return Dt
        End Function


        Protected Sub ddlnonwindhaillosses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlnonwindhaillosses.SelectedIndexChanged
            If ddlnonwindhaillosses.SelectedIndex = 0 Or ddlnonwindhaillosses.SelectedValue = 0 Then

                dgnonwindhaillosses.Visible = False


            Else
                numrowsnon = Int32.Parse(ddlnonwindhaillosses.SelectedValue.ToString)
                dgnonwindhaillosses.Visible = True
                dgnonwindhaillosses.DataSource = GetDataTableNonWind(numrowsnon)
                dgnonwindhaillosses.DataBind()
            End If
            ddlnonwindhaillosses.Focus()


        End Sub

        'Private Function FillControls(ByVal pstrQuoteId As String) As Boolean Implements ISubscriber.FillControls
        '    Return True
        'End Function
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            ''<NumericFact id="windLossesLast3">0</NumericFact>
            ''<NumericFact id="nonWindLossesLast3">0</NumericFact
            Dim _strInputData As String
            _strInputData = "<NumericFact id='windLossesLast3'>" + ddlnumberoflosses.Items(ddlnumberoflosses.SelectedIndex).Text + "</NumericFact>"
            _strInputData += "<NumericFact id='nonwindLossesLast3'>" + ddlnonwindhaillosses.Items(ddlnonwindhaillosses.SelectedIndex).Text + "</NumericFact>"
            Return _strInputData
        End Function
        ''' <summary>
        ''' Implements GetH03InputData Method
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            logger.Debug("Entering H03InsuranceHistorycontrol.GetH03InputData")
            Try
                geninsuranceColl = New GenericCollection(Of IEntity)
                If ddlnumberoflosses.SelectedValue > 0 Then


                    For Each DgItem As DataGridItem In dgwindhaillosses.Items
                        Dim txtDescription As TextBox = CType(DgItem.FindControl("txtDescription"), TextBox)
                        Dim txtAmount As TextBox = CType(DgItem.FindControl("txtAmount"), TextBox)
                        Dim txtoutcome As TextBox = CType(DgItem.FindControl("txtoutcome"), TextBox)


                        objWindHail = New H03.WindHailLossHistory()
                        objWindHail.WindHailLossHistoryId = 0
                        objWindHail.Description = txtDescription.Text
                        objWindHail.Amount = txtAmount.Text
                        objWindHail.OutComeLosses = txtoutcome.Text
                        objWindHail.TypeofLosses = "Wind-Hail"
                        geninsuranceColl.Add(objWindHail)

                    Next


                End If
                If ddlnonwindhaillosses.SelectedValue > 0 Then


                    For Each DgItem As DataGridItem In dgnonwindhaillosses.Items
                        Dim txtDescriptionnon As TextBox = CType(DgItem.FindControl("txtDescriptionnon"), TextBox)
                        Dim txtAmountnon As TextBox = CType(DgItem.FindControl("txtAmountnon"), TextBox)
                        Dim txtoutcomenon As TextBox = CType(DgItem.FindControl("txtoutcomenon"), TextBox)

                        objWindHail = New H03.WindHailLossHistory()
                        objWindHail.WindHailLossHistoryId = 0
                        objWindHail.Description = txtDescriptionnon.Text
                        objWindHail.Amount = txtAmountnon.Text
                        objWindHail.OutComeLosses = txtoutcomenon.Text
                        objWindHail.TypeofLosses = "NonWind-Hail"
                        geninsuranceColl.Add(objWindHail)

                    Next
                End If


            Catch ex As Exception


                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally

                'objCoverage = Nothing

            End Try
            Return geninsuranceColl
            logger.Debug("Exiting H03InsuranceHistorycontrol.GetH03InputData")
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

