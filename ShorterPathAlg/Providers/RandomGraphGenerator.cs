﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShorterPathAlg.Models;
using WebGrease.Css.Extensions;

namespace ShorterPathAlg.Providers
{
    public interface IRandomGraphGenerator
    {
        void GenerateRandomPaths(ICollection<ConnectableLocation<Location>> locations);
        void GenerateRandomTwoWaysPaths(ICollection<ConnectableLocation<Location>> locations);
    }

    public class RandomGraphGenerator : IRandomGraphGenerator
    {
        public void GenerateRandomPaths(ICollection<ConnectableLocation<Location>> locations)
        {
            GenerateBasicCyclicGraph(locations);
            AddRandomPaths(locations);
        }

        public void GenerateRandomTwoWaysPaths(ICollection<ConnectableLocation<Location>> locations)
        {
            GenerateBasicCyclicGraph(locations);
            AddRandomPaths(locations);
            AddPathsForSecondWay(locations);
        }

        private void AddPathsForSecondWay(ICollection<ConnectableLocation<Location>> locations)
        {
            locations.ForEach(location =>
            {
                location.ConnectedLocations.ForEach(location1 =>
                {
                    locations.Where(connectableLocation => connectableLocation.Equals(location1))
                        .ForEach(connectableLocation2 => connectableLocation2.ConnectedLocations.Add(location));
                });

            });
        }


        private void AddRandomPaths(ICollection<ConnectableLocation<Location>> locations)
        {
            var rnd = new Random();

            locations.ForEach(location =>
            {
                for (int i = 0; i < rnd.Next(0, 3); i++)
                {
                    location.ConnectedLocations.Add(locations.ElementAt(rnd.Next(0, locations.Count())));
                }
            });
        }

        private void GenerateBasicCyclicGraph(ICollection<ConnectableLocation<Location>> locations)
        {
            locations.ForEach(location => location.ConnectedLocations.Add(GetClosestLocation(locations, location)));
        }

        private ConnectableLocation<Location> GetClosestLocation(ICollection<ConnectableLocation<Location>> locations, ConnectableLocation<Location> location)
        {
            return locations.Aggregate((loc1, loc2) => location.ComputeEuclidicDistance(loc1) < location.ComputeEuclidicDistance(loc2) ? loc1 : loc2);
        }
    }
}