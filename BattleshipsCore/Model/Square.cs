using System;

namespace Battleships.Core.Model
{
    public class Square : ISquare
    {
        private SquareState _state = SquareState.NotShotAt;
        public IShip Ship { get; private set; }

        public Square(IShip ship = null)
        {
            Ship = ship;
        }

        public ShotStatus Shoot()
        {
            if (_state == SquareState.ShotAt) return ShotStatus.Repeated;

            _state = SquareState.ShotAt;
            if(Ship == null)
            {
                return ShotStatus.Miss;
            }

            return Ship.Shoot();
        }
    }
}