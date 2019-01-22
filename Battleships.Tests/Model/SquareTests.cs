using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Moq;
using Battleships.Model;

namespace Battleships.Tests.Model
{
  public class SquareTests
  {
    [Fact]
    public void WhenShotAndWithoutShipItReturnsAMiss()
    {
      var square = new Square();

      var result = square.Shoot();

      result.ShouldBe(ShotStatus.Miss);
    }

    [Fact]
    public void WhenShotWithShipItDelegatesShotToShip()
    {
      var wasShipShot = false;
      var shipMock = new Mock<IShip>(MockBehavior.Strict);
      shipMock
          .Setup(ship => ship.Shoot())
          .Callback(() => wasShipShot = true)
          .Returns(ShotStatus.Hit);
      var square = new Square(shipMock.Object);

      square.Shoot();

      wasShipShot.ShouldBe(true);
    }

    [Fact]
    public void WhenShotMoreThanOnceItIgnoresTheShotAndReturnsRepeated()
    {
      var numberOfTimesShot = 0;
      var shipMock = new Mock<IShip>(MockBehavior.Strict);
      shipMock
          .Setup(ship => ship.Shoot())
          .Callback(() => numberOfTimesShot++)
          .Returns(ShotStatus.Hit);
      var square = new Square(shipMock.Object);

      square.Shoot();
      var secondShotResult = square.Shoot();

      secondShotResult.ShouldBe(ShotStatus.Repeated);
      numberOfTimesShot.ShouldBe(1);
    }
  }
}
