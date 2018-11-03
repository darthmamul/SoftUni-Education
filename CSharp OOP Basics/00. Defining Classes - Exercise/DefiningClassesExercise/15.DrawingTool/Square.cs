using System;
using System.Collections.Generic;
using System.Text;


public class Square : CorDraw
{
    private int size;

    public Square(int size)
    {
        this.size = size;
    }

    public override void Draw()
    {
        var sb = new StringBuilder();
        sb.Append("|").Append(new string('-', size)).AppendLine("|");
        for (int i = 0; i < this.size - 2; i++)
        {
            sb.Append("|").Append(new string(' ', size)).AppendLine("|");
        }
        if (size > 1)
        {
            sb.Append("|").Append(new string('-', size)).AppendLine("|");
        }

        Console.WriteLine(sb.ToString());
    }
}

