using Battleships.Core.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Core.Tests
{
    public class GameLoopTests
    {
        [Fact]
        public void WhenAllShipsAreSunkItFinishesTheGameImmediately()
        {
            var shipMock = new Mock<IShip>(MockBehavior.Strict);
            shipMock.Setup(ship => ship.IsSunk()).Returns(true);
            var squareMock = new Mock<ISquare>(MockBehavior.Strict);
            squareMock.Setup(square => square.Ship).Returns(shipMock.Object);
            var userInteractionMock = new Mock<IUserInteraction>(MockBehavior.Strict);

            var gameLoop = new GameLoop(
                grid: new ISquare[,] { { squareMock.Object } },
                userInteraction: userInteractionMock.Object
                );

            gameLoop.Run();

            // if this test were to fail we would get a timeout or error
            // from user interaction mock
        }
    }
}
