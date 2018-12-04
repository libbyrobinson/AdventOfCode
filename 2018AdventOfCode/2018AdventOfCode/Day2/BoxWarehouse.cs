using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day2
{
    public class BoxWarehouse
    {
        public int CalculateChecksum(List<string> boxIds)
        {
            var boxesWithExactlyTwoOfSameLetter = 0;
            var boxesWithExactlyThreeOfSameLetter = 0;

            foreach (var boxId in boxIds)
            {
                var letterCounts = GetBoxLetterCounts(boxId);
                if (letterCounts.Any(l => l.Value == 2))
                    boxesWithExactlyTwoOfSameLetter++;
                if (letterCounts.Any(l => l.Value == 3))
                    boxesWithExactlyThreeOfSameLetter++;
            }

            return boxesWithExactlyTwoOfSameLetter * boxesWithExactlyThreeOfSameLetter;
        }

        private Dictionary<char, int> GetBoxLetterCounts(string boxId)
        {
            var letterCounts = new Dictionary<char, int>();
            foreach (var letter in boxId)
            {
                if (letterCounts.ContainsKey(letter))
                {
                    letterCounts[letter]++;
                }
                else
                {
                    letterCounts.Add(letter, 1);
                }
            }
            return letterCounts;
        }

        public string FindCommonLettersInPrototypeFabricBoxes(List<string> input)
        {
            for (var firstBoxIndex = 0; firstBoxIndex < input.Count; firstBoxIndex++)
            {
                var firstBox = input[firstBoxIndex];
                for (var secondBoxIndex = firstBoxIndex + 1; secondBoxIndex < input.Count; secondBoxIndex++)
                {
                    var secondBox = input[secondBoxIndex];
                    var commonLetters = FindCommonLettersBetweenBoxes(firstBox, secondBox);
                    if (commonLetters.Length == firstBox.Length - 1)
                    {
                        return commonLetters;
                    }
                }
            }

            return null;
        }

        private static string FindCommonLettersBetweenBoxes(string firstBox, string secondBox)
        {
            var commonLetters = "";
            for (var letterIndex = 0; letterIndex < firstBox.Length; letterIndex++)
            {
                if (firstBox[letterIndex] == secondBox[letterIndex])
                {
                    commonLetters += firstBox[letterIndex];
                }
            }

            return commonLetters;
        }
    }
}