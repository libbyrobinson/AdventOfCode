using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace _2018AdventOfCode.Day6
{
    public class CoordinateGrid
    {
        private readonly int _regionThreshold;
        private string[,] _grid; // X,Y
        private Dictionary<string, Coordinate> _coordinates;

        public CoordinateGrid(List<string> rawCoordinates, int regionThreshold = 0)
        {
            _regionThreshold = regionThreshold;
            RegionClosestToMostCoordinates = 0;
            InitializeCoordinates(rawCoordinates, out var maxX, out var maxY);
            InitializeGrid(maxX, maxY);
        }

        private void InitializeCoordinates(List<string> rawCoordinates, out int maxX, out int maxY)
        {
            _coordinates = new Dictionary<string, Coordinate>();
            maxX = 0;
            maxY = 0;
            for (var i = 0; i < rawCoordinates.Count; i++)
            {
                var xy = rawCoordinates[i].Split(',');
                var coordinate = new Coordinate(i.ToString(), int.Parse(xy[0].Trim()), int.Parse(xy[1].Trim()));
                _coordinates.Add(coordinate.Name, coordinate);
                if (coordinate.X > maxX)
                {
                    maxX = coordinate.X;
                }

                if (coordinate.Y > maxY)
                {
                    maxY = coordinate.Y;
                }
            }
        }

        private void InitializeGrid(int maxX, int maxY)
        {
            _grid = new string[maxX + 1, maxY + 1];
            foreach (var coordinate in _coordinates.Values)
            {
                _grid[coordinate.X, coordinate.Y] = coordinate.Name;
            }
        }

        public void CalculateManhattanDistancesForGrid()
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    string closestCoordinateName = null;
                    var shortestDistance = 0;
                    var totalDistanceToAllCoordinates = 0;
                    foreach (var coordinate in _coordinates)
                    {
                        var manhattanDistance = GetManhattanDistance(
                            new Tuple<int, int>(x, y),
                            new Tuple<int, int>(coordinate.Value.X, coordinate.Value.Y));

                        totalDistanceToAllCoordinates += manhattanDistance;
                        if (closestCoordinateName == null || manhattanDistance < shortestDistance)
                        {
                            closestCoordinateName = coordinate.Key;
                            shortestDistance = manhattanDistance;
                        }
                        else if (manhattanDistance == shortestDistance)
                        {
                            closestCoordinateName = ".";
                            shortestDistance = manhattanDistance;
                        }
                    }

                    _grid[x, y] = closestCoordinateName;
                    if (totalDistanceToAllCoordinates < _regionThreshold)
                    {
                        RegionClosestToMostCoordinates++;
                    }
                    if (closestCoordinateName != ".")
                    {
                        _coordinates[closestCoordinateName].Area++;
                        if (x == 0 || y == 0 || x == _grid.GetLength(0) - 1 || y == _grid.GetLength(1) - 1)
                        {
                            _coordinates[closestCoordinateName].IsInfinite = true;
                        }
                    }
                }
            }
        }

        private int GetManhattanDistance(Tuple<int, int> coordinate1, Tuple<int, int> coordinate2)
        {
            return Math.Abs(coordinate1.Item1 - coordinate2.Item1) + Math.Abs(coordinate1.Item2 - coordinate2.Item2);
        }

        public Coordinate CoordinateFurthestFromOtherCoordinates
        {
            get { return _coordinates.Values.Where(c => !c.IsInfinite).MaxBy(c => c.Area).First(); }
        }

        public int RegionClosestToMostCoordinates { get; private set; }
    }
}
