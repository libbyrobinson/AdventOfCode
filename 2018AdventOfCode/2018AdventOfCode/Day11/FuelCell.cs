using System;

namespace _2018AdventOfCode.Day11
{
    public class FuelCell
    {
        public FuelCell(int x, int y, int serialNumber)
        {
            XCoordinate = x;
            YCoordinate = y;

            RackId = XCoordinate + 10;

            var powerLevel = RackId * YCoordinate;
            powerLevel += serialNumber;
            powerLevel *= RackId;
            powerLevel = Math.Abs(powerLevel / 100 % 10);

            PowerLevel = powerLevel - 5;
        }

        public int XCoordinate { get; }
        public int YCoordinate { get; }
        private int RackId { get; }
        public int PowerLevel { get; }
        public int SummedPowerLevel { get; set; }
    }
}