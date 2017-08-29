Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace GarageQuoteSheetDLL.My
	<CompilerGenerated>
	<EditorBrowsable(EditorBrowsableState.Advanced)>
	<GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")>
	Friend NotInheritable Class MySettings
		Inherits ApplicationSettingsBase
		Private Shared defaultInstance As MySettings

		Public ReadOnly Shared Property [Default] As MySettings
			Get
				Return MySettings.defaultInstance
			End Get
		End Property

		<ApplicationScopedSetting>
		<DebuggerNonUserCode>
		<DefaultSettingValue("http://siuweb1ex/siuservices/service.asmx")>
		<SpecialSetting(SpecialSetting.WebServiceUrl)>
		Public ReadOnly Property GarageQuoteSheetDLL_SIUService_Service As String
			Get
				Return Conversions.ToString(Me("GarageQuoteSheetDLL_SIUService_Service"))
			End Get
		End Property

		Shared Sub New()
			MySettings.defaultInstance = DirectCast(SettingsBase.Synchronized(New MySettings()), MySettings)
		End Sub

		<DebuggerNonUserCode>
		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace