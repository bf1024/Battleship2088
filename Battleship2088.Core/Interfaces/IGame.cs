using Battleship2088.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship2088.Core.Interfaces
{
    public interface IGame
    {
        bool IsGameOver();
        void DrawGrid();
        public HitResult PlayTurn(string input);
    }
}
