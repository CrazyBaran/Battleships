using Battleships;
using Battleships.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Battleships
{
  public class StreamUserInteraction : IUserInteraction, IDisposable
  {
    private readonly StreamReader _input;
    public readonly StreamWriter _output;

    public StreamUserInteraction(Stream input, Stream output)
    {
      _input = new StreamReader(input);
      _output = new StreamWriter(output, Encoding.UTF8, 1024, leaveOpen: true);
    }


    public Coordinates ReadCoordinates(int xUpperBound, int yUpperBound)
    {
      while (true)
      {
        _output.Write("Enter coordinates: ");
        _output.Flush();

        var line = _input.ReadLine().Trim();
        if (Coordinates.TryParse(xUpperBound, yUpperBound, line, out Coordinates result))
          return result;
      }
    }

    public void Dispose()
    {
      _input.Dispose();
      _output.Dispose();
    }
  }
}
