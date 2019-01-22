using Battleships.Core;
using Battleships.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Battleships
{
    public class StreamUserInteraction : IUserInteraction, IDisposable
    {
        private readonly StreamReader _input;
        private readonly StreamWriter _output;

        public StreamUserInteraction(Stream input, Stream output)
        {
            _input = new StreamReader(input);
            _output = new StreamWriter(output, Encoding.UTF8, 1024, leaveOpen: true);
        }

        public void DisplayShotResult(ShotStatus shotResult)
        {
            switch (shotResult)
            {
                case ShotStatus.Hit:
                    _output.WriteLine("HIT!");
                    break;
                case ShotStatus.Miss:
                    _output.WriteLine("Miss :(");
                    break;
                case ShotStatus.Repeated:
                    _output.WriteLine("This square was already shot");
                    break;
                case ShotStatus.Sink:
                    _output.WriteLine("Ship sinked!");
                    break;
            }
        }

        public Coordinates GetCoordinates(int xUpperBound, int yUpperBound)
        {
            Coordinates result = null;
            while (result == null)
            {
                _output.Write("Enter coordinates: ");
                _output.Flush();
                var line = _input.ReadLine().Trim();
                if (line.Length >= 2)
                {
                    var x = line[0].ToNumber();
                    if (x != null
                        && int.TryParse(line.Substring(1), out int y)
                        && x >= 0 && x <= xUpperBound
                        && y >= 0 && y <= yUpperBound)
                    {
                        result = new Coordinates(x.Value - 1, y - 1);
                    }
                }
            }

            return result;
        }

        public void DisplayGrid(ISquare[,] grid)
        {
            _output.WriteLine();
            for(var x = 0;x < grid.GetLength(0);x++)
            {
                _output.Write("|");
                for (var y = 0;y < grid.GetLength(1);y++)
                {
                    var square = grid[x, y];
                    if(square.State == SquareState.NotShotAt)
                    {
                        _output.Write("_|");
                        continue;
                    }

                    if (square.Ship == null)
                    {
                        _output.Write("o|");
                        continue;
                    }

                    if(square.Ship.IsSunk())
                    {
                        _output.Write("D|");
                        continue;
                    }

                    _output.Write("x|");
                }

                _output.WriteLine();
            }
        }

        public void Dispose()
        {
            _input.Dispose();
            _output.Dispose();
        }
    }
}
