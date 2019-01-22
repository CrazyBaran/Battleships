using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Model;

namespace Battleships
{
  public interface IUserInteraction // What pattern are we using here?
  {
    Coordinates ReadCoordinates(int xUpperBound, int yUpperBound); // Following .Net console convention
    void WriteShotResult(ShotStatus shotResult);
    void WriteGrid(ISquare[,] grid);
  }
}
