using System;

namespace Battleships.Model
{
  public class Ship : IShip
  {
    private int _remainingLife;
    public int Size { get; private set; }

    public Ship(int size)
    {
      Size = size;
      _remainingLife = size;
    }

    public bool IsSunk => _remainingLife <= 0;

    public ShotStatus Shoot()
    {
      _remainingLife--;
      if (IsSunk)
      {
        return ShotStatus.Sink;
      }

      return ShotStatus.Hit;
    }
  }
}