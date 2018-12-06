using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day6
{
    public class CoordinateGridTests
    {
        [Fact]
        public void ShouldCalculateCoordinateFurthestFromOtherCoordinatesFromSmallExample()
        {
            var rawCoordinates = new List<string>
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };
            var sut = new CoordinateGrid(rawCoordinates);

            sut.CalculateManhattanDistancesForGrid();

            sut.CoordinateFurthestFromOtherCoordinates.Area.Should().Be(17);
        }

        [Fact]
        public void ShouldCalculateRegionClosestToMostCoordinatesFromSmallExample()
        {
            var rawCoordinates = new List<string>
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };
            var sut = new CoordinateGrid(rawCoordinates, 32);

            sut.CalculateManhattanDistancesForGrid();

            sut.RegionClosestToMostCoordinates.Should().Be(16);
        }

        [Fact]
        public void ShouldCalculateCoordinateFurthestFromOtherCoordinatesFromBigInput()
        {
            var sut = new CoordinateGrid(PuzzleInputParser.ParseStrings("Day6/Input.txt"), 10000);

            sut.CalculateManhattanDistancesForGrid();

            sut.CoordinateFurthestFromOtherCoordinates.Area.Should().Be(5358);
        }

        [Fact]
        public void ShouldCalculateRegionClosestToMostCoordinatesFromBigInput()
        {
            var sut = new CoordinateGrid(PuzzleInputParser.ParseStrings("Day6/Input.txt"), 10000);

            sut.CalculateManhattanDistancesForGrid();

            sut.RegionClosestToMostCoordinates.Should().Be(37093);
        }
    }
}