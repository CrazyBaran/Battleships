using Battleships.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public class RandomCoordinatesProvider : ICoordinatesProvider
  {
    private Random _random = new Random(); // Could be static https://docs.microsoft.com/en-us/dotnet/api/system.random?redirectedfrom=MSDN&view=netframework-4.7.2#avoiding-multiple-instantiationsa

    public (Coordinates, Orientation) GetCoordinates(int gridSize, int shipSize)
    {
      var orientation = GetOrientation();
      var coordinates = GetCoordinates(gridSize, shipSize, orientation);
      return (coordinates, orientation);
    }
    private Coordinates GetCoordinates(int gridSize, int shipSize, Orientation orientation)
    {
      if (orientation == Orientation.Vertical)
      {
        return new Coordinates(
            x: _random.Next(gridSize - shipSize + 1),
            y: _random.Next(gridSize)
            );
      }
      else
      {
        return new Coordinates(
            x: _random.Next(gridSize),
            y: _random.Next(gridSize - shipSize + 1)
            );
      }
    }


    private Orientation GetOrientation()
    {
      return _random.Next() % 2 == 0 ? Orientation.Horizontal : Orientation.Vertical;
    }
  }
}
