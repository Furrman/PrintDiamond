﻿using System;
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

            for (var i = 0; i < numberOfUserChars; i++)
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

        private string GetDiamondLine(int charCounter, char character, int numberOfUsedChars)
        {
            StringBuilder stringBuilder = new();

            var numberOfCharsInRow = numberOfUsedChars * 2 - 1;
            var numberOfLettersInRow = character == CharAlphhabeticHelper.A_LETTER ? 1 : 2;
            var oneSideTrimSpace = new string(CharAlphhabeticHelper.SPACE, numberOfUsedChars - charCounter - 1); //TODO
            var insideSpace = new string(CharAlphhabeticHelper.SPACE, numberOfCharsInRow - 2 * oneSideTrimSpace.Length - numberOfLettersInRow);

            stringBuilder
                .Append(oneSideTrimSpace)
                .Append(character)
                .Append(insideSpace)
                .Append(character)
                .Append(oneSideTrimSpace)
                .Append(CharAlphhabeticHelper.NEW_LINE);

            return stringBuilder.ToString();
        }
    }
}
