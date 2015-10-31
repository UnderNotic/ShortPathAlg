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
        private readonly HashSet<DijkstraLocation> _dijkstraLocations = new HashSet<DijkstraLocation>();

        public List<Location> GetShortestPath(HashSet<Location> locations, int startingLocation,
            int destinationLocation)
        {
            if (startingLocation == destinationLocation) throw new ArgumentException("Starting location cannot be the same as destination location");
          
            Init(locations, startingLocation);

            var destLocation = ExecuteAlgorithm(destinationLocation);

            var stack = GetShorterPath(destLocation);
            if (stack.Count == 1 || stack.First().Id != startingLocation) throw new ArgumentException("Cannot find path beetwen locations");

            return stack.ToList();
        }

        private static Stack<Location> GetShorterPath(DijkstraLocation destLocation)
        {
            var stack = new Stack<Location>();

            while (destLocation != null)
            {
                stack.Push(destLocation.ToLocation());
                destLocation = destLocation.PreviousLocation;
            }
            return stack;
        }

        //TODO throw somethere exception if there is no path 
        private DijkstraLocation ExecuteAlgorithm(int destinationLocationId)
        {
            while (_dijkstraLocations.Any())
            {
                var lastLocation = _dijkstraLocations.Aggregate((loc1, loc2) => loc1.Distance < loc2.Distance ? loc1 : loc2);
                if (lastLocation.Id == destinationLocationId) return lastLocation;
                _dijkstraLocations.Remove(lastLocation);

                foreach (var connectedLocation in lastLocation.ConnectedLocations)
                {
                    var distance = lastLocation.Distance + lastLocation.ComputeEuclidicDistance(connectedLocation);

                    if (connectedLocation.Distance > distance)
                    {
                        connectedLocation.Distance = distance;
                        connectedLocation.PreviousLocation = lastLocation;
                    }
                }
            }
            return null; //this should never happen, only when destinationId is not in graph
        }

        private void Init(HashSet<Location> locations, int startingLocationId)
        {
            locations.ForEach(location =>
            {
                DijkstraLocation locToAdd = location.Id == startingLocationId ? new DijkstraLocation(location) {Distance = 0} : new DijkstraLocation(location);
                _dijkstraLocations.Add(locToAdd);
            });
            DijkstraLocation.MapConnectedLocations(_dijkstraLocations, locations);
        }

        private class DijkstraLocation : ConnectableLocation<DijkstraLocation>
        {
            public double Distance { get; set; } = double.MaxValue;
            public DijkstraLocation PreviousLocation { get; set; }

            public DijkstraLocation(ConnectableLocation<Location> location) : base(location.Id)
            {
                Longitude = location.Longitude;
                Latitude = location.Latitude;
            }

            public Location ToLocation()
            {
                var location = new Location(Id, Latitude, Longitude);
                MapConnectedLocations(ConnectedLocations, location.ConnectedLocations);
                return location;
            }
           
        }
    }
}