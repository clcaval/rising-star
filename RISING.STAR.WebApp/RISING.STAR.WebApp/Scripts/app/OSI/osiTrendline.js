var s,
    g,
    h,
    b,
    a,
    u,
    OSITrendline = {

        settings: {

            intHistTable: $("#intHistTable"),
            tbody: $("#tbodyInterventions"),
            osiGraph: $('#osiGraphType1'),
            datePick: $('#datePicker'),
            btnSave: $("#btnSave"),
            intervEventId: $("#interventionId"),
            btnAddIntPat: $("#btnAddIntervention"),

            start: $("#starFilter"),
            end: $("#endFilter"),
            btnFilt: $("#btnFilter")

        },

        url: {
            
            addIntEventUrl: "http://" + window.location.hostname + ":" + window.location.port + "/Intervention/InterventionEvents/CreateViewModel",
            editIntEventUrl: "http://" + window.location.hostname + ":" + window.location.port + "/Intervention/InterventionEvents/EditViewModel",
            deleteIntUrl: "http://" + window.location.hostname + ":" + window.location.port + "/Intervention/InterventionEvents/Delete",
            retrieveAcqUrl: "http://" + window.location.hostname + ":" + window.location.port + "/OSI/ScatterTrendline/RetrieveAcquisitions",
            iconsURL: '../../../Images/ChartsIcons/20/'

        },

        graph: {

            generateOSIGraph: function (_data, _icons) {

                var categories = [], values = [], normalOsi = [], interventions = [], intervValues = [];
                var maxOsi = 0;

                s.tbody.children('tr').each(function (i, e) {
                    var d = $(this).children('td:nth-child(5)').text();
                    var date = moment(d);
                    var icon = $(this).children('td:nth-child(2)').text();
                    interventions.push({ 'date': date, 'icon': icon , display: date.format('MMM/YYYY') });
                });
                
                $.each(_data, function (i, v) {
               
                    normalOsi.push({
                        y: 1,
                        marker: {
                            enabled: false
                        }
                    });

                    categories.push(v.DisplayX);
                                        
                    var momentDate = moment(v.Date);                    
                    var t = momentDate.format('MMM/YYYY');
                    
                    var found = interventions.filter(x=> x.display === t);
                    var iconsForPoint = [];

                    if(found.length > 0)
                    {

                        $.each(found, function(q, p){
                            iconsForPoint.push(p.icon);
                        });

                        values.push({
                            y: v.Value,
                            custom: iconsForPoint.join(','),
                            marker: {
                                symbol: 'url(' + u.iconsURL + 'lightning.png)'
                            }
                        });

                    }else
                    {
                        values.push(v.Value);
                    }

                });
                                                                
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
                        categories: categories
                    },
                    yAxis: {
                        title: {
                            text: 'OSI'
                        }
                    },
                    tooltip: {
                        crosshairs: true,
                        shared: true,
                        useHTML: true,
                        formatter: function(){
    
                            var s = '<b>'+ this.x +'</b>';
                            $.each(this.points, function(i, point) {
                                s += '<br/><span style="color:'+ point.series.color +'">\u25CF</span>: ' + point.series.name + ': ' + point.y;
                            });
                            s += "<br />";
                            var point = this.points[0];
                            var custom = point.point.custom;
                            if(custom){
                                var imgs = custom.split(',');
                                $.each(imgs, function(index, image){
                                    var img = "<img src='"+u.iconsURL + image+"'/>";
                                    s = s + img + "&nbsp;";
                                });
                            }
                            return s;
                        }
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
                        point: {
                            events: {
                                click: function (event) {
                                    
                                }
                            }
                        },
                        data: values

                    }, {
                        name: "Normal OSI",
                        color: 'red',
                        marker: {
                            symbol: 'diamond'
                        },
                        data: normalOsi
                    }]
                });
            }            
        },

        ajax: {

            postIntervention: function(_data, url){
                
                console.log(_data, url);

                $.post(u.addIntEventUrl, _data,

                    function (returnedData) {
                           
                        var date = moment($("#dateSelected").val());
                        
                        if (returnedData.message == "OK") {
                            s.tbody.append($('<tr>')
                                        .append($('<td>')
                                            .text(returnedData.guid)
                                            .addClass('hidden'))
                                        .append($('<td>')
                                            .text($("#SelectedIntervention option:selected").text())
                                            .attr('id', $("#SelectedIntervention option:selected").val()))
                                        .append($('<td>')
                                            .text($("#SelectedEye").val()))
                                        .append($('<td>')
                                            .text(date.format('YYYY-MMM-DD')))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .text('Edit')
                                                .addClass('btn btn-primary edit')
                                                .attr('data-toggle', 'modal')
                                                .attr('data-target', '#editModal'))
                                                .on('click', function () {
                                                    var id = $(this).parent().children('td:first-child').text();
                                                    s.intervEventId.text(id);
                                                })
                                            )
                                        .append($('<td>')
                                            .append($('<button>')
                                                .text('X')
                                                .addClass('btn btn-danger delete')
                                                .attr('data-toggle', 'modal')
                                                .attr('data-target', '#deleteModal'))
                                                .on('click', function () {
                                                    var id = $(this).parent().children('td:first-child').text();
                                                    s.intervEventId.text(id);   
                                                }))
                                    );
                        }
                        else {
                            alert(2);
                        }

                }).fail(function () {
                    console.log("error");
                });

                $('#editModal').modal('toggle');
            },

            deleteIntervention: function (_data) {
                
                $.post(u.deleteIntUrl, _data,
                    function (returnedData) {

                        if (returnedData.message == "OK") {
                            var s = $("#tbodyInterventions tr td:contains('"+ _data.id +"')").parent();
                            s.remove();
                            $('#deleteModal').modal('toggle');
                        }
                        else {
                            // treat error
                        }
                    }).fail(function () {
                        console.log("error");
                    });
                
            },

            getOSITrendline: function(_data) {
                
                console.log(_data);

                $.get(u.retrieveAcqUrl, _data,
                       function (returnedData) {
                           g.generateOSIGraph(returnedData);
                       });
            }

        },

        helper: {

            logging: function(data)
            {
                console.log(data);
            }

        },

        binder: {

            bindInitialFilters: function(){ 
            
                $("#eyeFilter option:eq(1)").attr('selected', true);

                // TODO: remove hardcode
                $("#startFilter").val('01/01/2016');
                $("#endFilter").val('12/31/2016');

            },

            bindDatePicker: function () {

                s.datePick.datepicker({
                    todayBtn: "linked",
                    autoclose: true
                });

                $('.input-daterange').datepicker({
                    autoclose: true,
                    minViewMode: 1                    
                });

            },

            bindSave: function () {
                
                s.btnSave.on('click', function () {

                    var data;
                    var eventGuid = s.intervEventId.text();
                    console.log(eventGuid, eventGuid.length);

                    if(eventGuid.length > 0)
                    {
                        data = {
                            InterventionEventGuid: eventGuid,
                            PatientGuid: $("#Patient").val(),
                            SelectedIntervention: $("#SelectedIntervention").val(),
                            SelectedEye: $("#SelectedEye").val(),
                            Date: $("#dateSelected").val()                        
                        };
                    }
                    else
                    {
                        data = {
                            InterventionEventGuid: "",
                            PatientGuid: $("#Patient").val(),
                            SelectedIntervention: $("#SelectedIntervention").val(),
                            SelectedEye: $("#SelectedEye").val(),
                            Date: $("#dateSelected").val()                        
                        };
                    }
                    

                    var url = data.InterventionEventGuid.length == 0 ? u.addIntEventUrl : u.editIntEventUrl;
                    a.postIntervention(data, url);

                });

            },
            
            bindEdits: function()
            {
                $('.edit').on('click', function () {

                    var id = $(this).parent().parent().children().eq(0).text();
                    var interventionId = $(this).parent().parent().children().eq(2).attr('id');
                    var eye = $(this).parent().parent().children().eq(3).text();
                    var date = $(this).parent().parent().children().eq(4).text();

                    $("#SelectedEye").val(eye);
                    $("#SelectedIntervention").val(interventionId);
                    $("#dateSelected").val(date);
                    s.intervEventId.text(id);
                    
                });
            },

            bindDelete: function()
            {
                $('.delete').on('click', function () {
                    var id = $(this).parent().parent().children(':first-child').text();
                    s.intervEventId.text(id);
                });

                $('#btnDeleteYes').on('click', function () {

                    var data = { id: s.intervEventId.text() };
                    a.deleteIntervention(data);

                });
            },

            bindButtons: function(){

                s.btnFilt.on('click', function () {
                    
                    var _data = {
                        patientId: $("#Patient").val(),
                        eye: $("#eyeFilter").val(),
                        initialDate: $("#startFilter").val(),
                        finalDate: $("#endFilter").val()
                    };

                    a.getOSITrendline(_data);

                });

                s.btnAddIntPat.on('click', function(){

                    $("#SelectedEye option:eq(0)").attr('selected', true)
                    $("#SelectedIntervention option:eq(0)").attr('selected', true);
                    $("#dateSelected").val("");
                    s.intervEventId.text("");

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

            b.bindInitialFilters();
            b.bindDatePicker();
            b.bindSave();
            b.bindEdits();
            b.bindDelete();
            b.bindButtons();
            
        }

    }

$(function () {
    OSITrendline.init();
});
