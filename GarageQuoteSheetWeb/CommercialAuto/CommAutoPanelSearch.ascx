<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommAutoPanelSearch.ascx.vb" Inherits="UserControl947.CommAutoPanelSearch" %>


<fieldset>
                                <table style="width: 680px;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                            <asp:Panel ID="pnlSearch" runat="server" >
                                                <td colspan="2" align="center">
                                                    <div style="text-align: center">
                                                        <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                                            <tr>
                                                                <td colspan="2" align="center" >
                                                               <asp:UpdatePanel ID="UpdatePanelSearch" runat="server">
                                                <ContentTemplate>
                                                                    <asp:GridView id="gvQuote" runat="server" AutoGenerateColumns="false" HeaderStyle-BorderStyle="Solid" HeaderStyle-Font-Bold="true" AllowPaging="true" AllowSorting="true"
                                                                     BorderColor="black"  BorderWidth="1" HeaderStyle-BackColor="blue" HeaderStyle-ForeColor="white">
                                                                       <Columns>
                                                                        <asp:TemplateField HeaderText="Quote Number" HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1"  ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkQuote" ForeColor="blue" ValidationGroup="Grid"  runat="server" CommandName="FillDetails" CommandArgument='<%#databinder.Eval(Container.DataItem,"GarageQuoteID") %>'><%#DataBinder.Eval(Container.DataItem, "GarageQuoteNumber")%></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1" HeaderText="Quote ID" datafield="GarageQuoteID"  SortExpression="ORDER by GarageQuoteID"></asp:BoundField>
                                                                            <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1" HeaderText="Applicant Name" datafield="ApplicantName" SortExpression="ApplicantName"></asp:BoundField>
                                                                            <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1" HeaderText="Trade Name" datafield="TradeName" SortExpression="TradeName"></asp:BoundField>
                                                                            <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1" HeaderText="Date Created" datafield="CreatedDate" SortExpression="CreatedDate"></asp:BoundField>
                                                                            <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1" HeaderText="Contact" DataField="Contact" SortExpression="Contact" />
                                                                       </Columns>
                                                                    </asp:GridView>
                                                       </ContentTemplate>
                                          <Triggers><asp:PostBackTrigger ControlID="gvQuote" /></Triggers>
                                                </asp:UpdatePanel>
                                                                  </td>
                                                            </tr>
                                                        </table>
                                                    <p>
                                                    <p align="left">
                                                        <b></b>
                                                    </p>
                                                </div>
                                                </td>
                                            </asp:Panel>
                                        </tr>
                                </table> 
                            </fieldset>