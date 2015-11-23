using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ShorterPathAlg.Models
{
    public abstract class ConnectableLocation<T> : BaseLocation where T : BaseLocation
    {
        public HashSet<T> ConnectedLocations { get; protected set; } = new HashSet<T>();

        private readonly IDictionary<T, double> _connectedLocationsWithValues = new Dictionary<T, double>();
        public IDictionary<T, double> ConnectedLocationsWithValues
        {
            get
            {
                ConnectedLocations.ForEach(location => _connectedLocationsWithValues.Add(location, ComputeEuclidicDistance(location)));
                return _connectedLocationsWithValues;
            }
        }

        public double ComputeEuclidicDistance(T other)
        {
            var result = Math.Sqrt(Math.Pow((Latitude - other.Latitude), 2) + Math.Pow((Longitude - other.Longitude), 2));
            var roundedResult = Math.Round(result, 4);
            return (decimal)result == 0 ? int.MaxValue : roundedResult;
        }

        public static void MapConnectedLocations<TConnected>(IEnumerable<ConnectableLocation<T>> notConnectedLocations,
            IEnumerable<ConnectableLocation<TConnected>> connectedLocations) where TConnected : BaseLocation
        {
            connectedLocations.ForEach(location =>
            {
                var notConnected = notConnectedLocations.First(loc => loc.Equals(location));
                var connections = location.ConnectedLocations;
                var toAdd = notConnectedLocations.Where(
                    connectableLocation => connections.Any(location1 => location1.Equals(connectableLocation)))
                    .Select(connectableLocation => connectableLocation as T);

                notConnected.ConnectedLocations = new HashSet<T>(toAdd);
            });
        }

        public ConnectableLocation(int id) : base(id)
        {
        }
    }
}