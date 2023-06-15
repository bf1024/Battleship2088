using Battleship2088.Core.Models.Enums;
using Battleship2088.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship2088.Core.Interfaces
{
    public interface IGrid
    {
        HitResult Shoot(Coordinate target);
        bool AllShipsSunk();
        void DrawGrid();
        bool PlaceShip(IShip ship, Coordinate start, bool isVertical);
    }
}
