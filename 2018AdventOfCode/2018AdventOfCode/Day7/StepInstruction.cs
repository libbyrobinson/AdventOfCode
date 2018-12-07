using System.Collections.Generic;

namespace _2018AdventOfCode.Day7
{
    public class StepInstruction
    {
        private readonly int _stepBaseTime;
        public StepInstruction(int stepBaseTime)
        {
            _stepBaseTime = stepBaseTime;
            Next = new List<StepInstruction>();
            Previous = new List<StepInstruction>();
        }

        public char Step { get; set; }
        public int StepTime => _stepBaseTime + (Step - 'A' + 1);

        public List<StepInstruction> Next { get; set; }
        public List<StepInstruction> Previous { get; set; }
    }
}