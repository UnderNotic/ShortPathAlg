"use strict";

class Drawer {
    constructor(context) {
        this.context = context;
        this.particle = null;
        this.chosenCircle = [];
        this.inShortestPath = [];
    }

    drawCircle(circle) {
        if (circle.isStartOrEnd) {
            //randomize number of moiving things and colour of it 

            this.chosenCircle[0] = this.chosenCircle[0] || {
                id: circle.getHashcode(),
                lastPosStart: 2 * Math.PI,
                lastPosEnd: 0
            };

            this.chosenCircle[1] = this.chosenCircle[1] || {
                id: circle.getHashcode(),
                lastPosStart: 0,
                lastPosEnd: 2 * Math.PI * 0.6
            };

            let speed = 0.07;

            this.chosenCircle[0].lastPosStart += speed;
            this.chosenCircle[0].lastPosEnd += speed;
            this.chosenCircle[1].lastPosStart += speed;
            this.chosenCircle[1].lastPosEnd += speed;

            this.context.beginPath();
            this.context.fillStyle = circle.connectedLocations.length !== 0 ? 'whitesmoke' : '#cfc';
            this.context.arc(circle.x, circle.y, circle.circleRadius * 1.16, this.chosenCircle[0].lastPosStart, this.chosenCircle[0].lastPosEnd, true);
            this.context.fill();

            this.context.beginPath();
            this.context.fillStyle = '#D0CA9C';
            this.context.arc(circle.x, circle.y, circle.circleRadius * 1.16, this.chosenCircle[1].lastPosStart, this.chosenCircle[1].lastPosEnd, false);
            this.context.fill();
        }

        this.context.fillStyle = circle.connectedLocations.length !== 0 ? "#cfc" : "whitesmoke";
        this.context.beginPath();
        this.context.arc(circle.x, circle.y, circle.circleRadius, 0, Math.PI * 2, true);
        this.context.fill();
    }

    drawFloatingCircles(circles) {
        // match floating circles with actual circles and their x, y pos
        // for (let i = circles.length; i < this.inShortestPath.length; i++) {
        //     this.inShortestPath.push({
        //         size: 5,
        //         position: { x: circle.x, y: circle.y },
        //         offset: { x: 0, y: 0 },
        //         shift: { x: 0, y: 0 },
        //         speed: 0.04,
        //         fillColor: '#whitesmoke',
        //         orbit: circle.circleRadius * 1.4
        //     })
        // }
    }

    drawBorder(circle) {
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