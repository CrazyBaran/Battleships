using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public class GridGenerator
    {
        private Random random = new Random();
        public ISquare[,] Generate(int gridSize, IShip[] ships)
        {
            var grid = new Square[gridSize, gridSize];
            foreach (var ship in ships)
            {
                bool wasShipSuccesfullyPlaced = false;
                while (!wasShipSuccesfullyPlaced)
                {
                    var orientation = GetRandomOrientation();
                    var coordinates = GetRandomPosition(gridSize, ship, orientation);
                    wasShipSuccesfullyPlaced = TryPlaceShip(grid, ship, orientation, coordinates);
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

        private Coordinates GetRandomPosition(int gridSize, IShip ship, Orientation orientation)
        {
            if (orientation == Orientation.Vertical)
            {
                return new Coordinates(
                    x: random.Next(gridSize - ship.Size + 1),
                    y: random.Next(gridSize)
                    );
            }
            else
            {
                return new Coordinates(
                    x: random.Next(gridSize),
                    y: random.Next(gridSize - ship.Size + 1)
                    );
            }
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

        private Orientation GetRandomOrientation()
        {
            if (random.Next() % 2 == 0) return Orientation.Horizontal;
            return Orientation.Vertical;
        }
    }
}
