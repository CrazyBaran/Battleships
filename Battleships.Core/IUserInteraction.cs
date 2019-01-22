using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Core.Model;

namespace Battleships.Core
{
  public interface IUserInteraction
  {
    Coordinates ReadCoordinates(int xUpperBound, int yUpperBound); // Following .Net console convention
    void WriteShotResult(ShotStatus shotResult);
    void WriteGrid(ISquare[,] grid);
  }
}
