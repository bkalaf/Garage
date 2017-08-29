<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appication.aspx.vb" Inherits="Appication"
    EnableEventValidation="true" MaintainScrollPositionOnPostback="False" SmartNavigation="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CustomValidationSummaryControl" Namespace="Controls" TagPrefix="cusSum" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Reference Control="~/UserControls/HeaderControl.ascx" %>
<%@ Reference Control="~/CommercialAuto/CommAutoOperationControl.ascx" %>
<%@ Reference Control="~/CommercialAuto/AgencyInformation.ascx" %>
<%@ Reference Control="~/CommercialAuto/CommAutoCoverageControl.ascx" %>
<%@ Reference Control="~/CommercialAuto/CommAutoVehicleControl.ascx" %>
<%@ Reference Control="~/CommercialAuto/CommAutoDriverControl.ascx" %>
<%@ Reference Control="~/CommercialAuto/AutoCommInsuranceHistorycontrol.ascx" %>
<%@ Reference Control="~/CommercialAuto/AdditionalNotes.ascx" %>
<%@ Reference Control="~/H03Controls/H03InsuranceHistorycontrol.ascx" %>
<%@ Reference Control="~/CommercialAuto/CommAutoPanelSearch.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
    <meta http-equiv="X-UA-Compatible" content="IE=10" />
    <meta name="generator" content="Adobe GoLive" />
    <title>
        <%=strTitle %></title>

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <style type="text/css">
        .DashboardButton
        {
            border-radius: 3px;
            height: 30px;
            width: 110px;
            text-align: center;
            font-size: 15px;
            font-weight: normal;
            background-color: Gray;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
            z-index: 9999999999;
        }
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            width: 100px;
            height: 110px;
            display: none;
            position: fixed;
            background-color: white;
            z-index: 999;
        }
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 100;
            display: none;
        }
        .cnt223 a
        {
            text-decoration: none;
        }
        .popup
        {
            width: 100%;
            margin: 0 auto;
            display: none;
            position: fixed;
            z-index: 101;
        }
        .cnt223
        {
            min-width: 600px;
            width: 600px;
            min-height: 150px;
            margin: 100px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }
        .cnt223 p
        {
            clear: both;
            color: #555555;
            text-align: justify;
        }
        .cnt223 p a
        {
            color: #d91900;
            font-weight: bold;
        }
        .cnt223 .x
        {
            float: right;
            height: 35px;
            left: 22px;
            position: relative;
            top: -25px;
            width: 34px;
        }
        .cnt223 .x:hover
        {
            cursor: pointer;
        }
    </style>

    <script type="text/javascript" src="./Js/html-form-input-mask.js"></script>

    <script type="text/javascript" src="./Js/prototype.js"></script>

    <script language="JavaScript" type="text/javascript">

        function addLoadEvent(func) {
            var oldonload = window.onload;
            if (typeof window.onload != 'function') {
                window.onload = func;
            } else {
                window.onload = function () {
                    if (oldonload) {
                        oldonload();
                    }
                    func();
                }
            }
        }
        addLoadEvent(function () {
            Xaprb.InputMask.setupElementMasks();
        });
        function CheckNumeric() {
            vKey = window.event.keyCode;
            if (!isNumeric(vKey))
                window.event.keyCode = 0;
        }
        function isNumeric(k) {
            return ((k >= 48) && (k <= 57));
        }

        function CheckAmount(obj) {
            vKey = window.event.keyCode;
            if ((document.getElementById(obj.id).value.indexOf(".") != -1) && (vKey == 46))
                window.event.keyCode = 0;
            else {
                if (!isNumeric(vKey) && (vKey != 46))
                    window.event.keyCode = 0;
            }

        }
        function Confirmation1() {
            //alert(document.getElementById("Vehicle_txyear1"));  
            var i = 1;
            var flag = 0;
            var objyr, objmake, objstated, objgvw, objded, objtyp;
            var rowNo;
            for (i = 1; i <= 10; i++) {

                objyr = document.getElementById("Vehicle_txyear" + i);
                objmake = document.getElementById("Vehicle_txtMake" + i);
                objtyp = document.getElementById("Vehicle_txttype" + i);
                objstated = document.getElementById("Vehicle_txtstatedvalue" + i);
                objgvw = document.getElementById("Vehicle_txtGVW" + i);


                if (objyr.value != "" || objmake.value != "" || objtyp.value != "" || objstated.value != "" || objgvw.value != "") {
                    if (objyr.value == "" || objmake.value == "" || objtyp.value == "" || objstated.value == "" || objgvw.value == "") {
                        flag = 1;
                        rowNo = i;
                        break;
                    }
                }

            }
            if (flag == 1) {

                return confirm("Row No" + rowNo + " of Vehicle Control is incomplete.Still do you want to submit?");

            }
            else {
                return true;

            }
        }

        function CheckFile(ctrl) {
            debugger;
            var file = document.getElementById(ctrl.id);
            
            if(file.value.length>0)
            {
            var len = file.value.length;
            var ext = file.value;
            if (ext.substr(len - 3, len) != "pdf") {
            file.value='';
            var id=file.id;
            if(file.value.length>0)
            {
            if(id=="upl1")
            var input = $('#upl1');
            else if(id=="upl2")
            var input = $('#upl2');
             else if(id=="upl3")
            var input = $('#upl3');
             else if(id=="upl4")
            var input = $('#upl4');
             else if(id=="upl5")
            var input = $('#upl5');
              input.replaceWith(input.val('').clone(true));
            }
                alert("Please select a pdf file ");
                //Clear(file);
                //ClearFileUpload(file);
//                $fileInput = $('#fileInput');
//                 $fileInput.replaceWith( $fileInput = $fileInput.clone( true ) );
            }
            else
            {
             
            }
            }
        }
        
        function Clear(Cntrl) {
            //Reference the FileUpload and get its Id and Name.
            var fileUpload = Cntrl;
            var id = fileUpload.id;
            var name = fileUpload.name;

            //Create a new FileUpload element.
            var newFileUpload = document.createElement("INPUT");
            newFileUpload.type = "FILE";

            //Append it next to the original FileUpload.
            fileUpload.parentNode.insertBefore(newFileUpload, fileUpload.nextSibling);

            //Remove the original FileUpload.
            fileUpload.parentNode.removeChild(fileUpload);

            //Set the Id and Name to the new FileUpload.
            newFileUpload.id = id;
            newFileUpload.name = name;
            newFileUpload.onchange= CheckFile();
            return false;
        }
 
    </script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <style type="text/css" media="screen">
        body
        {
            background-color: #666;
            background-image: url(images/background.jpg);
            background-repeat: repeat-x;
            margin: 0;
            padding: 0;
        }
        h1
        {
            color: #fff;
            font-size: 30px;
            font-family: Arial;
            font-weight: normal;
            text-align: left;
            margin-top: 0;
            margin-bottom: 0;
            padding: 95px 0 0 100px;
        }
        h5
        {
            color: #fff;
            font-size: 16px;
            font-family: Arial;
            font-weight: normal;
            text-align: left;
            margin-top: 0;
            margin-bottom: 0;
            padding: 30px 0 0 195px;
        }
        h6
        {
            color: #fff;
            font-size: 10px;
            font-family: Arial;
            font-weight: normal;
            text-align: left;
            margin-top: 0;
            padding: 0 0 0 195px;
        }
        h2
        {
            font-size: 15px;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            margin: 0;
            padding: 0;
            vertical-align: middle;
        }
        h3
        {
            font-size: 10px;
            font-family: Arial;
            margin: 0;
            padding: 15px 0 15px 100px;
        }
        h4
        {
            color: #666666;
            font-size: 16px;
            font-family: Arial;
            font-style: normal;
            margin: 20px 0 0;
            padding-top: 0;
            padding-right: 30px;
        }
        .fieldset
        {
            padding: 1px;
            padding-top: -5px;
            margin-top: 0px;
            margin-bottom: 2px;
            background-color: #fdf9e5;
            background-image: url(images/fieldback.jpg);
            background-repeat: repeat-x;
            background-position: 0 bottom;
            clear: left;
            border: solid 1px #999;
        }
        legend
        {
            color: #666;
            font-size: 15px;
            font-family: Arial;
            font-weight: bold;
            margin: 0 0 0 20px;
            padding: 0;
        }
        fieldset ol
        {
            list-style: none;
            padding-top: 10px;
            padding-right: 10px;
            padding-left: 10px;
        }
        fieldset li
        {
            padding-bottom: 10px;
            width: 100%;
            float: left;
            clear: left;
        }
        fieldset.submit
        {
            background-color: transparent;
            background-image: none;
            padding-top: 20px;
            padding-left: 100px;
            width: auto;
            float: none;
            border-style: none;
        }
        label
        {
            color: #666;
            font-size: 13px;
            font-family: Arial;
            text-align: right;
            display: block;
            margin-right: 10px;
            width: 150px;
            float: left;
        }
        label2
        {
            color: #666;
            font-size: 13px;
            font-family: Arial;
            text-align: left;
            margin-right: 10px;
            width: auto;
        }
        button
        {
            background-color: #666;
            padding: 6px;
            border: solid 1px #666;
        }
        p
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            line-height: 18px;
            color: #666666;
            padding-right: 60px;
        }
        #nav
        {
            font-size: 12px;
            font-family: Arial;
            background-image: none;
            background-repeat: repeat;
            background-attachment: scroll;
            background-position: 0 0;
            text-align: center;
            letter-spacing: 1px;
            list-style-type: none;
            margin: 0 0 0 75px;
            padding: 0;
            width: auto;
            float: left;
        }
        #nav li
        {
            text-align: center;
            margin: 0;
            padding: 0;
            float: left;
        }
        #nav a
        {
            color: #fff;
            line-height: 30px;
            text-decoration: none;
            background-image: url(images/buttons.jpg);
            text-align: center;
            width: 100px;
            float: left;
            border-right: 3px none;
        }
        #nav #nav_con a
        {
            border: none;
        }
        #nav a:hover
        {
            background-image: url(images/buttons.jpg);
            background-repeat: repeat;
            background-attachment: scroll;
            background-position: -100px 0;
            text-align: center;
        }
        #nav li.current a
        {
            color: #666;
            font-weight: bold;
            background-image: url(images/buttons.jpg);
            background-repeat: repeat;
            background-attachment: scroll;
            background-position: -200px 0;
        }
        div#footer
        {
            background-color: #ddd;
            background-image: url(images/footerback.jpg);
            margin: 0 auto;
            padding-top: 0;
            width: 900px;
            height: 120px;
        }
        a:link
        {
            color: #666;
            font-family: Arial;
            text-decoration: none;
        }
        a:visited
        {
            color: #666;
            font-family: Arial;
            text-decoration: none;
        }
        a:hover
        {
            color: #333;
            font-family: Arial;
            text-decoration: underline;
        }
        a:active
        {
            color: #666;
            font-family: Arial;
            text-decoration: none;
        }
        #test input
        {
            width: auto;
        }
        .divWaiting
        {
            position: absolute;
            background-color: #FAFAFA;
            z-index: 2147483647 !important;
            overflow: hidden;
            text-align: center;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            padding-top: 30%;
        }
    </style>
