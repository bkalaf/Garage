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
//function validateRange ( src, args ) 
//    {       
//        var controlid= src.id.split("CFromValidator");  //substring(src.id.indexOf("CFromValidator"),src.length);//.split("CustomTermFromValidator");  
//        //alert(controlid.length);
//        var id=1;
//        if (controlid.length > 1)
//            id=controlid[1];
//        else
//        {
//            controlid= src.id.split("CToValidator");
//            
//            if (controlid.length > 1)
//            id=controlid[1];
//        }    
//        if (TwoRanage(src.id,id) == false)
//        {
//            args.IsValid = false;                
//        }     
//    }
//    function TwoRanage(val,id)
//    {       
//        var ToDate ="<%=MMDDYYYY %>";
//        var FromDate=01/01/1900;
//        //var str=val.substring(0,val.lastIndexOf("_"));
//        //var str=val;
//        
//      
//       if(document.getElementById(val + "txtTermFrom" + id).value != "")              
//           FromDate =document.getElementById(val + "txtTermFrom" + id).value;
//        if(document.getElementById(val + "txtTermto" + id).value != "")            
//           ToDate =document.getElementById(val + "txtTermto" + id).value;

//        var start = new Date (FromDate);
//        var end = new Date (ToDate);
//        
//        
//        
//        if (end <= start) 
//              return false;
//        else
//              return true;   

//    }
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
    for (var index = 0; index < count; index++) {
        if (getValue("tb" + baseName + "Name" + (index + 1).toString())) {
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
    $(control).change(function () {
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
        if (JSON.parse(getValue("txtMplOwnerSpouseNameAge"))) {
            hideControls(oldNameAges);
        } else {
            hideControls(newNamesAges);
        }
    } catch (e) {
        hideControls(oldNameAges);
    }
});