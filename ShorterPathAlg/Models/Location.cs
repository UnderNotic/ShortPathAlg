using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace ShorterPathAlg.Models
{
    public class Location : IEquatable<Location>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Id { get; set; }

        public HashSet<Location> ConnectedLocations { get; } = new HashSet<Location>();

        private readonly IDictionary<Location, double> _connectedLocationsWithValues = new Dictionary<Location, double>();
        public IDictionary<Location, double> ConnectedLocationsWithValues
        {
            get
            {
                ConnectedLocations.ForEach(location => _connectedLocationsWithValues.Add(location, ComputeEuclidicDistance(location)));
                return _connectedLocationsWithValues;
            }
        }

        public double ComputeEuclidicDistance(Location other)
        {
            var result = Math.Sqrt(Math.Pow((Latitude - other.Latitude), 2) + Math.Pow((Longitude - other.Longitude), 2));
            var roundedResult = Math.Round(result, 4);
            return (decimal)result == 0 ? int.MaxValue : roundedResult;
        }

        public bool Equals(Location other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 37 * 166777 ^ Id.GetHashCode();
        }
    }
}