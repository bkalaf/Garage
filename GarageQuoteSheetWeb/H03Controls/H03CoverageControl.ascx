<%@ Control Language="VB" AutoEventWireup="false" CodeFile="H03CoverageControl.ascx.vb" Inherits="UserControlH03.H03CoverageControl" %>
<script language="JavaScript" type="text/javascript">
              
         function Click2(obj,ctrl)
    {   
        //alert(obj.id.substring(0,obj.id.lastIndexOf("_")));
        var str=obj.id.substring(0,obj.id.lastIndexOf("_"));
       // obj.Text=obj.checked;
       //alert(obj.Text);
        if((obj.id.indexOf("AnsNo") != -1) &&  (obj.checked == true))
        {  
         
          document.getElementById(str + "_"  + ctrl).disabled=true;
         // alert(document.getElementById(str + "_"  + ctrl).id));
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
  
  <fieldset>
    <legend><strong>Coverages</strong></legend>
   <table border="0" cellpadding="0" cellspacing="0" class="fieldset" style="width: 680px; height: 240px">
       
                  
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Coverage A-dwelling (in dollars):</td>
            <td align="left" colspan="3">
              <asp:TextBox ID="txtcoverageA" runat="server" Width="120px" TabIndex="56" onkeypress="JavaScript:CheckNumeric()"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvcoverage" ControlToValidate="txtcoverageA"  runat="server" ErrorMessage="Coverage A-dwelling cannot be blank(Coverage details)">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="rfvcoverageA" runat="server" ControlToValidate="txtcoverageA"
                ErrorMessage="Invalid Coverage A-dwelling" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
               </td>
               <td></td> 
        </tr>
       <tr>
           <td align="left" style="width: 300px">
               &nbsp;&nbsp; Coverage B- Adjacent Structures:</td>
           <td align="left" colspan="3">
               <asp:TextBox ID="txtCoverageB" runat="server" Width="120px" Enabled="False">0.0</asp:TextBox></td>
           <td>
           </td>
       </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Coverage C-personal property(in dollars):</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtCoverageC" runat="server" Width="120px" TabIndex="57" onkeypress="JavaScript:CheckNumeric()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcovergagec" ControlToValidate="txtCoverageC"  runat="server" ErrorMessage="Coverage C-personal cannot be blank(Coverage details)">*</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="rexv" runat="server" ControlToValidate="txtCoverageC"
                ErrorMessage="Invalid Coverage C-dwelling" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                </td>
            <td></td> 
        </tr>
       <tr>
           <td align="left" style="width: 300px">
               &nbsp;&nbsp; Coverage D - Loss of Use:</td>
           <td align="left" colspan="3" style="color: #ff0000">
               <asp:TextBox ID="txtCoverageD" runat="server" Enabled="False"  Width="120px">0.0</asp:TextBox></td>
           <td>
           </td>
       </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Coverage E-liability:</td>
             <td align="left" style="color: #ff0000" colspan="3">
                <asp:DropDownList ID="ddlCoverageEliability" runat="server" Width="120px" TabIndex="58">
                     <asp:ListItem>$100,000</asp:ListItem>
                    <asp:ListItem>$300,000</asp:ListItem>
                     <asp:ListItem>$500,000</asp:ListItem>

                    </asp:DropDownList>
            </td> <td></td> 
        </tr>
        <tr>
            <td align="left" style="width: 300px">
                <span style="color: #ff0000">*</span> Coverage F-Med Pay:</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtcoverageFmed" onkeypress="JavaScript:CheckNumeric()" runat="server" Width="120px" Text="2000" ReadOnly="true" TabIndex="59"></asp:TextBox></td>
                 <td></td> 
        </tr>
        <tr>
            <td align="left" style="width: 300px; height: 22px;">
                <span style="color: #ff0000">*</span> Deductible for all perils:</td>
           <td align="left" colspan="3" style="height: 22px">
                <asp:DropDownList ID="ddlperils" runat="server" Width="120px" TabIndex="60">
                <asp:ListItem>1000</asp:ListItem>
                    <asp:ListItem>2500</asp:ListItem>
                     <asp:ListItem>5000</asp:ListItem>
                    </asp:DropDownList></td>
                 <td style="height: 22px"></td> 
        </tr>
         
       
                                    
        <tr>
          
               
                    
                        <td >
                        </td>
                        <td align="left" >
                            Yes</td>
                        <td align="left">
                             No</td>
                        <td >
                        </td>
         </tr>
                    <tr>
                        <td align="left" style="width: 300px; height: 41px;">
                            <span style="color: #ff0000">*</span>Wind and Hail Exclusion:&nbsp;<br />
                            <span style="color: #ff0000">(If No,Please Select deductible)</span>
                        </td>
                        <td align="left" style="height: 41px" >
                            <asp:RadioButton ID="rdoWindandHailExAnsNo" runat="server"  GroupName="Exclusion" onclick="JavaScript:Click2(this,'ddlwinddeductible')" TabIndex="61" /></td>
                        <td align="left" style="height: 41px">
                            <asp:RadioButton ID="rdoWindandHailExAnsYes" runat="server"  GroupName="Exclusion" onclick="JavaScript:Click2(this,'ddlwinddeductible')" TabIndex="62" /></td>
                         <td style="height: 41px">&nbsp;Wind Deductible: 
                           <asp:DropDownList ID="ddlwinddeductible" runat="server" AutoPostBack="False" Width="120px" TabIndex="63">
               <asp:ListItem Value="2">2%</asp:ListItem><asp:ListItem Value="3">3%</asp:ListItem>
                     <asp:ListItem Value="5">5%</asp:ListItem>

                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 300px; height: 39px;" >
                            <span style="color: #ff0000">*</span>Sink hole exclusion: &nbsp;<span style="font-size: small;
                                color: #ff0000">
                                <span style="color: #000000"></span></span></td>
                        <td align="left" style="height: 39px">
                            <asp:RadioButton ID="rdosinkholeexlusionYes" runat="server" GroupName="sinkexclusion" TabIndex="64" /></td>
                        <td align="left" style="height: 39px">
                            <asp:RadioButton ID="rdosinkholeexlusionNo" runat="server" GroupName="sinkexclusion" TabIndex="65" /></td>
                        <td style="height: 39px">
                            
                        </td>
                    </tr>
                     <tr>
                        <td align="left"  style="width: 300px">
                            <span style="color: #ff0000">*</span>Ordinance or law limits coverage A:&nbsp;</td>
                        <td align="left">
                            <asp:RadioButton ID="rdoOrdinanceLimitsyes" runat="server" GroupName="ordinance" TabIndex="66" /></td>
                        <td align="left">
                            <asp:RadioButton ID="rdoOrdinanceLimitsNo" runat="server" GroupName="ordinance" TabIndex="67" /></td>
                        <td>
                            
                        </td>
                    </tr>
               
           
     
        
        
        
    </table>
</fieldset>

