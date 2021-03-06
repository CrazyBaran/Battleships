﻿using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public class GridManager
    {
        private readonly IRandomProvider _random;

        public GridManager(IRandomProvider random)
        {
            _random = random;
        }

        public void PlaceShips(ISquare[,] grid, IShip[] ships)
        {
            // assuming that grid is a square
            var gridSize = grid.GetLength(0);
            foreach (var ship in ships)
            {
                bool wasShipSuccesfullyPlaced = false;
                while (!wasShipSuccesfullyPlaced)
                {
                    var orientation = _random.GetOrientation();
                    var coordinates = _random.GetCoordinates(gridSize, ship.Size, orientation);
                    wasShipSuccesfullyPlaced = TryPlaceShip(
                        grid,
                        ship,
                        orientation,
                        coordinates
                        );
                }
            }
        }

        public ISquare[,] GetEmptyGrid(int gridSize)
        {
            var grid = new Square[gridSize, gridSize];
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
                var x = orientation == Orientation.Vertical 
                    ? coordinates.X + i 
                    : coordinates.X;
                var y = orientation == Orientation.Horizontal
                    ? coordinates.Y + 1
                    : coordinates.Y;

                if (grid[x, y]?.Ship != null) return false;
            }

            return true;
        }
    }
}
