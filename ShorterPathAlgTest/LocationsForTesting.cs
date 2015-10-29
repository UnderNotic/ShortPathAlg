using System.Collections.Generic;
using System.Linq;
using ShorterPathAlg.Models;
using ShorterPathAlg.Providers;

namespace ShorterPathAlgTest
{
    public static class LocationsForTesting
    {
         public static IEnumerable<ConnectableLocation<Location>> GetLocationsForTest()
        {
            var locations = new List<ConnectableLocation<Location>>
            {
                new ConnectableLocation<Location>
                {
                    Id = 1,
                    Longitude = 3,
                    Latitude = -4
                },
                new ConnectableLocation<Location>
                {
                    Id = 2,
                    Longitude = -2,
                    Latitude = -3
                },
                new ConnectableLocation<Location>
                {
                    Id = 3,
                    Longitude = 0,
                    Latitude = 3
                }
            };

            return locations;
        }

        public static void AddAnotherLocations(IList<ConnectableLocation<Location>> locs, int numberOfLocationsToAdd = 1)
        {
            var id = locs.Max(location => location.Id);

            for (int i = 0; i < numberOfLocationsToAdd; i++)
            {
                var longitude = 6%(i + 1);
                var latitude = 6%(i + 1);

                locs.Add(new ConnectableLocation<Location>
                {
                    Id = ++id,
                    Latitude = latitude,
                    Longitude = longitude
                });
            }
        }
    }
}