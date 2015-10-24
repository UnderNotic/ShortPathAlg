using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{
    public interface IShorterPathAlgorithm
    {
        List<Location> GetShorterPath(IEnumerable<Location> locations);
    }
}