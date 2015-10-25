using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Algorithms
{

    public interface IDijkstraAlgorithm : IShorterPathAlgorithm
    {
    }

    public class DijkstraAlgorithm : IDijkstraAlgorithm
    {
        private readonly IDictionary<Location, double> _pathValues = new Dictionary<Location, double>();
        private Location _startingLocation;
        private Location _destinationLocation;
        private Location _currentLocation;
        private readonly HashSet<Location> _checkedLocations = new HashSet<Location>();
        private readonly List<Location> _shorterPath = new List<Location>();

        public List<Location> GetShortestPath(IEnumerable<Location> locations, Location startingLocation,
            Location destinationLocation)
        {
            _startingLocation = startingLocation;
            _destinationLocation = destinationLocation;

            InitPathValues(locations);

            _pathValues[startingLocation] = 0;

            _currentLocation = startingLocation;

            for (int i = 0; i < _pathValues.Count; i++)
            {
                _currentLocation = _pathValues.First(pair => !_checkedLocations.Contains(pair.Key) && Math.Abs(pair.Value - Double.MaxValue) > 0.5).Key;
                _currentLocation.ConnectedLocationsWithValues.ForEach(pair =>
                {
                    if (!_pathValues.ContainsKey(pair.Key))
                    {
                        _pathValues.Add(pair);
                        _pathValues[pair.Key] += _pathValues[_currentLocation];
                    }
                    else
                    {
                        var newValue = pair.Value + _pathValues[_currentLocation];
                        if (newValue < _pathValues[pair.Key]) _pathValues[pair.Key] = newValue;
                    }
                    _checkedLocations.Add(_currentLocation);
                });
            }
            ComposeShorterPath();

            return _shorterPath;
        }

        private void ComposeShorterPath()
        {
            _shorterPath.Add(_destinationLocation);

            Location currLocation = null;
            while (currLocation != _startingLocation)
            {
                currLocation = _pathValues.Where(pair => pair.Key.ConnectedLocations.Contains(_destinationLocation))
                     .Aggregate((pair1, pair2) => pair1.Value < pair2.Value ? pair1 : pair2).Key;
            }

        }

        private void InitPathValues(IEnumerable<Location> locations)
        {
            locations.ForEach(location => _pathValues.Add(location, double.MaxValue));
        }
    }
}