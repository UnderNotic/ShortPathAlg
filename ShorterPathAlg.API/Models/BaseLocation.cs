﻿using System;

namespace ShorterPathAlg.Models
{
    public abstract class BaseLocation : IEquatable<BaseLocation>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Id { get; }

        protected BaseLocation()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected BaseLocation(string id)
        {
            Id = id;
        }
        public bool Equals(BaseLocation other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}