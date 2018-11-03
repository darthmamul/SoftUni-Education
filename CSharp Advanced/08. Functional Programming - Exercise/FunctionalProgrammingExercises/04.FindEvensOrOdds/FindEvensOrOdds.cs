using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            string evenOrOdd = Console.ReadLine();
            Func<int, bool> even = n => n % 2 == 0;
            Func<int, bool> odd = n => n % 2 != 0;

            foreach (var number in numbers)
            {
                if (evenOrOdd.Equals("even"))
                {
                    if (even.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
                else
                {
                    if (odd.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
