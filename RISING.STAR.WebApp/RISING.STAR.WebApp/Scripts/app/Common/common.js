var h,
    u,
    Common = {

        url:
        {
            getPatUrl: 'Patients/GetPatients'
        },

        helper: {            
            bindUIComponents: function () {
                
                $("#Patient").on('change', function () {
                    var k = sessionStorage.getItem('patientId') || 0;
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

        },
        
        init: function () {

            h = this.helper;
            u = this.url;
            
            $("#Patient").select2();

            var k = sessionStorage.getItem('patientId') || 0;
            if (k != 0) {
                $("#Patient").val(k).trigger('change');
            }

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