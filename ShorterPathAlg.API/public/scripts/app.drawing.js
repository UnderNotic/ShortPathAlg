if (game === undefined) {
    var game = {};
}

game.drawCircle = function (x, y, radius) {
    var ctx = game.ctx;
    ctx.fillStyle = "whitesmoke";
    ctx.beginPath();
    ctx.arc(x, y, radius, 0, Math.PI * 2, true);
    ctx.closePath();
    ctx.fill();
};