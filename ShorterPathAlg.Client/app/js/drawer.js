﻿"use strict"

class Drawer {
    constructor(context) {
        this.context = context;
    }

    drawCircle(circle) {
        this.context.fillStyle = circle.isStartOrEnd ? "#337575" : circle.isClicked || circle.connectedLocations.length !== 0 ? "#cfc" : "whitesmoke";
        this.context.beginPath();
        this.context.arc(circle.x, circle.y, circle.circleRadius, 0, Math.PI * 2, true);
        this.context.closePath();
        this.context.fill();
    };

    drawLine(circle1, circle2, thickness) {
        this.context.beginPath();
        this.context.moveTo(circle1.x, circle1.y);
        this.context.lineTo(circle2.x, circle2.y);
        this.context.lineWidth = thickness;
        this.context.strokeStyle = "#cfc";
        this.context.stroke();
    };

    connectCircles(circles) {
        //TODO connect locations from API response
    }
}

module.exports = Drawer;