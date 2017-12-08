using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.PuzzleInput;
using FluentAssertions;
using Xunit;

namespace AdventOfCode
{
    public class Day8_Tests
    {
        private Day8_Registers _sut;

        public Day8_Tests()
        {
            _sut = new Day8_Registers();
        }

        [Theory]
        [InlineData("b inc 5 if a > 1", "b", OperationType.Increase, 5, "a", OperandType.GreaterThan, 1)]
        [InlineData("a inc 1 if b < 5", "a", OperationType.Increase, 1, "b", OperandType.LessThan, 5)]
        [InlineData("c dec -10 if a >= 1", "c", OperationType.Decrease, -10, "a", OperandType.GreaterThanOrEqualTo, 1)]
        [InlineData("c inc -20 if c == 10", "c", OperationType.Increase, -20, "c", OperandType.EqualTo, 10)]
        public void ParseInstruction(
            string rawInstruction,
            string registerToModify,
            OperationType operation,
            int amount,
            string conditionRegister,
            OperandType conditionOperand,
            int conditionAmount)
        {
            var instruction = new RegisterInstruction(rawInstruction);

            instruction.RegisterToModify.Should().Be(registerToModify);
            instruction.Operation.Should().Be(operation);
            instruction.Amount.Should().Be(amount);
            instruction.ConditionRegister.Should().Be(conditionRegister);
            instruction.ConditionOperand.Should().Be(conditionOperand);
            instruction.ConditionAmount.Should().Be(conditionAmount);
        }

        [Theory]
        [MemberData(nameof(GetDay8Data))]
        public void CheckLargestValues(IEnumerable<RegisterInstruction> instructions, int expectedAfter, int expectedDuring)
        {
            _sut.GetLargestRegistryValueAfterInstructions(instructions).Should().Be(expectedAfter);
            _sut.GetLargestRegistryValueDuringInstructions(instructions).Should().Be(expectedDuring);
        }
        
        public static IEnumerable<object[]> GetDay8Data()
        {
            yield return new object[]
            {
                new List<RegisterInstruction>
                {
                    new RegisterInstruction("b inc 5 if a > 1"),
                    new RegisterInstruction("a inc 1 if b < 5"),
                    new RegisterInstruction("c dec -10 if a >= 1"),
                    new RegisterInstruction("c inc -20 if c == 10")
                },
                1,
                10
            };

            var input = PuzzleInputParser.Parse("Day8Input.txt");
            var lines = input
                .Split(new[] { "\r\n" }, StringSplitOptions.None)
                .ToList();

            yield return new object[]
            {
                lines.Select(l => new RegisterInstruction(l)),
                3745,
                4644
            };
        }
    }
}