var s,
    g,
    h,
    b,
    a,
    u,
    TearFilmCohort = {

        settings: {
          
            graph: $("#graph")

        },

        url: {

        },

        graph: {
                            
            generateGraph: function (_data)
            {

                s.graph.highcharts({
                    chart: {
                        renderTo: 'container',
                        type: 'column',
                        options3d: {
                            enabled: true,
                            alpha: 15,
                            beta: 15,
                            depth: 50,
                            viewDistance: 25
                        }
                    },
                    title: {
                        text: 'Chart rotation demo'
                    },
                    subtitle: {
                        text: 'Test options by dragging the sliders below'
                    },
                    plotOptions: {
                        column: {
                            depth: 25
                        }
                    },
                    series: [{
                        data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
                    }]
                
                });

            }

        },

        ajax: {


        },

        helper: {

            logging: function(data)
            {
                console.log(data);
            },

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

            g.generateGraph();
                        
        }

    }

$(function () {
    TearFilmCohort.init();
});