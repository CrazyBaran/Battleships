using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core.Model
{
  public class Coordinates // Consider switching back to tuple - record types didnt make c# 8 :
  {
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coordinates(int x, int y)
    {
      X = x;
      Y = y;
    }
  }
}
