<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AutoCommInsuranceHistorycontrol.ascx.vb"
    Inherits="UserControl947.AutoCommInsuranceHistorycontrol" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp1" %>

<script language="JavaScript" type="text/javascript">



// function validateRange ( src, args ) 
//    {       
//        var controlid= src.id.split("CFromValidator");  //substring(src.id.indexOf("CFromValidator"),src.length);//.split("CustomTermFromValidator");  
//        //alert(controlid.length);
//        var id=1;
//        if (controlid.length > 1)
//            id=controlid[1];
//        else
//        {
//            controlid= src.id.split("CToValidator");
//            
//            if (controlid.length > 1)
//            id=controlid[1];
//        }    
//        if (TwoRanage(src.id,id) == false)
//        {
//            args.IsValid = false;                
//        }     
//    }
//    function TwoRanage(val,id)
//    {       
//        var ToDate ="<%=MMDDYYYY %>";
//        var FromDate=01/01/1900;
//        var str=val.substring(0,val.lastIndexOf("_"));
//      
//       if(document.getElementById(str + "_txtTermFrom" + id).value != "")              
//           FromDate =document.getElementById(str + "_txtTermFrom" + id).value;
//        if(document.getElementById(str + "_txtTermto" + id).value != "")            
//           ToDate =document.getElementById(str + "_txtTermto" + id).value;

//        var start = new Date (FromDate);
//        var end = new Date (ToDate);
//        
//        
//        
//        if (end <= start) 
//              return false;
//        else
//              return true;   

//    }



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
    function isNumeric (k)
   {
    return ((k >= 48) && (k <= 57));
   }

