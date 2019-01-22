using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core.Model
{
    public interface ISquare
    {
        SquareState State { get; }
        IShip Ship { get; }
        ShotStatus Shoot();
    }
}
