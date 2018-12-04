namespace _2018AdventOfCode.Day3
{
    public class Plan
    {
        public Plan(string plan)
        {
            var currentPart = "";
            foreach (var character in plan)
            {
                switch (character)
                {
                    case '#':
                    case ' ':
                        break;
                    case '@':
                        Id = currentPart;
                        currentPart = "";
                        break;
                    case ',':
                        DistanceFromLeft = int.Parse(currentPart);
                        currentPart = "";
                        break;
                    case ':':
                        DistanceFromTop = int.Parse(currentPart);
                        currentPart = "";
                        break;
                    case 'x':
                        Width = int.Parse(currentPart);
                        currentPart = "";
                        break;
                    default:
                        currentPart += character;
                        break;
                }
            }

            Height = int.Parse(currentPart);
        }

        public string Id { get; }
        public int DistanceFromLeft { get; }
        public int DistanceFromTop { get; }
        public int Width { get; }
        public int Height { get; }
        public int Area => Width * Height;

        public bool HasOverlap { get; set; }
    }
}