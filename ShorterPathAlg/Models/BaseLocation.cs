using System;
using System.Collections.Generic;
using System.Linq;

namespace ShorterPathAlg.Models
{
    public abstract class BaseLocation : IEquatable<BaseLocation>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Id { get; protected set; }

        public bool Equals(BaseLocation other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 37 * 166777 ^ Id.GetHashCode();
        }
    }
}