using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day7
{
    public class StepInstructionParserTests
    {
        private readonly StepInstructionParser _sut;

        public StepInstructionParserTests()
        {
            _sut = new StepInstructionParser();
        }

        [Fact]
        public void ShouldDetermineStepOrderForExampleInput()
        {
            var instructions = new List<string>
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            _sut.GetStepOrder(instructions).Should().Be("CABDFE");
        }

        [Fact]
        public void ShouldDetermineStepOrderForBigInput()
        {
            _sut.GetStepOrder(PuzzleInputParser.ParseStrings("Day7/Input.txt")).Should().Be("FHICMRTXYDBOAJNPWQGVZUEKLS");
        }

        [Fact]
        public void ShouldDetermineStepTimeFromExampleInput()
        {
            var instructions = new List<string>
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };
            _sut.GetTimeToCompleteInstructions(instructions, 0, 2).Should().Be(15);
        }

        [Fact]
        public void ShouldDetermineStepForBigInput()
        {
            _sut.GetTimeToCompleteInstructions(PuzzleInputParser.ParseStrings("Day7/Input.txt"), 60, 5).Should().Be(946);
        }
    }
}