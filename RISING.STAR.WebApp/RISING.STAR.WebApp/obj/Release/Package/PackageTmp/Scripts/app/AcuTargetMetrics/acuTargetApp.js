var s,
    u,
    h,
    m,
    b,
    AcuTarget = {
        
        settings: {
            
            // OSI
            tblOSI: $('#tblOSI'),
            txtOsiOD: $("#txtOSIOD"),
            txtOsiODDate: $("#txtOSIODDate"),
            txtOsiOS: $("#txtOSIOS"),
            txtOsiOSDate: $("#txtOSIOSDate"),

            // PseudoAccomodation
            tblPseudoAcc: $('#tblPseudoAcc'),
            txtPseudoAccOD: $("#txtPseudoAccOD"),
            txtPseudoAccODDate :$("#txtPseudoAccODDate"),
            txtPseudoAccOS: $("#txtPseudoAccOS"),
            txtPseudoAccOSDate: $("#txtPseudoAccOSDate"),
            
            // Tear film
            tblTearFilmOSI: $('#tblTearFilmOSI'),
            txtTearFilmOSIOD: $("#txtTearFilmOSIOD"),
            txtTearFilmStDevOD: $("#txtTearFilmStDevOD"),
            txtTearFilmOSIODDate: $("#txtTearFilmOSIODDate"),
            txtTearFilmOSIOS: $("#txtTearFilmOSIOS"),
            txtTearFilmStDevOS: $("#txtTearFilmStDevOS"),
            txtTearFilmOSIOSDate: $("#txtTearFilmOSIOSDate"),
            
            // Purkinje vs Pupil
            tblPurkVsPupil: $('#tblPurkVsPupil'),
            txtCoordOD: $("#txtCoordOD"),
            txtAngleOD: $("#txtAngleOD"),
            txtXOD: $("#txtXOD"),
            txtYOD: $("#txtYOD"),
            txtPurkODDate: $("#txtPurkODDate"),
            txtCoordOS: $("#txtCoordOS"),
            txtAngleOS: $("#txtAngleOS"),
            txtXOS: $("#txtXOS"),
            txtYOS: $("#txtYOS"),
            txtPurkOSDate: $("#txtPurkOSDate"),
            
            // Inlay vs Purkinke
            tblInlayVsPurk: $('#tblInlayVsPurk'),
            txtInlayVsPurkXOD: $("#txtInlayVsPurkXOD"),
            txtInlayVsPurkYOD: $("#txtInlayVsPurkYOD"),
            txtInlayVsPurkODDate: $("#txtInlayVsPurkODDate"),
            txtInlayVsPurkXOS: $("#txtInlayVsPurkXOS"),
            txtInlayVsPurkYOS: $("#txtInlayVsPurkYOS"),
            txtInlayVsPurkOSDate: $("#txtInlayVsPurkOSDate"),


            // Target Inlay vs Purkinje
            txtTargetInlayVsPurkCoordOD:$("#txtTargetInlayVsPurkCoordOD"),
            txtTargetInlayVsPurkAngleOD:$("#txtTargetInlayVsPurkAngleOD"),
            txtTargetInlayVsPurkXOD:$("#txtTargetInlayVsPurkXOD"),
            txtTargetInlayVsPurkYOD:$("#txtTargetInlayVsPurkYOD"),
            txtTargetInlayVsPurkODDate:$("#txtTargetInlayVsPurkODDate"),
            
            txtTargetInlayVsPurkCoordOS:$("#txtTargetInlayVsPurkCoordOS"),
            txtTargetInlayVsPurkAngleOS:$("#txtTargetInlayVsPurkAngleOS"),
            txtTargetInlayVsPurkXOS:$("#txtTargetInlayVsPurkXOS"),
            txtTargetInlayVsPurkYOS:$("#txtTargetInlayVsPurkYOS"),
            txtTargetInlayVsPurkOSDate: $("#txtTargetInlayVsPurkOSDate"),
            
            
            // MAB            
            txtAchievMABCoordOD:$("#txtAchievMABCoordOD"),
            txtAchievMABAngleOD:$("#txtAchievMABAngleOD"),
            txtAchievMABXOD:$("#txtAchievMABXOD"),
            txtAchievMABYOD:$("#txtAchievMABYOD"),
            txtAchievMABDate:$("#txtAchievMABDate"),
            
            txtAchievMABCoordOS:$("#txtAchievMABCoordOS"),
            txtAchievMABAngleOS:$("#txtAchievMABAngleOS"),
            txtAchievMABXOS:$("#txtAchievMABXOS"),
            txtAchievMABYOS:$("#txtAchievMABYOS"),
            txtAchievMABOSDate:$("#txtAchievMABOSDate"),
            
            // Achieved Inlay vs Purkinje            
            txtAchievPurkCoordOD:$("#txtAchievPurkCoordOD"),
            txtAchievPurkAngleOD:$("#txtAchievPurkAngleOD"),
            txtAchievPurkXOD:$("#txtAchievPurkXOD"),
            txtAchievPurkYOD:$("#txtAchievPurkYOD"),
            txtAchievPurkDate:$("#txtAchievPurkDate"),
            
            txtAchievPurkCoordOS:$("#txtAchievPurkCoordOS"),
            txtAchievPurkAngleOS:$("#txtAchievPurkAngleOS"),
            txtAchievPurkXOS:$("#txtAchievPurkXOS"),
            txtAchievPurkYOS:$("#txtAchievPurkYOS"),
            txtAchievPurkOSDate: $("#txtAchievPurkOSDate"),

        },
    
        url: {
            
            osiUrl: 'AcuTargetMetrics/GetOSIs?patientId=',
            pseudoAccUrl: 'AcuTargetMetrics/GetPseudoAccomodation?patientId=',
            tearFilmUrl: 'AcuTargetMetrics/GetTearFilmOSI?patientId=',
            purkVsPupUrl: 'AcuTargetMetrics/GetPurkinjeVsPupil?patientId=',
            inlayVsPurkUrl: 'AcuTargetMetrics/GetInlayVsPurkinje?patientId='
            
        },

        helper: {

        },

        math: {
            
            vars: {

                targetXOD: 0,
                targetYOD: 0,

                targetXOS: 0,
                targetYOS: 0
            },

            // OD: 
            calculateInlayVsPurkinjeTargetOD: function () {
                     

                if (parseInt(s.txtCoordOD.val()) >= 300)
                {
                    // X, Y
                    var x = (parseInt(s.txtXOD.val()) / 2) * (-1);
                    s.txtTargetInlayVsPurkXOD.val(x);

                    var y = (parseInt(s.txtYOD.val()) / 2) * (-1);
                    s.txtTargetInlayVsPurkYOD.val(y);

                    // Cords
                    var sq = Math.round((Math.sqrt((Math.pow(s.txtXOD.val(), 2) + Math.pow(s.txtYOD.val(), 2)))) / 2);
                    s.txtTargetInlayVsPurkCoordOD.val(sq);

                    // Angle
                    s.txtTargetInlayVsPurkAngleOD.val(s.txtAngleOD.val());

                    // Date
                    s.txtTargetInlayVsPurkODDate.val(s.txtPurkODDate.val());

                    this.vars.targetXOD = x;
                    this.vars.targetYOD = y;
                }
                else
                {
                    
                    // x, y
                    s.txtTargetInlayVsPurkXOD.val(0);
                    s.txtTargetInlayVsPurkYOD.val(0);

                    // Cords
                    s.txtTargetInlayVsPurkCoordOD.val(0);

                    // Angle
                    s.txtTargetInlayVsPurkAngleOD.val(0);

                    // Date
                    s.txtTargetInlayVsPurkODDate.val("");

                    this.vars.targetXOD = 0;
                    this.vars.targetYOD = 0;
                }

            },

            calculateMABOD: function () {
                
                // Coords
                var xCoords = Math.round(
                                    Math.sqrt(Math.pow((s.txtInlayVsPurkXOD.val() - this.vars.targetXOD), 2) +
                                              Math.pow((s.txtInlayVsPurkYOD.val() - this.vars.targetYOD), 2)));

                s.txtAchievMABCoordOD.val(xCoords);

                // X, Y
                s.txtAchievMABXOD.val(parseInt(s.txtInlayVsPurkXOD.val()) - parseInt(this.vars.targetXOD));
                s.txtAchievMABYOD.val(parseInt(s.txtInlayVsPurkYOD.val()) - parseInt(this.vars.targetYOD));

                if (s.txtAchievMABXOD.val() == 0) {
                    s.txtAchievMABAngleOD.val(0);
                }else {
                    var angle = Math.round(Math.atan(s.txtAchievMABYOD.val() / s.txtAchievMABXOD.val()) * (360 / (2 * Math.PI)));
                    s.txtAchievMABAngleOD.val(angle);
                }

                // Date
                s.txtAchievMABDate.val(s.txtInlayVsPurkODDate.val());
                

            },

            calculateInlayVsPurkinjeAchievedOD: function () {
                
                // Coords
                var sq = Math.round(Math.sqrt(Math.pow(s.txtInlayVsPurkXOD.val(), 2) +
                                    Math.pow(s.txtInlayVsPurkYOD.val(), 2)));

                s.txtAchievPurkCoordOD.val(sq);

                // X, Y
                s.txtAchievPurkXOD.val(s.txtInlayVsPurkXOD.val());
                s.txtAchievPurkYOD.val(s.txtInlayVsPurkYOD.val());

                // Angle
                if (s.txtInlayVsPurkXOD.val() || s.txtInlayVsPurkXOD.val() == 0) {
                    s.txtAchievPurkAngleOD.val(0);
                } else {

                    var angle = Math.round(Math.atan(s.txtInlayVsPurkYOD.val() / s.txtInlayVsPurkXOD.val()) * (360 / (2 * Math.PI)));
                    s.txtAchievPurkAngleOD.val(angle);
                }

                // Date
                s.txtAchievPurkDate.val(s.txtInlayVsPurkODDate.val());

            },

            // OS
            calculateInlayVsPurkinjeTargetOS: function () {

                if (parseInt(s.txtCoordOS.val()) >= 300) {
                    // X, Y
                    var x = (parseInt(s.txtXOS.val()) / 2);
                    s.txtTargetInlayVsPurkXOS.val(x);

                    var y = (parseInt(s.txtYOS.val()) / 2);
                    s.txtTargetInlayVsPurkYOS.val(y);

                    // Cords
                    var sq = Math.round((Math.sqrt((Math.pow(s.txtXOS.val(), 2) + Math.pow(s.txtYOS.val(), 2)))) / 2);
                    s.txtTargetInlayVsPurkCoordOS.val(sq);

                    // Angle
                    s.txtTargetInlayVsPurkAngleOS.val(s.txtAngleOS.val());

                    // Date
                    s.txtTargetInlayVsPurkOSDate.val(s.txtPurkOSDate.val());

                    this.vars.targetXOS = x;
                    this.vars.targetYOS = y;

                }
                else
                {
                    // X, Y
                    s.txtTargetInlayVsPurkXOS.val(0);
                    s.txtTargetInlayVsPurkYOS.val(0);

                    // Cords
                    s.txtTargetInlayVsPurkCoordOS.val(0);

                    // Angle
                    s.txtTargetInlayVsPurkAngleOS.val(0);

                    // Date
                    s.txtTargetInlayVsPurkOSDate.val(0);

                    this.vars.targetXOS = 0;
                    this.vars.targetYOS = 0;
                }
            },

            calculateMABOS: function () {

                // Coords
                var xCoords = Math.round(
                                    Math.sqrt(Math.pow((s.txtInlayVsPurkXOS.val() - this.vars.targetXOS), 2) +
                                              Math.pow((s.txtInlayVsPurkYOS.val() - this.vars.targetYOS), 2)));

                s.txtAchievMABCoordOS.val(xCoords);

                // X, Y
                s.txtAchievMABXOS.val(parseInt(s.txtInlayVsPurkXOS.val()) - parseInt(this.vars.targetXOS));
                s.txtAchievMABYOS.val(parseInt(s.txtInlayVsPurkYOS.val()) - parseInt(this.vars.targetYOS));

                if (s.txtAchievMABXOS.val() == 0) {
                    s.txtAchievMABAngleOS.val(0);
                } else {
                    var angle = Math.round(Math.atan(s.txtAchievMABYOS.val() / s.txtAchievMABXOS.val()) * (360 / (2 * Math.PI)));
                    s.txtAchievMABAngleOS.val(angle);
                }

                // Date
                s.txtAchievMABOSDate.val(s.txtInlayVsPurkOSDate.val());

            },

            calculateInlayVsPurkinjeAchievedOS: function () {

                // Coords
                var sq = Math.round(Math.sqrt(Math.pow(s.txtInlayVsPurkXOS.val(), 2) +
                                    Math.pow(s.txtInlayVsPurkYOS.val(), 2)));

                s.txtAchievPurkCoordOS.val(sq);

                // X, Y
                s.txtAchievPurkXOS.val(s.txtInlayVsPurkXOS.val());
                s.txtAchievPurkYOS.val(s.txtInlayVsPurkYOS.val());

                // Angle
                if (s.txtInlayVsPurkXOS.val() || s.txtInlayVsPurkXOS.val() == 0) {
                    s.txtAchievPurkAngleOS.val(0);
                } else {

                    var angle = Math.round(Math.atan(s.txtInlayVsPurkYOS.val() / s.txtInlayVsPurkXOS.val()) * (360 / (2 * Math.PI)));
                    s.txtAchievPurkAngleOS.val(angle);
                }

                // Date
                s.txtAchievPurkOSDate.val(s.txtInlayVsPurkOSDate.val());
                
            }

        },

        binder: {

            bindGraphGenerates: function ()
            {

                var patientId = $("#Patient").val();
                var name = $("#Patient option:selected").text();

                $("#InlayVsPurkGraphOD").on('click', function () {

                    // TODO: the rest and also get the real thing
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - MAB Position");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtTargetInlayVsPurkCoordOD").val());
                    this.href = this.href.replace("__angle__", $("#txtTargetInlayVsPurkAngleOD").val());
                    this.href = this.href.replace("__x__", $("#txtTargetInlayVsPurkXOD").val());
                    this.href = this.href.replace("__y__", $("#txtTargetInlayVsPurkYOD").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOD").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOD").val());
                    this.href = this.href.replace("__type__", 1);
                    this.href = this.href.replace("__eye__", "OD");

                    console.log(this.href);

                });

                $("#InlayVsPurkGraphOS").on('click', function () {
                    
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - MAB Position");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtTargetInlayVsPurkCoordOS").val());
                    this.href = this.href.replace("__angle__", $("#txtTargetInlayVsPurkAngleOS").val());
                    this.href = this.href.replace("__x__", $("#txtTargetInlayVsPurkXOS").val());
                    this.href = this.href.replace("__y__", $("#txtTargetInlayVsPurkYOS").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOS").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOS").val());
                    this.href = this.href.replace("__type__", 2);
                    this.href = this.href.replace("__eye__", "OS");

                });

                $("#MABOD").on('click', function () {
                    
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - MAB Position");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtAchievMABCoordOD").val());
                    this.href = this.href.replace("__angle__", $("#txtAchievMABAngleOD").val());
                    this.href = this.href.replace("__x__", $("#txtAchievMABXOD").val());
                    this.href = this.href.replace("__y__", $("#txtAchievMABYOD").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOD").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOD").val());
                    this.href = this.href.replace("__type__", 3);
                    this.href = this.href.replace("__eye__", "OD");

                });
                
                $("#MABOS").on('click', function () {
                    
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - MAB Position");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtAchievMABCoordOS").val());
                    this.href = this.href.replace("__angle__", $("#txtAchievMABAngleOS").val());
                    this.href = this.href.replace("__x__", $("#txtAchievMABXOS").val());
                    this.href = this.href.replace("__y__", $("#txtAchievMABYOS").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOS").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOS").val());
                    this.href = this.href.replace("__type__", 4);
                    this.href = this.href.replace("__eye__", "OS");

                });
                
                $("#PurkinjeTargetOD").on('click', function () {
                    
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - Purkinje Image");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtAchievPurkCoordOD").val());
                    this.href = this.href.replace("__angle__", $("#txtAchievPurkAngleOD").val());
                    this.href = this.href.replace("__x__", $("#txtAchievPurkXOD").val());
                    this.href = this.href.replace("__y__", $("#txtAchievPurkYOD").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOS").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOS").val());
                    this.href = this.href.replace("__type__", 5);
                    this.href = this.href.replace("__eye__", "OD");

                });
                
                $("#PurkinjeTargetOS").on('click', function () {
                    
                    this.href = this.href.replace("__ids__", patientId);
                    this.href = this.href.replace("__name__", name);
                    this.href = this.href.replace("__exam__", "Target - Purkinje Image");
                    this.href = this.href.replace("__section__", "???");
                    this.href = this.href.replace("__cords__", $("#txtAchievPurkCoordOS").val());
                    this.href = this.href.replace("__angle__", $("#txtAchievPurkAngleOS").val());
                    this.href = this.href.replace("__x__", $("#txtAchievPurkXOS").val());
                    this.href = this.href.replace("__y__", $("#txtAchievPurkYOS").val());
                    this.href = this.href.replace("__purkX__", $("#txtTargetInlayVsPurkXOS").val());
                    this.href = this.href.replace("__purkY__", $("#txtTargetInlayVsPurkYOS").val());
                    this.href = this.href.replace("__type__", 6);
                    this.href = this.href.replace("__eye__", "OS");

                });


            },

            bindCalc: function () {
                
                $("#btnCalculate").on('click', function () {
                    m.calculateInlayVsPurkinjeTargetOD();
                    m.calculateMABOD();
                    m.calculateInlayVsPurkinjeAchievedOD();
                    m.calculateInlayVsPurkinjeTargetOS();
                    m.calculateMABOS();
                    m.calculateInlayVsPurkinjeAchievedOS();
                });

            }

        },

        init: function()
        {

            s = this.settings;
            u = this.url;
            h = this.helper;
            m = this.math;
            b = this.binder;

            var patientId = $("#Patient").val();

            this.retrieveOSI(patientId);
            this.retrievePseudoAcc(patientId);
            this.retrieveTearFilmOSI(patientId);
            this.retrievePurkinjeVsPupils(patientId);
            this.retrieveInlayVsPurkinje(patientId);

            b.bindGraphGenerates();

            b.bindCalc();

   
        },

        retrieveOSI: function(patId)
        {

            $.ajax({
                type: "POST",
                url: u.osiUrl+patId,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (data, textStatus, jqXHR) {

                if ($.isArray(data)) {
                    $.each(data, function (i, v) {
                        s.tblOSI.append($('<tr>')
                                        .append($('<td>')
                                            .text(v.AcqId)
                                            .css('display', 'none'))
                                        .append($('<td>')
                                            .text(v.ExamDate))
                                        .append($('<td>')
                                            .text(v.ExamTime))
                                        .append($('<td>')
                                            .text(v.ExamEye))
                                        .append($('<td>')
                                            .text(v.OSI))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .attr('id', v.AcqId)
                                                .text('Use')
                                                .addClass('btn')
                                                .addClass('btn-primary'))
                                                .on('click', function () {
                                                    if(v.ExamEye == 'OD')
                                                    {
                                                        s.txtOsiOD.val(v.OSI);
                                                        s.txtOsiODDate.val(v.ExamDate);
                                                    }
                                                    else
                                                    {
                                                        s.txtOsiOS.val(v.OSI);
                                                        s.txtOsiOSDate.val(v.ExamDate);
                                                    }
                                                }))
                                    );
                    });
                }
                else {
                    // TODO: if its only one
                }
            }).always(function (data, textStatus, jqXHR) {

            }).fail(function (jqXHR, textStatus, errorThrown) {

            });

        },

        retrievePseudoAcc: function (patId) {

            $.ajax({
                type: "POST",
                url: u.pseudoAccUrl + patId,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (data, textStatus, jqXHR) {

                if ($.isArray(data)) {
                    $.each(data, function (i, v) {

                        s.tblPseudoAcc.append($('<tr>')
                                        .append($('<td>')
                                            .text(v.AcqId)
                                            .css('display', 'none'))
                                        .append($('<td>')
                                            .text(v.ExamDate))
                                        .append($('<td>')
                                            .text(v.ExamTime))
                                        .append($('<td>')
                                            .text(v.ExamEye))
                                        .append($('<td>')
                                            .text(v.OAR))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .attr('id', v.AcqId)
                                                .text('Use')
                                                .addClass('btn')
                                                .addClass('btn-primary'))
                                                .on('click', function () {
                                                    if (v.ExamEye == 'OD') {
                                                        s.txtPseudoAccOD.val(v.OAR);
                                                        s.txtPseudoAccODDate.val(v.ExamDate);
                                                    }
                                                    else {
                                                        s.txtPseudoAccOS.val(v.OAR);
                                                        s.txtPseudoAccOSDate.val(v.ExamDate);
                                                    }
                                                }))
                                    );
                    });
                }
                else {
                    // TODO: if its only one
                }
            }).always(function (data, textStatus, jqXHR) {

            }).fail(function (jqXHR, textStatus, errorThrown) {

            });

        },

        retrieveTearFilmOSI: function (patId) {

            $.ajax({
                type: "POST",
                url: u.tearFilmUrl + patId,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (data, textStatus, jqXHR) {

                if ($.isArray(data)) {
                    $.each(data, function (i, v) {

                        s.tblTearFilmOSI.append($('<tr>')
                                        .append($('<td>')
                                            .text(v.AcqId)
                                            .css('display', 'none'))
                                        .append($('<td>')
                                            .text(v.ExamDate))
                                        .append($('<td>')
                                            .text(v.ExamTime))
                                        .append($('<td>')
                                            .text(v.ExamEye))
                                        .append($('<td>')
                                            .text(v.OSI))
                                        .append($('<td>')
                                            .text(v.StDev))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .attr('id', v.AcqId)
                                                .text('Use')
                                                .addClass('btn')
                                                .addClass('btn-primary'))
                                                .on('click', function () {
                                                    if (v.ExamEye == 'OD') {
                                                        s.txtTearFilmOSIOD.val(v.OSI);
                                                        s.txtTearFilmStDevOD.val(v.StDev);
                                                        s.txtTearFilmOSIODDate.val(v.ExamDate);
                                                    }
                                                    else {
                                                        s.txtTearFilmOSIOS.val(v.OSI);
                                                        s.txtTearFilmStDevOS.val(v.StDev);
                                                        s.txtTearFilmOSIOSDate.val(v.ExamDate);
                                                    }
                                                }))
                                    );
                    });
                }
                else {
                    // TODO: if its only one
                }
            }).always(function (data, textStatus, jqXHR) {

            }).fail(function (jqXHR, textStatus, errorThrown) {

            });

        },

        retrievePurkinjeVsPupils: function (patId) {

            $.ajax({
                type: "POST",
                url: u.purkVsPupUrl + patId,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (data, textStatus, jqXHR) {

                if ($.isArray(data)) {
                    $.each(data, function (i, v) {

                        s.tblPurkVsPupil.append($('<tr>')
                                        .append($('<td>')
                                            .text(v.AcqId)
                                            .css('display', 'none'))
                                        .append($('<td>')
                                            .text(v.ExamDate))
                                        .append($('<td>')
                                            .text(v.ExamTime))
                                        .append($('<td>')
                                            .text(v.ExamEye))
                                        .append($('<td>')
                                            .text(v.Coord))
                                        .append($('<td>')
                                            .text(v.Angle))
                                        .append($('<td>')
                                            .text(v.X))
                                        .append($('<td>')
                                            .text(v.Y))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .attr('id', v.AcqId)
                                                .text('Use')
                                                .addClass('btn')
                                                .addClass('btn-primary'))
                                                .on('click', function () {
                                                    if (v.ExamEye == 'OD') {
                                                        s.txtCoordOD.val(v.Coord);
                                                        s.txtAngleOD.val(v.Angle);
                                                        s.txtXOD.val(v.X);
                                                        s.txtYOD.val(v.Y);
                                                        s.txtPurkODDate.val(v.ExamDate);
                                                    }
                                                    else {
                                                        s.txtCoordOS.val(v.Coord);
                                                        s.txtAngleOS.val(v.Angle);
                                                        s.txtXOS.val(v.X);
                                                        s.txtYOS.val(v.Y);
                                                        s.txtPurkOSDate.val(v.ExamDate);
                                                    }
                                                }))
                                    );
                    });
                }
                else {
                    // TODO: if its only one
                }
            }).always(function (data, textStatus, jqXHR) {

            }).fail(function (jqXHR, textStatus, errorThrown) {

            });

        },

        retrieveInlayVsPurkinje: function (patId) {

            $.ajax({
                type: "POST",
                url: u.inlayVsPurkUrl + patId,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (data, textStatus, jqXHR) {

                if ($.isArray(data)) {
                    $.each(data, function (i, v) {

                        s.tblInlayVsPurk.append($('<tr>')
                                        .append($('<td>')
                                            .text(v.AcqId)
                                            .css('display', 'none'))
                                        .append($('<td>')
                                            .text(v.ExamDate))
                                        .append($('<td>')
                                            .text(v.ExamTime))
                                        .append($('<td>')
                                            .text(v.ExamEye))
                                        .append($('<td>')
                                            .text(v.X))
                                        .append($('<td>')
                                            .text(v.Y))
                                        .append($('<td>')
                                            .append($('<button>')
                                                .attr('id', v.AcqId)
                                                .text('Use')
                                                .addClass('btn')
                                                .addClass('btn-primary'))
                                                .on('click', function () {
                                                    if (v.ExamEye == 'OD') {
                                                        s.txtInlayVsPurkXOD.val(v.X);
                                                        s.txtInlayVsPurkYOD.val(v.Y);
                                                        s.txtInlayVsPurkODDate.val(v.ExamDate);
                                                    }
                                                    else {
                                                        s.txtInlayVsPurkXOS.val(v.X);
                                                        s.txtInlayVsPurkYOS.val(v.Y);
                                                        s.txtInlayVsPurkOSDate.val(v.ExamDate);
                                                    }
                                                }))
                                    );
                    });
                }
                else {
                    // TODO: if its only one
                }
            }).always(function (data, textStatus, jqXHR) {

            }).fail(function (jqXHR, textStatus, errorThrown) {

            });

        }

    }

$(function () {
    AcuTarget.init();
});
