using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day8
{
    public class TreeTests
    {
        [Fact]
        public void ShouldCalculateMetadataSumFromSimpleExample()
        {
            var raw = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new Tree(raw);
            sut.MetadataSum.Should().Be(138);
        }

        [Fact]
        public void ShouldCalculateMetadataSumFromBigInput()
        {
            var raw = PuzzleInputParser.ParseString("Day8/Input.txt");
            var sut = new Tree(raw);
            sut.MetadataSum.Should().Be(40309);
        }

        [Fact]
        public void ShouldCalculateRootNodeValueFromSimpleExample()
        {
            var raw = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new Tree(raw);
            sut.RootNodeValue.Should().Be(66);
        }

        [Fact]
        public void ShouldCalculateRootNodeValueFromBigInput()
        {
            var raw = PuzzleInputParser.ParseString("Day8/Input.txt");
            var sut = new Tree(raw);
            sut.RootNodeValue.Should().Be(28779);
        }
    }
}