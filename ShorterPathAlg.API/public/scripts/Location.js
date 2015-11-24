define(function () {
    //Do setup work here
    class Location{
        constructor(x, y) {
            this.x = x;
            this.y = y;
            this.connectedLocations = [];
        }

        toString() {
            return "Location x: " + this.x + " y: " + this.y;
        }

        setX(x) {
            this.x = x;
        }

        setY(y) {
            this.y = y;
        }

        addConnectedLocation(location) {
            this.connectedLocations.push(location);
        }

        equals(location) {
            if (this.x === location.x && this.y === location.y) {
                return true;
            }
            return false;
        }

    }

    return makeLocation = () => new location();
});