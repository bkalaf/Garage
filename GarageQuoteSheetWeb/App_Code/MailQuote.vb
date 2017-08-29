Imports Microsoft.VisualBasic
Imports System.Web.Mail
Imports GarageQuoteSheetDLL
Imports System.Data
Imports System.Data.SqlClient
Imports log4net
Imports XmlUtils
Imports System
Imports System.IO
Imports System.Collections
Imports System.Web


Public Class MailQuote

    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote = "CommQuote"
    Private Const COMP_GQS_SearchQuote = "SearchQuotes"
    Private Const xmlCONTEXT = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Dim objService As New SIUService.ServiceSoapClient()

    Public Sub mail2Agent(ByVal strQuoteId As String, ByVal strmailid As String, ByVal filelst As System.Collections.Generic.List(Of String))
        logger.Debug("Entering MailQuote.mail2Agent")
        Dim strQuoteNumber As String
        Dim strAplicantname As String
        Dim strAgentLoginID As String
        Dim strUWEmail As String

        Try

            Dim objQuote As New GarageQuoteDataModel
            Dim objQuoteData As IEntity
            xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)

            objQuoteData = objQuote.GetQuoteDetailsByQuoteId(strQuoteId, "2")
            strQuoteNumber = CType(objQuoteData, GarageQuote).GarageQuoteNumber
            strAplicantname = CType(objQuoteData, GarageQuote).ApplicantName
            strAgentLoginID = CType(objQuoteData, GarageQuote).AgentID
            strUWEmail = CType(objQuoteData, GarageQuote).UnderwriterEmail
            Dim strBccemailID As String = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPBCC") '"kstephenson@siuins.com" 'xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPBCC")
            Dim blnInternal As Boolean = objService.isUnderwriter(IpAddress)
            If CType(objQuoteData, GarageQuote).Fax = "" Then
                xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
                Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
                Message.To = strmailid 'CType(objQuoteData, GarageQuote).Email ' txtFaxNo.Text

                If strUWEmail <> "" Then

                    If blnInternal Then
                        Message.Bcc = strBccemailID & ", " & strUWEmail 'strUWEmail commented 9 sep10 ' no mail to Kieth  [ bcc to keith mentioned in config file]
                    Else
                        Message.Bcc = strBccemailID & ", " & strUWEmail '"kstephenson@siuins.com"
                    End If

                Else
                    If Not blnInternal Then
                        Message.Bcc = strBccemailID '"kstephenson@siuins.com"
                    End If

                End If

                logger.Debug("BCC email id is : " & Message.Bcc.ToString)
                Message.From = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPFrom")
                Message.Subject = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPSubject")
                Message.Body = "Commerical Transportation Quote Generated" & vbCrLf & "QuoteNumber is: " & strQuoteNumber & vbCrLf _
                & "Thank you for your submission, Someone in our transportation division will be contacting you " & vbCrLf _
                 & "within 24 to 48 hours. Please note that MVRs must be provided to SIU to receive a ``For Hire Trucking`` quote. Should you have any questions, please feel free to give us a call. " & vbCrLf _
                 & vbCrLf & "Thank you again for choosing SIU."


                'If blnInternal Then
                If HttpContext.Current.Session("CommercialAttachmentFileName") <> "" Then
                    Message.Attachments.Add(New MailAttachment(HttpContext.Current.Session("CommercialAttachmentFileName").ToString))
                End If
                'End If
                If (filelst.Count > 0) Then
                    For Each File As String In filelst
                        Message.Attachments.Add(New MailAttachment(xmlConfig.GetComponentProperty("ImageRight", "IDXFilePath") & File))
                    Next
                End If

                Try
                    SmtpMail.SmtpServer = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPServer")
                    SmtpMail.Send(Message)

                    logger.Debug("Mail has been sent from : " & Message.From.ToString & " To : " & Message.To.ToString & " BCC  : " & Message.Bcc.ToString)

                Catch ex As System.Web.HttpException
                    logger.Error("Exception occurred while sending mail to agent :", ex)
                    logger.Error("Exception Details :" & ex.StackTrace)
                End Try
            End If
        Catch e As System.Exception
            logger.Error("Exception occurred while Savinsubmitting Quote", e)
        End Try
        logger.Debug("Exiting MailQuote.mail2Agent")
    End Sub
    Public Sub Sendmail(ByVal From As String, ByVal tomail As String, ByVal subject As String, ByVal body As String, ByVal ArrayAsAttachment As ArrayList)

        Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
        Message.To = tomail
        Message.From = From
        Message.Subject = subject
        Message.Body = body
        Dim intAttach As Integer = 0
        For intAttach = 0 To ArrayAsAttachment.Count - 1
            Message.Attachments.Add(New MailAttachment(ArrayAsAttachment(intAttach).ToString()))
        Next

        xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)

        Try
            SmtpMail.SmtpServer = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPServer")
            SmtpMail.Send(Message)
        Catch ex As System.Web.HttpException
            logger.Error("Exception occurred while sending mail to agent :", ex)
            logger.Error("Exception Details :" & ex.StackTrace)
        End Try

    End Sub

    Public Function IpAddress() As String
        Dim strIpAddress As String
        strIpAddress = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If strIpAddress Is Nothing Then
            strIpAddress = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
        End If
        Return strIpAddress
    End Function






    Public Sub mail2AgentwhenFax(ByVal strQuoteId As String)
        logger.Debug("Entering MailQuote.mail2Agent")
        Dim strQuoteNumber As String
        Dim strAplicantname As String
        Dim strAgentLoginID As String

        Try

            Dim objQuote As New GarageQuoteDataModel
            Dim objQuoteData As IEntity
            objQuoteData = objQuote.GetQuoteDetailsByQuoteId(strQuoteId, "2")
            strQuoteNumber = CType(objQuoteData, GarageQuote).GarageQuoteNumber
            strAplicantname = CType(objQuoteData, GarageQuote).ApplicantName
            strAgentLoginID = CType(objQuoteData, GarageQuote).AgentID
            If CType(objQuoteData, GarageQuote).Fax = "" Then
                xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
                Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
                Message.To = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPBCC")
                Message.From = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPFrom")
                Message.Subject = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPSubject")
                Message.Body = "Commerical Transportation Quote Generated" & vbCrLf & "QuoteNumber is: " & strQuoteId & vbCrLf _
                & "Thank you for your submission, Someone in our transportation division will be contacting you " & vbCrLf _
                 & "within 24 to 48 hours. Should you have any questions, please feel free to give us a call. " & vbCrLf _
                 & vbCrLf & "Thank you again for choosing SIU." & vbCrLf _
                & vbCrLf & "For this quote fax has been sent to the agent."


                If objService.isUnderwriter(IpAddress) = True Then
                    If HttpContext.Current.Session("CommercialAttachmentFileName") <> "" Then
                        Message.Attachments.Add(New MailAttachment(HttpContext.Current.Session("CommercialAttachmentFileName").ToString))
                    End If
                End If


                Try
                    SmtpMail.SmtpServer = xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "SMTPServer")
                    SmtpMail.Send(Message)
                Catch ex As System.Web.HttpException
                    logger.Error("Exception occurred while sending mail to agent :", ex)
                    logger.Error("Exception Details :" & ex.StackTrace)
                End Try
            End If
        Catch e As System.Exception

        End Try
        logger.Debug("Exiting MailQuote.mail2Agent")
    End Sub
End Class
