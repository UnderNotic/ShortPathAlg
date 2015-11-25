using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{
    public interface IShorterPathAlgorithm
    {
        List<Location> GetShortestPath(HashSet<Location> locations, string startingLocationId, string destinationLocationId);
    }
}