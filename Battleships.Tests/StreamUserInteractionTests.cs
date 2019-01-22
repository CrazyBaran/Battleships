using Battleships.Tests.Utils;
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
                    ui.GetCoordinates(10, 10);
                }

                outputStream.Position = 0;
                var streamReader = new StreamReader(outputStream);
                streamReader.ReadToEnd().ShouldBe(expectedOutput);
            }
        }
    }
}
