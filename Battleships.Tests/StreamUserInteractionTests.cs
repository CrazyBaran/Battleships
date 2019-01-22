using Battleships.Model;
using Battleships.Tests.Utils;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Battleships.Tests
{
  public class StreamUserInteractionTests
  {
    [Theory]
    [InlineData("A1\n", "Enter coordinates: ")]
    [InlineData("AA1\nA1\n", "Enter coordinates: Enter coordinates: ")]
    [InlineData("$1\nA1\n", "Enter coordinates: Enter coordinates: ")]
    [InlineData("AA\nA1\n", "Enter coordinates: Enter coordinates: ")]
    [InlineData("Z1\nA1\n", "Enter coordinates: Enter coordinates: ")]
    public void GetCoordinatesAsksForCoordinatesUntilSuccesfull(string input, string expectedOutput)
    {
      using (var inputStream = input.ToStream())
      {
        var outputStream = new MemoryStream();
        using (var ui = new StreamUserInteraction(inputStream, outputStream))
        {
          ui.ReadCoordinates(10, 10);
        }

        outputStream.Position = 0;
        var streamReader = new StreamReader(outputStream);
        streamReader.ReadToEnd().ShouldBe(expectedOutput);
      }
    }

    [Theory]
    [InlineData("A1\n", 0, 0)]
    [InlineData("A9\n", 0, 8)]
    [InlineData("J1\n", 9, 0)]
    [InlineData("J10\n", 9, 9)]
    public void GetCoordinatesCorrectlyPassesCoordinates(string input, int expectedX, int expectedY)
    {
      using (var inputStream = input.ToStream())
      {
        using (var ui = new StreamUserInteraction(inputStream, new MemoryStream()))
        {
          var coordinates = ui.ReadCoordinates(10, 10);
          coordinates.X.ShouldBe(expectedX);
          coordinates.Y.ShouldBe(expectedY);
        }
      }
    }
  }
}
