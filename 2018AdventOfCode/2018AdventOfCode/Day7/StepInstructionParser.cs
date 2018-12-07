using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace _2018AdventOfCode.Day7
{
    public class StepInstructionParser
    {
        public string GetStepOrder(IEnumerable<string> stepInstructions)
        {
            var nextInstructions = GetNextInstructions(stepInstructions);

            var stepOrder = "";
            while (nextInstructions.Any())
            {
                var instruction = nextInstructions
                    .Where(i => i.Previous.Count == 0 || i.Previous.All(p => stepOrder.Contains(p.Step)))
                    .MinBy(i => i.Step).FirstOrDefault();
                stepOrder += instruction.Step;
                nextInstructions = nextInstructions.Where(i => i != instruction).Concat(instruction.Next).ToList();
            }

            return stepOrder;
        }

        public int GetTimeToCompleteInstructions(IEnumerable<string> stepInstructions, int stepBaseTime, int numberOfElves)
        {
            var nextInstructions = GetNextInstructions(stepInstructions, stepBaseTime);

            var order = "";
            var elfWorkers = new List<Stack<char>>();
            for (var i = 0; i < numberOfElves; i++)
            {
                elfWorkers.Add(new Stack<char>());
            }

            var second = 0;
            while (nextInstructions.Any() || elfWorkers.Any(s => s.Count != 0))
            {
                foreach (var elfWork in elfWorkers)
                {
                    if (elfWork.TryPop(out var step) && elfWork.Count == 0)
                    {
                        order += step;
                    }
                }

                Stack<char> nextAvailableElf;
                StepInstruction nextAvailableInstruction;
                bool MoreWorkForElvesThisSecond()
                {
                    nextAvailableElf = elfWorkers.FirstOrDefault(s => s.Count == 0);
                    nextAvailableInstruction = nextInstructions.Where(i =>
                            (i.Previous.Count == 0 || i.Previous.All(p => order.Contains(p.Step))) &&
                            elfWorkers.TrueForAll(s => !s.Contains(i.Step)))
                        .MinBy(i => i.Step)
                        .FirstOrDefault();
                    return nextAvailableElf != null && nextAvailableInstruction != null;
                }

                while (MoreWorkForElvesThisSecond())
                {
                    for (var i = 0; i < nextAvailableInstruction.StepTime; i++)
                    {
                        nextAvailableElf.Push(nextAvailableInstruction.Step);
                    }

                    nextInstructions = nextInstructions.Where(i => i != nextAvailableInstruction).Concat(nextAvailableInstruction.Next).ToList();
                }

                second++;
            }

            return second - 1;
        }

        private List<StepInstruction> GetNextInstructions(IEnumerable<string> stepInstructions, int stepBaseTime = 0)
        {
            var instructions = new Dictionary<char, StepInstruction>();

            foreach (var rawInstruction in stepInstructions)
            {
                var pieces = rawInstruction.ToUpper().Split("STEP ");

                var step = pieces[1][0];
                var next = pieces[2][0];

                StepInstruction stepInstruction;
                if (instructions.ContainsKey(step))
                    stepInstruction = instructions[step];
                else
                {
                    stepInstruction = new StepInstruction(stepBaseTime)
                    {
                        Step = step
                    };
                    instructions.Add(step, stepInstruction);
                }

                StepInstruction nextInstruction;
                if (instructions.ContainsKey(next))
                {
                    nextInstruction = instructions[next];
                }
                else
                {
                    nextInstruction = new StepInstruction(stepBaseTime)
                    {
                        Step = next
                    };
                    instructions.Add(next, nextInstruction);
                }

                stepInstruction.Next.Add(nextInstruction);
                nextInstruction.Previous.Add(stepInstruction);
            }

            return instructions.Values.Where(i => i.Previous.Count == 0).ToList();
        }
    }
}