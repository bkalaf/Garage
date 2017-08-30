<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CommercialAuto.aspx.vb" Inherits="CommercialAuto" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%--<%@ Reference Control="~/CommercialAuto/HeaderControl.ascx" %>
--%><%@ Reference Control="~/CommercialAuto/AutoCommInsuranceHistorycontrol.ascx"%>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1"/>
    <meta name="generator" content="Adobe GoLive"/>
    <title>SIU - Commercial Transportation Quote Sheet</title>
    <style type="text/css" media="screen">
		
body { background-color: #666; background-image: url(images/background.jpg); background-repeat: repeat-x; margin: 0; padding: 0 }
h1{ color: #fff; font-size: 30px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; margin-bottom: 0; padding: 95px 0 0 100px }
h5 { color: #fff; font-size: 16px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; margin-bottom: 0; padding: 30px 0 0 195px }
h6 { color: #fff; font-size: 10px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; padding: 0 0 0 195px }
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
.fieldset      { padding: 1px; padding-top:-5px; margin-top: 0px; margin-bottom: 2px;
background-color: #fdf9e5; background-image: url(images/fieldback.jpg); background-repeat: repeat-x; background-position: 0 bottom; clear: left; border: solid 1px #999 }
legend      { color: #666; font-size: 15px; font-family: Arial; font-weight: bold; margin: 0 0 0 20px; padding: 0 }
fieldset ol   { list-style: none; padding-top: 10px; padding-right: 10px; padding-left: 10px }
fieldset li    { padding-bottom: 10px; width: 100%; float: left; clear: left }
fieldset.submit   { background-color: transparent; background-image: none; padding-top: 20px; padding-left: 100px; width: auto; float: none; border-style: none }
label    { color: #666; font-size: 13px; font-family: Arial; text-align: right; display: block; margin-right: 10px; width: 150px; float: left }
label2    { color: #666; font-size: 13px; font-family: Arial; text-align: left; margin-right: 10px; width: auto }

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
#test input {width:auto}
<!--[if lte IE7]>
<style type="text/css" media="all">
@import "fieldset-styling-ie.css";
</style>
		<![endif]>

-->
		</style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Select2_onclick() {
  
}

// ]]>
    </script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
</head>
   <body background="(EmptyReference!)" leftmargin="0" marginheight="0" marginwidth="0"
    topmargin="0">
    <center>
        <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            <div align="center">
               
       <asp:PlaceHolder  ID="HeaderPh" runat="server"></asp:PlaceHolder>
      
          </div>
          <div>
          <table border="0" cellspacing="0" cellpadding="0" style="background-color: White">
               <tr>
                    <td colspan="2" align="left">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Transparent"
                            BorderColor="Gray" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                         <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnSearch" runat="server" Text="Search Quotes"/></td>
                </tr>
                 
            
                <tr>
                    <td align="center" valign="top">
                        <div style="text-align: center">
                        
      
       <asp:PlaceHolder  ID="AgencyInfoPh" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder  ID="OperationPh" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder  ID="Vehicleph" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder  ID="DriverPh" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder  ID="InsuranceHistoryPh" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder  ID="Coverageph" runat="server"></asp:PlaceHolder>
        <fieldset>
                                <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                            <input type="button" onclick="javascript:window.print();" value="Print" />
                                            <asp:TextBox ID="txtGQID" runat="server" Visible="false" Text="0"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
      
                         </div>
                    </td>
                </tr>
            </table>
      
    
       </div>
       <div>
        
                 <asp:PlaceHolder ID="FooterPh" runat="server"></asp:PlaceHolder>
                
       </div>
       
    
   </form>
    </center>
<%--<iframe name="gToday:normal:agenda.js" id="gToday:normal:agenda.js"
src="includes/ipopeng.htm" scrolling="no" frameborder="0"
style="visibility:visible; z-index:999; position:absolute; top:-500px; left:-500px;">
<layer name="gToday:normal:agenda.js" src="npopeng.htm" background="npopeng.htm">     </LAYER>
</iframe> --%>
</body>
</html>
