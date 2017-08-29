Imports UserControl947
Imports UserControlH03
Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Collections
Imports System.Web.Mail
Partial Class H03CreateQuote
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote As String = "CreateQuote"
    Private Const COMP_GQS_SearchQuote As String = "SearchQuotes"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
        Dim oAgent As GarageQuoteSheetDLL.Agent
        Dim controls As Collection
        'Dim cnt As Microsoft.VisualBasic.Collection.KeyValuePair()

        Dim str1 As String
        Dim str2 As String
        str1 = ""
        str2 = ""





        btnSearch.Visible = False



        controls = xmlConfig.GetComponentPropertyCollection("AgentLoginControls")
        Dim myEnumerator As IEnumerator = controls.GetEnumerator()

        str1 = myEnumerator.MoveNext.ToString()



        str2 = controls.Item(1).ToString()



        'If controls.Contains("Header").ToString = "True" Then
        '    Dim uc As UserControl947.HeaderControl = DirectCast(Page.LoadControl("~/CommercialAuto/HeaderControl.ascx"), UserControl947.HeaderControl)
        '    'accessing the user control header property dynamically 
        '    uc.Title = "HomeOwners Quote Sheet"
        '    HeaderPh.Controls.Add(uc)

        'Else

        'End If


        If controls.Contains("AgencyInfo").ToString = "True" Then
            Dim AgencyInfo As Control = LoadControl("H03Controls/H03AgencyInformation.ascx")
            AgencyInfoPh.Controls.Add(AgencyInfo)
        Else

        End If

        If controls.Contains("Risk").ToString = "True" Then
            Dim Operation As Control = LoadControl("H03Controls/H03RiskDescriptionl.ascx")
            RiskPh.Controls.Add(Operation)
        Else

        End If

        If controls.Contains("Home").ToString = "True" Then
            Dim Vehicle As Control = LoadControl("H03Controls/H03HomeDesc.ascx")
            Homeph.Controls.Add(Vehicle)
        Else

        End If



        If controls.Contains("InsuranceHistory").ToString = "True" Then

            Dim Insurancehistory As Control = LoadControl("H03Controls/H03InsuranceHistorycontrol.ascx")


            InsuranceHistoryPh.Controls.Add(Insurancehistory)



        Else

        End If

        If controls.Contains("Coverage").ToString = "True" Then
            Dim coverage As Control = LoadControl("H03Controls/H03CoverageControl.ascx")
            Coverageph.Controls.Add(coverage)
        Else

        End If
        If controls.Contains("Quote").ToString = "True" Then
            Dim coverage As Control = LoadControl("H03Controls/H03Quotecontrol.ascx")
            Quoteph.Controls.Add(coverage)
        Else

        End If

        If controls.Contains("Footer").ToString = "True" Then
            Dim FooterControl As Control = LoadControl("H03Controls/FooterControl.ascx")
            FooterPh.Controls.Add(FooterControl)



        Else

        End If
    End Sub

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub
End Class

