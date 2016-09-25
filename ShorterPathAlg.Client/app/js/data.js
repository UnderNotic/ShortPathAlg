"use strict";

var Location = require("./location");

var createRandomLocations = function (width, height, circlesCount) {
    // randomly draw 5 circles
    var locations = [];
    var offset = 80;
    for (var i = 0; i < circlesCount; i++) {
        var x = Math.random() * (width - offset*2) + offset;
        var y = Math.random() * (height - 350) + 200;
        locations.push(new Location(x, y));
    }
    return locations;
};

module.exports = {
    createRandomLocations: createRandomLocations
};