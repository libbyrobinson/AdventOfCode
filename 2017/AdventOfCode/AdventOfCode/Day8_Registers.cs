using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day8_Registers
    {
        public int GetLargestRegistryValueAfterInstructions(IEnumerable<RegisterInstruction> instructions)
        {
            var registers = new Dictionary<string, int>();
            foreach (var instruction in instructions)
            {
                RunInstructionOnRegister(registers, instruction);
            }

            return registers.Values.Max();
        }

        public int GetLargestRegistryValueDuringInstructions(IEnumerable<RegisterInstruction> instructions)
        {
            var registers = new Dictionary<string, int>();
            var largest = 0;
            foreach (var instruction in instructions)
            {
                RunInstructionOnRegister(registers, instruction);
                var currentMax = registers.Values.Max();
                if (currentMax > largest)
                {
                    largest = currentMax;
                }
            }

            return largest;
        }

        private static void RunInstructionOnRegister(IDictionary<string, int> registers, RegisterInstruction instruction)
        {
            if (!registers.ContainsKey(instruction.RegisterToModify))
            {
                registers.Add(instruction.RegisterToModify, 0);
            }
            if (!registers.ContainsKey(instruction.ConditionRegister))
            {
                registers.Add(instruction.ConditionRegister, 0);
            }

            bool conditionMet;
            switch (instruction.ConditionOperand)
            {
                case OperandType.GreaterThan:
                    conditionMet = registers[instruction.ConditionRegister] > instruction.ConditionAmount;
                    break;
                case OperandType.LessThan:
                    conditionMet = registers[instruction.ConditionRegister] < instruction.ConditionAmount;
                    break;
                case OperandType.GreaterThanOrEqualTo:
                    conditionMet = registers[instruction.ConditionRegister] >= instruction.ConditionAmount;
                    break;
                case OperandType.LessThanOrEqualTo:
                    conditionMet = registers[instruction.ConditionRegister] <= instruction.ConditionAmount;
                    break;
                case OperandType.EqualTo:
                    conditionMet = registers[instruction.ConditionRegister] == instruction.ConditionAmount;
                    break;
                case OperandType.NotEqualTo:
                    conditionMet = registers[instruction.ConditionRegister] != instruction.ConditionAmount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (conditionMet)
            {
                switch (instruction.Operation)
                {
                    case OperationType.Increase:
                        registers[instruction.RegisterToModify] += instruction.Amount;
                        break;
                    case OperationType.Decrease:
                        registers[instruction.RegisterToModify] -= instruction.Amount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class RegisterInstruction
    {
        public RegisterInstruction(string rawInstruction)
        {
            var instructions = rawInstruction.Split(' ');

            RegisterToModify = instructions[0];

            switch (instructions[1])
            {
                case "inc":
                    Operation = OperationType.Increase;
                    break;
                case "dec":
                    Operation = OperationType.Decrease;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Amount = int.Parse(instructions[2]);
            ConditionRegister = instructions[4];

            switch (instructions[5])
            {
                case "<":
                    ConditionOperand = OperandType.LessThan;
                    break;
                case "<=":
                    ConditionOperand = OperandType.LessThanOrEqualTo;
                    break;
                case ">":
                    ConditionOperand = OperandType.GreaterThan;
                    break;
                case ">=":
                    ConditionOperand = OperandType.GreaterThanOrEqualTo;
                    break;
                case "==":
                    ConditionOperand = OperandType.EqualTo;
                    break;
                case "!=":
                    ConditionOperand = OperandType.NotEqualTo;
                    break;
            }

            ConditionAmount = int.Parse(instructions[6]);
        }

        public string RegisterToModify { get; set; }
        public OperationType Operation { get; set; }
        public int Amount { get; set; }
        public string ConditionRegister { get; set; }
        public OperandType ConditionOperand { get; set; }
        public int ConditionAmount { get; set; }
    }

    public enum OperandType
    {
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        EqualTo,
        NotEqualTo
    }

    public enum OperationType
    {
        Increase, 
        Decrease
    }
}