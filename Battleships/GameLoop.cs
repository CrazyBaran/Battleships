using Battleships.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public class GameLoop
  {
    private readonly ISquare[,] _grid;
    private readonly IUserInteraction _userInteraction;
    private readonly IShip[] _ships;

    public GameLoop(ISquare[,] grid, IUserInteraction userInteraction)
    {
      _grid = grid;
      _userInteraction = userInteraction;
      _ships = _grid
          .OfType<ISquare>() // Is this right? Seems to work but...
          .Select(square => square.Ship)
          .Where(ship => ship != null)
          .Distinct()
          .ToArray();
    }

    public void Run()
    {
      while (!IsGameFinished())
      {
        _userInteraction.WriteGrid(_grid);

        var coordinates = _userInteraction.ReadCoordinates(
            xUpperBound: _grid.GetLength(0),
            yUpperBound: _grid.GetLength(1));
        var squareToShoot = _grid[coordinates.X, coordinates.Y];
        var shotResult = squareToShoot.Shoot();

        _userInteraction.WriteShotResult(shotResult);
      }
    }

    private bool IsGameFinished() => _ships.All(ship => ship.IsSunk);
  }
}
