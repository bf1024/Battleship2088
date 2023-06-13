using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship2088.Core.Interfaces
{
    public interface IShip
    {
        int Size { get; }
        bool IsSunk { get; }
        void Hit();
    }
}
