using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace _2018AdventOfCode.Day18
{
    public class LumberAreaTests
    {
        private readonly ITestOutputHelper _output;

        public LumberAreaTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void should_count_wooden_areas_and_lumberyards_in_example()
        {
            var sut = new LumberArea(new List<string>
            {
                ".#.#...|#.",
                ".....#|##|",
                ".|..|...#.",
                "..|#.....#",
                "#.#|||#|#|",
                "...#.||...",
                ".|....|...",
                "||...#|.#|",
                "|.||||..|.",
                "...#.|..|."
            });

            _output.WriteLine("Initial State");
            _output.WriteLine(sut.Print());

            var minute = 0;
            while (minute < 10)
            {
                sut.PassMinute();
                minute++;
                _output.WriteLine($"Minute {minute}");
                _output.WriteLine(sut.Print());
            }
//
            var forestCount = sut.CountAllWoodedAreas();
            var lumberyardCount = sut.CountAllLumberyards();

            forestCount.Should().Be(37);
            lumberyardCount.Should().Be(31);

            (forestCount * lumberyardCount).Should().Be(1147);
        }

        [Fact]
        public void should_count_wooden_areas_and_lumberyards_in_big_input()
        {
            var sut = new LumberArea(PuzzleInputParser.ParseStrings("Day18/Input.txt"));
            sut.PassMinutes(10);

            var forestCount = sut.CountAllWoodedAreas();
            var lumberyardCount = sut.CountAllLumberyards();

            forestCount.Should().Be(709);
            lumberyardCount.Should().Be(502);

            (forestCount * lumberyardCount).Should().Be(355918);
        }

        [Fact]
        public void should_observe_change_pattern_over_many_minutes()
        {
            var sut = new LumberArea(PuzzleInputParser.ParseStrings("Day18/Input.txt"));
            
            var minute = 0;

            var forestCount = sut.CountAllWoodedAreas();
            var lumberyardCount = sut.CountAllLumberyards();

            while (minute < 1000)
            {
                sut.PassMinute();
                minute++;

                forestCount = sut.CountAllWoodedAreas();
                lumberyardCount = sut.CountAllLumberyards();

                _output.WriteLine($"Minute {minute} - {forestCount}");
                _output.WriteLine($"Minute {minute} - {lumberyardCount}");
            }

            // At minute 506, this starts to repeat for the forest counts
            // Minute 506 - 586
            // Minute 507 - 580
            // Minute 508 - 573
            // Minute 509 - 572
            // Minute 510 - 568
            // Minute 511 - 568
            // Minute 512 - 567
            // Minute 513 - 570
            // Minute 514 - 570
            // Minute 515 - 573
            // Minute 516 - 572
            // Minute 517 - 575
            // Minute 518 - 573
            // Minute 519 - 576
            // Minute 520 - 576
            // Minute 521 - 581
            // Minute 522 - 586
            // Minute 523 - 591
            // Minute 524 - 593
            // Minute 525 - 600
            // Minute 526 - 602
            // Minute 527 - 603
            // Minute 528 - 606
            // Minute 529 - 609
            // Minute 530 - 606
            // Minute 531 - 606
            // Minute 532 - 601
            // Minute 533 - 596

            // and this for the lumber counts
            // Minute 506 - 358
            // Minute 507 - 358
            // Minute 508 - 351
            // Minute 509 - 344
            // Minute 510 - 339
            // Minute 511 - 337
            // Minute 512 - 332
            // Minute 513 - 331
            // Minute 514 - 329
            // Minute 515 - 331
            // Minute 516 - 332
            // Minute 517 - 335
            // Minute 518 - 337
            // Minute 519 - 336
            // Minute 520 - 338
            // Minute 521 - 337
            // Minute 522 - 338
            // Minute 523 - 339
            // Minute 524 - 342
            // Minute 525 - 341
            // Minute 526 - 346
            // Minute 527 - 350
            // Minute 528 - 354
            // Minute 529 - 353
            // Minute 530 - 354
            // Minute 531 - 355
            // Minute 532 - 357
            // Minute 533 - 360

            var forestPatternStartingAt506 = new int[]
            {
                586,
                580,
                573,
                572,
                568,
                568,
                567,
                570,
                570,
                573,
                572,
                575,
                573,
                576,
                576,
                581,
                586,
                591,
                593,
                600,
                602,
                603,
                606,
                609,
                606,
                606,
                601,
                596,
            };

            var lumberyardPatternStartingAt506 = new int[]
            {
                358,
                358,
                351,
                344,
                339,
                337,
                332,
                331,
                329,
                331,
                332,
                335,
                337,
                336,
                338,
                337,
                338,
                339,
                342,
                341,
                346,
                350,
                354,
                353,
                354,
                355,
                357,
                360
            };

            // Figure out formula, verify it works
            forestPatternStartingAt506[(1000 - 506) % forestPatternStartingAt506.Length]
                .Should()
                .Be(forestCount);

            lumberyardPatternStartingAt506[(1000 - 506) % lumberyardPatternStartingAt506.Length]
                .Should()
                .Be(lumberyardCount);
        }

        [Fact]
        public void should_count_wooded_areas_and_lumberyards_after_1000000000_minutes()
        {
            var forestPatternStartingAt506 = new int[]
            {
                586,
                580,
                573,
                572,
                568,
                568,
                567,
                570,
                570,
                573,
                572,
                575,
                573,
                576,
                576,
                581,
                586,
                591,
                593,
                600,
                602,
                603,
                606,
                609,
                606,
                606,
                601,
                596,
            };

            var lumberyardPatternStartingAt506 = new int[]
            {
                358,
                358,
                351,
                344,
                339,
                337,
                332,
                331,
                329,
                331,
                332,
                335,
                337,
                336,
                338,
                337,
                338,
                339,
                342,
                341,
                346,
                350,
                354,
                353,
                354,
                355,
                357,
                360
            };

            var forestCount = forestPatternStartingAt506[(1000000000 - 506) % forestPatternStartingAt506.Length];
            var lumberyardCount = lumberyardPatternStartingAt506[(1000000000 - 506) % lumberyardPatternStartingAt506.Length];

            (forestCount * lumberyardCount).Should().Be(202806);
        }
    }
}