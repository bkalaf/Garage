<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DriverInfo.aspx.vb" Inherits="DriverInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
                                            <td style="width: 118px; height: 15px;">
                                                Name</td>
                                            <td style="width: 108px; height: 15px;">
                                                Date of Birth</td>
                                            <td style="width: 104px; height: 15px;">
                                                Years of Experience</td>
        <td style="width: 100px; height: 15px">
            Hire Date</td>
                                            <td style="width: 100px; height: 15px;">
                                                Any Accidents</td>
                                            <td style="width: 100px; height: 15px;">
                                                Tickets</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px">
                                                <asp:TextBox ID="txtName1" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom1);return false;" href="javascript:void(0)"><img alt="click" src="includes/calbtn.gif" width="10"/></a></td>
                                            <td style="width: 108px">
                                                <asp:TextBox ID="txtTermto1" runat="server" Width="70px" MaxLength="10" />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto1);return false;" href="javascript:void(0)"></a></td>
                                            <td style="width: 104px">
                                                <asp:TextBox ID="txtCarrier1" runat="server" Width="40px" MaxLength="25" /></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="TextBox1" runat="server" Width="70px"></asp:TextBox></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtAmtpaid1" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid1" runat="server" ControlToValidate="txtAmtpaid1"
                                                    ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtMplDetails1" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="61px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px">
                                                <asp:TextBox ID="txtName2" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom2);return false;" href="javascript:void(0)"></a></td>
                                            <td style="width: 108px">
                                                <asp:TextBox ID="txtTermto2" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto2);return false;" href="javascript:void(0)"></a></td>
                                            <td style="width: 104px">
                                                <asp:TextBox ID="txtCarrier2" runat="server" Width="40px" MaxLength="25" /></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="TextBox2" runat="server" Width="70px"></asp:TextBox></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtAmtpaid2" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid2" runat="server" ControlToValidate="txtAmtpaid2"
                                                    ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtMplDetails2" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px">
                                                <asp:TextBox ID="txtName3" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom3);return false;" href="javascript:void(0)"></a></td>
                                            <td style="width: 108px">
                                                <asp:TextBox ID="txtTermto3" runat="server" Width="70px" MaxLength="10" />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto3);return false;" href="javascript:void(0)"></a></td>
                                            <td style="width: 104px">
                                                <asp:TextBox ID="txtCarrier3" runat="server" Width="40px" MaxLength="25" /></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="TextBox3" runat="server" Width="70px"></asp:TextBox></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtAmtpaid3" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid3" runat="server" ControlToValidate="txtAmtpaid3"
                                                    ErrorMessage="InvalidAmount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtMplDetails3" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
                                        </tr>
        <tr>
            <td style="width: 118px">
                <asp:TextBox ID="txtName4" runat="server" Width="70px" MaxLength="10"  /></td>
            <td style="width: 108px">
                <asp:TextBox ID="TextBox6" runat="server" Width="70px" MaxLength="10" /></td>
            <td style="width: 104px">
                <asp:TextBox ID="TextBox8" runat="server" Width="40px" MaxLength="25" /></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox10" runat="server" Width="70px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox12" runat="server" Width="64px" MaxLength="9" /></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox14" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:TextBox ID="TextBox5" runat="server" Width="70px" MaxLength="10"  /></td>
            <td style="width: 108px">
                <asp:TextBox ID="TextBox7" runat="server" Width="70px" MaxLength="10" /></td>
            <td style="width: 104px">
                <asp:TextBox ID="TextBox9" runat="server" Width="40px" MaxLength="25" /></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox11" runat="server" Width="70px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox13" runat="server" Width="64px" MaxLength="9" /></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox15" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
        </tr>
    </table>
    </div>
    </form>
<iframe name="gToday:normal:agenda.js" id="gToday:normal:agenda.js"
src="includes/ipopeng.htm" scrolling="no" frameborder="0"
style="visibility:visible; z-index:999; position:absolute; top:-500px; left:-500px;">
<layer name="gToday:normal:agenda.js" src="npopeng.htm" background="npopeng.htm">     </LAYER>
</iframe></body>
</html>
