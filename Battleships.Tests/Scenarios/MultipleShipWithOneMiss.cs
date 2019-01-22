using Battleships.Core.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests.Scenarios
{
    public class MultipleShipWithOneMiss
    {
        [Fact]
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

            output.ShouldBe(@"Enter coordinates: Ship sinked!
Enter coordinates: HIT!
Enter coordinates: Miss :(
Enter coordinates: Ship sinked!
");
        }
    }
}
