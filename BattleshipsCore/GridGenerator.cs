using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public class GridGenerator
    {
        private readonly IRandomProvider _random;

        public GridGenerator(IRandomProvider random)
        {
            _random = random;
        }

        public ISquare[,] Generate(int gridSize, IShip[] ships)
        {
            var grid = new Square[gridSize, gridSize];
            foreach (var ship in ships)
            {
                bool wasShipSuccesfullyPlaced = false;
                while (!wasShipSuccesfullyPlaced)
                {
                    var orientation = _random.GetOrientation();
                    var coordinates = _random.GetPosition(gridSize, ship.Size, orientation);
                    wasShipSuccesfullyPlaced = TryPlaceShip(
                        grid, 
                        ship, 
                        orientation, 
                        coordinates
                        );
                }
            }
            
            for (var x = 0; x < grid.GetLength(0); x++)
            {
                for (var y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] == null)
                    {
                        grid[x, y] = new Square();
                    }
                }
            }

            return grid;
        }

        private bool TryPlaceShip(
            ISquare[,] grid, 
            IShip ship, 
            Orientation orientation, 
            Coordinates coordinates
            )
        {
            if (!IsGridFree(grid, orientation, coordinates, ship.Size)) return false;

            for (var i = 0; i < ship.Size; i++)
            {
                if (orientation == Orientation.Vertical)
                {
                    grid[coordinates.X + i, coordinates.Y] = new Square(ship);
                }
                else
                {
                    grid[coordinates.X, coordinates.Y + i] = new Square(ship);
                }
            }

            return true;
        }

        private bool IsGridFree(
            ISquare[,] grid, 
            Orientation orientation, 
            Coordinates coordinates, 
            int length
            )
        {
            for (var i = 0; i < length; i++)
            {
                if (orientation == Orientation.Vertical
                    && grid[coordinates.X + i, coordinates.Y] != null)
                {
                    return false;
                }
                
                if(orientation == Orientation.Horizontal
                    && grid[coordinates.X, coordinates.Y + i] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
