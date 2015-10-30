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
        private ICollection<ConnectableLocation<Location>> _locations;

        [SetUp]
        public void Init()
        {
            _generator = new RandomGraphGenerator();
            _locations = new HashSet<ConnectableLocation<Location>>
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
                loc1..First(location => location.Equals(loc1))
                    .ConnectedLocations.Any(location => location.Equals(loc1));

            Assert.IsTrue(assert);
        }



    }
}