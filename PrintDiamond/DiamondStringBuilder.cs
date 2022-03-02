using System;
using System.Text;

namespace PrintDiamond
{
    public class DiamondStringBuilder
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
            string midDiamondPart = GetMidPartOfDiamond(upperLastChar);
            string bottomDiamondPart = GetBottomPartOfDiamond(topDiamondPart);

            stringBuilder.Append(topDiamondPart);
            stringBuilder.Append(midDiamondPart);
            stringBuilder.Append(bottomDiamondPart);

            return stringBuilder.ToString();
        }

        private string GetTopPartOfDiamond(int numberOfUserChars)
        {
            StringBuilder stringBuilder = new();

            for (var i = 0; i < numberOfUserChars; i++)
            {
                var charUnicode = _firstAlphaCharUnicode + i;
                stringBuilder.Append(GetDiamondLine((char)charUnicode));
            }

            return stringBuilder.ToString();
        }

        private string GetMidPartOfDiamond(char upperLastChar)
            =>  GetDiamondLine(upperLastChar);

        private string GetBottomPartOfDiamond(string topDiamondPart)
        {
            StringBuilder stringBuilder = new();

            var lines = topDiamondPart.Split(CharAlphhabeticHelper.NEW_LINE);
            Array.Reverse(lines);

            foreach (var line in lines)
            {
                stringBuilder
                    .Append(line)
                    .Append(CharAlphhabeticHelper.NEW_LINE);
            }

            return stringBuilder.ToString();
        }

        private string GetDiamondLine(char character)
        {
            StringBuilder stringBuilder = new();

            // TODO

            stringBuilder.Append(CharAlphhabeticHelper.NEW_LINE);

            return stringBuilder.ToString();
        }
    }
}
