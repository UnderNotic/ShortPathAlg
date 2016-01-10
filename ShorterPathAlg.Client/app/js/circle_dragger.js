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
                    var tempCircle = dragger.circles[index];
                    var circle = tempCircle.isPointInsideCircle({ x: e.clientX, y: e.clientY });
                    if (circle) {
                        dragger.isDragging = true;
                        draggedCircle = circle;
                    }
                }
            };

        var move =
            function handleMouseMove(e) {
                if (dragger.isDragging && e.which == 1) {
                    draggedCircle.x = e.clientX;
                    draggedCircle.y = e.clientY;
                }
            }

        var out =
            function handleMouseOut(e) {
                dragger.isDragging = false;
            }

        var up =
            function handleMouseUp(e) {
                dragger.isDragging = false;
            }

        $("#" + canvasId).mousedown(function (e) { down(e) });
        $("#" + canvasId).mouseup(function (e) { up(e); });
        $("#" + canvasId).mousemove(function (e) { move(e); });
        $("#canvas").mouseout(function (e) { out(e); });
    }
}


module.exports = CircleDragger;