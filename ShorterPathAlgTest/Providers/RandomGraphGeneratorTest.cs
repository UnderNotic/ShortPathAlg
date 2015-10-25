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
        private IEnumerable<Location> _locations;

        [SetUp]
        public void Init()
        {
            _generator = new RandomGraphGenerator();
            _locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Longitude = 3,
                    Latitude = -4
                },
                new Location
                {
                    Id = 2,
                    Longitude = -2,
                    Latitude = -3
                },
                new Location
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
    }
}