using System.Collections.Generic;

namespace _2018AdventOfCode.Day12
{
    public class Pot
    {
        public int Number { get; set; }

        public Dictionary<long, bool> HasPlantsByGeneration { get; set; }
     
        public Pot LeftPot { get; set; }

        public Pot RightPot { get; set; }

        public char State(long generation) => HasPlantsByGeneration.ContainsKey(generation) && HasPlantsByGeneration[generation] ? '#' : '.';

        public string SurroundingPotState(long generation) =>
            $"{LeftPot?.LeftPot?.State(generation) ?? '.'}{LeftPot?.State(generation) ?? '.'}{State(generation)}{RightPot?.State(generation) ?? '.'}{RightPot?.RightPot?.State(generation) ?? '.'}";
    }

    public class PotGrowthRule
    {
        public string SurroundingPotState { get; set; }
        public bool HasPlant { get; set; }
    }
}