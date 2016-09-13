"use strict";

var Drawer = require("./drawer");
var dataUtils = require("./data");
var Dragger = require("./circle_dragger");
var Connector = require("./circle_connector");

var CANVAS_ID = "canvas"


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
    }

    var drawer = new Drawer(ctx);
    
    var circles = dataUtils.createRandomLocations(playground.width, playground.height, 5);

    var dragger = new Dragger(circles);
    dragger.setHandlers(CANVAS_ID);    
    var connector = new Connector(circles);
    connector.setHandlers(CANVAS_ID);
    
    render();

    function render() {
        ctx.clearRect(0, 0, playground.width, playground.height);
        drawCircles();
        drawLines();
        drawMenus();

        requestAnimationFrame(render);
    }

    function drawMenus() {
        ctx.fillStyle = "whitesmoke";
        ctx.font = "40px Tangerine";
        ctx.textBaseline = "top";
        const MorePoints = "More points!";
        const LessPoints = "Less points!";
        ctx.fillText(MorePoints, playground.width * .9 - 150, playground.height - 70);
        ctx.fillText(LessPoints, playground.width * .1, playground.height - 70);
        let morePointsLength = ctx.measureText(MorePoints); 

    }

    function drawCircles() {
        circles.forEach(location => drawer.drawCircle(location, 40));
    }
    
    function drawLines() {
        circles.forEach(circle => circle.connectedLocations.forEach(conCircle =>{
            drawer.drawLine(circle, conCircle, 2);
        }))
    }

    function onResize() {
        playground.width = canvas.width = window.innerWidth;
        playground.height = canvas.height = window.innerHeight;

        playground.centerX = playground.width * .5;
        playground.centerY = playground.height * .5;
    }






    function handleMouseInputs() {
        // run the game when mouse moves in the playground.
        $('#canvas').mouseenter(function () {
            game.isPaused = false;
        });

        // pause the game when mouse moves out the playground.
        $('#canvas').mouseleave(function () {
            game.isPaused = true;
        });

        // calculate the paddle position by using the mouse position.
        $('#canvas').mousemove(function (e) {
            pingpong.paddleB.y = e.pageY - pingpong.playground.offsetTop;
        });

    }
}