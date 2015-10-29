using System;
using System.Collections.Generic;
using System.Linq;

namespace ShorterPathAlg.Models
{
    public class Location : IEquatable<Location>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Id { get; set; }

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