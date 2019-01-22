using Battleships.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public interface ICoordinatesProvider
  {
    (Coordinates, Orientation) GetCoordinates(int gridSize, int shipSize);


  }
}
