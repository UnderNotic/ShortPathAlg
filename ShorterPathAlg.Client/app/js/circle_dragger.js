"use strict"

class CircleDragger {
    constructor(circles) {
        this.circles = circles;
        this.isDragging = false;
    }

    setHandlers(canvasId) {
        var dragger = this;
        var draggedCircle = {};

        var down =
            function handleMouseDown(e) {
                console.log("mouse down! x:" + e.clientX + " y:" + e.clientY);
                for (var index = 0; index < dragger.circles.length; index++) {
                    var location = dragger.circles[index];
                    var circle = isPointInsideCircle(location, { x: e.clientX, y: e.clientY })
                    if (circle) {
                        dragger.isDragging = !dragger.isDragging;
                        draggedCircle = circle;
                    }
                }
            };


        var move =
            function handleMouseMove(e) {
                if (dragger.isDragging) {
                    draggedCircle.x = e.clientX;
                    draggedCircle.y = e.clientY;
                }
            }

        var out =
            function handleMouseOut(e) {
                dragger.isDragging = false;
            }
            
        // TODO change it to dragging on movedown
        // var up = 
        //     function handleMouseUp(e) {
        //         dragger.isDragging = false;
        //     }

        $("#" + canvasId).mousedown(function (e) { down(e) });
        $("#" + canvasId).mousemove(function (e) { move(e); });
        $("#canvas").mouseout(function (e) { out(e); });
    }
}

function isPointInsideCircle(location, point) {
    var distance = Math.sqrt(Math.pow(location.x - point.x, 2) + Math.pow(location.y - point.y, 2))
    if (distance < location.circleRadius) return location;
}

module.exports = CircleDragger;