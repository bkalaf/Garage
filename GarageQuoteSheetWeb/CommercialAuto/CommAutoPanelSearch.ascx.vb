Imports System.Data.SqlClient
Imports System.Data
Imports GarageQuoteSheetDLL
Imports System.Collections.Generic
Namespace UserControl947
    Partial Class CommAutoPanelSearch
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Implements IPublisher
        Private xmlConfig As XmlUtils.XmlConfig
        Private Shared logger As log4net.ILog = _
                  log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
        Private Const COMP_GQS_CreateQuote = "CreateQuote"
        Private Const COMP_GQS_SearchQuote = "SearchQuotes"
        Private Const xmlCONTEXT = "GarageQuoteSheet"
        Dim vaidatemsg As String
        Dim strName As String = "SearchQuotes"
        Dim subscribers As New List(Of ISubscriber)
#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region
        Private Function Validate() As String Implements ISubscriber.Validate

            'Validation Part Here
            Return ""
        End Function
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        End Sub
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        Private Function FillControls(ByVal strAgentId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoPanelSearch.FillControls")
            Try
                BindGrid(strAgentId)
            Catch ex As Exception
                logger.Error("Exception occurred while fetching commercial quotes for agent :" & strAgentId, ex)
                logger.Error("Exception Details : " & ex.StackTrace)
                Throw ex
            End Try
            logger.Debug("Exiting CommAutoPanelSearch.FillControls")
            Return True
        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            Dim genAdditioanlCollection As GenericCollection(Of IEntity)
            genAdditioanlCollection = New GenericCollection(Of IEntity)

            Return genAdditioanlCollection
        End Function
        Private Sub BindGrid(ByVal pstrAgentID As String, Optional ByVal sortExpression As String = Nothing)
            Dim oGarageQuoteData As New GarageQuoteSheetDLL.GarageQuoteDataModel
            Dim iCol As ICollection
            Try
                gvQuote.DataSource = Nothing

                'Following fills Reject
                xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
                Dim strDays As String = xmlConfig.GetComponentProperty(COMP_GQS_SearchQuote, "RecordsFrom").Trim
                Dim intDays As Integer = -1
                If strDays <> "" Then
                    If IsNumeric(strDays) Then
                        intDays = CInt(strDays)
                    End If
                End If

                iCol = oGarageQuoteData.searchQuoteDetails(pstrAgentID, "1", intDays)
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
                    'lblMessage.Text = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SearchAgent")
                    'lblMessage.Visible = True
                    gvQuote.Visible = False
                End If
                pnlSearch.Visible = True
            Catch ex As Exception
                'lblMessage.Text = ".NET Exception: " & ex.Message
                'lblMessage.Visible = True
            End Try
        End Sub
        Sub AttachSubscriber()
            Dim ctrl As Control
            Dim Insuctrl As Control

            For Each ctrl In Me.Parent.Parent.Controls
                If ctrl.ClientID.ToString().Contains("InsuranceHistoryPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("AutoCommInsuranceHistorycontrol") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("Coverageph") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("Coverage") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("Vehicleph") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("Vehicle") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("OperationPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("Operation") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("DriverPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("Driver") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("AgencyInfoPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("AgencyInfo") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If
                If ctrl.ClientID.ToString().Contains("AdditionalPh") Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains("AdditionalNotes") Then
                            Attach(CType(Insuctrl, ISubscriber))
                        End If
                    Next
                End If

            Next
        End Sub
        Private Sub Attach(ByVal Subscriber As ISubscriber) Implements IPublisher.Attach
            subscribers.Add(Subscriber)
        End Sub
        Protected Sub gvQuote_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuote.RowCommand

            Dim subscriber As ISubscriber
            Dim strQuoteId As String = e.CommandArgument.ToString
            AttachSubscriber()
            If e.CommandName = "FillDetails" Then


                For Each subscriber In subscribers
                    Select Case subscriber.Name

                        Case "AgencyDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "OperationDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "InsuranceDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "CoverageDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "VehicleDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "DriverDetails"
                            subscriber.FillControls(strQuoteId)
                        Case "AdditionNotes"
                            subscriber.FillControls(strQuoteId)
                    End Select
                Next
                'If Not (Session("SearchedQuoteid") Is Nothing) Then
                Session("SearchedQuoteid") = strQuoteId
                'Else
                'End If
                CType(Me.Parent.Parent.FindControl("hdnSubmit"), HtmlInputHidden).Value = "0"
                pnlSearch.Visible = False
            End If
        End Sub



        Protected Sub gvQuote_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvQuote.Sorting
            BindGrid(e.SortExpression.ToString)
        End Sub

        Protected Sub gvQuote_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvQuote.PageIndexChanging
            gvQuote.PageIndex = e.NewPageIndex
            BindGrid(Session("AgentCode").ToString)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            pnlSearch.Visible = False
        End Sub
    End Class
End Namespace

