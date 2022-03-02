using System;
using System.Text.RegularExpressions;

namespace PrintDiamond
{
    public static class CharAlphhabeticHelper
    {
        public static readonly int A_LETTER_UNICODE = 'A';
        public static readonly char[] ALPHABET_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static readonly char NEW_LINE = '\n';

        public static bool IsAlphabethic(char character)
        {
            Regex rg = new(@"^[a-zA-Z]$");
            return rg.IsMatch(char.ToString(character));
        }
    }
}
