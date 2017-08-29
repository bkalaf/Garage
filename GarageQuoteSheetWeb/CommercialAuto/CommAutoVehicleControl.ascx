<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommAutoVehicleControl.ascx.vb"
    Inherits="UserControl947.CommAutoVehicleControl" %>
<script language="javascript" type="text/javascript">
		
		    function validateYYYY( src, args)
		    {
		       var MMYYYY=args.Value;
              var serverMMYYYY ="<%=MMYYYY %>".split("/"); //new Date(); 
//              var MM=serverMMYYYY[0];

var YY=serverMMYYYY[1]; 
 
if(MMYYYY.length <=0)
args.IsValid = false; 

else if ((eval(MMYYYY) >YY) || (eval(MMYYYY) < 1900) || (eval(MMYYYY).length < 4) )
args.IsValid = false; 
		    }
</script>

<fieldset>
    <legend><strong>Vehicle Information - Power Units and Trailers</strong></legend>
    <table style="width: 680px; height: 400px" border="0" cellpadding="0" cellspacing="0"
        class="fieldset">
        <tr>
            <td style="width: 132px; height: 50px; valign: top">
                Year (yyyy)
            </td>
            <td>
                Make
            </td>
            <td>
                GVW
            </td>
            <td>
                Type
            </td>
            <td>
                Stated Value
            </td>
            <td>
                Deductible
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear1" runat="server" Width="100px" MaxLength="4" TabIndex="26"></asp:TextBox>           
            </td>
            <td valign="top">
                <asp:TextBox ID="txtmake1" runat="server" MaxLength="80" Width="100px" TabIndex="27" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW1" runat="server" MaxLength="80" Width="100px" TabIndex="28" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype1" runat="server" MaxLength="80" Width="100px" TabIndex="29"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue1" runat="server" MaxLength="80" Width="100px" TabIndex="30" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible1" TabIndex="31">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear2" runat="server" MaxLength="4" Width="100px" TabIndex="32" />           
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake2" runat="server" MaxLength="80" Width="100px" TabIndex="33" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW2" runat="server" MaxLength="80" Width="100px" TabIndex="34" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype2" runat="server" MaxLength="80" Width="100px" TabIndex="35"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue2" runat="server" MaxLength="80" Width="100px" TabIndex="36" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible2" TabIndex="37">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear3" runat="server" MaxLength="4" Width="100px" TabIndex="38" />           
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake3" runat="server" MaxLength="80" Width="100px" TabIndex="39" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW3" runat="server" MaxLength="80" Width="100px" TabIndex="40" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype3" runat="server" MaxLength="80" Width="100px" TabIndex="41"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue3" runat="server" MaxLength="80" Width="100px" TabIndex="42" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible3" TabIndex="43">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear4" runat="server" MaxLength="4" Width="100px" TabIndex="44" />             
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake4" runat="server" MaxLength="80" Width="100px" TabIndex="45" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW4" runat="server" MaxLength="80" Width="100px" TabIndex="46" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype4" runat="server" MaxLength="80" Width="100px" TabIndex="47"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue4" runat="server" MaxLength="80" Width="100px" TabIndex="48" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible4" TabIndex="49">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear5" runat="server" MaxLength="4" Width="100px" TabIndex="50" />            
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake5" runat="server" MaxLength="80" Width="100px" TabIndex="51" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW5" runat="server" MaxLength="80" Width="100px" TabIndex="52" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype5" runat="server" MaxLength="80" Width="100px" TabIndex="53"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue5" runat="server" MaxLength="80" Width="100px" TabIndex="54" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible5" TabIndex="55">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear6" runat="server" MaxLength="4" Width="100px" TabIndex="56" />              
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake6" runat="server" MaxLength="80" Width="100px" TabIndex="57" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW6" runat="server" MaxLength="80" Width="100px" TabIndex="58" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype6" runat="server" MaxLength="80" Width="100px" TabIndex="59"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue6" runat="server" MaxLength="80" Width="100px" TabIndex="60" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible6" TabIndex="61">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear7" runat="server" MaxLength="4" Width="100px" TabIndex="62" />               
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake7" runat="server" MaxLength="80" Width="100px" TabIndex="63" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW7" runat="server" MaxLength="80" Width="100px" TabIndex="64" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype7" runat="server" MaxLength="80" Width="100px" TabIndex="65"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue7" runat="server" MaxLength="80" Width="100px" TabIndex="66" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible7" TabIndex="67">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear8" runat="server" MaxLength="4" Width="100px" TabIndex="68" />           
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake8" runat="server" MaxLength="80" Width="100px" TabIndex="69" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW8" runat="server" MaxLength="80" Width="100px" TabIndex="70" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype8" runat="server" MaxLength="80" Width="100px" TabIndex="71"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue8" runat="server" MaxLength="80" Width="100px" TabIndex="72" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible8" TabIndex="73">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear9" runat="server" MaxLength="4" Width="100px" TabIndex="74" />             
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake9" runat="server" MaxLength="80" Width="100px" TabIndex="75" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW9" runat="server" MaxLength="80" Width="100px" TabIndex="76" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype9" runat="server" MaxLength="80" Width="100px" TabIndex="77"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue9" runat="server" MaxLength="80" Width="100px" TabIndex="78" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible9" TabIndex="79">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 132px; height: 35px;">
                <asp:TextBox ID="txyear10" runat="server" Width="100px" MaxLength="4" TabIndex="80" />          
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMake10" runat="server" MaxLength="80" Width="100px" TabIndex="81" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txtGVW10" runat="server" MaxLength="80" Width="100px" TabIndex="82" />
            </td>
            <td valign="top">
                <asp:TextBox ID="txttype10" runat="server" MaxLength="80" Width="100px" TabIndex="83"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtstatedvalue10" runat="server" MaxLength="80" Width="100px" TabIndex="84" />
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="ddldeductible10" TabIndex="85">
                    <asp:ListItem Value="0">Select One</asp:ListItem>
                    <asp:ListItem Value="1">500</asp:ListItem>
                    <asp:ListItem Value="2">1000</asp:ListItem>
                    <asp:ListItem Value="3">2500</asp:ListItem>
                    <asp:ListItem Value="4">5000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</fieldset>
