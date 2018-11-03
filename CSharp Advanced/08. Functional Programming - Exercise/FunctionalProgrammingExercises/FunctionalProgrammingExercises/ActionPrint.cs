using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Action<string> print = n => Console.WriteLine(n);
            foreach (var word in words)
            {
                print(word);
            }

        }
    }
}
