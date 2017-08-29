Imports Microsoft.VisualBasic
Imports GarageQuoteSheetDLL

Public Interface ISubscriber
    ReadOnly Property Name() As String
    Function Validate() As String
    Function GetInputData() As GenericCollection(Of IEntity)
    Sub ShowHideHistory(ByVal index As Integer)
    Sub ShowState(ByVal state As String)
    Function FillControls(ByVal strAgentId As String) As Boolean
End Interface
