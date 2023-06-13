using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models;

namespace Battleship2088.Utils
{
    public class Randomizer : IRandomizer
    {
        private readonly Random random = new Random();

        public Coordinate NextCoordinate()
        {
            var x = random.Next(0, 10);
            var y = random.Next(0, 10);
            return new Coordinate(x, y);
        }

        public bool NextBool()
        {
            return random.Next(0, 2) == 0;
        }
    }
}