"use strict"

class CircleConnector {
    constructor(circles) {
        this.circles = circles;
    }

    setHandlers(canvasId) {

        var connector = this;
        var chosenCircle = {};

        var down = function (e) {
            if (e.which == 2 || e.which == 3) {
                for (var index = 0; index < connector.circles.length; index++) {
                    var tempCircle = connector.circles[index];
                    var circle = tempCircle.isPointInsideCircle({ x: e.clientX, y: e.clientY });
                    if (circle) {
                        if (connector.chosenCircle) {
                            chosenCircle.addConnectedLocation(circle);
                        }
                        else {
                            chosenCircle = circle;
                        }
                    }
                    else {
                        chosenCircle = {};
                    }
                }

            }
        }

        $("#canvas").mousedown(function (e) { down(e) });

    }


}

module.exports = CircleConnector;