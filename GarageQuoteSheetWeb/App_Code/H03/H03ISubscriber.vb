Imports Microsoft.VisualBasic
Imports GarageQuoteSheetDLL

Public Interface H03ISubscriber
    'Function GetInputData() As GenericCollection(Of IEntity)
    ReadOnly Property SubscriberName() As String
    Function GetInputXmlData() As String
    Function GetH03InputData() As GenericCollection(Of IEntity)
    Function H03ValidateInputData() As String
    Sub ShowMessage(ByVal strMessage As String)
    Sub SetCoverage(ByVal CoverageB As String, ByVal CoverageD As String)
End Interface
