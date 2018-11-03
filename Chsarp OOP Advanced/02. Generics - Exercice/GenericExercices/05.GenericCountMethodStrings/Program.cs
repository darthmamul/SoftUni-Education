using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            List<Box<string>> boxesList = new List<Box<string>>();

            for (int i = 0; i < lines; i++)
            {
                Box<string> boxStr = new Box<string>(Console.ReadLine());
                boxesList.Add(boxStr);
            }

            var element = Console.ReadLine();
            var result = GetGreaterElementsCount(boxesList, element);

            Console.WriteLine(result);
        }

        public static int GetGreaterElementsCount<T>(List<Box<T>> BoxesList, T element)
            where T : IComparable<T>
          => BoxesList.Count(b => b.Value.CompareTo(element) > 0);
        
    }
}

