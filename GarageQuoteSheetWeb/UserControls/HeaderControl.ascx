<%@ Control Language="VB" AutoEventWireup="False" CodeFile="HeaderControl.ascx.vb"
    Inherits="UserControls947.HeaderControl" %>
<table width="900" border="0" cellspacing="0" cellpadding="0" background="images/headerback.jpg"
    height="150">
    <tr>
        <td align="left" valign="top">
            <h1>
                <asp:Label ID="TitleLabel" runat="server" />
            </h1>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                ID="lblFor" runat="server" Font-Bold="True" ForeColor="White" />
        </td>
    </tr>
</table>
<table width="850" border="0" cellspacing="0" cellpadding="0">
    <tr height="30">
        <td width="1050" background="images/navback.jpg" style="height: 30px; text-align: center;padding-right: 67px;">
            <a href="http://www.siuins.com/SIURATE/pages/homepage.aspx" class="DashboardButton"
                style="padding-left: 29px; color:blue; text-decoration: underline; background-color: Transparent !important;">
                <b style="font-size: medium;">SiuRate</b></a>
            <div align="center">
                <ul id="nav">
                </ul>
            </div>
        </td>
    </tr>
</table>
