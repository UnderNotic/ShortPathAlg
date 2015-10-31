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
                    id : 1,
                    longitude : 3,
                    latitude : -4
                ),
                new Location
                (
                    id : 2,
                    longitude : -2,
                    latitude : -3
                ),
                     new Location
                (
                    id : 3,
                    longitude : -1,
                    latitude : -8
                ),
                new Location
                (
                    id : 4,
                    longitude : 4   ,
                    latitude : 3
                ),
                new Location
                (
                    id : 5,
                    longitude : 9,
                    latitude : 3
                ),
                new Location
                (
                    id : 6,
                    longitude : 0,
                    latitude : 3
                ),
                new Location
                (
                    id : 7,
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
                    id: ++id,
                    latitude: latitude,
                    longitude: longitude
                ));
            }
        }
    }
}