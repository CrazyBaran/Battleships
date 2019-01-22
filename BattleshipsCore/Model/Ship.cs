using System;

namespace Battleships.Core.Model
{
    public class Ship : IShip
    {
        private int _remainingLife;

        public Ship(int remainingLife)
        {
            _remainingLife = remainingLife;
        }

        public ShotStatus Shoot()
        {
            _remainingLife--;
            if(_remainingLife <= 0)
            {
                return ShotStatus.Sink;
            }

            return ShotStatus.Hit;
        }
    }
}