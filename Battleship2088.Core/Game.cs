using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models;
using Battleship2088.Core.Models.Enums;
using Battleship2088.Utils;

namespace Battleship2088.Core
{
    public class Game : IGame
    {
        private readonly IGrid _grid;
        private readonly IInputParser _inputParser;
        private readonly IRandomizer _randomizer;

        public Game(IGrid grid, IInputParser inputParser, IRandomizer randomizer)
        {
            _grid = grid;
            _inputParser = inputParser;
            _randomizer = randomizer;
            InitializeShips();
        }

        private void InitializeShips()
        {
            var battleship = new Ship(5);
            while (!TryPlaceShipRandomly(battleship)) { }

            for (var i = 0; i < 2; i++)
            {
                var destroyer = new Ship(4);
                while (!TryPlaceShipRandomly(destroyer)) { }
            }
        }

        private bool TryPlaceShipRandomly(IShip ship)
        {
            var start = _randomizer.NextCoordinate();
            var isVertical = _randomizer.NextBool();
            var result = _grid.PlaceShip(ship, start, isVertical);
            return result;
        }

        public HitResult PlayTurn(string input)
        {
            var coordinate = _inputParser.Parse(input);
            return _grid.Shoot(coordinate);
        }

        public bool IsGameOver()
        {
            return _grid.AllShipsSunk();
        }
    }
}