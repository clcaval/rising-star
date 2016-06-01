var s,
    g,
    h,
    b,
    m,
    AcuTargetGraph = {
        
        settings: {

            svg: document.getElementById('mySvg'),
            kamraInner: $("#kamraInner"),
            docInfo: $("#docInfo"),

            centerX: 300,
            centerY: 300,
            
            targetInlayVsPurkinje: "<p>The center of the KAMRA inlay is to be located __diffcordOD__ microns __strCord__ to the Purkinje image.</p>" +
                                        "<p>In order to be in perfect position the center of the KAMRA inlay should be __dblMoveX__ __strMoveX__ __dblMoveY__ __strMoveY__ to the Purkinje.</p>",
            
            achievedMAB: "<p>The center of the KAMRA inlay is located __diffcordOD__ microns __strCord__ to the MAB target position.</p>" +
                                "<p>__position__</p>" +
                                "<p>In order to be in perfect position you need to move the inlay __dblMoveX__ __strMoveX__ __dblMoveY__ __strMoveY__.</p>",
            
            strKAMRAPosPurk: "<p>The center of the KAMRA inlay is located __diffcordOD__ microns __strCord__ to the Purkinje image.</p>" +
                                "<p>__position__</p>" +
                                "<p>In order to be in perfect position you need to move the inlay __dblMoveX__ __strMoveX__ __dblMoveY__ __strMoveY__</p>",

            perfectPos: "The inlay is in perfect position.  We do not recommend repositioning the inlay.",
            goodPos: "The inlay is in good position.  We do not recommend repositioning the inlay.",
            fairPos: "The inlay is in fair position.  It would be best to try repositioning the inlay.",
            poorPos: "The inlay is in poor position.  It would be best to try repositioning the inlay.",
            notAccepPos: "The inlay is not in an acceptable position.  You must reposition the inlay to obtain a good visual result."

        },

        messaging: {

            retrieveTopText: function (x, y, eye, type) {

                var strResponse = "";
                var cord = parseInt($("#txtCoord").val());
                console.log(type);
                if (type == 1 || type == 2) {
                    strResponse = s.targetInlayVsPurkinje;
                    strResponse = strResponse.replace('__position__', '');
                } else if (type == 3 || type == 4) {
                    strResponse = s.achievedMAB;
                } else{
                    strResponse = s.strKAMRAPosPurk;
                }

                var moveX = h.parseIntAndAbs($("#txtX").val());
                var moveY = h.parseIntAndAbs($("#txtY").val());

                strResponse = strResponse.replace('__diffcordOD__', $("#txtCoord").val());
                strResponse = strResponse.replace('__dblMoveX__', moveX == 0 ? '' : moveX);
                strResponse = strResponse.replace('__dblMoveY__', moveY == 0 ? '' : moveY);
                $("#positionId").remove();
                
                if (cord <= 50)
                    strResponse = strResponse.replace('__position__', s.perfectPos);
                else if (cord > 50 && cord <= 100)
                    strResponse = strResponse.replace('__position__', s.goodPos);
                else if (cord > 100 && cord <= 150)
                    strResponse = strResponse.replace('__position__', s.fairPos);
                else if (cord > 150 && cord <= 200)
                    strResponse = strResponse.replace('__position__', s.poorPos);
                else if (cord > 200)
                    strResponse = strResponse.replace('__position__', s.notAccepPos);
                else
                    strResponse = strResponse.replace('__position__', '');
                
                if (eye == "OD")
                {

                    if(x < 0 && y > 0){
                        strResponse = strResponse.replace('__strCord__', 'superonasal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns nasal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540,     'Superotemporal', 'positionId');
                    }
                    else if (x < 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferonasal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns nasal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior ');
                        g.makeAndAppendPosition(6, 540, 'Inferonasal', 'positionId');
                    }
                    else if(x > 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferotemporal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns temporal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior ');
                        g.makeAndAppendPosition(6, 540, 'Inferotemporal', 'positionId');
                    }
                    else if (x > 0 && y > 0) {
                        strResponse = strResponse.replace('__strCord__', 'superotemporal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns temporal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540, 'Superotemporal', 'positionId');                                                
                    }
                    else if(x == 0 && y  > 0){
                        strResponse = strResponse.replace('__strCord__', 'superior');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540, 'Superior', 'positionId');
                    }
                    else if(x == 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferior');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior');
                        g.makeAndAppendPosition(6, 540, 'Inferior', 'positionId');
                    }                    
                    else if (x > 0 && y == 0){
                        strResponse = strResponse.replace('__strCord__', 'temporal');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns temporal');
                        g.makeAndAppendPosition(6, 540, 'Temporal', 'positionId');
                    }
                    else if (x < 0 && y == 0) {
                        strResponse = strResponse.replace('__strCord__', 'nasal');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns nasal');
                        g.makeAndAppendPosition(6, 540, 'Nasal', 'positionId');
                    }
                    
                }
                else
                {

                    if(x < 0 && y > 0){
                        strResponse = strResponse.replace('__strCord__', 'superotemporal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns temporal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior ');
                        g.makeAndAppendPosition(6, 540,     'Superotemporal', 'positionId');
                    }
                    else if (x < 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferonasal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns temporal  and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540, 'Inferonasal', 'positionId');
                    }
                    else if(x > 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferotemporal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns nasal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540, 'Inferotemporal', 'positionId');
                    }
                    else if (x > 0 && y > 0) {
                        strResponse = strResponse.replace('__strCord__', 'inferonasal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns nasal and ');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior ');
                        g.makeAndAppendPosition(6, 540, 'Inferonasal', 'positionId');                                                
                    }
                    else if(x == 0 && y > 0){
                        strResponse = strResponse.replace('__strCord__', 'superior');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns superior ');
                        g.makeAndAppendPosition(6, 540, 'Superior', 'positionId');
                    }
                    else if(x == 0 && y < 0){
                        strResponse = strResponse.replace('__strCord__', 'inferior');
                        strResponse = strResponse.replace('__strMoveX__', '');
                        strResponse = strResponse.replace('__strMoveY__', ' microns inferior');
                        g.makeAndAppendPosition(6, 540, 'Inferior', 'positionId');
                    }                    
                    else if (x > 0 && y == 0){
                        strResponse = strResponse.replace('__strCord__', 'nasal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns nasal ');
                        strResponse = strResponse.replace('__strMoveY__', '');
                        g.makeAndAppendPosition(6, 540, 'Nasal', 'positionId');
                    }
                    else if (x < 0 && y == 0) {
                        strResponse = strResponse.replace('__strCord__', 'temporal');
                        strResponse = strResponse.replace('__strMoveX__', ' microns temporal ');
                        strResponse = strResponse.replace('__strMoveY__', ' ');
                        g.makeAndAppendPosition(6, 540, 'Temporal', 'positionId');
                    }

                }

                return strResponse;
            }

        },

        graph: {

            makeInlayCenter: function () {

                $("#inlayCenter").remove();

                var inner = $("#targetInlayInner");
                var x = inner.attr('cx');
                var y = inner.attr('cy');

                h.makeRect(parseInt(x)-4, parseInt(y)-4, 'green', 'inlayCenter');
            },

            makeKAMRAInlay: function (x, y) {

                $("#kamraInner").remove();
                $("#kamraOuter").remove();
                
                var innerCircle = h.makeCircle(x, y, 80, 'black', 'grey', 'kamraInner');
                var outerCircle = h.makeCircle(x, y, 200, 'url(#image)', 'grey', 'kamraOuter');

                s.svg.appendChild(outerCircle);
                s.svg.appendChild(innerCircle);

            },
            
            makePurkinjeTarget: function (x, y) {                
                $("#idTarget").remove();
                var target = h.makeSVG('circle', { cx: x, cy: y, r: 4, 'stroke-width': 2, fill: 'red', id: 'idTarget' });
                s.svg.appendChild(target);
            },

            makeInlayCenterTarget: function () {

                $("#idInlayCenterTarget").remove();

                var inner = $("#kamraInner");
                var x = inner.attr('cx');
                var y = inner.attr('cy');

                $("#idInlayCenterTarget").remove();
                var target = h.makeSVG('circle', { cx: x, cy: y, r: 4, 'stroke-width': 2, fill: 'teal', id: 'idInlayCenterTarget' });
                s.svg.appendChild(target);
                
            },
                        
            makePupilCenter: function (x, y) {

                $("#pupilCenterLine1").remove();
                $("#pupilCenterLine2").remove();
                                
                var newX1 = x - 10;
                var newX2 = x + 10;
                var newY1 = y - 10;
                var newY2 = y + 10;
                
                console.log(x, y);

                var line1 = h.makeLine(newX1, newY1, newX2, newY1, 'pupilCenterLine1');
                var line2 = h.makeLine(x, y - 20, x, y, 'pupilCenterLine2');

                s.svg.appendChild(line1);
                s.svg.appendChild(line2);

            },

            makeTargetInlay: function () {

                $("#targetInlayInner").remove();
                $("#targetInlayOuter").remove();

                var innerCircle = h.makeCircle(s.centerX, s.centerY, 80, 'transparent', '#00ccff', 'targetInlayInner');
                var outerCircle = h.makeCircle(s.centerX, s.centerY, 200, 'transparent', '#00ccff', 'targetInlayOuter');
                
                s.svg.appendChild(outerCircle);
                s.svg.appendChild(innerCircle);

            },

            makeGrid: function () {
                $("#gridId").remove();
                var grid = h.makeSVG('rect', { width: '100%', height: '100%', fill: 'url(#grid)', id: 'gridId' });
                s.svg.appendChild(grid);
            },

            makeAndAppendPatientId: function (_x, _y, id) {
                var patientId = h.makeText(_x, _y, '12pt', id); 
                var patientIdNode = document.createTextNode('Id: ' + id);
                patientId.appendChild(patientIdNode);
                s.svg.appendChild(patientId);
            },

            makeAndAppendPatientName: function (_x, _y, _patientName) {
                var patientName = h.makeText(_x, _y, '12pt', 'noid'); 
                var patientNode = document.createTextNode(_patientName);
                patientName.appendChild(patientNode);
                s.svg.appendChild(patientName);
            },

            makeAndAppendEye: function(_eye)
            {
                var eye = h.makeText(275, 34, '24pt', 'eyeId');
                var eyeNode = document.createTextNode(_eye);
                eye.appendChild(eyeNode);
                s.svg.appendChild(eye);
            },

            makeAndAppendNasal: function (_x, _y) {
                var nasal = h.makeText(_x, _y, '12pt', 'noid2'); 
                var nasalNode = document.createTextNode('Nasal');
                nasal.appendChild(nasalNode);
                s.svg.appendChild(nasal);
            },

            makeAndAppendTemporal: function (_x, _y) {
                var temporal = h.makeText(_x, _y, '12pt', 'noid3');
                var temporalNode = document.createTextNode('Temporal');
                temporal.appendChild(temporalNode);
                s.svg.appendChild(temporal);
            },

            makeAndAppendExamName: function (_x, _y, _examName) {
                var examName = h.makeText(_x, _y, '14pt', 'noid4'); 
                var examNode = document.createTextNode(_examName);
                examName.appendChild(examNode);
                s.svg.appendChild(examName);
            },

            makeAndAppendCoords: function(_x, _y, _coords, _id)
            {
                var coods = h.makeText(_x, _y, '10pt', _id); 
                var coodsNode = document.createTextNode('Cords: ' + _coords + ' microns');
                coods.appendChild(coodsNode);
                s.svg.appendChild(coods);
            },

            makeAndAppendPosition: function(_x, _y, _position, _positionId)
            {                
                var position = h.makeText(_x, _y, '10pt', _positionId);
                var positionNode = document.createTextNode(_position);
                position.appendChild(positionNode);
                s.svg.appendChild(position);
            },

            makeAndAppendX: function(_x, _y, _xValue, _id)
            {
                var x = h.makeSVG('text', { x: _x, y: _y, 'font-family': 'sans-serif', 'font-size': '10pt', fill: 'white', id: _id });
                var xNode = document.createTextNode('X: ' + Math.abs(_xValue));
                x.appendChild(xNode);
                s.svg.appendChild(x);
            },

            makeAndAppendY: function(_x, _y, _yValue, _id)
            {
                var y = h.makeSVG('text', { x: _x, y: _y, 'font-family': 'sans-serif', 'font-size': '10pt', fill: 'white', id: _id });
                var yNode = document.createTextNode('Y: ' + _yValue);
                y.appendChild(yNode);
                s.svg.appendChild(y);
            },

            makeAndAppendInferiorText: function (_x, _y, _position, _coords, _x1, _y1) {
                
                _x1 = Math.abs(_x1);
                _y1 = Math.abs(_y1);

                $("#positionId").remove();
                this.makeAndAppendPosition(_x, _y, _position, 'positionId');
                _y += 16;

                $("#coodsId").remove();
                this.makeAndAppendCoords(_x, _y, _coords, 'coodsId');
                _y += 16;

                $("#xId").remove();
                this.makeAndAppendX(_x, _y, _x1, 'xId');
                _y += 16;

                $("#yId").remove();
                this.makeAndAppendY(_x, _y, _y1, 'yId');

            },
            
            // Graphics - Pre-op Target Inlay vs Purkinje
            plotTargetInlayVsPurkinjeOD: function ()
            {

                g.makeTargetInlay();
                g.makeInlayCenter();

                var inner = $("#targetInlayInner");
                var x = parseInt(inner.attr('cx')) + Math.round(parseInt($("#txtX").val()) / 10);
                var y = parseInt(inner.attr('cy')) + Math.round((parseInt($("#txtY").val())) / 10);
                
                var pupilX = parseInt(inner.attr('cx')) - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = parseInt(inner.attr('cy')) - Math.round((parseInt($("#txtY").val())) / 10);
                
                g.makePurkinjeTarget(x, y);
                g.makePupilCenter(pupilX, pupilY);
                
                g.makeAndAppendNasal(528, 285);
                g.makeAndAppendTemporal(6, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OD", 1);
                $("#docInfo").html(text);

            },

            plotTargetInlayVsPurkinjeOS: function () {

                g.makeTargetInlay();
                g.makeInlayCenter();

                var inner = $("#targetInlayInner");
                var x = parseInt(inner.attr('cx')) + Math.round(parseInt($("#txtX").val()) / 10);
                var y = parseInt(inner.attr('cy')) + Math.round((parseInt($("#txtY").val()) * (-1)) / 10);

                var pupilX = parseInt(inner.attr('cx')) - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = parseInt(inner.attr('cy')) - Math.round((parseInt($("#txtY").val()) * (-1)) / 10);

                g.makePurkinjeTarget(x, y);
                g.makePupilCenter(pupilX, pupilY);
                
                g.makeAndAppendNasal(6, 285);
                g.makeAndAppendTemporal(528, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OS", 2);
                $("#docInfo").html(text);
                
            },


            // Graphics - Pos-op Target Inlay vs Purkinje MAB
            plotTargetInlayVsPurkMABOD: function () {

                var inner = $("#targetInlayInner");
                var x = s.centerX + (Math.round((parseInt($("#txtX").val()) * (-1))) / 10);
                var y = s.centerY + (Math.round(parseInt($("#txtY").val())) / 10);
                                
                var pupilX = s.centerX - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = s.centerY - Math.round((parseInt($("#txtY").val())) / 10);
                
                var yKamra = s.centerY + ((-1)*(s.centerY - y));

                g.makeKAMRAInlay(x, yKamra);
                g.makeInlayCenterTarget();
                g.makeTargetInlay();
                g.makeInlayCenter();

                var xPurkTarget = s.centerX + parseInt($("#txtPurkinjeX").val()) / 10;
                var yPurkTarget = s.centerY + ((-1) * parseInt($("#txtPurkinjeY").val()) / 10);
               
                g.makePurkinjeTarget(xPurkTarget, yPurkTarget);
                
                g.makeAndAppendNasal(528, 285);
                g.makeAndAppendTemporal(6, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OD", 3);
                $("#docInfo").html(text);
                                
            },

            plotTargetInlayVsPurkMABOS: function () {

                var inner = $("#targetInlayInner");
                var x = s.centerX + (Math.round((parseInt($("#txtX").val()))) / 10);
                var y = s.centerY + (Math.round(parseInt($("#txtY").val())) / 10);

                var pupilX = s.centerX - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = s.centerY - Math.round((parseInt($("#txtY").val())) / 10);

                var xKamra = s.centerX + Math.abs(s.centerX - x);
                var yKamra = s.centerY + ((s.centerY - y));
                console.log(xKamra, yKamra);
                                
                g.makeKAMRAInlay(xKamra, yKamra);
                g.makeInlayCenterTarget(x, y);
                g.makeTargetInlay();
                g.makeInlayCenter();

                var targetPurkinjeX = s.centerX + (parseInt($("#txtPurkinjeX").val()) / 10);
                var targetPurkinjeY = s.centerY + Math.abs((parseInt($("#txtPurkinjeY").val()) / 10));
                g.makePurkinjeTarget(targetPurkinjeX, targetPurkinjeY);

                g.makeAndAppendNasal(6, 285);
                g.makeAndAppendTemporal(528, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OS", 4);
                $("#docInfo").html(text);
                
            },


            // Graphics - Pos-op Target Inlay vs Purkinje MAB
            plotTargetInlayVsPurkinje_PurkinjeOD: function () {

                var inner = $("#targetInlayInner");
                var x = s.centerX + (Math.round((parseInt($("#txtX").val()) * (-1))) / 10);
                var y = s.centerY + (Math.round(parseInt($("#txtY").val())) / 10);

                var pupilX = s.centerX - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = s.centerY - Math.round((parseInt($("#txtY").val())) / 10);

                var yKamra = s.centerY + Math.abs(s.centerY - y);

                g.makeKAMRAInlay(x, yKamra);
                g.makeInlayCenterTarget();
                g.makeTargetInlay();
                g.makeInlayCenter();

                g.makePurkinjeTarget(x, y);
                //g.makePupilCenter(pupilX, pupilY);

                g.makeAndAppendNasal(528, 285);
                g.makeAndAppendTemporal(6, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OD", 5);
                $("#docInfo").html(text);
                
            },

            plotTargetInlayVsPurkinje_PurkinjeOS: function () {

                var inner = $("#targetInlayInner");
                var x = s.centerX + (Math.round((parseInt($("#txtX").val()))) / 10);
                var y = s.centerY + (Math.round(parseInt($("#txtY").val())) / 10);

                var pupilX = s.centerX - Math.round(parseInt($("#txtX").val()) / 10);
                var pupilY = s.centerY - Math.round((parseInt($("#txtY").val())) / 10);

                var xKamra = s.centerX + Math.abs(s.centerX - x);
                var yKamra = s.centerY + ((s.centerY - y));
                console.log(xKamra, yKamra);


                g.makeKAMRAInlay(xKamra, yKamra);
                g.makeInlayCenterTarget(x, y);
                g.makeTargetInlay();
                g.makeInlayCenter();

                var targetPurkinjeX = s.centerX + (parseInt(h.getParameterByName("purkX")) / 10);
                var targetPurkinjeY = s.centerY + Math.abs((parseInt(h.getParameterByName("purkY")) / 10));
                g.makePurkinjeTarget(targetPurkinjeX, targetPurkinjeY);

                g.makeAndAppendNasal(6, 285);
                g.makeAndAppendTemporal(528, 285);

                var text = m.retrieveTopText(parseInt($("#txtX").val()), parseInt($("#txtY").val()), "OS", 6);
                $("#docInfo").html(text);

            },



        },

        helper: {

            makeRect: function (_x, _y, _color, _id) {
                var rect = this.makeSVG('rect', { x: _x, y: _y, width: 8, height: 8, 'stroke-width': 2, fill: _color, id: _id });
                s.svg.appendChild(rect);
            },

            makeCircle: function (_cx, _cy, _r, _fill, _strokeColor, _id) {
                var circle = this.makeSVG('circle', { cx: _cx, cy: _cy, r: _r, fill: _fill, 'stroke-width': 2, stroke: _strokeColor, 'stroke-dasharray': '5,5', id: _id });
                return circle
            },

            makeTriangle: function(x1, y1, x2, y2, x3, y3, _id)
            {
                var tri = this.makeSVG('polygon', { points: x1 + ',' + y1 + ' ' + x2 + ',' + y2 + ' ' + x3 + ',' + y3, id: _id });
                return tri;
            },

            makeLine: function (_x1, _y1, _x2, _y2, _id) {
                var line = this.makeSVG('line', { x1: _x1, y1: _y1, x2: _x2, y2: _y2, 'stroke-width': 2, 'class': 'yellowLine', id: _id });
                return line;
            },
            
            makeText: function (_x, _y, font_size, _id) {
                var text = h.makeSVG('text', { x: _x, y: _y, 'font-family': 'sans-serif', 'font-size': font_size, fill: 'white', id: _id });
                return text;
            },

            makeSVG: function (tag, attrs) {
                var el = document.createElementNS('http://www.w3.org/2000/svg', tag);
                for (var k in attrs)
                    el.setAttribute(k, attrs[k]);
                return el;
            },
            
            getParameterByName: function (name, url) {
                if (!url) url = window.location.href;

                name = name.replace(/[\[\]]/g, "\\$&");
                var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                    results = regex.exec(url);
                if (!results) return null;
                if (!results[2]) return '';
                return decodeURIComponent(results[2].replace(/\+/g, " "));
            },

            selectGraphic: function()
            {

                g.makeAndAppendEye(h.getParameterByName('eye'));
                g.makeAndAppendPatientName(10, 50, h.getParameterByName('name'));
                g.makeAndAppendPatientId(10, 70, h.getParameterByName('ids'));
                g.makeAndAppendExamName(10, 20, h.getParameterByName('exam'));
                g.makeAndAppendInferiorText(6, 540, $("#txtSection").val(), $("#txtCoord").val(), $("#txtX").val(), $("#txtY").val());
                
                switch (parseInt(h.getParameterByName("type"))) {
                    case 1:
                        g.plotTargetInlayVsPurkinjeOD();
                        break;
                    case 2:
                        g.plotTargetInlayVsPurkinjeOS();
                        break;
                    case 3:
                        g.plotTargetInlayVsPurkMABOD();
                        break;
                    case 4:
                        g.plotTargetInlayVsPurkMABOS();
                        break;
                    case 5:
                        g.plotTargetInlayVsPurkinje_PurkinjeOD();
                        break;
                    case 6:
                        g.plotTargetInlayVsPurkinje_PurkinjeOS();
                        break;
                }

                g.makeGrid();

            },

            getPositionFromCord: function(cord)
            {
                var value = parseInt(cord);
                if (value <= 50)
                    return s.perfectPos;
                else if (value > 50 && value <= 100)
                    return s.goodPos;
                else if (value > 101 && value <= 150)
                    return s.fairPos;
                else if (value > 150 && value <= 200)
                    return s.poorPos;
                else if (value > 200)
                    return s.notAccepPos;
            },

            parseIntAndAbs: function (x) {
                return Math.abs(parseInt(x));
            }
            
        },

        binder: {

            bindToSimulator: function () {

                $("#txtPupilCenterX").val(s.centerX);
                $("#txtPupilCenterY").val(s.centerY);

                $("#txtCoord").val(h.getParameterByName('cords'));
                $("#txtAngle").val(h.getParameterByName('angle'));
                $("#txtX").val(h.getParameterByName('x'));
                $("#txtY").val(h.getParameterByName('y'));
                //$("#txtSection").val(h.getParameterByName('section'));

                $("#txtPurkinjeX").val(h.getParameterByName('purkX'));
                $("#txtPurkinjeY").val(h.getParameterByName('purkY'));

            },

            bindPlot: function () {

                $("#btnPlot").on('click', function () {
                    h.selectGraphic();
                });

            },
            
            bindControlEvents: function () {

                $("#btnPupilCenter").on('click', function () {
                    $("#pupilCenterLine1").toggle();
                    $("#pupilCenterLine2").toggle();
                });

                $("#btnTarget").on('click', function () {
                    $("#idTarget").toggle();
                });

                $("#btnInlayCenter").on('click', function () {
                    $("#inlayCenter").toggle();
                });

                $("#btnInlayTarget").on('click', function () {
                    $("#targetInlayOuter").toggle();
                    $("#targetInlayInner").toggle();
                });

                $("#btnKamraInlay").on('click', function () {
                    $("#kamraOuter").toggle();
                    $("#kamraInner").toggle();
                });

            }

        },

        init: function () {           
            
            s = this.settings;
            g = this.graph;
            h = this.helper;
            b = this.binder;
            m = this.messaging;

            b.bindToSimulator();
            b.bindControlEvents();
            b.bindPlot();
            
            h.selectGraphic();

            //g.makeKAMRAInlay();
            //g.makeTargetInlay();
            g.makeGrid();
            //g.makePupilCenter();
            //g.makeInlayCenter();

            //g.makeAndAppendNasal(6, 285);
            //g.makeAndAppendTemporal(500, 285);
            //g.makeAndAppendPatientName(10, 50, h.getParameterByName('name'));
            //g.makeAndAppendPatientId(10, 70, h.getParameterByName('ids'));
            //g.makeAndAppendExamName(10, 20, h.getParameterByName('exam'));
            //g.makeAndAppendInferiorText(6, 540, $("#txtSection").val(), $("#txtCoord").val(), $("#txtX").val(), $("#txtY").val());
            
        }

    }

$(function () {
    AcuTargetGraph.init();
});
