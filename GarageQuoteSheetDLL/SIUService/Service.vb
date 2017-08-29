Imports GarageQuoteSheetDLL.My
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.Services.Protocols

Namespace GarageQuoteSheetDLL.SIUService
	''' <remarks />
	<DebuggerStepThrough>
	<DesignerCategory("code")>
	<GeneratedCode("System.Web.Services", "2.0.50727.3053")>
	<WebServiceBinding(Name:="ServiceSoap", Namespace:="http://tempuri.org/")>
	Public Class Service
		Inherits SoapHttpClientProtocol
		Private Shared __ENCList As ArrayList

		Private GetTerritoryCountyInfoOperationCompleted As SendOrPostCallback

		Private GetBuiltYearCreditSurchargeOperationCompleted As SendOrPostCallback

		Private GetRoofAgeCreditSurchargeOperationCompleted As SendOrPostCallback

		Private GetWindDeductableCreditSurchargeOperationCompleted As SendOrPostCallback

		Private GetProtectionClassOperationCompleted As SendOrPostCallback

		Private GetConstructionTypeOperationCompleted As SendOrPostCallback

		Private GetProtectiveDeviceOperationCompleted As SendOrPostCallback

		Private GetOccupancyOperationCompleted As SendOrPostCallback

		Private isUnderwriterOperationCompleted As SendOrPostCallback

		Private GetPoolOperationCompleted As SendOrPostCallback

		Private GetNCCIClassCodeOperationCompleted As SendOrPostCallback

		Private GetNCCIClassDescriptionOperationCompleted As SendOrPostCallback

		Private GetCountyOperationCompleted As SendOrPostCallback

		Private GetLookupDataOperationCompleted As SendOrPostCallback

		Private GetLookupDataByStateCodeOperationCompleted As SendOrPostCallback

		Private GetCountyByZipCodeForALOperationCompleted As SendOrPostCallback

		Private GetCountyByZipCodeForSCOperationCompleted As SendOrPostCallback

		Private GetStateByZipCodeForALSCGAOperationCompleted As SendOrPostCallback

		Private useDefaultCredentialsSetExplicitly As Boolean

		Public Shadows Property Url As String
			Get
				Return MyBase.Url
			End Get
			Set(ByVal value As String)
				If (If(Not Me.IsLocalFileSystemWebService(MyBase.Url) OrElse Me.useDefaultCredentialsSetExplicitly OrElse Me.IsLocalFileSystemWebService(value), False, True)) Then
					MyBase.UseDefaultCredentials = False
				End If
				MyBase.Url = value
			End Set
		End Property

		Public Shadows Property UseDefaultCredentials As Boolean
			Get
				Return MyBase.UseDefaultCredentials
			End Get
			Set(ByVal value As Boolean)
				MyBase.UseDefaultCredentials = value
				Me.useDefaultCredentialsSetExplicitly = True
			End Set
		End Property

		<DebuggerNonUserCode>
		Shared Sub New()
			GarageQuoteSheetDLL.SIUService.Service.__ENCList = New ArrayList()
		End Sub

		''' <remarks />
		Public Sub New()
			MyBase.New()
			Dim _ENCList As ArrayList = GarageQuoteSheetDLL.SIUService.Service.__ENCList
			Monitor.Enter(_ENCList)
			Try
				GarageQuoteSheetDLL.SIUService.Service.__ENCList.Add(New WeakReference(Me))
			Finally
				Monitor.[Exit](_ENCList)
			End Try
			Me.Url = MySettings.[Default].GarageQuoteSheetDLL_SIUService_Service
			If (Not Me.IsLocalFileSystemWebService(Me.Url)) Then
				Me.useDefaultCredentialsSetExplicitly = True
			Else
				Me.UseDefaultCredentials = True
				Me.useDefaultCredentialsSetExplicitly = False
			End If
		End Sub

		Public Shadows Sub CancelAsync(ByVal userState As Object)
			MyBase.CancelAsync(RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetBuiltYearCreditSurcharge", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetBuiltYearCreditSurcharge(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetBuiltYearCreditSurcharge", objArray)(0), DataSet)
		End Function

		Public Sub GetBuiltYearCreditSurchargeAsync(ByVal strState As String)
			Me.GetBuiltYearCreditSurchargeAsync(strState, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetBuiltYearCreditSurchargeAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetBuiltYearCreditSurchargeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetBuiltYearCreditSurchargeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetBuiltYearCreditSurchargeOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetBuiltYearCreditSurcharge", objArray, Me.GetBuiltYearCreditSurchargeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetConstructionType", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetConstructionType(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetConstructionType", objArray)(0), DataSet)
		End Function

		Public Sub GetConstructionTypeAsync(ByVal strState As String)
			Me.GetConstructionTypeAsync(strState, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetConstructionTypeAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetConstructionTypeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetConstructionTypeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetConstructionTypeOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetConstructionType", objArray, Me.GetConstructionTypeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetCounty", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetCounty(ByVal strZipCode As String, ByVal strState As String) As DataSet
			Dim objArray() As Object = { strZipCode, strState }
			Return DirectCast(Me.Invoke("GetCounty", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetCountyAsync(ByVal strZipCode As String, ByVal strState As String)
			Me.GetCountyAsync(strZipCode, strState, Nothing)
		End Sub

		Public Sub GetCountyAsync(ByVal strZipCode As String, ByVal strState As String, ByVal userState As Object)
			If (Me.GetCountyOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetCountyOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetCountyOperationCompleted)
			End If
			Dim objArray() As Object = { strZipCode, strState }
			Me.InvokeAsync("GetCounty", objArray, Me.GetCountyOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetCountyByZipCodeForAL", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetCountyByZipCodeForAL(ByVal strZipcode As String) As DataSet
			Dim objArray() As Object = { strZipcode }
			Return DirectCast(Me.Invoke("GetCountyByZipCodeForAL", objArray)(0), DataSet)
		End Function

		Public Sub GetCountyByZipCodeForALAsync(ByVal strZipcode As String)
			Me.GetCountyByZipCodeForALAsync(strZipcode, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetCountyByZipCodeForALAsync(ByVal strZipcode As String, ByVal userState As Object)
			If (Me.GetCountyByZipCodeForALOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetCountyByZipCodeForALOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetCountyByZipCodeForALOperationCompleted)
			End If
			Dim objArray() As Object = { strZipcode }
			Me.InvokeAsync("GetCountyByZipCodeForAL", objArray, Me.GetCountyByZipCodeForALOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetCountyByZipCodeForSC", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetCountyByZipCodeForSC(ByVal strZipcode As String) As DataSet
			Dim objArray() As Object = { strZipcode }
			Return DirectCast(Me.Invoke("GetCountyByZipCodeForSC", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetCountyByZipCodeForSCAsync(ByVal strZipcode As String)
			Me.GetCountyByZipCodeForSCAsync(strZipcode, Nothing)
		End Sub

		Public Sub GetCountyByZipCodeForSCAsync(ByVal strZipcode As String, ByVal userState As Object)
			If (Me.GetCountyByZipCodeForSCOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetCountyByZipCodeForSCOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetCountyByZipCodeForSCOperationCompleted)
			End If
			Dim objArray() As Object = { strZipcode }
			Me.InvokeAsync("GetCountyByZipCodeForSC", objArray, Me.GetCountyByZipCodeForSCOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetLookupData", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetLookupData(ByVal intParentTable As Integer) As DataSet
			Dim objArray() As Object = { intParentTable }
			Return DirectCast(Me.Invoke("GetLookupData", objArray)(0), DataSet)
		End Function

		Public Sub GetLookupDataAsync(ByVal intParentTable As Integer)
			Me.GetLookupDataAsync(intParentTable, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetLookupDataAsync(ByVal intParentTable As Integer, ByVal userState As Object)
			If (Me.GetLookupDataOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetLookupDataOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetLookupDataOperationCompleted)
			End If
			Dim objArray() As Object = { intParentTable }
			Me.InvokeAsync("GetLookupData", objArray, Me.GetLookupDataOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetLookupDataByStateCode", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetLookupDataByStateCode(ByVal intParentTable As Integer, ByVal strState As String) As DataSet
			Dim objArray() As Object = { intParentTable, strState }
			Return DirectCast(Me.Invoke("GetLookupDataByStateCode", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetLookupDataByStateCodeAsync(ByVal intParentTable As Integer, ByVal strState As String)
			Me.GetLookupDataByStateCodeAsync(intParentTable, strState, Nothing)
		End Sub

		Public Sub GetLookupDataByStateCodeAsync(ByVal intParentTable As Integer, ByVal strState As String, ByVal userState As Object)
			If (Me.GetLookupDataByStateCodeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetLookupDataByStateCodeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetLookupDataByStateCodeOperationCompleted)
			End If
			Dim objArray() As Object = { intParentTable, strState }
			Me.InvokeAsync("GetLookupDataByStateCode", objArray, Me.GetLookupDataByStateCodeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetNCCIClassCode", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetNCCIClassCode() As DataSet
			Dim objArray As Object() = Me.Invoke("GetNCCIClassCode", New Object(-1) {})
			Return DirectCast(objArray(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetNCCIClassCodeAsync()
			Me.GetNCCIClassCodeAsync(Nothing)
		End Sub

		Public Sub GetNCCIClassCodeAsync(ByVal userState As Object)
			If (Me.GetNCCIClassCodeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetNCCIClassCodeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetNCCIClassCodeOperationCompleted)
			End If
			Me.InvokeAsync("GetNCCIClassCode", New Object(-1) {}, Me.GetNCCIClassCodeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetNCCIClassDescription", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetNCCIClassDescription(ByVal strCode As String) As DataSet
			Dim objArray() As Object = { strCode }
			Return DirectCast(Me.Invoke("GetNCCIClassDescription", objArray)(0), DataSet)
		End Function

		Public Sub GetNCCIClassDescriptionAsync(ByVal strCode As String)
			Me.GetNCCIClassDescriptionAsync(strCode, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetNCCIClassDescriptionAsync(ByVal strCode As String, ByVal userState As Object)
			If (Me.GetNCCIClassDescriptionOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetNCCIClassDescriptionOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetNCCIClassDescriptionOperationCompleted)
			End If
			Dim objArray() As Object = { strCode }
			Me.InvokeAsync("GetNCCIClassDescription", objArray, Me.GetNCCIClassDescriptionOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetOccupancy", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetOccupancy(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetOccupancy", objArray)(0), DataSet)
		End Function

		Public Sub GetOccupancyAsync(ByVal strState As String)
			Me.GetOccupancyAsync(strState, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetOccupancyAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetOccupancyOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetOccupancyOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetOccupancyOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetOccupancy", objArray, Me.GetOccupancyOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetPool", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetPool(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetPool", objArray)(0), DataSet)
		End Function

		Public Sub GetPoolAsync(ByVal strState As String)
			Me.GetPoolAsync(strState, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetPoolAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetPoolOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetPoolOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetPoolOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetPool", objArray, Me.GetPoolOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetProtectionClass", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetProtectionClass(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetProtectionClass", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetProtectionClassAsync(ByVal strState As String)
			Me.GetProtectionClassAsync(strState, Nothing)
		End Sub

		Public Sub GetProtectionClassAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetProtectionClassOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetProtectionClassOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetProtectionClassOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetProtectionClass", objArray, Me.GetProtectionClassOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetProtectiveDevice", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetProtectiveDevice(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetProtectiveDevice", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetProtectiveDeviceAsync(ByVal strState As String)
			Me.GetProtectiveDeviceAsync(strState, Nothing)
		End Sub

		Public Sub GetProtectiveDeviceAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetProtectiveDeviceOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetProtectiveDeviceOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetProtectiveDeviceOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetProtectiveDevice", objArray, Me.GetProtectiveDeviceOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetRoofAgeCreditSurcharge", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetRoofAgeCreditSurcharge(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetRoofAgeCreditSurcharge", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetRoofAgeCreditSurchargeAsync(ByVal strState As String)
			Me.GetRoofAgeCreditSurchargeAsync(strState, Nothing)
		End Sub

		Public Sub GetRoofAgeCreditSurchargeAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetRoofAgeCreditSurchargeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetRoofAgeCreditSurchargeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetRoofAgeCreditSurchargeOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetRoofAgeCreditSurcharge", objArray, Me.GetRoofAgeCreditSurchargeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetStateByZipCodeForALSCGA", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetStateByZipCodeForALSCGA(ByVal strZipcode As String) As DataSet
			Dim objArray() As Object = { strZipcode }
			Return DirectCast(Me.Invoke("GetStateByZipCodeForALSCGA", objArray)(0), DataSet)
		End Function

		Public Sub GetStateByZipCodeForALSCGAAsync(ByVal strZipcode As String)
			Me.GetStateByZipCodeForALSCGAAsync(strZipcode, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetStateByZipCodeForALSCGAAsync(ByVal strZipcode As String, ByVal userState As Object)
			If (Me.GetStateByZipCodeForALSCGAOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetStateByZipCodeForALSCGAOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetStateByZipCodeForALSCGAOperationCompleted)
			End If
			Dim objArray() As Object = { strZipcode }
			Me.InvokeAsync("GetStateByZipCodeForALSCGA", objArray, Me.GetStateByZipCodeForALSCGAOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		<SoapDocumentMethod("http://tempuri.org/GetTerritoryCountyInfo", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetTerritoryCountyInfo(ByVal strZipcode As String) As DataSet
			Dim objArray() As Object = { strZipcode }
			Return DirectCast(Me.Invoke("GetTerritoryCountyInfo", objArray)(0), DataSet)
		End Function

		''' <remarks />
		Public Sub GetTerritoryCountyInfoAsync(ByVal strZipcode As String)
			Me.GetTerritoryCountyInfoAsync(strZipcode, Nothing)
		End Sub

		Public Sub GetTerritoryCountyInfoAsync(ByVal strZipcode As String, ByVal userState As Object)
			If (Me.GetTerritoryCountyInfoOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetTerritoryCountyInfoOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetTerritoryCountyInfoOperationCompleted)
			End If
			Dim objArray() As Object = { strZipcode }
			Me.InvokeAsync("GetTerritoryCountyInfo", objArray, Me.GetTerritoryCountyInfoOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		''' <remarks />
		<SoapDocumentMethod("http://tempuri.org/GetWindDeductableCreditSurcharge", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function GetWindDeductableCreditSurcharge(ByVal strState As String) As DataSet
			Dim objArray() As Object = { strState }
			Return DirectCast(Me.Invoke("GetWindDeductableCreditSurcharge", objArray)(0), DataSet)
		End Function

		Public Sub GetWindDeductableCreditSurchargeAsync(ByVal strState As String)
			Me.GetWindDeductableCreditSurchargeAsync(strState, Nothing)
		End Sub

		''' <remarks />
		Public Sub GetWindDeductableCreditSurchargeAsync(ByVal strState As String, ByVal userState As Object)
			If (Me.GetWindDeductableCreditSurchargeOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.GetWindDeductableCreditSurchargeOperationCompleted = New SendOrPostCallback(AddressOf service.OnGetWindDeductableCreditSurchargeOperationCompleted)
			End If
			Dim objArray() As Object = { strState }
			Me.InvokeAsync("GetWindDeductableCreditSurcharge", objArray, Me.GetWindDeductableCreditSurchargeOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
			Dim flag As Boolean
			If (If(url Is Nothing OrElse CObj(url) = CObj(String.Empty), False, True)) Then
				Dim uri As System.Uri = New System.Uri(url)
				flag = If(If(uri.Port < 1024 OrElse String.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) <> 0, True, False), False, True)
			Else
				flag = False
			End If
			Return flag
		End Function

		<SoapDocumentMethod("http://tempuri.org/isUnderwriter", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=SoapBindingUse.Literal, ParameterStyle:=SoapParameterStyle.Wrapped)>
		Public Function isUnderwriter(ByVal IpAddress As String) As Boolean
			Dim objArray() As Object = { IpAddress }
			Dim objArray1 As Object() = Me.Invoke("isUnderwriter", objArray)
			Return Conversions.ToBoolean(objArray1(0))
		End Function

		''' <remarks />
		Public Sub isUnderwriterAsync(ByVal IpAddress As String)
			Me.isUnderwriterAsync(IpAddress, Nothing)
		End Sub

		Public Sub isUnderwriterAsync(ByVal IpAddress As String, ByVal userState As Object)
			If (Me.isUnderwriterOperationCompleted Is Nothing) Then
				Dim service As GarageQuoteSheetDLL.SIUService.Service = Me
				Me.isUnderwriterOperationCompleted = New SendOrPostCallback(AddressOf service.OnisUnderwriterOperationCompleted)
			End If
			Dim objArray() As Object = { IpAddress }
			Me.InvokeAsync("isUnderwriter", objArray, Me.isUnderwriterOperationCompleted, RuntimeHelpers.GetObjectValue(userState))
		End Sub

		Private Sub OnGetBuiltYearCreditSurchargeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetBuiltYearCreditSurchargeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetBuiltYearCreditSurchargeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetConstructionTypeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetConstructionTypeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetConstructionTypeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetCountyByZipCodeForALOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetCountyByZipCodeForALOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetCountyByZipCodeForALOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetCountyByZipCodeForSCOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetCountyByZipCodeForSCOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetCountyByZipCodeForSCOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetCountyOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetCountyOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetCountyOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetLookupDataByStateCodeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetLookupDataByStateCodeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetLookupDataByStateCodeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetLookupDataOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetLookupDataOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetLookupDataOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetNCCIClassCodeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetNCCIClassCodeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetNCCIClassCodeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetNCCIClassDescriptionOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetNCCIClassDescriptionOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetNCCIClassDescriptionOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetOccupancyOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetOccupancyOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetOccupancyOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetPoolOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetPoolOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetPoolOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetProtectionClassOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetProtectionClassOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetProtectionClassOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetProtectiveDeviceOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetProtectiveDeviceOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetProtectiveDeviceOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetRoofAgeCreditSurchargeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetRoofAgeCreditSurchargeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetRoofAgeCreditSurchargeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetStateByZipCodeForALSCGAOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetStateByZipCodeForALSCGAOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetStateByZipCodeForALSCGAOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetTerritoryCountyInfoOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetTerritoryCountyInfoOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetTerritoryCountyInfoOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnGetWindDeductableCreditSurchargeOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnGetWindDeductableCreditSurchargeOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnGetWindDeductableCreditSurchargeOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub OnisUnderwriterOperationCompleted(ByVal arg As Object)
			' 
			' Current member / type: System.Void GarageQuoteSheetDLL.SIUService.Service::OnisUnderwriterOperationCompleted(System.Object)
			' File path: C:\Source\Conversion3\DLL\GarageQuoteSheetDLL\GarageQuoteSheetDLL.dll
			' 
			' Product version: 2017.1.116.2
			' Exception in: System.Void OnisUnderwriterOperationCompleted(System.Object)
			' 
			' Visual Basic does not support this type of event usage. Please, try using other language.
			'    at ...( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 210
			'    at ..(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 537
			'    at ...(BinaryExpression ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
			'    at ..(IfStatement ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 398
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
			'    at ..Visit(IEnumerable ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 374
			'    at ..( ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 379
			'    at ..Visit(ICodeNode ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
			'    at ..(DecompilationContext ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
			'    at ..(MethodBody ,  , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		''' <remarks />
		Public Event GetBuiltYearCreditSurchargeCompleted As GetBuiltYearCreditSurchargeCompletedEventHandler

		''' <remarks />
		Public Event GetConstructionTypeCompleted As GetConstructionTypeCompletedEventHandler

		''' <remarks />
		Public Event GetCountyByZipCodeForALCompleted As GetCountyByZipCodeForALCompletedEventHandler

		Public Event GetCountyByZipCodeForSCCompleted As GetCountyByZipCodeForSCCompletedEventHandler

		Public Event GetCountyCompleted As GetCountyCompletedEventHandler

		Public Event GetLookupDataByStateCodeCompleted As GetLookupDataByStateCodeCompletedEventHandler

		''' <remarks />
		Public Event GetLookupDataCompleted As GetLookupDataCompletedEventHandler

		Public Event GetNCCIClassCodeCompleted As GetNCCIClassCodeCompletedEventHandler

		''' <remarks />
		Public Event GetNCCIClassDescriptionCompleted As GetNCCIClassDescriptionCompletedEventHandler

		''' <remarks />
		Public Event GetOccupancyCompleted As GetOccupancyCompletedEventHandler

		''' <remarks />
		Public Event GetPoolCompleted As GetPoolCompletedEventHandler

		Public Event GetProtectionClassCompleted As GetProtectionClassCompletedEventHandler

		Public Event GetProtectiveDeviceCompleted As GetProtectiveDeviceCompletedEventHandler

		Public Event GetRoofAgeCreditSurchargeCompleted As GetRoofAgeCreditSurchargeCompletedEventHandler

		''' <remarks />
		Public Event GetStateByZipCodeForALSCGACompleted As GetStateByZipCodeForALSCGACompletedEventHandler

		Public Event GetTerritoryCountyInfoCompleted As GetTerritoryCountyInfoCompletedEventHandler

		''' <remarks />
		Public Event GetWindDeductableCreditSurchargeCompleted As GetWindDeductableCreditSurchargeCompletedEventHandler

		Public Event isUnderwriterCompleted As isUnderwriterCompletedEventHandler
	End Class
End Namespace