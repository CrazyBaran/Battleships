using Battleships.Model;
using System;

namespace Battleships
{
  static class ShotStatusExtension
  {
    public static string ToPrettyString(this ShotStatus status)
    {
      switch (status)
      {
        case ShotStatus.Hit:
          return "HIT!";
        case ShotStatus.Miss:
          return "Miss :(";
        case ShotStatus.Repeated:
          return "This square was already shot";
        case ShotStatus.Sink:
          return "Ship sinked!";
        default:
          throw new NotImplementedException();
      }
    }
  }
}
