using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day2
{
    public class BoxChecksumTests
    {
        private readonly BoxWarehouse _sut;
        private readonly List<string> _input;

        public BoxChecksumTests()
        {
            _sut = new BoxWarehouse();
            _input = PuzzleInputParser.ParseStrings("Day2/Input.txt").ToList();
        }

        [Fact]
        public void ShouldCalculateChecksumFromExample()
        {
            var exampleInputs = new List<string>
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
            _sut.CalculateChecksum(exampleInputs).Should().Be(12);
        }

        [Fact]
        public void ShouldCalculateChecksumFromBigInput()
        {
            _sut.CalculateChecksum(_input).Should().Be(6225);
        }

        [Fact]
        public void ShouldFindPrototypeFabricBoxesFromExample()
        {
            var exampleInputs = new List<string>
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz "
            };

            _sut.FindCommonLettersInPrototypeFabricBoxes(exampleInputs).Should().Be("fgij");
        }

        [Fact]
        public void ShouldFindPrototypeFabricBoxesFromBigInput()
        {
            _sut.FindCommonLettersInPrototypeFabricBoxes(_input).Should().Be("revtaubfniyhsgxdoajwkqilp");
        }
    }
}