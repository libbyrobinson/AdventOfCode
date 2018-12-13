using System.Collections.Generic;

namespace _2018AdventOfCode.Day12
{
    public class PotTunnel
    {
        private long _currentGeneration;
        private readonly Pot _potZero;
        private readonly List<PotGrowthRule> _potGrowthRules;

        public PotTunnel(string input, IEnumerable<string> growthRules)
        {
            _currentGeneration = 0;
            Pot previousPot = null;
            for (int i = 0; i < input.Length; i++)
            {
                var nextPot = new Pot
                {
                    Number = i,
                    HasPlantsByGeneration = new Dictionary<long, bool>
                    {
                        {_currentGeneration, input[i] == '#'}
                    },
                    LeftPot = previousPot
                };
                if (previousPot != null)
                {
                    previousPot.RightPot = nextPot;
                }
                else
                {
                    _potZero = nextPot;
                }

                previousPot = nextPot;
            }

            _potGrowthRules = new List<PotGrowthRule>();
            foreach (var growthRule in growthRules)
            {
                var state = growthRule.Split("=>");
                _potGrowthRules.Add(new PotGrowthRule
                {
                    SurroundingPotState = state[0].Trim(),
                    HasPlant = state[1].Trim() == "#"
                });
            }
        }

        public void GrowUntilGeneration(long desiredGeneration)
        {
            while (_currentGeneration < desiredGeneration)
            {
                GrowNextGeneration();
            }
        }

        public void GrowNextGeneration()
        {
            _currentGeneration++;

            CheckRulesOnPot(_potZero);
            CheckRulesMovingRight(_potZero);
            CheckRulesMovingLeft(_potZero);

        }

        public int GetSumOfAllPotNumbersThatCountainPlantsInCurrentGeneration()
        {
            int plantNumberSum = 0;
            if (_potZero.HasPlantsByGeneration[_currentGeneration])
            {
                plantNumberSum += _potZero.Number;
            }

            //move right
            var currentPlant = _potZero.RightPot;
            while (currentPlant != null)
            {
                if (currentPlant.HasPlantsByGeneration[_currentGeneration])
                {
                    plantNumberSum += currentPlant.Number;
                }

                currentPlant = currentPlant.RightPot;
            }

            //move left
            currentPlant = _potZero.LeftPot;
            while (currentPlant != null)
            {
                if (currentPlant.HasPlantsByGeneration[_currentGeneration])
                {
                    plantNumberSum += currentPlant.Number;
                }

                currentPlant = currentPlant.LeftPot;
            }

            return plantNumberSum;
        }

        private void CheckRulesOnPot(Pot pot)
        {
            foreach (var potGrowthRule in _potGrowthRules)
            {
                if (potGrowthRule.SurroundingPotState == pot.SurroundingPotState(_currentGeneration - 1))
                {
                    pot.HasPlantsByGeneration.Add(_currentGeneration, potGrowthRule.HasPlant);
                    return;
                }
            }

            pot.HasPlantsByGeneration.Add(_currentGeneration, false);
        }

        private void CheckRulesMovingRight(Pot pot)
        {
            var currentPot = pot;
            while (currentPot.RightPot != null)
            {
                currentPot = currentPot.RightPot;
                CheckRulesOnPot(currentPot);
            }

            //Check if new pots need to be added, if something grew
            var extraPot = new Pot
            {
                Number = currentPot.Number + 1,
                HasPlantsByGeneration = new Dictionary<long, bool>(),
                LeftPot = currentPot
            };
            extraPot.RightPot = new Pot
            {
                Number = currentPot.Number + 2,
                HasPlantsByGeneration = new Dictionary<long, bool>(),
                LeftPot = extraPot
            };

            CheckRulesOnPot(extraPot);
            CheckRulesOnPot(extraPot.RightPot);

            if (extraPot.HasPlantsByGeneration[_currentGeneration] ||
                extraPot.RightPot.HasPlantsByGeneration[_currentGeneration])
            {
                currentPot.RightPot = extraPot;
            }
        }

        private void CheckRulesMovingLeft(Pot pot)
        {
            var currentPot = pot;
            while (currentPot.LeftPot != null)
            {
                currentPot = currentPot.LeftPot;
                CheckRulesOnPot(currentPot);
            }

            //Check if new pots need to be added, if something grew
            var extraPot = new Pot
            {
                Number = currentPot.Number - 1,
                HasPlantsByGeneration = new Dictionary<long, bool>(),
                RightPot = currentPot
            };
            extraPot.LeftPot = new Pot
            {
                Number = currentPot.Number - 2,
                HasPlantsByGeneration = new Dictionary<long, bool>(),
                RightPot = extraPot
            };

            CheckRulesOnPot(extraPot);
            CheckRulesOnPot(extraPot.LeftPot);

            if (extraPot.HasPlantsByGeneration[_currentGeneration] ||
                extraPot.LeftPot.HasPlantsByGeneration[_currentGeneration])
            {
                currentPot.LeftPot = extraPot;
            }
        }

        public string GetPotString(int left, int right)
        {
            var potString = $"{_potZero.State(_currentGeneration)}";

            var leftPot = _potZero.LeftPot;
            for (int i = -1; i >= left; i--)
            {
                if (leftPot != null)
                {
                    potString = $"{leftPot.State(_currentGeneration)}{potString}";
                    leftPot = leftPot.LeftPot;
                }
                else
                {
                    potString = $".{potString}";
                }
            }

            var rightPot = _potZero.RightPot;
            for (int i = 1; i <= right; i++)
            {
                if (rightPot != null)
                {
                    potString += $"{rightPot.State(_currentGeneration)}";
                    rightPot = rightPot.RightPot;
                }
                else
                {
                    potString += ".";
                }
            }

            return potString;
        }
    }
}