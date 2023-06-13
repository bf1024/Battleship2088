using Battleship2088.Core.Models;

namespace Battleship2088.Core.Interfaces
{
    public interface IRandomizer
    {
        Coordinate NextCoordinate();
        bool NextBool();
    }
}