"use strict";

class Drawer {
    constructor(context) {
        this.context = context;
    }

    drawCircle(circle) {
        this.context.fillStyle = circle.connectedLocations.length !== 0 ? "#cfc" : "whitesmoke";
        this.context.beginPath();
        this.context.arc(circle.x, circle.y, circle.circleRadius, 0, Math.PI * 2, true);
        this.context.fill();

        if (circle.isStartOrEnd) {
            this.context.font = "30px Tangerine";
            this.context.fillStyle = "whitesmoke";

            this.context.fillText("|---->", circle.x - circle.circleRadius, circle.y + 50);
        }
    };

    drawBorderOnShortestPathCircle(circle) {
        if (circle.isInShortestPath) {
            this.context.fillStyle = "whitesmoke";
            this.context.beginPath();
            this.context.arc(circle.x, circle.y, circle.circleRadius + 5, 0, Math.PI * 2, true);
            this.context.fill();
        }
    }

    drawLine(circle1, circle2, thickness, color) {
        this.context.beginPath();
        this.context.moveTo(circle1.x, circle1.y);
        this.context.lineTo(circle2.x, circle2.y);
        this.context.lineWidth = thickness;
        this.context.strokeStyle = color;
        this.context.stroke();
    }
}

module.exports = Drawer;