﻿using System.Linq;
using NUnit.Framework;
using ShorterPathAlg.Algorithms;

namespace ShorterPathAlgTest.Algorithms
{
    public class DijkstraAlgorithmTest
    {
        private IDijkstraAlgorithm _alg;

        [SetUp]
        public void Init()
        {
            _alg = new DijkstraAlgorithm();
        }

        [Test]
        public void Init_GoesCorrectly()
        {
        }


    [Test]
        public void GetShortestPath_ReturnCorrectly()
        {
            var locations = LocationsForTesting.GetLocationsForTest();

            var result = _alg.GetShortestPath(locations, locations.ElementAt(0).Id, locations.ElementAt(2).Id);
            Assert.AreEqual(2, result.Count);
        }



    }
}