</head>
<body onload="history.forward()" background="(EmptyReference!)" leftmargin="0" marginheight="0"
    marginwidth="0" topmargin="0">
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="loading" align="center">
            <img src="Images/progressbar.gif" alt="" /><br />
            <b>Processing. Please wait.</b>
        </div>
        <%-- <div style="width: 100%; height: 100%; z-index: 99999; background-color: Gray; display: none;
            z-index: 99999999999;" id="divback" runat="server">
        </div>--%>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div align="center">
                    <asp:PlaceHolder ID="HeaderPh" runat="server"></asp:PlaceHolder>
                </div>
                <div>
                    <table border="0" cellspacing="0" cellpadding="0" style="background-color: White;
                        width: 800px">
                        <tr>
                            <td colspan="2" align="left">
                                <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Transparent"
                                    BorderColor="Gray" />--%>
                                <cusSum:AjaxValidationSummary ID="ValidationSummary1" runat="server" BackColor="Transparent"
                                    BorderColor="Gray" ValidationGroup="Garage" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" style="height: 26px">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl1" runat="server" Text="."
                                    Font-Size="X-Large" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp;&nbsp;<asp:Label
                                        ID="lblMessage" runat="server" Visible="false" ForeColor="red" Font-Bold="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:Button ID="btnSearch" ValidationGroup="Search" runat="server" Text="Search Quotes"
                                    OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div style="text-align: center">
                                    <asp:PlaceHolder ID="AgencyInfoPh" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="SearchPh" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="OperationPh" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="Vehicleph" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="DriverPh" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="InsuranceHistoryPh" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="Coverageph" runat="server"></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="MVRUploadph" runat="server">
                                        <fieldset>
                                            <legend><strong>MVR Uploads</strong></legend>
                                            <table style="width: 680px; height: 50px;" border="0" cellpadding="0" cellspacing="0"
                                                class="fieldset">
                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="text-align: left;">
                                                                    <b>If this is a “For Hire Trucking” quote request, please upload MVRs below.</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="text-align: left;">
                                                                                Attach MVR pdf:
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:FileUpload ID="upl1" runat="server" onchange="javascript:CheckFile(this);" />
                                                                                <%-- <asp:RegularExpressionValidator ID="revupload1" Display="Dynamic" runat="server"
                                                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                                                    ControlToValidate="upl1" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox ID="lblFile1" runat="server" Style="display: none;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left;">
                                                                                Attach MVR pdf:
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:FileUpload ID="upl2" runat="server" onchange="javascript:CheckFile(this);" />
                                                                                <%-- <asp:RegularExpressionValidator ID="revupload2" Display="Dynamic" runat="server"
                                                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                                                    ControlToValidate="upl2" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox ID="lblFile2" runat="server" Style="display: none;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left;">
                                                                                Attach MVR pdf:
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:FileUpload ID="upl3" runat="server" onchange="javascript:CheckFile(this);" />
                                                                                <%--  <asp:RegularExpressionValidator ID="revupload3" runat="server" Display="Dynamic"
                                                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                                                    ControlToValidate="upl3" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox ID="lblFile3" runat="server" Style="display: none;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left;">
                                                                                Attach MVR pdf:
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:FileUpload ID="upl4" runat="server" onchange="javascript:CheckFile(this);" />
                                                                                <%-- <asp:RegularExpressionValidator ID="revupload4" runat="server" Display="Dynamic"
                                                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                                                    ControlToValidate="upl4" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox ID="lblFile4" runat="server" Style="display: none;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left;">
                                                                                Attach MVR pdf:
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:FileUpload ID="upl5" runat="server" onchange="javascript:CheckFile(this);" />
                                                                                <%-- <asp:RegularExpressionValidator ID="revupload5" runat="server" Display="Dynamic"
                                                                                    ErrorMessage="Only PDF files are allowed!" Text="*" ValidationGroup="Upload"
                                                                                    ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                                                    ControlToValidate="upl5" CssClass="text-red"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox ID="lblFile5" runat="server" Style="display: none;"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <%-- <asp:ValidationSummary ID="valsumuploads" runat="server" ValidationGroup="Upload"
                                                                        ShowMessageBox="true" ShowSummary="true" />--%>
                                                                    <%-- <cusSum:AjaxValidationSummary ID="valsumuploads" runat="server" BackColor="Transparent"
                                                                        BorderColor="Gray" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="AdditionalPh" runat="server"></asp:PlaceHolder>
                                    <fieldset>
                                        <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                            <tr>
                                                <td colspan="2" align="left" style="height: 26px">
                                                    <asp:Label ID="lbl2" runat="server" Text="." Font-Size="X-Large" Font-Bold="True"
                                                        ForeColor="Red"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblmsg1" runat="server" Visible="false"
                                                            ForeColor="red" Font-Bold="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="height: 27px">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="152" CausesValidation="true"
                                                        ValidationGroup="Garage" />
                                                    <%-- <input type="button" onclick="javascript:window.print();" value="Print" id="btnPrint"
                                                        tabindex="153" />--%>
                                                    <input id="Button1" type="button" value="Cancel" language="javascript" onclick="location.href='Default.aspx';"
                                                        tabindex="153" />
                                                    <%--<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancel" ValidationGroup="none"
                                                        Visible="false" TabIndex="153" CausesValidation="false" />--%>
                                                    <asp:TextBox ID="txtGQID" runat="server" Visible="false" Text="0"></asp:TextBox>
                                                    <input id="hdnSubmit" runat="server" type="hidden" value="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <%-- <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="Transparent"
                                                        BorderColor="Gray" />--%>
                                                    <cusSum:AjaxValidationSummary ID="ValidationSummary2" runat="server" BackColor="Transparent"
                                                        BorderColor="Gray" ValidationGroup="Garage" />
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
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <ajaxToolkit:ModalPopupExtender ID="mpeConfirm" BackgroundCssClass="modal" runat="server"
                    TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnhide"
                    DropShadow="true">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="white" Height="184px" Width="450px">
                    <table width="100%" style="border: Solid 2px #d07c00; width: 100%; height: 100%"
                        cellpadding="0" cellspacing="0">
                        <tr style="background-color: #e9c002;">
                            <td style="height: 10%; color: White; font-weight: bold; padding: 3px; font-size: larger;
                                font-family: Calibri" align="Left">
                                Confirmation
                            </td>
                            <td style="color: White; font-weight: bold; padding: 3px; font-size: larger;" align="Right">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" style="padding: 5px; font-family: Verdana; font-size: 14px;">
                                <b>Your request for quote has been processed. Thank You
                                    <br />
                                    for your Submission</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td width="50%" style="text-align: center;">
                                            <%-- <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="DashboardButton" />--%>
                                            <input type="button" id="print" value="print" onclick="javascript:PrintPage();" class="DashboardButton" />
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:Button ID="btnClose" runat="server" Text="Close" CausesValidation="false" CssClass="DashboardButton" />
                                            <asp:Button ID="btnhide" runat="server" Text="Close" CausesValidation="false" CssClass="DashboardButton"
                                                Style="display: none;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="btnSearch" />
            </Triggers>
        </asp:UpdatePanel>
        </form>
    </center>
    <%--<iframe name="gToday:normal:agenda.js" id="gToday:normal:agenda.js"
