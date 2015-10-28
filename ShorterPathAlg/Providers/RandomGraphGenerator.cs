using System;
using System.Collections.Generic;
using System.Linq;
using ShorterPathAlg.Models;
using WebGrease.Css.Extensions;

namespace ShorterPathAlg.Providers
{
    public interface IRandomGraphGenerator
    {
        void GenerateRandomPaths(IEnumerable<ConnectableLocation<Location>> locations);
    }

    public class RandomGraphGenerator : IRandomGraphGenerator
    {
        private IEnumerable<ConnectableLocation<Location>> _locations; 

        public void GenerateRandomPaths(IEnumerable<ConnectableLocation<Location>> locations)
        {
            _locations = locations;
            GenerateBasicCyclicGraph();
            AddRandomPaths();
        }

        private void AddRandomPaths()
        {
            var rnd = new Random();

            _locations.ForEach(location =>
            {
                for (int i = 0; i < rnd.Next(0, 3); i++)
                {
                   location.ConnectedLocations.Add(_locations.ElementAt(rnd.Next(0, _locations.Count())));
                }
            });
        }

        private void GenerateBasicCyclicGraph()
        {
            _locations.ForEach(location => location.ConnectedLocations.Add(GetClosestLocation(location)));
        }

        private Location GetClosestLocation(ConnectableLocation<Location> location)
        {
            return _locations.Aggregate((loc1, loc2) => location.ComputeEuclidicDistance(loc1) < location.ComputeEuclidicDistance(loc2) ? loc1 : loc2);
        }
    }
}