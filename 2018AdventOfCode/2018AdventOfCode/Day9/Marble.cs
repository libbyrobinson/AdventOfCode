namespace _2018AdventOfCode.Day9
{
    public class Marble
    {
        public long Value { get; set; }
        public Marble Previous { get; set; }
        public Marble Next { get; set; }
    }
}