var s,
    g,
    h,
    b,
    a,
    u,
    OSI = {

        settings: {

            // 2D patient info
            pvaDecPat: $("#pvaDecimalPatient"),
            pvaSmellenPat: $("#pvaSmellenPatient"),
            pvaDecPat3D: $("#pvaDecimalPatient3D"),
            pvaSmellenPat3D: $("#pvaSmellenPatient3D"),

            // 3D patient info
            pvaDecNormal: $("#pvaDecimalNormal"),
            pvaSmellenNormal: $("#pvaSmellenNormal"),
            pvaDecNormal3D: $("#pvaDecimalNormal3D"),
            pvaSmellenNormal3D: $("#pvaSmellenNormal3D"),

            // Gauges
            vertGaugePat: $("#verticalGaugePatient"),
            vertGaugeNormal: $("#verticalGaugeNormal"),
            vertGaugePat3D: $("#verticalGaugePatient3D"),
            vertGaugeNormal3D: $("#verticalGaugeNormal3D"),

            // Strehl Ratio information
            widAt50Pat: $("#widAt50Patient"),
            widAt10Pat: $("#widAt10Patient"),

            widAt50Norm: $("#widAt50Normal"),
            widAt10Norm: $("#widAt10Normal"),

            // Strehl Ratio graphs
            strehlGraphPatient: $("#strehlGraphPatient"),
            strehlGraphNormal: $("#strehlGraphNormal")

    
        },

        url:
        {

        },

        graph: {

            verticalGauge: function(osiValue, container)
            {

                container.highcharts({

                    chart: {
                        type: 'gauge',
                        plotBackgroundColor: null,
                        plotBackgroundImage: null,
                        plotBorderWidth: 0,
                        plotShadow: false
                    },

                    title: {
                        text: 'OSI: ' + osiValue
                    },

                    pane: {
                        startAngle: -120,
                        endAngle: 120,
                        background: [{
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#FFF'],
                                    [1, '#333']
                                ]
                            },
                            borderWidth: 0,
                            outerRadius: '109%'
                        }, {
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#333'],
                                    [1, '#FFF']
                                ]
                            },
                            borderWidth: 1,
                            outerRadius: '107%'
                        }, {
                            // default background
                        }, {
                            backgroundColor: '#DDD',
                            borderWidth: 0,
                            outerRadius: '105%',
                            innerRadius: '103%'
                        }]
                    },

                    // the value axis
                    yAxis: {
                        min: 0,
                        max: 6,

                        minorTickInterval: 'auto',
                        minorTickWidth: 1,
                        minorTickLength: 10,
                        minorTickPosition: 'inside',
                        minorTickColor: '#666',

                        tickPixelInterval: 30,
                        tickWidth: 2,
                        tickPosition: 'inside',
                        tickLength: 10,
                        tickColor: '#666',
                        labels: {
                            step: 2,
                            rotation: 'auto'
                        },
                        title: {
                            text: 'OSI'
                        },
                        plotBands: [{
                            from: 0,
                            to: 2,
                            color: '#55BF3B' // green
                        }, {
                            from: 2,
                            to: 4,
                            color: '#DDDF0D' // yellow
                        }, {
                            from: 4,
                            to: 6,
                            color: '#DF5353' // red
                        }]
                    },

                    series: [{
                        name: 'OSI',
                        data: [osiValue],
                        tooltip: {
                            valueSuffix: ''
                        }
                    }]

                });                

            },

            getPatientInfo: function(id)
            {

                var data = a.getPredictedVisualAcuityPatient(id);

                s.pvaDecPat.html(data.decimal);
                s.pvaSmellenPat.html(data.smellen);
                s.pvaDecPat3D.html(data.decimal);
                s.pvaSmellenPat3D.html(data.smellen);

                data = a.getPredictedVisualAcuityNormal();

                s.pvaDecNormal.html(data.decimal);
                s.pvaSmellenNormal.html(data.smellen);
                s.pvaDecNormal3D.html(data.decimal);
                s.pvaSmellenNormal3D.html(data.smellen);

            },

            getStrehlRatioGraph: function (id, container, _data)
            {
                
                container.highcharts({
                    chart: {
                        type: 'spline'
                    },
                    title: {
                        text: 'Title',
                        x: -20 //center
                    },
                    subtitle: {
                        text: 'Subtitle',
                        x: -20
                    },
                    xAxis: {
                        categories: ['', '-30', '-20', '-10', '0', '10',
                            '20', '30', ' ']
                            ,
                        title: {
                            text: 'Arc min'
                        }
                    },
                    yAxis: {
                        title: {
                            text: 'Put title here'
                        },
                        plotLines: [{
                            value: 0,
                            width: 1,
                            color: '#808080'
                        }, {
                            value: 120,
                            color: 'red',
                            dashStyle: 'shortdash',
                            width: 2,
                            label: {
                                text: ''
                            }
                        }, {
                            value: 38,
                            color: 'red',
                            dashStyle: 'shortdash',
                            width: 2,
                            label: {
                                text: ''
                            }
                        }]
                    },
                    tooltip: {
                        valueSuffix: ''
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: [{
                        name: 'Patient',
                        data: _data
                    }]
                });

            },

            getStrehlRatioPatient: function(id){
                
                var data = a.getStrehlRatioWidthPatient(id);
                // TODO: get real info here
                var patientData = [20, 30, 40, 50, 240, 70, 38, 30, 27];                
                this.getStrehlRatioGraph(id, s.strehlGraphPatient, patientData);

                s.widAt50Pat.html(data.widthAt50);
                s.widAt10Pat.html(data.widthAt10);
                               
            },

            getStrehlRatioNormal: function () {
                                

                var data = a.getStrehlRatioWidthNormal();
                // TODO: get real info here
                var patientData = [20, 30, 40, 50, 240, 70, 38, 30, 27];
                this.getStrehlRatioGraph(596, s.strehlGraphNormal, patientData);

                s.widAt50Norm.html(data.widthAt50);
                s.widAt10Norm.html(data.widthAt10);


            }


        },

        ajax: {

            getPredictedVisualAcuityPatient: function(id)
            {

                // TODO: get this from db
                return { decimal: 0.5, smellen: '20/40' }

            },
            
            getPredictedVisualAcuityNormal: function()
            {

                // TODO: get this from db
                return { decimal: 1.7, smellen: '20/12' }

            },

            getStrehlRatioWidthPatient: function(id)
            {
                // TODO: get this from db
                return { widthAt50: 8.56, widthAt10: 61.0 }
            },
           
            getStrehlRatioWidthNormal: function () {
                // TODO: get this from db
                return { widthAt50: 2.47, widthAt10: 7.02 }
            }

        },
        
        helper: {

            getPatient: function () {
                return $("#Patient").val();
            }
            
        },

        binder: {            

        },

        init: function () {

            s = this.settings;
            g = this.graph;
            h = this.helper;
            b = this.binder;
            a = this.ajax;
            u = this.url;


            g.verticalGauge(4.9, s.vertGaugePat);
            g.verticalGauge(0.4, s.vertGaugeNormal);

            g.verticalGauge(4.9, s.vertGaugePat3D);
            g.verticalGauge(0.4, s.vertGaugeNormal3D);

            g.getPatientInfo(h.getPatient());

            g.getStrehlRatioPatient(h.getPatient());
            g.getStrehlRatioNormal();

        }

    }

$(function () {
    OSI.init();
});
