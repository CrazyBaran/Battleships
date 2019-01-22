using Battleships.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public class Grid
  {
    private readonly ICoordinatesProvider _random;
    public readonly ISquare[,] _grid; // TODO: remove hack
    public Grid(ICoordinatesProvider random, int size)
    {
      _random = random;
      _grid = GetEmptyGrid(size);
    }

    public void PlaceShips(IShip[] ships)
    {
      // assuming that grid is a square
      var gridSize = _grid.GetLength(0);
      foreach (var ship in ships)
      {
        bool wasShipSuccesfullyPlaced = false;
        while (!wasShipSuccesfullyPlaced)
        {
          var (coordinates, orientation) = _random.GetCoordinates(gridSize, ship.Size);
          wasShipSuccesfullyPlaced = TryPlaceShip(
              ship,
              orientation,
              coordinates
              );
        }
      }
    }

    private static ISquare[,] GetEmptyGrid(int gridSize)
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
        IShip ship,
        Orientation orientation,
        Coordinates coordinates
        )
    {
      if (!IsGridFree(orientation, coordinates, ship.Size)) return false;

      for (var i = 0; i < ship.Size; i++)
      {
        if (orientation == Orientation.Vertical)
        {
          _grid[coordinates.X + i, coordinates.Y] = new Square(ship);
        }
        else
        {
          _grid[coordinates.X, coordinates.Y + i] = new Square(ship);
        }
      }

      return true;
    }

    private bool IsGridFree(
        Orientation orientation,
        Coordinates coordinates,
        int length
        )
    {
      for (var i = 0; i < length; i++)
      {
        // TODO: use this style elsewhere too
        var x = orientation == Orientation.Vertical
            ? coordinates.X + i
            : coordinates.X;
        var y = orientation == Orientation.Horizontal
            ? coordinates.Y + 1
            : coordinates.Y;

        if (_grid[x, y]?.Ship != null) return false;
      }

      return true;
    }
  }
}
