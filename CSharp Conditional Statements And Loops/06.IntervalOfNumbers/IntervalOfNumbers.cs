using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.IntervalOfNumbers
{
    class IntervalOfNumbers
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            var startingFrom = Math.Min(firstNumber, secondNumber);
            var endingWith = Math.Max(firstNumber, secondNumber);

            for (int number = startingFrom; number <= endingWith; number++)
            {
                Console.WriteLine(number);
            }
        }
    }

}