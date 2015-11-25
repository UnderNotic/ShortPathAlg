using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShorterPathAlg.Models;
using ShorterPathAlg.Providers;

namespace ShorterPathAlgTest.Providers
{
    [TestFixture]
    public class RandomGraphGeneratorTest
    {
        private RandomGraphGenerator _generator;
        private ICollection<Location> _locations;

        [SetUp]
        public void Init()
        {
            _generator = new RandomGraphGenerator();
            _locations = new HashSet<Location>
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
                    longitude : 0,
                    latitude : 3
                )
            };
        }

        [Test]
        public void GenerateRandomPaths_ReturnCorrectly()
        {
            _generator.GenerateRandomPaths(_locations);
            Assert.IsTrue(_locations.All(location => location.ConnectedLocations.Count >= 1));
        }

        [Test]
        public void GenerateRandomTwoWaysPaths_ReturnsCorrectly()
        {
            _generator.GenerateRandomTwoWaysPaths(_locations);

            var loc1 = _locations.First().ConnectedLocations.First();
            var assert =
                loc1.ConnectedLocations.First(location => location.Equals(loc1))
                    .ConnectedLocations.Any(location => location.Equals(loc1));

            Assert.IsTrue(assert);
        }



    }
}