using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day1
{
    public class FrequencyCalibration
    {
        public int ApplyFrequencyChanges(List<int> changes)
        {
            return changes.Sum();
        }

        public int ApplyFrequencyChangesUntilRepeatFrequency(List<int> changes)
        {
            var currentFrequency = 0;
            var frequencyHistory = new HashSet<int> {currentFrequency};
            var changeList = changes.ToList();
            while (true)
            {
                foreach (var change in changeList)
                {
                    currentFrequency += change;
                    if (frequencyHistory.Contains(currentFrequency))
                    {
                        return currentFrequency;
                    }

                    frequencyHistory.Add(currentFrequency);
                }
            }
        }
    }
}