<%@ Control Language="VB" AutoEventWireup="false" CodeFile="H03RiskDescriptionl.ascx.vb" Inherits="UserControlH03.RiskdescControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <script language="javascript" type="text/javascript">
 function Click(obj,ctrl)
    {   
        //alert(obj.id.substring(0,obj.id.lastIndexOf("_")));
        var str=obj.id.substring(0,obj.id.lastIndexOf("_"));
        if((obj.id.indexOf("AnsNo") != -1) &&  (obj.checked == true))
        {    
           document.getElementById(str + "_"  + ctrl).disabled=true;
           document.getElementById(str + "_"  + ctrl).value="";
        }
        else
        {
            document.getElementById(str + "_"  + ctrl).disabled=false;
        }
    }


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


                 <asp:UpdatePanel ID="riskdescpctl" runat="server"><ContentTemplate>

							<fieldset>
                                <legend><strong>Risk Description</strong></legend>
                                
                                <table  style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                                    class="fieldset">
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Applicant Name:(First,Last,MI)</td> 
                                           <td align="Left" colspan="2" >
                                           <asp:TextBox ID="txtApplicantfirstName" runat="server" MaxLength="50" Width="120px" TabIndex="5"/>
                                           <asp:RequiredFieldValidator
                                                 ID="reqfvapplname" runat="server" ControlToValidate="txtApplicantfirstName" ErrorMessage="Applicant First name cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                                  <asp:RegularExpressionValidator ID="regexplName" runat="server" ControlToValidate="txtApplicantfirstName"
                                                    ErrorMessage="Applicant First name(Risk Description)" ValidationExpression="^[a-zA-Z'.\s]{1,40}$">*</asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txtApplicantlastName" runat="server" MaxLength="50" Width="105px" TabIndex="6" /> <asp:RequiredFieldValidator
                                                 ID="rfvappfirstname" runat="server" ControlToValidate="txtApplicantlastName" ErrorMessage="Applicant first name cannot be blank(Risk description)">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rexvfname" runat="server" ControlToValidate="txtApplicantlastName"
                                                    ErrorMessage="Applicant last name(Risk Description)" ValidationExpression="^[a-zA-Z'.\s]{1,40}$">*</asp:RegularExpressionValidator><asp:TextBox ID="txtApplicantMiddleIn" runat="server" MaxLength="6" Width="50px" TabIndex="7" /></td>
                                         <td></td>   
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Location Address Line 1:</td>
                                        <td align="Left" colspan="2" >
                                            <asp:TextBox ID="txtlocaddline1" runat="server" MaxLength="50" Width="244px" TabIndex="8" /><asp:RequiredFieldValidator
                                                 ID="rfvlocaddline1" runat="server" ControlToValidate="txtlocaddline1" ErrorMessage="Location Address line 1 cannot be blank(Risk description)">*</asp:RequiredFieldValidator></td>
                                        <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px; height: 24px;">  &nbsp;&nbsp; Location Address Line 2:</td>
                                        <td  align="Left" colspan="2" style="height: 24px">
                                            <asp:TextBox ID="txtlocaddline2" runat="server" MaxLength="50" Width="244px" TabIndex="9" />
                                            </td>
                                    <td style="height: 24px"></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px; height: 24px;">
                                            <span style="color: #ff0000">*</span> Location City:</td>
                                        <td  align="Left" colspan="2" style="height: 24px">
                                            <asp:TextBox ID="txtcity" runat="server" MaxLength="50" Width="120px" TabIndex="10" /> <asp:RequiredFieldValidator
                                                 ID="rfvcity" runat="server" ControlToValidate="txtcity" ErrorMessage="Location city cannot be blank(Risk description)">*</asp:RequiredFieldValidator></td>
                                            <td style="height: 24px"></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Location State:</td>
                                        <td  align="Left" colspan="2">
                                            <asp:TextBox ID="txtstate" runat="server"  MaxLength="2" Width="50px" TabIndex="11" />
                                            <asp:RequiredFieldValidator ID="rfvstate" runat="server" ControlToValidate="txtstate"
                                                ErrorMessage="Location state cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtstate"
                                                    ErrorMessage="Invaild State Code(Risk Description)" ValidationExpression="^[a-zA-Z]{2}$">*</asp:RegularExpressionValidator>  
                                                </td>
                                            <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Location Zipcode:</td>
                                        <td  align="Left" colspan="2">
                                            
                                                    <asp:TextBox ID="txtzipcode" runat="server" AutoPostBack="true" MaxLength="5" Width="100px" TabIndex="12"  />
                                              <asp:RequiredFieldValidator ID="rqfzipcode" runat="server" ControlToValidate="txtzipcode"
                                                ErrorMessage="Location zipCode cannot be blank(Rsik description)">*</asp:RequiredFieldValidator>
                                              
                                                    <asp:RegularExpressionValidator ID="revzipcode" runat="server" ControlToValidate="txtzipcode"
                                                    ErrorMessage="Invalid ZipCode(Risk description)" ValidationExpression="^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$">*</asp:RegularExpressionValidator>    
                                                
                                               
                                         
                                            
                                            
                                                </td>
                                            <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Location County:</td>
                                        <td  align="Left" colspan="2">
                                            <asp:DropDownList ID="ddlcounty" runat="server"  Width="120px" TabIndex="13" /></td>
                                            <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Territory Name:</td>
                                        <td  align="Left" colspan="2">
                                            
                                            <asp:DropDownList ID="ddlterritory" runat="server"   Width="244px" TabIndex="14" AutoPostBack="True" />
                                               
                                               
                                               
                                            </td>
                                            <td></td> 
                                    </tr>
                                      <tr>
                                        <td  align="Left" style="width: 300px; height: 24px;">
                                            <span style="color: #ff0000">*</span> Territory Code:</td>
                                        <td  align="Left" colspan="2" style="height: 24px">
                                            <asp:TextBox ID="lblTerritorycode" runat="server"   ReadOnly="true" Width="120px" TabIndex="15" /></td>
                                            <td style="height: 24px"></td> 
                                    </tr>
                                    
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Home Phone:</td>
                                        <td  align="Left" colspan="2">
                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="12" class="text input_mask mask_phone" TabIndex="15" />
                                            <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtphone"
                                                ErrorMessage="Location home phone cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
                                                ErrorMessage="Invalid home phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPhone" Mask="999-999-9999" ClearMaskOnLostFocus="false">
                                            </cc1:MaskedEditExtender>
                                             <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtPhone"></cc1:MaskedEditValidator>
                                                </td>
                                            <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="Left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Work Phone:</td>
                                        <td  align="Left" colspan="2">
                                            <asp:TextBox ID="txtworkphone" runat="server" MaxLength="12" class="text input_mask mask_phone" TabIndex="16" />
                                            <asp:RequiredFieldValidator ID="rfvwrkphone" runat="server" ControlToValidate="txtworkphone"
                                                ErrorMessage="Location work phone cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtworkphone"
                                                ErrorMessage="Invalid whone phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtworkphone" Mask="999-999-9999" ClearMaskOnLostFocus="false">
                                            </cc1:MaskedEditExtender>
                                             <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtworkphone"></cc1:MaskedEditValidator></td>
                                            <td></td> 
                                    </tr>
                                    
                                    
                                    <tr>
                                                    <td  align="Left" style="width: 300px" >
                                                    </td>
                                                    <td align="left"  >
                                                        Yes
                                                    &nbsp;&nbsp;&nbsp;
                                                        No</td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td  align="left" style="width: 300px; height: 20px;" >
                                                        <span style="color: #ff0000">*</span> Mailing Address same as Location address:
                                                     
                                                    </td>
                                                    <td align="left" style="height: 20px">
                                                        <asp:RadioButton ID="rdmailingaddYes" GroupName="mailingadd" runat="server" AutoPostBack="true" TabIndex="17" />
                                                    &nbsp;&nbsp;&nbsp;
                                                        <asp:RadioButton ID="rdmailingaddNo" GroupName="mailingadd" runat="server" AutoPostBack="true" TabIndex="17" /></td>
                                                    
                                                </tr>
                                                     
                                            
                                          
                                   <tr>
                                  
                                        <td  align="left" style="width: 290px; height: 24px;">
                                            <span style="color: #ff0000">*</span> Mailing Address Line 1:</td>
                                        <td  align="left" colspan="3" style="height: 24px">
                                           <asp:TextBox ID="txtmaddln1" runat="server"  Width="244px" TabIndex="18" />
                                           <asp:RequiredFieldValidator
                                                 ID="rfvmaddln1" runat="server" ControlToValidate="txtmaddln1" ErrorMessage="Mailing address line 1 cannot be blank(Risk description)">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    
                                   <tr>
                                        <td  align="left" style="width: 300px">
                                             &nbsp;&nbsp;&nbsp;Mailing Address Line 2:
                                        </td>
                                        <td  align="left" colspan="3">
                                              <asp:TextBox ID="txtmaddln2" runat="server" Width="244px" TabIndex="20" />
                                       </td>
                                    </tr>
                                   <tr>
                                        <td  align="left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Mailing City:</td>
                                         <td  align="left" colspan="3">
                                            <asp:TextBox ID="txtmacity" runat="server" MaxLength="10" Width="244px" TabIndex="21" />
                                            <asp:RequiredFieldValidator
                                                 ID="rfvmacity" runat="server" ControlToValidate="txtmacity" ErrorMessage="Mailing address city cannot be blank(Risk description)">*</asp:RequiredFieldValidator></td> 
                                    </tr>
                                    <tr>
                                        <td  align="left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Mailing State:</td>
                                       <td  align="left" colspan="3">
                                            <asp:TextBox ID="txtmastate" runat="server" MaxLength="2" Width="50px" TabIndex="22" />
                                            <asp:RequiredFieldValidator
                                                 ID="rfvmastate" runat="server" ControlToValidate="txtmastate" ErrorMessage="Mailing state cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtmastate"
                                                    ErrorMessage="Invaild State Code(Risk Description Mailing State)" ValidationExpression="^[a-zA-Z]{2}$">*</asp:RegularExpressionValidator>  
                                                 
                                                 </td>
                                    </tr>
                                  <tr>
                                        <td  align="left" style="width: 300px">
                                            <span style="color: #ff0000">*</span> Mailing Zipcode:</td>
                                        <td  align="left" colspan="3">
                                           
                                            <asp:TextBox ID="txtmaZipcode" runat="server"  MaxLength="5" AutoPostBack="true"   Width="120px" TabIndex="23" />
                                            <asp:RequiredFieldValidator
                                                 ID="rfvmazipcode" runat="server" ControlToValidate="txtmaZipcode" ErrorMessage="Mailing zipcode cannot be blank(Risk description)">*</asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="rexvmazipcode" runat="server" ControlToValidate="txtmaZipcode"
                                                    ErrorMessage="Invalid ZipCode(Mailing address zipcode Risk description)" ValidationExpression="^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$">*</asp:RegularExpressionValidator></td>
                                                
                                               
                                               
                                                 
                                                    
                                    </tr>
                                    
                                    <tr>
                                        <td  align="left" style="width: 300px" >
                                            <span style="color: #ff0000">*</span> Mailing County:</td>
                                         <td  align="left" colspan="3">
                                            <asp:TextBox ID="txtmacounty" ReadOnly="true" runat="server" MaxLength="50" Width="120px" TabIndex="24" />
                                            <asp:RequiredFieldValidator
                                                 ID="rfvmacounty" runat="server" ControlToValidate="txtmacounty" ErrorMessage="Mailing county cannot be blank(Risk description)">*</asp:RequiredFieldValidator></td>
                                    </tr>        
                                   
                                    <tr>
                                        <td  align="left" style="width: 300px" >
                                            &nbsp;&nbsp; Lien Holder:</td>
                                         <td  align="Left" colspan="2"><asp:TextBox ID="txtlienholder" runat="server"  Width="244px" TabIndex="25" />
                                             </td>
                                         <td></td> 
                                    </tr>
                                    <tr>
                                        <td  align="left" style="width: 300px" >
                                            &nbsp;&nbsp;&nbsp;Comments:</td>
                                        <td  align="Left" colspan="2">
                                            <asp:TextBox runat="server" TextMode="multiline" ID="txtcomments" Height="60px"
                                                Width="360px" TabIndex="26" />
                                            </td>
                                                <td></td> 
                                    </tr>
                                    
                                    
                                  
                                </table>
                            </fieldset>
                            </ContentTemplate>
                             <Triggers><asp:PostBackTrigger ControlID="txtzipcode" /></Triggers>
                              <Triggers><asp:PostBackTrigger ControlID="ddlterritory" /></Triggers>
                               <Triggers><asp:PostBackTrigger ControlID="rdmailingaddYes" /></Triggers>
                               <Triggers><asp:PostBackTrigger ControlID="rdmailingaddNo" /></Triggers>
                               <Triggers><asp:PostBackTrigger ControlID="txtmaZipcode" /></Triggers>
                            </asp:UpdatePanel>
					
            
													
					