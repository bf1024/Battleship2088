using Battleship2088.Core.Interfaces;

namespace Battleship2088.Core.Models
{
    public class Ship : IShip
    {
        public int Size { get; }
        private int hitCount;

        public bool IsSunk => hitCount == Size;

        public Ship(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Ship size must be positive.", nameof(size));
            }
            Size = size;
        }

        public void Hit()
        {
            if (IsSunk)
            {
                throw new InvalidOperationException("Cannot hit a ship that is already sunk.");
            }
            hitCount++;
        }
    }
}