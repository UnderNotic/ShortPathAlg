"use strict";

var drawings = require("./drawing");
var data = require("./data");

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

    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");

    var titleOffset = 0;

    var playground = {
        width: canvas.width = window.innerWidth,
        height: canvas.height = window.innerHeight - titleOffset,
        centerX: window.innerWidth * .5,
        centerY: (window.innerHeight - titleOffset) * .5 
    }

    game.ctx = ctx;
    game.isPaused = false;
    
    game.createRandomCircles(playground.width, playground.height);


    render();

// use this instead request animationFrame
//function gameLoop() {
//    window.setTimeout(gameLoop, 20);
//    render();
//}

    function render() {
        ctx.clearRect(0, 0, playground.width, playground.height);

        drawLocations();
        drawMenus();

        requestAnimationFrame(render);
    }

    function drawMenus() {
        ctx.fillStyle = "whitesmoke";
        ctx.font = "40px Tangerine";
        ctx.textBaseline = "top";
        ctx.fillText("More points!", playground.width * .9 - 150, playground.height - 70);
        ctx.fillText("Less points!", playground.width * .1, playground.height - 70);

    }


    function drawLocations() {
        game.locations.forEach(location => game.drawCircle(location.x, location.y, 40));
    }


    function onResize() {
        playground.width = canvas.width = window.innerWidth;
        playground.height = canvas.height = window.innerHeight - titleOffset;

        playground.centerX = playground.width * .5;
        playground.centerY = playground.height * .5;
    }

    function handleMouseInputs() {
        // run the game when mouse moves in the playground.
        $('#canvas').mouseenter(function() {
            game.isPaused = false;
        });

        // pause the game when mouse moves out the playground.
        $('#canvas').mouseleave(function() {
            game.isPaused = true;
        });

        // calculate the paddle position by using the mouse position.
        $('#canvas').mousemove(function(e) {
            pingpong.paddleB.y = e.pageY - pingpong.playground.offsetTop;
        });

    }
}