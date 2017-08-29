Imports UserControl947
Imports System.Data
Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports log4net
Imports XmlUtils
Imports System.Collections
Imports System.Web.Mail
Partial Class CommercialAuto
    Inherits System.Web.UI.Page
    Dim app As String

    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote As String = "CreateQuote"
    Private Const COMP_GQS_SearchQuote As String = "SearchQuotes"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
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


        app = Request.QueryString("app")




        controls = xmlConfig.GetComponentPropertyCollection("AgentLoginControls")
        Dim myEnumerator As IEnumerator = controls.GetEnumerator()

        str1 = myEnumerator.MoveNext.ToString()



        str2 = controls.Item(1).ToString()


        'If controls.Contains("Header").ToString = "True" Then
        '    Dim uc As HeaderControl = DirectCast(Page.LoadControl("~/CommercialAuto/HeaderControl.ascx"), HeaderControl)
        '    'accessing the user control header property dynamically 
        '    uc.Title = "Commercial Transportation Quote Sheet"
        '    HeaderPh.Controls.Add(uc)

        'Else


        'End If


        If controls.Contains("AgencyInfo").ToString = "True" Then
            Dim AgencyInfo As Control = LoadControl("CommercialAuto/AgencyInformation.ascx")
            AgencyInfoPh.Controls.Add(AgencyInfo)
        Else

        End If

        If controls.Contains("Operation").ToString = "True" Then
            Dim Operation As Control = LoadControl("CommercialAuto/CommAutoOperationControl.ascx")
            OperationPh.Controls.Add(Operation)
        Else

        End If

        If controls.Contains("Vehicle").ToString = "True" Then
            Dim Vehicle As Control = LoadControl("CommercialAuto/CommAutoVehicleControl.ascx")
            Vehicleph.Controls.Add(Vehicle)
        Else

        End If

        If controls.Contains("Driver").ToString = "True" Then
            Dim driver As Control = LoadControl("CommercialAuto/CommAutoDriverControl.ascx")
            DriverPh.Controls.Add(driver)
        Else

        End If
        
        If controls.Contains("InsuranceHistory").ToString = "True" Then

            Dim uc1 As AutoCommInsuranceHistorycontrol = DirectCast(Page.LoadControl("~/CommercialAuto/AutoCommInsuranceHistorycontrol.ascx"), AutoCommInsuranceHistorycontrol)
            'accessing the user control header property dynamically 

            InsuranceHistoryPh.Controls.Add(uc1)
            'Dim HistoryInsurance As Control = LoadControl("CommercialAuto/AutoCommInsuranceHistorycontrol.ascx")
            'InsuranceHistoryPh.Controls.Add(HistoryInsurance)
            Dim Threshold As TextBox = DirectCast(InsuranceHistoryPh.Controls(0).FindControl("txtTermfrom1"), TextBox)


           

        Else

        End If

        If controls.Contains("Coverage").ToString = "True" Then
            Dim coverage As Control = LoadControl("CommercialAuto/CommAutoCoverageControl.ascx")
            Coverageph.Controls.Add(coverage)
        Else

        End If


        If controls.Contains("Footer").ToString = "True" Then
            Dim FooterControl As Control = LoadControl("CommercialAuto/FooterControl.ascx")
            FooterPh.Controls.Add(FooterControl)



        Else

        End If

    End Sub

    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

    End Sub
End Class
