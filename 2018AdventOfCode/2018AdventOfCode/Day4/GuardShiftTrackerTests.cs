﻿using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day4
{
    public class GuardShiftTrackerTests
    {
        [Fact]
        public void ShouldFindSleepiestGuardFromExample()
        {
            var exampleShiftLogs = new List<string>
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };

            var sut = new GuardShiftTracker(exampleShiftLogs);

            var guard = sut.FindGuardWithMostMinutesAsleep();

            guard.Id.Should().Be(10);
            guard.MinuteAsleepMost.Should().Be(24);
            (guard.Id * guard.MinuteAsleepMost).Should().Be(240);
        }

        [Fact]
        public void ShouldFindSleepiestGuardFromBigInput()
        {
            var shiftLogs = PuzzleInputParser.ParseStrings("Day4/Input.txt");
            var sut = new GuardShiftTracker(shiftLogs);

            var guard = sut.FindGuardWithMostMinutesAsleep();

            guard.Id.Should().Be(3557);
            guard.MinuteAsleepMost.Should().Be(30);
            (guard.Id * guard.MinuteAsleepMost).Should().Be(106710);
        }

        [Fact]
        public void ShouldFindGuardMostFrequentlyAsleepAtSameMinuteFromExample()
        {
            var exampleShiftLogs = new List<string>
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };

            var sut = new GuardShiftTracker(exampleShiftLogs);

            var guard = sut.FindGuardMostFrequentlyAsleepAtSameMinute();

            guard.Id.Should().Be(99);
            guard.MinuteAsleepMost.Should().Be(45);
            (guard.Id * guard.MinuteAsleepMost).Should().Be(4455);
        }

        [Fact]
        public void ShouldFindGuardMostFrequentlyAsleepAtSameMinuteFromBigInput()
        {
            var shiftLogs = PuzzleInputParser.ParseStrings("Day4/Input.txt");
            var sut = new GuardShiftTracker(shiftLogs);

            var guard = sut.FindGuardMostFrequentlyAsleepAtSameMinute();

            guard.Id.Should().Be(269);
            guard.MinuteAsleepMost.Should().Be(39);
            (guard.Id * guard.MinuteAsleepMost).Should().Be(10491);
        }
    }
}