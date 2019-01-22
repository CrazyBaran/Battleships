using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Core
{
    public class DefaultRandomProvider : IRandomProvider
    {
        private Random _random = new Random();

        public Coordinates GetPosition(int gridSize, int shipSize, Orientation orientation)
        {
            if (orientation == Orientation.Vertical)
            {
                return new Coordinates(
                    x: _random.Next(gridSize - shipSize + 1),
                    y: _random.Next(gridSize)
                    );
            }
            else
            {
                return new Coordinates(
                    x: _random.Next(gridSize),
                    y: _random.Next(gridSize - shipSize + 1)
                    );
            }
        }

        public Orientation GetOrientation()
        {
            if (_random.Next() % 2 == 0) return Orientation.Horizontal;
            return Orientation.Vertical;
        }
    }
}
