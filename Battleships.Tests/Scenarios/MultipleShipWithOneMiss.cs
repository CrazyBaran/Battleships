using Battleships.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests.Scenarios
{
  public class MultipleShipWithOneMiss
  {
    /*[Fact]
    public void RunsCorrectly()
    {
      var shipA = new Ship(1);
      var shipB = new Ship(2);
      var grid = new Square[,]
      {
                { new Square(shipA), new Square() },
                { new Square(shipB), new Square(shipB) }
      };

      var input = @"A1
B1
A2
B2
";

      var output = ScenarioExecutor.Execute(input, grid);

      output.ShouldBe(@"
|_|_|
|_|_|
Enter coordinates: Ship sinked!

|D|_|
|_|_|
Enter coordinates: HIT!

|D|_|
|x|_|
Enter coordinates: Miss :(

|D|o|
|x|_|
Enter coordinates: Ship sinked!
");
    }*/
  }
}
