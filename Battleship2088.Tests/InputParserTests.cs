using Battleship2088.Utils;
using Battleship2088.Core.Models;
using Battleship2088.Core.Interfaces;
using NUnit.Framework.Internal;

namespace Battleship2088.Tests
{
    [TestFixture]
    public class InputParserTests
    {
        private IInputParser? parser;

        [SetUp]
        public void SetUp()
        {
            parser = new InputParser();
        }

        [Test]
        public void Parse_ValidInput_ReturnsCoordinate()
        {
            var input = "A1";
            var expectedCoordinate = new Coordinate(0, 0);
            var actualCoordinate = parser.Parse(input);

            Assert.That(actualCoordinate.X, Is.EqualTo(expectedCoordinate.X));
            Assert.That(actualCoordinate.Y, Is.EqualTo(expectedCoordinate.Y));
        }

        [Test]
        public void Parse_InvalidInput_ThrowsArgumentException()
        {
            var invalidInput = "Z12";
            Assert.Throws<ArgumentException>(() => parser.Parse(invalidInput));
        }

        [Test]
        public void Parse_EmptyInput_ThrowsArgumentException()
        {
            var emptyInput = string.Empty;
            Assert.Throws<ArgumentException>(() => parser.Parse(emptyInput));
        }

        [Test]
        public void Parse_NullInput_ThrowsArgumentException()
        {
            string nullInput = null;
            Assert.Throws<ArgumentException>(() => parser.Parse(nullInput));
        }
    }
}



