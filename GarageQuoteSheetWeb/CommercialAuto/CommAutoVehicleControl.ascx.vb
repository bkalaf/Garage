Imports GarageQuoteSheetDLL
Imports log4net

Namespace UserControl947
    Partial Class CommAutoVehicleControl
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Private Shared logger As log4net.ILog = _
                    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
        Dim vaidatemsg As String
        Public MMYYYY As String = DateTime.Now.Month.ToString() & "/" & DateTime.Now.Year.ToString()
        Dim flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8, flag9, flag10 As String

          
#Region "DataMembers"
        Private GenVehicleCollection As GenericCollection(Of IEntity)
        Private objVehicle As Vehicle
        Private strName As String = "VehicleDetails"
#End Region

#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
#End Region

        Private Function Validate() As String Implements ISubscriber.Validate
            'Validation Part Here

            Dim strFiled As String = ""

            logger.Debug("Entering CommAutoVehicleControl.Validate")
            Try
                If CType(Me.Parent.Parent.FindControl("hdnSubmit"), HtmlInputHidden).Value = "0" Then
                    CType(Me.Parent.Parent.FindControl("hdnSubmit"), HtmlInputHidden).Value = "1"

                    If txyear1.Text <> "" Or txtmake1.Text <> "" Or txtGVW1.Text <> "" Or txttype1.Text <> "" Or txtstatedvalue1.Text <> "" Or ddldeductible1.SelectedIndex <> 0 Then
                        If txyear1.Text = "" Or txtmake1.Text = "" Or txtGVW1.Text = "" Or txttype1.Text = "" Or txtstatedvalue1.Text = "" Or ddldeductible1.SelectedIndex = 0 Then

                            If txyear1.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtmake1.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW1.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype1.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue1.Text = "" Then
                                strFiled = "Stated value"
                                'ElseIf ddldeductible1.SelectedIndex = 0 Then
                                '    strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 1 in Vehicle Information section."
                            'txyear1.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear2.Text <> "" Or txtMake2.Text <> "" Or txtGVW2.Text <> "" Or txttype2.Text <> "" Or txtstatedvalue2.Text <> "" Or ddldeductible2.SelectedIndex <> 0 Then
                        If txyear2.Text = "" Or txtMake2.Text = "" Or txtGVW2.Text = "" Or txttype2.Text = "" Or txtstatedvalue2.Text = "" Or ddldeductible2.SelectedIndex = 0 Then
                            If txyear2.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake2.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW2.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype2.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue2.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible2.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 2 in Vehicle Information section."

                            'txyear2.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear3.Text <> "" Or txtMake3.Text <> "" Or txtGVW3.Text <> "" Or txttype3.Text <> "" Or txtstatedvalue3.Text <> "" Or ddldeductible3.SelectedIndex <> 0 Then
                        If txyear3.Text = "" Or txtMake3.Text = "" Or txtGVW3.Text = "" Or txttype3.Text = "" Or txtstatedvalue3.Text = "" Or ddldeductible3.SelectedIndex = 0 Then

                            If txyear3.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake3.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW3.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype3.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue3.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible3.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 3 in Vehicle Information section."

                            'txyear3.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If


                    If txyear4.Text <> "" Or txtMake4.Text <> "" Or txtGVW4.Text <> "" Or txttype4.Text <> "" Or txtstatedvalue4.Text <> "" Or ddldeductible4.SelectedIndex <> 0 Then
                        If txyear4.Text = "" Or txtMake4.Text = "" Or txtGVW4.Text = "" Or txttype4.Text = "" Or txtstatedvalue4.Text = "" Or ddldeductible4.SelectedIndex = 0 Then

                            If txyear4.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake4.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW4.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype4.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue4.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible4.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 4 in Vehicle Information section."
                            'txyear4.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear5.Text <> "" Or txtMake5.Text <> "" Or txtGVW5.Text <> "" Or txttype5.Text <> "" Or txtstatedvalue5.Text <> "" Or ddldeductible5.SelectedIndex <> 0 Then
                        If txyear5.Text = "" Or txtMake5.Text = "" Or txtGVW5.Text = "" Or txttype5.Text = "" Or txtstatedvalue5.Text = "" Or ddldeductible5.SelectedIndex = 0 Then
                            If txyear5.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake5.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW5.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype5.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue5.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible5.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 5 in Vehicle Information section."
                            'txyear5.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear6.Text <> "" Or txtMake6.Text <> "" Or txtGVW6.Text <> "" Or txttype6.Text <> "" Or txtstatedvalue6.Text <> "" Or ddldeductible6.SelectedIndex <> 0 Then
                        If txyear6.Text = "" Or txtMake6.Text = "" Or txtGVW6.Text = "" Or txttype6.Text = "" Or txtstatedvalue6.Text = "" Or ddldeductible6.SelectedIndex = 0 Then
                            If txyear6.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake6.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW6.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype6.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue6.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible6.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 6 in Vehicle Information section."
                            'txyear6.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear7.Text <> "" Or txtMake7.Text <> "" Or txtGVW7.Text <> "" Or txttype7.Text <> "" Or txtstatedvalue7.Text <> "" Or ddldeductible7.SelectedIndex <> 0 Then
                        If txyear7.Text = "" Or txtMake7.Text = "" Or txtGVW7.Text = "" Or txttype7.Text = "" Or txtstatedvalue7.Text = "" Or ddldeductible7.SelectedIndex = 0 Then
                            If txyear7.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake7.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW7.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype7.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue7.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible7.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 7 in Vehicle Information section."
                            'txyear7.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear8.Text <> "" Or txtMake8.Text <> "" Or txtGVW8.Text <> "" Or txttype8.Text <> "" Or txtstatedvalue8.Text <> "" Or ddldeductible8.SelectedIndex <> 0 Then
                        If txyear8.Text = "" Or txtMake8.Text = "" Or txtGVW8.Text = "" Or txttype8.Text = "" Or txtstatedvalue8.Text = "" Or ddldeductible8.SelectedIndex = 0 Then
                            If txyear8.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake8.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW8.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype8.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue8.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible8.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 8 in Vehicle Information section."
                            'txyear8.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If


                    If txyear9.Text <> "" Or txtMake9.Text <> "" Or txtGVW9.Text <> "" Or txttype9.Text <> "" Or txtstatedvalue9.Text <> "" Or ddldeductible9.SelectedIndex <> 0 Then
                        If txyear9.Text = "" Or txtMake9.Text = "" Or txtGVW9.Text = "" Or txttype9.Text = "" Or txtstatedvalue9.Text = "" Or ddldeductible9.SelectedIndex = 0 Then
                            If txyear9.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake9.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW9.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype9.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue9.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible9.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 9 in Vehicle Information section."
                            'txyear9.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If

                    If txyear10.Text <> "" Or txtMake10.Text <> "" Or txtGVW10.Text <> "" Or txttype10.Text <> "" Or txtstatedvalue10.Text <> "" Or ddldeductible10.SelectedIndex <> 0 Then
                        If txyear10.Text = "" Or txtMake10.Text = "" Or txtGVW10.Text = "" Or txttype10.Text = "" Or txtstatedvalue10.Text = "" Or ddldeductible10.SelectedIndex = 0 Then
                            If txyear10.Text = "" Then
                                strFiled = "Year"
                            ElseIf txtMake10.Text = "" Then
                                strFiled = "Make"
                            ElseIf txtGVW10.Text = "" Then
                                strFiled = "Gross Vehicle Weight"
                            ElseIf txttype10.Text = "" Then
                                strFiled = "Type"
                            ElseIf txtstatedvalue10.Text = "" Then
                                strFiled = "Stated value"
                            ElseIf ddldeductible10.SelectedIndex = 0 Then
                                strFiled = "Deductible"
                            End If
                            vaidatemsg = "Warning: Missing " & strFiled & " of row 10 in Vehicle Information section."
                            'txyear10.Focus()
                        End If
                        logger.Info(vaidatemsg)
                        logger.Debug("Exiting CommAutoVehicleControl.Validate")
                        Return (vaidatemsg)
                    End If
                End If
            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try
            logger.Info(vaidatemsg)
            logger.Debug("Exiting CommAutoVehicleControl.Validate")
            Return (vaidatemsg)


        End Function

        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            logger.Debug("Entering CommAutoVehicleControl.GetInputData")
            Try


                GenVehicleCollection = New GenericCollection(Of IEntity)
                objVehicle = New Vehicle()
                If txyear1.Text <> "" Or txtmake1.Text <> "" Or txtGVW1.Text <> "" Or txttype1.Text <> "" Then
                    objVehicle.Id = 0
                    objVehicle.Year = txyear1.Text.Trim
                    objVehicle.Make = txtmake1.Text.Trim
                    objVehicle.GVW = txtGVW1.Text.Trim
                    objVehicle.VehicleType = txttype1.Text
                    objVehicle.StatedValue = txtstatedvalue1.Text.Trim
                    objVehicle.Deductible = ddldeductible1.SelectedItem.Text

                    GenVehicleCollection.Add(objVehicle)
                End If
                '2

                If txyear2.Text <> "" Or txtMake2.Text <> "" Or txtGVW2.Text <> "" Or txttype2.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear2.Text.Trim
                    objVehicle.Make = txtMake2.Text.Trim
                    objVehicle.GVW = txtGVW2.Text.Trim
                    objVehicle.VehicleType = txttype2.Text
                    objVehicle.StatedValue = txtstatedvalue2.Text.Trim
                    objVehicle.Deductible = ddldeductible2.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '3
                If txyear3.Text <> "" Or txtMake3.Text <> "" Or txtGVW3.Text <> "" Or txttype3.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear3.Text.Trim
                    objVehicle.Make = txtMake3.Text.Trim
                    objVehicle.GVW = txtGVW3.Text.Trim
                    objVehicle.VehicleType = txttype3.Text
                    objVehicle.StatedValue = txtstatedvalue3.Text.Trim
                    objVehicle.Deductible = ddldeductible3.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '4
                If txyear4.Text <> "" Or txtMake4.Text <> "" Or txtGVW4.Text <> "" Or txttype4.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear4.Text.Trim
                    objVehicle.Make = txtMake4.Text.Trim
                    objVehicle.GVW = txtGVW4.Text.Trim
                    objVehicle.VehicleType = txttype4.Text
                    objVehicle.StatedValue = txtstatedvalue4.Text.Trim
                    objVehicle.Deductible = ddldeductible4.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '5
                If txyear5.Text <> "" Or txtMake5.Text <> "" Or txtGVW5.Text <> "" Or txttype5.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear5.Text.Trim
                    objVehicle.Make = txtMake5.Text.Trim
                    objVehicle.GVW = txtGVW5.Text.Trim
                    objVehicle.VehicleType = txttype5.Text
                    objVehicle.StatedValue = txtstatedvalue5.Text.Trim
                    objVehicle.Deductible = ddldeductible5.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '6
                If txyear6.Text <> "" Or txtMake6.Text <> "" Or txtGVW6.Text <> "" Or txttype6.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear6.Text.Trim
                    objVehicle.Make = txtMake6.Text.Trim
                    objVehicle.GVW = txtGVW6.Text.Trim
                    objVehicle.VehicleType = txttype6.Text
                    objVehicle.StatedValue = txtstatedvalue6.Text.Trim
                    objVehicle.Deductible = ddldeductible6.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '7
                If txyear7.Text <> "" Or txtMake7.Text <> "" Or txtGVW7.Text <> "" Or txttype7.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear7.Text.Trim
                    objVehicle.Make = txtMake7.Text.Trim
                    objVehicle.GVW = txtGVW7.Text.Trim
                    objVehicle.VehicleType = txttype7.Text
                    objVehicle.StatedValue = txtstatedvalue7.Text.Trim
                    objVehicle.Deductible = ddldeductible7.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)

                End If
                '8
                If txyear8.Text <> "" Or txtMake8.Text <> "" Or txtGVW8.Text <> "" Or txttype8.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear8.Text.Trim
                    objVehicle.Make = txtMake8.Text.Trim
                    objVehicle.GVW = txtGVW8.Text.Trim
                    objVehicle.VehicleType = txttype8.Text
                    objVehicle.StatedValue = txtstatedvalue8.Text.Trim
                    objVehicle.Deductible = ddldeductible8.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '9
                If txyear9.Text <> "" Or txtMake9.Text <> "" Or txtGVW9.Text <> "" Or txttype9.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear9.Text.Trim
                    objVehicle.Make = txtMake9.Text.Trim
                    objVehicle.GVW = txtGVW9.Text.Trim
                    objVehicle.VehicleType = txttype9.Text
                    objVehicle.StatedValue = txtstatedvalue9.Text.Trim
                    objVehicle.Deductible = ddldeductible9.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
                '10
                If txyear10.Text <> "" Or txtMake10.Text <> "" Or txtGVW10.Text <> "" Or txttype10.Text <> "" Then
                    objVehicle = New Vehicle()

                    objVehicle.Id = 0
                    objVehicle.Year = txyear10.Text.Trim
                    objVehicle.Make = txtMake10.Text.Trim
                    objVehicle.GVW = txtGVW10.Text.Trim
                    objVehicle.VehicleType = txttype10.Text
                    objVehicle.StatedValue = txtstatedvalue10.Text.Trim
                    objVehicle.Deductible = ddldeductible10.SelectedItem.Text


                    GenVehicleCollection.Add(objVehicle)
                End If
            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try
            logger.Debug("Exiting CommAutoVehicleControl.GetInputData")
            Return GenVehicleCollection


        End Function

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering CommAutoVehicleControl.FillControls")
            Dim objVehicles As GenericCollection(Of IEntity)
            Dim objVehicleDM As VehicleDataModel
            Dim objVehicle As New Vehicle
            Dim iCount As Integer = 0
            Try
                objVehicles = New GenericCollection(Of IEntity)
                objVehicleDM = New VehicleDataModel()
                objVehicles = objVehicleDM.GetData(strQuoteId, "1")

                For Each objVehicle In objVehicles

                    Select Case iCount
                        Case 0
                            txyear1.Text = objVehicle.Year
                            txtmake1.Text = objVehicle.Make
                            txtGVW1.Text = objVehicle.GVW
                            txttype1.Text = objVehicle.VehicleType
                            txtstatedvalue1.Text = objVehicle.StatedValue
                            ddldeductible1.SelectedIndex = -1
                            ddldeductible1.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 1
                            txyear2.Text = objVehicle.Year
                            txtMake2.Text = objVehicle.Make
                            txtGVW2.Text = objVehicle.GVW
                            txttype2.Text = objVehicle.VehicleType
                            txtstatedvalue2.Text = objVehicle.StatedValue
                            ddldeductible2.SelectedIndex = -1
                            ddldeductible2.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 2
                            txyear3.Text = objVehicle.Year
                            txtMake3.Text = objVehicle.Make
                            txtGVW3.Text = objVehicle.GVW
                            txttype3.Text = objVehicle.VehicleType
                            txtstatedvalue3.Text = objVehicle.StatedValue
                            ddldeductible3.SelectedIndex = -1
                            ddldeductible3.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 3
                            txyear4.Text = objVehicle.Year
                            txtMake4.Text = objVehicle.Make
                            txtGVW4.Text = objVehicle.GVW
                            txttype4.Text = objVehicle.VehicleType
                            txtstatedvalue4.Text = objVehicle.StatedValue
                            ddldeductible4.SelectedIndex = -1
                            ddldeductible4.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 4
                            txyear5.Text = objVehicle.Year
                            txtMake5.Text = objVehicle.Make
                            txtGVW5.Text = objVehicle.GVW
                            txttype5.Text = objVehicle.VehicleType
                            txtstatedvalue5.Text = objVehicle.StatedValue
                            ddldeductible5.SelectedIndex = -1
                            ddldeductible5.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 5
                            txyear6.Text = objVehicle.Year
                            txtMake6.Text = objVehicle.Make
                            txtGVW6.Text = objVehicle.GVW
                            txttype6.Text = objVehicle.VehicleType
                            txtstatedvalue6.Text = objVehicle.StatedValue
                            ddldeductible6.SelectedIndex = -1
                            ddldeductible6.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 6
                            txyear7.Text = objVehicle.Year
                            txtMake7.Text = objVehicle.Make
                            txtGVW7.Text = objVehicle.GVW
                            txttype7.Text = objVehicle.VehicleType
                            txtstatedvalue7.Text = objVehicle.StatedValue
                            ddldeductible7.SelectedIndex = -1
                            ddldeductible7.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 7
                            txyear8.Text = objVehicle.Year
                            txtMake8.Text = objVehicle.Make
                            txtGVW8.Text = objVehicle.GVW
                            txttype8.Text = objVehicle.VehicleType
                            txtstatedvalue8.Text = objVehicle.StatedValue
                            ddldeductible8.SelectedIndex = -1
                            ddldeductible8.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 8
                            txyear9.Text = objVehicle.Year
                            txtMake9.Text = objVehicle.Make
                            txtGVW9.Text = objVehicle.GVW
                            txttype9.Text = objVehicle.VehicleType
                            txtstatedvalue9.Text = objVehicle.StatedValue
                            ddldeductible9.SelectedIndex = -1
                            ddldeductible9.Items.FindByText(objVehicle.Deductible).Selected = True

                        Case 9
                            txyear10.Text = objVehicle.Year
                            txtMake10.Text = objVehicle.Make
                            txtGVW10.Text = objVehicle.GVW
                            txttype10.Text = objVehicle.VehicleType
                            txtstatedvalue10.Text = objVehicle.StatedValue
                            ddldeductible10.SelectedIndex = -1
                            ddldeductible10.Items.FindByText(objVehicle.Deductible).Selected = True


                    End Select
                    iCount += 1
                Next



            Catch ex As Exception

            End Try
            logger.Debug("Exiting CommAutoVehicleControl.FillControls")

        End Function

        <Obsolete("It is not usable")> _
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory
        End Sub
        <Obsolete("It is not usable")> _
        Public Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub
    End Class
End Namespace
