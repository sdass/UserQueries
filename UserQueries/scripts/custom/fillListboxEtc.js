

$(document).ready(
    
    function () {
        console.log("ready!!");
        // not good window.history.forward(-1); //backbutton & refresh to stop

        doOtherInitialization();

       getTracksInjoson(fillUpTrackListBox); //global var used with passing callback function
        //var trackArrayLocal = getTracksInjosonSynch();
       // fillUpTrackListBoxWithLocal(trackArrayLocal);

        //-------fill 2 listboxes below---------
       var trackDropDnList = $('#DropDownList1');
        trackDropDnList.append($("<option/>").val('FL,NY,CH').text('EAST'));
        trackDropDnList.append($("<option/>").val('CA,SC,TO').text('WEST'));




    });

function fillUpTrackListBoxWithLocal(ltrackArray) {
    var track2Listbox = $('#ListBox1')
    $.each(ltrackArray, function (index, track) {
        console.log(index + " ----- " + track.fullName + " : " + track.abbrev);
        track2Listbox.append($("<option/>").val(track.abbrev).text(track.fullName));
    });
}

function fillUpTrackListBox(ptrackArray) {
    var track2Listbox = $('#ListBox1')
    $.each(ptrackArray, function (index, track) {
        console.log(index + " ----- " + track.fullName + " : " + track.abbrev);
        track2Listbox.append($("<option/>").val(track.abbrev).text(track.fullName));
    });
}

function getTracksInjoson(callback) {
    $.ajax({
        dataType: "json",
        url: document.URL.substring(0, document.URL.lastIndexOf("/") + 1  ) + "data/alltracks.json", // 'http://localhost:50049/data/alltracks.json',
        data: '',
        success: function (rcvdata, textStatus, jqXHR) {
            console.log("call successsful!");
            callback(rcvdata);
        }

    })
}

function doOtherInitialization(){
    $('#TextBox1').attr("placeholder", "mm-dd-yyyy");
    $('#TextBox1').val(''); //does not block refresh
}

function ValidateForm() {
    var isFormDataValid = false;
    
    var sdate = $('#TextBox1').val();       
    if (validateDate(sdate) == false) {
        $('#lblStatusId').html("Date format must be mm-dd-yyyy. Prepend 0 for single digit month or date. ").css('color', 'red');;
        return false;
    }
    
    var region1 = $("#DropDownList1 option:selected");
    console.log("region selceted: " + region1.text() + "value=" + region1.val());

    var trackSelected = $("#ListBox1 option:selected");
    if (region1.length == 0 || trackSelected.length == 0) {
        $('#lblStatusId').html("Please select both tracks and region. ").css('color', 'red');;
        return false;
    }

    var tracks ="";
    $.each(trackSelected, function (index, item) {
       console.log("----- log----")
       console.log("index=" + index + " text=" + $(item).text() + " value=" + $(item).val());
        //tracks += $(item).text() + ",";
       tracks += $(item).val() + ",";
    });
   
    //all good so offer user for final confirmation
    var msg = "To proceed press OK.\n" + "Inputs date: " + sdate + " region=" + region1.text() + "[" + region1.val() + "]" + " tracks=" + tracks.replace(/.$/, ".");
    var allInputs = "date=" + sdate + "|region=" + region1.text() + "[" + region1.val() + "]" + "|tracks=" + tracks.replace(/.$/, ".");
   // $('#lblStatusId').html("Inputs date: " + sdate + " " + region1.text() + " tracks=" + tracks.replace(/.$/, ".")).css('color', 'green');
    $('#txtBoxAllINputId').val(allInputs);
    var scanf = confirm(msg);
    if (!scanf) {
        return false;
    }
    return true;
}

function validateDate(dtstr) {
    var dateParts = dtstr.split('-');
    if (dtstr && (dateParts.length == 3) && (dateParts[0].length == 2) && (dateParts[1].length == 2) && (dateParts[2].length == 4)) {
        //month, day, year check
        var month = parseInt(dateParts[0]);
        var day = parseInt(dateParts[1]);
        var year = parseInt(dateParts[2]);
        if ((month > 0 && month <= 12) && (day > 0 && day <= 31) && (year >= 2019 && year <= 3019)) { //user input
            return true;
        }
    }
    return false;
}

/*
    function getTracksInjosonSynch() {
        $.ajax({
            dataType: "json",
            url:   document.URL.substring(0, document.URL.lastIndexOf("/") + 1  ) + "data/alltracks.json",  //'http://localhost:50049/data/alltracks.json',
            data: '',
            success: function (rcvdata, textStatus, jqXHR) {
                console.log("call successsful!");
                return rcvdata;
                
            },
            async: false

        })
}
*/