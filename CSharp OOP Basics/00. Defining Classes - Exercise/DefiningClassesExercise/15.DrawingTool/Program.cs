using System;

namespace _15.DrawingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            switch (figure)
            {
                case "Square":
                    var size = int.Parse(Console.ReadLine());
                    var square = new Square(size);
                    square.Draw();
                    break;
                case "Rectangle":
                    var sizeA = int.Parse(Console.ReadLine());
                    var sizeB = int.Parse(Console.ReadLine());
                    var rectangle = new Rectangle(sizeA, sizeB);
                    rectangle.Draw();
                    break;
            }
        }
    }
}
