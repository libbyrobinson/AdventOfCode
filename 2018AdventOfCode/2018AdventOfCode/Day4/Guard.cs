using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace _2018AdventOfCode.Day4
{
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

        public int MostTimeAsleepAtAnyMinute
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