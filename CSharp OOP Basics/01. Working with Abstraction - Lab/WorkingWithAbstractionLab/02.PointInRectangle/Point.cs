using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Func<string> readPoint)
    {
        var pointCoordinates = readPoint()
                .Split()
                .Select(int.Parse)
                .ToList();
        X = pointCoordinates[0];
        Y = pointCoordinates[1];
    }
}

