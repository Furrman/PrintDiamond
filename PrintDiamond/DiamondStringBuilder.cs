 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintDiamond
{
    public sealed class DiamondStringBuilder
    {
        private readonly int _firstAlphaCharUnicode = CharAlphhabeticHelper.A_LETTER_UNICODE;

        public string GetDiamondText(char lastLetter)
        {
            if (!CharAlphhabeticHelper.IsAlphabethic(lastLetter))
            {
                throw new ArgumentException("Last character for diamond has to be a letter.");
            }

            StringBuilder stringBuilder = new();
            List<string> lines = new();
            var upperLastChar = char.ToUpper(lastLetter);
            int lastCharUnicode = upperLastChar;
            var numberOfUserChars = lastCharUnicode - _firstAlphaCharUnicode + 1;

            var topLines = GetDiamondTopLines(numberOfUserChars);
            var midLine = GetDiamondMidLines(numberOfUserChars, upperLastChar);
            var bottomLines = GetDiamondBottomLine(topLines);

            lines.AddRange(topLines);
            lines.Add(midLine);
            lines.AddRange(bottomLines);

            foreach (var line in lines)
            {
                stringBuilder
                    .Append(line)
                    .Append(CharAlphhabeticHelper.NEW_LINE);
            }

            return stringBuilder.ToString();
        }

        private IEnumerable<string> GetDiamondTopLines(int numberOfUserChars)
        {
            List<string> topLines = new();

            for (var i = 0; i < numberOfUserChars - 1; i++)
            {
                var charUnicode = _firstAlphaCharUnicode + i;
                topLines.Add(GetDiamondLine(i, (char)charUnicode, numberOfUserChars));
            }

            return topLines;
        }

        private string GetDiamondMidLines(int numberOfUserChars, char upperLastChar)
            => GetDiamondLine(numberOfUserChars - 1, upperLastChar, numberOfUserChars);

        private IEnumerable<string> GetDiamondBottomLine(IEnumerable<string> topDiamondPart)
            => topDiamondPart.Reverse();

        private string GetDiamondLine(int charCounter, char character, int numberOfUsedChars)
        {
            StringBuilder stringBuilder = new();

            var numberOfCharsInRow = numberOfUsedChars * 2 - 1;
            var numberOfLettersInRow = character == CharAlphhabeticHelper.A_LETTER ? 1 : 2;
            int oneSideSpaceLength = numberOfUsedChars - charCounter - 1;
            var oneSideSpace = new string(CharAlphhabeticHelper.SPACE, oneSideSpaceLength);
            int insideSpaceLength = numberOfCharsInRow - 2 * oneSideSpace.Length - numberOfLettersInRow;
            var insideSpace = new string(CharAlphhabeticHelper.SPACE, insideSpaceLength);

            // TODO Remove spaces at the right side of the diamond
            if (insideSpace == string.Empty)
            {
                stringBuilder
                    .Append(oneSideSpace)
                    .Append(character)
                    .Append(oneSideSpace);
            }
            else
            {
                stringBuilder
                    .Append(oneSideSpace)
                    .Append(character)
                    .Append(insideSpace)
                    .Append(character)
                    .Append(oneSideSpace);
            }

            return stringBuilder.ToString();
        }
    }
}
