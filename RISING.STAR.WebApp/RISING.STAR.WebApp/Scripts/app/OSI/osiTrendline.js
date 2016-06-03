var s,
    g,
    h,
    b,
    a,
    u,
    OSITrendline = {

        settings: {

            intHistTable: $("#intHistTable"),
            osiGraph: $('#osiGraph'),
            datePick: $('#datePicker'),
            btnAddIntervention: $("#btnAddIntervention")

        },

        url: {
            
            addIntTypeUrl: window.location. window.location.hostname + ":" + window.location.port + "/Intervention/InterventionEvents/Create"

        },

        graph: {

            generateOSIGraph: function () {

                s.osiGraph.highcharts({
                    chart: {
                        type: 'spline'
                    },
                    title: {
                        text: 'Objective Scatter Index'
                    },
                    subtitle: {
                        text: $("#Patient option:selected").text()
                    },
                    xAxis: {
                        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                            'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                    },
                    yAxis: {
                        title: {
                            text: 'OSI'
                        }
                    },
                    tooltip: {
                        crosshairs: true,
                        shared: true
                    },
                    plotOptions: {
                        spline: {
                            marker: {
                                radius: 4,
                                lineColor: '#666666',
                                lineWidth: 1
                            }
                        }
                    },
                    series: [{
                        name: 'OSI',
                        marker: {
                            symbol: 'square'
                        },
                        data: [1.0, 1.5, 0.5, 2, 5, 4 , 2.2, {
                            y: 2.5,
                            marker: {
                                symbol: 'url(https://www.highcharts.com/samples/graphics/sun.png)'
                            }
                        }, 4.3, 2.3, 1.9, 5.6]

                    }, {
                        name: "Normal OSI",
                        color: 'red',
                        marker: {
                            symbol: 'diamond'
                        },
                        data: [1, { y: 1, marker: { enabled: false } }, { y: 1, marker: { enabled: false } },
                                    { y: 1, marker: { enabled: false } }, { y: 1, marker: { enabled: false } },
                                    { y: 1, marker: { enabled: false } }, { y: 1, marker: { enabled: false } },
                                    { y: 1, marker: { enabled: false } }, { y: 1, marker: { enabled: false } },
                                    { y: 1, marker: { enabled: false } }, { y: 1, marker: { enabled: false } },
                               1]
                    }]
                });
            }
            
        },

        ajax: {

            postIntervention: function(_data){
                
                h.logging(u.addIntTypeUrl);
                h.logging(JSON.stringify(_data));

                var a =  $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    type: 'POST',
                    dataType: 'json',
                    data: JSON.stringify(_data),
                    url: h.addIntTypeUrl
                }).done(function(data, textStatus, jqXHR){
                                   
                    h.logging(data);
                    h.logging(textStatus);
                    h.logging(jqXHR);

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    
                    h.logging(jqXHR);
                    h.logging(textStatus);
                    h.logging(errorThrown);
                  

                }).always(function(data, textStatus, jqXHR){
                    h.logging(data);
                    h.logging(textStatus);
                    h.logging(jqXHR);
                });

            },

            
        },

        helper: {

            logging: function(data)
            {
                console.log(data);
            }

        },

        binder: {

            bindDatePicker: function(){

                s.datePick.datepicker({
                    todayBtn: "linked",
                    autoclose: true
                });

            },

            bindIntervention: function () {
                s.btnAddIntervention.on('click', function () {
                    var data = {}; // InterventionEventGuid,PatientGuid,InterventionTypeGuid,Eye,Date
                    data["InterventionEventGuid"] = "";
                    data["PatientGuid"] = $("#Patient").val();
                    data["InterventionTypeGuid"] = $("#SelectedIntervention").val();
                    data["Eye"] = $("#SelectedEye").val();
                    data["Date"] = $("#dateSelected").val();
                    console.log(data);
                    a.postIntervention(data);
                })
            }

        },

        init: function () {

            s = this.settings;
            g = this.graph;
            h = this.helper;
            b = this.binder;
            a = this.ajax;
            u = this.url;

            g.generateOSIGraph();
            b.bindDatePicker();
            b.bindIntervention();

        }

    }

$(function () {
    OSITrendline.init();
});
