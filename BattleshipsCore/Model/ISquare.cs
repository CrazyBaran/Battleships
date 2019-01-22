using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core.Model
{
    public interface ISquare
    {
        ShotStatus Shoot();
    }
}
