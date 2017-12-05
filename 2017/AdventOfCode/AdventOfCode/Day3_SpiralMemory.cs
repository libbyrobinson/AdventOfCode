using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode
{
    public class Day3_SpiralMemory
    {
        public int CalculateSteps_Part1_Clever()
        {
            var targetInput = 347991;

            var squareSize = int.Parse(Math.Ceiling(Math.Sqrt(targetInput)).ToString());
            if (squareSize % 2 == 0)
            {
                squareSize = squareSize++;
            }

            var maxSteps = squareSize - 1;

            var quarterSequence = new List<int>();

            var currentSequenceToAdd = maxSteps;
            while (currentSequenceToAdd > maxSteps / 2)
            {
                quarterSequence.Add(currentSequenceToAdd);
                currentSequenceToAdd--;
            }

            while (currentSequenceToAdd < maxSteps)
            {
                quarterSequence.Add(currentSequenceToAdd);
                currentSequenceToAdd++;
            }

            var fullSequence = new List<int>();
            fullSequence.AddRange(quarterSequence);
            fullSequence.AddRange(quarterSequence);
            fullSequence.AddRange(quarterSequence);
            fullSequence.AddRange(quarterSequence);

            return fullSequence[squareSize * squareSize - targetInput];
        }

        public int CalculateSteps_Part1_Brute()
        {
            var input = 347991;

            var spiralMatrix = new Matrix();

            var currentCoordinate = spiralMatrix.AddNext();
            while (currentCoordinate.Value != input)
            {
                currentCoordinate = spiralMatrix.AddNext();
            }

            return currentCoordinate.GetStepsToMiddle();
        }

        public int CalculateSteps_Part2()
        {
            var input = 347991;

            var spiralMatrix = new Matrix();

            var currentCoordinate = spiralMatrix.AddNext();
            while (currentCoordinate.SurroundingSum <= input)
            {
                currentCoordinate = spiralMatrix.AddNext();
            }

            return currentCoordinate.SurroundingSum;
        }
    }

    public class MatrixCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SurroundingSum { get; set; }
        public int Value { get; set; }

        public int GetStepsToMiddle()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }
    }

    public class Matrix 
    {
        private Dictionary<Tuple<int,int>, MatrixCoordinate> _matrix { get; }
        private int CurrentX { get; set; }
        private int CurrentY { get; set; }
        private int CurrentSize { get; set; }
        private int CurrentValue { get; set; }
        private string CurrentDirection { get; set; }
        private int CurrentDirectionCount { get; set; }

        public Matrix()
        {
            _matrix = new Dictionary<Tuple<int, int>, MatrixCoordinate>
            {
                {
                    new Tuple<int, int>(0, 0), new MatrixCoordinate
                    {
                        X = 0,
                        Y = 0,
                        Value = 1,
                        SurroundingSum = 1
                    }
                }
            };
            CurrentX = 0;
            CurrentY = 0;
            CurrentSize = 1;
            CurrentValue = 1;
            CurrentDirection = "right";
            CurrentDirectionCount = 0;
        }

        public MatrixCoordinate AddNext()
        {
            if (CurrentDirectionCount >= CurrentSize)
            {
                TurnCornerCounterclockwise();
            }

            IncrementXAndYInProperDirection();
            IncrementValue();

            var coordinate = new MatrixCoordinate
            {
                X = CurrentX,
                Y = CurrentY,
                Value = CurrentValue,
                SurroundingSum = CalculateSurroundingSumOfCurrentCoordinate()
            };

            _matrix.Add(new Tuple<int, int>(coordinate.X, coordinate.Y), coordinate);

            IncrementDirectionCount();

            return coordinate;
        }

        private void IncrementDirectionCount()
        {
            CurrentDirectionCount++;
        }

        private void IncrementValue()
        {
            CurrentValue++;
        }

        private int CalculateSurroundingSumOfCurrentCoordinate()
        {
            var sum = 0;

            int GetSurroundingSum(int x, int y)
            {
                var key = new Tuple<int, int>(x, y);
                return _matrix.ContainsKey(key) ? _matrix[key].SurroundingSum : 0;
            }

            sum += GetSurroundingSum(CurrentX,CurrentY + 1); //top
            sum += GetSurroundingSum(CurrentX + 1,CurrentY + 1); //top right
            sum += GetSurroundingSum(CurrentX + 1,CurrentY); //right
            sum += GetSurroundingSum(CurrentX + 1,CurrentY - 1); //bottom right
            sum += GetSurroundingSum(CurrentX,CurrentY - 1); //bottom
            sum += GetSurroundingSum(CurrentX - 1,CurrentY - 1); //bottom left
            sum += GetSurroundingSum(CurrentX - 1,CurrentY); //left
            sum += GetSurroundingSum(CurrentX - 1,CurrentY + 1); //top left

            return sum;
        }

        private void IncrementXAndYInProperDirection()
        {
            switch (CurrentDirection)
            {
                case "right":
                    CurrentX++;
                    break;
                case "up":
                    CurrentY++;
                    break;
                case "left":
                    CurrentX--;
                    break;
                case "down":
                    CurrentY--;
                    break;
                default:
                    throw new Exception("Bad direction");
            }
        }

        private void TurnCornerCounterclockwise()
        {
            switch (CurrentDirection)
            {
                case "right":
                    CurrentDirection = "up";
                    break;
                case "up":
                    CurrentDirection = "left";
                    CurrentSize++;
                    break;
                case "left":
                    CurrentDirection = "down";
                    break;
                case "down":
                    CurrentDirection = "right";
                    CurrentSize++;
                    break;
                default:
                    throw new Exception("Bad direction");
            }

            CurrentDirectionCount = 0;
        }
    }
}