src="includes/ipopeng.htm" scrolling="no" frameborder="0"
style="visibility:visible; z-index:999; position:absolute; top:-500px; left:-500px;">
<layer name="gToday:normal:agenda.js" src="npopeng.htm" background="npopeng.htm">     </LAYER>

</iframe> --%>

    <script type="text/javascript">
    
    function PrintPage()
    {
    $find("mpeConfirm").hide();
         window.print();
          $find("mpeConfirm").show();
    }
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
//    debugger;
//    var postBackElementID;
//   Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(InitializeRequestHandler);
//   function InitializeRequestHandler(sender, args)
//   {
//   postBackElementID = args.get_postBackElement().id.substring(args.get_postBackElement().id.lastIndexOf("_") + 1);
//   }
    $('form').live("submit", function () {
    debugger;
//    var id=document.getElementById('__EVENTTARGET').value;
//    alert(id);
    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
              for (var i = 0; i < window.Page_Validators.length; i++)
                {
                    window.ValidatorEnable(window.Page_Validators[i]);

                    //if condition to check whether the validation was successfull or not. 
                    if (!window.Page_Validators[i].isvalid)
                    {
                        var errMsg = window.Page_Validators[i].getAttribute('ErrorMessage');
                        alert(errMsg);
                        return false;
                    }
                }
                
            }
        ShowProgress();
        return true;
    });

    </script>

</body>
</html>
