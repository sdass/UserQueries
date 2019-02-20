

$(document).ready(
    function () {
        console.log("ready!!");

        //put an ajax call to read the track list from a file or database and fill up the text box eventually.
       getTracksInjoson(fillUpTrackListBox); //global var used with passing callback function
        //var trackArrayLocal = getTracksInjosonSynch();
       // fillUpTrackListBoxWithLocal(trackArrayLocal);

        /*
        var a = {};
        a["fullName"] = 'Aqueduct'; a["abbrev"] = 'AQU';
        trackArray.push(a);
        //-------------
        a = {};
        a["fullName"] = 'Gulfstream'; a["abbrev"] = 'GF';
        trackArray.push(a);
        //-----------------
        a = {};
        a["fullName"] = 'Laurel'; a["abbrev"] = 'LARC';
        trackArray.push(a);
        //-----------------
        a = {};
        a["fullName"] = 'Santa Anita'; a["abbrev"] = 'SAN';
        trackArray.push(a);
        */
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
        url: 'http://localhost:50049/data/alltracks.json',
        data: '',
        success: function (rcvdata, textStatus, jqXHR) {
            console.log("call successsful!");
            callback(rcvdata);
        }

    })
}


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