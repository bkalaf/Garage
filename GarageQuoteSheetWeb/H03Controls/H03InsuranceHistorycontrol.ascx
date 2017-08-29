<%@ Control Language="VB" AutoEventWireup="false" CodeFile="H03InsuranceHistorycontrol.ascx.vb" Inherits="UserControlH03.H03InsuranceHistorycontrol" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script language="JavaScript" type="text/javascript">

function DoNotCallIsAlphaNumeric(bolAllowBlank)

{ 


if (bolAllowBlank == true)

{

if (!(event.keyCode >= 65 && event.keyCode <= 90) && !(event.keyCode >= 97 && event.keyCode <= 122) && !(event.keyCode >= 48 && event.keyCode <= 59) && (event.keyCode != 32)&& (event.keyCode != 45)&& (event.keyCode != 46))

{

event.keyCode=0;

}

}

else

{

if (!(event.keyCode >= 65 && event.keyCode <= 90) && !(event.keyCode >= 97 && event.keyCode <= 122) && !(event.keyCode >= 48 && event.keyCode <= 59))

{

event.keyCode=0;

}


}

} 

</script>


<asp:UpdatePanel ID="insurancectl" runat="server">
<ContentTemplate>

<asp:Panel ID="pnlInsuranceHistory" runat="server">
                                <fieldset>
                                <legend><strong>Insurance History</strong></legend>
               <table border="0" cellpadding="0" cellspacing="0" class="fieldset"  style="width: 680px; height: 120px">
               <tr><td align="left" style="width: 200px"></td><td align="left">Number of Losses</td><td align="left"></td></tr>
        <tr>
            <td align="left" style="width: 200px" >
                <span style="color: #ff0000">*</span>Number of wind/hail losses in the last 3 years:</td>
                <td align="left">
                <asp:DropDownList runat="server" ID="ddlnumberoflosses" TabIndex="46" AutoPostBack="true">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList></td>
            <td align="left">
                <asp:datagrid ID="dgwindhaillosses" runat="server" AutoGenerateColumns="false" Visible="false" Width="100%" TabIndex="47">
                    <Columns>
                    <asp:TemplateColumn HeaderText="Description">
                        <ItemTemplate><asp:TextBox ID="txtDescription" runat="server" Width="80px" MaxLength="100" TabIndex="48"></asp:TextBox><asp:RequiredFieldValidator
                                                 ID="reqfvdesc" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description  wind hail losses cannot be blank(Insurance History)">*</asp:RequiredFieldValidator>
                                                 </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Amount">
                        <ItemTemplate><asp:TextBox ID="txtAmount" runat="server" Width="64px" MaxLength="9" TabIndex="49"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvamtwindhailloss" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount wind hail losses cannot be blank(Insuarance History)">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvAmountPaid1" runat="server" ControlToValidate="txtAmount"
                          ErrorMessage="Invalid Amount Insurance History " ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Outcome Losses">
                        <ItemTemplate><asp:TextBox ID="txtoutcome" runat="server" Width="64px" MaxLength="20" TabIndex="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfvoutcomeloss" runat="server" ControlToValidate="txtoutcome" ErrorMessage="Outcome losses wind hail losses cannot be blank(Insurance History)">*</asp:RequiredFieldValidator>
                        
                        </ItemTemplate>
                    </asp:TemplateColumn>    
                    </Columns>
                </asp:datagrid>
                  
          
            </td>
        </tr>
       <tr>
            <td align="left" style="width: 200px">
                <span style="color: #ff0000">*</span>Number of non-wind/hail losses in the last 3 years:</td>
           
            <td align="left">
                <asp:DropDownList runat="server" ID="ddlnonwindhaillosses" TabIndex="51" AutoPostBack="True">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList></td>
              <td align="left">
                <asp:datagrid ID="dgnonwindhaillosses" runat="server" AutoGenerateColumns="false" Visible="false" Width="100%" TabIndex="52">
                    <Columns>
                    <asp:TemplateColumn HeaderText="Description">
                        <ItemTemplate><asp:TextBox ID="txtDescriptionnon" runat="server" Width="80px" MaxLength="100" TabIndex="53"></asp:TextBox><asp:RequiredFieldValidator
                                                 ID="reqfvdescnon" runat="server" ControlToValidate="txtDescriptionnon" ErrorMessage="Description non wind hail losses cannot be Blank(Insurance History)">*</asp:RequiredFieldValidator>
                                                 </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Amount">
                        <ItemTemplate><asp:TextBox ID="txtAmountnon" runat="server" Width="64px" MaxLength="9" TabIndex="54"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvamtnonwindhailloss" runat="server" ControlToValidate="txtAmountnon" ErrorMessage="Amount  non wind hail losses cannot be blank(Insuarance History)">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvAmountPaidnon" runat="server" ControlToValidate="txtAmountnon"
                          ErrorMessage="Invalid Amount nonwind hail losses Insurance History " ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Outcome Losses">
                        <ItemTemplate><asp:TextBox ID="txtoutcomenon" runat="server" Width="64px" MaxLength="20" TabIndex="55"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfvoutcomelossnon" runat="server" ControlToValidate="txtoutcomenon" ErrorMessage="Outcome loss wind hail losses cannot be Blank(Insurance History)">*</asp:RequiredFieldValidator>
                        
                        </ItemTemplate>
                    </asp:TemplateColumn>    
                    </Columns>
                </asp:datagrid>
                  
          
            </td>
        </tr>
        
        
        
    </table>
                                </fieldset>
                                
                            </asp:Panel>
                            </ContentTemplate>
                            <Triggers><asp:PostBackTrigger ControlID="ddlnumberoflosses" /></Triggers>
                             <Triggers><asp:PostBackTrigger ControlID="ddlnonwindhaillosses" /></Triggers>
                            </asp:UpdatePanel>
         
		