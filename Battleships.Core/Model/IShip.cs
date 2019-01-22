using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core.Model
{
  public interface IShip
  {
    int Size { get; }
    ShotStatus Shoot();
    bool IsSunk { get; }
  }
}
