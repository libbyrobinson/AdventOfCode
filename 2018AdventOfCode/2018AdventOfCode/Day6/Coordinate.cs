namespace _2018AdventOfCode.Day6
{
    public class Coordinate
    {
        public Coordinate(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            IsInfinite = false;
            Area = 0;
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsInfinite { get; set; }
        public int Area { get; set; }
    }
}