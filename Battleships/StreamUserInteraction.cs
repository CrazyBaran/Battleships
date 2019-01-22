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

        public (int X, int Y) GetCoordinates(int xUpperBound, int yUpperBound)
        {
            (int X, int Y)? result = null;
            while (result == null)
            {
                _output.Write("Enter coordinates: ");
                var line = _input.ReadLine().Trim();
                if (line.Length == 2)
                {
                    var x = line[0].ToNumber();
                    if (x != null
                        && int.TryParse(line[1].ToString(), out int y)
                        && x >= 0 && x < xUpperBound
                        && y >= 0 && y < yUpperBound)
                    {
                        result = (x.Value, y);
                    }
                }
            }

            return result.Value;
        }

        public void Dispose()
        {
            _input.Dispose();
            _output.Dispose();
        }
    }
}
