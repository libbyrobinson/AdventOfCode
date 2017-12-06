using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day6_MemoryReallocation
    {
        private string _rawData = "11\t11\t13\t7\t0\t15\t5\t5\t4\t4\t1\t1\t7\t1\t15\t11";
        private string _rawData2 = "0\t2\t7\t0";

        public int CountRedistributionCycles_Part1()
        {
            var memoryBanks = _rawData.Split(new[] {"\t"}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();

            var cycleCount = 0;
            var seenBefore = new Dictionary<string, object>();
            var key = GenerateKey(memoryBanks);
            while (!seenBefore.ContainsKey(key))
            {
                RedistributeBlocks(memoryBanks);

                cycleCount++;
                seenBefore.Add(key, null);
                key = GenerateKey(memoryBanks);
            }

            return cycleCount;
        }

        public int CountRedistributionCycles_Part2()
        {
            var memoryBanks = _rawData.Split(new[] { "\t" }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();

            var cycleCount = 0;
            var seenBefore = new Dictionary<string, object>();
            var key = GenerateKey(memoryBanks);
            while (!seenBefore.ContainsKey(key))
            {
                RedistributeBlocks(memoryBanks);

                cycleCount++;
                seenBefore.Add(key, null);
                key = GenerateKey(memoryBanks);
            }

            var targetKey = key;
            cycleCount = 0;
            do
            {
                RedistributeBlocks(memoryBanks);

                cycleCount++;
                key = GenerateKey(memoryBanks);

            } while (targetKey != key);

            return cycleCount;
        }

        private string GenerateKey(IEnumerable<int> memoryBanks)
        {
            return string.Join(".", memoryBanks);
        }

        private static void RedistributeBlocks(IList<int> memoryBanks)
        {
            var mostBlocks = memoryBanks.Max();
            var currentIndex = memoryBanks.IndexOf(mostBlocks);
            memoryBanks[currentIndex] = 0;
            while (mostBlocks > 0)
            {
                currentIndex = currentIndex + 1 >= memoryBanks.Count ? 0 : currentIndex + 1;
                memoryBanks[currentIndex]++;
                mostBlocks--;
            }
        }
    }
}