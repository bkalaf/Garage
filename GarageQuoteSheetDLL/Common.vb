Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics

Namespace GarageQuoteSheetDLL
	Public Class Common
		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Function getBit(ByVal obj As Object) As Integer
			Dim num As Integer
			If (Operators.CompareString(obj.[GetType]().ToString(), "System.Boolean", False) = 0 Or Operators.CompareString(obj.[GetType]().ToString(), "Boolean", False) = 0) Then
				If (Conversions.ToBoolean(obj)) Then
					num = 1
					Return num
				ElseIf (Not Conversions.ToBoolean(obj)) Then
					num = 0
					Return num
				End If
			End If
			If (Operators.CompareString(obj.[GetType]().ToString(), "System.String", False) = 0 Or Operators.CompareString(obj.[GetType]().ToString(), "String", False) = 0) Then
				If (Strings.StrComp(Conversions.ToString(obj), "True", CompareMethod.Text) = 0) Then
					num = 1
					Return num
				ElseIf (Strings.StrComp(Conversions.ToString(obj), "False", CompareMethod.Text) = 0) Then
					num = 0
					Return num
				End If
			End If
			num = -1
			Return num
		End Function
	End Class
End Namespace