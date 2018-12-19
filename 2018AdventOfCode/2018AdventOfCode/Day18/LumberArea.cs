using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _2018AdventOfCode.Day18
{
    public class LumberArea
    {
        private char[,] _acres;
        private int _currentMinute;

        public LumberArea(List<string> input)
        {
            _acres = new char[input.First().Length, input.Count];

            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                var row = input[y];
                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    _acres[x, y] = row[x];
                }
            }

            _currentMinute = 0;
        }

        public void PassMinutes(int minute)
        {
            while (_currentMinute < minute)
            {
                PassMinute();
            }
        }

        public void PassMinute()
        {
            var newAcres = new char[_acres.GetLength(0), _acres.GetLength(1)];
            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    var currentAcre = _acres[x, y];
                    var adjacentAcres = GetAdjacentAcres(x, y);
                    if (IsOpen(currentAcre) && CountWoodedAreas(adjacentAcres) >= 3)
                    {
                        newAcres[x, y] = '|';
                    }
                    else if (IsWooded(currentAcre) && CountLumberyards(adjacentAcres) >= 3)
                    {
                        newAcres[x, y] = '#';
                    } else if (IsLumberyard(currentAcre) &&
                               (CountLumberyards(adjacentAcres) < 1 || CountWoodedAreas(adjacentAcres) < 1))
                    {
                        newAcres[x, y] = '.';
                    }
                    else
                    {
                        newAcres[x, y] = _acres[x, y];
                    }
                }
            }

            _acres = newAcres;
            _currentMinute++;
        }

        public int CountAllWoodedAreas()
        {
            return CountWoodedAreas(_acres.Cast<char>());
        }

        public int CountAllLumberyards()
        {
            return CountLumberyards(_acres.Cast<char>());
        }

        public string Print()
        {
            var stringBuilder = new StringBuilder();
            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                var line = "";
                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    line += _acres[x, y];
                }

                stringBuilder.AppendLine(line);
            }

            return stringBuilder.ToString();
        }

        private int CountLumberyards(IEnumerable<char> adjacentAcres)
        {
            return adjacentAcres.Count(a => a == '#');
        }

        private int CountWoodedAreas(IEnumerable<char> adjacentAcres)
        {
            return adjacentAcres.Count(a => a == '|');
        }

        private List<char> GetAdjacentAcres(int x, int y)
        {
            return new List<char?>
            {
                GetAcre(x - 1, y - 1),
                GetAcre(x, y - 1),
                GetAcre(x + 1, y - 1),
                GetAcre(x - 1, y),
                GetAcre(x + 1, y),
                GetAcre(x - 1, y + 1),
                GetAcre(x, y + 1),
                GetAcre(x + 1, y + 1)
            }.Where(a => a.HasValue).Select(a => a.Value).ToList();
        }

        private char? GetAcre(int x, int y)
        {
            if (x >= 0 && x < _acres.GetLength(0) && y >= 0 && y < _acres.GetLength(1))
                return _acres[x, y];
            return null;
        }

        private bool IsOpen(char currentAcre)
        {
            return currentAcre == '.';
        }

        private bool IsWooded(char currentAcre)
        {
            return currentAcre == '|';
        }

        private bool IsLumberyard(char currentAcre)
        {
            return currentAcre == '#';
        }
    }
}