using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day3_SpiralMemory
    {
        public int CalculateSteps_Part1()
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

        public int CalculateSteps_Part2()
        {
            var input = 347991;

            var spiralMatrix = new List<MatrixCoordinate>
            {
                new MatrixCoordinate
                {
                    X = 0,
                    Y = 0,
                    SurroundingSum = 1
                }
            };
            
            var currentSize = 1;
            while (true)
            {
                AddToMatrix(spiralMatrix, "right", currentSize);
                AddToMatrix(spiralMatrix, "up", currentSize);

                currentSize++;

                AddToMatrix(spiralMatrix, "left", currentSize);
                AddToMatrix(spiralMatrix, "down", currentSize);

                currentSize++;

                var bigger = spiralMatrix.FirstOrDefault(s => s.SurroundingSum > input);
                if (bigger != null)
                    return bigger.SurroundingSum;
            }
        }

        private int GetSurroundingSumOfCoordinate(IReadOnlyCollection<MatrixCoordinate> spiralMatrix, MatrixCoordinate coordinate)
        {
            var sum = 0;

            var top = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X && x.Y == coordinate.Y + 1);
            if (top != null) sum += top.SurroundingSum;

            var topRight = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X + 1 && x.Y == coordinate.Y + 1);
            if (topRight != null) sum += topRight.SurroundingSum;

            var right = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X + 1 && x.Y == coordinate.Y);
            if (right != null) sum += right.SurroundingSum;

            var bottomRight = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X + 1 && x.Y == coordinate.Y - 1);
            if (bottomRight != null) sum += bottomRight.SurroundingSum;

            var bottom = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X && x.Y == coordinate.Y - 1);
            if (bottom != null) sum += bottom.SurroundingSum;

            var bottomLeft = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X - 1 && x.Y == coordinate.Y - 1);
            if (bottomLeft != null) sum += bottomLeft.SurroundingSum;

            var left = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X - 1 && x.Y == coordinate.Y);
            if (left != null) sum += left.SurroundingSum;

            var topLeft = spiralMatrix.SingleOrDefault(x => x.X == coordinate.X - 1 && x.Y == coordinate.Y + 1);
            if (topLeft != null) sum += topLeft.SurroundingSum;

            return sum;
        }

        private void AddToMatrix(List<MatrixCoordinate> sprialMatrix, string direction, int numberToAdd)
        {
            for (var i = 0; i < numberToAdd; i++)
            {
                var next = sprialMatrix.Last().Next(direction);
                next.SurroundingSum = GetSurroundingSumOfCoordinate(sprialMatrix, next);
                sprialMatrix.Add(next);
            }
        }
    }

    public class MatrixCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SurroundingSum { get; set; }

        public MatrixCoordinate Next(string direction)
        {
            var next = new MatrixCoordinate
            {
                X = X,
                Y = Y
            };
            switch (direction)
            {
                case "right":
                    next.X++;
                    break;
                case "up":
                    next.Y++;
                    break;
                case "left":
                    next.X--;
                    break;
                case "down":
                    next.Y--;
                    break;
            }
            return next;
        }
    }
}