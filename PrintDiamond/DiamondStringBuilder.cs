 using System;
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
            var upperLastChar = char.ToUpper(lastLetter);
            int lastCharUnicode = upperLastChar;
            var numberOfUserChars = lastCharUnicode - _firstAlphaCharUnicode + 1;

            string topDiamondPart = GetTopPartOfDiamond(numberOfUserChars);
            string midDiamondPart = GetMidPartOfDiamond(numberOfUserChars, upperLastChar);
            string bottomDiamondPart = GetBottomPartOfDiamond(topDiamondPart);

            stringBuilder
                .Append(topDiamondPart)
                .Append(midDiamondPart)
                .Append(bottomDiamondPart);

            return stringBuilder.ToString();
        }

        private string GetTopPartOfDiamond(int numberOfUserChars)
        {
            StringBuilder stringBuilder = new();

            for (var i = 0; i < numberOfUserChars - 1; i++)
            {
                var charUnicode = _firstAlphaCharUnicode + i;
                stringBuilder
                    .Append(GetDiamondLine(i, (char)charUnicode, numberOfUserChars))
                    .Append(CharAlphhabeticHelper.NEW_LINE);
            }

            return stringBuilder.ToString();
        }

        private string GetMidPartOfDiamond(int numberOfUserChars, char upperLastChar)
        {
            StringBuilder stringBuilder = new();
            stringBuilder
                .Append(GetDiamondLine(numberOfUserChars - 1, upperLastChar, numberOfUserChars))
                .Append(CharAlphhabeticHelper.NEW_LINE);

            return stringBuilder.ToString();
        }

        private string GetBottomPartOfDiamond(string topDiamondPart)
        {
            StringBuilder stringBuilder = new();
            var newLine = CharAlphhabeticHelper.NEW_LINE.ToString();

            var lines = topDiamondPart
                .Split(newLine)
                .Where(s => s != string.Empty);

            lines = lines.Reverse();

            foreach (var line in lines)
            {
                stringBuilder
                    .Append(line)
                    .Append(CharAlphhabeticHelper.NEW_LINE);
            }

            return stringBuilder.ToString();
        }

        private string GetDiamondLine(int charCounter, char character, int numberOfUsedChars)
        {
            StringBuilder stringBuilder = new();

            var numberOfCharsInRow = numberOfUsedChars * 2 - 1;
            var numberOfLettersInRow = character == CharAlphhabeticHelper.A_LETTER ? 1 : 2;
            var oneSideTrimSpace = new string(CharAlphhabeticHelper.SPACE, numberOfUsedChars - charCounter - 1);
            var insideSpace = new string(CharAlphhabeticHelper.SPACE, numberOfCharsInRow - 2 * oneSideTrimSpace.Length - numberOfLettersInRow);

            if (insideSpace == string.Empty)
            {
                stringBuilder
                    .Append(oneSideTrimSpace)
                    .Append(character)
                    .Append(oneSideTrimSpace);
            }
            else
            {
                stringBuilder
                    .Append(oneSideTrimSpace)
                    .Append(character)
                    .Append(insideSpace)
                    .Append(character)
                    .Append(oneSideTrimSpace);
            }

            return stringBuilder.ToString();
        }
    }
}
