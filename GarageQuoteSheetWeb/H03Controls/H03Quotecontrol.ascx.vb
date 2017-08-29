Imports GarageQuoteSheetDLL
Imports GarageQuoteSheetDLL.H03
Imports log4net
Imports System.IO
Imports System.Xml
Imports System.Collections.Generic
Imports System.Xml.Xsl
Imports System.Xml.XPath

Namespace UserControlH03
    Partial Class H03Quotecontrol
        Inherits System.Web.UI.UserControl
        '''Implements ISubscriber
        Implements H03IPublisher
        Implements H03ISubscriber
        Dim vaidatemsg As String
        Dim strName As String = "QuoteDescriptiondetails"
        Dim H03subscribers As New List(Of H03ISubscriber)
        Dim H03Application As New List(Of H03ISubscriber)
        Dim strState As String
        Dim isApplication As Boolean = False
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)
#Region "Properties"


        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property

#End Region
#Region "DataMembers"
        Private genquotecoll As GenericCollection(Of IEntity)
        Private objH03Quote As H03Quote



#End Region
        ''' <summary>
        ''' Validate InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            'Validation Part Here
            logger.Debug("Entering H03Quotecontrol.Validate")
            Try

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            End Try


            Return (vaidatemsg)

            logger.Debug("Exiting H03Quotecontrol.Validate")


        End Function
        ''Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
        ''    logger.Debug("Entering CommAutoCoverageControl.GetInputData")

        ''    logger.Debug("Exiting CommAutoCoverageControl.GetInputData")
        ''End Function
        ''Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        ''End Sub


        '' ''Private Function FillControls(ByVal pstrQuoteId As String) As Boolean Implements ISubscriber.FillControls
        '' ''    Return True
        '' ''End Function

        Protected Sub btnCalculatePremium_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalculatePremium.Click
            Try
                'Validate Service Running Or not
                logger.Info("Start Validating Quote Application Before Calculating Premium")
                Dim subscriber As H03ISubscriber
                Dim Coveragesubscriber As H03ISubscriber
                Dim objValidateService As New ValidateService()
                Dim strOutput As String
                If objValidateService.IsServiceRunning("H03Rating.HO3Service") = False Then
                    Dim strAlert = "<Script Language='JavaScript'>alert('H03Rating Service is not Responding...');</Script>"
                    Response.Write(strAlert)
                    Exit Sub
                Else
                    AttachSubscriber("AgencyInfoPh", "AgencyDetails")
                    AttachSubscriber("OperationPh", "H03RiskDescriptionl")
                    AttachSubscriber("Vehicleph", "HomeDescriptiondetails")
                    AttachSubscriber("InsuranceHistoryPh", "CoverageDescriptiondetails")
                    AttachSubscriber("DriverPh", "HistoryDescriptiondetails")
                    
                    Dim strHomeDescription As String = ""
                    Dim strRiskDescription As String = ""
                    Dim strInsHistoryDes As String = ""
                    Dim strCoverage As String = ""
                    Dim strMessage As String = ""
                    For Each subscriber In H03subscribers
                        If subscriber.SubscriberName = "AgencyDetails" Then
                            strMessage = subscriber.H03ValidateInputData()
                            If strMessage <> "" Then
                                ''Show ErrorMessage
                                ShowErrorMessage(strMessage)
                                Exit Sub
                            End If

                        ElseIf subscriber.SubscriberName = "RiskDescriptiondetails" Then
                            strMessage = subscriber.H03ValidateInputData()
                            If strMessage = "" Then
                                strRiskDescription = subscriber.GetInputXmlData()
                            Else
                                ''Show ErrorMessage
                                ShowErrorMessage(strMessage)
                                Exit Sub
                            End If
                        ElseIf subscriber.SubscriberName = "HomeDescriptiondetails" Then
                            strMessage = subscriber.H03ValidateInputData()
                            If strMessage = "" Then
                                strHomeDescription = subscriber.GetInputXmlData()
                            Else
                                ''Show ErrorMessage
                                ShowErrorMessage(strMessage)
                                Exit Sub
                            End If


                        ElseIf subscriber.SubscriberName = "HistoryDescriptiondetails" Then
                            strMessage = subscriber.H03ValidateInputData()
                            If strMessage = "" Then
                                strInsHistoryDes = subscriber.GetInputXmlData()
                            Else
                                ''Show ErrorMessage
                                ShowErrorMessage(subscriber.H03ValidateInputData())
                                Exit Sub
                            End If

                        ElseIf subscriber.SubscriberName = "CoverageDescriptiondetails" Then
                            Coveragesubscriber = subscriber
                            strMessage = subscriber.H03ValidateInputData()
                            If strMessage = "" Then
                                strCoverage = subscriber.GetInputXmlData()
                            Else
                                ShowErrorMessage(strMessage)
                                ''Show ErrorMessage
                                Exit Sub
                            End If

                        End If
                    Next
                    logger.Info("Validation Completed, Generating InputXML File For H03Rating Service")
                    Dim objRate As New H03Rating.HO3ALEngineSoapClient()
                    Dim _strMenuXml As String = "<FactBase>" + strHomeDescription + strRiskDescription + strInsHistoryDes + strCoverage + "</FactBase>"
                    strState = GetXmlNodeList(_strMenuXml, "LiteralFact", "State").Item(0).InnerText
                    logger.Info("Pass inputXML file to Rating Engine")
                    strOutput = objRate.Rate(_strMenuXml)
                End If
                'GetBaseRate
                Dim _xmlNodeList As XmlNodeList '= GetXmlNodeList(strOutput, "LiteralFact", "failRule1")
                logger.Info("Parsed Output XML to get Base Rate")
                _xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "baseRate")
                If _xmlNodeList Is Nothing Or _xmlNodeList.Count = 0 Then logger.Info("Output XML Failed to return BaseRate") Else txttotbasePre.Text = _xmlNodeList.Item(0).InnerText

                'GetAdditionalPremiumSum
                _xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "additionalPremiumSum")
                If _xmlNodeList Is Nothing Or _xmlNodeList.Count = 0 Then logger.Info("Output XML Failed to return additionalPremiumSum") Else txtaddpre.Text = _xmlNodeList.Item(0).InnerText

                _xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "totalCreditSurcharge") 'creditSurchargePerSum
                If _xmlNodeList Is Nothing Or _xmlNodeList.Count = 0 Then logger.Info("Output XML Failed to return totalCreditSurcharge") Else txttotcredits.Text = _xmlNodeList.Item(0).InnerText
                '_xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "structures")
                'txt()
                txttotpre.Text = Val(txttotbasePre.Text) + Val(txtaddpre.Text)


                '' Set B_Structure And D_LossOfUse    
                _xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "structures")
                Dim structures As String = "0.00"
                If _xmlNodeList Is Nothing Or _xmlNodeList.Count = 0 Then logger.Info("Output XML Failed to return structures") Else structures = _xmlNodeList.Item(0).InnerText

                _xmlNodeList = GetXmlNodeList(strOutput, "NumericFact", "lossOfUse")
                Dim lossOfUse As String = "0.00"
                If _xmlNodeList Is Nothing Or _xmlNodeList.Count = 0 Then logger.Info("Output XML Failed to return lossOfUse") Else lossOfUse = _xmlNodeList.Item(0).InnerText

                logger.Info("Set B_AdjacentStructure & D_LossOfUse Value")
                Coveragesubscriber.SetCoverage(structures, lossOfUse)

                logger.Info("Calculate StateTaxAndFees")
                CalculateStateTaxAndFees()

            Catch ex As Exception
                logger.Info("Getting Error While Getting output From H03Rating Engine, Error MSG :" & ex.Message)
            End Try

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="strMessage"></param>
        ''' <remarks></remarks>
        Sub ShowErrorMessage(ByVal strMessage As String)
            isApplication = True
            H03AttachSubscriber(CType(Me.Parent.Parent.Page, H03ISubscriber))
            Dim ApplicationSubscriber As H03ISubscriber
            For Each ApplicationSubscriber In H03Application
                ApplicationSubscriber.ShowMessage(strMessage)
            Next
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim objService As New SIUService.ServiceSoapClient()
            If objService.isUnderwriter(IpAddress()) Then
                txtunderwriters.Enabled = True
                txtpolicy.Enabled = True
                txttotcredits.Enabled = True
            Else
                txtunderwriters.Enabled = False
                txtpolicy.Enabled = False
                txttotcredits.Enabled = False
            End If
        End Sub

        ''' <summary>
        ''' Get ProxyIp Address of Visitor '216.235.149.254
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IpAddress() As String
            Dim strIpAddress As String
            strIpAddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If strIpAddress Is Nothing Then
                strIpAddress = Request.ServerVariables("REMOTE_ADDR")
            End If
            Return strIpAddress
        End Function

        ''' <summary>
        ''' GetXMLNodeList For BaseRate
        ''' </summary>
        ''' <param name="_strXML"></param>
        ''' <param name="strFact"></param>
        ''' <param name="strid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetXmlNodeList(ByVal _strXML As String, ByVal strFact As String, ByVal strid As String) As XmlNodeList
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(_strXML)
            Dim _xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("FactBase/" + strFact + "[@id='" + strid + "']")
            Return _xmlNodeList
        End Function

        Private Sub H03AttachSubscriber(ByVal Subscriber As H03ISubscriber) Implements H03IPublisher.H03AttachSubscriber
            If isApplication Then
                H03Application.Add(Subscriber)
            Else
                H03subscribers.Add(Subscriber)
            End If

        End Sub
        

        ''' <summary>
        ''' Attach Subscriber
        ''' </summary>
        ''' <param name="strPanel"></param>
        ''' <param name="strControl"></param>
        ''' <remarks></remarks>
        Sub AttachSubscriber(ByVal strPanel As String, ByVal strControl As String)
            Dim ctrl As Control
            Dim Insuctrl As Control
            For Each ctrl In Me.Parent.Parent.Controls
                If ctrl.ClientID.ToString().Contains(strPanel) Then
                    For Each Insuctrl In ctrl.Controls
                        If Insuctrl.ClientID.ToString().Contains(strControl) Then
                            isApplication = False
                            H03AttachSubscriber(CType(Insuctrl, H03ISubscriber))
                        End If
                    Next
                End If
            Next
        End Sub
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            Return ""
        End Function
        ''' <summary>
        ''' Implements GetH03InputData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            logger.Debug("Entering H03QuoteControl.GetH03InputData")
            Try
                genquotecoll = New GenericCollection(Of IEntity)
                objH03Quote = New H03Quote
                objH03Quote.quotequoteId = 0
                objH03Quote.TotalBase = txttotbasePre.Text.Trim
                objH03Quote.SumAddPre = txtaddpre.Text.Trim
                ' objH03Quote.TotPremium = txttotpremium.Text.Trim
                objH03Quote.TotCredit = txttotcredits.Text.Trim
                objH03Quote.UnderWriterDis = txtunderwriters.Text.Trim
                objH03Quote.TotPre = txttotpremium.Text.Trim
                objH03Quote.Policy = txtpolicy.Text.Trim
                objH03Quote.SalesTax = txtsalestax.Text.Trim
                objH03Quote.Fslso = txtfslso.Text.Trim
                objH03Quote.Fhcf = txtfhcf.Text.Trim
                objH03Quote.Cpica = txtcpica.Text.Trim
                objH03Quote.Emg = txtemg.Text.Trim
                objH03Quote.GrandTotal = txtgrandtot.Text.Trim
                genquotecoll.Add(objH03Quote)

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
            Finally
            End Try

            Return genquotecoll
            logger.Debug("Exiting H03QuoteControl.GetH03InputData")
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub txttotpre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            CalculateStateTaxAndFees()
        End Sub
        ''' <summary>
        ''' 'CalculateStateTaxes And Fees
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateStateTaxAndFees()
            Try
                'Validate Service Running Or not
                Dim objValidateService As New ValidateService()
                Dim strOutput As String
                If objValidateService.IsServiceRunning("TaxesAndFees.StateTaxesAndFees") = False Then
                    Dim strAlert = "<Script Language='JavaScript'>alert('StateTaxes And Fees Service is not Responding...');</Script>"
                    Response.Write(strAlert)
                    logger.Info("StateTaxes And Fees Service is not Responding...")
                    Exit Sub
                Else
                    AttachSubscriber("OperationPh", "H03RiskDescriptionl")
                    Dim subscriber As H03ISubscriber
                    Dim strRiskDescription As String = ""
                    For Each subscriber In H03subscribers
                        If subscriber.SubscriberName = "RiskDescriptiondetails" Then
                            strRiskDescription = subscriber.GetInputXmlData()
                        End If
                    Next
                    Dim _strMenuXml As String = "<FactBase>" + strRiskDescription + "</FactBase>"
                    strState = GetXmlNodeList(_strMenuXml, "LiteralFact", "State").Item(0).InnerText

                    Dim objTaxesAndFees As New TaxesAndFees.StateTaxesAndFeesSoapClient()
                    Dim state As String = strState
                    Dim TotalPremium As Double = Val(txttotpre.Text) + Val(txttotcredits.Text) + Val(txtunderwriters.Text)
                    Dim premium As Double = TotalPremium + Val(txtpolicy.Text)
                    txttotpremium.Text = TotalPremium.ToString()
                    Dim effective As Date = DateTime.Now.ToShortDateString()
                    logger.Info("Passing Input to StateTaxAndFees webService ")
                    strOutput = objTaxesAndFees.GetTaxesAndFees(state, premium, effective)
                    txtsalestax.Text = GetStateTaxXmlNodeList(strOutput, "State Tax")
                    txtfslso.Text = GetStateTaxXmlNodeList(strOutput, "FSLSO")
                    txtfhcf.Text = GetStateTaxXmlNodeList(strOutput, "FHCF")
                    txtcpica.Text = GetStateTaxXmlNodeList(strOutput, "CPICA")
                    txtemg.Text = GetStateTaxXmlNodeList(strOutput, "EMG")
                    txtgrandtot.Text = Val(txtsalestax.Text) + Val(txtfslso.Text) + Val(txtfhcf.Text) + Val(txtcpica.Text) + Val(txtemg.Text) + Val(txttotpre.Text) + Val(txtunderwriters.Text) + Val(txtpolicy.Text) + Val(txttotcredits.Text)
                End If
            Catch ex As Exception
                logger.Info("Failed To Calculate StateTaxAndFees ... ")
            End Try
        End Sub
        ''' <summary>
        ''' GetStateTaxAnd Fees XML NodeList
        ''' </summary>
        ''' <param name="_strXML"></param>
        ''' <param name="strDesc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetStateTaxXmlNodeList(ByVal _strXML As String, ByVal strDesc As String) As String
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(_strXML)
            Dim strAmount As String = "0"
            Dim _xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("StateTaxesAndFees/Tax")
            For Each _xmlNode As XmlNode In _xmlNodeList
                If _xmlNode.Name = "Tax" Then
                    If _xmlNode.Item("Description").InnerText = strDesc Then
                        strAmount = _xmlNode.Item("Amount").InnerText.ToString()
                        Return strAmount
                        Exit Function
                    End If
                End If
            Next
            Return strAmount
        End Function

        Protected Sub txtunderwriters_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            CalculateStateTaxAndFees()
        End Sub
        ''' <summary>
        ''' Show Error Message
        ''' </summary>
        ''' <param name="strMessage"></param>
        ''' <remarks></remarks>
        Sub ShowMessage(ByVal strMessage As String) Implements H03ISubscriber.ShowMessage
            Exit Sub
        End Sub
        ''' <summary>
        ''' Set CoverageB & CoverageD 
        ''' </summary>
        ''' <param name="CoverageB"></param>
        ''' <param name="CoverageD"></param>
        ''' <remarks></remarks>
        Sub SetCoverage(ByVal CoverageB As String, ByVal CoverageD As String) Implements H03ISubscriber.SetCoverage

        End Sub
    End Class
End Namespace
