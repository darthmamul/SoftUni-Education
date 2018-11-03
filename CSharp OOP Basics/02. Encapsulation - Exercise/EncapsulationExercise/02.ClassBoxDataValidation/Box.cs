using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            this.height = value;
        }
    }


    public double GetSurfaceArea(double length, double width, double height)
    {
        return (2 * length * width) + (2 * length * height) + (2 * width * height);
    }

    public double GetLateralSurfaceaArea(double length, double width, double height)
    {
        return (2 * length * height) + (2 * width * height);
    }

    public double GetVolume(double length, double width, double height)
    {
        return length * width * height;
    }

    public override string ToString()
    {
        var sb = new StringBuilder()
            .AppendLine($"Surface Area - {GetSurfaceArea(this.length, this.width, this.height):f2}")
            .AppendLine($"Lateral Surface Area - {GetLateralSurfaceaArea(this.length, this.width, this.height):f2}")
            .AppendLine($"Volume - {GetVolume(this.length, this.width, this.height):f2}");
        return sb.ToString();
    }
}

