using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{

    public interface IDijkstraAlgorithm : IShorterPathAlgorithm
    {
    }

    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        private HashSet<DijkstraLocation> _locations;

        public List<Location> GetShortestPath(IEnumerable<ConnectableLocation<Location>> locations, int startingLocation,
            int destinationLocation)
        {
            Init(locations, startingLocation);

            var destLocation = ExecuteAlgorithm(destinationLocation);

            var stack = GetShorterPath(destLocation);

            return stack.ToList();
        }

        private static Stack<Location> GetShorterPath(DijkstraLocation destLocation)
        {
            var stack = new Stack<Location>();

            while (destLocation != null)
            {
                stack.Push(destLocation);
                destLocation = destLocation.PreviousLocation;
            }
            return stack;
        }

        private DijkstraLocation ExecuteAlgorithm(int destinationLocationId)
        {
            while (_locations.Any())
            {
                var lastLocation = _locations.Aggregate((loc1, loc2) => loc1.Distance < loc2.Distance ? loc1 : loc2);
                if (lastLocation.Id == destinationLocationId) return lastLocation;
                _locations.Remove(lastLocation);

                foreach (var connectedLocation in lastLocation.ConnectedLocations)
                {
                    var distance = lastLocation.Distance + lastLocation.ComputeEuclidicDistance(connectedLocation);

                    var dijkstraLocation = connectedLocation;
                    if (dijkstraLocation.Distance > distance)
                    {
                        dijkstraLocation.Distance = distance;
                        dijkstraLocation.PreviousLocation = lastLocation;
                    }
                }
            }
            return null; //this should never happen, only when destinationId is not in graph
        }

        private void Init(IEnumerable<ConnectableLocation<Location>> locations, int startingLocationId)
        {
            locations.ForEach(location =>
            {
                DijkstraLocation locToAdd = location.Id == startingLocationId ? new DijkstraLocation(location) {Distance = 0} : new DijkstraLocation(location);
                _locations.Add(locToAdd);
            });

            DijkstraLocation.MapConnectedLocations(_locations, locations);
        }

        private class DijkstraLocation : ConnectableLocation<DijkstraLocation> 
        {
            public double Distance { get; set; } = double.MaxValue;
            public DijkstraLocation PreviousLocation { get; set; }

            public DijkstraLocation(ConnectableLocation<Location> location)
            {
                Id = location.Id;
                Longitude = location.Longitude;
                Latitude = location.Latitude;
            }
           
        }
    }
}