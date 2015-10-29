using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShorterPathAlg.Algorithms;
using ShorterPathAlg.Models;

namespace ShorterPathAlgTest.Algorithms
{
    public class DijkstraAlgorithmTest
    {
        private IDijkstraAlgorithm _alg;
        private IEnumerable<ConnectableLocation<Location>> _locations;

        [SetUp]
        public void Init()
        {
            _alg = new DijkstraAlgorithm();

            _locations = LocationsForTesting.GetLocationsForTest();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetShortestPath_ShouldThrowExceptionNoPath()
        {
            _alg.GetShortestPath(_locations, _locations.ElementAt(0).Id, _locations.ElementAt(2).Id);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetShortestPath_ShouldThrowExceptionSameEndAndStartPoint()
        {
            _alg.GetShortestPath(_locations, _locations.ElementAt(0).Id, _locations.ElementAt(0).Id);
        }



        [Test]
        public void GetShortestPath_ReturnCorrectly()
        {
            _locations.ElementAt(0).ConnectedLocations.Add(_locations.ElementAt(1));
            _locations.ElementAt(1).ConnectedLocations.Add(_locations.ElementAt(2));

            var result = _alg.GetShortestPath(_locations, _locations.ElementAt(0).Id, _locations.ElementAt(2).Id);
            Assert.AreEqual(3, result.Count);
        }


        [Test]
        public void GetShortestPath_ReturnCorrectly2()
        {
            _locations.ElementAt(0).ConnectedLocations.Add(_locations.ElementAt(1));
            _locations.ElementAt(0).ConnectedLocations.Add(_locations.ElementAt(2));
            _locations.ElementAt(1).ConnectedLocations.Add(_locations.ElementAt(0));

            var result = _alg.GetShortestPath(_locations, _locations.ElementAt(0).Id, _locations.ElementAt(1).Id);
            var result2 = _alg.GetShortestPath(_locations, _locations.ElementAt(0).Id, _locations.ElementAt(2).Id);
            var result3 = _alg.GetShortestPath(_locations, _locations.ElementAt(1).Id, _locations.ElementAt(2).Id);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result2.Count);
            Assert.AreEqual(3, result3.Count);
        }



        [Test]
        public void GetShortestPath_ReturnCorrectly3()
        {
            var locs = _locations.ToList();
            LocationsForTesting.AddAnotherLocations(locs, 4);

            locs.ElementAt(0).ConnectedLocations.Add(locs.ElementAt(1));
            locs.ElementAt(1).ConnectedLocations.Add(locs.ElementAt(2));
            locs.ElementAt(2).ConnectedLocations.Add(locs.ElementAt(3));
            locs.ElementAt(3).ConnectedLocations.Add(locs.ElementAt(4));
            locs.ElementAt(4).ConnectedLocations.Add(locs.ElementAt(5));
            locs.ElementAt(5).ConnectedLocations.Add(locs.ElementAt(6));

            var result = _alg.GetShortestPath(locs, locs.ElementAt(0).Id, locs.ElementAt(6).Id);

            Assert.AreEqual(7, result.Count);
        }
    }
}