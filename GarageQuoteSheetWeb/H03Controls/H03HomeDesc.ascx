<%@ Control Language="VB" AutoEventWireup="false"  CodeFile="H03HomeDesc.ascx.vb" Inherits="UserControlH03.H03HomeDesc" %>

<script language="JavaScript" type="text/javascript">
              
         function Click1(obj,ctrl)
    {   
//        alert(obj.id.substring(0,obj.id.lastIndexOf("_")));
        var str=obj.id.substring(0,obj.id.lastIndexOf("_"));
        if((obj.id.indexOf("AnsNo") != -1) &&  (obj.checked == true))
        {  
           document.getElementById(str + "_"  + ctrl).disabled=true;
           document.getElementById(str + "_"  + ctrl).value=""; 
          
        }
        else
        {
            document.getElementById(str + "_"  + ctrl).disabled=false;
            document.getElementById(str + "_"  + ctrl).value="";
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
  <asp:UpdatePanel ID="homedescctl" runat="server">
  <ContentTemplate>
<fieldset>
    <legend><strong>Home Description</strong></legend>
    <table border="0" cellpadding="0" cellspacing="0" class="fieldset" style="width: 680px;
        height: 240px" >
       <tr>
            <td align="left" style="width: 300px; height: 22px;">
                <span style="color: #ff0000">*</span> Occupancy:</td>
            <td align="left" style="color: #ff0000; height: 22px;" colspan="3">
                <asp:DropDownList ID="ddloccupany" runat="server"  Width="200px" TabIndex="27">                
                 </asp:DropDownList>
            </td>
            <td style="height: 22px"></td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px" >
                <span style="color: #ff0000">*</span> Construction Type</td>
            <td align="left" colspan="3">
                <asp:DropDownList ID="ddlconstructiontype" runat="server" Width="200px" TabIndex="28">
                    </asp:DropDownList>
            </td>
             <td></td>
             <td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px; height: 22px;">
                <span style="color: #ff0000">*</span> Year Built</td>
            <td align="left" colspan="3" style="height: 22px">
                <asp:DropDownList ID="ddlyearbuilt" runat="server" Width="200px" TabIndex="29">                
                    </asp:DropDownList>
            </td>
             <td style="height: 22px"></td>
             <td style="height: 22px"></td>
        </tr>
         <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Protection Class:</td>
            <td align="left" style="color: #ff0000" colspan="3">
                <asp:DropDownList ID="ddlprotection" runat="server" Width="200px" TabIndex="30">                  
                 </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Protective Devices:</td>
            <td align="left" style="color: #ff0000" colspan="3">
                <asp:DropDownList ID="ddlprotectivedevices" runat="server" Width="200px" TabIndex="31">
                
                    </asp:DropDownList>
            </td>
             <td></td>
             <td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px" >
                <span style="color: #ff0000">*</span> Families:</td>
            <td align="left" style="color: #ff0000" colspan="3">
                <asp:DropDownList ID="ddlfamilies" runat="server" Width="110px" TabIndex="32">
                <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">more than 2</asp:ListItem>
                    </asp:DropDownList>
            </td>
             <td></td>
             <td></td>
        </tr>
         <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Miles to Coastal Water:</td>
            <td align="left" valign="middle" colspan="3"><br /><br />
                 <asp:TextBox ID="txtmiles" runat="server" Width="105px" TabIndex="33"></asp:TextBox>Definition of Coastal Waters: island, gulf,<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ocean, bays and inter-coastal waterway
                <asp:RequiredFieldValidator
                 ID="rfvmilestidal" runat="server" ControlToValidate="txtmiles" ErrorMessage="Miles to tidal water cannot be blank(Home description)">*</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="rexvmiles" runat="server" ControlToValidate="txtmiles"
                          ErrorMessage="Invalid miles to coastal water " ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                 </td>
             <td></td>
             <td></td>
        </tr>
        <tr>
            <td align="left" style="width: 200px">
                <span style="color: #ff0000">*</span> Do you have a Pool:</td>
            <td align="left" style="color: #ff0000" colspan="3">
                <asp:DropDownList ID="ddlpool" runat="server" Width="110px" TabIndex="34">
                <%--<asp:ListItem Value="1">No</asp:ListItem>
                    <asp:ListItem Value="2">Yes Fence / Cage</asp:ListItem>
                    <asp:ListItem Value="3">Yes No Fence</asp:ListItem>--%></asp:DropDownList>
            </td>
             <td></td>
             <td></td>
        </tr>
        <tr>
            
                        <td align="left" style="width: 300px">
                        </td>
                        <td align="left">
                            Yes</td>
                        <td align="left" >
                            No</td>
                        <td >
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 300px">
                            <span style="color: #ff0000">*</span>Do you have a trampoline?&nbsp;<br />
                            <span style="color: #ff0000">&nbsp;</span>
                        </td>
                        <td align="left">
                            <asp:RadioButton ID="rdoH03trampolineYes" runat="server" GroupName="trampoline" TabIndex="35"
                                 /></td>
                        <td align="left">
                            <asp:RadioButton ID="rdoH03trampolineNo" runat="server" GroupName="trampoline" TabIndex="36"
                                 /></td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 300px">
                            <span style="color: #ff0000">*</span>Do you have Pets? &nbsp;<br />
                            <span style="color: #ff0000">(If Yes,Please describe breed </span>
                              </td>
                        <td align="left">
                            <asp:RadioButton ID="rdoh03petsAnsYes" runat="server" GroupName="pets" onclick="JavaScript:Click1(this,'txtpets')" TabIndex="37" /></td>
                        <td align="left">
                            <asp:RadioButton ID="rdoh03petsAnsNo" runat="server" GroupName="pets"  onclick="JavaScript:Click1(this,'txtpets')" TabIndex="38" /></td>
                        <td>
                            <asp:TextBox ID="txtpets" runat="server" Height="30px" TextMode="MultiLine"
                                Width="300px" TabIndex="37"></asp:TextBox>
                        </td>
                    </tr>
                
        <tr>
            <td align="left" style="width: 300px" >
                <span style="color: #ff0000">*</span> Roof Installed/Updated</td>
            <td align="left" colspan="3">
            <asp:DropDownList ID="ddlroofage" runat="server" Width="110px" TabIndex="39" >
             </asp:DropDownList></td>
             <td></td><td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px" >
                <span style="color: #ff0000">*</span> Square Footage</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtsqfootage" runat="server" Width="105px" TabIndex="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvsqfootage" runat="server" ControlToValidate="txtsqfootage"
                    ErrorMessage="Square footage cannot be blank(Home description)">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rexvsqfootage" runat="server" ControlToValidate="txtsqfootage"
                          ErrorMessage="Invalid square footage" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                 
                    </td>
                 <td></td><td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Stories</td>
            <td align="left" colspan="3">
                <asp:DropDownList ID="ddlstories" runat="server" Width="110px" TabIndex="41">
                <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem></asp:DropDownList>
            </td>
             <td></td><td></td>
        </tr>
        
        <tr>
            <td align="left" style="width: 300px" >
                <span style="color: #ff0000">*</span> Feet From fire hydrant</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtfirehydrant" runat="server" Width="108px" TabIndex="42"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvfirehydrant" runat="server" ControlToValidate="txtfirehydrant"
                    ErrorMessage="Feet from fire hydrant water cannot be blank(Home description)">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rexvfeetfromhydrant" runat="server" ControlToValidate="txtfirehydrant"
                          ErrorMessage="Invalid feet from fire hydrant" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                 
                    </td>
                 <td></td><td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Miles to Fire Station</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtmilestofirestation" runat="server" Width="108px" TabIndex="43"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvfirstation" runat="server" ControlToValidate="txtmilestofirestation"
                    ErrorMessage="Miles to fire station cannot be blank(Home description)">*</asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="rexvmilestofirestation" runat="server" ControlToValidate="txtmilestofirestation"
                          ErrorMessage="Invalid Miles to fire station" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator> 
                    </td>
                 <td></td><td></td>
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">&nbsp;</span> Fire District</td>
            <td align="left" colspan="3">
                 <asp:TextBox ID="txtfiredistrict" runat="server"
                                Width="241px" TabIndex="44"></asp:TextBox>
            </td>
                                 <td></td><td></td>
        </tr>
         <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Wind Protective Devices</td>
            <td align="left" colspan="3">
                <asp:DropDownList ID="ddlprotectivedeviceswind" runat="server" Width="244px" TabIndex="45">
                <asp:ListItem Value="1">None</asp:ListItem>
                    <asp:ListItem Value="2">Hurricane Shutters</asp:ListItem>
                    <asp:ListItem Value="3">Impact reistant glass</asp:ListItem></asp:DropDownList>
            </td>
             <td></td><td></td>
        </tr>
        
        
    </table>
</fieldset>
</ContentTemplate>
</asp:UpdatePanel>
