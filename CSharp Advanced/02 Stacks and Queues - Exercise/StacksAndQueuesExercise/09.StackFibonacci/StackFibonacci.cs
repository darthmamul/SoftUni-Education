using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibonacci = new Stack<long>();

            fibonacci.Push(1);
            fibonacci.Push(1);

            for (int i = 2; i < n; i++)
            {
                long previous = fibonacci.Pop();
                long next = fibonacci.Peek() + previous;
                fibonacci.Push(previous);
                fibonacci.Push(next);
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
