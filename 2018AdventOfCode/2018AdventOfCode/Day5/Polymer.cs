using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2018AdventOfCode.Day5
{
    public class Polymer
    {
        private readonly List<char> _polymer;

        public Polymer(string polymer)
        {
            _polymer = polymer.ToList();
        }

        public int Units => _polymer.Count;

        public Task ReactAsync()
        {
            return Task.Run(() =>
            {
                for (var i = _polymer.Count - 1; i > 0; i--)
                {
                    if (i >= _polymer.Count) i--;

                    var currentUnit = _polymer[i];
                    var previousUnit = _polymer[i - 1];

                    if (char.IsUpper(currentUnit) && char.ToLower(currentUnit) == previousUnit ||
                        char.IsLower(currentUnit) && char.ToUpper(currentUnit) == previousUnit)
                    {
                        _polymer.RemoveAt(i);
                        _polymer.RemoveAt(i - 1);
                    }
                }
            });
        }
    }
}