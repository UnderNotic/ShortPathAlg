export default (locations) => {
    console.log("executing dijktra");
    let start = locations.filter(loc => loc.isStartOrEnd)[0];
    let end = locations.filter(loc => loc.isStartOrEnd)[1];

    if (!start || !end) {
        return;
    }

    locations.forEach(loc => {
        loc.connectedShortestPathLocation = null;
    });
    locations = locations.slice(); //from this array shit should be delted
    let vertexes = locations.map(loc => { // this is result with dist and prev and pointer to loc
        let dist = loc === start ? 0 : Infinity;
        return { loc, dist, prev: null };
    });

    while (locations.length !== 0) {
        let vertex = locations.map(l => vertexes.find(v => v.loc === l)).reduce((prev, curr) => prev.dist < curr.dist ? prev : curr);
        if (vertex.loc === end) {
            break;
        }

        locations = locations.filter(v => v !== vertex.loc);

        vertex.loc.connectedLocations.forEach(l => {
            let alt = vertex.dist + vertex.loc.computeEuclidicDistance(l);
            var currVertex = vertexes.find(v => v.loc === l);
            if (alt < currVertex.dist) {
                currVertex.dist = alt;
                currVertex.prev = vertex;
            }
        });
    }

    let shortestPath = [end];
    let prev = vertexes.find(v => v.loc === end).prev;
    while (prev !== null) {
        prev.loc.connectedShortestPathLocation = shortestPath[0];
        shortestPath.unshift(prev.loc);
        prev = vertexes.find(v => v.loc === prev.loc).prev;
    }

    return shortestPath;
}