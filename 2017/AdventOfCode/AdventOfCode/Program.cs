using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            var day1 = new Day1_InverseCaptcha();
            var day1Part1Result = day1.CalculateSum_Part1();
            var day1part2Result = day1.CalculateSum_Part2();
            Console.WriteLine($"Day 1. Part 1: {day1Part1Result}. Part 2: {day1part2Result}.");

            var day2 = new Day2_CorruptionChecksum();
            var day2Part1Result = day2.CalculateChecksum_Part1();
            var day2Part2Result = day2.CalculateChecksum_Part2();
            Console.WriteLine($"Day 2. Part 1: {day2Part1Result}. Part 2: {day2Part2Result}.");

            var day3 = new Day3_SpiralMemory();
            var day3Part1Result = day3.CalculateSteps_Part1_Brute();
            var day3Part2Result = day3.CalculateSteps_Part2();
            Console.WriteLine($"Day 3. Part 1: {day3Part1Result}. Part 2: {day3Part2Result}.");

            var day4 = new Day4_HighEntropyPassphrases();
            var day4Part1Result = day4.CountValidPassphrases_Part1();
            var day4Part2Result = day4.CountValidPassphrases_Part2();
            Console.WriteLine($"Day 4. Part 1: {day4Part1Result}. Part 2: {day4Part2Result}.");

            var day5 = new Day5_TwistyTrampolines();
            var day5Part1Result = day5.CountStepsToExit_Part1();
            var day5Part2Result = day5.CountStepsToExit_Part2();
            Console.WriteLine($"Day 5. Part 1: {day5Part1Result}. Part 2: {day5Part2Result}.");

            var day6 = new Day6_MemoryReallocation();
            var day6Part1Result = day6.CountRedistributionCycles_Part1();
            var day6Part2Result = day6.CountRedistributionCycles_Part2();
            Console.WriteLine($"Day 6. Part 1: {day6Part1Result}. Part 2: {day6Part2Result}.");

            Console.ReadKey();
        }
    }
}
