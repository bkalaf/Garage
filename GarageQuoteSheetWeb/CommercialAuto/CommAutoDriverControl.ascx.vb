Imports GarageQuoteSheetDLL
Imports log4net

Namespace UserControl947
    Partial Class CommAutoDriverControl
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Dim vaidatemsg As String
        Dim ArrayTkts As New ArrayList


        Private Shared logger As log4net.ILog = _
                    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
        Private GenDriverCollection As GenericCollection(Of IEntity)
        Private strName As String = "DriverDetails"
        Public MMYYYY As String = DateTime.Now.Month.ToString() & "/" & DateTime.Now.Year.ToString()
        Dim fyear1, fyear2, fyear3 As Integer
        Dim tyear1, tyear2, tyear3 As Integer
        Dim frmyear1, frmyear2, frmyear3 As String
        Dim toyear1, toyear2, toyear3 As String
        Dim frmdate1, todate1, frmdate2, frmdate3, todate2, todate3 As DateTime

#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"

        Private objDriver As Driver
        Private genTktsDriverColl As GenericCollection(Of DriverTicket)
        Private objTktsDriver As DriverTicket



#End Region

        Private Function Validate() As String Implements ISubscriber.Validate
            logger.Debug("Entering CommAutoDriverControl.Validate")
            'Validation Part Here

            Try


                If txtName1.Text <> "" Or txtbirth1.Text <> "" Or txtexp1.Text <> "" Then
                    If txtName1.Text = "" Or txtbirth1.Text = "" Or txtexp1.Text = "" Then
                        vaidatemsg = "Fill the entire row 1 of Driver Information"
                        txtName1.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoDriverControl.Validate")
                        Return (vaidatemsg)
                    End If
                    'If txthiredt1.Text <> "" Then
                    '    Dim dtHiredate1 As Date
                    '    Try
                    '        dtHiredate1 = txthiredt1.Text
                    '        If dtHiredate1.Year < 1900 Or dtHiredate1.Year > Now.Year Then
                    '            vaidatemsg = "Please enter a valid hire date(year should be greater than 1900 and not greater than current year ) for the first driver"
                    '            txthiredt1.Focus()
                    '            Return (vaidatemsg)

                    '        End If
                    '    Catch ex As Exception
                    '        vaidatemsg = "Please enter a valid hire date (year should be greater than 1900 and not greater than current year ) for the first driver"
                    '        txthiredt1.Focus()
                    '        Return (vaidatemsg)
                    '    End Try
                    'End If
                End If



                If txtName2.Text <> "" Or txtbirth2.Text <> "" Or txtexp2.Text <> "" Then
                    If txtName2.Text = "" Or txtbirth2.Text = "" Or txtexp2.Text = "" Then
                        vaidatemsg = "Fill the entrire row 2 of Driver Information"
                        txtName2.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoDriverControl.Validate")
                        Return (vaidatemsg)
                    End If
                    'If txthiredt2.Text <> "" Then
                    '    Dim dtHiredate2 As Date
                    '    dtHiredate2 = txthiredt2.Text
                    '    If dtHiredate2.Year < 1900 Or dtHiredate2.Year > Now.Year Then
                    '        vaidatemsg = "Please enter a valid hire date (year should be greater than 1900 and not greater than current year ) for the second driver"
                    '        txthiredt2.Focus()
                    '        Return (vaidatemsg)
                    '    End If
                    'End If
                End If


                If txtName3.Text <> "" Or txtbirth3.Text <> "" Or txtexp3.Text <> "" Then
                    If txtName3.Text = "" Or txtbirth3.Text = "" Or txtexp3.Text = "" Then
                        vaidatemsg = "Fill the entrire row 3 of Driver Information"
                        txtName3.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoDriverControl.Validate")
                        Return (vaidatemsg)
                    End If
                    'If txthiredt3.Text <> "" Then
                    '    Dim dtHiredate3 As Date
                    '    dtHiredate3 = txthiredt3.Text
                    '    If dtHiredate3.Year < 1900 Or dtHiredate3.Year > Now.Year Then
                    '        vaidatemsg = "Please enter a valid hire date (year should be greater than 1900 and not greater than current year ) for the third driver"
                    '        txthiredt3.Focus()
                    '        Return (vaidatemsg)
                    '    End If
                    'End If
                End If


                If txtName4.Text <> "" Or txtbirth4.Text <> "" Or txtexp4.Text <> "" Then
                    If txtName4.Text = "" Or txtbirth4.Text = "" Or txtexp4.Text = "" Then
                        vaidatemsg = "Fill the entrire row 4 of Driver Information"
                        txtName4.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoDriverControl.Validate")
                        Return (vaidatemsg)
                    End If
                    'If txthiredt4.Text <> "" Then
                    '    Dim dtHiredate4 As Date
                    '    dtHiredate4 = txthiredt4.Text
                    '    If dtHiredate4.Year < 1900 Or dtHiredate4.Year > Now.Year Then
                    '        vaidatemsg = "Please enter a valid hire date (year should be greater than 1900 and not greater than current year ) for the fourth driver"
                    '        txthiredt4.Focus()
                    '        Return (vaidatemsg)
                    '    End If
                    'End If
                End If
                If txtName5.Text <> "" Or txtbirth5.Text <> "" Or txtexp5.Text <> "" Then
                    If txtName5.Text = "" Or txtbirth5.Text = "" Or txtexp5.Text = "" Then
                        vaidatemsg = "Fill the entrire row 5 of Driver Information"
                        txtName5.Focus()
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoDriverControl.Validate")
                        Return (vaidatemsg)
                    End If
                    'If txthiredt5.Text <> "" Then
                    '    Dim dtHiredate5 As Date
                    '    dtHiredate5 = txthiredt5.Text
                    '    If dtHiredate5.Year < 1900 Or dtHiredate5.Year > Now.Year Then
                    '        vaidatemsg = "Please enter a valid hire date (year should be greater than 1900 and not greater than current year ) for the fifth driver"
                    '        txthiredt1.Focus()
                    '        Return (vaidatemsg)
                    '    End If
                    'End If
                End If

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try
            logger.Info(vaidatemsg)
            logger.Debug("Exiting CommAutoDriverControl.Validate")
            Return (vaidatemsg)

        End Function


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            logger.Debug("Entering CommAutoDriverControl.Page_Load")
            Try


                txtexp1.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtName1.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtName2.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtName3.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtName4.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtName5.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtexp2.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtexp3.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtexp4.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtexp5.Attributes.Add("onkeypress", "Javascript:return DoNotCallIsAlphaNumeric(true);")
                txtexp2.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
                txtexp3.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
                txtexp4.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
                txtexp5.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")
                txtexp1.Attributes.Add("onkeypress", "Javascript:return CheckNumeric();")

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try
            logger.Debug("Exiting CommAutoDriverControl.Page_Load")
        End Sub

        Public Function SplitCollection(ByVal txtControl As TextBox) As ArrayList
            logger.Debug("Entering CommAutoDriverControl.SplitCollection")
            Dim Arrlst As ArrayList

            Try

                Dim strSplit() As String = txtControl.Text.Trim().Split(vbCrLf)

                If (strSplit.Length = 1) Then
                    Arrlst = New ArrayList(1)
                    Arrlst.Add(txtControl.Text.Trim())
                    Return Arrlst
                Else

                    Arrlst = New ArrayList(strSplit.Length)
                    'Loop Here
                    For i As Integer = 0 To strSplit.Length - 1
                        Arrlst.Add(strSplit(i).ToString().Trim())
                    Next
                    Return Arrlst
                End If
            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try
            Return Arrlst

            logger.Debug("Exiting CommAutoDriverControl.SplitCollection")
        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            logger.Debug("Entering CommAutoDriverControl.GetInputData")
            Try
                GenDriverCollection = New GenericCollection(Of IEntity)

                objDriver = New Driver()
                If txtName1.Text <> "" Or txtbirth1.Text <> "" Or txtexp1.Text <> "" Or txthiredt1.Text <> "" Then
                    objDriver.Id = 0
                    objDriver.Name = txtName1.Text.Trim

                    If txtbirth1.Text <> "" Then
                        If txtbirth1.Text <> "__/__/____" Then
                            Dim firstpart As String = ""
                            Dim secpart As String = ""
                            Dim thrdpart As String = ""
                            Dim forthpart As String = ""
                            Dim mon As Integer
                            Dim day As Integer

                            If txtbirth1.Text.Contains("/") Then
                                firstpart = txtbirth1.Text.Substring(0, txtbirth1.Text.IndexOf("/"))
                                secpart = txtbirth1.Text.Substring(txtbirth1.Text.IndexOf("/") + 1)
                                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                            End If
                            mon = Convert.ToInt32(firstpart)
                            day = Convert.ToInt32(thrdpart)
                            If mon >= 1 And mon <= 9 Then
                                firstpart = "0" + mon.ToString

                            End If
                            If day >= 1 And day <= 9 Then
                                thrdpart = "0" + day.ToString

                            End If
                            If forthpart = "0000" Then
                                frmyear1 = 2000
                                txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                            Else
                                frmyear1 = ""
                                frmdate1 = txtbirth1.Text
                                fyear1 = frmdate1.Year
                                txtbirth1.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                If fyear1 >= 1 And fyear1 <= 9 Then
                                    frmyear1 = "200" & fyear1
                                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 9 And fyear1 <= 40 Then
                                    frmyear1 = "20" & fyear1
                                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 40 And fyear1 < 99 Then
                                    frmyear1 = "19" & fyear1
                                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                            End If
                            objDriver.DOB = txtbirth1.Text.Trim
                        End If
                    End If
                    objDriver.YearsExperience = txtexp1.Text.Trim
                    If txthiredt1.Text <> "" Then
                        If txthiredt1.Text <> "" Then
                            If txthiredt1.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                If txthiredt1.Text.Contains("/") Then
                                    firstpart = txthiredt1.Text.Substring(0, txthiredt1.Text.IndexOf("/"))
                                    secpart = txthiredt1.Text.Substring(txthiredt1.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                Dim mon As Integer
                                Dim day As Integer
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString
                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else
                                    frmyear1 = ""
                                    frmdate1 = txthiredt1.Text
                                    fyear1 = frmdate1.Year
                                    txthiredt1.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 <= 40 Then
                                        frmyear1 = "20" & fyear1
                                        txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 40 And fyear1 < 99 Then
                                        frmyear1 = "19" & fyear1
                                        txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                End If
                                objDriver.HireDate = txthiredt1.Text.Trim

                            End If
                        End If
                    Else
                        objDriver.HireDate = "1/1/1900"
                    End If



                    If (txttkts1.Text <> "") Then
                        genTktsDriverColl = New GenericCollection(Of DriverTicket)
                        ArrayTkts = SplitCollection(txttkts1)

                        Dim i As Integer
                        For i = 0 To ArrayTkts.Count - 1
                            objTktsDriver = New DriverTicket()
                            objTktsDriver.Id = 0
                            objTktsDriver.DriverId = 0
                            If ArrayTkts.Item(i).ToString <> "" Then
                                objTktsDriver.TicketDetails = ArrayTkts.Item(i).ToString
                                genTktsDriverColl.Add(objTktsDriver)
                            End If

                        Next
                        objDriver.DrverTickets = genTktsDriverColl
                    End If
                    GenDriverCollection.Add(objDriver)


                End If
                '2

                objDriver = New Driver()
                If txtName2.Text <> "" Or txtbirth2.Text <> "" Or txtexp2.Text <> "" Or txthiredt2.Text <> "" Then
                    objDriver.Id = 0
                    objDriver.Name = txtName2.Text.Trim
                    'objDriver.DOB = txtbirth2.Text.Trim
                    If txtbirth2.Text <> "" Then


                        If txtbirth2.Text <> "__/__/____" Then

                            Dim firstpart As String = ""
                            Dim secpart As String = ""
                            Dim thrdpart As String = ""
                            Dim forthpart As String = ""
                            Dim mon As Integer
                            Dim day As Integer


                            If txtbirth2.Text.Contains("/") Then

                                firstpart = txtbirth2.Text.Substring(0, txtbirth1.Text.IndexOf("/"))
                                secpart = txtbirth2.Text.Substring(txtbirth1.Text.IndexOf("/") + 1)
                                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

                            End If
                            mon = Convert.ToInt32(firstpart)
                            day = Convert.ToInt32(thrdpart)
                            If mon >= 1 And mon <= 9 Then
                                firstpart = "0" + mon.ToString

                            End If
                            If day >= 1 And day <= 9 Then
                                thrdpart = "0" + day.ToString

                            End If
                            If forthpart = "0000" Then
                                frmyear1 = 2000
                                txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                            Else
                                frmyear1 = ""
                                frmdate1 = txtbirth2.Text
                                fyear1 = frmdate1.Year
                                txtbirth2.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                If fyear1 >= 1 And fyear1 <= 9 Then
                                    frmyear1 = "200" & fyear1
                                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 9 And fyear1 <= 40 Then
                                    frmyear1 = "20" & fyear1
                                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 40 And fyear1 < 99 Then
                                    frmyear1 = "19" & fyear1
                                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                            End If
                            objDriver.DOB = txtbirth2.Text.Trim
                        End If
                    End If

                    objDriver.YearsExperience = txtexp2.Text.Trim

                    If txthiredt2.Text <> "" Then
                        If txthiredt2.Text <> "" Then
                            If txthiredt2.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                If txthiredt2.Text.Contains("/") Then
                                    firstpart = txthiredt2.Text.Substring(0, txthiredt2.Text.IndexOf("/"))
                                    secpart = txthiredt2.Text.Substring(txthiredt2.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                Dim mon As Integer
                                Dim day As Integer
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString
                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else
                                    frmyear1 = ""
                                    frmdate1 = txthiredt2.Text
                                    fyear1 = frmdate1.Year
                                    txthiredt2.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 <= 40 Then
                                        frmyear1 = "20" & fyear1
                                        txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 40 And fyear1 < 99 Then
                                        frmyear1 = "19" & fyear1
                                        txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                End If
                                objDriver.HireDate = txthiredt2.Text.Trim

                            End If
                        End If
                    Else
                        objDriver.HireDate = "1/1/1900"
                    End If



                    If (txttkts2.Text <> "") Then
                        genTktsDriverColl = New GenericCollection(Of DriverTicket)
                        ArrayTkts = SplitCollection(txttkts2)

                        Dim i As Integer
                        For i = 0 To ArrayTkts.Count - 1
                            objTktsDriver = New DriverTicket()
                            objTktsDriver.Id = 0
                            objTktsDriver.DriverId = 0
                            If ArrayTkts.Item(i).ToString <> "" Then
                                objTktsDriver.TicketDetails = ArrayTkts.Item(i).ToString
                                genTktsDriverColl.Add(objTktsDriver)
                            End If
                        Next
                        objDriver.DrverTickets = genTktsDriverColl
                    End If
                    GenDriverCollection.Add(objDriver)

                End If
                '3
                objDriver = New Driver()
                If txtName3.Text <> "" Or txtbirth3.Text <> "" Or txtexp3.Text <> "" Or txthiredt3.Text <> "" Then
                    objDriver.Id = 0
                    objDriver.Name = txtName3.Text.Trim
                    If txtbirth3.Text <> "" Then

                        If txtbirth3.Text <> "__/__/____" Then

                            Dim firstpart As String = ""
                            Dim secpart As String = ""
                            Dim thrdpart As String = ""
                            Dim forthpart As String = ""
                            Dim mon As Integer
                            Dim day As Integer


                            If txtbirth3.Text.Contains("/") Then
                                firstpart = txtbirth3.Text.Substring(0, txtbirth3.Text.IndexOf("/"))
                                secpart = txtbirth3.Text.Substring(txtbirth3.Text.IndexOf("/") + 1)
                                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                            End If
                            mon = Convert.ToInt32(firstpart)
                            day = Convert.ToInt32(thrdpart)
                            If mon >= 1 And mon <= 9 Then
                                firstpart = "0" + mon.ToString

                            End If
                            If day >= 1 And day <= 9 Then
                                thrdpart = "0" + day.ToString

                            End If
                            If forthpart = "0000" Then
                                frmyear1 = 2000
                                txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                            Else
                                frmyear1 = ""
                                frmdate1 = txtbirth3.Text
                                fyear1 = frmdate1.Year
                                txtbirth3.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                If fyear1 >= 1 And fyear1 <= 9 Then
                                    frmyear1 = "200" & fyear1
                                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 9 And fyear1 <= 40 Then
                                    frmyear1 = "20" & fyear1
                                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 40 And fyear1 < 99 Then
                                    frmyear1 = "19" & fyear1
                                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                            End If
                            objDriver.DOB = txtbirth3.Text.Trim
                        End If
                    End If

                    objDriver.YearsExperience = txtexp3.Text.Trim
                    If txthiredt3.Text <> "" Then
                        If txthiredt3.Text <> "" Then
                            If txthiredt3.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                If txthiredt3.Text.Contains("/") Then
                                    firstpart = txthiredt3.Text.Substring(0, txthiredt3.Text.IndexOf("/"))
                                    secpart = txthiredt3.Text.Substring(txthiredt3.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                Dim mon As Integer
                                Dim day As Integer
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString
                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else
                                    frmyear1 = ""
                                    frmdate1 = txthiredt3.Text
                                    fyear1 = frmdate1.Year
                                    txthiredt3.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 <= 40 Then
                                        frmyear1 = "20" & fyear1
                                        txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 40 And fyear1 < 99 Then
                                        frmyear1 = "19" & fyear1
                                        txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                End If
                                objDriver.HireDate = txthiredt3.Text.Trim

                            End If
                        End If
                    Else
                        objDriver.HireDate = "1/1/1900"
                    End If


                    If (txttkts3.Text <> "") Then
                        genTktsDriverColl = New GenericCollection(Of DriverTicket)
                        ArrayTkts = SplitCollection(txttkts3)

                        Dim i As Integer
                        For i = 0 To ArrayTkts.Count - 1
                            objTktsDriver = New DriverTicket()
                            objTktsDriver.Id = 0
                            objTktsDriver.DriverId = 0
                            If ArrayTkts.Item(i).ToString <> "" Then
                                objTktsDriver.TicketDetails = ArrayTkts.Item(i).ToString
                                genTktsDriverColl.Add(objTktsDriver)
                            End If
                        Next
                        objDriver.DrverTickets = genTktsDriverColl
                    End If
                    GenDriverCollection.Add(objDriver)

                End If
                '4
                objDriver = New Driver()
                If txtName4.Text <> "" Or txtbirth4.Text <> "" Or txtexp4.Text <> "" Or txthiredt4.Text <> "" Then
                    objDriver.Id = 0
                    objDriver.Name = txtName4.Text.Trim
                    'objDriver.DOB = txtbirth4.Text.Trim
                    If txtbirth4.Text <> "" Then
                        If txtbirth4.Text <> "__/__/____" Then
                            Dim firstpart As String = ""
                            Dim secpart As String = ""
                            Dim thrdpart As String = ""
                            Dim forthpart As String = ""
                            Dim mon As Integer
                            Dim day As Integer

                            If txtbirth4.Text.Contains("/") Then
                                firstpart = txtbirth4.Text.Substring(0, txtbirth4.Text.IndexOf("/"))
                                secpart = txtbirth4.Text.Substring(txtbirth4.Text.IndexOf("/") + 1)
                                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                            End If
                            mon = Convert.ToInt32(firstpart)
                            day = Convert.ToInt32(thrdpart)
                            If mon >= 1 And mon <= 9 Then
                                firstpart = "0" + mon.ToString
                            End If
                            If day >= 1 And day <= 9 Then
                                thrdpart = "0" + day.ToString

                            End If
                            If forthpart = "0000" Then
                                frmyear1 = 2000
                                txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                            Else
                                frmyear1 = ""
                                frmdate1 = txtbirth4.Text
                                fyear1 = frmdate1.Year
                                txtbirth4.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                If fyear1 >= 1 And fyear1 <= 9 Then
                                    frmyear1 = "200" & fyear1
                                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 9 And fyear1 <= 40 Then
                                    frmyear1 = "20" & fyear1
                                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 40 And fyear1 < 99 Then
                                    frmyear1 = "19" & fyear1
                                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                            End If
                            objDriver.DOB = txtbirth4.Text.Trim
                        End If
                    End If


                    objDriver.YearsExperience = txtexp4.Text.Trim
                    ' objDriver.HireDate = txthiredt4.Text.Trim
                    If txthiredt4.Text <> "" Then
                        If txthiredt4.Text <> "" Then
                            If txthiredt4.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                If txthiredt4.Text.Contains("/") Then
                                    firstpart = txthiredt4.Text.Substring(0, txthiredt4.Text.IndexOf("/"))
                                    secpart = txthiredt4.Text.Substring(txthiredt4.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                Dim mon As Integer
                                Dim day As Integer
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString
                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else
                                    frmyear1 = ""
                                    frmdate1 = txthiredt4.Text
                                    fyear1 = frmdate1.Year
                                    txthiredt4.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 <= 40 Then
                                        frmyear1 = "20" & fyear1
                                        txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 40 And fyear1 < 99 Then
                                        frmyear1 = "19" & fyear1
                                        txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                End If
                                objDriver.HireDate = txthiredt4.Text.Trim

                            End If
                        End If
                    Else
                        objDriver.HireDate = "1/1/1900"
                    End If


                    If (txttkts4.Text <> "") Then
                        genTktsDriverColl = New GenericCollection(Of DriverTicket)
                        ArrayTkts = SplitCollection(txttkts4)

                        Dim i As Integer
                        For i = 0 To ArrayTkts.Count - 1
                            objTktsDriver = New DriverTicket()
                            objTktsDriver.Id = 0
                            objTktsDriver.DriverId = 0
                            If ArrayTkts.Item(i).ToString <> "" Then
                                objTktsDriver.TicketDetails = ArrayTkts.Item(i).ToString
                                genTktsDriverColl.Add(objTktsDriver)
                            End If
                        Next
                        objDriver.DrverTickets = genTktsDriverColl

                    End If


                    GenDriverCollection.Add(objDriver)

                End If
                '5
                objDriver = New Driver()
                If txtName5.Text <> "" Or txtbirth5.Text <> "" Or txtexp5.Text <> "" Or txthiredt5.Text <> "" Then
                    objDriver.Id = 0
                    objDriver.Name = txtName5.Text.Trim
                    'objDriver.DOB = txtbirth5.Text.Trim

                    If txtbirth5.Text <> "" Then
                        If txtbirth5.Text <> "__/__/____" Then
                            Dim firstpart As String = ""
                            Dim secpart As String = ""
                            Dim thrdpart As String = ""
                            Dim forthpart As String = ""
                            Dim mon As Integer
                            Dim day As Integer

                            If txtbirth5.Text.Contains("/") Then
                                firstpart = txtbirth5.Text.Substring(0, txtbirth5.Text.IndexOf("/"))
                                secpart = txtbirth5.Text.Substring(txtbirth5.Text.IndexOf("/") + 1)
                                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                            End If
                            mon = Convert.ToInt32(firstpart)
                            day = Convert.ToInt32(thrdpart)
                            If mon >= 1 And mon <= 9 Then
                                firstpart = "0" + mon.ToString
                            End If
                            If day >= 1 And day <= 9 Then
                                thrdpart = "0" + day.ToString

                            End If
                            If forthpart = "0000" Then
                                frmyear1 = 2000
                                txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                            Else
                                frmyear1 = ""
                                frmdate1 = txtbirth5.Text
                                fyear1 = frmdate1.Year
                                txtbirth5.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                If fyear1 >= 1 And fyear1 <= 9 Then
                                    frmyear1 = "200" & fyear1
                                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 9 And fyear1 <= 40 Then
                                    frmyear1 = "20" & fyear1
                                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                                If fyear1 > 40 And fyear1 < 99 Then
                                    frmyear1 = "19" & fyear1
                                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                End If
                            End If
                            objDriver.DOB = txtbirth5.Text.Trim
                        End If
                    End If



                    objDriver.YearsExperience = txtexp5.Text.Trim
                    'objDriver.HireDate = txthiredt5.Text.Trim
                    If txthiredt5.Text <> "" Then
                        If txthiredt5.Text <> "" Then
                            If txthiredt5.Text <> "__/__/____" Then

                                Dim firstpart As String = ""
                                Dim secpart As String = ""
                                Dim thrdpart As String = ""
                                Dim forthpart As String = ""

                                If txthiredt5.Text.Contains("/") Then
                                    firstpart = txthiredt5.Text.Substring(0, txthiredt5.Text.IndexOf("/"))
                                    secpart = txthiredt4.Text.Substring(txthiredt5.Text.IndexOf("/") + 1)
                                    thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
                                    forthpart = secpart.Substring(secpart.IndexOf("/") + 1)
                                End If
                                Dim mon As Integer
                                Dim day As Integer
                                mon = Convert.ToInt32(firstpart)
                                day = Convert.ToInt32(thrdpart)
                                If mon >= 1 And mon <= 9 Then
                                    firstpart = "0" + mon.ToString
                                End If
                                If day >= 1 And day <= 9 Then
                                    thrdpart = "0" + day.ToString
                                End If
                                If forthpart = "0000" Then
                                    frmyear1 = 2000
                                    txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                Else
                                    frmyear1 = ""
                                    frmdate1 = txthiredt5.Text
                                    fyear1 = frmdate1.Year
                                    txthiredt5.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
                                    If fyear1 >= 1 And fyear1 <= 9 Then
                                        frmyear1 = "200" & fyear1
                                        txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 9 And fyear1 <= 40 Then
                                        frmyear1 = "20" & fyear1
                                        txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                    If fyear1 > 40 And fyear1 < 99 Then
                                        frmyear1 = "19" & fyear1
                                        txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
                                    End If
                                End If
                                objDriver.HireDate = txthiredt5.Text.Trim

                            End If
                        End If
                    Else
                        objDriver.HireDate = "1/1/1900"
                    End If

                    If (txttkts5.Text <> "") Then
                        genTktsDriverColl = New GenericCollection(Of DriverTicket)
                        ArrayTkts = SplitCollection(txttkts5)

                        Dim i As Integer
                        For i = 0 To ArrayTkts.Count - 1
                            objTktsDriver = New DriverTicket()
                            objTktsDriver.Id = 0
                            objTktsDriver.DriverId = 0
                            If ArrayTkts.Item(i).ToString <> "" Then
                                objTktsDriver.TicketDetails = ArrayTkts.Item(i).ToString
                                genTktsDriverColl.Add(objTktsDriver)
                            End If
                        Next
                        objDriver.DrverTickets = genTktsDriverColl

                    End If


                    GenDriverCollection.Add(objDriver)

                End If

                'objDriver.DrverTickets = genTktsDriverColl
            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try

            logger.Debug("Exiting CommAutoDriverControl.GetInputData")

            Return GenDriverCollection

        End Function
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        End Sub
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoVehicleControl.FillControls")
            Dim objDrivers As GenericCollection(Of IEntity)
            Dim objDriverDM As DriverDataModel
            Dim objDriver As New Driver
            Dim iCount As Integer
            Dim drivercnt As Integer
            Try
                objDrivers = New GenericCollection(Of IEntity)
                objDriverDM = New DriverDataModel()
                objDrivers = objDriverDM.GetData(strQuoteId, "1")
                Dim strTicket As String
                For Each objDriver In objDrivers

                    Select Case drivercnt
                        Case 0
                            txtName1.Text = objDriver.Name
                            txtbirth1.Text = objDriver.DOB
                            txtexp1.Text = objDriver.YearsExperience

                            If objDriver.HireDate = "1/1/1900" Then
                                txthiredt1.Text = ""
                            Else
                                txthiredt1.Text = objDriver.HireDate

                            End If
                            strTicket = ""
                            If Not (objDriver.DrverTickets Is Nothing) Then
                                If objDriver.DrverTickets.Count > 0 Then
                                    For iCount = 0 To objDriver.DrverTickets.Count - 1
                                        strTicket += CType(objDriver.DrverTickets.Item(iCount), DriverTicket).TicketDetails & vbCrLf
                                    Next
                                End If
                            End If
                            txttkts1.Text = strTicket

                        Case 1
                            txtName2.Text = objDriver.Name
                            txtbirth2.Text = objDriver.DOB
                            txtexp2.Text = objDriver.YearsExperience
                            'txthiredt2.Text = objDriver.HireDate
                            If objDriver.HireDate = "1/1/1900" Then
                                txthiredt2.Text = ""
                            Else
                                txthiredt2.Text = objDriver.HireDate

                            End If
                            strTicket = ""
                            If Not (objDriver.DrverTickets Is Nothing) Then
                                If objDriver.DrverTickets.Count > 0 Then
                                    For iCount = 0 To objDriver.DrverTickets.Count - 1
                                        strTicket += CType(objDriver.DrverTickets.Item(iCount), DriverTicket).TicketDetails & vbCrLf
                                    Next
                                End If
                            End If
                            txttkts2.Text = strTicket
                        Case 2
                            txtName3.Text = objDriver.Name
                            txtbirth3.Text = objDriver.DOB
                            txtexp3.Text = objDriver.YearsExperience
                            'txthiredt3.Text = objDriver.HireDate
                            If objDriver.HireDate = "1/1/1900" Then
                                txthiredt3.Text = ""
                            Else
                                txthiredt3.Text = objDriver.HireDate

                            End If
                            strTicket = ""
                            If Not (objDriver.DrverTickets Is Nothing) Then
                                If objDriver.DrverTickets.Count > 0 Then
                                    For iCount = 0 To objDriver.DrverTickets.Count - 1
                                        strTicket += CType(objDriver.DrverTickets.Item(iCount), DriverTicket).TicketDetails & vbCrLf
                                    Next
                                End If
                            End If
                            txttkts3.Text = strTicket
                        Case 3
                            txtName4.Text = objDriver.Name
                            txtbirth4.Text = objDriver.DOB
                            txtexp4.Text = objDriver.YearsExperience
                            'txthiredt4.Text = objDriver.HireDate
                            If objDriver.HireDate = "1/1/1900" Then
                                txthiredt4.Text = ""
                            Else
                                txthiredt4.Text = objDriver.HireDate

                            End If
                            strTicket = ""
                            If Not (objDriver.DrverTickets Is Nothing) Then
                                If objDriver.DrverTickets.Count > 0 Then
                                    For iCount = 0 To objDriver.DrverTickets.Count - 1
                                        strTicket += CType(objDriver.DrverTickets.Item(iCount), DriverTicket).TicketDetails & vbCrLf
                                    Next
                                End If
                            End If
                            txttkts4.Text = strTicket
                        Case 4
                            txtName5.Text = objDriver.Name
                            txtbirth5.Text = objDriver.DOB
                            txtexp5.Text = objDriver.YearsExperience
                            'txthiredt5.Text = objDriver.HireDate
                            If objDriver.HireDate = "1/1/1900" Then
                                txthiredt5.Text = ""
                            Else
                                txthiredt5.Text = objDriver.HireDate

                            End If
                            strTicket = ""
                            If Not (objDriver.DrverTickets Is Nothing) Then
                                If objDriver.DrverTickets.Count > 0 Then
                                    For iCount = 0 To objDriver.DrverTickets.Count - 1
                                        strTicket += CType(objDriver.DrverTickets.Item(iCount), DriverTicket).TicketDetails & vbCrLf
                                    Next
                                End If
                            End If
                            txttkts5.Text = strTicket


                    End Select
                    drivercnt += 1
                Next



            Catch ex As Exception
                logger.Error("Exception occurred while setting values in Driver Details :", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
                Throw ex
            End Try
            logger.Debug("Exiting CommAutoDriverControl.FillControls")

        End Function

        'Protected Sub txtbirth1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)


        '    If txtbirth1.Text <> "" Then
        '        'if Convert.ToDateTime(txtbirth1.Text.ToString())<>

        '        If txtbirth1.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txtbirth1.Text.Contains("/") Then

        '                firstpart = txtbirth1.Text.Substring(0, txtbirth1.Text.IndexOf("/"))
        '                secpart = txtbirth1.Text.Substring(txtbirth1.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth1.Text
        '                fyear1 = frmdate1.Year
        '                txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txtbirth1.Text = Convert.ToDateTime(txtbirth1.Text)
        '            txtexp1.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txtbirth2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbirth2.TextChanged
        '    If txtbirth2.Text <> "" Then


        '        If txtbirth2.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""
        '            Dim mon As Integer
        '            Dim day As Integer

        '            If txtbirth2.Text.Contains("/") Then

        '                firstpart = txtbirth2.Text.Substring(0, txtbirth2.Text.IndexOf("/"))
        '                secpart = txtbirth2.Text.Substring(txtbirth2.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)


        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth2.Text
        '                fyear1 = frmdate1.Year
        '                'txtbirth2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txtbirth2.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txtbirth2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txtbirth2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txtbirth2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txtbirth2.Focus()

        '        End If
        '    End If

        'End Sub

        'Protected Sub txtbirth3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbirth3.TextChanged
        '    If txtbirth3.Text <> "" Then


        '        If txtbirth3.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""
        '            Dim mon As Integer
        '            Dim day As Integer
        '            If txtbirth3.Text.Contains("/") Then

        '                firstpart = txtbirth3.Text.Substring(0, txtbirth3.Text.IndexOf("/"))
        '                secpart = txtbirth3.Text.Substring(txtbirth3.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)

        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth3.Text
        '                fyear1 = frmdate1.Year
        '                'txtbirth3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txtbirth3.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txtbirth3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txtbirth3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txtbirth3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txtbirth3.Focus()
        '            '.Focus()
        '        End If
        '    End If

        'End Sub

        'Protected Sub txtbirth4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbirth4.TextChanged
        '    If txtbirth4.Text <> "" Then


        '        If txtbirth4.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""
        '            Dim mon As Integer
        '            Dim day As Integer
        '            If txtbirth4.Text.Contains("/") Then

        '                firstpart = txtbirth4.Text.Substring(0, txtbirth4.Text.IndexOf("/"))
        '                secpart = txtbirth4.Text.Substring(txtbirth4.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If

        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth4.Text
        '                fyear1 = frmdate1.Year
        '                'txtbirth4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txtbirth4.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txtbirth4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txtbirth4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txtbirth4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txtbirth4.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txtbirth5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbirth5.TextChanged
        '    If txtbirth5.Text <> "" Then


        '        If txtbirth5.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txtbirth5.Text.Contains("/") Then

        '                firstpart = txtbirth5.Text.Substring(0, txtbirth5.Text.IndexOf("/"))
        '                secpart = txtbirth5.Text.Substring(txtbirth5.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth5.Text
        '                fyear1 = frmdate1.Year
        '                txtbirth5.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
        '                'txtbirth5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    ' txtbirth5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txtbirth5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txtbirth5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txtbirth5.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txthiredt1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthiredt1.TextChanged
        '    If txthiredt1.Text <> "" Then



        '        If txthiredt1.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txthiredt1.Text.Contains("/") Then

        '                firstpart = txthiredt1.Text.Substring(0, txthiredt1.Text.IndexOf("/"))
        '                secpart = txthiredt1.Text.Substring(txthiredt1.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)

        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txthiredt1.Text
        '                fyear1 = frmdate1.Year
        '                'txthiredt1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txthiredt1.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txthiredt1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txthiredt1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txthiredt1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If
        '            txthiredt1.Focus()

        '        End If
        '    End If
        'End Sub

        'Protected Sub txthiredt2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthiredt2.TextChanged
        '    If txthiredt2.Text <> "" Then


        '        If txthiredt2.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txthiredt2.Text.Contains("/") Then

        '                firstpart = txthiredt2.Text.Substring(0, txthiredt2.Text.IndexOf("/"))
        '                secpart = txthiredt2.Text.Substring(txthiredt2.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If

        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txthiredt2.Text
        '                fyear1 = frmdate1.Year
        '                'txthiredt2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txthiredt2.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txthiredt2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString '

        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txthiredt2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    ' txthiredt2.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt2.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If


        '            End If
        '            txthiredt2.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txthiredt3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthiredt3.TextChanged
        '    If txthiredt3.Text <> "" Then


        '        If txthiredt3.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txthiredt3.Text.Contains("/") Then

        '                firstpart = txthiredt3.Text.Substring(0, txthiredt3.Text.IndexOf("/"))
        '                secpart = txthiredt3.Text.Substring(txthiredt3.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If

        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txthiredt3.Text
        '                fyear1 = frmdate1.Year
        '                'txthiredt3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txthiredt3.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString
        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txthiredt3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txthiredt3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txthiredt3.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt3.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If


        '            End If
        '            txthiredt3.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txthiredt4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthiredt4.TextChanged
        '    If txthiredt4.Text <> "" Then


        '        If txthiredt4.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txthiredt4.Text.Contains("/") Then

        '                firstpart = txthiredt4.Text.Substring(0, txthiredt4.Text.IndexOf("/"))
        '                secpart = txthiredt4.Text.Substring(txthiredt4.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)

        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If

        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txthiredt4.Text
        '                fyear1 = frmdate1.Year
        '                'txthiredt4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txthiredt4.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txthiredt4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txthiredt4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txthiredt4.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt4.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If


        '            End If
        '            txthiredt4.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txthiredt5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthiredt5.TextChanged
        '    If txthiredt5.Text <> "" Then


        '        If txthiredt5.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""

        '            If txthiredt5.Text.Contains("/") Then

        '                firstpart = txthiredt5.Text.Substring(0, txthiredt5.Text.IndexOf("/"))
        '                secpart = txthiredt5.Text.Substring(txthiredt5.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            Dim mon As Integer
        '            Dim day As Integer
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txthiredt5.Text
        '                fyear1 = frmdate1.Year
        '                'txthiredt5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txthiredt5.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txthiredt5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    'txthiredt5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txthiredt5.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txthiredt5.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If


        '            End If
        '            txthiredt5.Focus()
        '        End If
        '    End If
        'End Sub

        'Protected Sub txtbirth1_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        '    If txtbirth1.Text <> "" Then
        '        'if Convert.ToDateTime(txtbirth1.Text.ToString())<>

        '        If txtbirth1.Text <> "__/__/____" Then

        '            Dim firstpart As String = ""
        '            Dim secpart As String = ""
        '            Dim thrdpart As String = ""
        '            Dim forthpart As String = ""
        '            Dim mon As Integer
        '            Dim day As Integer


        '            If txtbirth1.Text.Contains("/") Then

        '                firstpart = txtbirth1.Text.Substring(0, txtbirth1.Text.IndexOf("/"))
        '                secpart = txtbirth1.Text.Substring(txtbirth1.Text.IndexOf("/") + 1)
        '                thrdpart = secpart.Substring(0, secpart.IndexOf("/"))
        '                forthpart = secpart.Substring(secpart.IndexOf("/") + 1)

        '            End If
        '            mon = Convert.ToInt32(firstpart)
        '            day = Convert.ToInt32(thrdpart)
        '            If mon >= 1 And mon <= 9 Then
        '                firstpart = "0" + mon.ToString

        '            End If
        '            If day >= 1 And day <= 9 Then
        '                thrdpart = "0" + day.ToString

        '            End If
        '            If forthpart = "0000" Then
        '                frmyear1 = 2000
        '                txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '            Else



        '                frmyear1 = ""
        '                frmdate1 = txtbirth1.Text
        '                fyear1 = frmdate1.Year
        '                ' txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + fyear1.ToString
        '                txtbirth1.Text = firstpart & "/" + thrdpart & "/" + fyear1.ToString

        '                If fyear1 >= 1 And fyear1 <= 9 Then
        '                    frmyear1 = "200" & fyear1
        '                    'txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 9 And fyear1 <= 40 Then
        '                    frmyear1 = "20" & fyear1
        '                    ' txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If
        '                If fyear1 > 40 And fyear1 < 99 Then
        '                    frmyear1 = "19" & fyear1
        '                    'txtbirth1.Text = frmdate1.Month.ToString & "/" + frmdate1.Day.ToString & "/" + frmyear1.ToString
        '                    txtbirth1.Text = firstpart & "/" + thrdpart & "/" + frmyear1.ToString
        '                End If



        '            End If

        '            txtbirth1.Focus()


        '        End If
        '    End If
        'End Sub

    End Class

End Namespace

