using NUnit.Framework;
using Battleship2088.Core.Models;
using Battleship2088.Utils;
using Battleship2088.Core.Models.Enums;
using Battleship2088.Core.Interfaces;
using Moq;
using Microsoft.Extensions.Configuration;

namespace Battleship2088.Tests
{
    [TestFixture]
    public class GridTests
    {
        private IGrid grid;

        [SetUp]
        public void Setup()
        {
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(config => config["Config:GridSize"]).Returns("10");

            grid = new Grid(mockConfiguration.Object);
        }

        [Test]
        public void Grid_ShipPlaced_HitReturnsHit()
        {
            var ship = new Ship(3);
            grid.PlaceShip(ship, new Coordinate(0, 0), false);
            Assert.That(grid.Shoot(new Coordinate(0, 0)), Is.EqualTo(HitResult.Hit));
        }

        [Test]
        public void Grid_ShipNotPlaced_HitReturnsMiss()
        {
            Assert.That(grid.Shoot(new Coordinate(0, 0)), Is.EqualTo(HitResult.Miss));
        }

        [Test]
        public void Grid_AllShipsSunk_ReturnsTrue()
        {
            var ship = new Ship(3);
            grid.PlaceShip(ship, new Coordinate(0, 0), false);
            for (int i = 0; i < 3; i++)
            {
                grid.Shoot(new Coordinate(i, 0));
            }
            Assert.IsTrue(grid.AllShipsSunk());
        }
    }
}