using System.Collections.Generic;
using System.Linq;
using ShorterPathAlg.Models;
using ShorterPathAlg.Providers;

namespace ShorterPathAlgTest
{
    public static class LocationsForTesting
    {
        public static HashSet<Location> GetLocationsForTest()
        {
            var locations = new HashSet<Location>
            {
                new Location
                (
                    id : 1.ToString(),
                    longitude : 3,
                    latitude : -4
                ),
                new Location
                (
                    id : 2.ToString(),
                    longitude : -2,
                    latitude : -3
                ),
                     new Location
                (
                    id : 3.ToString(),
                    longitude : -1,
                    latitude : -8
                ),
                new Location
                (
                    id : 4.ToString(),
                    longitude : 4   ,
                    latitude : 3
                ),
                new Location
                (
                    id : 5.ToString(),
                    longitude : 9,
                    latitude : 3
                ),
                new Location
                (
                    id : 6.ToString(),
                    longitude : 0,
                    latitude : 3
                ),
                new Location
                (
                    id : 7.ToString(),
                    longitude : 55,
                    latitude : 33
                ),
            };

            return locations;
        }

        public static void AddAnotherLocations(HashSet<Location> locs, int numberOfLocationsToAdd = 1)
        {
            var id = locs.Max(location => location.Id);

            for (int i = 0; i < numberOfLocationsToAdd; i++)
            {
                var longitude = 6 % (i + 1);
                var latitude = 6 % (i + 1);

                locs.Add(new Location
                (
                    latitude: latitude,
                    longitude: longitude
                ));
            }
        }
    }
}