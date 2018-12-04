using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2018AdventOfCode
{
    public static class PuzzleInputParser
    {
        public static List<int> ParseInts(string fileName)
        {
            string fileText;
            using (var streamReader = new StreamReader(fileName))
            {
                fileText = streamReader.ReadToEnd();
            }

            return fileText
                .Split(new[] {"\r\n"}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();
        }

        public static List<string> ParseStrings(string fileName)
        {
            string fileText;
            using (var streamReader = new StreamReader(fileName))
            {
                fileText = streamReader.ReadToEnd();
            }

            return fileText
                .Split(new[] {"\r\n"}, StringSplitOptions.None)
                .ToList();
        }
    }
}
