
/** Grid header Check/Uncheck all: Begin **/

var TotalChkBx;
var Counter;


function Initialize(nCount)
{
    //Get total no. of CheckBoxes in side the GridView.
    TotalChkBx = nCount;
    //Get total no. of checked CheckBoxes in side the GridView.
    Counter = 0;
}

function HeaderClick(CheckBox,HCheckBox) 
{
    //Get target base & child control.
    var TargetBaseControl = document.getElementById(HCheckBox);
    var TargetChildControl = "chkSelect";

    //Get all the control of the type INPUT in the base control.
    var Inputs = TargetBaseControl.getElementsByTagName("input");

    //Checked/Unchecked all the checkBoxes in side the GridView.
    for (var n = 0; n < Inputs.length; ++n)
        if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
        Inputs[n].checked = CheckBox.checked;
    //Reset Counter
    Counter = CheckBox.checked ? TotalChkBx : 0;
}

function ChildClick(CheckBox, HCheckBox) 
{
    //get target base & child control.
    var HeaderCheckBox = document.getElementById(HCheckBox);
   
    //Modifiy Counter;            
    if (CheckBox.checked && Counter < TotalChkBx)
        Counter++;
    else if (Counter > 0)
        Counter--;

    //Change state of the header CheckBox.
    if (Counter < TotalChkBx)
        HeaderCheckBox.checked = false;
    else if (Counter == TotalChkBx)
        HeaderCheckBox.checked = true;
}

/** Grid header Check/Uncheck all: End **/


function isNumericKeyStroke(i) {
    if (i.value.length > 0) {
        i.value = i.value.replace(/[^\d-]+/g, '');
    }
}

function highlightTextBox(IDfield) {

    formattedID = "\":[ID*=" + IDfield + "]\"";
    
    $(formattedID).focus(function() {
        $(this).parent().parent().addClass("curFocus");
    });

    $(formattedID).blur(function() {
        $(this).parent().parent().removeClass("curFocus");
    });
}

function highlightRow(gvID) {
    gvID = "\":[ID*=" + gvID + "]\" tr:gt(0)";
    $(gvID).css({ "width": "100%" });
    $(gvID).hover(function() {
        $(this).not("th").toggleClass("highlightrow");
    }, function() {
        $(this).toggleClass("highlightrow");
    });
}