Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace GarageQuoteSheetDLL
	''' <summary>
	''' This class represents Generic collection. 
	''' </summary>
	''' <typeparam name="GenericType"></typeparam>
	''' <remarks></remarks>
	Public Class GenericCollection(Of GenericType)
		Inherits CollectionBase
		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub Add(ByVal GenericObject As GenericType)
			Me.InnerList.Add(GenericObject)
		End Sub

		Public Function Item(ByVal index As Integer) As GenericType
			Dim genericParameter As GenericType = Conversions.ToGenericParameter(Of GenericType)(RuntimeHelpers.GetObjectValue(Me.InnerList(index)))
			Return genericParameter
		End Function

		Public Sub Remove(ByVal index As Integer)
			Me.InnerList.RemoveAt(index)
		End Sub
	End Class
End Namespace