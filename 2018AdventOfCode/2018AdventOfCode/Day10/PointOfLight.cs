using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit.Abstractions;

namespace _2018AdventOfCode.Day10
{
    public static class PointOfLightParser
    {
        public static IEnumerable<PointOfLight> Parse(IEnumerable<string> lines)
        {
            var pointsOfLight = new List<PointOfLight>();

            foreach (var line in lines)
            {
                var positionAndVelocity = line.Split('<', '>');
                var position = positionAndVelocity[1].Split(',');
                var velocity = positionAndVelocity[3].Split(',');

                pointsOfLight.Add(new PointOfLight
                {
                    CurrentX = int.Parse(position[0]),
                    CurrentY = int.Parse(position[1]),
                    VelocityX = int.Parse(velocity[0]),
                    VelocityY = int.Parse(velocity[1]),
                });
            }

            return pointsOfLight;
        }
    }

    public class PointOfLight
    {
        public long CurrentX { get; set; }
        public long CurrentY { get; set; }

        public long VelocityX { get; set; }
        public long VelocityY { get; set; }

        public void Move()
        {
            CurrentX += VelocityX;
            CurrentY += VelocityY;
        }

        public void ReverseMove()
        {
            CurrentX -= VelocityX;
            CurrentY -= VelocityY;
        }
    }
}