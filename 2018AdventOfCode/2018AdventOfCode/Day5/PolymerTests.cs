using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day5
{
    public class PolymerTests
    {
        [Fact]
        public async Task ShouldPerformPolymerReactionForSimpleExample()
        {
            var sut = new Polymer("dabAcCaCBAcCcaDA");
            await sut.ReactAsync();
            sut.Units.Should().Be(10);
        }

        [Fact]
        public async Task ShouldPerformPolymerReactionForBigInput()
        {
            var sut = new Polymer(PuzzleInputParser.ParseString("Day5/Input.txt"));
            await sut.ReactAsync();
            sut.Units.Should().Be(10774);
        }

        [Fact]
        public async Task ShouldPerformOptimizedPolymerReactionForSimpleExample()
        {
            var sut = new OptimizedPolymer("dabAcCaCBAcCcaDA");
            await sut.ReactAsync();
            sut.Units.Should().Be(4);
        }

        [Fact]
        public async Task ShouldPerformOptimizedPolymerReactionForBigInput()
        {
            var sut = new OptimizedPolymer(PuzzleInputParser.ParseString("Day5/Input.txt"));
            await sut.ReactAsync();
            sut.Units.Should().Be(5122);
        }
    }
}