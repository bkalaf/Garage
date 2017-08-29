Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.SqlClient
Imports GarageQuoteSheetDLL
Imports System.Data
Imports System.IO
Imports System.Xml
Partial Class Report_ReportViewer
    Inherits System.Web.UI.Page
    Private xmlConfig As XmlUtils.XmlConfig
    Dim PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Dim strCONTEXT As String = "GarageQuoteSheet"
    Private PersonalProperty As New ReportDocument
    Private dsPersonalProperty As New DSPersonalProperty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Shell("C:\Inetpub\wwwroot\documents\H03\Quote-PdfFile\Xyz.pdf")
        'Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.Start("http://itdevelop2/documents/H03/Quote-PdfFile/Xyz.pdf")
        'Dim strAlert = "<Script Language='JavaScript'>strURL=window.open('http://itdevelop2/documents/H03/Quote-PdfFile/Xyz.pdf','','status=0,toolbar=0,width=650,height=550,titlebar=no');strURL.document.title = 'Home Owner';</Script>"
        'Response.Write(strAlert)
        ' wait until it exits
        'myProcess.WaitForExit()

        If Not IsPostBack Then
            Dim _strReportId As String = Request.QueryString("RptId")
            Dim _intQuouteId As Integer = Convert.ToInt32(Request.QueryString("QuoteId"))
            If _strReportId = "1" Then
                ConfigureCrystalReports(_intQuouteId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Configure Crystal Report Based on QuoteId
    ''' </summary>
    ''' <param name="_intQuoteid"></param>
    ''' <remarks></remarks>
    Private Sub ConfigureCrystalReports(ByVal _intQuoteid As Integer)
        Dim objH03Quote As New GarageQuoteSheetDLL.H03QuoteDataModel
        Dim DsProperty As System.Data.DataSet = objH03Quote.GetQuoteDetails(_intQuoteid)
        Dim Dr As DataRow = dsPersonalProperty.Tables(0).NewRow
        Dim _intCol As Integer = 0
        For _intCol = 0 To DsProperty.Tables(0).Columns.Count - 1
            If DsProperty.Tables(0).Columns(_intCol).ColumnName <> "HomeDescription" Then
                Select Case (DsProperty.Tables(0).Columns(_intCol).ColumnName)
                    Case "A_DwellingAmount", "C_PersonalProperty", "E_Liability", "F_MedPay", "B_AdjacentStructure", "D_LossofUse", "DeductibleAmount"
                        Dim strValue As String = Val(DsProperty.Tables(0).Rows(0)(_intCol)).ToString()
                        Dr(DsProperty.Tables(0).Columns(_intCol).ColumnName) = String.Format("{0:C0}", Double.Parse(strValue.Replace("'", ""))).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "")
                    Case Else
                        Dr(DsProperty.Tables(0).Columns(_intCol).ColumnName) = DsProperty.Tables(0).Rows(0)(_intCol)
                End Select

            Else
                ''Extract XML
                Dim docbinaryarray As Byte() = DirectCast(DsProperty.Tables(0).Rows(0)("HomeDescription"), Byte())
                Dim strFileName = System.Guid.NewGuid.ToString()
                Dim TargetPath As String = Server.MapPath(strFileName + ".xml")
                Dim objfilestream As New FileStream(TargetPath, FileMode.Create, FileAccess.ReadWrite)
                objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length)
                objfilestream.Close()
                Dim Tr As TextReader = New StreamReader(TargetPath)
                Dim _strMenuXml As String = Tr.ReadToEnd()
                Dim NList As XmlNodeList = GetXmlNodeList(_strMenuXml, "RiskDescription")
                For Each Node As XmlNode In NList.Item(0)
                    Select Case Node.Name.Trim()
                        Case "MAddress1"
                            Dr("MAddress1") = Node.InnerText.Trim()
                        Case "MAddress2"
                            Dr("MAddress2") = Node.InnerText.Trim()
                        Case "MCity"
                            Dr("MCity") = Node.InnerText.Trim()
                        Case "MState"
                            Dr("MState") = Node.InnerText.Trim()
                        Case "MZipCode"
                            Dr("MZip") = Node.InnerText.Trim()
                            'Case "MCounty"

                    End Select
                Next
                NList = GetXmlNodeList(_strMenuXml, "HomeDescription")
                For Each Node As XmlNode In NList.Item(0)
                    Select Case Node.Name.Trim()
                        Case "Occupancy"
                            Dr("Occupancy") = Node.InnerText.Trim()
                        Case "ConstructionType"
                            Dr("ConstructionType") = Node.InnerText.Trim()
                        Case "YearBuilt"
                            Dr("YearBuilt") = Node.InnerText.Trim()
                        Case "ProtectionClass"
                            Dr("ProtectionClass") = Node.InnerText.Trim()
                        Case "Families"
                            Dr("NumberOfFamilies") = Node.InnerText.Trim()
                        Case "MilesToCoastalWater"
                            Dr("MilestoCoastal") = Node.InnerText.Trim()
                        Case "Pool"
                            Dr("Pool") = Node.InnerText.Trim()
                        Case "Trampoline"
                            Dr("Trampoline") = Node.InnerText.Trim()
                        Case "SquareFootage"
                            Dr("SqFootage") = Node.InnerText.Trim()
                        Case "Stories"
                            Dr("Stories") = Node.InnerText.Trim()
                        Case "MilesToFireStation"
                            Dr("MilestoStation") = Node.InnerText.Trim()
                        Case "FireHydrant"
                            Dr("FeetFromHyd") = Node.InnerText.Trim()
                            'Case "Stories"
                            '    Dr("Stories") = Node.InnerText.Trim()
                            'Case "Stories"
                            '    Dr("Stories") = Node.InnerText.Trim()
                    End Select
                Next
                Tr.Close()
                If File.Exists(TargetPath) Then
                    File.Delete(TargetPath)
                End If
            End If
        Next
        dsPersonalProperty.Tables(0).Rows.Add(Dr)
        PersonalProperty.Load(Server.MapPath("CrptPersonalProperty.rpt"))
        PersonalProperty.SetDataSource(dsPersonalProperty)
        CrptViewer.ReportSource = PersonalProperty
        CrptViewer.DataBind()
        'SavePdfFile()
        Export2Pdf()
        ''PrintPdf()
    End Sub
    ''' <summary>
    ''' SavePdf File using FileStreem
    ''' </summary>
    ''' <remarks></remarks>
    Sub SavePdfFile()
        'Dim rptSummary As ReportDocument
        
        Dim strExportFile As String
        Dim objExOpt As ExportOptions
        Dim objDiskOpt As New DiskFileDestinationOptions
        xmlConfig = New XmlUtils.XmlConfig(strCONTEXT, PROPERTIES)
        Dim strExportPath As String = xmlConfig.GetComponentProperty("H03", "ExportPDFPath")
        strExportFile = "Xyz.pdf"
        If File.Exists(strExportPath & "/" & strExportFile) Then
            File.Delete(strExportPath & "/" & strExportFile)
        End If
        ' ... process your report here ...

        objDiskOpt.DiskFileName = strExportPath & "/" & strExportFile
        objExOpt = PersonalProperty.ExportOptions
        objExOpt.ExportDestinationType = ExportDestinationType.DiskFile
        objExOpt.ExportFormatType = ExportFormatType.PortableDocFormat
        objExOpt.DestinationOptions = objDiskOpt
        PersonalProperty.Export()
        PersonalProperty.Close()
        objExOpt = Nothing
        ''System.Diagnostics.Process.Start("Notepad.exe")
        'System.Diagnostics.Process.Start(strExportPath & "/" & strExportFile)
        ''Response.Redirect(strExportPath & "/" & strExportFile)
        'RefreshContent(strExportPath & "/" & strExportFile)
        'Shell("C:\Inetpub\wwwroot\documents\H03\Quote-PdfFile\Xyz.pdf")
    End Sub
    Public Shared Sub RefreshContent(ByVal filePath As String)
        Dim processor As New System.Diagnostics.Process()
        processor.StartInfo.FileName = filePath
        processor.StartInfo.Arguments = "/q"
        'quiet mode 
        processor.StartInfo.CreateNoWindow = True
        processor.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(filePath)
        processor.StartInfo.UseShellExecute = False
        processor.StartInfo.LoadUserProfile = False
        'true also failed. 
        'processor.StartInfo.UserName = "RefreshContentFromWeb"
        'Dim password As SecureString = MakeSecureString("0a8fsud")
        'password.MakeReadOnly()
        'processor.StartInfo.Password = password
        processor.Start()

        ''processor.WaitForExit(1000 * 60 * 5)
        '5 minutes. 
    End Sub

    ''' <summary>
    ''' Export2Pdf
    ''' </summary>
    ''' <remarks></remarks>
    Sub Export2Pdf()
        ''PersonalProperty.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "PersonalProperty")
        Dim oStream As New MemoryStream
        Try
            oStream = PersonalProperty.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(oStream.ToArray())
            Response.End()
        Catch ex As Exception

        End Try
    End Sub
    Sub PrintPdf()
        'Dim margins As PageMargins = PersonalProperty.PrintOptions.PageMargins
        'margins.bottomMargin = 200
        'margins.leftMargin = 200
        'margins.rightMargin = 50
        'margins.topMargin = 100
        'PersonalProperty.PrintOptions.ApplyPageMargins(margins)
        PersonalProperty.PrintToPrinter(1, False, 1, 1)
    End Sub
    ''' <summary>
    ''' GetXml NodeList
    ''' </summary>
    ''' <param name="_strXML"></param>
    ''' <param name="strElementName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetXmlNodeList(ByVal _strXML As String, ByVal strElementName As String) As XmlNodeList
        'ApplicantInfo/RiskDescriptionxmlDoc.SelectNodes("ApplicantInfo/RiskDescription")
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(_strXML)
        Dim _xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("ApplicantInfo/" + strElementName)
        Return _xmlNodeList
    End Function
End Class
