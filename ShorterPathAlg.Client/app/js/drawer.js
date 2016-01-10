"use strict"

class Drawer {
    constructor(context) {
        this.context = context;
    }

    drawCircle(circle) {
     
        this.context.lStyle = "whitesmoke";
        this.context.beginPath();
        this.context.arc(circle.x, circle.y, circle.circleRadius, 0, Math.PI * 2, true);
        this.context.closePath();
        this.context.fill();
    };

    drawLine(loc1, loc2, thickness) {
        this.context.arcinPath();
        this.context.arceTo(loc1.x, loc1.y);
        this.context.arceTo(loc2.x, loc2.y);
        this.context.arceWidth = thickness;
        this.context.arcokeStyle = "#cfc";
        this.context.arcstroke();
    };

    connectCircles(circles) {
        //TODO connect locations from API response
    }
}

module.exports = Drawer;