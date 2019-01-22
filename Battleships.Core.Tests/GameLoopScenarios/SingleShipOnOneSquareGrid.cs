using Battleships.Core.Model;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Core.Tests.GameLoopScenarios
{
    public class SingleShipOnOneSquareGrid
    {
        [Fact]
        public void RunsCorrectly()
        {
            var ship = new Ship(1);
            var userInteractionMock = new Mock<IUserInteraction>();
            userInteractionMock
                .Setup(ui => ui.GetCoordinates(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(() => (0, 0));

            var gameLoop = new GameLoop(
                grid: new Square[,] { { new Square(ship) } },
                userInteraction: userInteractionMock.Object
                );

            gameLoop.Start();

            ship.IsSunk().ShouldBe(true);
        }
    }
}
