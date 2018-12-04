using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day3
{
    public class PrototypeFabricTests
    {
        [Fact]
        public void ShouldParsePlan()
        {
            var plan = new Plan("#123 @ 3,2: 5x4");

            plan.Id.Should().Be("123");
            plan.DistanceFromLeft.Should().Be(3);
            plan.DistanceFromTop.Should().Be(2);
            plan.Width.Should().Be(5);
            plan.Height.Should().Be(4);
        }

        [Fact]
        public void ShouldCountPlanOverlapFromSimpleExample()
        {
            var plans = new List<string>
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            var fabric = new PrototypeFabric(12, plans);
            fabric.CountAreaOfOverlaps().Should().Be(4);
        }

        [Fact]
        public void ShouldCountPlanOverlapFromBigInput()
        {
            var plans = PuzzleInputParser.ParseStrings("Day3/Input.txt");
            var fabric = new PrototypeFabric(1000, plans);
            fabric.CountAreaOfOverlaps().Should().Be(116491);
        }

        [Fact]
        public void ShouldFindFirstNonOverlappingPlanFromBigInput()
        {
            var plans = PuzzleInputParser.ParseStrings("Day3/Input.txt");
            var fabric = new PrototypeFabric(1000, plans);
            fabric.GetFirstNonOverlappingPlanId().Should().Be("707");
        }
    }
}