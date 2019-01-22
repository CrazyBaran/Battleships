using System;

namespace Battleships.Core.Model
{
    public class Square : ISquare
    {
        public SquareState State { get; private set; } = SquareState.NotShotAt;
        public IShip Ship { get; private set; }

        public Square(IShip ship = null)
        {
            Ship = ship;
        }

        public ShotStatus Shoot()
        {
            if (State == SquareState.ShotAt) return ShotStatus.Repeated;

            State = SquareState.ShotAt;
            if(Ship == null)
            {
                return ShotStatus.Miss;
            }

            return Ship.Shoot();
        }
    }
}