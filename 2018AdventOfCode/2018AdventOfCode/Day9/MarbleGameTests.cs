using System;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace _2018AdventOfCode.Day9
{
    public class MarbleGameTests
    {
        private readonly ITestOutputHelper _output;

        public MarbleGameTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(9, 32, 32)]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        [InlineData(400, 71864, 437654)]
        [InlineData(400, 7186400, 3689913905)]
        public void ShouldDetermineMarbleGameHighScore(int numPlayers, int lastMarbleValue, long expectedHighScore)
        {
            var sut = new MarbleGame(numPlayers);

            while (sut.CurrentMarbleValue != lastMarbleValue)
            {
                sut.PlaceNextMarble();
            }


            sut.HighScore.Should().Be(expectedHighScore);
        }
    }
}