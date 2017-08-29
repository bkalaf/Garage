<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popup.aspx.vb" Inherits="popup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .DashboardButton
        {
            border-radius: 3px;
            height: 30px;
            width: 100px;
            text-align: center;
            font-size: 14px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="mpeConfirm" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlpopup" CancelControlID="btnclose" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="Transparent" Height="184px" Width="440px"
            CssClass="panel">
            <table width="100%" style="border: Solid 2px #d07c00; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0">
                <tr style="background-color: #e9c002;">
                    <td style="height: 10%; color: White; font-weight: bold; padding: 3px; font-size: larger;
                        font-family: Calibri" align="Left">
                        Confirmation
                    </td>
                    <td style="color: White; font-weight: bold; padding: 3px; font-size: larger;" align="Right">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding: 5px; font-family: Verdana; font-size: 14px;">
                        <b>Your request for quote has been processed. Thank You
                            <br />
                            for your Submission</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td width="50%" style="text-align: center;">
                                    <asp:Button ID="btnPrint" OnClientClick="javascript:window.print();" Text="Print"
                                        CssClass="DashboardButton" runat="server" CausesValidation="false" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" CausesValidation="false"
                                        CssClass="DashboardButton" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button runat="server" ID="Show" Text="Show Popup" />
    </div>
    </form>
</body>
</html>
