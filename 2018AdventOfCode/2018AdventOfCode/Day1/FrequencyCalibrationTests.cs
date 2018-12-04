using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day1
{
    public class FrequencyCalibrationTests
    {
        private readonly FrequencyCalibration _sut;
        private readonly List<int> _input;

        public FrequencyCalibrationTests()
        {
            _sut = new FrequencyCalibration();
            _input = PuzzleInputParser.ParseInts("Day1/Input.txt");
        }

        [Fact]
        public void ShouldApplyFrequencyChanges()
        {
            _sut.ApplyFrequencyChanges(_input).Should().Be(587);
        }

        [Fact]
        public void ShouldFindFirstFrequencyReachedTwice()
        {
            _sut.ApplyFrequencyChangesUntilRepeatFrequency(_input).Should().Be(83130);
        }
    }
}