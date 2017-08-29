<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportViewer.aspx.vb" ValidateRequest="false"  Inherits="Report_ReportViewer" %>

<%--@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>--%>
 <%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home Owner</title>
</head>
<body>
    
    <form id="frmMain" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrptViewer" runat="server" AutoDataBind="true" HasCrystalLogo="False" HasExportButton="True" Font-Size="Medium" Height="650px" Width="800px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
     </div>
    </form>
</body>
</html>
