$(window).resize(function () { window.resize(); });

var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");

var titleOffset = 300;

var width = canvas.width = window.innerWidth;
var height = canvas.height = window.innerHeight - titleOffset;

var centerX = width * .5,
    centerY = height * .5,
    radius = 0,
    speed = .04,
    angle = 0;

render();

function render() {
    var y = Math.sin(angle) * height * .5;

    ctx.clearRect(0, 0, width, height);
    ctx.beginPath();
    ctx.arc(centerX, centerY, radius, 0, 2 * Math.PI);
    ctx.fill();

    angle += speed;

    radius = (y > 0) ? y : -y;

    requestAnimationFrame(render);
}

function resize() {
    titleOffset = 300;

    width = canvas.width = window.innerWidth;
    height = canvas.height = window.innerHeight - titleOffset;

    centerX = width * .5;
    centerY = height * .5;
    radius = 0;
    speed = .04;
    angle = 0;
}