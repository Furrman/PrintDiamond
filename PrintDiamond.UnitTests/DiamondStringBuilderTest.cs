using System;
using NUnit.Framework;

namespace PrintDiamond.UnitTests
{
    [TestFixture]
    public class DiamondStringBuilderTest
    {
        private readonly DiamondStringBuilder _diamondStringBuilder = new();

        [Test]
        [TestCase('1')]
        [TestCase('!')]
        [TestCase('Æ')]
        public void InvalidInputCharacterThrow(char character)
        {
            Assert.Throws<ArgumentException>(() => _diamondStringBuilder.GetDiamondText(character));
        }


    }
}
