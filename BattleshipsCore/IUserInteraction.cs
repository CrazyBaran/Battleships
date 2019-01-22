using System;
using System.Collections.Generic;
using System.Text;
using Battleships.Core.Model;

namespace Battleships.Core
{
    public interface IUserInteraction
    {
        Coordinates GetCoordinates(int xUpperBound, int yUpperBound);
        void DisplayShotResult(ShotStatus shotResult);
    }
}
