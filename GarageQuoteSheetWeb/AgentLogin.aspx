<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AgentLogin.aspx.vb" Inherits="AgentLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    
   <meta http-equiv="content-type" content="text/html;charset=iso-8859-1">
		<meta name="generator" content="Adobe GoLive">
		<title>Automobile Garage Quote Sheet</title>
		 <style type="text/css" media="screen">
		
body       { background-color: #666; background-image: url(images/background.jpg); background-repeat: repeat-x; margin: 0; padding: 0 }
h1      { color: #fff; font-size: 30px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; margin-bottom: 0; padding: 95px 0 0 100px }
h5   { color: #fff; font-size: 16px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; margin-bottom: 0; padding: 30px 0 0 195px }
h6   { color: #fff; font-size: 10px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; padding: 0 0 0 195px }
h2 {
	font-size: 15px;
	font-family: Arial;
	font-weight: bold;
	text-align: center;
	margin: 0;
	padding: 0;
	vertical-align: middle
}
h3  { font-size: 10px; font-family: Arial; margin: 0; padding: 15px 0 15px 100px }
h4    { color: #666666; font-size: 16px; font-family: Arial; font-style: normal; margin: 20px 0 0; padding-top: 0; padding-right: 30px }
fieldset      { background-color: #fdf9e5; background-image: url(images/fieldback.jpg); background-repeat: repeat-x; background-position: 0 bottom; margin: 20px 50px 0 75px; padding: 0; position: relative; width: 475px; float: left; clear: left; border: solid 1px #999 }
legend      { color: #666; font-size: 13px; font-family: Arial; font-weight: bold; margin: 0 0 0 20px; padding: 0 }
fieldset ol   { list-style: none; padding-top: 10px; padding-right: 10px; padding-left: 10px }
fieldset li    { padding-bottom: 10px; width: 100%; float: left; clear: left }
fieldset.submit   { background-color: transparent; background-image: none; padding-top: 20px; padding-left: 100px; width: auto; float: none; border-style: none }
label    { color: #666; font-size: 13px; font-family: Arial; text-align: right; display: block; margin-right: 10px; width: 150px; float: left }
label2    { color: #666; font-size: 13px; font-family: Arial; text-align: left; margin-right: 10px; width: auto }
input  { width: 200px }
textarea { width: 250px }
button { background-color: #666; padding: 6px; border: solid 1px #666 }
p {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 11px;
	line-height: 18px;
	color: #666666;
	padding-right: 60px;
}
#nav       { font-size: 12px; font-family: Arial; background-image: none; background-repeat: repeat; background-attachment: scroll; background-position: 0 0; text-align: center; letter-spacing: 1px; list-style-type: none; margin: 0 0 0 75px; padding: 0; width: auto; float: left }
#nav li  { text-align: center; margin: 0; padding: 0; float: left }
#nav a      { color: #fff; line-height: 30px; text-decoration: none; background-image: url(images/buttons.jpg); text-align: center; width: 100px; float: left; border-right: 3px none }
#nav #nav_con a {border: none;}
#nav a:hover    { background-image: url(images/buttons.jpg); background-repeat: repeat; background-attachment: scroll; background-position: -100px 0; text-align: center }
#nav li.current a   { color: #666; font-weight: bold; background-image: url(images/buttons.jpg); background-repeat: repeat; background-attachment: scroll; background-position: -200px 0 }
div#footer  { background-color: #ddd; background-image: url(images/footerback.jpg); margin: 0 auto; padding-top: 0; width: 900px; height: 120px }
a:link { color: #666; font-family: Arial; text-decoration: none }
a:visited { color: #666; font-family: Arial; text-decoration: none }
a:hover  { color: #333; font-family: Arial; text-decoration: underline }
a:active { color: #666; font-family: Arial; text-decoration: none }

<!--[if lte IE7]>
<style type="text/css" media="all">
@import "fieldset-styling-ie.css";
</style>
		<![endif]>

-->
		</style>
    
</head>
<body background="(EmptyReference!)" leftmargin="0" marginheight="0" marginwidth="0" topmargin="0">
		<form id="form1" runat="server">
         
		<div align="center">
			<table width="900" border="0" cellspacing="0" cellpadding="0" background="images/headerback.jpg" height="150">
				<tr>
					<td align="left" valign="top"><h1> Commercial Garage Quote Sheet</h1></td>

				</tr>
			</table>
			<table width="850" border="0" cellspacing="0" cellpadding="0" background="images/formback.jpg">

				<tr>
					<td align="center" valign="top" style=" width: 650px;">
						
							<fieldset style="left: 0px; top: 0px">
								<legend>Agency Information</legend>
								<ol>
								<li>
                                   <table style="width: 472px">
                                   <tr>
                                       <td colspan="2"  ><asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                       </td>
                                   </tr>
                                   <tr>
                                       <td colspan="2" align="center"><asp:Label ID="lblMessage" Width="450px"  runat="server" ForeColor="red"></asp:Label></td>
                                   </tr>
                                   <tr>
                                       <td><label for="txtCode"><span style=" color :Red">*</span>Agency Code:</label>
                                       </td>
                                       <td align="left"><asp:TextBox ID="txtCode" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="Please enter AgentCode">*</asp:RequiredFieldValidator></td>
                                   </tr>
                                   <tr>
                                        <td><label for="txtRequester"><span style=" color :Red">*</span>Person Requesting:</label></td>
                                        <td align="left"><asp:TextBox ID="txtRequester" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequester"
                                                ErrorMessage="Please Enter Person Requesting">*</asp:RequiredFieldValidator></td>
                                   </tr>
                                   <tr>
                                        <td><label for="txtPhone"><span style=" color :Red">*</span>Phone:<br />
                                            <strong>(NNN-NNN-NNNN)</strong></label></td>
                                        <td align="left"><asp:TextBox ID="txtPhone" runat="server" CssClass="text" MaxLength="12"></asp:TextBox><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
                                                ErrorMessage="Invalid Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator></td>
                                   </tr>
                                    <tr>
                                        <td><label for="optionemailfax">How do you want your quote replied?:</label></td>
                                        <td align="left"><asp:DropDownList ID="ddlReplyOptions" runat="server" Width="208px" AutoPostBack="True">
                                            <asp:ListItem>Email</asp:ListItem>
                                            <asp:ListItem>Fax</asp:ListItem>
                                        </asp:DropDownList></td>
                                   </tr>
                                   <tr>
                                        <td><label for="fax"><span style=" color :Red">*</span>Email/Fax:</label></td>
                                        <td align="left"><asp:TextBox ID="txtFaxNo" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regxvEmailOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator
                                                ID="regxvFaxOption" runat="server" ControlToValidate="txtFaxNo"
                                                ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Enabled="False" Width="1px">*</asp:RegularExpressionValidator></td>
                                   </tr>
                                  
                                   <tr>
                                    <td colspan="2" align="center" ><asp:Button ID="btnSubmit" runat="server" Text="Continue" Width="78px" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="78px" ValidationGroup="none" /></td>
                                   </tr>
                                   </table></li></ol>
							</fieldset>
													
					</td>
				</tr>
			</table>
		</div>

		<div id="footer" align="center" >
			<h5>Southern Insurance Underwriters, Inc </h5>
			<h6>&copy;2008 <a href="(EmptyReference!)">Privacy Statement</a> | <a href="(EmptyReference!)">Terms &amp; Conditions</a></h6>
		</div>
		</form>
	</body>

</html>