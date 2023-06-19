namespace Battleship2088.Core.Models
{
    public struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            if (x < 0 || x >= Grid.GridSize)
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"X-coordinate must be between 0 and {Grid.GridSize}.");
            }
            if (y < 0 || y >= Grid.GridSize)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"Y-coordinate must be between 0 and {Grid.GridSize}.");
            }
            X = x;
            Y = y;
        }
    }
}
