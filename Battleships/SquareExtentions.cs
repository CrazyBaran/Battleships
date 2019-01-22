using Battleships.Model;
using System.Text;

namespace Battleships
{
  public static class SquareExtentions
  {
    public static string ToPrettyString(this ISquare[,] grid)
    {
      var stringBuilder = new StringBuilder();
      return stringBuilder.ToString();
    }

    public static void WriteGrid(StringBuilder stringBuilder, ISquare[,] grid)
    {
      stringBuilder.AppendLine();
      for (var row = 0; row < grid.GetLength(0); row++)
      {
        stringBuilder.Append("|");
        AppendRow(stringBuilder, grid, row);

        stringBuilder.AppendLine();
      }
    }

    private static void AppendRow(StringBuilder stringBuilder, ISquare[,] grid, int row)
    {
      for (var y = 0; y < grid.GetLength(1); y++)
      {
        var square = grid[row, y];
        AppendSquare(stringBuilder, square);
      }
    }

    private static void AppendSquare(StringBuilder stringBuilder, ISquare square)
    {
      if (square.State == SquareState.NotShotAt)
      {
        stringBuilder.Append("_|");
      }

      else if (square.Ship == null)
      {
        stringBuilder.Append("o|");
      }

      else if (square.Ship.IsSunk)
      {
        stringBuilder.Append("D|");
      }
      else
      {
        stringBuilder.Append("x|");
      }
    }


  }
}
