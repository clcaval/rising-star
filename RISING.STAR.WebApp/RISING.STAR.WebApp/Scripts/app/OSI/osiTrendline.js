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
            datePick: $('#datePicker')

        },

        url: {
            
        },

        graph: {

            generateOSIGraph: function () {

                s.osiGraph.highcharts({
                    chart: {
                        type: 'spline'/*,
                        backgroundColor: 'rgba(0,0,0,0)'*/
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

        },

        helper: {

        },

        binder: {

            bindDatePicker: function(){

                s.datePick.datepicker({
                    todayBtn: "linked",
                    autoclose: true
                });

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

        }

    }

$(function () {
    OSITrendline.init();
});
