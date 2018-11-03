using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            //IList - за повече гъвкавост, по-голяма абстракция(същото и в Swap метода)
            IList<Box<int>> boxesList = new List<Box<int>>();

            for (int i = 0; i < lines; i++)
            {
                Box<int> boxStr = new Box<int>(int.Parse(Console.ReadLine()));
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

        private static void SwapElements<T>(IList<T> boxesList, int index1, int index2)
        {
            T temp = boxesList[index1];
            boxesList[index1] = boxesList[index2];
            boxesList[index2] = temp;
        }
    }
}

