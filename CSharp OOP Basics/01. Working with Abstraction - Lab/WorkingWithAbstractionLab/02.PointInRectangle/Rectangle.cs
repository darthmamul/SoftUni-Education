using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    public Point TopLeft { get; set; }

    public Point BottomRight { get; set; }

    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        TopLeft = new Point(topX, topY);
        BottomRight = new Point(bottomX, bottomY);
    }

    public Rectangle(string coordsLine)
    {
        var coordinates = coordsLine()
                .Split()
                .Select(int.Parse)
                .ToList();
        var rectangle = new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
        TopLeft = new Point(coordinates[0], coordinates[1]);
        BottomRight = new Point(coordinates[2], coordinates[3]);
    }

    public bool Contains(Point point)
    {
        var contains = 
            point.X >= TopLeft.X &&
            point.X <= BottomRight.X &&
            point.Y >= TopLeft.Y &&
            point.Y <= BottomRight.Y;
        return contains;
    }
}

