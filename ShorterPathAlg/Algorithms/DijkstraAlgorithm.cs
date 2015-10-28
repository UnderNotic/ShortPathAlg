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


        public List<Location> GetShortestPath(IEnumerable<Location> locations, int startingLocation,
            int destinationLocation)
        {
            Init(locations, startingLocation);

            while (_locations.Any())
            {
                var loc = _locations.Aggregate((loc1, loc2) => loc1.Distance < loc2.Distance ? loc1 : loc2);
                _locations.Remove(loc);

                foreach (var connectedLocation in loc.ConnectedLocations)
                {
                    var distance = loc.Distance + loc.ComputeEuclidicDistance(connectedLocation);
                    if(connectedLocation.)
                }

            }

            return null;
        }

        private void Init(IEnumerable<Location> locations, int startingLocationId)
        {
            locations.ForEach(location =>
            {
                DijkstraLocation locToAdd = location.Id == startingLocationId ? new DijkstraLocation(location) {Distance = 0} : new DijkstraLocation(location);
                _locations.Add(locToAdd);
            });
        }

        private class DijkstraLocation : Location
        {
            public double Distance { get; set; } = double.MaxValue;
            public DijkstraLocation PreviousLocation { get; set; }

            public DijkstraLocation(Location location)
            {
                Id = location.Id;
                Longitude = location.Longitude;
                Latitude = location.Latitude;
                ConnectedLocations = location.ConnectedLocations;
            }
        }
    }
}