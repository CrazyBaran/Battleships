using Battleships.Core.Model;
using Shouldly;
using System;
using Xunit;

namespace Battleships.Core.Tests.Model
{
    public class ShipTests
    {
        [Theory]
        [InlineData(1, ShotStatus.Sink)]
        [InlineData(2, ShotStatus.Hit)]
        public void WhenShotItReturnsCorrectStatus(int remainingLife, ShotStatus expectedStatus)
        {
            var ship = new Ship(remainingLife);

            var shotStatus = ship.Shoot();

            shotStatus.ShouldBe(expectedStatus);
        }
    }
}
