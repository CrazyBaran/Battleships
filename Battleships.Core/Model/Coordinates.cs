using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core.Model
{
  public class Coordinates
  {
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coordinates(int x, int y)
    {
      X = x;
      Y = y;
    }

    public static bool TryParse(int xUpperBound, int yUpperBound, string line, out Coordinates result)
    {
      result = null;
      if (line.Length >= 2)
      {
        var x = line[0].ToNumber();
        if (x != null
            && int.TryParse(line.Substring(1), out int y)
            && x >= 0 && x <= xUpperBound
            && y >= 0 && y <= yUpperBound)
        {
          result = new Coordinates(x.Value - 1, y - 1);
        }
      }

      return result != null;
    }
  }
}
