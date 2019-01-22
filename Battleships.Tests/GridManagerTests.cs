using Battleships.Model;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests
{
  public class GridManagerTests
  {
    [Fact]
    public void PlacesShipAtRandomPosition()
    {
      var randomProviderMock = new Mock<ICoordinatesProvider>(MockBehavior.Strict);
      randomProviderMock
          .Setup(random => random.GetCoordinates(It.IsAny<int>(), It.IsAny<int>()))
          .Returns((new Coordinates(2, 2), Orientation.Horizontal));

      var ship = new Ship(2);
      var gridGenerator = new Grid(randomProviderMock.Object, 10);
      gridGenerator.PlaceShips(new[] { ship });

      gridGenerator._grid[2, 2].Ship.ShouldBe(ship);
      gridGenerator._grid[2, 3].Ship.ShouldBe(ship);
      gridGenerator._grid[2, 4].Ship.ShouldNotBe(ship);
    }

    [Fact]
    public void RetriesPlacingShipIfSpaceIsTaken()
    {
      var coordinateIndex = 0;
      var possibleCoordinates = new[]
      {
                // conflicting coordinates
                new Coordinates(2, 0),
                // correct coordinates
                new Coordinates(0, 0)
            };
      var randomProviderMock = new Mock<ICoordinatesProvider>(MockBehavior.Strict);
      randomProviderMock
          .Setup(random => random.GetCoordinates(It.IsAny<int>(), It.IsAny<int>()))
          .Returns(() =>
          {
            var coordinates = possibleCoordinates[coordinateIndex];
            coordinateIndex++;
            return (coordinates, Orientation.Horizontal);
          });

      var gridGenerator = new Grid(randomProviderMock.Object, 10);
      var shipA = new Ship(3);
      gridGenerator._grid[1, 1] = new Square(shipA);
      gridGenerator._grid[2, 1] = new Square(shipA);
      gridGenerator._grid[3, 1] = new Square(shipA);
      var shipB = new Ship(2);


      gridGenerator.PlaceShips(new[] { shipB });

      gridGenerator._grid[0, 0].Ship.ShouldBe(shipB);
      gridGenerator._grid[0, 1].Ship.ShouldBe(shipB);
      gridGenerator._grid[0, 2].Ship.ShouldNotBe(shipB);
    }
  }
}
