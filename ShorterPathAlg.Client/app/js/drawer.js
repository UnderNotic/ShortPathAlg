"use strict";

class Drawer {
    constructor(context) {
        this.context = context;
        this.particle = null;
        this.chosenCircle = null;
    }

    drawCircle(circle) {
        if (circle.isStartOrEnd) {
            let radians = this.chosenCircle = this.chosenCircle + 0.1 || 0.1 * Math.PI;
            this.context.beginPath();
            this.context.fillStyle = '#' + (Math.random() * 0x404040 + 0xaaaaaa | 0).toString(16);
            this.context.arc(circle.x, circle.y, circle.circleRadius * 1.2, radians, radians + 10, true);

            this.context.fill();
            this.context.beginPath();
            this.context.fillStyle = '#' + (Math.random() * 0x404040 + 0xaaaaaa | 0).toString(16);

            this.context.arc(circle.x, circle.y, circle.circleRadius * 1.2, radians + 10, radians + 20, true);

            this.context.fill();
        }

        this.context.fillStyle = circle.connectedLocations.length !== 0 ? "#cfc" : "whitesmoke";
        this.context.beginPath();
        this.context.arc(circle.x, circle.y, circle.circleRadius, 0, Math.PI * 2, true);
        this.context.fill();

        if (!circle.isStartOrEnd && circle.isInShortestPath) {
            var RADIUS_SCALE = 1;

            let particle = this.particle = this.particle || {
                size: 11,
                position: { x: circle.x, y: circle.y },
                offset: { x: 0, y: 0 },
                shift: { x: 0, y: 0 },
                speed: 0.04,
                fillColor: '#whitesmoke',
                orbit: circle.circleRadius * 1.4
            };

            var lp = { x: particle.position.x, y: particle.position.y };

            // Rotation
            particle.offset.x += particle.speed;
            particle.offset.y += particle.speed;

            // Follow mouse with some lag
            particle.shift.x += (circle.x - particle.shift.x) * (particle.speed);
            particle.shift.y += (circle.y - particle.shift.y) * (particle.speed);

            // Apply position
            particle.position.x = particle.shift.x + Math.cos(1 + particle.offset.x) * (particle.orbit * RADIUS_SCALE);
            particle.position.y = particle.shift.y + Math.sin(1 + particle.offset.y) * (particle.orbit * RADIUS_SCALE);

            this.context.beginPath();
            this.context.fillStyle = particle.fillColor;
            this.context.strokeStyle = particle.fillColor;
            this.context.lineWidth = particle.size;

            this.context.moveTo(lp.x, lp.y);

            this.context.arc(particle.position.x, particle.position.y, particle.size / 2, 0, Math.PI * 2, true);
            this.context.fill();
        }
    }

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