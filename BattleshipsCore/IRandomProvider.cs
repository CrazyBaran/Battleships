using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public interface IRandomProvider
    {
        Coordinates GetPosition(int gridSize, int shipSize, Orientation orientation);

        Orientation GetOrientation();
    }
}
