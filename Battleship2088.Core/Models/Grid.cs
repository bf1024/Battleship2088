using Battleship2088.Core.Interfaces;
using Battleship2088.Core.Models.Enums;
using System.Numerics;

namespace Battleship2088.Core.Models
{
    public class Grid : IGrid
    {
        private const int GridSize = 10;
        private readonly IShip[,] grid;
        private readonly HashSet<Coordinate> hits = new HashSet<Coordinate>();

        public Grid()
        {
            grid = new IShip[GridSize, GridSize];
        }

        public bool PlaceShip(IShip ship, Coordinate start, bool vertical)
        {
            if (vertical && start.Y + ship.Size > GridSize
                || !vertical && start.X + ship.Size > GridSize)
            {
                return false;
            }

            for (var i = 0; i < ship.Size; i++)
            {
                if (vertical)
                {
                    if (grid[start.X, start.Y + i] != null)
                        return false;
                }
                else
                {
                    if (grid[start.X + i, start.Y] != null)
                        return false;
                }
            }

            for (var i = 0; i < ship.Size; i++)
            {
                if (vertical)
                {
                    grid[start.X, start.Y + i] = ship;
                }
                else
                {
                    grid[start.X + i, start.Y] = ship;
                }
            }

            return true;
        }

        public HitResult Shoot(Coordinate target)
        {
            if (hits.Contains(target))
            {
                return HitResult.AlreadyHit;
            }

            var ship = grid[target.X, target.Y];

            if (ship == null)
            {
                return HitResult.Miss;
            }

            ship.Hit();
            hits.Add(target);

            if (ship.IsSunk)
            {
                return HitResult.Sunk;
            }

            return HitResult.Hit;
        }

        public bool AllShipsSunk()
        {
            return !grid.Cast<Ship>().Any(ship => ship != null && !ship.IsSunk);
        }

        public void DrawGrid()
        {
            Console.Write("  ");

            for (int i = 0; i < GridSize; i++)
            {
              Console.Write($" {i + 1}");
            }

            Console.WriteLine();
                
            for (int i = 0; i < GridSize; i++)
            {
                Console.Write($"{(char)(i + 'A')} ");
                for (int j = 0; j < GridSize; j++)
                {
                    var ship = grid[i, j];
                    if (ship == null)
                    {
                        Console.Write(" .");
                    }
                    else if(hits.Contains(new Coordinate(i,j)))
                    {
                        Console.Write(" *");
                    }
                    else
                    {
                        Console.Write(" #");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}