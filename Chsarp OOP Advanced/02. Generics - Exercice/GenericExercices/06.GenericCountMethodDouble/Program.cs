using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = double.Parse(Console.ReadLine());

            List<Box<double>> boxesList = new List<Box<double>>();

            for (int i = 0; i < lines; i++)
            {
                Box<double> boxStr = new Box<double>(double.Parse(Console.ReadLine()));
                boxesList.Add(boxStr);
            }

            var element = double.Parse(Console.ReadLine());
            var result = GetGreaterElementsCount(boxesList, element);

            Console.WriteLine(result);
        }

        public static int GetGreaterElementsCount<T>(List<Box<T>> BoxesList, T element)
            where T : IComparable<T>
          => BoxesList.Count(b => b.Value.CompareTo(element) > 0);
    }
}

