Imports GarageQuoteSheetDLL
Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports System.Collections.Generic
Imports System.Data

Namespace UserControlH03
    Partial Class RiskdescControl
        Inherits System.Web.UI.UserControl

        ''Implements ISubscriber
        Implements IPublisher
        Implements H03ISubscriber
        Dim vaidatemsg As String
        Dim strName As String = "RiskDescriptiondetails"
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
        Dim subscribers As New List(Of ISubscriber)
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
        Private genRiskColl As GenericCollection(Of IEntity)
        Private objRisk As H03RiskDetails



#End Region



        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            logger.Debug("Entering RiskdescControl.Page_Load")
            If Not IsPostBack Then
                Try
                    ddlcounty.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                    ddlterritory.Items.Insert(0, New System.Web.UI.WebControls.ListItem("Select One", "0"))
                Catch ex As Exception
                    logger.Error("Exception occurred while loadding Agency Information ", ex)
                    logger.Error("Exception Details : " & ex.StackTrace)
                End Try
            End If

            logger.Debug("Exiting RiskdescControl.Page_Load")

        End Sub
        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            'Validation Part Here
            logger.Debug("Entering RiskdescControl.Validate")
            Try


                If rdmailingaddYes.Checked = False And rdmailingaddNo.Checked = False Then

                    vaidatemsg = "Select one  mailing  address(Risk Description)"
                    rdmailingaddYes.Focus()
                    Return (vaidatemsg)
                End If

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try

            Return (vaidatemsg)

            logger.Debug("Exiting RiskdescControl.Validate")


        End Function
        ''Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData

        ''End Function
        ''Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        ''End Sub

        Protected Sub rdmailingaddNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdmailingaddNo.CheckedChanged

            If rdmailingaddNo.Checked = False Then
                txtmaddln1.Text = txtlocaddline1.Text

                txtmaddln2.Text = txtlocaddline2.Text
                txtmacity.Text = txtcity.Text
                txtmastate.Text = txtstate.Text
                txtmaZipcode.Text = txtzipcode.Text
                txtmacounty.Text = ddlcounty.SelectedItem.Text

                txtmaddln1.Focus()


            Else

                txtmaddln1.Text = ""

                txtmaddln2.Text = ""
                txtmacity.Text = ""
                txtmastate.Text = ""
                txtmaZipcode.Text = ""
                txtmacounty.Text = ""
                txtmaddln1.Focus()


            End If

            
        End Sub

        Protected Sub rdmailingaddYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdmailingaddYes.CheckedChanged
            If rdmailingaddYes.Checked = True Then
                txtmaddln1.Text = txtlocaddline1.Text

                txtmaddln2.Text = txtlocaddline2.Text
                txtmacity.Text = txtcity.Text
                txtmastate.Text = txtstate.Text
                txtmaZipcode.Text = txtzipcode.Text
                txtmacounty.Text = ddlcounty.SelectedItem.Text
                txtmaddln1.Focus()



            Else

                txtmaddln1.Text = ""

                txtmaddln1.Text = ""
                txtmacity.Text = ""
                txtmastate.Text = ""
                txtmaZipcode.Text = ""
                txtmacounty.Text = ""
                txtmaddln1.Focus()


            End If

            
        End Sub
        Sub AttachSubscriber()
            Dim ctrl As Control
            Dim Insuctrl As Control

            For Each ctrl In Me.Parent.Parent.Controls
                
                If ctrl.ClientID.ToString().Contains("OperationPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("H03RiskDescriptionl") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
            Next
        End Sub
        Private Sub Attach(ByVal Subscriber As ISubscriber) Implements IPublisher.Attach
            subscribers.Add(Subscriber)
        End Sub
        ' ''Private Function FillControls(ByVal pstrQuoteId As String) As Boolean Implements ISubscriber.FillControls
        ' ''    Return True
        ' ''End Function

        Protected Sub rdmailingaddNo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdmailingaddNo.Load

        End Sub

        Protected Sub txtzipcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtzipcode.TextChanged
            Try
                Dim objValidateService As New ValidateService()
                If objValidateService.IsServiceRunning("SIUService.Service") = False Then
                    Dim strAlert = "<Script Language='JavaScript'>alert('SIULookup Service is not Responding...');</Script>"
                    Response.Write(strAlert)
                Else
                    Dim objService As New SIUService.ServiceSoapClient()
                    Dim DsTerritory As New DataSet()
                    DsTerritory = objService.GetTerritoryCountyInfo(txtzipcode.Text.Trim())
                    ddlcounty.Items.Clear()
                    ddlterritory.Items.Clear()
                    lblTerritorycode.Text = ""
                    If DsTerritory.Tables(0).Rows.Count > 0 Then
                        ddlcounty.DataTextField = "CountyName"
                        ddlcounty.DataValueField = "CountyCode"
                        ddlcounty.DataSource = SelectDistinct(DsTerritory.Tables(0), "CountyCode")
                        ddlcounty.DataBind()

                        ddlterritory.DataTextField = "TerritoryName"
                        ddlterritory.DataValueField = "TerritoryCode"
                        ddlterritory.DataSource = DsTerritory.Tables(0)
                        ddlterritory.DataBind()
                        lblTerritorycode.Text = ddlterritory.Items(ddlterritory.SelectedIndex).Value
                    Else
                        Dim strAlert = "<Script Language='JavaScript'>alert('Zipcode does not exists');</Script>"
                        Response.Write(strAlert)
                    End If
                    txtzipcode.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary> 
        ''' Method to get Distinct Status Record form Datatable Based  on FieldName
        ''' </summary> 
        ''' <param name="SourceTable"></param> 
        ''' <param name="FieldName"></param> 
        ''' <returns></returns> 
        Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal FieldName As String) As DataTable
            Dim dt As New DataTable()
            For i As Integer = 0 To SourceTable.Columns.Count - 1
                dt.Columns.Add(SourceTable.Columns(i).ColumnName, SourceTable.Columns(i).DataType)
            Next
            Dim LastValue As Object = Nothing
            Dim DrNew As DataRow = Nothing
            For Each dr As DataRow In SourceTable.[Select]("", FieldName)
                If LastValue Is Nothing OrElse Not (ColumnEqual(LastValue, dr(FieldName))) Then
                    LastValue = dr(FieldName)
                    DrNew = dt.NewRow()
                    For i As Integer = 0 To SourceTable.Columns.Count - 1

                        DrNew(SourceTable.Columns(i).ColumnName) = dr(SourceTable.Columns(i).ColumnName).ToString()

                    Next
                    dt.Rows.Add(DrNew)

                End If
            Next

            Return dt
        End Function
        ''' <summary> 
        ''' Validate Columns equals 
        ''' </summary> 
        ''' <param name="A"></param> 
        ''' <param name="B"></param> 
        ''' <returns></returns> 
        Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean

            ' Compares two values to see if they are equal. Also compares DBNULL.Value. 
            ' Note: If your DataTable contains object fields, then you must extend this 
            ' function to handle them in a meaningful way if you intend to group on them. 

            If IsDBNull(A) AndAlso IsDBNull(B) Then
                ' both are DBNull.Value 
                Return True
            End If
            If IsDBNull(A) OrElse IsDBNull(B) Then
                ' only one is DBNull.Value 
                Return False
            End If
            Return (A.Equals(B))
            ' value type standard comparison 
        End Function

        Protected Sub ddlterritory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlterritory.SelectedIndexChanged
            lblTerritorycode.Text = ddlterritory.Items(ddlterritory.SelectedIndex).Value
            ddlterritory.Focus()

        End Sub

        Protected Sub txtmaZipcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmaZipcode.TextChanged
            Dim objService As New SIUService.ServiceSoapClient()
            Dim DsTerritory As New DataSet()
            DsTerritory = objService.GetTerritoryCountyInfo(txtmaZipcode.Text.Trim())
            txtmacounty.Text = ""
            If DsTerritory.Tables(0).Rows.Count > 0 Then
                txtmacounty.Text = DsTerritory.Tables(0).Rows(0)("CountyName").ToString()
            Else
                Dim strAlert = "<Script Language='JavaScript'>alert('Zipcode does not exists');</Script>"
                Response.Write(strAlert)
            End If
            txtmaZipcode.Focus()

        End Sub
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            ''<LiteralFact id="county">CALHOUN</LiteralFact>            
            Dim _strInputData As String
            '_strInputData = "<LiteralFact id='county'>" + ddlcounty.Items(ddlcounty.SelectedIndex).Text.ToUpper() + "</LiteralFact>"
            _strInputData = "<LiteralFact id='county'>" + ddlterritory.Items(ddlterritory.SelectedIndex).Text + "</LiteralFact>"
            _strInputData += "<LiteralFact id='State'>" + txtstate.Text.ToUpper() + "</LiteralFact>"
            Return _strInputData
        End Function
        ''' <summary>
        ''' Implements GetH03InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            logger.Debug("Entering RiskdescControl.GetH03InputData")
            Try
                genRiskColl = New GenericCollection(Of IEntity)

                objRisk = New H03RiskDetails()
                objRisk.H03RiskId = 0
                objRisk.ApplicantFName = txtApplicantfirstName.Text.Trim
                objRisk.ApplicantLName = txtApplicantlastName.Text.Trim
                objRisk.ApplicantMName = txtApplicantMiddleIn.Text.Trim
                objRisk.LocationAddLineOne = txtlocaddline1.Text.Trim
                objRisk.LocationAddLineTwo = txtlocaddline2.Text.Trim
                objRisk.LocationCity = txtcity.Text.Trim
                objRisk.LocationState = txtstate.Text.Trim
                objRisk.LocationZipcode = txtzipcode.Text.Trim
                objRisk.LocationCounty = ddlcounty.SelectedItem.Text
                objRisk.TerritoryName = ddlterritory.SelectedItem.Text
                objRisk.TerritoryCode = lblTerritorycode.Text.Trim
                objRisk.HomePhone = txtphone.Text.Trim
                objRisk.WorkPhone = txtworkphone.Text.Trim
                If rdmailingaddYes.Checked Then

                    objRisk.SameMailingAddress = 1
                    objRisk.MailingAddLineOne = txtmaddln1.Text.Trim
                    objRisk.MailingAddLineTwo = txtmaddln2.Text.Trim
                    objRisk.MailingCity = txtmacity.Text.Trim
                    objRisk.MailingState = txtmastate.Text.Trim
                    objRisk.MailingZipcode = txtmaZipcode.Text.Trim
                    objRisk.MailingCounty = txtmacounty.Text.Trim


                Else
                    objRisk.SameMailingAddress = 0
                    objRisk.MailingAddLineOne = txtmaddln1.Text.Trim
                    objRisk.MailingAddLineTwo = txtmaddln2.Text.Trim
                    objRisk.MailingCity = txtmacity.Text.Trim
                    objRisk.MailingState = txtmastate.Text.Trim
                    objRisk.MailingZipcode = txtmaZipcode.Text.Trim
                    objRisk.MailingCounty = txtmacounty.Text.Trim

                End If
                objRisk.LienHolder = txtlienholder.Text.Trim
                objRisk.Commnets = txtcomments.Text.Trim
                genRiskColl.Add(objRisk)

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally

            End Try

            Return genRiskColl
            logger.Debug("Exiting RiskdescControl.GetH03InputData")
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

