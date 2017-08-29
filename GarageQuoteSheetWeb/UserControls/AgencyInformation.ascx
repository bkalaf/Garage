<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AgencyInformation.ascx.vb" Inherits="UserControls947.AgencyInformation" %>
   
               <table width="800" border="0" cellspacing="0" cellpadding="0" background="images/formback.jpg">

				<tr>
					<td align="center">
						
							<fieldset>
								<legend>Agency Information</legend>
								<ol>
								<li>
                                  
                            
                               
                                <table style="width: 680px;" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                    <tr>
                                        <td align="Left">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span> <strong>Agency #:</strong>
                                        </td>
                                        <td align="Left">
                                            <asp:Label ID="lblAgency" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        
                                    </tr>
                                    <tr>
                                        <td align="Left">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Name:</strong>
                                            </td>
                                        <td align="Left">
                                            <asp:Label ID="lblAgencyName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                            </td>
                                    </tr>
                                    <tr id="trAgentStatus" runat="server" >
                                        <td align="Left">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Status:</strong>
                                            </td>
                                        <td align="Left">
                                            <asp:Label ID="lblAgentStatus" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="Left">
                                            <span style="color: #ff0000">*</span> Contact:</td>
                                        <td align="Left">
                                            <asp:TextBox ID="txtContact" runat="server" MaxLength="100" Width="244px" /></td>
                                    </tr>
                                    <tr>
                                        <td align="Left">
                                            <span style="color: #ff0000">*</span> Phone</td>
                                        <td align="Left" >
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" Width="244px" /><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone"
                                                ErrorMessage="Invalid Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone No. can not be blank">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="left" ><span style="color: #ff0000">&nbsp;&nbsp;</span>
                                        How do you want your quote replied ?
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlReplyOptions" runat="server" Width="74px" AutoPostBack="True">
                                            <asp:ListItem>Email</asp:ListItem>
                                            <asp:ListItem>Fax</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                   <tr>
                                        <td align="Left">
                                            &nbsp;&nbsp; Email/Fax:</td>
                                        <td align="Left" ><asp:TextBox ID="txtFaxNo" runat="server" CssClass="text" Width="244px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regxvEmailOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                 <asp:RegularExpressionValidator
                                                ID="regxvFaxOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Enabled="False" Width="1px">*</asp:RegularExpressionValidator></td>
                                   </tr>                                </table>
                          </li></ol>
							</fieldset>
													
					</td>
				</tr>
			</table>
				
		

                       
            
													
					