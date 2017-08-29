<%@ Control Language="VB" AutoEventWireup="false" CodeFile="H03Quotecontrol.ascx.vb" Inherits="UserControlH03.H03Quotecontrol" %>
<asp:UpdatePanel ID="quotectl" runat="server">
<ContentTemplate>


<fieldset>
    <legend><strong>Quote </strong></legend>
    <table border="0" cellpadding="0" cellspacing="0" class="fieldset" style="width: 680px; height: 240px">
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Total of Base Premium:</td>
            <td align="left">
                 <asp:TextBox ID="txttotbasePre" runat="server" CssClass="TextBox" Width="100px" Text="0.00" Enabled="False" ></asp:TextBox>
            <asp:RequiredFieldValidator
                 ID="Rfvtotbase" runat="server" ControlToValidate="txttotbasePre" ErrorMessage="Total Base Premium cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px; height: 24px;">
                <span style="color: #ff0000">*</span> Sum of additional premiums:</td>
            <td align="left" style="height: 24px">
                <asp:TextBox ID="txtaddpre" runat="server" Width="100px" Text="0.00" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvaddpre" runat="server" ControlToValidate="txtaddpre" ErrorMessage="Sum of additional Premium cannot be blank(Quote Details)">*</asp:RequiredFieldValidator></td>
                <td align="left" style="height: 24px">
               
                <asp:button ID="btnCalculatePremium" runat="server" text="Calculate Premium"></asp:button>
                
                </td>
                
        </tr>
        <tr>
            <td align="left" style="width: 300px; height: 24px;">
                <span style="color: #ff0000">*</span> Premium:</td>
             <td align="left" style="height: 24px">
                 <asp:TextBox ID="txttotpre" runat="server" Width="100px" OnTextChanged="txttotpre_TextChanged" AutoPostBack="True" Enabled="False">0.00</asp:TextBox>
                  <asp:RequiredFieldValidator
                 ID="rfvtotpre" runat="server" ControlToValidate="txttotpre" ErrorMessage="Total Premium cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Total credits and/or surcharges:</td>
            <td align="left">
                <asp:TextBox ID="txttotcredits" runat="server" Width="100px" Text="0.00" AutoPostBack="true" OnTextChanged="txtunderwriters_TextChanged" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvtotcredits" runat="server" ControlToValidate="txttotcredits" ErrorMessage="Total credits/surcharges cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px; height: 24px;">
                <span style="color: #ff0000">*</span> Underwriters discretion:</td>
            <td align="left" style="color: #ff0000; height: 24px;">
                <asp:TextBox ID="txtunderwriters" runat="server" Width="100px" Text="0.00" AutoPostBack="True"  OnTextChanged="txtunderwriters_TextChanged" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvunderwriter" runat="server" ControlToValidate="txtunderwriters" ErrorMessage="Underwriters discretion cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
         <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Total Premium:</td>
            <td align="left" style="color: #ff0000">
                <asp:TextBox ID="txttotpremium" runat="server" Width="100px" Text="0.00" AutoPostBack="True" OnTextChanged="txtunderwriters_TextChanged" Enabled="False" ></asp:TextBox>
                 <asp:RequiredFieldValidator
                 ID="rfvtotpremium" runat="server" ControlToValidate="txttotpremium" ErrorMessage="Total Premium cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Policy and inspection fee:</td>
            <td align="left" style="color: #ff0000; height: 19px;">
                <asp:TextBox ID="txtpolicy" runat="server" Width="100px" Text="135.00" AutoPostBack="True" OnTextChanged="txtunderwriters_TextChanged" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvpo" runat="server" ControlToValidate="txtpolicy" ErrorMessage="Policy and inspection cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
       
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Surplus Lines Tax:</td>
            <td align="left" style="height: 19px">
                <asp:TextBox ID="txtsalestax" runat="server" Width="100px" Text="0.00" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvsalestax" runat="server" ControlToValidate="txtsalestax" ErrorMessage="Sales Tax cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> FSLSO:</td>
            <td align="left" style="height: 19px">
                <asp:TextBox ID="txtfslso" runat="server" Width="100px" Text="0.00" Enabled="False"></asp:TextBox>
                 <asp:RequiredFieldValidator
                 ID="rfvfslso" runat="server" ControlToValidate="txtfslso" ErrorMessage="FSLSO cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> FHCF:</td>
            <td align="left">
                <asp:TextBox ID="txtfhcf" runat="server" Width="100px" Text="0.00" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvfhcf" runat="server" ControlToValidate="txtfhcf" ErrorMessage="FHCF cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> CPICA</td>
            <td align="left">
                <asp:TextBox ID="txtcpica" runat="server" Width="100px" Text="0.00" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvcpica" runat="server" ControlToValidate="txtcpica" ErrorMessage="CPICA cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> EMG</td>
            <td align="left">
                <asp:TextBox ID="txtemg" runat="server" Width="100px" Text="0.00" Enabled="False" ></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvemg" runat="server" ControlToValidate="txtemg" ErrorMessage="EMG cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Grand Total</td>
            <td align="left">
                <asp:TextBox ID="txtgrandtot" runat="server" Width="100px" Text="135.00" ReadOnly="false" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator
                 ID="rfvgrndtot" runat="server" ControlToValidate="txtgrandtot" ErrorMessage="Grand total cannot be blank(Quote Details)">*</asp:RequiredFieldValidator>
                 </td>
        </tr>
       
        
    </table>
</fieldset>
</ContentTemplate>
<Triggers><asp:PostBackTrigger ControlID="btnCalculatePremium" />
<asp:PostBackTrigger ControlID="txtunderwriters" />
<asp:PostBackTrigger ControlID="txttotcredits" />
<asp:PostBackTrigger ControlID="txtpolicy" />
</Triggers>
</asp:UpdatePanel>
