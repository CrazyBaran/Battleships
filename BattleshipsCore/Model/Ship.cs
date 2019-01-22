using System;

namespace Battleships.Core.Model
{
    public class Ship : IShip
    {
        private int _remainingLife;

        public Ship(int life)
        {
            _remainingLife = life;
        }

        public bool IsSunk() => _remainingLife <= 0;

        public ShotStatus Shoot()
        {
            _remainingLife--;
            if(IsSunk())
            {
                return ShotStatus.Sink;
            }

            return ShotStatus.Hit;
        }
    }
}