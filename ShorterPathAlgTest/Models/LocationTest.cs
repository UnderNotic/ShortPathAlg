using System;
using NUnit.Framework;
using ShorterPathAlg.Models;

namespace ShorterPathAlgTest.Models
{
    [TestFixture]
    public class LocationTest
    {
        private ConnectableLocation<Location> _location;
        

        [SetUp]
        public void Init()
        {
        _location = new ConnectableLocation<Location>{ Latitude = 2, Longitude = 4};    
        }

        [Test]
        public void ComputeEuclidicDistance_ReturnsCorrectly()
        {
            var loc2 = new ConnectableLocation<Location> {Latitude = 1, Longitude = 3};

            var result = _location.ComputeEuclidicDistance(loc2);

            Assert.AreEqual(Math.Round(Math.Sqrt(2), 4), result);
        }

        [Test]
        public void GetConnectedLocationsWithValues_ReturnsCorrectly()
        {
            var loc1 = new ConnectableLocation<Location>
            {
                Id = 1,
                Longitude = 4,
                Latitude = 7
            };
            var loc2 = new ConnectableLocation<Location>
            {
                Id = 2,
                Longitude = 3,
                Latitude = 2
            };

            _location.ConnectedLocations.Add(loc1);
            _location.ConnectedLocations.Add(loc2);

            var result = _location.ConnectedLocationsWithValues;

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(5, result[loc1]);
            Assert.AreEqual(1, result[loc2]);
        }
    }
}