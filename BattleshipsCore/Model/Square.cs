using System;

namespace Battleships.Core.Model
{
    public class Square : ISquare
    {
        private SquareState _state = SquareState.NotShotAt;
        private IShip _ship;

        public Square(IShip ship = null)
        {
            _ship = ship;
        }

        public ShotStatus Shoot()
        {
            if (_state == SquareState.ShotAt) return ShotStatus.Repeated;

            _state = SquareState.ShotAt;
            if(_ship == null)
            {
                return ShotStatus.Miss;
            }

            return _ship.Shoot();
        }
    }
}