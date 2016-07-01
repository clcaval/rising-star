var s,
    g,
    h,
    b,
    a,
    u,
    OSIReport = {

        settings: {
          
            graph: $("#dispersionGraph"),
            btnGraph: $("#btnShowGraph"),
            btnReset: $("#btnReset"),
            StartAge: $("#StartAge"),
            EndAge: $("#EndAge"),
            SelectedFirstCriteria: $("#SelectedFirstCriteria"),
            SelectedSecondCriteria: $("#SelectedSecondCriteria"),
            SelectedTimewindow: $("#SelectedTimewindow")

        },

        url: {

            getQueryDataURL: "http://" + window.location.hostname + ":" + window.location.port + "/OSI/ScatterReports/RetrieveOSICohort"

        },

        graph: {
                            
            generateScatter: function(_data)
            {

                s.graph.highcharts({
                    chart: {
                        type: 'scatter',
                        zoomType: 'xy'
                    },
                    title: {
                        text: 'Chart title'
                    },
                    subtitle: {
                        text: 'Chart mini title'
                    },
                    xAxis: {
                        title: {
                            enabled: true,
                            text: 'X-axis name'
                        },
                        startOnTick: true,
                        endOnTick: true,
                        showLastLabel: true
                    },
                    yAxis: {
                        title: {
                            text: 'Y-axis name'
                        }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'left',
                        verticalAlign: 'top',
                        x: 100,
                        y: 70,
                        floating: true,
                        backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF',
                        borderWidth: 1
                    },
                    plotOptions: {
                        scatter: {
                            marker: {
                                radius: 5,
                                states: {
                                    hover: {
                                        enabled: true,
                                        lineColor: 'rgb(100,100,100)'
                                    }
                                }
                            },
                            states: {
                                hover: {
                                    marker: {
                                        enabled: false
                                    }
                                }
                            },
                            tooltip: {
                                headerFormat: '<b>{series.name}</b><br>',
                                pointFormat: '{point.x} days, OSI {point.y}'
                            }
                        }
                    },
                    series: _data
                });

            }

        },

        ajax: {

            getQueryData: function (_data) {

                $.get(u.getQueryDataURL, _data, function(returnedResult){

                    console.log(returnedResult);
                    console.log(JSON.stringify(returnedResult));

                    g.generateScatter(returnedResult);

                });

            }

        },

        helper: {

            logging: function(data)
            {
                console.log(data);
            },

        },

        binder: {

            bindDatepicker: function () {

                $("#datepicker").datepicker({});

            },

            bindButtons: function () {

                s.btnGraph.on('click', function () {

                    var data = {
                        StartAge: s.StartAge.val(),
                        EndAge: s.EndAge.val(),
                        SelectedFirstCriteria: s.SelectedFirstCriteria.val(),
                        SelectedSecondCriteria: s.SelectedSecondCriteria.val(),
                        SelectedTimewindow: s.SelectedTimewindow.val()
                    };

                    console.log(data);

                    a.getQueryData(data);

                });

                s.btnReset.on('click', function () {
                    alert('reset query');
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

            b.bindDatepicker();
            b.bindButtons();
            g.generateScatter();
                        
        }

    }

$(function () {
    OSIReport.init();
});



/*
generateScatter: function(_data)
{

    s.graph.highcharts({
        chart: {
            type: 'scatter',
            zoomType: 'xy'
        },
        title: {
            text: 'Chart title'
        },
        subtitle: {
            text: 'Chart mini title'
        },
        xAxis: {
            title: {
                enabled: true,
                text: 'X-axis name'
            },
            startOnTick: true,
            endOnTick: true,
            showLastLabel: true
        },
        yAxis: {
            title: {
                text: 'Y-axis name'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'left',
            verticalAlign: 'top',
            x: 100,
            y: 70,
            floating: true,
            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF',
            borderWidth: 1
        },
        plotOptions: {
            scatter: {
                marker: {
                    radius: 5,
                    states: {
                        hover: {
                            enabled: true,
                            lineColor: 'rgb(100,100,100)'
                        }
                    }
                },
                states: {
                    hover: {
                        marker: {
                            enabled: false
                        }
                    }
                },
                tooltip: {
                    headerFormat: '<b>{series.name}</b><br>',
                    pointFormat: '{point.x} cm, {point.y} kg'
                }
            }
        },
        series: [{
            name: '1st Serie',
            color: 'rgba(223, 83, 83, .5)',
            data: [[161.2, 51.6], [167.5, 59.0], [159.5, 49.2], [157.0, 63.0], [155.8, 53.6],
                [170.0, 59.0], [159.1, 47.6], [166.0, 69.8], [176.2, 66.8], [160.2, 75.2],
                [172.5, 55.2], [170.9, 54.2], [172.9, 62.5], [153.4, 42.0], [160.0, 50.0],
                [147.2, 49.8], [168.2, 49.2], [175.0, 73.2], [157.0, 47.8], [167.6, 68.8],
                [159.5, 50.6], [175.0, 82.5], [166.8, 57.2], [176.5, 87.8], [170.2, 72.8],
                [174.0, 54.5], [173.0, 59.8], [179.9, 67.3], [170.5, 67.8], [160.0, 47.0],
                [154.4, 46.2], [162.0, 55.0], [176.5, 83.0], [160.0, 54.4], [152.0, 45.8],
                [162.1, 53.6], [170.0, 73.2], [160.2, 52.1], [161.3, 67.9], [166.4, 56.6]]

        }, {
            name: '2nd Serie',
            color: 'rgba(119, 152, 191, .5)',
            data: [
                    [174.0, 65.6],
                    [175.3, 71.8],
                    [193.5, 80.7],
                    [186.5, 72.6], [187.2, 78.8],
                [181.5, 74.8], [184.0, 86.4], [184.5, 78.4], [175.0, 62.0], [184.0, 81.6],
                [180.0, 76.6], [177.8, 83.6], [192.0, 90.0], [176.0, 74.6], [174.0, 71.0],
                [184.0, 79.6], [192.7, 93.8], [171.5, 70.0], [173.0, 72.4], [176.0, 85.9],
                [176.0, 78.8], [180.5, 77.8], [172.7, 66.2], [176.0, 86.4], [173.5, 81.8],
                [178.0, 89.6], [180.3, 82.8], [180.3, 76.4], [164.5, 63.2], [173.0, 60.9],
                [183.5, 74.8], [175.5, 70.0], [188.0, 72.4], [189.2, 84.1], [172.8, 69.1],
                [170.0, 59.5], [182.0, 67.2], [170.0, 61.3], [177.8, 68.6], [184.2, 80.1],
                [186.7, 87.8], [171.4, 84.7], [172.7, 73.4], [175.3, 72.1], [180.3, 82.6],
                [182.9, 88.7], [188.0, 84.1], [177.2, 94.1], [172.1, 74.9], [167.0, 59.1],
                [169.5, 75.6], [174.0, 86.2], [172.7, 75.3], [182.2, 87.1], [164.1, 55.2],
                [163.0, 57.0], [171.5, 61.4], [184.2, 76.8], [174.0, 86.8], [174.0, 72.2]]
        }]
    });

}
*/