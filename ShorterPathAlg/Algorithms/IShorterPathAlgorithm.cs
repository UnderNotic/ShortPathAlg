using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{
    public interface IShorterPathAlgorithm
    {
        List<Location> GetShortestPath(IEnumerable<ConnectableLocation<Location>> locations, int startingLocationId, int destinationLocationId);
    }
}