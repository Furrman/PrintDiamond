using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace PrintDiamond.UnitTests.DiamondStringBuilder
{
    [TestFixture]
    [Category("GetDiamondText")]
    public class DiamondStringBuilderTest
    {
        private readonly PrintDiamond.DiamondStringBuilder _diamondStringBuilder = new();

        [TestCase('1')]
        [TestCase('!')]
        [TestCase('Æ')]
        public void InvalidInputCharacterThrow(char character)
        {
            Assert.Throws<ArgumentException>(() => _diamondStringBuilder.GetDiamondText(character));
        }

        [TestCase('A', ExpectedResult = 1 * 2)] // w x h
        [TestCase('a', ExpectedResult = 1 * 2)] // w x h
        [TestCase('B', ExpectedResult = 3 * 4)]
        [TestCase('b', ExpectedResult = 3 * 4)]
        [TestCase('C', ExpectedResult = 5 * 6)]
        [TestCase('c', ExpectedResult = 5 * 6)]
        [TestCase('Z', ExpectedResult = (1 + 2 * 25) * (2 * 26))]
        [TestCase('z', ExpectedResult = (1 + 2 * 25) * (2 * 26))]
        public int CorrectLength(char character)
        {
            var result = _diamondStringBuilder.GetDiamondText(character);
            return result.Length;
        }

        [TestCase('A', ExpectedResult = 1)]
        [TestCase('a', ExpectedResult = 1)]
        [TestCase('B', ExpectedResult = 3)]
        [TestCase('b', ExpectedResult = 3)]
        [TestCase('C', ExpectedResult = 5)]
        [TestCase('c', ExpectedResult = 5)]
        [TestCase('Z', ExpectedResult = 1 + 2 * 25)]
        [TestCase('z', ExpectedResult = 1 + 2 * 25)]
        public int CorrectNumberOfRows(char character)
        {
            var result = _diamondStringBuilder.GetDiamondText(character);
            return result.Count(s => s == CharAlphhabeticHelper.NEW_LINE);
        }

        [TestCase('A')]
        [TestCase('a')]
        public void CorrectNumberOfCharacterA(char character)
        {
            var result = _diamondStringBuilder.GetDiamondText(character);

            Assert.AreEqual(1, result.Count(s => s == char.ToUpper(character)));
        }

        [TestCase('B')]
        [TestCase('b')]
        [TestCase('C')]
        [TestCase('c')]
        [TestCase('Z')]
        [TestCase('z')]
        public void CorrectNumberOfCharacters(char character)
        {
            var aChar = 'A';
            int firstCharUnicode = aChar,
                currentCharUnicode = char.ToUpper(character);

            var result = _diamondStringBuilder.GetDiamondText(character);

            Assert.AreEqual(2, result.Count(s => s == aChar), $"Wrong number of character {aChar}");
            for (var i = firstCharUnicode + 1; i <= currentCharUnicode; i++)
            {
                Assert.AreEqual(4, result.Count(s => s == (char)i), $"Wrong number of character {(char)i}");
            }
        }

        [TestCase('A')]
        [TestCase('a')]
        [TestCase('B')]
        [TestCase('b')]
        [TestCase('C')]
        [TestCase('c')]
        [TestCase('Z')]
        [TestCase('z')]
        public void CorrectDiamondStructure(char character)
        {
            var upperChar = char.ToUpper(character);
            var expected = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "DiamondStringBuilder", $"CorrectDiamondStructure{upperChar}.txt"));

            var result = _diamondStringBuilder.GetDiamondText(upperChar);

            Assert.AreEqual(expected, result);
        }
    }
}
