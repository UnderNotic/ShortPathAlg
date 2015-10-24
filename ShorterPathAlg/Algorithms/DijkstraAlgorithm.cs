using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{

    public interface IDijkstraAlgorithm : IShorterPathAlgorithm
    {
    }

    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        public List<Location> GetShorterPath(IEnumerable<Location> locations)
        {
            throw new System.NotImplementedException();
        }
    }
}