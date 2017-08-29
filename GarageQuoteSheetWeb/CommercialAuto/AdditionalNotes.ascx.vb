Imports GarageQuoteSheetDLL
Imports log4net


Namespace UserControl947
    Partial Class AdditionalNotes
        Inherits System.Web.UI.UserControl
        Implements ISubscriber
        Implements H03ISubscriber
        Private Shared logger As log4net.ILog = _
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType)

        Dim vaidatemsg As String
        Dim strName As String = "AdditionNotes"
        Dim genAdditioanlCollection As GenericCollection(Of IEntity)
#Region "Properties"
        ReadOnly Property Name() As String Implements ISubscriber.Name
            Get
                Return strName
            End Get
        End Property
        ReadOnly Property SubscriberName() As String Implements H03ISubscriber.SubscriberName
            Get
                Return strName
            End Get
        End Property
#End Region
#Region "DataMembers"

        Private objAdditional As AdditionNotes


#End Region
        Private Function Validate() As String Implements ISubscriber.Validate
            logger.Debug("Entering AdditionalNotes.Validate")
            'Validation Part Here
            Try

                If txtmultadditionalnotes.Text = "" Then
                    vaidatemsg = ""
                    Return (vaidatemsg)

                Else


                End If

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try


            logger.Info(vaidatemsg)
            logger.Debug("Exiting AdditionalNotes.Validate")
            Return (vaidatemsg)


        End Function
        ''' <summary>
        ''' Validate H03 InpuData
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function H03ValidateInputData() As String Implements H03ISubscriber.H03ValidateInputData
            logger.Debug("Entering AdditionalNotes.Validate")
            'Validation Part Here
            Try

                If txtmultadditionalnotes.Text = "" Then
                    vaidatemsg = ""
                    Return (vaidatemsg)
                Else
                End If

            Catch ex As Exception
                logger.Error("Exception occurred while loadding Agency Information ", ex)
                logger.Error("Exception Details : " & ex.StackTrace)

            End Try
            Return (vaidatemsg)
            logger.Debug("Exiting AdditionalNotes.Validate")
        End Function
        Private Function GetInputData() As GenericCollection(Of IEntity) Implements ISubscriber.GetInputData
            Return GetCollection("Commercial")
            
        End Function
        Private Function GetH03InputData() As GenericCollection(Of IEntity) Implements H03ISubscriber.GetH03InputData
            Return GetCollection("H03")
        End Function
        Public Function GetCollection(ByVal strControl As String) As GenericCollection(Of IEntity)
            logger.Debug("Entering AgencyInformation.GetInputData For " + strControl)
            genAdditioanlCollection = New GenericCollection(Of IEntity)

            objAdditional = New AdditionNotes()
            objAdditional.AdditionId = 0
            objAdditional.QuoteId = 0

            objAdditional.AdditionalNotes = txtmultadditionalnotes.Text.Trim
            genAdditioanlCollection.Add(objAdditional)

            Return genAdditioanlCollection
            logger.Debug("Exiting AgencyInformation.GetInputData For " + strControl)
        End Function
        Private Sub ShowHideHistory(ByVal index As Integer) Implements ISubscriber.ShowHideHistory

        End Sub
        Private Sub ShowState(ByVal State As String) Implements ISubscriber.ShowState

        End Sub

        Private Function FillControls(ByVal strQuoteId As String) As Boolean Implements ISubscriber.FillControls
            logger.Debug("Entering AdditionalNotes.FillControls")
            Dim objNoteColl As GenericCollection(Of IEntity)
            Dim objNoteDM As AdditionalNotesDataModel
            Try
                objNoteColl = New GenericCollection(Of IEntity)
                objNoteDM = New AdditionalNotesDataModel()
                objNoteColl = objNoteDM.GetData(strQuoteId, "1")
                If objNoteColl.Count > 0 Then
                    txtmultadditionalnotes.Text = CType(objNoteColl.Item(0), AdditionNotes).AdditionalNotes
                End If
            Catch ex As Exception
                logger.Error("Exception occurred while setting values in Additional Notes Details :", ex)
                logger.Error("Exception Details : " & ex.StackTrace)
                Throw ex

            End Try
            logger.Debug("Exiting AdditionalNotes.FillControls")

        End Function
        ''' <summary>
        ''' Get InputXMLData 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetInputXmlData() As String Implements H03ISubscriber.GetInputXmlData
            Return ""
        End Function
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

