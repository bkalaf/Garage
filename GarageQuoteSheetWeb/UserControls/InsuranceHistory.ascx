<%@ Control Language="VB" AutoEventWireup="false" CodeFile="InsuranceHistory.ascx.vb" Inherits="UserControls947.InsuranceHistory" %>
 <table width="800" border="0" cellspacing="0" cellpadding="0" background="images/formback.jpg">

				<tr>
					<td>
<asp:Panel ID="pnlInsuranceHistory" runat="server">
                                <fieldset>
                                    <legend><strong>Insurance History</strong></legend>
                                    <table  border="0" cellpadding="0" cellspacing="0"
                                        class="fieldset">
                                        <tr>
                                            <td colspan="5">
                                                <table>
                                                    <tr>
                                                        <td  align="left">
                                                        </td>
                                                        <td align="center" width="50">
                                                            Yes</td>
                                                        <td align="center" width="50">
                                                            No</td>
                                                        <td style="width: 360px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <span style="color: #ff0000">*</span>Previous Policy Cancelled:
                                                            <br/>&nbsp;&nbsp;<span style="color: #ff0000; font-size:small">(If Yes, Please explain)</span></td>
                                                        <td align="center" >
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyCnYes" GroupName="PrePolicyCn" Style="width: 18px"
                                                                Width="45px" /></td>
                                                        <td align="center">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyCnNo" GroupName="PrePolicyCn"/></td>
                                                        <td>
                                                            <asp:TextBox ID="txtMplPolicyCancelledDetails" runat="server" TextMode="MultiLine"
                                                                Height="60px" Width="360px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td  align="left">
                                                            <span style="color: #ff0000">*</span>Previous Policy Not-Renewed:
                                                            <br/>&nbsp;&nbsp;<span style="color: #ff0000; font-size:small">(If Yes, Please explain)</span></td>
                                                        <td align="center" >
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedYes" GroupName="PrePolicyNonRenewed"
                                                                /></td>
                                                        <td align="center" style="height: 44px;">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedNo" GroupName="PrePolicyNonRenewed"
                                                                Width="45px" /></td>
                                                        <td >
                                                            <asp:TextBox ID="txtMplPolicyNotRenewalDetail" runat="server" TextMode="MultiLine"
                                                                Height="60px" Width="360px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td  align="right">
                                                <strong>&nbsp; &nbsp; Loss History</strong>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Term From (mm/dd/yyyy)</td>
                                            <td>
                                                Term To(mm/dd/yyyy)</td>
                                            <td>
                                                Carrier</td>
                                            <td>
                                                Amount Paid</td>
                                            <td>
                                                Details</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtTermFrom1" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom1);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td >
                                                <asp:TextBox ID="txtTermto1" runat="server" Width="70px" MaxLength="10" />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto1);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td >
                                                <asp:TextBox ID="txtCarrier1" runat="server" Width="150px" MaxLength="25" /></td>
                                            <td >
                                                <asp:TextBox ID="txtAmtpaid1" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid1" runat="server" ControlToValidate="txtAmtpaid1"
                                                    ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td >
                                                <asp:TextBox ID="txtMplDetails1" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="61px" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtTermFrom2" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom2);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td>
                                                <asp:TextBox ID="txtTermto2" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto2);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td>
                                                <asp:TextBox ID="txtCarrier2" runat="server" Width="150px" MaxLength="25" /></td>
                                            <td>
                                                <asp:TextBox ID="txtAmtpaid2" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid2" runat="server" ControlToValidate="txtAmtpaid2"
                                                    ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td>
                                                <asp:TextBox ID="txtMplDetails2" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtTermFrom3" runat="server" Width="70px" MaxLength="10"  />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermFrom3);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td >
                                                <asp:TextBox ID="txtTermto3" runat="server" Width="70px" MaxLength="10" />
                                                <a onclick="if(self.gfPop)gfPop.fPopCalendar(document.form1.txtTermto3);return false;" href="javascript:void(0)"><img alt="click" src="../includes/calbtn.gif" width="10"/></a></td>
                                            <td >
                                                <asp:TextBox ID="txtCarrier3" runat="server" Width="150px" MaxLength="25" /></td>
                                            <td >
                                                <asp:TextBox ID="txtAmtpaid3" runat="server" Width="64px" MaxLength="9" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid3" runat="server" ControlToValidate="txtAmtpaid3"
                                                    ErrorMessage="InvalidAmount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td >
                                                <asp:TextBox ID="txtMplDetails3" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" /></td>
                                        </tr>
                                    </table>
                                </fieldset>.
                                
                            </asp:Panel>
                            </td>
				</tr>
			</table>
				
		