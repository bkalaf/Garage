<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CommAutoOperationControl.ascx.vb"
    Inherits="UserControl947.CommAutoOperationControl" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script language="JavaScript" type="text/javascript">
              
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
	function CheckNumeric()
   {
   debugger;
    vKey = window.event.keyCode;
    if (!isNumeric(vKey))
     window.event.keyCode=0;
   }
   function isNumeric (k)
   { alert(k);
    return ((k >= 48) && (k <= 57));
   }
	 function AllowAlphabet()
   {	 vKeycode = window.event.keyCode;
   if (!isAlphabet(vKeycode))
     window.event.keyCode=0;
    	
   	}
   	function isAlphabet (k)
   {
    return (((k >= 65) && (k <= 90))|| ((k >= 97) && (k <= 122)) || (k == 46) || (k == 32) || (k == 45));
   }					
function up(lstr)
{
	var str=lstr.value;
	lstr.value=str.toUpperCase();
          };

          $("document").ready(function () {
              var selector = $("#Operation_tbFilingNumber");
              var selector2 = $("#Operation_lblFilingNumber");
              $("#Operation_radioDOT").change(function () {
                  if (document.getElementById("Operation_radioDOT").value) {
                      selector.show();
                      selector2.show();
                  }
              });
              $("#Operation_radioMC").change(function () {
                  if (document.getElementById("Operation_radioMC").value) {
                      selector.show();
                      selector2.show();
                  }
              });
              $("#Operation_radioUnknown").change(function () {
                  if (document.getElementById("Operation_radioUnknown").value) {
                      selector.hide();
                      selector2.hide();
                  }
              });
              selector.hide();
              selector2.hide();
          });
</script>

