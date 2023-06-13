using Battleship2088.Core.Models;

namespace Battleship2088.Core.Interfaces
{
    public interface IInputParser
    {
        Coordinate Parse(string input);
    }
}
