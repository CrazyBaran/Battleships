using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public interface IRandomNumberProvider
    {
        int Next();
        int Next(int exclusiveMaxValue);
    }
}
