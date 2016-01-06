"use strict"

var drawCircle = function (x, y, radius) {
    var ctx = game.ctx;
    ctx.fillStyle = "whitesmoke";
    ctx.beginPath();
    ctx.arc(x, y, radius, 0, Math.PI * 2, true);
    ctx.closePath();
    ctx.fill();
};

var drawLine = function (ctx, x1, y1, x2, y2, thickness) {
    ctx.beginPath();
    ctx.moveTo(x1, y1);
    ctx.lineTo(x2, y2);
    ctx.lineWidth = thickness;
    ctx.strokeStyle = "#cfc";
    ctx.stroke();
};

var connectCircles = function(locations) {
    //TODO connect locations from API response
}

module.exports = {
    drawCircle: drawCircle,
    drawLine: drawLine
};