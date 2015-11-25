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
            _location = new Location(1.ToString(), 2, 4);
        }

        [Test]
        public void ComputeEuclidicDistance_ReturnsCorrectly()
        {
            var loc2 = new Location(1.ToString(), 1, 3);

            var result = _location.ComputeEuclidicDistance(loc2);

            Assert.AreEqual(Math.Round(Math.Sqrt(2), 4), result);
        }

        [Test]
        public void GetConnectedLocationsWithValues_ReturnsCorrectly()
        {
            var loc1 = new Location
            (
                id : 1.ToString(),
                longitude : 4,
                latitude : 7
            );
            var loc2 = new Location
            (
                id : 2.ToString(),
                longitude : 3,
                latitude : 2
            );

            _location.ConnectedLocations.Add(loc1);
            _location.ConnectedLocations.Add(loc2);

            var result = _location.ConnectedLocationsWithValues;

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(5, result[loc1]);
            Assert.AreEqual(1, result[loc2]);
        }
    }
}