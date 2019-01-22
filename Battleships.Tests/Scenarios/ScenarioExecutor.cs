using Battleships.Model;
using Battleships.Tests.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Battleships.Tests.Scenarios
{
  public static class ScenarioExecutor
  {
    public static string Execute(string input, ISquare[,] grid)
    {
      using (var inputStream = input.ToStream())
      {
        using (var outputStream = new MemoryStream())
        {
          using (var ui = new StreamUserInteraction(inputStream, outputStream))
          {
            var gameLoop = new GameLoop(grid, ui);
            gameLoop.Run();
          }

          outputStream.Position = 0;
          using (var streamReader = new StreamReader(outputStream))
          {
            return streamReader.ReadToEnd();
          }
        }

      }
    }
  }
}
