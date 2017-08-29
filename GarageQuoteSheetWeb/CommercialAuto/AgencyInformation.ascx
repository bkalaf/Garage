<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AgencyInformation.ascx.vb" Inherits="UserControl947.AgencyInformation" %>
<%@ Register Assembly="AjaxControlToolkit" NameSpace="AjaxControlToolkit" TagPrefix="cc1" %>

  
<fieldset>                				
<legend><strong>Agency Information </strong></legend>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
<table style="width: 680px;" border="0" cellpadding="0" cellspacing="0" class="fieldset">
<tr>
<td align="Left" style="height: 22px; width: 300px;">
    <span style="color: #ff0000">&nbsp;&nbsp;</span> <strong>Agency #:</strong>
</td>
<td align="Left" style="height: 23px">
    <asp:Label ID="lblAgency" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>

</tr>
<tr>
<td align="Left" style="width: 300px; height: 22px">
    <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Name:</strong>
    </td>
<td align="Left"  style="height: 22px">
    <asp:Label ID="lblAgencyName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
    </td>
</tr>
<tr id="trAgentStatus" runat="server" >
<td align="Left" style="width: 300px; height: 22px">
    <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Status:</strong>
    </td>
<td align="Left"  style="height: 22px">
    <asp:Label ID="lblAgentStatus" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
    </td>
</tr>
<tr>
<td align="Left" style="width: 300px; height: 22px">
    <span style="color: #ff0000">*</span> Contact:</td>
<td align="Left"  style="height: 24px">
    <asp:TextBox ID="txtContact" runat="server" MaxLength="100" Width="244px" TabIndex="1" />
     <asp:RequiredFieldValidator ID="rfvcontact" runat="server" ControlToValidate="txtContact"
        ErrorMessage="Please Enter Contact">*</asp:RequiredFieldValidator></td>
</tr>

<tr>
<td align="Left" style="width: 300px; height: 22px"><span style=" color :#ff0000">*</span> Phone:<font size="2" name="arial">(NNN-NNN-NNNN)</font></td>
 <td align="Left" style="height: 24px" >
   <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" class="text input_mask mask_phone" TabIndex="2"></asp:TextBox>
     <asp:RequiredFieldValidator ID="rfvtxtphone" runat="server" ControlToValidate="txtPhone"
        ErrorMessage="Please Enter Phone">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
        ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
        ErrorMessage="Invalid Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPhone" Mask="999-999-9999" ClearMaskOnLostFocus="false">
    </cc1:MaskedEditExtender>
     <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtPhone"></cc1:MaskedEditValidator></td>
</tr>
<tr>
<td align="left" style="width: 300px; height: 22px"><span style="color: #ff0000">&nbsp;&nbsp;</span>
How do you want your quote replied ?
</td>
<td align="left">
 
    <asp:DropDownList ID="ddlReplyOptions" runat="server" Width="74px" AutoPostBack="True" TabIndex="3">
    <asp:ListItem>Email</asp:ListItem>
    <asp:ListItem>Fax</asp:ListItem>
</asp:DropDownList>

        
</td>
</tr>
<tr>
<td align="Left" style="width: 300px; height: 22px">
    &nbsp;&nbsp; Email/Fax:</td>
    <td align="Left" ><asp:TextBox ID="txtFaxNo" runat="server" CssClass="text" MaxLength="12" class="text input_mask mask_phone" TabIndex="4"></asp:TextBox><asp:TextBox ID="txtemail" runat="server" CssClass="text" TabIndex="4"></asp:TextBox>
    <asp:RegularExpressionValidator ID="regxvEmailOption" runat="server" ControlToValidate="txtemail"
        ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
         <asp:RegularExpressionValidator
        ID="regxvFaxOption" runat="server" ControlToValidate="txtFaxNo"
        ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"  Width="1px">*</asp:RegularExpressionValidator>
        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFaxNo" Mask="999-999-9999" ClearMaskOnLostFocus="false">
    </cc1:MaskedEditExtender>
     <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtFaxNo"></cc1:MaskedEditValidator></td> 
 </tr>
 <tr>
    <td align="Left" style="width: 300px; height: 22px">&nbsp;&nbsp;
        <asp:Label ID="lblUnderwriter" runat="server" Text="Underwriter Name" Visible="false"></asp:Label></td>
    <td align="Left"><asp:TextBox ID="txtUnderwriteName" runat="server" Visible="false" CssClass="text" MaxLength="150"  TabIndex="4"></asp:TextBox>
       </td>
 </tr>
 <tr>
    <td align="Left" style="width: 300px; height: 22px">&nbsp;&nbsp;
        <asp:Label ID="lblUWEmail" runat="server" Text="Underwriter Email" Visible="false"></asp:Label></td>
    <td align="Left"><asp:TextBox ID="txtunderwriteremail" runat="server" Visible="false" CssClass="text" MaxLength="244"  TabIndex="4"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqvUWEmail" runat="server" ControlToValidate="txtunderwriteremail"
        ErrorMessage="Please Enter UnderwriterEmail">*</asp:RequiredFieldValidator></td>
     <asp:RegularExpressionValidator ID="rgvUWEmail" runat="server" ControlToValidate="txtunderwriteremail"
        ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>  </td>
 </tr>
 <tr>
    <td colspan="2" align="left" valign="top">
        <asp:Panel ID="pnlAgentInformation" runat="server" Visible="False">
            <table>
                <tr>
                    <td align="Left" style="width: 300px; height: 22px">&nbsp;&nbsp;Select Agent/CSR</td>
                    <td align="left"><asp:DropDownList ID="ddlAgentCSR" TabIndex="4" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAgentCSR_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="Left" style="width: 300px; height: 22px"><span style="color: #ff0000">*</span>&nbsp;First Name</td>
                    <td align="left">
                    <asp:TextBox ID="txtFName" runat="server" TabIndex="4" CssClass="text" ReadOnly="true"></asp:TextBox>                    
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 300px; height: 22px"><span style="color: #ff0000">*</span>&nbsp;Last Name</td>
                    <td align="left"><asp:TextBox ID="txtLName" TabIndex="4" runat="server" CssClass="text" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="Left" style="width: 300px; height: 22px"><span style="color: #ff0000">*</span>&nbsp;SSN #</td>
                    <td align="left"><asp:TextBox ID="txtSSN" TabIndex="4" runat="server" onkeypress="JavaScript:CheckNumeric()"  ReadOnly="true" MaxLength="4" Width="69px"></asp:TextBox>(Last 4 digits)</td>
                </tr>
            </table>
        </asp:Panel>
    </td>
 </tr>
     </table>

 </ContentTemplate>
  <Triggers><asp:PostBackTrigger ControlID="ddlReplyOptions" /></Triggers>
  <Triggers><asp:PostBackTrigger ControlID="ddlAgentCSR" /></Triggers>
</asp:UpdatePanel>
</fieldset>