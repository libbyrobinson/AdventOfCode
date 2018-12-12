using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day11
{
    public class FuelCellGridTests
    {
        [Theory]
        [InlineData(3, 5, 8, 4)]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void ShouldCalculateFuelCellPowerLevel(int x, int y, int serialNumber, int expectedPowerLevel)
        {
            var cell = new FuelCell(x, y, serialNumber);
            cell.PowerLevel.Should().Be(expectedPowerLevel);
        }

        [Theory]
        [InlineData(18, 33, 45)]
        [InlineData(42, 21, 61)]
        [InlineData(5535, 19, 41)]
        public async Task ShouldFindSize3SquareWithHighestPower(int serialNumber, int x, int y)
        {
            var grid = new FuelCellGrid(300, serialNumber);
            var square = await grid.FindSquareWithHighestPowerAsync(3);
            square.TopLeftCorner.XCoordinate.Should().Be(x);
            square.TopLeftCorner.YCoordinate.Should().Be(y);
        }

        [Theory]
        [InlineData(18, 90, 269, 16)]
        [InlineData(42, 232, 251, 12)]
        [InlineData(5535, 237,284,11)]
        public async Task ShouldFindAnySizeSquareWithHighestPower(int serialNumber, int x, int y, int size)
        {
            var grid = new FuelCellGrid(300, serialNumber);
            var square = await grid.FindSquareWithHighestPowerAsync();
            square.TopLeftCorner.XCoordinate.Should().Be(x);
            square.TopLeftCorner.YCoordinate.Should().Be(y);
            square.SquareSize.Should().Be(size);
        }
    }
}