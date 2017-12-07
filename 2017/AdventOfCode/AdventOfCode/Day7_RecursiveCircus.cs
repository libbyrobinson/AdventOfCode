using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode
{
    public class Day7_RecursiveCircus
    {
        public string GetBottomTowerName(IEnumerable<Program> programs)
        {
            return GetBottomTower(programs).Name;
        }

        public int GetCorrectWeightOfOffTower(IEnumerable<Program> programs)
        {
            var bottomTower = GetBottomTower(programs);
            FillTowersOnDisc(bottomTower, programs);

            var badProgram = bottomTower;
            int targetWeight;
            do
            {
                var newBadProgram = badProgram.GetOffBalancedProgram;
                targetWeight = badProgram.GetTargetWeight;
                badProgram = newBadProgram;
            } while (!badProgram.IsBalanced);
            
            return badProgram.MyWeight + (targetWeight - badProgram.TotalTowerWeight);
        }

        private Program GetBottomTower(IEnumerable<Program> programs)
        {
            foreach (var program in programs)
            {
                if (programs.Any(p => p.ProgramNamesOnDisc.Any(n => n == program.Name))) { continue; }

                return program;
            }

            return null;
        }

        private void FillTowersOnDisc(Program program, IEnumerable<Program> programs)
        {
            foreach (var nameOnDisc in program.ProgramNamesOnDisc)
            {
                var match = programs.FirstOrDefault(p => p.Name == nameOnDisc);
                program.ProgramsStackedOnDisc.Add(match);
                FillTowersOnDisc(match, programs);
            }
        }

        public class Program
        {
            public Program()
            {
                ProgramNamesOnDisc = new List<string>();
                ProgramsStackedOnDisc = new List<Program>();
            }

            public string Name { get; set; }
            public int MyWeight { get; set; }
            public List<string> ProgramNamesOnDisc { get; set; }
            public List<Program> ProgramsStackedOnDisc { get; set; }

            public int TotalTowerWeight
            {
                get
                {
                    return MyWeight + ProgramsStackedOnDisc.Sum(program => program.TotalTowerWeight);
                }
            }

            public bool IsBalanced
            {
                get { return ProgramsStackedOnDisc.DistinctBy(p => p.TotalTowerWeight).Count() == 1; }
            }

            public Program GetOffBalancedProgram
            {
                get
                {
                    return ProgramsStackedOnDisc.FirstOrDefault(p => ProgramsStackedOnDisc.Count(c => p.TotalTowerWeight == c.TotalTowerWeight) == 1);
                }
            }

            public int GetTargetWeight
            {
                get
                {
                    var offBalance = GetOffBalancedProgram;
                    return ProgramsStackedOnDisc.First(p => p.TotalTowerWeight != offBalance.TotalTowerWeight).TotalTowerWeight;
                }
            }
        }
    }
}