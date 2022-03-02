using System;

namespace PrintDiamond
{
    public class DiamondStringBuilder
    {
        public string GetDiamondText(char lastLetter)
        {
            if (!CharAlphhabeticHelper.IsAlphabethic(lastLetter))
            {
                throw new ArgumentException("Last character for diamond has to be a letter.");
            }

            return string.Empty;
        }
    }
}
