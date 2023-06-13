using NUnit.Framework;
using Battleship2088.Core.Models;

namespace Battleship2088.Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void Ship_Created_NotSunk()
        {
            var ship = new Ship(3);
            Assert.IsFalse(ship.IsSunk);
        }

        [Test]
        public void Ship_Hit_NotSunk()
        {
            var ship = new Ship(3);
            ship.Hit();
            Assert.IsFalse(ship.IsSunk);
        }

        [Test]
        public void Ship_HitEnoughTimes_Sunk()
        {
            var ship = new Ship(3);
            for (int i = 0; i < 3; i++)
            {
                ship.Hit();
            }
            Assert.IsTrue(ship.IsSunk);
        }

        [Test]
        public void Ship_HitTooManyTimes_ThrowsException()
        {
            var ship = new Ship(3);
            for (int i = 0; i < 3; i++)
            {
                ship.Hit();
            }
            Assert.Throws<InvalidOperationException>(ship.Hit);
        }
    }
}