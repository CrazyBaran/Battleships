using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public interface IRandomProvider
    {
        Coordinates GetCoordinates(int gridSize, int shipSize, Orientation orientation);

        Orientation GetOrientation();
    }
}
