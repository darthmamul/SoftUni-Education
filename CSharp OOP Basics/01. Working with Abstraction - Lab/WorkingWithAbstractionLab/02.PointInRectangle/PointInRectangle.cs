using System;
using System.Linq;

namespace _02.PointInRectangle
{
    class PointInRectangle
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var rectangle = new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
            var pointsCount = int.Parse(Console.ReadLine());
            for (int pointsCounter = 0; pointsCounter < pointsCount; pointsCounter++)
            {
                var pointCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
                var point = new Point(pointCoordinates[0], pointCoordinates[1]);
                var containsPoint = rectangle.Contains(point);
                Console.WriteLine(containsPoint);
            }

        }
    }
}
