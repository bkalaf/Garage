<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  %>

<%@ Reference Control="~/UserControls/HeaderControl.ascx" %>








<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SIU Login</title>
    <script type="text/javascript" src="./Js/html-form-input-mask.js"></script>
<script type="text/javascript" src="./Js/prototype.js"></script>
<script language="JavaScript" type="text/javascript">
function addLoadEvent(func) 
{ 
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function() {
      if (oldonload) {
        oldonload();
      }
      func();
    }
  }
}
addLoadEvent(function()
 {
    Xaprb.InputMask.setupElementMasks();
});
</script>
    <style type="text/css" media="screen">
		
body { background-color: #666; background-image: url(images/background.jpg); background-repeat: repeat-x; margin: 0; padding: 0 }
h1   { color: #fff; font-size: 30px; font-family: Arial; font-weight: normal; text-align: left; margin-top: 0; margin-bottom: 0; padding: 95px 0 0 100px }
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
div#header  { background-color: #ddd; background-image: url(images/headerback.jpg); margin: 0 auto; padding-top: 0; width: 900px; height: 130px }
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

 
		</style>
    
</head>

 
<body  background="(EmptyReference!)" leftmargin="0" marginheight="0" marginwidth="0" topmargin="0">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <div align="center">
     
       <asp:PlaceHolder  ID="HeaderPh" runat="server"> </asp:PlaceHolder>
       
      
       </div>
       
       
       
       <div align="center">
   
       
       <asp:PlaceHolder  ID="LoginPh" runat="server"></asp:PlaceHolder>
       
        
       
       </div>
       
       
       
     
      <div align="center">
      
       <asp:PlaceHolder ID="FooterPh" runat="server"></asp:PlaceHolder>
          
         
       
       </div>
   
       
    
    </form>
</body>
</html>
