using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> reversed = new Stack<int>();

            foreach (var number in input)
            {
                reversed.Push(number);
            }

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}
