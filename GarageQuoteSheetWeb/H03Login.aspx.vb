Imports UserControls947
Imports log4net
Imports System.Collections
Imports System.Collections.Specialized

Partial Class H03Login
    Inherits System.Web.UI.Page

    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_AgentLogin = "AgentLogin"
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
            uc.Title = "HomeOwners Quote Sheet"
            HeaderPh.Controls.Add(uc)

        Else


        End If


        If controls.Contains("Login").ToString = "True" Then
            Dim LoginControl As Control = LoadControl("UserControls/LoginH03.ascx")
            LoginPh.Controls.Add(LoginControl)
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
