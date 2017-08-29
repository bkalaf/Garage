Imports System.Data
Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports XmlUtils
Imports System.Web
Imports System.Configuration
Imports GarageQuoteSheetDLL
Imports ImageRightFileCreator
Imports System.Collections.Generic

Public Class PDFCreater
    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_PDF = "PDFGenerator"
    Private Const COMP_GQS_TransPDF = "PDFGenerator_TRANS"
    Private Const xmlCONTEXT = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Public Function CreatePDF(ByVal objGenericIEntity As GenericCollection(Of IEntity), ByVal strQuoteNbr As String) As Boolean
        logger.Debug("Entering PDFCreater.CreatePDF")
        Dim document As New Document
        Try

            'PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "-" & Format(Now, "ddMMMyy-HHmmss") & ".pdf", FileMode.Create))

            If strQuoteNbr.Length >= 8 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 7 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 6 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 5 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 4 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 3 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 2 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
            ElseIf strQuoteNbr.Length = 1 Then
                PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
            End If



            AddHeader2PDF(document)
            document.Open()
            write2PDF(document, objGenericIEntity)
            document.Close()

            Return True
        Catch ex As Exception
            Return False
            logger.Error("Exception in PDFCreater.CreatePDF: " & ex.Message)
        End Try
        logger.Debug("Exiting PDFCreater.CreatePDF")
    End Function
    Public Function CreateGaragePDF(ByVal objQuoteData As GenericCollection(Of IEntity), _
        ByVal objOperations As GenericCollection(Of IEntity), _
        ByVal objInsuranceHistory As GenericCollection(Of IEntity), _
        ByVal objInsuranceLosses As GenericCollection(Of IEntity), _
        ByVal objCoverages As GenericCollection(Of IEntity), _
        ByVal objPersons As GenericCollection(Of IEntity), _
         ByVal strQuoteNbr As String) As Boolean
        logger.Debug("Entering PDFCreater.CreatePDF")
        Dim document As New Document
        Try

            'PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "-" & Format(Now, "ddMMMyy-HHmmss") & ".pdf", FileMode.Create))

            HttpContext.Current.Session("GarageAttachmentFileName") = ""
            If (Convert.ToInt32(ConfigurationManager.AppSettings("VersionID") > 1)) Then
                Dim objWcfImageRightService = New WcfImageRightService.ImageRightServiceClient()
                Dim strImageSvr As String

                strImageSvr = objWcfImageRightService.GetFileLocation(Convert.ToInt32(ConfigurationManager.AppSettings("VersionID")))

                If strQuoteNbr.Length >= 8 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 7 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 6 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "00" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "00" & ".pdf"
                ElseIf strQuoteNbr.Length = 5 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "000" & ".pdf"
                ElseIf strQuoteNbr.Length = 4 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "0000" & ".pdf"
                ElseIf strQuoteNbr.Length = 3 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "00000" & ".pdf"
                ElseIf strQuoteNbr.Length = 2 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "000000" & ".pdf"
                ElseIf strQuoteNbr.Length = 1 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = strImageSvr & strQuoteNbr & "0000000" & ".pdf"
                End If


            Else
                If strQuoteNbr.Length >= 8 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 7 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 6 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf"
                ElseIf strQuoteNbr.Length = 5 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf"
                ElseIf strQuoteNbr.Length = 4 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf"
                ElseIf strQuoteNbr.Length = 3 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf"
                ElseIf strQuoteNbr.Length = 2 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf"
                ElseIf strQuoteNbr.Length = 1 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("GarageAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf"
                End If

            End If



            AddHeader2PDF(document)
            document.Open()
            write2GaragePDF(document, objQuoteData, objOperations, objInsuranceHistory, objInsuranceLosses, objCoverages, objPersons, objQuoteData)
            document.Close()

            Return True
        Catch ex As Exception
            Return False
            logger.Error("Exception in PDFCreater.CreatePDF: " & ex.Message)
        End Try
        logger.Debug("Exiting PDFCreater.CreatePDF")
    End Function
    Public Function CreateTransportationPDF(ByVal objQuoteData As GenericCollection(Of IEntity), _
    ByVal objOperations As GenericCollection(Of IEntity), _
    ByVal objCoverages As GenericCollection(Of IEntity), _
    ByVal objInsuranceHistroy As GenericCollection(Of IEntity), _
    ByVal objVehicles As GenericCollection(Of IEntity), _
    ByVal objDrivers As GenericCollection(Of IEntity), _
    ByVal objAdditionalNotes As GenericCollection(Of IEntity), ByVal strQuoteNbr As String, ByVal filelst As System.Collections.Generic.List(Of String)) As Boolean
        logger.Debug("Entering PDFCreater.CreatePDF")
        Dim document As New Document

        Try

            'PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "-" & Format(Now, "ddMMMyy-HHmmss") & ".pdf", FileMode.Create))

            ' HttpContext.Current.Session("CommercialAttachmentFileName") = ""

            'If strQuoteNbr.Length >= 8 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"


            'ElseIf strQuoteNbr.Length = 7 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"

            'ElseIf strQuoteNbr.Length = 6 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf"

            'ElseIf strQuoteNbr.Length = 5 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf"

            'ElseIf strQuoteNbr.Length = 4 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf"

            'ElseIf strQuoteNbr.Length = 3 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf"

            'ElseIf strQuoteNbr.Length = 2 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf"

            'ElseIf strQuoteNbr.Length = 1 Then
            '    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
            '    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf"

            'End If

            HttpContext.Current.Session("CommercialAttachmentFileName") = ""
            If (Convert.ToInt32(ConfigurationManager.AppSettings("VersionID") > 1)) Then
                Dim objWcfImageRightService = New WcfImageRightService.ImageRightServiceClient()
                Dim strImageSvr As String

                strImageSvr = objWcfImageRightService.GetFileLocation(Convert.ToInt32(ConfigurationManager.AppSettings("VersionID")))

                If strQuoteNbr.Length >= 8 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 7 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 6 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "00" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "00" & ".pdf"
                ElseIf strQuoteNbr.Length = 5 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "000" & ".pdf"
                ElseIf strQuoteNbr.Length = 4 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "0000" & ".pdf"
                ElseIf strQuoteNbr.Length = 3 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "00000" & ".pdf"
                ElseIf strQuoteNbr.Length = 2 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "000000" & ".pdf"
                ElseIf strQuoteNbr.Length = 1 Then
                    PdfWriter.GetInstance(document, New FileStream(strImageSvr & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = strImageSvr & strQuoteNbr & "0000000" & ".pdf"
                End If


            Else
                If strQuoteNbr.Length >= 8 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 7 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0" & ".pdf"
                ElseIf strQuoteNbr.Length = 6 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00" & ".pdf"
                ElseIf strQuoteNbr.Length = 5 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000" & ".pdf"
                ElseIf strQuoteNbr.Length = 4 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000" & ".pdf"
                ElseIf strQuoteNbr.Length = 3 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "00000" & ".pdf"
                ElseIf strQuoteNbr.Length = 2 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "000000" & ".pdf"
                ElseIf strQuoteNbr.Length = 1 Then
                    PdfWriter.GetInstance(document, New FileStream(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf", FileMode.Create))
                    HttpContext.Current.Session("CommercialAttachmentFileName") = xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFPath") & strQuoteNbr & "0000000" & ".pdf"
                End If

            End If


            AddHeader2TransportationPDF(document)
            document.Open()
            write2TransportationPDF(document, objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionalNotes, filelst)

            document.Close()

            Return True
        Catch ex As Exception

            logger.Error("Exception in PDFCreater.CreatePDF: " & ex.Message)
            logger.Error(ex.StackTrace)
            Return False
        End Try
        logger.Debug("Exiting PDFCreater.CreatePDF")
    End Function

    Private Sub AddHeader2PDF(ByRef doc As iTextSharp.text.Document)
        Dim phr As New Phrase(xmlConfig.GetComponentProperty(COMP_GQS_PDF, "PDFHeader"), FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, iTextSharp.text.Color.BLUE))
        Dim hdr As New HeaderFooter(phr, False)
        hdr.Alignment = 1
        doc.Header = hdr
    End Sub
    Private Sub AddHeader2TransportationPDF(ByRef doc As iTextSharp.text.Document)
        Dim phr As New Phrase(xmlConfig.GetComponentProperty(COMP_GQS_TransPDF, "PDFHeader"), FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, iTextSharp.text.Color.BLUE))
        Dim hdr As New HeaderFooter(phr, False)
        hdr.Alignment = 1
        doc.Header = hdr
    End Sub

    Private Sub write2PDF(ByRef doc As iTextSharp.text.Document, ByVal objData As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        Dim _strUninsuredMotorist As String = ""
        Dim _strReject As String = ""
        For Each obj As Object In objData
            If Not IsNothing(obj) Then
                Dim t As Type = obj.GetType
                doc.Add(New Paragraph(""))
                doc.Add(New Paragraph(""))
                p = New Paragraph(New Paragraph(obj.ToString.Split(".")(1) & " Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
                'p.Alignment = 1
                doc.Add(p)
                doc.Add(New Paragraph(""))
                For Each pp As System.Reflection.PropertyInfo In t.GetProperties()
                    If InStr(pp.PropertyType.FullName, "GarageQuoteSheetDLL.InsuredOperation", CompareMethod.Text) > 0 _
                    Or InStr(pp.PropertyType.FullName, "GarageQuoteSheetDLL.OtherBusiness", CompareMethod.Text) > 0 _
                    Or InStr(pp.PropertyType.FullName, "GarageQuoteSheetDLL.OtherLocation", CompareMethod.Text) > 0 Then
                        If Not bl Then WriteGOObjectValues2Pdf(doc, obj)
                        bl = True
                    ElseIf Not IsNothing(pp.GetValue(obj, Nothing)) Then
                        If pp.GetValue(obj, Nothing).ToString.Trim = "1" Then
                            strVal = "Yes"
                        ElseIf pp.GetValue(obj, Nothing).ToString.Trim = "0" Then
                            strVal = "No"
                        Else : strVal = pp.GetValue(obj, Nothing).ToString
                        End If
                        If pp.Name = "IsUninsuredMotorist" Then
                            _strUninsuredMotorist = strVal
                        ElseIf pp.Name = "Reject" Then
                            _strReject = strVal
                            ''Add IsUninsuredMotorist
                            If _strReject.Trim <> "" Then
                                p = New Paragraph("IsUninsuredMotorist:          """ & _strReject & """")
                            Else : p = New Paragraph("IsUninsuredMotorist: ")
                            End If
                            doc.Add(p)
                            '' Add Rejected Value
                            If _strUninsuredMotorist.Trim <> "" Then
                                p = New Paragraph("Reject:          """ & _strUninsuredMotorist & """")
                            Else : p = New Paragraph("Reject: ")
                            End If
                            doc.Add(p)
                        ElseIf pp.Name = "NoofDealerPlates" Then
                            Select Case Convert.ToInt32(strVal)
                                Case 30
                                    strVal = 1
                                Case 31
                                    strVal = "2"
                                Case 32
                                    strVal = "3"
                                Case 33
                                    strVal = "4"
                                Case 34
                                    strVal = "5"
                                Case 35
                                    strVal = "6"
                                Case 36
                                    strVal = "7"
                                Case 37
                                    strVal = "8"
                                Case 38
                                    strVal = "9"
                                Case 39
                                    strVal = "10 Or more"
                            End Select
                            If strVal.Trim <> "" Then
                                p = New Paragraph(pp.Name & ":          """ & strVal & """")
                            Else : p = New Paragraph(pp.Name & ": ")
                            End If
                            doc.Add(p)
                        Else
                            If strVal.Trim <> "" Then
                                p = New Paragraph(pp.Name & ":          """ & strVal & """")
                            Else : p = New Paragraph(pp.Name & ": ")
                            End If
                            doc.Add(p)
                        End If

                    End If
                Next
            End If
        Next

    End Sub

    Private Sub write2GaragePDF(ByRef doc As iTextSharp.text.Document, ByVal objQuoteData As GenericCollection(Of IEntity), _
        ByVal objOperations As GenericCollection(Of IEntity), _
        ByVal objInsuranceHistory As GenericCollection(Of IEntity), _
        ByVal objInsuranceLosses As GenericCollection(Of IEntity), _
        ByVal objCoverages As GenericCollection(Of IEntity), _
        ByVal objPersons As GenericCollection(Of IEntity), _
        ByVal objAdditionalNotes As GenericCollection(Of IEntity))
        logger.Debug("Entering PDFCreator.write2GaragePDF")

        logger.Debug("Writing Agency Information...")

        WriteAgencyInfo2GaragePDF(doc, objQuoteData)
        logger.Debug("Writing Operation Details...")
        WriteOperationDetails2GaragePDF(doc, objQuoteData, objOperations, objPersons)
        Dim strval As String
        strval = CType(objOperations.Item(0), GarageOperations).YrsExperience_NewVenture
        If strval <> "0" Then
            logger.Debug("Writing Insurance History...")
            WriteInsuranceHistory2GaragePDF(doc, objInsuranceHistory, objInsuranceLosses)
        End If
        logger.Debug("Writing Coverage Details...")
        WriteCoverageDetails2GaragePDF(doc, objCoverages, objQuoteData)
        logger.Debug("Exiting PDFCreator.write2GaragePDF")

    End Sub

    Private Sub WriteAgencyInfo2GaragePDF(ByRef doc As iTextSharp.text.Document, ByVal objQuoteData As GenericCollection(Of IEntity))
        logger.Debug("Entering PDFCreator.WriteAgencyInfo2GaragePDF")
        Dim p As Paragraph

        Dim strVal As String
        Dim tbl As Table
        Dim tblCell As Cell
        Dim bl As Boolean = False
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Agency Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))

        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objQuoteData Is Nothing) Then
            If objQuoteData.Count > 0 Then
                tbl = New Table(2, 7)
                tbl.BorderWidth = 0
                tbl.BorderColor = New Color(255, 255, 255) ' No color
                tbl.Cellpadding = 0
                tbl.Cellspacing = 0
                tbl.DefaultCellBorder = 0



                tblCell = New Cell("AgencyID")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 0, 0)
                tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).AgentID)
                tblCell.Width = 100
                tblCell.Border = 0
                tbl.AddCell(tblCell, 0, 1)

                tblCell = New Cell("Agency Name")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 1, 0)
                tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).CreatedORModifiedBY)
                tblCell.Width = 100
                tbl.AddCell(tblCell, 1, 1)

                tblCell = New Cell("Contact")
                tblCell.Width = 5
                tbl.AddCell(tblCell, 2, 0)
                tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).Contact)
                tblCell.Width = 5
                tbl.AddCell(tblCell, 2, 1)

                tblCell = New Cell("Phone")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 3, 0)
                tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).Phone)
                tblCell.Width = 100
                tbl.AddCell(tblCell, 3, 1)

                strVal = IIf(CType(objQuoteData.Item(0), GarageQuote).Email = "", CType(objQuoteData.Item(0), GarageQuote).Fax, CType(objQuoteData.Item(0), GarageQuote).Email)
                tblCell = New Cell("Email/Fax")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 4, 0)
                tblCell = New Cell(strVal)
                tblCell.Width = 100
                tbl.AddCell(tblCell, 4, 1)

                Dim objDMGarageQuote As New GarageQuoteDataModel
                Dim strGarageQuoteNumber As String
                Try
                    strGarageQuoteNumber = objDMGarageQuote.getGarageQuoteNo(CType(objQuoteData.Item(0), GarageQuote).GarageQuoteID)
                Catch ex As Exception
                    strGarageQuoteNumber = CType(objQuoteData.Item(0), GarageQuote).GarageQuoteID
                End Try
                tblCell = New Cell("Garage Quote Number")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 5, 0)
                tblCell = New Cell(strGarageQuoteNumber)
                tblCell.Width = 100
                tbl.AddCell(tblCell, 5, 1)

                tblCell = New Cell("Submission Date")
                tblCell.Width = 30
                tbl.AddCell(tblCell, 6, 0)
                tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).CreatedORModifiedDate.ToShortDateString & " " & CType(objQuoteData.Item(0), GarageQuote).CreatedORModifiedDate.ToShortTimeString)
                tblCell.Width = 100
                tbl.AddCell(tblCell, 6, 1)


                doc.Add(tbl)
            End If
        End If
        logger.Debug("Exiting PDFCreator.WriteAgencyInfo2GaragePDF")
    End Sub

    Private Sub WriteOperationDetails2GaragePDF(ByRef doc As iTextSharp.text.Document, ByVal objQuoteData As GenericCollection(Of IEntity), ByVal objOperations As GenericCollection(Of IEntity), ByVal objPersons As GenericCollection(Of IEntity))
        logger.Debug("Entering PDFCreator.WriteOperationDetails2GaragePDF")
        Try
            Dim p As Paragraph

            Dim strVal As String
            Dim tbl As Table
            Dim tblCell As Cell
            Dim bl As Boolean = False
            doc.Add(New Paragraph(""))
            doc.Add(New Paragraph(""))
            p = New Paragraph(New Paragraph("Operation Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))

            doc.Add(p)
            doc.Add(New Paragraph(""))
            If Not (objOperations Is Nothing) Then
                If objOperations.Count > 0 Then
                    tbl = New Table(2, 30)
                    tbl.BorderWidth = 0
                    tbl.BorderColor = New Color(255, 255, 255) ' No color
                    tbl.Cellpadding = 0
                    tbl.Cellspacing = 0
                    tbl.DefaultCellBorder = 0



                    tblCell = New Cell("Applicant Name")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 0, 0)
                    tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).ApplicantName)
                    tblCell.Width = 130
                    tblCell.Border = 0
                    tbl.AddCell(tblCell, 0, 1)

                    tblCell = New Cell("Trade Name")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 1, 0)
                    tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).TradeName)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 1, 1)

                    tblCell = New Cell("Garaging Address")
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 2, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).GarageAddress)
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 2, 1)

                    tblCell = New Cell("City")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 3, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).City)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 3, 1)


                    tblCell = New Cell("County")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 4, 0)
                    tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).County)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 4, 1)

                    tblCell = New Cell("State")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 5, 0)
                    tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).State)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 5, 1)

                    tblCell = New Cell("Zip Code")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 6, 0)
                    tblCell = New Cell(CType(objQuoteData.Item(0), GarageQuote).ZIP)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 6, 1)

                    tblCell = New Cell("Type of Business")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 7, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).BusinessType)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 7, 1)





                    Select Case CType(objOperations.Item(0), GarageOperations).YrsExperience_NewVenture.ToString
                        Case "0"
                            strVal = "New Venture"
                        Case "1"
                            strVal = "1-3 Years"
                        Case "2"
                            strVal = "4-5 Years"
                        Case "3"
                            strVal = "6+ Years"
                        Case Else
                            strVal = ""
                    End Select

                    tblCell = New Cell("Years in  Business")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 8, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tblCell.Border = 0
                    tbl.AddCell(tblCell, 8, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).YrsInBusiness = 0, "", CType(objOperations.Item(0), GarageOperations).YrsInBusiness = 0)
                    tblCell = New Cell("Years of Experience")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 9, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).YrsInBusiness.ToString)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 9, 1)

                    tblCell = New Cell("Years Insured")
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 10, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).YearsInsured.ToString)
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 10, 1)

                    tblCell = New Cell("Operations of Insured")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 11, 0)
                    tblCell = New Cell(CType(CType(objOperations.Item(0), GarageOperations).InsuredOperations.Item(0), InsuredOperation).OperationDetails)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 11, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).SellAutoParts = 1, "Yes", "No")
                    tblCell = New Cell("Sell Auto parts New or Used")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 12, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 12, 1)


                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).SellPercentage <= 0, "", CType(objOperations.Item(0), GarageOperations).SellPercentage)
                    tblCell = New Cell("Annual receipts")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 13, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 13, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).OperateSalvageYard = 1, "Yes", "No")
                    tblCell = New Cell("Operate Salvage Yard")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 14, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 14, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).OperateOtherLocation = 1, "Yes", "No")
                    tblCell = New Cell("Any Garage Operations at Other Locations")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 15, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 15, 1)

                    tblCell = New Cell("If Yes, Explain")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 16, 0)
                    tblCell = New Cell(CType(CType(objOperations.Item(0), GarageOperations).OtherLocations.Item(0), OtherLocation).OperationLocation)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 16, 1)



                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).otherBusinessOperation = 1, "Yes", "No")
                    tblCell = New Cell("Any Other Business Operations on same premises owned by Insured")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 17, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tblCell.Border = 0
                    tbl.AddCell(tblCell, 17, 1)

                    tblCell = New Cell("If Yes, Explain reason")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 18, 0)
                    tblCell = New Cell(CType(CType(objOperations.Item(0), GarageOperations).OtherBusinesses.Item(0), OtherBusiness).OtherBusinessDetail)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 18, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).HasWrecker = 1, "Yes", "No")
                    tblCell = New Cell("Do you own a Wrecker")
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 19, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 5
                    tbl.AddCell(tblCell, 19, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).HasRollback = 1, "Yes", "No")
                    tblCell = New Cell("Do you own a Rollback")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 20, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 20, 1)

                    strVal = IIf(CType(objOperations.Item(0), GarageOperations).HasDollieOrTrailer = 1, "Yes", "No")
                    tblCell = New Cell("Do you own or use a Tow Bar or or Tow Dollie or Trailer")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 21, 0)
                    tblCell = New Cell(strVal)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 21, 1)

                    tblCell = New Cell("If Yes, Explain reason")
                    tblCell.Width = 30
                    tbl.AddCell(tblCell, 22, 0)
                    tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).DollieOrTrailerDetails)
                    tblCell.Width = 130
                    tbl.AddCell(tblCell, 22, 1)

                    If objPersons.Count > 0 Then

                        tblCell = New Cell("Owner & Spouse Name(s) & Age")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 23, 0)
                        tblCell = New Cell(CType(objPersons.Item(0), GaragePerson).NameAge)
                        tblCell.Width = 130
                        tbl.AddCell(tblCell, 23, 1)




                        tblCell = New Cell("Drivers Name(s) & Age")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 24, 0)
                        tblCell = New Cell(CType(objPersons.Item(0), GaragePerson).DriverNameAge)
                        tblCell.Width = 130
                        tblCell.Border = 0
                        tbl.AddCell(tblCell, 24, 1)

                        tblCell = New Cell("Employee Name(s) & Age")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 25, 0)
                        tblCell = New Cell(CType(objPersons.Item(0), GaragePerson).EmployeeNameAge)
                        tblCell.Width = 130
                        tbl.AddCell(tblCell, 25, 1)

                        tblCell = New Cell("Person Furnished Autos")
                        tblCell.Width = 5
                        tbl.AddCell(tblCell, 26, 0)
                        tblCell = New Cell(CType(objOperations.Item(0), GarageOperations).FurnishedAutoDetails)
                        tblCell.Width = 5
                        tbl.AddCell(tblCell, 26, 1)

                        strVal = IIf(CType(objPersons.Item(0), GaragePerson).IsChildHouseHold = 1, "Yes", "No")
                        tblCell = New Cell("Any Children in household")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 27, 0)
                        tblCell = New Cell(strVal)
                        tblCell.Width = 130
                        tbl.AddCell(tblCell, 27, 1)


                        tblCell = New Cell("If yes, need all ages")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 28, 0)
                        tblCell = New Cell(CType(objPersons.Item(0), GaragePerson).AllAges)
                        tblCell.Width = 130
                        tbl.AddCell(tblCell, 28, 1)

                        tblCell = New Cell("Comments")
                        tblCell.Width = 30
                        tbl.AddCell(tblCell, 29, 0)
                        tblCell = New Cell(CType(objPersons.Item(0), GaragePerson).Comments)
                        tblCell.Width = 130
                        tbl.AddCell(tblCell, 29, 1)


                    End If
                    doc.Add(tbl)
                End If
            End If


        Catch ex As Exception
            Throw ex

        End Try
        logger.Debug("Exiting PDFCreator.WriteOperationDetails2GaragePDF")
    End Sub

    Private Sub WriteInsuranceHistory2GaragePDF(ByRef doc As iTextSharp.text.Document, ByVal objInsuranceHistroy As GenericCollection(Of IEntity), ByVal objInsuranceLosses As GenericCollection(Of IEntity))
        logger.Debug("Entering PDFCreator.WriteInsuranceHistory2GaragePDF")
        Dim p As Paragraph
        Dim tbl As Table
        Dim tblcell As Cell
        Dim strVal As String
        Dim bl As Boolean = False
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Insurance History", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        doc.Add(p)
        doc.Add(New Paragraph(""))

        If Not (objInsuranceHistroy Is Nothing) Then
            If objInsuranceHistroy.Count > 0 Then
                tbl = New Table(2, 4)
                tbl.BorderWidth = 0
                tbl.BorderColor = New Color(255, 255, 255) ' No color
                tbl.Cellpadding = 0
                tbl.Cellspacing = 0
                tbl.DefaultCellBorder = 0

                strVal = IIf(CType(objInsuranceHistroy.Item(0), InsuranceHistory).IsPreviousPolicyCancelled = 1, "Yes", "No")

                tblcell = New Cell("Previous Policy Cancelled")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 0, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 0
                tbl.AddCell(tblcell, 0, 1)

                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).CancellationDetails = "" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objInsuranceHistroy.Item(0), InsuranceHistory).CancellationDetails
                End If

                tblcell = New Cell("If Yes, Details")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 1, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 0
                tbl.AddCell(tblcell, 1, 1)

                strVal = IIf(CType(objInsuranceHistroy.Item(0), InsuranceHistory).IsPreviousPolicyNotRenewed = 1, "Yes", "No")

                tblcell = New Cell("Previous Policy Not-Renewed")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 2, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 0

                tbl.AddCell(tblcell, 2, 1)

                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).NotRenewalDetails = "" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objInsuranceHistroy.Item(0), InsuranceHistory).NotRenewalDetails
                End If
                tblcell = New Cell("If Yes, Details")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 3, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 0

                tbl.AddCell(tblcell, 3, 1)

                doc.Add(tbl)
                tbl = New Table(5, 4)
                tbl.BorderWidth = 0
                tbl.BorderColor = New Color(255, 255, 255) ' No color
                tbl.Cellpadding = 1
                tbl.Cellspacing = 1
                tbl.DefaultCellBorder = 0
                If Not (objInsuranceLosses Is Nothing) Then
                    If objInsuranceLosses.Count > 0 Then
                        tblcell = New Cell("Loss History")
                        tblcell.Border = 0
                        tblcell.Colspan = 5
                        tblcell.HorizontalAlignment = 1 'center
                        tblcell.VerticalAlignment = 5 'middle
                        tblcell.Header = True
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 0, 0)

                        tblcell = New Cell("Term From")
                        tblcell.Width = 25
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 0)

                        tblcell = New Cell("Term To")
                        tblcell.Width = 25
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 1)

                        tblcell = New Cell("Carrier")
                        tblcell.Width = 35
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 2)

                        tblcell = New Cell("Amount Paid")
                        tblcell.Width = 25
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 3)

                        tblcell = New Cell("Details")
                        tblcell.Width = 130
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 4)


                        Dim itblRowCount As Integer = 2
                        Dim iCount As Integer
                        For iCount = 0 To objInsuranceLosses.Count - 1


                            tblcell = New Cell(CType(objInsuranceLosses.Item(iCount), InsuranceLossHistory).TermFrom.ToShortDateString)
                            tblcell.Width = 25
                            tbl.AddCell(tblcell, itblRowCount, 0)
                            tblcell = New Cell(CType(objInsuranceLosses.Item(iCount), InsuranceLossHistory).TermTo.ToShortDateString)
                            tblcell.Width = 25
                            tbl.AddCell(tblcell, itblRowCount, 1)
                            tblcell = New Cell(CType(objInsuranceLosses.Item(iCount), InsuranceLossHistory).Carrier)
                            tblcell.Width = 35
                            tbl.AddCell(tblcell, itblRowCount, 2)
                            tblcell = New Cell(CType(objInsuranceLosses.Item(iCount), InsuranceLossHistory).Amount.ToString)
                            tblcell.Width = 25
                            tbl.AddCell(tblcell, itblRowCount, 3)
                            tblcell = New Cell(CType(objInsuranceLosses.Item(iCount), InsuranceLossHistory).Details)
                            tblcell.Width = 130
                            tbl.AddCell(tblcell, itblRowCount, 4)
                            itblRowCount += 1

                        Next

                    Else
                        tblcell = New Cell("N/A")
                        tblcell.Border = 0
                        tblcell.Colspan = 5
                        tblcell.HorizontalAlignment = 1
                        tblcell.Border = 1
                        tbl.AddCell(tblcell, 1, 0)
                    End If
                    doc.Add(tbl)
                End If


            End If
        End If
        logger.Debug("Exiting PDFCreator.WriteInsuranceHistory2GaragePDF")
    End Sub

    Private Sub WriteCoverageDetails2GaragePDF(ByRef doc As iTextSharp.text.Document, ByVal objCoverages As GenericCollection(Of IEntity), ByVal objQuoteData As GenericCollection(Of IEntity))
        logger.Debug("Entering PDFCreator.WriteCoverageDetails2GaragePDF")
        Dim tbl As Table
        Dim tblcell As Cell
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Coverage Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        tbl = New Table(2, 25)
        tbl.BorderWidth = 0
        tbl.BorderColor = New Color(255, 255, 255) ' No color
        tbl.Cellpadding = 1
        tbl.Cellspacing = 1
        tbl.DefaultCellBorder = 0

        If Not (objCoverages Is Nothing) Then
            If objCoverages.Count > 0 Then


                tblcell = New Cell("General Liability")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 0, 0)
                If CType(objCoverages.Item(0), CoverageDetail).LiabiltyLimit = "Select One" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objCoverages.Item(0), CoverageDetail).LiabiltyLimit
                End If

                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 0
                tbl.AddCell(tblcell, 0, 1)

                tblcell = New Cell("Med Pay Limits")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 1, 0)

                If CType(objCoverages.Item(0), CoverageDetail).MedPayLimit = "Select One" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objCoverages.Item(0), CoverageDetail).MedPayLimit
                End If
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tbl.AddCell(tblcell, 1, 1)

                tblcell = New Cell("Radius of Operation")
                tblcell.Width = 5
                tbl.AddCell(tblcell, 2, 0)
                If CType(objCoverages.Item(0), CoverageDetail).OperationRadius = "Select One" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objCoverages.Item(0), CoverageDetail).OperationRadius
                End If
                tblcell = New Cell(strVal)
                tblcell.Width = 5
                tbl.AddCell(tblcell, 2, 1)

                tblcell = New Cell("Uninsured Motorist")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 3, 0)

                If CType(objCoverages.Item(0), CoverageDetail).Reject = "Select One" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objCoverages.Item(0), CoverageDetail).Reject
                End If
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tbl.AddCell(tblcell, 3, 1)





                tblcell = New Cell("If Uninsured Motorist is accepted then No. of Dealer Plates")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 4, 0)
                If CType(objCoverages.Item(0), CoverageDetail).Reject <> "Reject" Then
                    Dim strKey As String = ConfigurationManager.AppSettings("GarageCoverageKey").ToString

                    If strKey = "2" Then
                        ' for staging

                        Select Case Convert.ToInt32(CType(objCoverages.Item(0), CoverageDetail).NoofDealerPlates)
                            Case 39
                                strVal = "1"
                            Case 40
                                strVal = "2"
                            Case 41
                                strVal = "3"
                            Case 42
                                strVal = "4"
                            Case 43
                                strVal = "5"
                            Case 44
                                strVal = "6"
                            Case 45
                                strVal = "7"
                            Case 46
                                strVal = "8"
                            Case 47
                                strVal = "9"
                            Case 57
                                strVal = "10 Or more"
                        End Select
                    Else
                        ' for production
                        Select Case Convert.ToInt32(CType(objCoverages.Item(0), CoverageDetail).NoofDealerPlates)
                            Case 30
                                strVal = "1"
                            Case 31
                                strVal = "2"
                            Case 32
                                strVal = "3"
                            Case 33
                                strVal = "4"
                            Case 34
                                strVal = "5"
                            Case 35
                                strVal = "6"
                            Case 36
                                strVal = "7"
                            Case 37
                                strVal = "8"
                            Case 38
                                strVal = "9"
                            Case 39
                                strVal = "10 Or more"
                        End Select
                    End If




                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, 4, 1)
                Else
                    tblcell = New Cell("N\A")
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, 4, 1)
                End If

                Dim itblRowCount As Integer = 5

                If CType(objCoverages.Item(0), CoverageDetail).IsKeeperCoverage Then


                    tblcell = New Cell("Garage Keepers Coverage (Vehicles of others in the care, custody or control of the applicant)")
                    tblcell.Width = 30
                    tblcell.Colspan = 2
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    itblRowCount += 1

                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsLegalLiability = 1, "Yes", "No")
                    tblcell = New Cell("Legal Liability")
                    tblcell.Width = 30
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    tblcell = New Cell("Direct Primary")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsDirectPrimary = 1, "Yes", "No")
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    tblcell = New Cell("Total Value Per Lot")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(CType(objCoverages.Item(0), CoverageDetail).ValuePerLot.ToString)
                    tblcell.Width = 130
                    tblcell.Border = 0
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).Deductible = "Select One", "N\A", CType(objCoverages.Item(0), CoverageDetail).Deductible)
                    tblcell = New Cell("Deductible")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    tblcell = New Cell("Max Limit any 1-Unit")
                    tblcell.Width = 5
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(CType(objCoverages.Item(0), CoverageDetail).MaxLimitPerUnit.ToString)
                    tblcell.Width = 5
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1
                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsPerils = 1, "Yes", "No")
                    tblcell = New Cell("Specified Perils")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1


                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsCollision = 1, "Yes", "No")
                    tblcell = New Cell("Collision")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsComprehensive = 1, "Yes", "No")
                    tblcell = New Cell("Comprenhesive")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)

                    itblRowCount += 1
                End If

                If CType(objCoverages.Item(0), CoverageDetail).IsPhysicalCoverage Then




                    tblcell = New Cell("Physical Damage Coverage (All vehicles under title or bill of sale owned by the applicant)")
                    tblcell.Width = 30
                    tblcell.Colspan = 2
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    itblRowCount += 1



                    tblcell = New Cell("Total Value Per Lot")
                    tblcell.Width = 30
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(CType(objCoverages.Item(0), CoverageDetail).PhysicalValuePerLot.ToString)
                    tblcell.Width = 130
                    tblcell.Border = 1
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    tblcell = New Cell("Max Limit any 1-Unit")
                    tblcell.Width = 5
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(CType(objCoverages.Item(0), CoverageDetail).PhysicalMaxUnitPerLimit.ToString)
                    tblcell.Width = 5
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).PhysicalDeductible = "Select One", "N\A", CType(objCoverages.Item(0), CoverageDetail).PhysicalDeductible)
                    tblcell = New Cell("Deductible")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1


                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).PhysicalIsPerils = 1, "Yes", "No")
                    tblcell = New Cell("Specified Perils")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1


                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).PhysicalIsCollision = 1, "Yes", "No")
                    tblcell = New Cell("Collision")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)
                    itblRowCount += 1

                    strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).PhysicalIsComprehensive = 1, "Yes", "No")
                    tblcell = New Cell("Comprenhesive")
                    tblcell.Width = 30
                    tbl.AddCell(tblcell, itblRowCount, 0)
                    tblcell = New Cell(strVal)
                    tblcell.Width = 130
                    tbl.AddCell(tblcell, itblRowCount, 1)

                    itblRowCount += 1
                End If
                strVal = IIf(CType(objCoverages.Item(0), CoverageDetail).IsLotLightedNight = 1, "Yes", "No")
                tblcell = New Cell("Lot Lighted at Night")
                tblcell.Width = 30
                tblcell.Border = 1
                tbl.AddCell(tblcell, 21, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tblcell.Border = 1
                tbl.AddCell(tblcell, 21, 1)

                If CType(objCoverages.Item(0), CoverageDetail).IsLotChained = 1 Then
                    strVal = "Chained"
                ElseIf CType(objCoverages.Item(0), CoverageDetail).IsLotFenced = 1 Then
                    strVal = "Fenced"
                ElseIf CType(objCoverages.Item(0), CoverageDetail).IsLotOpen = 1 Then
                    strVal = "Open"
                Else
                    strVal = "N/A"
                End If

                tblcell = New Cell("Lot Perimeter")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 22, 0)
                tblcell = New Cell(strVal)
                tblcell.Width = 130
                tbl.AddCell(tblcell, 22, 1)

                tblcell = New Cell("Additional Notes")
                tblcell.Width = 30
                tbl.AddCell(tblcell, 23, 0)
                tblcell = New Cell(CType(objQuoteData.Item(0), GarageQuote).AdditionalNotes)
                tblcell.Width = 130
                tbl.AddCell(tblcell, 23, 1)
                doc.Add(tbl)
            End If
        End If
        logger.Debug("Exiting PDFCreator.WriteCoverageDetails2GaragePDF")
    End Sub

    Private Sub write2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objQuoteData As GenericCollection(Of IEntity), _
    ByVal objOperations As GenericCollection(Of IEntity), _
    ByVal objCoverages As GenericCollection(Of IEntity), _
    ByVal objInsuranceHistroy As GenericCollection(Of IEntity), _
    ByVal objVehicles As GenericCollection(Of IEntity), _
    ByVal objDrivers As GenericCollection(Of IEntity), _
    ByVal objAdditionalNotes As GenericCollection(Of IEntity), _
    ByVal filelst As System.Collections.Generic.List(Of String))
        logger.Debug("Entering PDFCreator.write2TransportationPDF")
        Try


            logger.Debug("Writing Agency Information...")
            WriteAgencyInfo2TransportationPDF(doc, objQuoteData)
            logger.Debug("Writing Operation Details...")
            WriteOperationDetails2TransportationPDF(doc, objOperations)
            logger.Debug("Writing Vehicle Details...")
            WriteVehicleDetails2TransportationPDF(doc, objVehicles)
            logger.Debug("Writing Driver details...")
            WriteDriverDetails2TransportationPDF(doc, objDrivers)
            logger.Debug("Writing Insurance History...")
            WriteInsuranceHistory2TransportationPDF(doc, objInsuranceHistroy)
            logger.Debug("Writing Coverage Details...")
            WriteCoverageDetails2TransportationPDF(doc, objCoverages)
            logger.Debug("Writing MVR Uploaded Files Details...")
            MVRFilesDetails2TransportationPDF(doc, filelst)
            logger.Debug("Writing Additional Notes...")
            WriteAddtionalNotes2TransportationPDF(doc, objAdditionalNotes)

            logger.Debug("Exiting PDFCreator.write2TransportationPDF")
        Catch ex As Exception
            logger.Error("Ëxception occured while writing to PDF : " & ex.Message)
            logger.Error(ex.StackTrace)
        End Try
    End Sub

    Private Sub MVRFilesDetails2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal filelst As System.Collections.Generic.List(Of String))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("MVR Uploaded Files", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (filelst Is Nothing) Then
            If filelst.Count > 0 Then
                For Each file As String In filelst
                    p = New Paragraph(file)
                    doc.Add(p)
                Next

            End If
        End If
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objQuoteData"></param>
    ''' <remarks></remarks>
    Private Sub WriteAgencyInfo2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objQuoteData As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Agency Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objQuoteData Is Nothing) Then
            If objQuoteData.Count > 0 Then

                p = New Paragraph("AgencyID                          : " & CType(objQuoteData.Item(0), GarageQuote).AgentID)
                doc.Add(p)
                p = New Paragraph("Agency Name                       : " & CType(objQuoteData.Item(0), GarageQuote).CreatedORModifiedBY)
                doc.Add(p)
                p = New Paragraph("Contact                           : " & CType(objQuoteData.Item(0), GarageQuote).Contact)
                doc.Add(p)
                p = New Paragraph("Phone                             : " & CType(objQuoteData.Item(0), GarageQuote).Phone & """")
                doc.Add(p)
                strVal = IIf(CType(objQuoteData.Item(0), GarageQuote).Email = "", CType(objQuoteData.Item(0), GarageQuote).Fax, CType(objQuoteData.Item(0), GarageQuote).Email)
                p = New Paragraph("Email/Fax                         : " & strVal)
                doc.Add(p)
            End If
        End If

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objOperations"></param>
    ''' <remarks></remarks>
    Private Sub WriteOperationDetails2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objOperations As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Operations Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objOperations Is Nothing) Then
            If objOperations.Count > 0 Then


                p = New Paragraph("ApplicantName                                    : " & CType(objOperations.Item(0), GarageOperations).ApplicantName)
                doc.Add(p)
                p = New Paragraph("BusinessName                                     : " & CType(objOperations.Item(0), GarageOperations).BusinessName)
                doc.Add(p)
                p = New Paragraph("Garaging Address                                 : " & CType(objOperations.Item(0), GarageOperations).GarageAddress)
                doc.Add(p)
                p = New Paragraph("City                                             : " & CType(objOperations.Item(0), GarageOperations).City)
                doc.Add(p)

                p = New Paragraph("County                                           : " & CType(objOperations.Item(0), GarageOperations).County)
                doc.Add(p)
                p = New Paragraph("State                                            : " & CType(objOperations.Item(0), GarageOperations).State)
                doc.Add(p)
                p = New Paragraph("ZipCode                                          : " & CType(objOperations.Item(0), GarageOperations).ZipCode)
                doc.Add(p)
                p = New Paragraph("Type of Business                                 : " & CType(objOperations.Item(0), GarageOperations).BusinessType)
                doc.Add(p)
                Select Case CType(objOperations.Item(0), GarageOperations).YrsInBusiness
                    Case 1
                        strVal = "New venture"
                    Case 2
                        strVal = "1-3 Years"
                    Case 3
                        strVal = "4-5 Years"
                    Case 4
                        strVal = "6+ Years"
                End Select
                p = New Paragraph("Years In Business                                : " & strVal)
                doc.Add(p)
                p = New Paragraph("Years Insured                                    : " & CType(objOperations.Item(0), GarageOperations).YearsInsured)
                doc.Add(p)
                p = New Paragraph("Operations of Insured                            : " & CType(objOperations.Item(0), GarageOperations).OperationInsured)
                doc.Add(p)
                p = New Paragraph("Number of Years insured has owned same type vehicles : " & CType(objOperations.Item(0), GarageOperations).YearsSameTypeVehicles)
                doc.Add(p)
                If CType(objOperations.Item(0), GarageOperations).IsFillingRequired = 1 Then
                    p = New Paragraph("Are any filings required                     : Yes")
                    doc.Add(p)
                    p = New Paragraph("Filings Details                              : " & CType(objOperations.Item(0), GarageOperations).FillingDetails)
                    doc.Add(p)
                Else
                    p = New Paragraph("Are any filings required                     : No")
                    doc.Add(p)
                    p = New Paragraph("Filings Details                              : N/A")
                    doc.Add(p)
                End If


                If CType(objOperations.Item(0), GarageOperations).AreAllVehiclesListed = 1 Then
                    p = New Paragraph("Are all owned and operated vehicles listed   : No")
                    doc.Add(p)
                    p = New Paragraph("Not listed Details                           : " & CType(objOperations.Item(0), GarageOperations).FillingDetails)
                    doc.Add(p)
                Else
                    p = New Paragraph("Are all owned and operated vehicles listed   : Yes")
                    doc.Add(p)
                    p = New Paragraph("Not listed Details                           : N/A")
                    doc.Add(p)
                End If

                p = New Paragraph("Radius of Operation                              : " & CType(objOperations.Item(0), GarageOperations).OperationRadius)
                doc.Add(p)
                p = New Paragraph("Commodities Hauled                               : " & CType(objOperations.Item(0), GarageOperations).CommoditiesHauled)
                doc.Add(p)
                p = New Paragraph("List Cities in which units are operated          : " & CType(objOperations.Item(0), GarageOperations).OperationCities)
                doc.Add(p)




            End If
        End If



    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objCoverages"></param>
    ''' <remarks></remarks>
    Private Sub WriteCoverageDetails2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objCoverages As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Coverage Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objCoverages Is Nothing) Then
            If objCoverages.Count > 0 Then

                'if cargo
                If CType(objCoverages.Item(0), CoverageDetail).IsCargo Then

                    strVal = "Yes"
                    p = New Paragraph("Cargo Only                      : " & strVal)
                    doc.Add(p)
                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl = "Select One" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl
                    End If
                    p = New Paragraph("Limits of Liability                      : " & strVal)
                    doc.Add(p)
                    strVal = ""

                    'If CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl = "Select One" Then

                    '    strVal = "N/A"

                    'Else
                    '    strVal = CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl
                    'End If


                    'p = New Paragraph("Uninsured Motorist                        : " & strVal)
                    'doc.Add(p)
                    'strVal = ""

                    'If Not (CType(objCoverages.Item(0), CoverageDetail).NoOfDealerTags Is Nothing) Then
                    '    p = New Paragraph("No.Of Dealer Tags                        : " & CType(objCoverages.Item(0), CoverageDetail).NoOfDealerTags)
                    '    doc.Add(p)
                    'End If
                    'If Not (CType(objCoverages.Item(0), CoverageDetail).PIP Is Nothing) Then
                    '    p = New Paragraph("PIP                       : " & CType(objCoverages.Item(0), CoverageDetail).PIP)
                    '    doc.Add(p)
                    'End If
                    'strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).DeductibleCargo = "Select One" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).DeductibleCargo
                    End If
                    p = New Paragraph("Deductible                      : " & strVal)
                    doc.Add(p)
                    'p = New Paragraph("Additional Info                       : " & CType(objCoverages.Item(0), CoverageDetail).AdditionalInfo)
                    'doc.Add(p)
                    'strVal = ""
                Else
                    ' if not cargo
                    strVal = "No"
                    p = New Paragraph("Cargo Only                      : " & strVal)
                    doc.Add(p)
                    strVal = ""


                    If CType(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl = "Select One" Then
                        If CType(objCoverages.Item(0), CoverageDetail).LiabilityLimit_Split <> "Select One" Then
                            strVal = "SPLIT  -- " & CType(objCoverages.Item(0), CoverageDetail).LiabilityLimit_Split
                        Else
                            strVal = "N/A"
                        End If
                    Else
                        strVal = "CSL  -- " & CType(objCoverages.Item(0), CoverageDetail).LibilityLimit_Csl
                    End If



                    p = New Paragraph("Limits of Liability                      : " & strVal)
                    doc.Add(p)
                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl = "Select One" Then
                        If CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Split <> "Select One" Then
                            strVal = "SPLIT  -- " & CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Split
                        Else
                            strVal = "N/A"
                        End If
                    Else
                        strVal = "CSL  -- " & CType(objCoverages.Item(0), CoverageDetail).UnInsuredMotorist_Csl
                    End If


                    p = New Paragraph("Uninsured Motorist                        : " & strVal)
                    doc.Add(p)
                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).MedPayLimit = "Select One" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).MedPayLimit
                    End If

                    p = New Paragraph("Medical Payments                           : " & strVal)
                    doc.Add(p)

                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).IsHired = 1 Then
                        strVal = "Yes"
                    Else
                        strVal = "No"
                    End If
                    p = New Paragraph("Hired                                       : " & strVal)
                    doc.Add(p)
                    If CType(objCoverages.Item(0), CoverageDetail).HiredDetails = "" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).HiredDetails
                    End If
                    p = New Paragraph("Hired Details                                : " & strVal)
                    doc.Add(p)

                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).IsNonOwned = 1 Then
                        strVal = "Yes"
                    Else
                        strVal = "No"
                    End If
                    p = New Paragraph("Non Owned                                     : " & strVal)
                    doc.Add(p)
                    If CType(objCoverages.Item(0), CoverageDetail).NonOwnedDetails = "" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).NonOwnedDetails
                    End If
                    p = New Paragraph("Non Owned Details                             : " & strVal)
                    doc.Add(p)


                    p = New Paragraph("Motor truck Cargo/On-Hook                     : " & CType(objCoverages.Item(0), CoverageDetail).TruckCargoDetails)
                    doc.Add(p)

                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).Deductible = "Select One" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).Deductible
                    End If
                    p = New Paragraph("Deductible                                     : " & strVal)
                    doc.Add(p)

                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).IsReeferBreaking = 1 Then
                        strVal = "Yes"
                    Else
                        strVal = "No"
                    End If
                    p = New Paragraph("Hired                                           : " & strVal)
                    doc.Add(p)
                    If CType(objCoverages.Item(0), CoverageDetail).ReeferBreaking = "" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).ReeferBreaking
                    End If
                    p = New Paragraph("Reefer Breakdown                                 : " & strVal)
                    doc.Add(p)

                    strVal = ""
                    If CType(objCoverages.Item(0), CoverageDetail).ISAddtnlInsured = 1 Then
                        strVal = "Yes"
                    Else
                        strVal = "No"
                    End If
                    p = New Paragraph("Additional Insured                               : " & strVal)
                    doc.Add(p)
                    If CType(objCoverages.Item(0), CoverageDetail).AddtnlInsuerdDetails = "" Then
                        strVal = "N/A"
                    Else
                        strVal = CType(objCoverages.Item(0), CoverageDetail).AddtnlInsuerdDetails
                    End If
                    p = New Paragraph("Additional Insured Details                       : " & strVal)
                    doc.Add(p)
                End If


            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objInsuranceHistroy"></param>
    ''' <remarks></remarks>
    Private Sub WriteInsuranceHistory2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objInsuranceHistroy As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim tbl As Table
        Dim cellText As Cell
        Dim strVal As String
        Dim bl As Boolean = False
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Insurance History", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objInsuranceHistroy Is Nothing) Then
            If objInsuranceHistroy.Count > 0 Then

                strVal = ""
                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).IsPreviousPolicyCancelled = 1 Then
                    strVal = "Yes"
                Else
                    strVal = "No"
                End If
                p = New Paragraph("Previous Policy Cancelled                    : " & strVal)
                doc.Add(p)
                strVal = ""
                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).CancellationDetails = "" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objInsuranceHistroy.Item(0), InsuranceHistory).CancellationDetails
                End If
                p = New Paragraph("Details                                      : " & strVal)
                doc.Add(p)

                strVal = ""
                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).IsPreviousPolicyNotRenewed = 1 Then
                    strVal = "Yes"
                Else
                    strVal = "No"
                End If
                p = New Paragraph("Previous Policy Not-Renewed                    : " & strVal)
                doc.Add(p)
                strVal = ""
                If CType(objInsuranceHistroy.Item(0), InsuranceHistory).NotRenewalDetails = "" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objInsuranceHistroy.Item(0), InsuranceHistory).NotRenewalDetails
                End If
                p = New Paragraph("Details                                      : " & strVal)
                doc.Add(p)


                'Loss History
                p = New Paragraph(New Paragraph("Prior Coverage & LossHistory", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
                doc.Add(p)
                Dim iCount As Integer


                Dim objinsurhist As InsuranceLossHistory
                Dim objinsurlosshist As InsuranceHistory
                objinsurlosshist = objInsuranceHistroy.Item(0)
                'objinsurlosshist.InsuranceLossHIstory.Count



                If Not IsNothing(CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory) Then

                    tbl = New Table(6, CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory.Count + 1)

                    cellText = New Cell("S.No")
                    cellText.Width = 5
                    tbl.AddCell(cellText, 0, 0)
                    cellText = New Cell("Term From")
                    cellText.Width = 15
                    tbl.AddCell(cellText, 0, 1)
                    cellText = New Cell("Term to")
                    cellText.Width = 10
                    tbl.AddCell(cellText, 0, 2)
                    cellText = New Cell("Carrier")
                    cellText.Width = 5
                    tbl.AddCell(cellText, 0, 3)
                    cellText = New Cell("Amount Paid")
                    cellText.Width = 10
                    tbl.AddCell(cellText, 0, 4)
                    cellText = New Cell("Detail")
                    cellText.Width = 20
                    tbl.AddCell(cellText, 0, 5)

                    'Dim objLossHistory As InsuranceLossHistory = CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory

                    If CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory.Count >= 1 Then

                        'For iCount = 0 To CType(objInsuranceHistroy.Item(0), InsuranceHistory).InsuranceLossHIstory.Count - 1
                        '    cellText = New Cell((iCount + 1).ToString)
                        '    cellText.Width = 5
                        '    tbl.AddCell(cellText, iCount + 1, 0)
                        '    cellText = New Cell(CType(CType(objInsuranceHistroy.Item(iCount), InsuranceHistory).InsuranceLossHIstory.Item(iCount), InsuranceLossHistory).TermFrom.ToShortDateString)
                        '    cellText.Width = 15
                        '    tbl.AddCell(cellText, iCount + 1, 1)
                        '    cellText = New Cell(CType(CType(objInsuranceHistroy.Item(iCount), InsuranceHistory).InsuranceLossHIstory.Item(iCount), InsuranceLossHistory).TermTo.ToShortDateString)
                        '    cellText.Width = 10
                        '    tbl.AddCell(cellText, iCount + 1, 2)
                        '    cellText = New Cell(CType(CType(objInsuranceHistroy.Item(iCount), InsuranceHistory).InsuranceLossHIstory.Item(iCount), InsuranceLossHistory).Carrier)
                        '    cellText.Width = 5
                        '    tbl.AddCell(cellText, iCount + 1, 3)
                        '    cellText = New Cell(CType(CType(objInsuranceHistroy.Item(iCount), InsuranceHistory).InsuranceLossHIstory.Item(iCount), InsuranceLossHistory).Amount.ToString)
                        '    cellText.Width = 10
                        '    tbl.AddCell(cellText, iCount + 1, 4)
                        '    cellText = New Cell(CType(CType(objInsuranceHistroy.Item(iCount), InsuranceHistory).InsuranceLossHIstory.Item(iCount), InsuranceLossHistory).Details)
                        '    cellText.Width = 20
                        '    tbl.AddCell(cellText, iCount + 1, 5)

                        'Next


                        For iCount = 0 To objinsurlosshist.InsuranceLossHIstory.Count - 1

                            cellText = New Cell((iCount + 1).ToString)
                            cellText.Width = 5
                            tbl.AddCell(cellText, iCount + 1, 0)
                            cellText = New Cell(objinsurlosshist.InsuranceLossHIstory.Item(iCount).TermFrom.ToShortDateString)
                            cellText.Width = 15
                            tbl.AddCell(cellText, iCount + 1, 1)
                            cellText = New Cell(objinsurlosshist.InsuranceLossHIstory.Item(iCount).TermTo.ToShortDateString)
                            cellText.Width = 10
                            tbl.AddCell(cellText, iCount + 1, 2)
                            cellText = New Cell(objinsurlosshist.InsuranceLossHIstory.Item(iCount).Carrier)
                            cellText.Width = 5
                            tbl.AddCell(cellText, iCount + 1, 3)
                            cellText = New Cell(objinsurlosshist.InsuranceLossHIstory.Item(iCount).Amount.ToString)
                            cellText.Width = 10
                            tbl.AddCell(cellText, iCount + 1, 4)
                            cellText = New Cell(objinsurlosshist.InsuranceLossHIstory.Item(iCount).Details)
                            cellText.Width = 20
                            tbl.AddCell(cellText, iCount + 1, 5)

                        Next
                    End If
                    doc.Add(tbl)
                Else
                    p = New Paragraph("N/A")
                    doc.Add(p)

                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objDrivers"></param>
    ''' <remarks></remarks>
    Private Sub WriteDriverDetails2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objDrivers As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim tbl As Table
        Dim cellText As Cell
        Dim strTicket As String
        Dim strVal As String = ""
        Dim strDeductible As String = ""
        Dim bl As Boolean = False
        Dim iCount As Integer
        Dim iTicketCount As Integer
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Driver Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objDrivers Is Nothing) Then
            If objDrivers.Count > 0 Then
                tbl = New Table(6, objDrivers.Count + 1)

                cellText = New Cell("S.No")
                cellText.Width = 5
                tbl.AddCell(cellText, 0, 0)
                cellText = New Cell("Name")
                cellText.Width = 15
                tbl.AddCell(cellText, 0, 1)
                cellText = New Cell("Date of Birth")
                cellText.Width = 10
                tbl.AddCell(cellText, 0, 2)
                cellText = New Cell("Years of Experience")
                cellText.Width = 5
                tbl.AddCell(cellText, 0, 3)
                cellText = New Cell("Hire Date")
                cellText.Width = 10
                tbl.AddCell(cellText, 0, 4)
                cellText = New Cell("Accident/Tickets")
                cellText.Width = 20
                tbl.AddCell(cellText, 0, 5)


                ''p = New Paragraph("S.NO" & Strings.Space(2) & "Name" & Strings.Space(4) & "Date of Birth" & Strings.Space(10) & "Years of " + Strings.Space(10) & "HireDate" & Strings.Space(10) & "List of Accident/Tickets")
                ''doc.Add(p)
                For iCount = 0 To objDrivers.Count - 1

                    cellText = New Cell((iCount + 1).ToString)
                    cellText.Width = 5
                    tbl.AddCell(cellText, iCount + 1, 0)
                    cellText = New Cell(CType(objDrivers.Item(iCount), Driver).Name)
                    cellText.Width = 15
                    tbl.AddCell(cellText, iCount + 1, 1)
                    cellText = New Cell(CType(objDrivers.Item(iCount), Driver).DOB.ToShortDateString)
                    cellText.Width = 10
                    tbl.AddCell(cellText, iCount + 1, 2)
                    cellText = New Cell(CType(objDrivers.Item(iCount), Driver).YearsExperience.ToString)
                    cellText.Width = 5
                    tbl.AddCell(cellText, iCount + 1, 3)
                    If CType(objDrivers.Item(iCount), Driver).HireDate.ToShortDateString = "1/1/1900" Then
                        cellText = New Cell("") 'New Cell(CType(objDrivers.Item(iCount), Driver).HireDate.ToShortDateString)
                        cellText.Width = 10
                        tbl.AddCell(cellText, iCount + 1, 4)
                    Else
                        cellText = New Cell(CType(objDrivers.Item(iCount), Driver).HireDate.ToShortDateString)
                        cellText.Width = 10
                        tbl.AddCell(cellText, iCount + 1, 4)
                    End If

                    strTicket = ""
                    If Not (CType(objDrivers.Item(iCount), Driver).DrverTickets Is Nothing) Then

                        If CType(objDrivers.Item(iCount), Driver).DrverTickets.Count > 0 Then
                            For iTicketCount = 0 To CType(objDrivers.Item(iCount), Driver).DrverTickets.Count - 1
                                strTicket += CType(CType(objDrivers.Item(iCount), Driver).DrverTickets.Item(iTicketCount), DriverTicket).TicketDetails & vbCrLf
                            Next
                        End If
                    End If
                    cellText = New Cell(strTicket)
                    cellText.Width = 20
                    tbl.AddCell(cellText, iCount + 1, 5)

                    'strDeductible = IIf(CType(objDrivers.Item(0), Vehicle).Deductible = "Select One", "", CType(objDrivers.Item(0), Vehicle).Deductible)
                    'strVal = IIf(CType(objDrivers.Item(0), Vehicle).StatedValue = "", "", CType(objDrivers.Item(0), Vehicle).StatedValue)
                    'p = New Paragraph((iCount + 1).ToString + Strings.Space(2) & CType(objDrivers.Item(0), Vehicle).Year & Strings.Space(4) & CType(objDrivers.Item(0), Vehicle).Make & Strings.Space(10) & CType(objDrivers.Item(0), Vehicle).GVW & Strings.Space(10) & CType(objDrivers.Item(0), Vehicle).VehicleType & Strings.Space(10) & strVal & Strings.Space(6) & strDeductible)
                    'doc.Add(p)

                Next
                doc.Add(tbl)
            Else
                p = New Paragraph("N/A")
                doc.Add(p)
            End If
        End If



    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objVehicles"></param>
    ''' <remarks></remarks>
    Private Sub WriteVehicleDetails2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objVehicles As GenericCollection(Of IEntity))
        'Dim p As Paragraph
        'Dim strVal As String
        'Dim strDeductible As String
        'Dim bl As Boolean = False
        'Dim iCount As Integer
        ' ''Dim objIEntity As IEntity
        ' ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        'doc.Add(New Paragraph(""))
        'doc.Add(New Paragraph(""))
        'p = New Paragraph(New Paragraph("Vehicle Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        ''p.Alignment = 1
        'doc.Add(p)
        'doc.Add(New Paragraph(""))
        'If Not (objVehicles Is Nothing) Then
        '    If objVehicles.Count > 0 Then
        '        p = New Paragraph("S.NO" & Strings.Space(2) & "Year" & Strings.Space(4) & "Make" & Strings.Space(10) & "GVW" + Strings.Space(10) & "Type" & Strings.Space(10) & "StatedValue" & Strings.Space(6) & " Deductible")
        '        doc.Add(p)
        '        For iCount = 0 To objVehicles.Count - 1
        '            strVal = ""
        '            strVal = ((iCount + 1).ToString + Strings.Space(10)).ToString.Substring(0, 6)
        '            strVal &= (CType(objVehicles.Item(iCount), Vehicle).Year & Strings.Space(10)).ToString.Substring(0, 8)
        '            strVal &= (CType(objVehicles.Item(iCount), Vehicle).Make & Strings.Space(15)).ToString.Substring(0, 14)
        '            strVal &= (CType(objVehicles.Item(iCount), Vehicle).GVW & Strings.Space(15)).ToString.Substring(0, 14)
        '            strVal &= (CType(objVehicles.Item(iCount), Vehicle).VehicleType & Strings.Space(15)).ToString.Substring(0, 14)
        '            strVal &= IIf(CType(objVehicles.Item(iCount), Vehicle).StatedValue = "", "", CType(objVehicles.Item(iCount), Vehicle).StatedValue)
        '            strVal &= IIf(CType(objVehicles.Item(iCount), Vehicle).Deductible = "Select One", "", CType(objVehicles.Item(iCount), Vehicle).Deductible)

        '            p = New Paragraph(strVal)
        '            doc.Add(p)
        '        Next
        '    Else
        '        p = New Paragraph("N/A")
        '        doc.Add(p)
        '    End If
        'End If

        Dim p As Paragraph
        Dim tbl As Table
        Dim cellText As Cell
        Dim strTicket As String = ""
        Dim strVal As String
        Dim strDeductible As String
        Dim bl As Boolean = False
        Dim iCount As Integer
        Dim iTicketCount As Integer
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Vehicle Details", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objVehicles Is Nothing) Then
            If objVehicles.Count > 0 Then
                tbl = New Table(7, objVehicles.Count + 1)

                cellText = New Cell("S.No")
                cellText.Width = 5
                tbl.AddCell(cellText, 0, 0)
                cellText = New Cell("Year")
                cellText.Width = 15
                tbl.AddCell(cellText, 0, 1)
                cellText = New Cell("Make")
                cellText.Width = 10
                tbl.AddCell(cellText, 0, 2)
                cellText = New Cell("GVW")
                cellText.Width = 5
                tbl.AddCell(cellText, 0, 3)
                cellText = New Cell("Type")
                cellText.Width = 10
                tbl.AddCell(cellText, 0, 4)
                cellText = New Cell("StatedValue")
                cellText.Width = 20
                tbl.AddCell(cellText, 0, 5)
                cellText = New Cell("Deductible")
                cellText.Width = 20
                tbl.AddCell(cellText, 0, 6)

                For iCount = 0 To objVehicles.Count - 1

                    cellText = New Cell((iCount + 1).ToString)
                    cellText.Width = 5
                    tbl.AddCell(cellText, iCount + 1, 0)
                    cellText = New Cell(CType(objVehicles.Item(iCount), Vehicle).Year.ToString)
                    cellText.Width = 15
                    tbl.AddCell(cellText, iCount + 1, 1)
                    cellText = New Cell(CType(objVehicles.Item(iCount), Vehicle).Make)
                    cellText.Width = 10
                    tbl.AddCell(cellText, iCount + 1, 2)
                    cellText = New Cell(CType(objVehicles.Item(iCount), Vehicle).GVW)
                    cellText.Width = 5
                    tbl.AddCell(cellText, iCount + 1, 3)
                    cellText = New Cell(CType(objVehicles.Item(iCount), Vehicle).VehicleType)
                    cellText.Width = 10
                    tbl.AddCell(cellText, iCount + 1, 4)
                    strVal = IIf(CType(objVehicles.Item(iCount), Vehicle).StatedValue = "", "", CType(objVehicles.Item(iCount), Vehicle).StatedValue)
                    strDeductible = IIf(CType(objVehicles.Item(iCount), Vehicle).Deductible = "Select One", "", CType(objVehicles.Item(iCount), Vehicle).Deductible)

                    cellText = New Cell(strVal)
                    cellText.Width = 20
                    tbl.AddCell(cellText, iCount + 1, 5)
                    cellText = New Cell(strDeductible)
                    cellText.Width = 20
                    tbl.AddCell(cellText, iCount + 1, 6)

                Next
                doc.Add(tbl)
            Else
                p = New Paragraph("N/A")
                doc.Add(p)
            End If
        End If





    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="objAdditionalNotes"></param>
    ''' <remarks></remarks>
    Private Sub WriteAddtionalNotes2TransportationPDF(ByRef doc As iTextSharp.text.Document, ByVal objAdditionalNotes As GenericCollection(Of IEntity))
        Dim p As Paragraph
        Dim strVal As String
        Dim bl As Boolean = False
        ''Dim objIEntity As IEntity
        ''objIEntity = CType(objOperations.Item(0), GarageOperations)
        doc.Add(New Paragraph(""))
        doc.Add(New Paragraph(""))
        p = New Paragraph(New Paragraph("Additional Notes", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, iTextSharp.text.Color.RED)))
        'p.Alignment = 1
        doc.Add(p)
        doc.Add(New Paragraph(""))
        If Not (objAdditionalNotes Is Nothing) Then
            If objAdditionalNotes.Count > 0 Then

                strVal = ""
                If CType(objAdditionalNotes.Item(0), AdditionNotes).AdditionalNotes = "" Then
                    strVal = "N/A"
                Else
                    strVal = CType(objAdditionalNotes.Item(0), AdditionNotes).AdditionalNotes
                End If

                p = New Paragraph("Additional Notes :          " & strVal)
                doc.Add(p)

            End If
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Private Sub WriteGOObjectValues2Pdf(ByRef doc As iTextSharp.text.Document, ByVal obj As GarageOperations)
        Try
            doc.Add(New Paragraph("Operation Details:       " & obj.InsuredOperations.Item(0).OperationDetails))
            doc.Add(New Paragraph("OtherBusiness Details:       " & obj.OtherBusinesses.Item(0).OtherBusinessDetail))
            doc.Add(New Paragraph("OtherLocation Details:       " & obj.OtherLocations.Item(0).OperationLocation))
        Catch ex As Exception
            logger.Error("GarageQuoteSheet Exception: " & ex.Message)
        End Try
    End Sub
    Private Sub WriteGOObjectValues2TransportationPdf(ByRef doc As iTextSharp.text.Document, ByVal obj As GarageOperations)
        Try
            doc.Add(New Paragraph("Operation Details:       " & obj.InsuredOperations.Item(0).OperationDetails))
            doc.Add(New Paragraph("OtherBusiness Details:       " & obj.OtherBusinesses.Item(0).OtherBusinessDetail))
            doc.Add(New Paragraph("OtherLocation Details:       " & obj.OtherLocations.Item(0).OperationLocation))
        Catch ex As Exception
            logger.Error("GarageQuoteSheet Exception: " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' For Commercial Transportation Quote
    ''' </summary>
    ''' <param name="objQuoteData"></param>
    ''' <param name="objOperations"></param>
    ''' <param name="objCoverages"></param>
    ''' <param name="objInsuranceHistroy"></param>
    ''' <param name="objVehicles"></param>
    ''' <param name="objDrivers"></param>
    ''' <param name="objAdditionalNotes"></param>
    ''' <param name="strQuoteID"></param>
    ''' <param name="strQuoteType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreatePDF(ByVal objQuoteData As GenericCollection(Of IEntity), _
    ByVal objOperations As GenericCollection(Of IEntity), _
    ByVal objCoverages As GenericCollection(Of IEntity), _
    ByVal objInsuranceHistroy As GenericCollection(Of IEntity), _
    ByVal objVehicles As GenericCollection(Of IEntity), _
    ByVal objDrivers As GenericCollection(Of IEntity), _
    ByVal objAdditionalNotes As GenericCollection(Of IEntity), _
   ByVal strQuoteID As String, _
    ByVal strQuoteType As String, ByVal filelst As System.Collections.Generic.List(Of String)) As Boolean
        logger.Debug("Entering PDFCreater.CreatePDF")
        Try
            Dim objQuote As New GarageQuoteDataModel
            Dim objQuoteInfo As IEntity
            Dim strQuoteNbr As String
            objQuoteInfo = objQuote.GetQuoteDetailsByQuoteId(strQuoteID, strQuoteType)
            strQuoteNbr = CType(objQuoteInfo, GarageQuote).GarageQuoteNumber
            If Not CreateTransportationPDF(objQuoteData, objOperations, objCoverages, objInsuranceHistroy, objVehicles, objDrivers, objAdditionalNotes, strQuoteNbr, filelst) Then
                logger.Error("Error in Creating PDF")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception

            logger.Error("Exception in PDFCreater.CreatePDF: " & ex.Message)
            logger.Error(ex.StackTrace)
            Return False
        End Try
        logger.Debug("Exiting PDFCreater.CreatePDF")
    End Function
    Public Sub New()
        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
    End Sub
End Class
