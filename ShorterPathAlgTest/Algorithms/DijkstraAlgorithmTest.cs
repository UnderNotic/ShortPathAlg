﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShorterPathAlg.Algorithms;
using ShorterPathAlg.Models;

namespace ShorterPathAlgTest.Algorithms
{
    [TestFixture]
    public class DijkstraAlgorithmTest
    {
        private IDijkstraAlgorithm _alg;
        private HashSet<Location> _locations;

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

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result2.Count);
        }

        [Test]
        public void GetShortestPath_ReturnCorrectly3()
        {
            _locations.ElementAt(5).ConnectedLocations.Add(_locations.ElementAt(6));
            _locations.ElementAt(6).ConnectedLocations.Add(_locations.ElementAt(5));
            _locations.ElementAt(4).ConnectedLocations.Add(_locations.ElementAt(5));
            _locations.ElementAt(3).ConnectedLocations.Add(_locations.ElementAt(5));
            _locations.ElementAt(3).ConnectedLocations.Add(_locations.ElementAt(4));

            var result = _alg.GetShortestPath(_locations, _locations.ElementAt(3).Id, _locations.ElementAt(6).Id);

            Assert.AreEqual(3, result.Count);
        }
    }
}