Imports System

Namespace GarageQuoteSheetDLL
	Public Interface IDataModel
		Function Delete(ByVal key As String) As Boolean

		Function GetData(ByVal key As String, Optional ByVal pstrQuoteType As String = "") As GenericCollection(Of IEntity)

		Function Save(ByVal objData As GenericCollection(Of IEntity)) As Integer

		Function Update(ByVal objData As GenericCollection(Of IEntity)) As Boolean
	End Interface
End Namespace