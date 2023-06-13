using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models;

namespace Battleship2088.Utils
{
    public class InputParser : IInputParser
    {
        public Coordinate Parse(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                throw new ArgumentException("Invalid input. Expected format is 'A5' where 'A' is the column and '5' is the row.");
            }

            var x = char.ToUpper(input[0]) - 'A';
            if (x < 0 || x >= 10)
            {
                throw new ArgumentException($"Invalid column '{input[0]}'. Expected a letter between A and J.");
            }

            if (!int.TryParse(input.Substring(1), out var y) || y < 1 || y > 10)
            {
                throw new ArgumentException($"Invalid row '{input.Substring(1)}'. Expected a number between 1 and 10.");
            }

            return new Coordinate(x, y - 1);
        }
    }
}