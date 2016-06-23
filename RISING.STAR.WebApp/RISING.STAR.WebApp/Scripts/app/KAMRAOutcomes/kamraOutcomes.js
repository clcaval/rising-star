var s,
    h,
    b,
    KAMRAOutcomes = {

        settings: {
          
            stDate: $("#startDate"),
            endDate: $("#endDate"),

        },

        helper: {

            logging: function(data){
                console.log(data);
            },

        },

        binder: {

            bindDatepicker: function () {

                $('.datepickers .input-group.date').datepicker({
                    todayBtn: "linked",
                    autoclose: true,
                    todayHighlight: true
                });

                $('.datepickers .input-group.date').datepicker({
                    todayBtn: "linked",
                    autoclose: true,
                    todayHighlight: true
                });

            },

            bindLinks: function () {

                $(".link").on('click', function () {
                   
                    var sDate = s.stDate.val().length > 0;
                    var eDate = s.endDate.val().length > 0;
                    console.log(sDate, eDate, typeof(sDate));

                    if (!(sDate && eDate))
                    {
                        alert('Pick both dates');
                        return false;
                    }

                });

            }
  
        },

        init: function () {

            s = this.settings;
            h = this.helper;
            b = this.binder;
           
            b.bindDatepicker();
            b.bindLinks();
            
        }

    }

$(function () {
    KAMRAOutcomes.init();
});