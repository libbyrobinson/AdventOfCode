using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day3
{
    public class PrototypeFabric
    {
        private readonly int _fabricSize;
        private readonly string[,] _fabric; // [row,column]
        private readonly List<Plan> _plans;
        private int _overlapCount;

        public PrototypeFabric(int fabricSize, IEnumerable<string> rawPlans)
        {
            _fabricSize = fabricSize;
            _overlapCount = 0;
            _fabric = new string[_fabricSize, _fabricSize];
            _plans = new List<Plan>();
            foreach (var rawPlan in rawPlans)
            {
                var plan = new Plan(rawPlan);
                AddPlanToFabric(plan);
                _plans.Add(plan);
            }
        }

        private void AddPlanToFabric(Plan plan)
        {
            var startingRow = plan.DistanceFromTop;
            var startingColumn = plan.DistanceFromLeft;
            for (var row = startingRow; row < plan.Height + startingRow; row++)
            {
                for (var column = startingColumn; column < plan.Width + startingColumn; column++)
                {
                    if (_fabric[row, column] == null)
                    {
                        _fabric[row, column] = plan.Id;
                    }
                    else
                    {
                        plan.HasOverlap = true;
                        if (_fabric[row, column] != "X")
                        {
                            _plans.First(p => p.Id == _fabric[row, column]).HasOverlap = true;
                            _fabric[row, column] = "X";
                            _overlapCount++;
                        }
                    }
                }
            }
        }

        public int CountAreaOfOverlaps()
        {
            return _overlapCount;
        }

        public string GetFirstNonOverlappingPlanId()
        {
            return _plans.FirstOrDefault(p => p.HasOverlap == false)?.Id;
        }
    }
}