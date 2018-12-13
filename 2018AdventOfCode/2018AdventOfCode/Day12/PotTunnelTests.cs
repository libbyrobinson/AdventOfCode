using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day12
{
    public class PotTunnelTests
    {
        [Fact]
        public void ShouldGetAllPotsWithPlantsAfter20YearsFromSimpleExample()
        {
            var input = "#..#.#..##......###...###";
            var growthRules = new List<string>
            {
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #"
            };
            var sut = new PotTunnel(input, growthRules);

            sut.GetPotString(-3, 35).Should().Be("...#..#.#..##......###...###...........");

            sut.GrowNextGeneration();
            sut.GetPotString(-3, 35).Should().Be("...#...#....#.....#..#..#..#...........");

            sut.GrowUntilGeneration(13);
            sut.GetPotString(-3, 35).Should().Be("..#..###.#....#.#...#....#...#...#.....");

            sut.GrowUntilGeneration(20);
            sut.GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration().Should().Be(325);
        }

        [Fact]
        public void ShouldGetAllPotsWithPlantsAfter20YearsFromBigInput()
        {
            var input = "#.#.#...#..##..###.##.#...#.##.#....#..#.#....##.#.##...###.#...#######.....##.###.####.#....#.#..##";
            var growthRules = new List<string>
            {
                "#...# => #",
                "....# => .",
                "##..# => #",
                ".#.## => #",
                "##.## => .",
                "###.# => #",
                "..... => .",
                "...#. => .",
                ".#.#. => #",
                "#.##. => #",
                "..#.# => #",
                ".#... => #",
                "#.#.. => .",
                "##.#. => .",
                ".##.. => #",
                "#..#. => .",
                ".###. => .",
                "..#.. => .",
                "#.### => .",
                "..##. => .",
                ".#..# => #",
                ".##.# => .",
                ".#### => .",
                "...## => #",
                "#.#.# => #",
                "..### => .",
                "#..## => .",
                "####. => #",
                "##### => .",
                "###.. => #",
                "##... => #",
                "#.... => ."
            };
            var sut = new PotTunnel(input, growthRules);
            sut.GrowUntilGeneration(20);
            sut.GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration().Should().Be(3120);
        }

        [Fact]
        public void CheckForSumChangesYearByYear()
        {
            var input = "#.#.#...#..##..###.##.#...#.##.#....#..#.#....##.#.##...###.#...#######.....##.###.####.#....#.#..##";
            var growthRules = new List<string>
            {
                "#...# => #",
                "....# => .",
                "##..# => #",
                ".#.## => #",
                "##.## => .",
                "###.# => #",
                "..... => .",
                "...#. => .",
                ".#.#. => #",
                "#.##. => #",
                "..#.# => #",
                ".#... => #",
                "#.#.. => .",
                "##.#. => .",
                ".##.. => #",
                "#..#. => .",
                ".###. => .",
                "..#.. => .",
                "#.### => .",
                "..##. => .",
                ".#..# => #",
                ".##.# => .",
                ".#### => .",
                "...## => #",
                "#.#.# => #",
                "..### => .",
                "#..## => .",
                "####. => #",
                "##### => .",
                "###.. => #",
                "##... => #",
                "#.... => ."
            };
            var sut = new PotTunnel(input, growthRules);
            var previousSum = sut.GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration();
            var sumChangesByYear = new List<int>();
            for(int i = 0; i < 500; i++)
            {
                sut.GrowNextGeneration();
                var newSum = sut.GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration();
                sumChangesByYear.Add(newSum - previousSum);
                previousSum = newSum;
            }

            //after 101 years, looking at this list shows that each year after the sum just increases the sum by 59
            sumChangesByYear[100].Should().NotBe(59);
            sumChangesByYear[101].Should().Be(59);
            sumChangesByYear[102].Should().Be(59);
            sumChangesByYear[103].Should().Be(59);
        }

        [Fact]
        public void ShouldGetAllPotsWithPlantsAfter50BillionYearsFromBigInput()
        {
            var input = "#.#.#...#..##..###.##.#...#.##.#....#..#.#....##.#.##...###.#...#######.....##.###.####.#....#.#..##";
            var growthRules = new List<string>
            {
                "#...# => #",
                "....# => .",
                "##..# => #",
                ".#.## => #",
                "##.## => .",
                "###.# => #",
                "..... => .",
                "...#. => .",
                ".#.#. => #",
                "#.##. => #",
                "..#.# => #",
                ".#... => #",
                "#.#.. => .",
                "##.#. => .",
                ".##.. => #",
                "#..#. => .",
                ".###. => .",
                "..#.. => .",
                "#.### => .",
                "..##. => .",
                ".#..# => #",
                ".##.# => .",
                ".#### => .",
                "...## => #",
                "#.#.# => #",
                "..### => .",
                "#..## => .",
                "####. => #",
                "##### => .",
                "###.. => #",
                "##... => #",
                "#.... => ."
            };
            var sut = new PotTunnel(input, growthRules);
            sut.GrowUntilGeneration(101);
            var sumAfter100Years = sut.GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration();

            var remainingYears = 50000000000 - 101;

            var finalSum = sumAfter100Years + (remainingYears * 59);
            finalSum.Should().Be(2950000001598);
        }
    }
}