using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            foreach (var word in words)
            {
                print(word);
            }
        }
    }
}
