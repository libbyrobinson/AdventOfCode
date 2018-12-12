using System;
using System.Collections.Generic;
using System.IO;
using MoreLinq;

namespace _2018AdventOfCode.Day10
{
    public class Sky
    {
        private readonly List<PointOfLight> _pointsOfLight;

        public Sky(List<PointOfLight> pointsOfLight)
        {
            PointsMovingTogether = true;
            Seconds = 0;
            _pointsOfLight = pointsOfLight;
        }

        public void MoveTimeUntilStarsSpellMessage()
        {
            while (PointsMovingTogether)
            {
                OneSecondForward();
            }
            OneSecondBack();
        }

        public int Seconds { get; private set; }
        
        private bool PointsMovingTogether { get; set; }

        private void OneSecondForward()
        {
            Seconds++;
            var preMovePointArea = TotalPointArea();
            foreach (var pointOfLight in _pointsOfLight)
            {
                pointOfLight.Move();
            }
            var postMovePointArea = TotalPointArea();
            if (postMovePointArea > preMovePointArea)
            {
                PointsMovingTogether = false;
            }
        }

        private void OneSecondBack()
        {
            Seconds--;
            foreach (var pointOfLight in _pointsOfLight)
            {
                pointOfLight.ReverseMove();
            }
        }

        private decimal TotalPointArea()
        {
            return Math.Abs(Leftest - Rightest) * Math.Abs(Highest - Lowest);
        }

        private long Leftest => _pointsOfLight.MinBy(p => p.CurrentX).First().CurrentX;
        private long Rightest => _pointsOfLight.MaxBy(p => p.CurrentX).First().CurrentX;
        private long Highest => _pointsOfLight.MinBy(p => p.CurrentY).First().CurrentY;
        private long Lowest => _pointsOfLight.MaxBy(p => p.CurrentY).First().CurrentY;

        public void Print()
        {
            var grid = new char?[Math.Abs(Highest - Lowest) + 1, Math.Abs(Rightest-Leftest) + 1]; //[Y,X]

            //make everything positive
            var xOffset = Leftest * -1;
            var yOffset = Highest * -1;

            foreach (var pointOfLight in _pointsOfLight)
            {
                grid[pointOfLight.CurrentY + yOffset, pointOfLight.CurrentX + xOffset] = '#';
            }

            using (var streamWriter = new StreamWriter("Day10/Output.txt"))
            {
                for (var y = 0; y < grid.GetLength(0); y++)
                {
                    var line = "";
                    for (var x = 0; x < grid.GetLength(1); x++)
                    {
                        if (grid[y, x].HasValue)
                            line += grid[y, x];
                        else
                            line += ".";
                    }

                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}