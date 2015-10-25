using System.Collections.Generic;
using ShorterPathAlg.Models;
using ShorterPathAlg.Providers;

namespace ShorterPathAlgTest
{
    public static class LocationsForTesting
    {
         public static IEnumerable<Location> GetLocationsForTest()
        {
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Longitude = 3,
                    Latitude = -4
                },
                new Location
                {
                    Id = 2,
                    Longitude = -2,
                    Latitude = -3
                },
                new Location
                {
                    Id = 3,
                    Longitude = 0,
                    Latitude = 3
                }
            };

            var gen = new RandomGraphGenerator();

            gen.GenerateRandomPaths(locations);
            return locations;
        } 
    }
}