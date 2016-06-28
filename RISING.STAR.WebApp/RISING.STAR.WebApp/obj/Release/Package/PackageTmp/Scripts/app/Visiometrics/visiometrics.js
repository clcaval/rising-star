var s,
    h,
    b,
    a,
    u,
    Visiometrics = {

        settings: {
          
            table: $("#tblExams")

        },

        url: { },
        
        ajax: { },

        helper: {

            logging: function(data){
                console.log(data);
            },

            showPDF: function(tr){
                
                var fileName =tr.children('td:nth-child(2)').text();
                var file = "http://" + window.location.hostname + ":" + window.location.port + "/Files/Exams/" + fileName

                var obj = $("<object>");
                obj.attr('data', file);
                obj.attr('width', 800);
                obj.attr('height', 600);
                obj.attr('type', 'application/pdf');
                
                $(".wrapper").html(obj);

            }

        },

        binder: {

            bindButtons: function()
            {

                $("#tblExams tbody tr").on('click', function () {
                    h.showPDF($(this));
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
    Visiometrics.init();
});