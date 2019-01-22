using Battleships.Core;
using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Battleships
{
  public class StreamUserInteraction : IUserInteraction, IDisposable
  {
    private readonly StreamReader _input;
    private readonly StreamWriter _output;

    public StreamUserInteraction(Stream input, Stream output)
    {
      _input = new StreamReader(input);
      _output = new StreamWriter(output, Encoding.UTF8, 1024, leaveOpen: true);
    }

    public void WriteShotResult(ShotStatus shotResult) // is this simply a ShotStatus to string?
    {
      _output.WriteLine(shotResult.ToPrettyString());
    }

    public Coordinates ReadCoordinates(int xUpperBound, int yUpperBound)
    {
      while (true)
      {
        _output.Write("Enter coordinates: ");
        _output.Flush();

        var line = _input.ReadLine().Trim();
        if (Coordinates.TryParse(xUpperBound, yUpperBound, line, out Coordinates result))
          return result;
      }
    }

    public void WriteGrid(ISquare[,] grid)
    {
      _output.WriteLine();
      for (var x = 0; x < grid.GetLength(0); x++)
      {
        _output.Write("|");
        for (var y = 0; y < grid.GetLength(1); y++)
        {
          var square = grid[x, y];
          if (square.State == SquareState.NotShotAt)
          {
            _output.Write("_|");
            continue;
          }

          if (square.Ship == null)
          {
            _output.Write("o|");
            continue;
          }

          if (square.Ship.IsSunk)
          {
            _output.Write("D|");
            continue;
          }

          _output.Write("x|");
        }

        _output.WriteLine();
      }
    }

    public void Dispose()
    {
      _input.Dispose();
      _output.Dispose();
    }
  }
}
