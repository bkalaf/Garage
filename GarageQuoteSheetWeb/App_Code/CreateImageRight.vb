Imports Microsoft.VisualBasic
Imports GarageQuoteSheetDLL
Imports System
Imports System.IO
Imports System.Text

Public Class CreateImageRight

    Private xmlConfig As XmlUtils.XmlConfig
    Private Const PROPERTIES As String = "GarageQuoteSheetXML.xml"
    Private Const COMP_GQS_CreateQuote As String = "CreateQuote"
    Private Const COMP_GQS_SearchQuote As String = "SearchQuotes"
    Private Const xmlCONTEXT As String = "GarageQuoteSheet"
    Private Shared logger As log4net.ILog = _
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
    Public Function CreateIDXfile(ByVal strQuoteID As String, ByVal strQuoteType As String, ByVal filelst As System.Collections.Generic.List(Of String)) As Boolean
        logger.Debug("Entering CreateImageright.CreateIDXFile")
        Dim strQuoteNumber As String
        Dim strAplicantname As String
        Dim strAgentLoginID As String
        Try


            Dim objQuote As New GarageQuoteDataModel
            Dim objQuoteData As IEntity
            objQuoteData = objQuote.GetQuoteDetailsByQuoteId(strQuoteID, strQuoteType)
            strQuoteNumber = CType(objQuoteData, GarageQuote).GarageQuoteNumber
            strAplicantname = CType(objQuoteData, GarageQuote).ApplicantName
            strAplicantname = strAplicantname.ToUpper

            Dim strBusinessName As String
            strBusinessName = CType(objQuoteData, GarageQuote).Garageoperation.BusinessName
            strBusinessName = strBusinessName.ToUpper
            If strBusinessName = "" Then
                strBusinessName = strAplicantname
            End If
            strAgentLoginID = Int32.Parse(CType(objQuoteData, GarageQuote).AgentID.Trim)

            Dim strName() As String = strAplicantname.Split(" ")
            Dim FName As String = String.Empty
            Dim LName As String = String.Empty
            If strName.Length > 1 Then
                FName = strName(0).Trim
                For i As Integer = 0 To strName.Length - 1
                    LName = LName & strName(i)
                Next
            Else : FName = strAplicantname
            End If

            If strQuoteNumber.Length = 6 Then strQuoteNumber = strQuoteNumber & "0"

            If strQuoteNumber.Length = 5 Then strQuoteNumber = strQuoteNumber & "00"

            If strQuoteNumber.Length = 4 Then strQuoteNumber = strQuoteNumber & "000"

            If strQuoteNumber.Length = 3 Then strQuoteNumber = strQuoteNumber & "0000"

            If strQuoteNumber.Length = 2 Then strQuoteNumber = strQuoteNumber & "00000"

            If strQuoteNumber.Length = 1 Then strQuoteNumber = strQuoteNumber & "000000"
            xmlConfig = New XmlUtils.XmlConfig(xmlCONTEXT, PROPERTIES)
            Dim objIDX As New ImageRightFileCreator.ImageWriterImpl
            objIDX.SetConfiguration(xmlCONTEXT, PROPERTIES)
            If Not objIDX.CreateIDXFile(xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "IDXDeptCode"), strQuoteNumber, strQuoteNumber, FName, LName, "N", strAgentLoginID.Trim, "comm", strBusinessName) Then
                'lblMessage.Text = "Error in creating IDX file"
                'lblMessage.Visible = True
                logger.Error("Error in creating file for QuoteNumber:" & strQuoteNumber)
                Return False
            Else
                For Each file As String In filelst
                    CreateIDXFile_Attachment(xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "IDXDeptCode"), file, strQuoteNumber, "N", "comm", strBusinessName)
                    ' objIDX.CreateIDXFile(xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "IDXDeptCode"), file, file, FName, LName, "N", strAgentLoginID.Trim, "comm", strBusinessName)
                Next

                Return True
            End If
        Catch ex As Exception
            logger.Error("Exception occurred while fetching quotedetails for imagerightfile :", ex)
            logger.Error("Exception Details : " & ex.StackTrace)
            Return False
        End Try
        logger.Debug("Exiting CreateImageright.CreateIDXFile")
    End Function
    'Private Sub CreateIDXfile(ByVal pv_GQNo As String, ByVal pv_Aplicantname As String, ByVal pv_AgentLoginID As String)
    '    Dim strName() As String = pv_Aplicantname.Split(" ")
    '    Dim FName As String = String.Empty
    '    Dim LName As String = String.Empty
    '    If strName.Length > 1 Then
    '        FName = strName(0).Trim
    '        For i As Integer = 0 To strName.Length - 1
    '            LName = LName & strName(i)
    '        Next
    '    Else : FName = pv_Aplicantname
    '    End If

    '    If pv_GQNo.Length = 6 Then pv_GQNo = pv_GQNo & "0"

    '    If pv_GQNo.Length = 5 Then pv_GQNo = pv_GQNo & "00"

    '    If pv_GQNo.Length = 4 Then pv_GQNo = pv_GQNo & "000"

    '    If pv_GQNo.Length = 3 Then pv_GQNo = pv_GQNo & "0000"

    '    If pv_GQNo.Length = 2 Then pv_GQNo = pv_GQNo & "00000"

    '    If pv_GQNo.Length = 1 Then pv_GQNo = pv_GQNo & "000000"

    '    Dim objIDX As New ImageRightFileCreator.ImageWriterImpl
    '    objIDX.SetConfiguration(xmlCONTEXT, PROPERTIES)
    '    If Not objIDX.CreateIDXFile(xmlConfig.GetComponentProperty(COMP_GQS_CreateQuote, "IDXDeptCode"), pv_GQNo, pv_GQNo, FName, LName, "N", pv_AgentLoginID) Then
    '        lblMessage.Text = "Error in creating IDX file"
    '        lblMessage.Visible = True
    '        logger.Error("Error in creating file for GarageQuoteNumber:" & pv_GQNo)
    '    End If


    'End Sub




    Public Function CreateIDXFile_Attachment(ByVal pstrDeptCode As String, ByVal pstrRefNbr As String, ByVal pstrPolicyNbr As String, ByVal pstrTranType As String, Optional ByVal pstrdeptname As String = "", Optional ByVal pstrBusinessorTradeName As String = "") As Boolean
        'ImageWriterImpl.logger.Debug("Entering ImageWriterImpl.CreateIDXFile")

        Dim result As Boolean = False

        Dim filename As String = pstrRefNbr & ".pdf"
        Dim SavePath As String = xmlConfig.GetComponentProperty("ImageRight", "IDXFilePath") + pstrRefNbr + "-" + Strings.Format(DateAndTime.Now, "ddMMMyy-HHmmss") + ".idx"
        Dim str As String = filename
        str = String.Concat(str, " ")
        str = String.Concat(str, "$#IY#$")
        Dim text As String = pstrPolicyNbr
        Dim text2 As String = pstrBusinessorTradeName
        Dim flag As Boolean = Strings.Len(text2) > 40
        If (flag) Then
            text2 = Strings.Left(text2, 40)
        Else
            While (Strings.Len(text2) < 40)
                text2 = String.Concat(text2, " ")
            End While
        End If
        str = String.Concat(str, text2)
        str = String.Concat(str, "D922")
        str = String.Concat(str, "M")
        Dim left As String = pstrTranType
        flag = (String.Compare(left, "N", False) = 0)
        If (flag) Then
            str = String.Concat(str, "10  ")
        Else

            flag = (String.Compare(left, "R", False) = 0)
            If (flag) Then
                str = String.Concat(str, "20  ")
            Else
                flag = (String.Compare(left, "E", False) = 0)
                If (flag) Then
                    str = String.Concat(str, "50  ")
                Else
                    str = String.Concat(str, "10  ")
                End If
            End If
        End If

        str = String.Concat(str, "     ")
        str = String.Concat(str, "2    ")
        str = String.Concat(str, "  ")
        str = String.Concat(str, "   ")
        str = String.Concat(str, "  ")
        str = String.Concat(str, "              ")
        str = String.Concat(str, "N")
        Dim text3 As String = pstrBusinessorTradeName
        flag = (Strings.Len(text3) > 30)
        If (flag) Then
            text3 = Strings.Left(text3, 30)
        Else
            While (Strings.Len(text3) < 30)
                text3 = String.Concat(text3, " ")
            End While
        End If

        str = String.Concat(str, text3)
        Dim text4 As String = (DateAndTime.Month(DateAndTime.Now)).ToString
        Dim text5 As String = (DateAndTime.Day(DateAndTime.Now)).ToString
        Dim str2 As String = (DateAndTime.Year(DateAndTime.Now)).ToString
        flag = (Strings.Len(text4) < 2)
        If (flag) Then
            text4 = "0" & text4
        End If
        flag = (Strings.Len(text5) < 2)
        If (flag) Then
            text5 = "0" & text5
        End If
        Dim str3 As String = str2 & text4 & text5
        str = String.Concat(str, str3)
        str = String.Concat(str, "        ")
        str = String.Concat(str, "Y")
        flag = (String.Compare(pstrdeptname.ToUpper(), "COMM", False) = 0)
        If (flag) Then
            str = String.Concat(str, "Commercial Transportation Quote Sheet             ")
        Else
            str = String.Concat(str, "Garage Quote Sheet                                ")
        End If
        str = String.Concat(str, "C")
        str = String.Concat(str, "1     ")
        str = String.Concat(str, "2         ")
        str = String.Concat(str, "N")

        While (Strings.Len(text) < 10)
            text = String.Concat(text, " ")
        End While
        str = String.Concat(str, text)
        str = String.Concat(str, "                    ")
        str = String.Concat(str, "                              ")
        str = String.Concat(str, "                                        ")
        Dim IsPresent As Boolean = False
        IsPresent = System.IO.File.Exists(SavePath)
        If (IsPresent) Then
            System.IO.File.Delete(SavePath)
        End If

        Dim fileStream As FileStream = File.Create(SavePath)
        fileStream.Close()
        fileStream = File.OpenWrite(SavePath)
        Dim bytes As Byte() = New UTF8Encoding(True).GetBytes(str)
        fileStream.Write(bytes, 0, bytes.Length)
        fileStream.Close()
        result = True
        Return result

    End Function

End Class
