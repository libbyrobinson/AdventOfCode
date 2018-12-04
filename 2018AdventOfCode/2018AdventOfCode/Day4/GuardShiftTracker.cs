using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            return _guards.MaxBy(g => g.Value.MostDaysAsleepAtSameMinute).First().Value;
        }
    }

    public class Guard
    {
        public Guard(int id)
        {
            Id = id;
            SleepingMinuteTracker = new Dictionary<int, int>();
            for (var minute = 0; minute < 59; minute++)
            {
                SleepingMinuteTracker.Add(minute, 0);
            }
        }

        public int Id { get; set; }
        public Dictionary<int, int> SleepingMinuteTracker { get; set; }

        public int TotalMinutesAsleep
        {
            get { return SleepingMinuteTracker.Sum(m => m.Value); }
        }

        public int MinuteAsleepMost
        {
            get { return SleepingMinuteTracker.MaxBy(s => s.Value).First().Key; }
        }

        public int MostDaysAsleepAtSameMinute
        {
            get { return SleepingMinuteTracker.MaxBy(s => s.Value).First().Value; }
        }

        public void AddSleepingMinutes(int fallAsleepMinute, int wakeMinute)
        {
            for (var minute = fallAsleepMinute; minute < wakeMinute; minute++)
            {
                SleepingMinuteTracker[minute]++;
            }
        }
    }
}