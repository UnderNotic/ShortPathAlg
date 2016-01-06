game.locations = [];

game.createRandomCircles = function (width, height) {
    // randomly draw 5 circles
    var circlesCount = 5;
    for (var i = 0; i < circlesCount; i++) {
        var x = Math.random() * width;
        var y = Math.random() * (height - 300) + 200;
        game.locations.push(new Location(x, y));
    }
};