using System.Collections.Generic;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{

    public interface IDijkstraAlgorithm : IShorterPathAlgorithm
    {
    }

    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        private IDictionary<Location,  double> _pathValues = new Dictionary<Location, double>();


        public List<Location> GetShortestPath(IEnumerable<Location> locations, Location startingLocation, Location destinationLocation)
        {
            ComputePathsCosts();

            return null;
        }

        private void ComputePathsCosts()
        {
            throw new System.NotImplementedException();
        }
    }
}