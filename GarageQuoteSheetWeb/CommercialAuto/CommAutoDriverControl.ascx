<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommAutoDriverControl.ascx.vb"
    Inherits="UserControl947.CommAutoDriverControl" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">





function validateInput ( src, args ) 

{ 

var MMYYYY=args.Value.split("/");

var serverMMYYYY ="<%=MMYYYY %>".split("/"); //new Date(); 

var MM=serverMMYYYY[0];

var YY=serverMMYYYY[1]; 



if(MMYYYY.length <=0)

args.IsValid = false; 

else if((eval(MMYYYY[0]) >12) || (eval(MMYYYY[0]) < 1) || (eval(MMYYYY[0]).length < 2)) 

args.IsValid = false;

else if ((eval(MMYYYY[1]) >YY) || (eval(MMYYYY[1]) < 1900) || (eval(MMYYYY[1]).length < 4) || ((eval(MMYYYY[1]) == YY) && (eval(MMYYYY[0]) > MM)))

args.IsValid = false; 


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
	function CheckNumeric()
   {
    vKey = window.event.keyCode;
    if (!isNumeric(vKey))
     window.event.keyCode=0;
   }
   function isNumeric (k)
   {
    return ((k >= 48) && (k <= 57));
   }
	
					
	
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>	
							<fieldset>
                                <legend><strong>Driver Information</strong></legend>
                                <table style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                                    class="fieldset">
                                    <tr>
                                        <td>Name</td>
                                            <td>
                                                DOB<br />(mm/dd/yyyy)</td>
                                            <td style="width: 76px">
                                                Yrs of Exp</td>
                                             <td>
                                               Hire Date<br />(mm/dd/yyyy)</td>
                                            <td>
                                                List Accidents/Tickets</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:TextBox ID="txtName1" runat="server" Width="150px" MaxLength="80" TabIndex="86"  />
                                              <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                                    ErrorMessage="Invalid Name(Driver Information)." 
                                                    ControlToValidate="txtName1"    ValidationGroup="Garage"  
                                                    ValidationExpression="^[a-zA-Z'.\s]{1,40}$" />

   
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtbirth1" runat="server"  Width="80px" MaxLength="10" TabIndex="87"  />
                                                 <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"  Mask="99/99/9999" MaskType="Date" TargetControlID="txtbirth1" CultureName="en-US"   PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" ValidationGroup="Garage" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtbirth1"   InvalidValueMessage="Invalid Birth1 date"></cc1:MaskedEditValidator>
                                                </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtexp1" runat="server" Width="20px" MaxLength="2" TabIndex="88" />
                                                 <asp:RegularExpressionValidator ID="rfvtxtexp1" runat="server" ControlToValidate="txtexp1"
                                                    ErrorMessage="Invalid Years Exp(Driver Information)" ValidationGroup="Garage" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                                             </td>
                                            <td valign="top">
                                                
                                                <asp:TextBox ID="txthiredt1" runat="server"  Width="80px" MaxLength="10" TabIndex="89" ></asp:TextBox>
                                                            
                                             <cc1:MaskedEditExtender ID="meexhiredt1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txthiredt1" PromptCharacter="_"></cc1:MaskedEditExtender>
                                               <cc1:MaskedEditValidator ID="medvhiredt1" ValidationGroup="Garage" runat="server" ControlExtender="meexhiredt1" ControlToValidate="txthiredt1"  InvalidValueMessage="Invalid Hire1 date"  ></cc1:MaskedEditValidator>
                                                
                                               </td>
                                            
                                                
                                            <td valign="top">
                                                <asp:TextBox ID="txttkts1" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="30px" MaxLength="100" TabIndex="90" />
                                                    </td></tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:TextBox ID="txtName2" runat="server" Width="150px" MaxLength="80" TabIndex="91"  />
                                                <asp:RegularExpressionValidator ID="rgexvaname2" runat="server"  ValidationGroup="Garage"   
                                                ErrorMessage="Invalid Name (Driver Information)" 
                                                ControlToValidate="txtName2"     
                                                ValidationExpression="^[a-zA-Z'.\s]{1,40}$" /></td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtbirth2" runat="server"  Width="80px" MaxLength="10" TabIndex="92" />
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtbirth2"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2" ControlToValidate="txtbirth2"  InvalidValueMessage="Invalid Birth2 date" ></cc1:MaskedEditValidator>
                                                </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtexp2" runat="server" Width="20px" MaxLength="2" TabIndex="93" />
                                                 <asp:RegularExpressionValidator ID="regexpvalexp2" runat="server" ControlToValidate="txtexp2"
                                                    ErrorMessage="Invalid Years Exp(Driver Information)" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator></td>
                                            <td valign="top">
                                                <asp:TextBox ID="txthiredt2" runat="server"  Width="80px" MaxLength="10" TabIndex="94" ></asp:TextBox>
                                                 <cc1:MaskedEditExtender ID="mexhiredt2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txthiredt2" PromptCharacter="_"></cc1:MaskedEditExtender>
                                               <cc1:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlExtender="mexhiredt2" ControlToValidate="txthiredt2"   InvalidValueMessage="Invalid Hire2 date" ></cc1:MaskedEditValidator>
                                                                                                
                                               </td>                                            
                                            <td valign="top">
                                                <asp:TextBox ID="txttkts2" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="30px" MaxLength="100" TabIndex="95"/></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:TextBox ID="txtName3" runat="server" Width="150px" MaxLength="80" TabIndex="96"/>
                                                <asp:RegularExpressionValidator ID="regexpvalname3" runat="server"     
                                                        ErrorMessage="Invalid Name (Driver Information)" 
                                                        ControlToValidate="txtName3"     ValidationGroup="Garage"
                                                        ValidationExpression="^[a-zA-Z'.\s]{1,40}$" /></td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtbirth3" runat="server" Width="80px" MaxLength="10" TabIndex="97"  />
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtbirth3"  PromptCharacter="_"> </cc1:MaskedEditExtender>

                                                <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3" ControlToValidate="txtbirth3"  InvalidValueMessage="Invalid Birth3 date" ></cc1:MaskedEditValidator>
                                                </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtexp3" runat="server" Width="20px" MaxLength="2" TabIndex="98" />
                                                <asp:RegularExpressionValidator ID="regexpvalexp3" ValidationGroup="Garage" runat="server" ControlToValidate="txtexp3"
                                                    ErrorMessage="Invalid Years Exp(Driver Information)" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator></td>
                                            <td valign="top">
                                                <asp:TextBox ID="txthiredt3" runat="server"  Width="80px" MaxLength="10" TabIndex="99" ></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="meexhiredt3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txthiredt3" PromptCharacter="_"></cc1:MaskedEditExtender>
                                                <cc1:MaskedEditValidator ID="medhiredt3" runat="server" ControlExtender="meexhiredt3" ControlToValidate="txthiredt3"   InvalidValueMessage="Invalid Hire3 date"  ></cc1:MaskedEditValidator>
                                            </td>
                                           
                                            <td valign="top">
                                                <asp:TextBox ID="txttkts3" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="30px" MaxLength="100" TabIndex="100" /></td>
                                        </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:TextBox ID="txtName4" runat="server" Width="150px" MaxLength="80" TabIndex="101"  />
                                            <asp:RegularExpressionValidator ID="rgexpname4" ValidationGroup="Garage" runat="server"     
                                                                ErrorMessage="Invalid Name (Driver Information)" 
                                                                ControlToValidate="txtName4"     
                                                                ValidationExpression="^[a-zA-Z'.\s]{1,40}$" /></td>
                                                    <td valign="top">
                                                       <asp:TextBox ID="txtbirth4" runat="server"  Width="80px" MaxLength="10" TabIndex="102"  />
                                                       <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtbirth4"   PromptCharacter="_"> </cc1:MaskedEditExtender>
                                                       <cc1:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="MaskedEditExtender4" ControlToValidate="txtbirth4"  InvalidValueMessage="Invalid Birth4 date" ></cc1:MaskedEditValidator></td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtexp4" runat="server" Width="20px" MaxLength="2" TabIndex="103" />
                                                        <asp:RegularExpressionValidator ID="regexpexp4" runat="server" ControlToValidate="txtexp4"
                                                          ErrorMessage="Invalid Years Exp(Driver Information)" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator></td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txthiredt4" runat="server"  Width="80px" MaxLength="10" TabIndex="104" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="mexhiredt4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txthiredt4" PromptCharacter="_"></cc1:MaskedEditExtender>
                                                        <cc1:MaskedEditValidator ID="medhiredt4" runat="server" ControlExtender="mexhiredt4" ControlToValidate="txthiredt4"  InvalidValueMessage="Invalid Hire4 date"  ></cc1:MaskedEditValidator>
                                                     </td>
                                                   
                                                    <td valign="top">
                                                        <asp:TextBox ID="txttkts4" runat="server" TextMode="MultiLine" Width="180px"
                                                                                            Height="30px" TabIndex="105" /></td>
                                                </tr>
                                                <tr>
            <td valign="top">
                <asp:TextBox ID="txtName5" runat="server" Width="150px" MaxLength="80" TabIndex="106"  />
                <asp:RegularExpressionValidator ID="regexpvalname5" runat="server"     
                                    ErrorMessage="Invalid Name (Driver Information)" 
                                    ControlToValidate="txtName5"     ValidationGroup="Garage"
                                    ValidationExpression="^[a-zA-Z'.\s]{1,40}$" /></td>
            <td valign="top">
                <asp:TextBox ID="txtbirth5" runat="server"  Width="80px" TabIndex="107"  />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtbirth5"  PromptCharacter="_"> </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server" ControlExtender="MaskedEditExtender5" ControlToValidate="txtbirth5"  InvalidValueMessage="Invalid Birth5 date"  ></cc1:MaskedEditValidator></td>
                <td valign="top">
                <asp:TextBox ID="txtexp5" runat="server" Width="20px" MaxLength="2" TabIndex="108" />
                <asp:RegularExpressionValidator ID="regexpexp5" runat="server" ControlToValidate="txtexp5"
                                                    ErrorMessage="Invalid Years Exp(Driver Information)" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator></td>
            <td valign="top">
                <asp:TextBox ID="txthiredt5" runat="server"  Width="80px" MaxLength="10" TabIndex="109" ></asp:TextBox>
                <cc1:MaskedEditExtender ID="msxhiredt5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txthiredt5" PromptCharacter="_"></cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="medhiredt5" runat="server" ControlExtender="msxhiredt5" ControlToValidate="txthiredt5"  InvalidValueMessage="Invalid Hire5 date" ></cc1:MaskedEditValidator>
                 </td>
           
            <td valign="top">
                <asp:TextBox ID="txttkts5" runat="server" TextMode="MultiLine" Width="180px"
                                                    Height="30px"  MaxLength="100" TabIndex="110"/></td>
        </tr>
    
        </table>
                                        
          </fieldset>

 </contenttemplate>
    <%--<Triggers><asp:PostBackTrigger ControlID="txtbirth1" /></Triggers>
                                               
                                                 <Triggers><asp:PostBackTrigger ControlID="txtbirth2" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txtbirth3" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txtbirth4" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txtbirth5" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txthiredt1" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txthiredt2" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txthiredt3" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txthiredt4" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="txthiredt5" /></Triggers>--%>
</asp:UpdatePanel>
