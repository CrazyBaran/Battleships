using Battleships.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public class GameLoop
  {
    private readonly Grid _grid;
    private readonly IUserInteraction _userInteraction;

    public GameLoop(Grid grid, IUserInteraction userInteraction)
    {
      _grid = grid;
      _userInteraction = userInteraction;
    }

    public void Run()
    {
      while (!_grid.IsGameFinished)
      {
        _userInteraction._output.WriteLine(_grid._grid.ToPrettyString());

        var coordinates = _userInteraction.ReadCoordinates(
            xUpperBound: _grid.Rows,
            yUpperBound: _grid.Columns); // TODO: check that's the right way around

        var shotResult = _grid.Shoot(coordinates);

        _userInteraction._output.WriteLine(shotResult.ToPrettyString());
      }
    }

  }
}
