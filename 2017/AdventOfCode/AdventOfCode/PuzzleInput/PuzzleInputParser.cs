using System.IO;

namespace AdventOfCode.PuzzleInput
{
    public static class PuzzleInputParser
    {
        public static string Parse(string fileName)
        {
            using (var streamReader = new StreamReader("PuzzleInput\\" + fileName))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}