function CheckAmount(obj)
   {
  
    vKey = window.event.keyCode;
    if ((document.getElementById(obj.id).value.indexOf(".") != -1) && (vKey== 46))
       window.event.keyCode=0;
    else
    {
    if (!isNumeric(vKey) && (vKey != 46))
     window.event.keyCode=0;
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

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
<asp:Panel ID="pnlInsuranceHistory" runat="server">
                                <fieldset>
                                    <legend><strong>Insurance History</strong></legend>
                                    <table style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                                        class="fieldset">
                                        <tr>
                                            <td colspan="5" style="height: 188px" width="100%">
                                                <table>
                                                    <tr>
                                                        <td style="width: 284px" align="left">
                                                        </td>
                                                        <td align="center" width="50">
                                                            Yes</td>
                                                        <td align="center" width="50">
                                                            No</td>
                                                        <td style="width: 360px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 284px; height: 40px;" align="left">
                                                            <span style="color: #ff0000">*</span> Previous Policy Cancelled:
                                                            <br/><span style="color: #ff0000; font-size:small">&nbsp;&nbsp;&nbsp;(If Yes, Please explain)</span></td>
                                                        <td align="center" style="width: 78px; height: 40px;">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyCnAnsYes" GroupName="PrePolicyCn" Style="width: 18px"
                                                                Width="45px" onclick="JavaScript:Click(this,'txtMplPolicyCancelledDetails')" TabIndex="111" /></td>
                                                        <td align="center" style="height: 40px;">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyCnAnsNo"  onclick="JavaScript:Click(this,'txtMplPolicyCancelledDetails')" GroupName="PrePolicyCn"
                                                                Style="width: 18px" Width="45px" TabIndex="111" /></td>
                                                        <td style="width: 199px; height: 40px">
                                                            <asp:TextBox ID="txtMplPolicyCancelledDetails" runat="server" TextMode="MultiLine"
                                                                Height="60px" Width="360px" Enabled="false" TabIndex="112" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 284px; height: 40px;" align="left">
                                                            <span style="color: #ff0000">*</span>  Previous Policy Non-
                                                            <br/>&nbsp;&nbsp;&nbsp;Renewed:<span style="color: #ff0000; font-size:small">&nbsp;&nbsp;(If Yes, Please explain)</span></td>
                                                        <td align="center" style="width: 78px; height: 44px;">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedAnsYes" GroupName="PrePolicyNonRenewed"
                                                                Style="width: 18px" Width="45px" onclick="JavaScript:Click(this,'txtMplPolicyNotRenewalDetail')" TabIndex="113" /></td>
                                                        <td align="center" style="height: 44px;">
                                                            <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedAnsNo" GroupName="PrePolicyNonRenewed"
                                                                Style="width: 18px" Width="45px" onclick="JavaScript:Click(this,'txtMplPolicyNotRenewalDetail')" TabIndex="113" /></td>
                                                        <td style="width: 199px; height: 44px">
                                                            <asp:TextBox ID="txtMplPolicyNotRenewalDetail" runat="server" TextMode="MultiLine"
                                                                Height="60px" Width="360px" Enabled="false" TabIndex="114"  />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="2" align="center"><strong>Prior Coverage and Loss History</strong> 
                                            </td>
                                            <td>
                                                
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px; height: 15px;">
                                                Term From (mm/dd/yyyy)</td>
                                            <td style="width: 108px; height: 15px;">
                                                Term To(mm/dd/yyyy)</td>
                                            <td style="width: 104px; height: 15px;">
                                                Carrier</td>
                                            <td style="width: 100px; height: 15px;">
                                                Amount Paid</td>
                                            <td style="width: 100px; height: 15px;">
                                                Details</td>
                                        </tr>
                                        <tr>
                                             <td style="width: 118px" valign="top">
                                              
                                               
                                                <asp:TextBox ID="txtTermFrom1" runat="server" Width="70px" MaxLength="10" TabIndex="115"    />
                                                    
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermFrom1" PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermFrom1"  InvalidValueMessage="Date is invalid" ></cc1:MaskedEditValidator>

   
                                                 <%--<asp:CustomValidator ID="CFromValidator1" runat="server" ControlToValidate="txtTermFrom1"
                                                     ClientValidationFunction="validateRange"></asp:CustomValidator>--%> 
                                                                     
                                              
                                                </td>
                                                
                                                


                                            <td style="width: 108px" valign="top">
                                                <asp:TextBox ID="txtTermto1" runat="server" Width="70px" MaxLength="10" TabIndex="116" />&nbsp;<asp:Label  ID="lbltoone"  runat="server" ForeColor="Red" Visible="False"></asp:Label>  
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermto1"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermto1" ValidationGroup="Garage"  InvalidValueMessage="Date is invalid"  ></cc1:MaskedEditValidator>
                                                  
                                               </td>
                                            <td style="width: 104px" valign="top">
                                                <asp:TextBox ID="txtCarrier1" runat="server" Width="150px" MaxLength="25" TabIndex="117" /></td>
                                            <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtAmtpaid1" runat="server" Width="64px" MaxLength="9" TabIndex="118"  onkeypress="JavaScript:CheckAmount(this)"/>
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid1" runat="server" ControlToValidate="txtAmtpaid1" 
                                                    ErrorMessage="Invalid Amount(Prior Coverage And Loss in Insurance History)" ValidationGroup="Garage" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtMplDetails1" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" MaxLength="100" TabIndex="119" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px" valign="top">
                                           
                                               
                                                <asp:TextBox ID="txtTermFrom2" runat="server" Width="70px" MaxLength="10" TabIndex="120"   />&nbsp;
                                                 <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermFrom2"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ValidationGroup="Garage" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermFrom2"  InvalidValueMessage="Date is invalid"  ></cc1:MaskedEditValidator>

                                                                 
                                                

                                                
                                                </td>
                                               

                                            <td style="width: 108px" valign="top">
                                                <asp:TextBox ID="txtTermto2" runat="server" Width="70px" MaxLength="10" TabIndex="121"  />&nbsp;&nbsp;<asp:Label  ID="lbltotwo"  runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                 <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermto2"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator4" ValidationGroup="Garage" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermto2"  InvalidValueMessage="Date is invalid"  TooltipMessage="Input a Date"></cc1:MaskedEditValidator>

                                                
                                               </td>
                                            <td style="width: 104px" valign="top">
                                                <asp:TextBox ID="txtCarrier2" runat="server" Width="150px" MaxLength="25" TabIndex="122"  /></td>
                                            <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtAmtpaid2" runat="server" Width="64px" MaxLength="9" TabIndex="123" onkeypress="JavaScript:CheckAmount(this)" />
                                                <asp:RegularExpressionValidator ID="rfvAmountPaid2" ValidationGroup="Garage" runat="server" ControlToValidate="txtAmtpaid2"
                                                    ErrorMessage="Invalid Amount (Prior Coverage And Loss in Insurance History))" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                                  <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtMplDetails2" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" MaxLength="100" TabIndex="124" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px" valign="top">
                                                <asp:TextBox ID="txtTermFrom3" runat="server" Width="70px" MaxLength="10" TabIndex="125"  />&nbsp;
                                                
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermFrom3"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator5" ValidationGroup="Garage" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermFrom3" InvalidValueMessage="Date is invalid"  ></cc1:MaskedEditValidator>
                                               
                                               </td>
                                            <td style="width: 108px" valign="top" >
                                                <asp:TextBox ID="txtTermto3" runat="server" Width="70px" MaxLength="10" TabIndex="126"  />&nbsp;<asp:Label  ID="lbltothree"  runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTermto3"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator6" ValidationGroup="Garage" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtTermto3"  InvalidValueMessage="Date is invalid"  ></cc1:MaskedEditValidator>
                                                

                                                </td>
                                               
                                            <td style="width: 104px" valign="top">
                                                <asp:TextBox ID="txtCarrier3" runat="server" Width="150px" MaxLength="25" TabIndex="127" /></td>
                                            <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtAmtpaid3" runat="server" Width="64px" MaxLength="9" TabIndex="128"  onkeypress="JavaScript:CheckAmount(this)"/>
                                                <asp:RegularExpressionValidator ValidationGroup="Garage" ID="rfvAmountPaid3" runat="server" ControlToValidate="txtAmtpaid3"
                                                    ErrorMessage="Invalid Amount(Prior Coverage And Loss in Insurance History))" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator></td>
                                            <td style="width: 100px" valign="top">
                                                <asp:TextBox ID="txtMplDetails3" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="60px" MaxLength="100" TabIndex="129" /></td>
                                        </tr>
                                    </table>
                                </fieldset>.
                                 
                            </asp:Panel>
                             </contenttemplate>
    <triggers><asp:PostBackTrigger ControlID="txtTermFrom1" /></triggers>
    <triggers><asp:PostBackTrigger ControlID="txtTermTo1" /></triggers>
    <triggers><asp:PostBackTrigger ControlID="txtTermFrom2" /></triggers>
    <triggers><asp:PostBackTrigger ControlID="txtTermTo2" /></triggers>
    <triggers><asp:PostBackTrigger ControlID="txtTermFrom3" /></triggers>
    <triggers><asp:PostBackTrigger ControlID="txtTermTo3" /></triggers>
</asp:UpdatePanel>
