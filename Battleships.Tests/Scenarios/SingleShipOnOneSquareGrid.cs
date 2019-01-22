using Battleships.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests.Scenarios
{
  public class SingleShipOnOneSquareGrid
  {
    [Fact]
    public void RunsCorrectly()
    {
      var ship = new Ship(1);
      var grid = new Square[,] { { new Square(ship) } };

      var input = "A1\r\n";

      var output = ScenarioExecutor.Execute(input, grid);

      output.ShouldBe(@"
|_|
Enter coordinates: Ship sinked!
");
    }
  }
}
