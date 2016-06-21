var s,
    h,
    b,
    a,
    u,
    Treatment = {

        settings: {
          
            addComm: $("#btnAddComment"),
            modal: $("#myModal"),
            btnSave: $("#btnSave"),
            txtComm: $("#txtComment")

        },

        url: {

            addPatCommUrl: "http://" + window.location.hostname + ":" + window.location.port + "/PatientsComments/Create"

        },
        
        ajax: {

            postPatientComment: function (_data, url) {

                $.post(u.addPatCommUrl, _data,

                    function (returnedData) {

                        console.log(_data);
                        console.log(returnedData);
                        
                        if (returnedData.message == "OK") {

                            var momt = moment().format('M/DD/YYYY hh:mm:ss a');
                            console.log(momt);

                            $("#tblComments tbody tr:last").after(
                                    $("<tr>").append($('<td>').text(momt))
                                             .append($('<td>').text($("#txtComment").val()))
                            );

                        }
                        else {
                            alert(2);
                        }

                    }).fail(function () {
                        console.log("error");
                    });

                s.modal.modal('toggle');

            }

        },

        helper: {

            logging: function(data)
            {
                console.log(data);
            },

        },

        binder: {

            bindButtons: function()
            {

                s.btnSave.on('click', function () {
                    
                    var data = {
                        CommentId: "",
                        PatientId: $("#Patient").val(),
                        Comment: s.txtComm.val(),
                        Date: "",
                        DoctorId: ""
                    };

                    a.postPatientComment(data, u.addPatCommUrl);

                });
                
            }
  
        },

        init: function () {

            s = this.settings;
            h = this.helper;
            b = this.binder;
            a = this.ajax;
            u = this.url;
           
            b.bindButtons();

        }

    }

$(function () {
    Treatment.init();
});