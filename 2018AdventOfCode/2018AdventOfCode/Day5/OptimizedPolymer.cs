using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq;

namespace _2018AdventOfCode.Day5
{
    public class OptimizedPolymer
    {
        private readonly Dictionary<char, Polymer> _optimizedPolymers;

        public OptimizedPolymer(string originalPolymer)
        {
            _optimizedPolymers = new Dictionary<char, Polymer>();

            var distinctUnits = originalPolymer.ToLower().ToList().Distinct();
            foreach (var character in distinctUnits)
            {
                var removedUnitPolymer = originalPolymer
                    .Replace(character.ToString(), "")
                    .Replace(char.ToUpper(character).ToString(), "");
                _optimizedPolymers.Add(character, new Polymer(removedUnitPolymer));
            }
        }

        public int Units
        {
            get { return _optimizedPolymers.Values.MinBy(p => p.Units).First().Units; }
        }

        public async Task ReactAsync()
        {
            var reactions = new List<Task>();

            foreach (var optimizedPolymer in _optimizedPolymers)
            {
                reactions.Add(optimizedPolymer.Value.ReactAsync());
            }

            await Task.WhenAll(reactions);
        }
    }
}