using Moq;
using Battleship2088.Core.Models;
using Battleship2088.Core;
using Battleship2088.Core.Models.Enums;
using Battleship2088.Core.Interfaces;
using Microsoft.VisualStudio.CodeCoverage;

namespace Battleship2088.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IGrid>? mockGrid;
        private Mock<IInputParser>? mockInputParser;
        private Mock<IRandomizer>? mockRandomizer;
        private Game? game;
        private Queue<Coordinate>? coordinatesQueue;
        private Coordinate coordinate1;
        private string? input;

        [SetUp]
        public void Setup()
        {
            mockGrid = new Mock<IGrid>();
            mockInputParser = new Mock<IInputParser>();
            mockRandomizer = new Mock<IRandomizer>();
            input = "A1";

            coordinate1 = new Coordinate(0, 0);
            Coordinate coordinate2 = new Coordinate(1, 0);
            Coordinate coordinate3 = new Coordinate(2, 0);

            coordinatesQueue = new Queue<Coordinate>(new[]
            {
                coordinate1,
                coordinate2,
                coordinate3
            });

            mockInputParser.Setup(m => m.Parse(input)).Returns(coordinate1);
            mockRandomizer.Setup(m => m.NextBool()).Returns(true);
            mockRandomizer.Setup(m => m.NextCoordinate()).Returns(coordinatesQueue.Dequeue);

            mockGrid.Setup(m => m.PlaceShip(It.IsAny<IShip>(), It.IsAny<Coordinate>(), It.IsAny<bool>()))
                    .Returns(true);

            game = new Game(mockGrid.Object, mockInputParser.Object, mockRandomizer.Object);
        }

        [Test]
        public void PlayTurn_ValidInput_ReturnsHitResult()
        {
            var hitResult = HitResult.Hit;

            mockGrid!.Setup(m => m.Shoot(coordinate1)).Returns(hitResult);

            var result = game!.PlayTurn(input!);

            Assert.That(result, Is.EqualTo(hitResult));
            mockInputParser!.Verify(m => m.Parse(input!), Times.Once);
            mockGrid.Verify(m => m.Shoot(coordinate1), Times.Once);
        }

        [Test]
        public void IsGameOver_ShipsNotSunk_ReturnsFalse()
        {
            mockGrid!.Setup(m => m.AllShipsSunk()).Returns(false);
            Assert.IsFalse(game!.IsGameOver());
        }

        [Test]
        public void IsGameOver_ShipsSunk_ReturnsTrue()
        {
            mockGrid.Setup(m => m.AllShipsSunk()).Returns(true);
            Assert.IsTrue(game!.IsGameOver());
        }
    }
}