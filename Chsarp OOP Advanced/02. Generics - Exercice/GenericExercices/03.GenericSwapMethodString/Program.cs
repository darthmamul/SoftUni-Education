using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
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

            var indexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            SwapElements(boxesList, indexes[0], indexes[1]);

            foreach (var box in boxesList)
            {
                Console.WriteLine(box);
            }
        }

        private static void SwapElements<T>(List<Box<T>> boxesList, int index1, int index2)
        {
            Box<T> temp = boxesList[index1];
            boxesList[index1] = boxesList[index2];
            boxesList[index2] = temp;
        }
    }
}
