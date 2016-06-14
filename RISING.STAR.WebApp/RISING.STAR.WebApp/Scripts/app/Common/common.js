var s,
    h,
    b,
    a,
    u,
    Common = {

        settings: {

        },

        url:
        {

            getPatUrl: 'Patients/GetPatients'

        },

        ajax: {

        },

        helper: {
            
            bindUIComponents: function () {
                
                $("#Patient").on('change', function () {

                    var k = sessionStorage.getItem('patientId') || 0;

                    //alert(sessionStorage.getItem('patientId'));
                    //console.log(k);
                    //if (k != 0)
                    //    sessionStorage.removeItem('patientId');

                    sessionStorage.setItem('patientId', $("#Patient").val());

                });

            },

            selectMenuItem: function(){

                var loc = window.location.pathname;
                
                $("#leftMenu > .active").removeClass('active');

                if (loc == '/Dashboard/Index')
                    $("#leftMenu").children('li').eq(0).addClass('active');
                else if (loc == '/OSI/ScatterMetrics')
                    $("#leftMenu").children('li').eq(1).addClass('active');
                else if (loc == '/OSI/ScatterTrendline')
                    $("#leftMenu").children('li').eq(2).addClass('active');
                else if (loc == '/OSI/ScatterReports')
                    $("#leftMenu").children('li').eq(3).addClass('active');
                else if (loc == '/TearFilm/OcularScatter')
                    $("#leftMenu").children('li').eq(5).addClass('active');
                else if (loc == '/TearFilm/Trendline')
                    $("#leftMenu").children('li').eq(6).addClass('active');
                else if (loc == '/TearFilm/CohortAnalysis')
                    $("#leftMenu").children('li').eq(7).addClass('active');
                else if (loc == '/TestingTreatment/TestingTreatmentSummary')
                    $("#leftMenu").children('li').eq(9).addClass('active');
                else if (loc == '/AcuTargetMetrics/AcuTargetMetrics')
                    $("#leftMenu").children('li').eq(10).addClass('active');
                else if (loc == '/PatientEd/PatientEducation')
                    $("#leftMenu").children('li').eq(11).addClass('active');
                else if (loc == '/Visiometrics/Visiometric')
                    $("#leftMenu").children('li').eq(13).addClass('active');
                else if (loc == '/Visiometrics/CompareVisiometrics')
                    $("#leftMenu").children('li').eq(14).addClass('active');
                else if (loc == '/Visiometrics/KAMRAOutcomes')
                    $("#leftMenu").children('li').eq(15).addClass('active');

            }

            //populatePatients: function () {
                              
            //    $.ajax({
            //        type: "POST",
            //        url: u.getPatUrl,
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json"
            //    }).done(function (data, textStatus, jqXHR) {

            //        if ($.isArray(data)) {
            //            $.each(data, function (i, v) {
            //                s.ddlPat.append($('<option>', {
            //                    value: v.Id,
            //                    text: v.Name
            //                }));
            //            });
            //        }
            //        else {
            //            // TODO: if its only one
            //        }
            //    }).always(function (data, textStatus, jqXHR) {

            //    }).fail(function (jqXHR, textStatus, errorThrown) {

            //    });
            //}

        },

        binder: {

        },

        init: function () {

            s = this.settings;
            h = this.helper;
            b = this.binder;
            a = this.ajax;
            u = this.url;
            
            var k = sessionStorage.getItem('patientId') || 0;

            if (k != 0)
            {                
                $("#Patient").find('option[value="'+k+'"]').prop('selected', true);
            }
   
            $("#Patient").on('change', function () {

            });

            $(".leftLink").on('click', function () {
                
                if ($("#Patient").val())
                {
                    this.href = this.href.replace("__ids__", $("#Patient").val());
                }
                else
                {
                    alert("Chose a patient");
                    return false;
                }
                
            });

            h.bindUIComponents();
            h.selectMenuItem();

        }

    }

$(function () {
    Common.init();
});