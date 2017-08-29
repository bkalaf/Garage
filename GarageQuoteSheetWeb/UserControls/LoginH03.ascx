<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LoginH03.ascx.vb" Inherits="Usercontrols947.LoginH03" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

  <table width="850" border="0" cellspacing="0" cellpadding="0" background="images/formback.jpg">

				<tr>
					<td align="center" valign="top" style=" width: 650px;">
						
							<fieldset style="left: 0px; top: 0px">
								<legend>Agency Information</legend>
								<ol>
								<li>
                                   <table style="width: 472px">
                                   <tr>
                                       <td colspan="2"  ><asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                       </td>
                                   </tr>
                                   <tr>
                                       <td colspan="2" align="center"><asp:Label ID="lblMessage" Width="450px"  runat="server" ForeColor="red"></asp:Label></td>
                                   </tr>
                                   <tr>
                                       <td><label for="txtCode"><span style=" color :Red">*</span>Agency Code:</label>
                                       </td>
                                       <td align="left"><asp:TextBox ID="txtCode" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="Please enter AgentCode">*</asp:RequiredFieldValidator></td>
                                   </tr>
                                   <tr>
                                        <td><label for="txtRequester"><span style=" color :Red">*</span>Person Requesting:</label></td>
                                        <td align="left"><asp:TextBox ID="txtRequester" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequester"
                                                ErrorMessage="Please Enter Person Requesting">*</asp:RequiredFieldValidator></td>
                                   </tr>
                                  <tr>
                                        <td align="left"><label for="txtPhone"><span style=" color :Red">*</span>Phone:<br/>(NNN-NNN-NNNN)</label></td>
                                         <td align="Left" >
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" class="text input_mask mask_phone"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="rfvtxtphone" runat="server" ControlToValidate="txtPhone"
                                                ErrorMessage="Please Enter Phone">*</asp:RequiredFieldValidator>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPhone" Mask="999-999-9999" ClearMaskOnLostFocus="false">
                                            </cc1:MaskedEditExtender>
                                             <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtPhone"></cc1:MaskedEditValidator></td>
                                           
                                   </tr>
                                    <tr>
                                        <td><label for="optionemailfax">How do you want your quote replied?:</label></td>
                                        <td align="left"><asp:DropDownList ID="ddlReplyOptions" runat="server" Width="208px" AutoPostBack="True">
                                            <asp:ListItem>Email</asp:ListItem>
                                            <asp:ListItem>Fax</asp:ListItem>
                                        </asp:DropDownList></td>
                                   </tr>
                                   <tr>
                                        <td><label for="fax"><span style=" color :Red">*</span>Email/Fax:</label></td>
                                        <td align="left"><asp:TextBox ID="txtFaxNo" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regxvEmailOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid EmailId " ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator
                                                ID="regxvFaxOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Enabled="False" Width="1px">*</asp:RegularExpressionValidator></td>
                                   </tr>
                                  
                                   <tr>
                                    <td colspan="2" align="center" ><asp:Button ID="btnSubmit" runat="server" Text="Continue" /></td>
                                   </tr>
                                   </table></li></ol>
							</fieldset>
													
					</td>
				</tr>
			</table>
				
		

        