﻿"use strict";

var Drawer = require("./drawer");
var dataUtils = require("./data");
var Dragger = require("./circle_dragger");
var Connector = require("./circle_connector");
var Marker = require("./circle_marker");

var CANVAS_ID = "canvas";

window.onload = function () {
    canvasApp();
};

function isCanvasSupported() {
    var elem = document.createElement('canvas');
    return !!(elem.getContext && elem.getContext('2d'));
}

function canvasApp() {
    window.addEventListener("resize", onResize, false);
    if (!isCanvasSupported()) {
        return;
    }
    $("#canvasSupport").hide();

    $("canvas").on("contextmenu", function () {
        return false;
    });

    var canvas = document.getElementById(CANVAS_ID);
    var ctx = canvas.getContext("2d");

    var playground = {
        width: canvas.width = window.innerWidth,
        height: canvas.height = window.innerHeight,
        centerX: window.innerWidth * .5,
        centerY: (window.innerHeight) * .5
    };

    var drawer = new Drawer(ctx);
    
    var circles = dataUtils.createRandomLocations(playground.width, playground.height, 5);

    var dragger = new Dragger(circles);
    dragger.setHandlers(CANVAS_ID);    
    var connector = new Connector(circles);
    connector.setHandlers(CANVAS_ID);
    var marker = new Marker(circles);
    marker.setHandlers(CANVAS_ID);

    setDomHandlers();
    render();

    function render() {
        ctx.clearRect(0, 0, playground.width, playground.height);
        drawLines();
        drawCircles();

        requestAnimationFrame(render);
    }

    function setDomHandlers() {
        $("#right-btn").click(_ => circles.push(dataUtils.createRandomLocations(playground.width, playground.height, 1)[0]));
        $("#left-btn").click(_ => circles.splice(circles.length - 1, 1));
    }


    function drawCircles() {
        circles.forEach(location => drawer.drawCircle(location, 40));
    }
    
    function drawLines() {
        circles.forEach(circle => circle.connectedLocations.forEach(conCircle =>{
            drawer.drawLine(circle, conCircle, 6);
        }));
    }

    function onResize() {
        playground.width = canvas.width = window.innerWidth;
        playground.height = canvas.height = window.innerHeight;

        playground.centerX = playground.width * .5;
        playground.centerY = playground.height * .5;
    }
}