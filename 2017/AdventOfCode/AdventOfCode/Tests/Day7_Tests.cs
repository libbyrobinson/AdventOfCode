using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.PuzzleInput;
using FluentAssertions;
using Xunit;

namespace AdventOfCode
{
    public class Day7_Tests
    {
        private readonly Day7_RecursiveCircus _sut;

        public Day7_Tests()
        {
            _sut = new Day7_RecursiveCircus();    
        }

        [Theory]
        [MemberData(nameof(GetDay7Data))]
        public void Day7_Part1(IEnumerable<Day7_RecursiveCircus.Program> programs, string expectedBottom, int expectedWeightDifference)
        {
            var bottomTower = _sut.GetBottomTowerName(programs);
            bottomTower.Should().Be(expectedBottom);
        }

        [Theory]
        [MemberData(nameof(GetDay7Data))]
        public void Day7_Part2(IEnumerable<Day7_RecursiveCircus.Program> programs, string expectedBottom, int expectedWeightDifference)
        {
            var weightDifference = _sut.GetCorrectWeightOfOffTower(programs);
            weightDifference.Should().Be(expectedWeightDifference);
        }

        public static IEnumerable<object[]> GetDay7Data()
        {
            yield return new object[]
            {
                new List<Day7_RecursiveCircus.Program>
                {
                    new Day7_RecursiveCircus.Program {Name="pbga", MyWeight = 66, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="xhth", MyWeight = 57, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="ebii", MyWeight = 61, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="havc", MyWeight = 66, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="ktlj", MyWeight = 57, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="fwft", MyWeight = 72, ProgramNamesOnDisc = new List<string> {"ktlj", "cntj", "xhth"}},
                    new Day7_RecursiveCircus.Program {Name="qoyq", MyWeight = 66, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="padx", MyWeight = 45, ProgramNamesOnDisc = new List<string> {"pbga", "havc", "qoyq"}},
                    new Day7_RecursiveCircus.Program {Name="tknk", MyWeight = 41, ProgramNamesOnDisc = new List<string> {"ugml", "padx", "fwft"}},
                    new Day7_RecursiveCircus.Program {Name="jptl", MyWeight = 61, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="ugml", MyWeight = 68, ProgramNamesOnDisc = new List<string> {"gyxo", "ebii", "jptl"}},
                    new Day7_RecursiveCircus.Program {Name="gyxo", MyWeight = 61, ProgramNamesOnDisc = new List<string>()},
                    new Day7_RecursiveCircus.Program {Name="cntj", MyWeight = 57, ProgramNamesOnDisc = new List<string>()},
                },
                "tknk",
                60
            };

            var input = PuzzleInputParser.Parse("Day7Input.txt");
            var lines = input.Split(new[] { "\r\n" }, StringSplitOptions.None)
                .ToList();
            var programs = new List<Day7_RecursiveCircus.Program>();
            foreach (var line in lines)
            {
                var program = new Day7_RecursiveCircus.Program
                {
                    Name = line.Substring(0, line.IndexOf("(")).Trim()
                };
                var anyStackedOnTop = line.IndexOf("->");
                if (anyStackedOnTop != -1)
                {
                    anyStackedOnTop += 2;
                    var stackedOnTop = line.Substring(anyStackedOnTop, line.Length-anyStackedOnTop).Replace(" ", "").Split(',');
                    program.ProgramNamesOnDisc = stackedOnTop.ToList();
                }
                program.MyWeight = int.Parse(line.Split('(', ')')[1]);
                programs.Add(program);
            }

            yield return new object[]
            {
                programs,
                "wiapj",
                1072
            };
        }
    }
}