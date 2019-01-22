using Battleships.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests
{
  public class GameLoopTests
  {
    [Fact]
    public void WhenAllShipsAreSunkItFinishesTheGameImmediately()
    {
      var gameLoop = new GameLoop(
          grid: new Grid(Mock.Of<ICoordinatesProvider>(), 10),
          userInteraction: Mock.Of<IUserInteraction>()
          );

      gameLoop.Run();

      // if this test were to fail we would get a timeout or error
      // from user interaction mock
    }
  }
}
