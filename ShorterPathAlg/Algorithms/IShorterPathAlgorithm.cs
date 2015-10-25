using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{
    public interface IShorterPathAlgorithm
    {
        List<Location> GetShortestPath(IEnumerable<Location> locations, Location startingLocation, Location destinationLocation);
    }
}