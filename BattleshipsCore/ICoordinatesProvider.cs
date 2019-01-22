using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public interface ICoordinatesProvider
    {
        (Coordinates, Orientation) GetCoordinates(int gridSize, int shipSize);


    }
}