<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
        <fieldset>
            <legend><strong>Operations</strong></legend>
            <table style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                class="fieldset">
                <tr>
                    <td align="Left" style="width: 400px">
                        <span style="color: #ff0000">*</span> Applicant Name:
                    </td>
                    <td align="Left" style="width: 361px">
                        <asp:TextBox ID="txtApplicantName" runat="server" MaxLength="50" Width="150px" TabIndex="7"
                            onkeyup="up(this)" />
                        <asp:RegularExpressionValidator ID="regexpName" runat="server" ControlToValidate="txtApplicantName"
                            ErrorMessage="Applicant Name(Operation)" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"
                            ValidationGroup="Garage">*</asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtApplicantName" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px">
                        <span style="color: #ff0000">*</span> Business Name:
                    </td>
                    <td align="Left" style="width: 361px">
                        <asp:TextBox ID="txtTradeName" runat="server" MaxLength="50" Width="244px" TabIndex="8"
                            onkeyup="up(this)" />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtTradeName" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px">
                        <span style="color: #ff0000">*</span> Garaging Address:
                    </td>
                    <td align="Left" style="width: 361px">
                        <asp:TextBox ID="txtaddress" runat="server" MaxLength="50" Width="244px" TabIndex="9" />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtaddress" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px; height: 24px;">
                        <span style="color: #ff0000">*</span> City:
                    </td>
                    <td align="Left" style="width: 361px; height: 24px;">
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="50" Width="244px" TabIndex="10" />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtCity" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px">
                        &nbsp&nbsp; County:
                    </td>
                    <td align="Left" style="width: 361px">
                        <asp:TextBox ID="txtCountry" runat="server" MaxLength="50" Width="244px" TabIndex="11" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px; height: 24px;">
                        <span style="color: #ff0000">*</span> State:
                    </td>
                    <td align="Left" style="width: 361px; height: 24px;">
                        <asp:TextBox ID="txtState" runat="server" MaxLength="2" Width="20px" TabIndex="12"
                            AutoPostBack="true" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtState"
                            ErrorMessage="State Cannot be Blank(Operations)" ValidationGroup="Garage">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblStateMsg" runat="server" ForeColor="red"></asp:Label>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtState" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="Left" style="width: 400px">
                        <span style="color: #ff0000">*</span> Zip Code:
                    </td>
                    <td align="Left" style="width: 361px">
                        <asp:TextBox ID="txtZIP" runat="server" MaxLength="5" Width="75px" TabIndex="13" />
                        <asp:RequiredFieldValidator ID="rqfzipcode" runat="server" ControlToValidate="txtZIP"
                            ErrorMessage="ZipCode Cannot be Blank(Operations)" ValidationGroup="Garage">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="txtZIP" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 400px">
                        <span style="color: #ff0000">*</span> Type of Business
                    </td>
                    <td>
                        <table style="border: solid 2px #999999" width="100%">
                            <tr>
                                <td align="right">
                                    Individual
                                </td>
                                <td align="center">
                                    <asp:RadioButton ID="rdoIndivudual" runat="server" GroupName="BusinessType" Checked="true"
                                        TabIndex="14" />
                                </td>
                                <td align="right">
                                    Partnership
                                </td>
                                <td align="center">
                                    <asp:RadioButton ID="rdoPartnerShip" runat="server" GroupName="BusinessType" />
                                </td>
                                <td align="right">
                                    Corporation
                                </td>
                                <td align="center">
                                    <asp:RadioButton ID="rdoCorporation" runat="server" GroupName="BusinessType" />
                                </td>
                                <td align="right">
                                    LLC
                                </td>
                                <td align="center">
                                    <asp:RadioButton ID="rdollc" runat="server" GroupName="BusinessType" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Years in Business
                    </td>
                    <td style="width: 400px" align="left">
                        <asp:DropDownList runat="server" ID="ddlYearsInBusiness" AutoPostBack="true" Width="122px"
                            TabIndex="15">
                            <asp:ListItem Value="-1">Select One</asp:ListItem>
                            <asp:ListItem Value="0">New Venture</asp:ListItem>
                            <asp:ListItem Value="1">1 - 3 Years</asp:ListItem>
                            <asp:ListItem Value="2">4 - 5 Years</asp:ListItem>
                            <asp:ListItem Value="3">6+ Years</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="ddlYearsInBusiness" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="Please select a valid value." MaximumValue="4" MinimumValue="1" 
                            Width="220px"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Years Insured:
                    </td>
                    <td style="width: 400px" align="left">
                        <asp:TextBox ID="txtyrs" runat="server" MaxLength="2" Width="50px" 
                            TabIndex="16" Height="22px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                            ControlToValidate="txtyrs" CssClass="validator" Display="Dynamic" 
                            ErrorMessage="This field is required." Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Operations of Insured:<br />
                        &nbsp;&nbsp;&nbsp;<span style="color: Green; font-size: small">(“For Hire Trucking”
                            quotes require MVRs)</span>
                    </td>
                    <td style="height: 27px; width: 361px;" align="left">
                        <asp:TextBox ID="txtMplOperations" runat="server" Height="61px" TextMode="MultiLine"
                            MaxLength="100" Width="354px" TabIndex="17"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator13" runat="server" ErrorMessage="This field is required."
                                ControlToValidate="txtMplOperations" CssClass="validator" 
                            Display="Dynamic" Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Number of Years insured has owned<br>
                        &nbsp;&nbsp; same type vehicles :
                    </td>
                    <td style="height: 27px; width: 361px;" align="left">
                        <asp:TextBox ID="txtnumyrs" runat="server" Height="61px" TextMode="MultiLine" MaxLength="100"
                            Width="354px" TabIndex="18"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                runat="server" ErrorMessage="This field is required."
                                ControlToValidate="txtnumyrs" CssClass="validator" Display="Dynamic" 
                            Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="100%">
                        <table width="100%">
                            <tr>
                                <td style="width: 211px" align="left">
                                </td>
                                <td align="center" style="width: 73px">
                                    Yes
                                </td>
                                <td align="center" style="width: 74px">
                                    No
                                </td>
                                <td width="300">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 360px" align="left">
                                    <span style="color: #ff0000">*</span>Are any filings required:
                                    <br />
                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                </td>
                                <td align="center" style="width: 73px; height: 38px;">
                                    <asp:RadioButton ID="rdfilingsAnsYes" GroupName="Filings" runat="server" onclick="JavaScript:Click(this,'txtmultfilings')"
                                        TabIndex="19" />
                                </td>
                                <td align="center" style="width: 74px; height: 38px;">
                                    <asp:RadioButton ID="rdfilingsAnsNo" GroupName="Filings" runat="server" onclick="JavaScript:Click(this,'txtmultfilings')"
                                        TabIndex="19" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmultfilings" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="300px" MaxLength="100" TabIndex="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 360px" align="center">
                                    <asp:RadioButton ID="radioDOT" runat="server" GroupName="FilingNumber" />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td align="center" style="width: 73px; height: 38px;">
                                    <asp:RadioButton ID="radioMC" runat="server" GroupName="FilingNumber" />
                                    <asp:Label ID="Label2" runat="server" Text="MC #"></asp:Label>
                                </td>
                                <td align="center" style="width: 74px; height: 38px;">
                                    <asp:RadioButton ID="radioUnknown" runat="server" GroupName="FilingNumber" 
                                        Width="93px" />
                                    <asp:Label ID="Label3" runat="server" Text="Unknown"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="tbFilingNumber" runat="server" Width="128px"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblFilingNumber" runat="server" Text="  Enter DOT/MC#" 
                                        Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 211px" align="left">
                                    <span style="color: #ff0000">*</span>Are all owned and operated<br>
                                    &nbsp;&nbsp; vehicles listed:
                                    <br />
                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If No, Please explain)</span>
                                </td>
                                <td align="center" style="width: 73px">
                                    <asp:RadioButton ID="rdovehivlesListesAnsNo" runat="server" GroupName="VehiclesListed"
                                        Style="width: 18px" onclick="JavaScript:Click(this,'txtMplVehicleslisted')" TabIndex="21" />
                                </td>
                                <td align="center" style="width: 74px">
                                    <asp:RadioButton ID="rdovehivlesListesAnsYes" runat="server" GroupName="VehiclesListed"
                                        Style="width: 18px" onclick="JavaScript:Click(this,'txtMplVehicleslisted')" TabIndex="21" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMplVehicleslisted" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="300px" MaxLength="100" TabIndex="22"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Commodities Hauled:<br />
                    </td>
                    <td style="width: 361px">
                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplCommoditieshauled" Height="60px"
                            Width="360px" MaxLength="100" TabIndex="23" /><asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                runat="server" ErrorMessage="This field is required."
                                ControlToValidate="txtMplCommoditieshauled" CssClass="validator" 
                            Display="Dynamic" Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> Radius of Operation:<br />
                    </td>
                    <td style="width: 361px;">
                        <asp:TextBox runat="server" TextMode="multiline" ID="txtradius" Height="60px" Width="360px"
                            MaxLength="100" TabIndex="24" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                ErrorMessage="This field is required."
                                ControlToValidate="txtradius" CssClass="validator" Display="Dynamic" 
                            Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" align="left">
                        <span style="color: #ff0000">*</span> List cities in which units are operated<br />
                    </td>
                    <td style="width: 361px">
                        <asp:TextBox runat="server" TextMode="multiline" ID="txtmulticities" Height="60px"
                            Width="360px" MaxLength="100" TabIndex="25" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                                runat="server" ErrorMessage="This field is required." ControlToValidate="txtmulticities" 
                            CssClass="validator" Display="Dynamic" Width="170px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="txtState" />
<asp:PostBackTrigger ControlID="ddlYearsInBusiness"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ddlYearsInBusiness"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="ddlYearsInBusiness"></asp:PostBackTrigger>
    </Triggers>
    <Triggers>
        <asp:PostBackTrigger ControlID="ddlYearsInBusiness" />
    </Triggers>
</asp:UpdatePanel>
