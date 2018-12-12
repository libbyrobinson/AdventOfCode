using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace _2018AdventOfCode.Day4
{
    public class GuardShiftTracker
    {
        private readonly Dictionary<int, Guard> _guards;

        public GuardShiftTracker(IEnumerable<string> rawGuardShiftLogs)
        {
            _guards = new Dictionary<int, Guard>();

            var orderedLogs = rawGuardShiftLogs
                .Select(l => l.Split(']'))
                .ToDictionary(dateAndAction => DateTime.Parse(dateAndAction[0].TrimStart('[')), dateAndAction => dateAndAction[1])
                .OrderBy(d => d.Key);

            var currentGuardId = 0;
            var fallAsleepMinute = 0;
            foreach (var orderedLog in orderedLogs)
            {
                if (orderedLog.Value.Contains("Guard #"))
                {
                    currentGuardId = int.Parse(orderedLog.Value.Split('#')[1].Split(' ')[0]);
                }
                else if (orderedLog.Value.Contains("falls asleep"))
                {
                    fallAsleepMinute = orderedLog.Key.Minute;
                }
                else if (orderedLog.Value.Contains("wakes up"))
                {
                    if (!_guards.ContainsKey(currentGuardId))
                    {
                        _guards.Add(currentGuardId, new Guard(currentGuardId));
                    }

                    _guards[currentGuardId].AddSleepingMinutes(fallAsleepMinute, orderedLog.Key.Minute);
                }
            }
        }

        public Guard FindGuardWithMostMinutesAsleep()
        {
            return _guards.MaxBy(g => g.Value.TotalMinutesAsleep).First().Value;
        }

        public Guard FindGuardMostFrequentlyAsleepAtSameMinute()
        {
            return _guards.MaxBy(g => g.Value.MostTimeAsleepAtAnyMinute).First().Value;
        }
    }
}