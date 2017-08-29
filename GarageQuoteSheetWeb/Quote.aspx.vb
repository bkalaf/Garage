Imports UserControls947
Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Collections
Imports System.Web.Mail
Partial Class Quote
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote = "CreateQuote"
    Private Const COMP_GQS_SearchQuote = "SearchQuotes"
    Private Const xmlCONTEXT = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objAgent As New GarageQuoteSheetDLL.AgentDataModel
        Dim oAgent As GarageQuoteSheetDLL.Agent
        Dim controls As Collection
        'Dim cnt As Microsoft.VisualBasic.Collection.KeyValuePair()

        Dim str1 As String
        Dim str2 As String
        str1 = ""
        str2 = ""







        controls = xmlConfig.GetComponentPropertyCollection("AgentLoginControls")
        Dim myEnumerator As IEnumerator = controls.GetEnumerator()

        str1 = myEnumerator.MoveNext.ToString()



        str2 = controls.Item(1).ToString()


        If controls.Contains("Header").ToString = "True" Then
            Dim uc As HeaderControl = DirectCast(Page.LoadControl("~/UserControls/HeaderControl.ascx"), HeaderControl)
            'accessing the user control header property dynamically 
            uc.Title = "Commercial Transportation Quote Sheet"
            HeaderPh.Controls.Add(uc)

        Else


        End If


        If controls.Contains("AgencyInfo").ToString = "True" Then
            Dim AgencyInfo As Control = LoadControl("UserControls/AgencyInformation.ascx")
            AgencyInfoPh.Controls.Add(AgencyInfo)
        Else

        End If
        If controls.Contains("InsuranceHistory").ToString = "True" Then
            Dim HistoryInsurance As Control = LoadControl("UserControls/InsuranceHistory.ascx")
            InsuranceHistoryPh.Controls.Add(HistoryInsurance)
        Else

        End If


        If controls.Contains("Footer").ToString = "True" Then
            Dim FooterControl As Control = LoadControl("UserControls/FooterControl.ascx")
            FooterPh.Controls.Add(FooterControl)



        Else

        End If





    End Sub

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub
End Class
