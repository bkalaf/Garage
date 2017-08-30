<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommAutoCoverageControl.ascx.vb" Inherits="UserControl947.CommAutoCoverageControl" %>
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

function processDD(dropDown) {
    var name = "Coverage_" + dropDown;
    var selector = $("#" + name);
    selector.empty();
    var option0 = "<option value='0'>Select One</option>";
    var option1 = "<option value='-1'>500</option>";
    var option2 = "<option value='2'>1000</option>";
    var option3 = "<option value='3'>2500</option>";
    var option4 = "<option value='4'>5000</option>";

    selector.append(option0, option1, option2, option3, option4);
    selector.mouseleave(function () {
        if (document.getElementById(name).value == -1) {
            document.getElementById(name).value = 0;
        }
    });
}
$("document").ready(function () {
    $("#<%= tbCoverageOther.ClientID %>").hide();
    $("#<%= lblCoverageOther.ClientID %>").hide();
    $("#<%= ddlCoverage.ClientID %>").mouseleave(function () {
        var selector = $("#<%= ddlCoverage.ClientID %>");
        if (selector.value == 4) {
            $("#<%= tbCoverageOther.ClientID %>").show();
            $("#<%= lblCoverageOther.ClientID %>").show();
        }
    });
    processDD("ddldedutible");
});
 </script>
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>	




							<fieldset>
                                <legend><strong>Coverage Details</strong></legend>
                                <table style="width: 680px; height: 50px" border="0" cellpadding="0" cellspacing="0"
                                    class="fieldset">
                                      
                                    <tr>
                                     <td colspan="2" width="100%">
                                      <table width="100%">
                                      <tr>
                                        <td align="Left">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> Cargo Only </td>
                                        <td align="Left">
                                                                          
                                            <asp:CheckBox runat="server" ID="chkcargo"  Width="100px" TabIndex="130" AutoPostBack="true">                                              
                                                
                                            </asp:CheckBox>
                                            
                                    
                                     </td>
                                    </tr>
                                      <tr id="csl" runat="server">
                                   
                                    <td align="left" width="360"></td>
                                    <td align="left" >CSL</td>
                                     <td align="left">SPLIT</td>
                                                                       
                                    </tr>
                                    <tr>
                                        <td  align="Left">
                                            <span style="color: #ff0000">*</span> Limits of Liability:</td>
                                        <td align="left" valign="top">
                                       
                                         <asp:DropDownList runat="server" ID="ddlLimitsliabilitycsl"  Width="100px" TabIndex="131" AutoPostBack="True">
                                             
                                      </asp:DropDownList>
                                      
                                    
                                     </td>
                                      <td align="left" valign="top">
                                      
                                          <asp:DropDownList runat="server" ID="ddllimitsliasplit"  Width="100px" TabIndex="131"  AutoPostBack="True" OnSelectedIndexChanged="ddllimitsliasplit_SelectedIndexChanged">
                                          <asp:ListItem Value="1">25/50/25</asp:ListItem>
                                          <asp:ListItem Value="2">50/100/25</asp:ListItem>
                                          <asp:ListItem Value="3">50/100/50</asp:ListItem>
                                          <asp:ListItem Value="4">100/300/25</asp:ListItem>
                                          <asp:ListItem Value="5">100/300/50</asp:ListItem>
                                          <asp:ListItem Value="6">100/300/100</asp:ListItem>
                                      </asp:DropDownList>
                                     
                                    
                                      
                                      </td>
                                      

                                   </tr>
                                    <tr id="Uninsured" runat="server">
                                        <td  align="Left">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span> Uninsured Motorist:</td>
                                       <td  align="Left" valign="top">
                                         
                                         <asp:DropDownList runat="server" ID="ddluninsuredMotoristcsl"  Width="161px" TabIndex="132" AutoPostBack="True">
                                             
                                      </asp:DropDownList>
                                          
                                         
                                          </td>
                                          <td align="left" valign="top">
                                          
                                         <asp:DropDownList runat="server" ID="ddluninsuredMotoristsplit"  Width="100px" TabIndex="132"  AutoPostBack="True" OnSelectedIndexChanged="ddluninsuredMotoristsplit_SelectedIndexChanged">
                                          <asp:ListItem Value="1">25/50/25</asp:ListItem>
                                          <asp:ListItem Value="2">50/100/25</asp:ListItem>
                                          <asp:ListItem Value="3">50/100/50</asp:ListItem>
                                          <asp:ListItem Value="4">100/300/25</asp:ListItem>
                                          <asp:ListItem Value="5">100/300/50</asp:ListItem>
                                          <asp:ListItem Value="6">100/300/100</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                          
                                          

                                    </td>
                                    </tr>
                                    <tr id="numdealer" runat="server">
                                        <td align="Left">&nbsp;&nbsp;
                                        <asp:Label ID="numdealertags" runat="server" text="No.of Dealer Tags"></asp:Label></td>
                                        <td align="Left">
                                      
                                            <asp:Textbox runat="server" ID="numofdealertags"   Width="300px" TabIndex="133"></asp:Textbox>
                                            
                                       
                                        </td>
                                    </tr>
                                    <tr id="trpip" runat="server">
                                        <td align="Left">&nbsp;&nbsp;
                                        <asp:Label ID="Label2" runat="server" text="PIP"></asp:Label></td>
                                        <td align="Left">
                                      
                                            <asp:Textbox runat="server" ID="txtpip"  TabIndex="134" Width="299px"></asp:Textbox>
                                            
                                       
                                        </td>
                                    </tr>
                                    
                                     <tr id="trdeductiblecargo" runat="server">
                                        <td align="Left">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> Deductible </td>
                                        <td align="Left">
                                      
                                            <asp:DropDownList runat="server" ID="DeductibleCargo"  Width="100px" TabIndex="135">                                              
                                                
                                            </asp:DropDownList>
                                            
                                       
                                        </td>
                                    </tr>
                                    <tr id="cargoaddinfo" runat="server">
                                        <td align="Left">&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" text="Additional Info"></asp:Label></td>
                                        <td align="Left">
                                      
                                            <asp:Textbox runat="server" ID="txtcargoAI"  TextMode="MultiLine" Height="60px" Width="300px"></asp:Textbox>
                                            
                                       
                                        </td>
                                    </tr>
                                    
                                    
                                    <tr id="trmedical" runat="server">
                                        <td align="Left">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> Medical Payments </td>
                                        <td align="Left">
                                      
                                            <asp:DropDownList runat="server" ID="ddlmedicalpayments"  Width="100px" TabIndex="136">                                              
                                                <asp:ListItem Value="1">1,000</asp:ListItem>
                                                <asp:ListItem Value="2">2,000</asp:ListItem>
                                                <asp:ListItem Value="3">5,000</asp:ListItem>
                                                <asp:ListItem Value="4">None</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                       
                                        </td>
                                    </tr>
                                  
                                    </table>
                                        </td>
                                    </tr>
                                    <tr id="yes" runat="server">
                                        <td colspan="2" width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 211px" align="left">
                                                    </td>
                                                    <td align="center" style="width: 73px">
                                                        Yes</td>
                                                    <td align="center" style="width: 74px">
                                                        No</td>
                                                    <td width="300">
                                                    </td>
                                                </tr>
                                                <tr id="hired" runat="server">
                                                    <td style="width: 211px; height: 38px;" align="left">
                                                        <span style="color: #ff0000">&nbsp;&nbsp;</span>Hired:
                                                        <br/>&nbsp;&nbsp;<span style="color: #ff0000; font-size:small">(If Yes, Provide cost
                                                            of Hire)</span>
                                                    </td>
                                                    <td align="center" style="width: 73px; height: 38px;">
                                                        <asp:RadioButton ID="rdohiredCnAnsYes" GroupName="Hired" runat="server"  onclick="JavaScript:Click(this,'txtmultcostofhire')" TabIndex="137"/></td>
                                                    <td align="center" style="width: 74px; height: 38px;">
                                                        <asp:RadioButton ID="rdohiredCnAnsNo" GroupName="Hired" runat="server"  onclick="JavaScript:Click(this,'txtmultcostofhire')" TabIndex="137" /></td>
                                                    <td>
                                                        <asp:TextBox ID="txtmultcostofhire" runat="server" TextMode="MultiLine" Height="60px"
                                                            Width="300px" MaxLength="100" Enabled="false" TabIndex="134" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="Non" runat="server">
                                                    <td style="width: 211px" align="left">
                                                        <span style="color: #ff0000">&nbsp;&nbsp;</span>Non Owned:&nbsp;<br/>&nbsp;&nbsp;<span style="color: #ff0000; font-size:small">(If Yes, Provide total number of employees)</span>
                                                    </td>
                                                    <td align="center" style="width: 73px">
                                                        <asp:RadioButton ID="rdononownedCnAnsYes" runat="server" GroupName="VehiclesListed"
                                                            Style="width: 18px" onclick="JavaScript:Click(this,'txtmulttotnumemployees')" TabIndex="138" /></td>
                                                    <td align="center" style="width: 74px">
                                                        <asp:RadioButton ID="rdononownedCnAnsNo" runat="server" GroupName="VehiclesListed"
                                                            Style="width: 18px"  onclick="JavaScript:Click(this,'txtmulttotnumemployees')" TabIndex="138" /></td>
                                                    <td>
                                                        <asp:TextBox ID="txtmulttotnumemployees" runat="server" TextMode="MultiLine" Height="60px"
                                                            Width="300px" MaxLength="100" Enabled="false" TabIndex="137" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                               
                                               
                                               
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="motortruck" runat="server">
                                        <td  align="Left" style="width:250px">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span> Motor Truck cargo/On-Hook:</td>
                                        <td>
                                            <asp:TextBox ID="txtmotortrukcargo" runat="server" Height="60px" TextMode="MultiLine" Width="300px" MaxLength="100" TabIndex="138"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span> Coverage:</td>
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlCoverage" Width="130px">
                                                <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="30,000" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="50,000" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="100,000" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:TextBox runat="server" ID="tbCoverageOther"></asp:TextBox>
                                            <asp:Label runat="server" ID="lblCoverageOther" Text="Please specify" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="deductible" runat="server">
                                        <td  align="Left" style="width:390px">
                                            <span style="color: #ff0000">&nbsp;&nbsp;</span> Deductible:</td>
                                         <td align="Left">
                                            <asp:DropDownList runat="server" ID="ddldedutible"  Width="100px" TabIndex="139">
                                                <asp:ListItem Value="1">500</asp:ListItem>
                                                <asp:ListItem Value="2">1,000</asp:ListItem>
                                                <asp:ListItem Value="3">2,500</asp:ListItem>
                                         
                                      </asp:DropDownList></td>
                                    </tr>                                  
                                    <tr id="secyes" runat="server">
                                        <td colspan="2" width="100%">
                                            <table width="100%">
                                             
                                                <tr>
                                                    <td style="width: 211px" align="left">
                                                    </td>
                                                    <td align="center" style="width: 73px">
                                                        Yes</td>
                                                    <td align="center" style="width: 74px">
                                                        No</td>
                                                    <td width="300">
                                                    </td>
                                                </tr>
                                                <tr id="reefer" runat="server">
                                                    <td style="width: 211px; height: 38px;" align="left">
                                                        <span style="color: #ff0000">&nbsp;&nbsp;</span>Reefer Breakdown:&nbsp;<br/>&nbsp;&nbsp;<span style="color: #ff0000; font-size:small"></span></td>
                                                    <td align="center" style="width: 73px; height: 38px;">
                                                        <asp:RadioButton ID="rdoreeferbrdwnCnYes" GroupName="Filings" runat="server" TabIndex="140" /></td>
                                                    <td align="center" style="width: 74px; height: 38px;">
                                                        <asp:RadioButton ID="rdoreeferbrdwnCnNo" GroupName="Filings" runat="server" TabIndex="140"  /></td>
                                                    <td>
                                                        <asp:TextBox ID="txtmultlnreeferbrkdwn" runat="server" TextMode="MultiLine" Height="60px"
                                                            Width="300px" MaxLength="100" TabIndex="141"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="addinfo" runat="server">
                                                    <td style="width: 211px" align="left">
                                                        <span style="color: #ff0000">&nbsp;&nbsp;</span>Additional Insured:&nbsp;<br/>&nbsp;</td>
                                                    <td align="center" style="width: 73px">
                                                        <asp:RadioButton ID="rdoaddInsuredCnYes" runat="server" GroupName="AddInsured"
                                                            Style="width: 18px" TabIndex="142" /></td>
                                                    <td align="center" style="width: 74px">
                                                        <asp:RadioButton ID="rdoaddInsuredCnNo" runat="server" GroupName="AddInsured"
                                                            Style="width: 18px" TabIndex="142"  /></td>
                                                    <td>
                                                        <asp:TextBox ID="txtmultaddinsured" runat="server" TextMode="MultiLine" Height="60px"
                                                            Width="300px" MaxLength="100" TabIndex="143"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                               
                                               
                                               
                                            </table>
                                        </td>
                                    </tr>
                                    
                                   
                                    
                                  
                                   
                                </table>
                                        
                            </fieldset>
                            </ContentTemplate>
                                                 <Triggers><asp:PostBackTrigger ControlID="chkcargo" /></Triggers>
                                                  <Triggers><asp:PostBackTrigger ControlID="ddllimitsliasplit" /></Triggers>
                                                  <Triggers><asp:PostBackTrigger ControlID="ddlLimitsliabilitycsl" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="ddluninsuredMotoristcsl" /></Triggers>
                                                 <Triggers><asp:PostBackTrigger ControlID="ddluninsuredMotoristsplit" /></Triggers>
                                                 
                                                </asp:UpdatePanel>
				

                       
				
		

                       
            
													
					