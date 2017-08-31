<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreateQuote.aspx.vb" Inherits="CreateQuote"
    MaintainScrollPositionOnPostback="False" SmartNavigation="True" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
    <meta name="generator" content="Adobe GoLive" />
    <title>SIU - Commercial Garage Quote Sheet</title>
    <script type="text/javascript" src="./Js/html-form-input-mask.js"></script>
    <script type="text/javascript" src="./Js/prototype.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="JS/bk.js"></script>
    <script type="text/javascript">
        function linkRadioTextAndLabel(yesButton, noButton, text, label) {
            $(yesButton).click(function () {
                $(label).show();
                $(text).show();
            });
            $(noButton).click(function () {
                $(label).hide();
                $(text).hide();
            });
            $(text).hide();
            $(label).hide();
        };

        function toNameAge(name, age) {
            return {
                name: name,
                age: age
            };
        }

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

        function AllowAlphabet() {
            vKeycode = window.event.keyCode;
            if (!isAlphabet(vKeycode))
                window.event.keyCode = 0;

        }

        function getValue(name) {
            return document.getElementById(name).value;
        }

        function setValue(name, value) {
            document.getElementById(name).value = "";
            document.getElementById(name).value = value;
        }

        function isAlphabet(k) {
            return (((k >= 65) && (k <= 90)) || ((k >= 97) && (k <= 122)) || (k == 46) || (k == 32) || (k == 45));
        }

        function up(lstr) {
            var str = lstr.value;
            lstr.value = str.toUpperCase();
        }

        function addToArray(baseArray, name, age) {
            var newNA = toNameAge(name, age);
            return baseArray.push(newNA);
        }

        function saveOwnerSpouse() {
            var owner = toNameAge(getValue("inputOwnerName"), getValue("inputOwnerAge"));
            var spouse = toNameAge(getValue("inputSpouseName"), getValue("inputSpouseAge"));
            var array = [owner, spouse];
            setValue("txtMplOwnerSpouseNameAge", JSON.stringify(array));
        }

        function saveGroup(count, baseName) {
            var array = [];
            for (var index = 0; index < parseInt(count); index++) {
                if (getValue("input" + baseName + "Name" + (index + 1).toString())) {
                    var n = getValue("input" + baseName + "Name" + (index + 1).toString());
                    var a = getValue("input" + baseName + "Age" + (index + 1).toString())
                    addToArray(array, n, a);
                }
            }
            if (array.length > 0) {
                var control = "txtMpl" + baseName + "NameAge";
                setValue(control, JSON.stringify(array));
            }
        }

        function masterSave() {
            saveGroup(getValue("tbDriverCount"), "Driver");
            saveGroup(getValue("tbEmployeeCount"), "Employee");
            saveGroup(getValue("tbPersonFurnishedCount"), "PersonFurnished");
            saveOwnerSpouse();
        }

        function setChangedEvent(control) {
            $("#" + control).change(function () {
                masterSave();
            });
        }

        function addDriver() {
            var current = parseInt(document.getElementById("tbDriverCount").value);
            var next = current + 1;
            var last = $("#endRowDriver");
            var nextName = "inputDriverName" + next;
            var nextAge = "inputDriverAge" + next;
            var html = "<tr><td style=\"width: 500px\" align=\"left\">\n&nbsp;</td>\n<td style=\"width: 500px\" align=\"left\">" +
        "<input name=\"" + nextName + "\" id=\"" + nextName + "\" style=\"width:300px;\" type=\"text\"></td><td style=\"width: 360px\">" +
        "<input name=\"" + nextAge + "\" id=\"" + nextAge + "\" style=\"width:65px;\" type=\"text\"></tr>";
            $(html).insertBefore(last);

            var currentName = document.getElementById("inputDriverName3").value;
            var currentAge = document.getElementById("inputDriverAge3").value;
            document.getElementById(nextName).value = currentName;
            document.getElementById(nextAge).value = currentAge;
            document.getElementById("inputDriverAge3").value = "";
            document.getElementById("inputDriverName3").value = "";
            document.getElementById("tbDriverCount").value = next;

            setChangedEvent(nextName);
            setChangedEvent(nextAge);
        }

        function addEmployee() {
            var current = parseInt(document.getElementById("tbEmployeeCount").value);
            var next = current + 1;
            var last = $("#endRowEmployee");
            var nextName = "inputEmployeeName" + next;
            var nextAge = "inputEmployeeAge" + next;
            var html = "<tr><td style=\"width: 500px\" align=\"left\">\n&nbsp;</td>\n<td style=\"width: 500px\" align=\"left\">" +
        "<input name=\"" + nextName + "\" id=\"" + nextName + "\" style=\"width:300px;\" type=\"text\"></td><td style=\"width: 360px\">" +
        "<input name=\"" + nextAge + "\" id=\"" + nextAge + "\" style=\"width:65px;\" type=\"text\"></tr>";
            $(html).insertBefore(last);

            var currentName = document.getElementById("inputEmployeeName3").value;
            var currentAge = document.getElementById("inputEmployeeAge3").value;
            document.getElementById(nextName).value = currentName;
            document.getElementById(nextAge).value = currentAge;
            document.getElementById("inputEmployeeAge3").value = "";
            document.getElementById("inputEmployeeName3").value = "";
            document.getElementById("tbEmployeeCount").value = next;

            setChangedEvent(nextName);
            setChangedEvent(nextAge);
        }

        function addFurnishedPerson() {
            var current = parseInt(document.getElementById("tbPersonFurnishedCount").value);
            var next = current + 1;
            var last = $("#endRowPersonFurnished");
            var nextName = "inputPersonFurnishedName" + next;
            var nextAge = "inputPersonFurnishedAge" + next;
            var html = "<tr><td style=\"width: 500px\" align=\"left\">\n&nbsp;</td>\n<td style=\"width: 500px\" align=\"left\">" +
        "<input name=\"" + nextName + "\" id=\"" + nextName + "\" style=\"width:300px;\" type=\"text\"></td><td style=\"width: 360px\">" +
        "<input name=\"" + nextAge + "\" id=\"" + nextAge + "\" style=\"width:65px;\" type=\"text\"></tr>";
            $(html).insertBefore(last);

            var currentName = document.getElementById("inputPersonFurnishedName3").value;
            var currentAge = document.getElementById("inputPersonFurnishedAge3").value;
            document.getElementById(nextName).value = currentName;
            document.getElementById(nextAge).value = currentAge;
            document.getElementById("inputPersonFurnishedAge3").value = "";
            document.getElementById("inputPersonFurnishedName3").value = "";
            document.getElementById("tbPersonFurnishedCount").value = next;

            setChangedEvent(nextName);
            setChangedEvent(nextAge);
        }

        function hideControl(name) {
            $(name).hide();
        }

        function showControl(name) {
            $(show).show();
        }

        function setTb(tb, value) {
            if (value) {
                setValue(tb, value);
            }
        }

        function readOwnerSpouse() {
            var value = getValue("txtMplOwnerSpouseNameAge");
            if (value) {
                var json = JSON.parse(value);
                setTb("inputOwnerName", json[0].name);
                setTb("inputOwnerAge", json[0].age);
                setTb("inputSpouseName", json[1].name);
                setTb("inputSpouseAge", json[1].age);
            }
        }


        function readGroup(count, baseName) {
            var value = getValue("txtMpl" + baseName + "NameAge");
            var max = 0;
            if (value) {
                var arr = JSON.parse(value);
                if (count > arr.length) {
                    max = count
                } else {
                    max = arr.length
                }
                if (arr.length > 0) {
                    for (var index = 0; index < max; index++) {
                        var element = arr[index];
                        var tbName = "input" + baseName + "Name" + (index + 1).toString();
                        var tbAge = "input" + baseName + "Age" + (index + 1).toString();
                        setValue(tbName, element.name);
                        setValue(tbAge, element.age);
                    }
                }
            }


        }



        function masterRead() {
            readOwnerSpouse();
            readGroup(getValue("tbDriverCount"), "Driver");
            readGroup(getValue("tbEmployeeCount"), "Employee");
            readGroup(getValue("tbPersonFurnishedCount"), "PersonFurnished");
        }

        function setSingleEvent(name) {
            var nameControl = "input" + name + "Name";
            var ageControl = "input" + name + "Age";
            setChangedEvent(nameControl);
            setChangedEvent(ageControl);
        }

        function setGroupEvent(name, i) {
            var nameControl = "input" + name + "Name" + i.toString();
            var ageControl = "input" + name + "Age" + i.toString();
            setChangedEvent(nameControl);
            setChangedEvent(ageControl);
        }
        var counts = ["tbPersonFurnishedCount", "tbDriverCount", "tbEmployeeCount", "cbUseOldFormat"];
        var oldNameAges = ["lblOwnerSpouse", "lblDriver", "lblEmployee", "lblPersonsFurnished", "txtMplDriverNameAge",
    "txtMplOwnerSpouseNameAge", "txtMplEmployeeNameAge", "txtMplPersonFurnishedNameAge"
];
        var newNamesAges = ["lblName", "lblAge", "lblOwner", "lblSpouse", "lblDrivers", "lblPersonsFurnished", "lblEmployee",
    "btnInputAddAdditionalDriver", "btnInputAddAdditionalEmployee", "btnInputAddAdditionalPersonFurnished", "inputOwnerName",
    "inputOwnerAge", "inputSpouseName", "inputSpouseAge", "inputDriverName1", "inputDriverAge1", "inputDriverName2", "inputDriverAge2",
    "inputDriverName3", "inputDriverAge3", "inputEmployeeName1", "inputEmployeeAge1", "inputEmployeeName2", "inputEmployeeAge2",
    "inputEmployeeName3", "inputEmployeeAge3", "inputPersonFurnishedName1", "inputPersonFurnishedAge1", "inputPersonFurnishedName2", "inputPersonFurnishedAge2",
    "inputPersonFurnishedName3", "inputPersonFurnishedAge3"
]

        function hideControls(array) {
            for (var i = 0; i < array.length; i++) {
                $("#" + array[i]).hide();
            }
        }
        $(document).ready(function () {
            linkRadioTextAndLabel(
        "#<%= rdoGarageOperationOtherLocationYes.ClientID %>",
        "#<%= rdoGarageOperationOtherLocationNo.ClientID %>",
        "#<%= txtMplOtherLocations.ClientID %>",
        "#<%= lblGarageOperationOtherLocationCrumb.ClientID %>");
            $("#rdOwnRollbackYes").click(function () {
                $("#tbRollBack").Text = "True";
            });
            $("#tbRollBack").Text = "False";
            $("#btnInputAddAdditionalDriver").click(addDriver);
            $("#btnInputAddAdditionalEmployee").click(addEmployee);
            $("#btnInputAddAdditionalPersonFurnished").click(addFurnishedPerson);
            masterRead();
            setSingleEvent("Owner");
            setSingleEvent("Spouse");
            for (var i = 0; i < getValue("tbDriverCount"); i++) {
                setGroupEvent("Driver", i + 1);
            }
            for (var i = 0; i < getValue("tbEmployeeCount"); i++) {
                setGroupEvent("Employee", i + 1);
            }
            for (var i = 0; i < getValue("tbPersonFurnishedCount"); i++) {
                bk.js
                setGroupEvent("FurnishedPerson", i + 1);
            }
            hideControls(counts);
            try {
                var json = getValue("txtMplOwnerSpouseNameAge");
                if (json != "" && JSON.parse(json)) {
                    hideControls(oldNameAges);
                } else {
                    hideControls(newNamesAges);
                }
            } catch (e) {
                hideControls(oldNameAges);
            }
        });   
    </script>
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
        .DashboardButton
        {
            border-radius: 3px;
            height: 30px;
            width: 110px;
            text-align: center;
            font-size: 15px;
            font-weight: bold;
            background-color: Transparent;
        }
        .validator
        {
            font-family: "Segoe UI Semibold";
            font-size: small;
            font-weight: bold;
            font-style: normal;
            font-variant: normal;
            text-transform: capitalize;
            color: #FF0000;
            width: 250px;
        }
        #Button1
        {
        }
        .style1
        {
            width: 505px;
        }
        .style2
        {
            width: 408px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Select2_onclick() {

        }

        // ]]>
    </script>
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
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <cc1:ModalPopupExtender ID="mpeConfirm" BackgroundCssClass="modal" runat="server"
            TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnhide"
            DropShadow="true">
        </cc1:ModalPopupExtender>
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
                        <b>GarageQuoteSheet Submitted in Database. Thank You
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
        <div align="center">
            <table width="900" border="0" cellspacing="0" cellpadding="0" background="images/headerback.jpg"
                height="150">
                <tr>
                    <td align="left" valign="top">
                        <h1>
                            Commercial Garage Quote Sheet</h1>
                        <asp:Button ID="Button1" runat="server" Text="||" Click="button1_click" 
                            Width="20px" />                            
                    </td>
                </tr>
            </table>
            <table width="850" border="0" cellspacing="0" cellpadding="0">
                <tr height="30">
                    <td width="1050" background="images/navback.jpg" style="height: 30px; text-align: center;
                        padding-right: 67px;">
                        <a href="http://www.siuins.com/SIURATE/pages/homepage.aspx" class="DashboardButton"
                            style="padding-left: 29px; color: blue; text-decoration: underline;"><b style="font-size: medium;">
                                SiuRate</b></a>
                        <div align="center">
                            <ul id="nav">
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <table border="0" cellspacing="0" cellpadding="0" style="background-color: White">
            <tr>
                <td colspan="2" align="left">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Transparent"
                        BorderColor="Gray" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 19px">
                    <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSearch" runat="server" Text="Search Quotes" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 800px;">
                    <div style="text-align: center">
                        <fieldset>
                            <legend><strong>Agency Information </strong></legend>
                            <table style="width: 680px;" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                <tr>
                                    <td align="Left" style="height: 23px; width: 310px;">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> <strong>Agency #:</strong>
                                    </td>
                                    <td align="Left" style="height: 23px">
                                        <asp:Label ID="lblAgency" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 310px; height: 22px">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Name:</strong>
                                    </td>
                                    <td align="Left" style="height: 22px">
                                        <asp:Label ID="lblAgencyName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trAgentStatus" runat="server">
                                    <td align="Left" style="width: 310px; height: 22px">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span><strong> Agency Status:</strong>
                                    </td>
                                    <td align="Left" style="height: 22px">
                                        <asp:Label ID="lblAgentStatus" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 310px; height: 24px">
                                        <span style="color: #ff0000">*</span> Contact:
                                    </td>
                                    <td align="Left" style="height: 24px">
                                        <asp:TextBox ID="txtContact" runat="server" MaxLength="100" Width="244px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 310px">
                                        <span style="color: #ff0000">*</span> Phone
                                    </td>
                                    <td align="Left">
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" class="text input_mask mask_phone"
                                            Width="244px" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                runat="server" ControlToValidate="txtPhone" ErrorMessage="Invalid Phone Number"
                                                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone No. can not be blank">*</asp:RequiredFieldValidator>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPhone"
                                            Mask="999-999-9999" ClearMaskOnLostFocus="false">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                            ControlToValidate="txtPhone"></cc1:MaskedEditValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 310px">
                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> How do you want your quote replied
                                        ?
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlReplyOptions" runat="server" Width="74px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlReplyOptions_SelectedIndexChanged">
                                                    <asp:ListItem>Email</asp:ListItem>
                                                    <asp:ListItem>Fax</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="ddlReplyOptions" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 310px">
                                        &nbsp;&nbsp; Email/Fax:
                                    </td>
                                    <td align="Left">
                                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="text" MaxLength="12" class="text input_mask mask_phone"
                                            Width="244px"></asp:TextBox><asp:TextBox ID="txtemail" runat="server" CssClass="text"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regxvEmailOption" runat="server" ControlToValidate="txtemail"
                                            ErrorMessage="Invalid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="regxvFaxOption" runat="server" ControlToValidate="txtFaxNo"
                                            ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                                            Width="1px">*</asp:RegularExpressionValidator>
                                        <cc1:MaskedEditExtender ID="meextxtphone" runat="server" TargetControlID="txtFaxNo"
                                            Mask="999-999-9999" ClearMaskOnLostFocus="false">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator ID="mevtxtphone" runat="server" ControlExtender="meextxtphone"
                                            ControlToValidate="txtFaxNo"></cc1:MaskedEditValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 300px; height: 22px">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblUnderwriter" runat="server" Text="Underwriter Name" Visible="false"></asp:Label>
                                    </td>
                                    <td align="Left">
                                        <asp:TextBox ID="txtUnderwriteName" runat="server" Visible="false" CssClass="text"
                                            MaxLength="150" class="text input_mask mask_phone" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" style="width: 300px; height: 22px">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblUnderwriteremail" runat="server" Text="Underwriter Email" Visible="false"></asp:Label>
                                    </td>
                                    <td align="Left">
                                        <asp:TextBox ID="txtuwemail" runat="server" Visible="false" CssClass="text" MaxLength="150"
                                            class="text input_mask mask_phone" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset id="fldParentQuote" runat="server">
                            <legend>Parent Quote Number</legend>
                            <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblParentQuoteNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset>
                            <table style="width: 680px;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <asp:Panel ID="pnlSearch" runat="server">
                                        <td colspan="2" align="center">
                                            <div style="text-align: center">
                                                <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:GridView ID="gvQuote" runat="server" AutoGenerateColumns="false" HeaderStyle-BorderStyle="Solid"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" AllowSorting="true" BorderColor="black"
                                                                BorderWidth="1" HeaderStyle-BackColor="blue" HeaderStyle-ForeColor="white">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Quote Number" HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1"
                                                                        ItemStyle-BorderColor="black" ItemStyle-BorderWidth="1">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkQuote" ForeColor="blue" runat="server" CommandName="FillDetails"
                                                                                CausesValidation="false" CommandArgument='<%#databinder.Eval(Container.DataItem,"GarageQuoteId") %>'><%#databinder.Eval(Container.DataItem,"GarageQuoteNumber") %></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField Visible="false" HeaderText="Quote Number" DataField="GarageQuoteNumber"
                                                                        SortExpression="ORDER by garagequotenumber"></asp:BoundField>
                                                                    <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black"
                                                                        ItemStyle-BorderWidth="1" HeaderText="Applicant Name" DataField="ApplicantName"
                                                                        SortExpression="ApplicantName"></asp:BoundField>
                                                                    <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black"
                                                                        ItemStyle-BorderWidth="1" HeaderText="Trade Name" DataField="TradeName" SortExpression="TradeName">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black"
                                                                        ItemStyle-BorderWidth="1" HeaderText="Date Created" DataField="CreatedDate" SortExpression="CreatedDate">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderStyle-BorderColor="black" HeaderStyle-BorderWidth="1" ItemStyle-BorderColor="black"
                                                                        ItemStyle-BorderWidth="1" HeaderText="Contact" DataField="Contact" SortExpression="Contact" />
                                                                    <asp:BoundField Visible="false" HeaderText="Quote ID" DataField="GarageQuoteId">
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <p>
                                                    <p align="left">
                                                        <b></b>
                                                    </p>
                                            </div>
                                        </td>
                                    </asp:Panel>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset>
                            <legend><strong>Operations</strong></legend>
                            <table style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                                class="fieldset">
                                <tr>
                                    <td style="height: 14px;" align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> Applicant Name
                                    </td>
                                    <td style="width: 100px; height: 14px;" align="Left">
                                        <asp:TextBox ID="txtApplicantName" runat="server" onkeyup="up(this)" MaxLength="50"
                                            Width="244px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvApplicantName" runat="server" ControlToValidate="txtApplicantName"
                                            ErrorMessage="This field is required." Width="250 px" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 14px;" align="Left" colspan="2">
                                        <span style="color: #ff0000"></span>&nbsp;&nbsp;Trade Name
                                    </td>
                                    <td style="width: 100px; height: 14px; text-align: left;">
                                        <asp:TextBox ID="txtTradeName" runat="server" onkeyup="up(this)" MaxLength="50" Width="244px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> Garaging Address:
                                    </td>
                                    <td style="width: 100px" align="Left">
                                        <asp:TextBox ID="txtgaragingadd" runat="server" MaxLength="50" Width="244px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvGaragingAddress" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtgaragingadd" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> City:
                                    </td>
                                    <td style="width: 100px" align="Left">
                                        <asp:TextBox ID="txtcity" runat="server" MaxLength="50" Width="244px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                            ErrorMessage="This field is required." Width="250 px" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> County:
                                    </td>
                                    <td style="width: 100px" align="Left">
                                        <asp:TextBox ID="txtCounty" runat="server" MaxLength="50" Width="244px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvCounty" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtCounty" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> State
                                    </td>
                                    <td align="Left">
                                        <asp:TextBox ID="txtState" runat="server" MaxLength="2" Width="20px" AutoPostBack="true" /><asp:Label
                                            ID="lblstateMsg" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtState" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="regexState" runat="server" Width="250 px" ErrorMessage="Please enter a valid 2 letter state abbreviation."
                                            ControlToValidate="txtState" CssClass="validator" ValidationExpression="[A-Z][A-Z]"
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" align="Left" colspan="2">
                                        <span style="color: #ff0000">*</span> ZIP Code
                                    </td>
                                    <td style="width: 100px; height: 10px;" align="Left">
                                        <asp:TextBox ID="txtZIP" runat="server" MaxLength="5" Width="75px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="This Field is Required."
                                            Width="250 px" ControlToValidate="txtZIP" CssClass="validator"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="regexZipCode" runat="server" ErrorMessage="Please enter a valid zip code in either 5 digit (#####) or 9 digit (#####-####) format."
                                            ControlToValidate="txtZIP" CssClass="validator" Width="250 px" ValidationExpression="[0-9]{5}([-][0-9]{4})?"
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table width="100%">
                                            <tr>
                                                <td align="left" style="width: 46%">
                                                    <span style="color: #ff0000">*</span> Type of Business
                                                </td>
                                                <td width="54%">
                                                    <table style="border: solid 2px #999999" width="100%">
                                                        <tr>
                                                            <td align="right">
                                                                Individual
                                                            </td>
                                                            <td align="center">
                                                                <asp:RadioButton ID="rdoIndivudual" runat="server" GroupName="BusinessType" />
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
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 49px" align="left" colspan="2">
                                        <span style="color: #ff0000">*</span> Years in Business
                                    </td>
                                    <td style="width: 360px; height: 49px" align="left">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlYearsInBusiness" AutoPostBack="true" OnSelectedIndexChanged="ddlYearsInBusiness_SelectedIndexChanged"
                                                    Width="122px">
                                                    <asp:ListItem Value="-1">Please Select...</asp:ListItem>
                                                    <asp:ListItem Value="0">New Venture</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - 3 Years</asp:ListItem>
                                                    <asp:ListItem Value="2">4 - 5 Years</asp:ListItem>
                                                    <asp:ListItem Value="3">6+ Years</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:RangeValidator ID="rvYearsInBusiness" runat="server" ErrorMessage="Please enter a valid value."
                                                    ControlToValidate="ddlYearsInBusiness" MinimumValue="0" MaximumValue="3" CssClass="validator"
                                                    Display="Dynamic"></asp:RangeValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="ddlYearsInBusiness" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr id="trYrsExp" runat="server" visible="false">
                                    <td style="height: 27px" align="left" colspan="2">
                                        <span style="color: #ff0000">*</span> Years of experience
                                    </td>
                                    <td style="width: 360px; height: 27px" align="left">
                                        <asp:TextBox ID="txtYrExp" runat="server" Width="27px"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvYrExp" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtYrExp" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="tryearinsured" runat="server">
                                    <td style="height: 27px" align="left" colspan="2">
                                        <span style="color: #ff0000">*</span> Years Insured:
                                    </td>
                                    <td style="width: 360px; height: 27px" align="left">
                                        <asp:TextBox ID="txtyrsinsured" runat="server" Width="27px"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvYearsInsured" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtyrsinsured" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 27px" align="left" colspan="2">
                                        <span style="color: #ff0000">*</span> Operations of Insured:
                                    </td>
                                    <td style="width: 360px; height: 27px" align="left">
                                        <asp:TextBox ID="txtMplOperations" runat="server" Height="61px" TextMode="MultiLine"
                                            Width="354px"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvMplOperations" runat="server" ErrorMessage="This field is required."
                                            Width="250 px" ControlToValidate="txtMplOperations" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 27px" align="left" colspan="2">
                                        &nbsp; Retail Dealership&nbsp;
                                    </td>
                                    <td style="width: 360px; height: 27px" align="left">
                                        <asp:CheckBox ID="cbRetailDealership" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 27px" align="left" colspan="2">
                                        &nbsp; Wholesale Dealership&nbsp;
                                    </td>
                                    <td style="width: 360px; height: 27px" align="left">
                                        <asp:CheckBox ID="cbWholesaleDealership" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" width="100%">
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
                                                <td style="width: 211px; height: 38px;" align="left">
                                                    <span style="color: #ff0000">*</span>Sell Auto Parts New or Used:
                                                    <br />
                                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                                    <br />
                                                    <asp:CustomValidator ID="customAutoParts" runat="server" ControlToValidate="txtSellPercentage"
                                                        ErrorMessage="Select either yes or no." ClientValidationFunction="Custom_rdoAutoParts"
                                                        CssClass="validator" Display="Dynamic"></asp:CustomValidator>
                                                </td>
                                                <td align="center" style="width: 73px; height: 38px;">
                                                    <asp:RadioButton ID="rdAutoPartsYes" GroupName="AutoParts" runat="server" />
                                                </td>
                                                <td align="center" style="width: 74px; height: 38px;">
                                                    <asp:RadioButton ID="rdAutoPartsNo" GroupName="AutoParts" runat="server" />
                                                </td>
                                                <td align="left" style="height: 38px">
                                                    <asp:TextBox ID="txtSellPercentage" runat="server" MaxLength="4" Width="45px"></asp:TextBox>Annual
                                                    Receipts<span>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSellPercentage"
                                                            ErrorMessage="Percentage can be betwen 0 to 100 only" MaximumValue="100" MinimumValue="0"
                                                            Type="Integer">*</asp:RangeValidator></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px" align="left">
                                                    <span style="color: #ff0000">*</span>Operate a Salvage Yard:
                                                    <br />
                                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Select either yes or no."
                                                        CssClass="validator" ControlToValidate="txtSellPercentage" ClientValidationFunction="Custom_rdoOperateSalvage"
                                                        Display="Dynamic"></asp:CustomValidator>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px">
                                                    <asp:RadioButton ID="rdoOperateSalvageYardYes" GroupName="OperateSalvageYard" runat="server" />
                                                </td>
                                                <td align="center" style="width: 74px">
                                                    <asp:RadioButton ID="rdoOperateSalvageYardNo" GroupName="OperateSalvageYard" runat="server" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px" align="left">
                                                    <span style="color: #ff0000">*</span>Any Garage Operations at other<br />
                                                    &nbsp; Locations:
                                                    <br />
                                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                                    <br />
                                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Select Either Yes or No."
                                                        CssClass="validator" ControlToValidate="txtSellPercentage" ClientValidationFunction="Custom_rdoGarageOperation"
                                                        Display="Dynamic"></asp:CustomValidator>
                                                    <br />
                                                    <asp:Label ID="lblGarageOperationOtherLocationCrumb" runat="server" Text="Please explain."
                                                        CssClass="crumb"></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px">
                                                    <asp:RadioButton ID="rdoGarageOperationOtherLocationYes" runat="server" GroupName="GarageOperationOtherLocation"
                                                        Style="width: 18px" />
                                                </td>
                                                <td align="center" style="width: 74px">
                                                    <asp:RadioButton ID="rdoGarageOperationOtherLocationNo" runat="server" GroupName="GarageOperationOtherLocation"
                                                        Style="width: 18px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMplOtherLocations" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px" align="left">
                                                    <span style="color: #ff0000">*</span>Any Other Business Operations<br />
                                                    &nbsp; on same premises Owned by Insured:<br />
                                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)<br />
                                                    </span>&nbsp;<asp:CustomValidator ID="customOtherBusiness" runat="server" ErrorMessage="Select Either Yes or No."
                                                        CssClass="validator" ControlToValidate="txtMplOtherBusiness" ClientValidationFunction="Custom_rdoOtherBusiness"
                                                        Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px">
                                                    <asp:RadioButton ID="rdOtherBusinessOperationYes" runat="server" GroupName="OtherBusinessOperation"
                                                        Style="width: 18px" />
                                                </td>
                                                <td align="center" style="width: 74px">
                                                    <asp:RadioButton ID="rdOtherBusinessOperationNo" runat="server" GroupName="OtherBusinessOperation"
                                                        Style="width: 18px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMplOtherBusiness" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px" align="left">
                                                    <span style="color: #ff0000">*</span>Do you own a Wrecker:<br />
                                                    <asp:CustomValidator ID="customHasWrecker" runat="server" ClientValidationFunction="Custom_rdoHasWrecker"
                                                        ControlToValidate="txtMplOtherBusiness" CssClass="validator" ErrorMessage="Select Either Yes Or No"
                                                        Display="Dynamic"></asp:CustomValidator>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px">
                                                    <asp:RadioButton ID="rdOwnWreckerYes" runat="server" GroupName="OwnWrecker" Style="width: 18px" />
                                                </td>
                                                <td align="center" style="width: 74px">
                                                    <asp:RadioButton ID="rdOwnWreckerNo" runat="server" GroupName="OwnWrecker" Style="width: 18px" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px" align="left">
                                                    <span style="color: #ff0000">*<span style="color: #000000"> Do you own a </span><span
                                                        style="color: #000000">Rollback:</span></span>
                                                    <br />
                                                    <asp:TextBox Visible="false" ID="tbRollBack" runat="server"></asp:TextBox>
                                                    <asp:CustomValidator ID="customHasRollBack" runat="server" ControlToValidate="tbRollBack"
                                                        CssClass="validator" ErrorMessage="Select Either Yes or No" ClientValidationFunction="Custom_rdoHasRollback"
                                                        ValidateEmptyText="True" Display="Dynamic"></asp:CustomValidator>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px">
                                                    <asp:RadioButton ID="rdOwnRollbackYes" runat="server" GroupName="OwnRollback" Style="width: 18px"
                                                        size="" />
                                                </td>
                                                <td align="center" style="width: 74px">
                                                    <asp:RadioButton ID="rdOwnRollbackNo" runat="server" GroupName="OwnRollback" Style="width: 18px" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px; height: 40px;" align="left">
                                                    <span style="color: #ff0000">*<span style="color: #000000">Do you own or use Tow Bar<br />
                                                        &nbsp; or Tow Dollie or Trailer:</span></span><br />
                                                    &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                                    <br />
                                                    <asp:Label ID="lblOwnTowBarCrumb" runat="server" CssClass="crumb" Text="Please explain"></asp:Label>
                                                    <br />
                                                    <asp:CustomValidator ID="customOwnTowBar" runat="server" ClientValidationFunction="Custom_rdoOwnTowBar"
                                                        ControlToValidate="txtMplDollie" CssClass="validator" ErrorMessage="Select Either Yes or No"
                                                        ValidateEmptyText="True" Display="Dynamic"></asp:CustomValidator>
                                                    <br />
                                                </td>
                                                <td align="center" style="width: 73px; height: 40px;">
                                                    <asp:RadioButton ID="rdTowBarDollieTrailerYes" runat="server" GroupName="TowBarDollieTrailer"
                                                        Style="width: 18px" />
                                                </td>
                                                <td align="center" style="width: 74px; height: 40px;">
                                                    <asp:RadioButton ID="rdTowBarDollieTrailerNo" runat="server" GroupName="TowBarDollieTrailer"
                                                        Style="width: 18px" />
                                                </td>
                                                <td style="height: 40px">
                                                    <asp:TextBox ID="txtMplDollie" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                    </td>
                                    <td align="left" style="width: 360px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:CheckBox ID="cbUseOldFormat" runat="server" />
                                    </td>
                                    <td align="left" style="width: 360px">
                                        <asp:TextBox ID="tbDriverCount" runat="server">3</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="left" style="width: 360px">
                                        <asp:TextBox ID="tbEmployeeCount" runat="server">3</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="left" style="width: 360px">
                                        <asp:TextBox ID="tbPersonFurnishedCount" runat="server">3</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 20px" align="center">
                                        <strong display="none"><span style="color: #ff0000">*</span> Owners / Spouses / Driver
                                            / Employees / Person furnished Autos</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblOwnerSpouse" runat="server" Text="Owner Spouse Name/Age:"></asp:Label>
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplOwnerSpouseNameAge" Height="60px"
                                            Width="360px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblDriver" runat="server" Text="Drivers Name/Age:"></asp:Label>
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplDriverNameAge" Height="60px"
                                            Width="360px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblEmployee" runat="server" Text="Employees Name/Age:"></asp:Label>
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplEmployeeNameAge" Height="60px"
                                            Width="360px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblFurnishedPerson" runat="server" Text="Furnished Person Name/Age"></asp:Label>
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplPersonFurnishedNameAge"
                                            Height="60px" Width="360px" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:Label runat="server" id="lblName" Text="Name" />
                                    </td>
                                    <td style="width: 160px">
                                        <asp:Label runat="server" id="lblAge" Text="Age" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        <asp:Label runat="server" id="lblOwner" Text="Owner" />
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputOwnerName" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputOwnerAge" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        <asp:Label runat="server" id="lblSpouse" Text="Spouse" />
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputSpouseName" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputSpouseAge" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        <asp:Label runat="server" id="lblDrivers" Text="Driver" />
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputDriverName1" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputDriverAge1" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputDriverName2" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputDriverAge2" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="endRowDriver">
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputDriverName3" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputDriverAge3" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td style="width: 660px" colspan="2" align="left">
                                        <input id="btnInputAddAdditionalDriver" type="button" value="Add Additional Driver" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        <asp:Label runat="server" id="lblEmployees" Text="Employees" />
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputEmployeeName1" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputEmployeeAge1" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputEmployeeName2" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputEmployeeAge2" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="endRowEmployee">
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputEmployeeName3" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputEmployeeAge3" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td style="width: 660px" colspan="2" align="left">
                                        <input id="btnInputAddAdditionalEmployee" type="button" value="Add Additional Employee" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        <asp:Label runat="server" id="lblPersonsFurnished" Text="Persons Furnished" />
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputPersonFurnishedName1" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputPersonFurnishedAge1" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputPersonFurnishedName2" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputPersonFurnishedAge2" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="endRowPersonFurnished">
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left" class="style1">
                                        <asp:TextBox ID="inputPersonFurnishedName3" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px">
                                        <asp:TextBox ID="inputPersonFurnishedAge3" runat="server" Width="65px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style2">
                                        &nbsp;
                                    </td>
                                    <td style="width: 660px" colspan="2" align="left">
                                        <input id="btnInputAddAdditionalPersonFurnished" type="button" value="Add Additional Person Furnished" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table>
                                            <tr>
                                                <td style="width: 333px" align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="width: 127px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 109px" align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="width: 100px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 333px" align="left">
                                                    <span style="color: #ff0000">*</span> Any children in household:
                                                    <br />
                                                </td>
                                                <td align="left" style="width: 127px">
                                                    Yes<asp:RadioButton ID="rdAnyChildreninHouseYes" runat="server" GroupName="AnyChildreninHouse"
                                                        Style="width: 78px" />
                                                </td>
                                                <td style="width: 109px" align="left">
                                                    No<asp:RadioButton ID="rdAnyChildreninHouseNo" runat="server" GroupName="AnyChildreninHouse"
                                                        Style="width: 78px" />
                                                </td>
                                                <td align="left" style="width: 100px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        &nbsp;If Yes, need all ages:
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" ID="txtMplChildrenAges" Height="60px" Width="360px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <strong>Comments:</strong>
                                    </td>
                                    <td style="width: 360px">
                                        <asp:TextBox runat="server" TextMode="multiline" ID="txtMplComments" Height="60px"
                                            Width="360px" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <asp:Panel ID="pnlInsuranceHistory" runat="server">
                            <fieldset>
                                <legend><strong>Insurance History</strong></legend>
                                <table style="width: 680px; height: 240px" border="0" cellpadding="0" cellspacing="0"
                                    class="fieldset">
                                    <tr>
                                        <td colspan="6" style="height: 188px" width="100%">
                                            <table>
                                                <tr>
                                                    <td style="width: 284px" align="left">
                                                    </td>
                                                    <td align="center" width="50">
                                                        Yes
                                                    </td>
                                                    <td align="center" width="50">
                                                        No
                                                    </td>
                                                    <td style="width: 360px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 284px; height: 40px;" align="left">
                                                        <span style="color: #ff0000">*</span>Previous Policy Cancelled:
                                                        <br />
                                                        &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                                        <br />
                                                    </td>
                                                    <td align="center" style="width: 78px; height: 40px;">
                                                        <asp:RadioButton runat="server" ID="rdoPrePolicyCnYes" GroupName="PrePolicyCn" Style="width: 18px"
                                                            Width="45px" />
                                                    </td>
                                                    <td align="center" style="height: 40px;">
                                                        <asp:RadioButton runat="server" ID="rdoPrePolicyCnNo" GroupName="PrePolicyCn" Style="width: 18px"
                                                            Width="45px" />
                                                    </td>
                                                    <td style="width: 199px; height: 40px">
                                                        <asp:TextBox ID="txtMplPolicyCancelledDetails" runat="server" TextMode="MultiLine"
                                                            Height="60px" Width="360px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 284px; height: 44px;" align="left">
                                                        <span style="color: #ff0000">*</span>Previous Policy Not-Renewed:
                                                        <br />
                                                        &nbsp;&nbsp;<span style="color: #ff0000; font-size: small">(If Yes, Please explain)</span>
                                                        <br />
                                                    </td>
                                                    <td align="center" style="width: 78px; height: 44px;">
                                                        <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedYes" GroupName="PrePolicyNonRenewed"
                                                            Style="width: 18px" Width="45px" />
                                                    </td>
                                                    <td align="center" style="height: 44px;">
                                                        <asp:RadioButton runat="server" ID="rdoPrePolicyNonRenewedNo" GroupName="PrePolicyNonRenewed"
                                                            Style="width: 18px" Width="45px" />
                                                    </td>
                                                    <td style="width: 199px; height: 44px">
                                                        <asp:TextBox ID="txtMplPolicyNotRenewalDetail" runat="server" TextMode="MultiLine"
                                                            Height="60px" Width="360px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                        </td>
                                        <td style="width: 108px">
                                        </td>
                                        <td style="width: 104px;" align="right">
                                            <strong>&nbsp; &nbsp; Loss History</strong>
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                        <td style="width: 100px;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px; height: 15px;">
                                            Term From (mm/dd/yyyy)
                                        </td>
                                        <td style="width: 108px; height: 15px;">
                                            Term To(mm/dd/yyyy)
                                        </td>
                                        <td style="width: 104px; height: 15px;">
                                            Carrier
                                        </td>
                                        <td style="width: 100px; height: 15px;">
                                            Loss<br />
                                            Amount Paid
                                        </td>
                                        <td style="width: 100px; height: 15px;">
                                            Premium
                                        </td>
                                        <td style="width: 100px; height: 15px;">
                                            Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px" valign="top">
                                            <asp:TextBox ID="txtTermFrom1" runat="server" Width="70px" MaxLength="10" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermFrom1" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                                ControlToValidate="txtTermFrom1" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>
                                        </td>
                                        <td style="width: 108px" valign="top">
                                            <asp:TextBox ID="txtTermto1" runat="server" Width="70px" MaxLength="10" />&nbsp;<asp:Label
                                                ID="lbltoone" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermto1" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                ControlToValidate="txtTermto1" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>
                                        </td>
                                        <td style="width: 104px" valign="top">
                                            <asp:TextBox ID="txtCarrier1" runat="server" Width="150px" MaxLength="25" />
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtAmtpaid1" runat="server" Width="64px" MaxLength="9" />
                                            <asp:RegularExpressionValidator ID="rfvAmountPaid1" runat="server" ControlToValidate="txtAmtpaid1"
                                                ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="tbPremium1" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtMplDetails1" runat="server" TextMode="MultiLine" Width="180px"
                                                Height="61px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px" valign="top">
                                            <asp:TextBox ID="txtTermFrom2" runat="server" Width="70px" MaxLength="10" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermFrom2" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="MaskedEditExtender4"
                                                ControlToValidate="txtTermFrom2" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>&nbsp;
                                        </td>
                                        <td style="width: 108px" valign="top">
                                            <asp:TextBox ID="txtTermto2" runat="server" Width="70px" MaxLength="10" />&nbsp;&nbsp;<asp:Label
                                                ID="lbltotwo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermto2" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server" ControlExtender="MaskedEditExtender5"
                                                ControlToValidate="txtTermto2" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>
                                        </td>
                                        <td style="width: 104px" valign="top">
                                            <asp:TextBox ID="txtCarrier2" runat="server" Width="150px" MaxLength="25" />
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtAmtpaid2" runat="server" Width="64px" MaxLength="9" />
                                            <asp:RegularExpressionValidator ID="rfvAmountPaid2" runat="server" ControlToValidate="txtAmtpaid2"
                                                ErrorMessage="Invalid Amount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="tbPremium2" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtMplDetails2" runat="server" TextMode="MultiLine" Width="180px"
                                                Height="60px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px" valign="top">
                                            <asp:TextBox ID="txtTermFrom3" runat="server" Width="70px" MaxLength="10" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermFrom3" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlExtender="MaskedEditExtender6"
                                                ControlToValidate="txtTermFrom3" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>&nbsp;
                                        </td>
                                        <td style="width: 108px" valign="top">
                                            <asp:TextBox ID="txtTermto3" runat="server" Width="70px" MaxLength="10" />&nbsp;<asp:Label
                                                ID="lbltothree" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtTermto3" PromptCharacter="_">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditValidator ID="MaskedEditValidator7" runat="server" ControlExtender="MaskedEditExtender7"
                                                ControlToValidate="txtTermto3" InvalidValueMessage="Date is invalid"></cc1:MaskedEditValidator>
                                        </td>
                                        <td style="width: 104px" valign="top">
                                            <asp:TextBox ID="txtCarrier3" runat="server" Width="150px" MaxLength="25" />
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtAmtpaid3" runat="server" Width="64px" MaxLength="9" />
                                            <asp:RegularExpressionValidator ID="rfvAmountPaid3" runat="server" ControlToValidate="txtAmtpaid3"
                                                ErrorMessage="InvalidAmount" ValidationExpression="\d+(\.\d+)?$">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="tbPremium3" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px" valign="top">
                                            <asp:TextBox ID="txtMplDetails3" runat="server" TextMode="MultiLine" Width="180px"
                                                Height="60px" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                        <fieldset>
                            <legend><strong>Coverage Details</strong></legend>
                            <table style="width: 680px; height: 219px" border="0" cellpadding="0" cellspacing="0"
                                class="fieldset">
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        &nbsp;Garage Limits of Liability:
                                    </td>
                                    <td style="width: 141px;" align="left">
                                        <asp:DropDownList runat="server" ID="ddlGarageLimit" Style="width: 200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 22px;"
                                        align="left">
                                        &nbsp;Med Pay Limits:
                                    </td>
                                    <td style="width: 141px; height: 22px;" align="left">
                                        <asp:DropDownList runat="server" ID="ddlMedPay" Style="width: 200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        &nbsp;Radius of Operation:
                                    </td>
                                    <td style="width: 141px" align="left">
                                        <asp:DropDownList runat="server" ID="ddlRadius" Style="height: 23px; width: 200px;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trVehicleCoverage" runat="server">
                                    <td colspan="2" align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                        <strong>Garage Vehicle Coverage - </strong>If # of Dealer Plates is more than zero,
                                        you may select UM / PIP
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; width: 30% !important; padding-top: 10px; padding-bottom: 10px;"
                                        align="left">
                                        <span style="text-decoration: underline">&nbsp;# of Dealer Plates:</span>
                                    </td>
                                    <td style="width: 141px" align="left">
                                        <asp:DropDownList runat="server" ID="ddlDealerPlates" Style="width: 200px" AutoPostBack="True"
                                            CausesValidation="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 20px;"
                                        align="left">
                                        &nbsp;Uninsured Motorist:
                                    </td>
                                    <td style="width: 141px; height: 20px;" align="left">
                                        <asp:DropDownList runat="server" ID="ddlReject" Style="width: 200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="Trpip" runat="server">
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 20px;"
                                        align="left">
                                        &nbsp;PIP:
                                    </td>
                                    <td style="width: 141px; height: 20px;" align="left">
                                        <asp:TextBox runat="server" ID="txtpip" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="dealertags" runat="server">
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 20px;"
                                        align="left">
                                        &nbsp;Number of Dealer Tags:
                                    </td>
                                    <td style="width: 141px; height: 20px;" align="left">
                                        <asp:TextBox runat="server" ID="txtnumtags" TextMode="MultiLine" Width="200px" Height="60px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 10px; padding-bottom: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; width: 30% !important; padding-top: 10px; padding-bottom: 10px;"
                                        align="left">
                                        <span style="text-decoration: underline">&nbsp;Garage Keepers Coverage:</span>
                                    </td>
                                    <td style="width: 141px" align="left">
                                        <asp:CheckBox ID="chkGarageKeeperCoverage" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                        <strong>Garage Keepers Coverage - </strong>Vehicles of others in the care, custody
                                        or control of the applicant.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        &nbsp;Legal Liability: &nbsp;<asp:CheckBox runat="server" ID="chkLegalLiability"
                                            Style="width: 86px" />
                                    </td>
                                    <td style="width: 141px" align="left">
                                        &nbsp;Direct Primary: &nbsp;<asp:CheckBox runat="server" ID="chkDirectPrimary" Style="width: 74px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        Total Value per Lot:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="GKLLTotalValueperLot" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        &nbsp;Deductible:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList runat="server" ID="ddlGKLLDeductible" Style="width: 208px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        Max Limit any 1-Unit:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMaxLimitperUnit1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="30%" style="padding-top: 10px; padding-bottom: 10px;">
                                    </td>
                                    <td>
                                        <table style="border: solid 2px #999999" width="100%">
                                            <tr>
                                                <td>
                                                    Specified Perils
                                                    <asp:CheckBox runat="server" ID="chkGKLLSpecifiedPerils" />
                                                </td>
                                                <td>
                                                    Collision
                                                    <asp:CheckBox runat="server" ID="chkGKLLCollision" />
                                                </td>
                                                <td>
                                                    Comprehensive<asp:CheckBox runat="server" ID="chkGKLLComprehensive" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; padding-top: 10px; padding-bottom: 10px;">
                                    </td>
                                    <td style="width: 141px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; width: 30% !important; padding-top: 10px; padding-bottom: 10px;"
                                        align="left">
                                        <span style="text-decoration: underline">&nbsp;Physical Damage Coverage:</span>
                                    </td>
                                    <td style="width: 141px" align="left">
                                        <asp:CheckBox ID="chkPhyDamageCoverage" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                        <strong>Physical Damage Coverage </strong>- All vehicles under title or bill of
                                        sale owned by the applicant
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 24px;"
                                        align="left">
                                        Total Value per Lot:
                                    </td>
                                    <td align="left" style="height: 24px">
                                        <asp:TextBox ID="txtDealerPhyDamTotalValueperLot" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        Max Limit any 1-Unit:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDealersPhyDamMaxLimitanyUnit" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px; height: 22px;"
                                        align="left">
                                        &nbsp;Deductible:
                                    </td>
                                    <td align="left" style="height: 22px">
                                        <asp:DropDownList runat="server" ID="ddlDealerPhyDamDeductible" Style="width: 200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="30%" style="padding-top: 10px; padding-bottom: 10px;">
                                    </td>
                                    <td>
                                        <table style="border: solid 2px #999999" width="100%">
                                            <tr>
                                                <td>
                                                    Specified Perils<asp:CheckBox runat="server" ID="chkGKLLSpecifiedPerils1" />
                                                </td>
                                                <td>
                                                    Collision<asp:CheckBox runat="server" ID="chkGKLLCollision1" />
                                                </td>
                                                <td>
                                                    Comprehensive<asp:CheckBox runat="server" ID="chkGKLLComprehensive1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 45px; padding-top: 10px; padding-bottom: 10px;">
                                        <table>
                                            <tr>
                                                <td style="width: 198px" align="left">
                                                    Lot Lighted at Night:
                                                </td>
                                                <td align="left" style="width: 127px">
                                                    Yes<asp:RadioButton runat="server" ID="rdoLightedYes" GroupName="Lighted" Style="width: 78px" />
                                                </td>
                                                <td align="left" style="width: 109px">
                                                    No<asp:RadioButton runat="server" ID="rdoLightedNo" GroupName="Lighted" Style="width: 78px" />
                                                </td>
                                                <td align="left" style="width: 100px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        Lot Perimeter:
                                    </td>
                                    <td width="100%">
                                        <table style="border: solid 2px #999999" width="100%">
                                            <tr>
                                                <td align="right" width="20">
                                                    Chained
                                                </td>
                                                <td align="center" width="20">
                                                    <asp:RadioButton ID="rdoChianed" runat="server" GroupName="LotPerimeter" Width="20px" />
                                                </td>
                                                <td align="right" width="20">
                                                    Fenced
                                                </td>
                                                <td align="center" width="20">
                                                    <asp:RadioButton ID="rdoFenced" runat="server" GroupName="LotPerimeter" />
                                                </td>
                                                <td align="right" width="20px">
                                                    Open
                                                </td>
                                                <td align="center" width="20">
                                                    <asp:RadioButton ID="rdoOpen" runat="server" GroupName="LotPerimeter" Width="20px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30% !important; padding-top: 10px; padding-bottom: 10px;" align="left">
                                        Additional Notes:
                                    </td>
                                    <td width="100%" align="left">
                                        <asp:TextBox ID="txtAdditionalNotes" runat="server" Width="276px" Height="72px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset>
                            <table style="width: 680px" border="0" cellpadding="0" cellspacing="0" class="fieldset">
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                        <asp:TextBox ID="txtGQID" runat="server" Visible="false" Text="0"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="Transparent"
                                            BorderColor="Gray" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="height: 19px">
                                        <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <p>
                            <p align="left">
                                <b></b>
                            </p>
                    </div>
                </td>
            </tr>
        </table>
        <div id="footer">
            <h5>
                Southern Insurance Underwriters, Inc
            </h5>
            <h6>
                &copy;2008 <a href="(EmptyReference!)">Privacy Statement</a> | <a href="(EmptyReference!)">
                    Terms &amp; Conditions</a></h6>
        </div>
        </form>
    </center>
    <script type="text/javascript">
        function PrintPage() {
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
                for (var i = 0; i < window.Page_Validators.length; i++) {
                    window.ValidatorEnable(window.Page_Validators[i]);

                    //if condition to check whether the validation was successfull or not. 
                    if (!window.Page_Validators[i].isvalid) {
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
