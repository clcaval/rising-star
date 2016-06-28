var s,
    h,
    b,
    a,
    u,
    CompareVisiometrics = {

        settings: {
          
            btnGroup: $("#btnGroup"),
            left: $("#leftPDF"),
            right: $("#rightPDF"),
            leftDD: $("#leftDropdown"),
            rightDD: $("#rightDropdown")

        },

        url: {
            
            getExamsUrl: "http://" + window.location.hostname + ":" + window.location.port + "/Visiometrics/CompareVisiometrics/RetrieveExams"

        },
        
        ajax: {

            getExams: function(_data, _container){

                $.get(u.getExamsUrl, _data, function (responseText) {

                    s.leftDD.html("");
                    s.rightDD.html("");

                    if($.isArray(responseText))
                    {

                        s.leftDD.append($("<option />").val("0").text("Select one exam"));
                        s.rightDD.append($("<option />").val("0").text("Select one exam"));

                        $.each(responseText, function (k, v) {

                            s.leftDD.append($("<option />").val(this.DocumentId).text(this.DocumentDisplay).attr('data-filename', this.DocumentName));
                            s.rightDD.append($("<option />").val(this.DocumentId).text(this.DocumentDisplay).attr('data-filename', this.DocumentName));

                        });                       

                    }

                });

            }

        },

        helper: {

            logging: function(data){
                console.log(data);
            },

            showPDF: function(fileName, container){
                
                var file = "http://" + window.location.hostname + ":" + window.location.port + "/Files/Exams/" + fileName

                var obj = $("<object>");
                obj.attr('data', file);
                obj.attr('width', 530);
                obj.attr('height', 600);
                obj.attr('type', 'application/pdf');
                
                container.html(obj);

            }

        },

        binder: {

            bindButtons: function()
            {

                $('.btns').on('click', function () {
                    
                    s.left.html("");
                    s.right.html("");

                    var type = $(this).attr('data-type');

                    var data = {
                        patientId: $("#Patient").val(),
                        type: type
                    }
                    
                    a.getExams(data, s.left);
                    
                });
                
            },

            bindDropdowns: function () {

                s.leftDD.on('change', function () {                    
                    var optionSelected = $("option:selected", this);
                    var fileName = optionSelected.attr('data-filename');                    
                    h.showPDF(fileName, s.left);
                });

                s.rightDD.on('change', function () {
                    var optionSelected = $("option:selected", this);
                    var fileName = optionSelected.attr('data-filename');
                    h.showPDF(fileName, s.right);
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
            b.bindDropdowns();

        }

    }

$(function () {
    CompareVisiometrics.init();
});