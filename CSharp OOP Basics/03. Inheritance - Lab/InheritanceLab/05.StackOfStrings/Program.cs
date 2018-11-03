using System;

namespace _05.StackOfStringss
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new StackOfStrings();
            data.Push("one");

            Console.WriteLine(data.IsEmpty());
            try
            {
                Console.WriteLine(data.Pop());
                Console.WriteLine(data.Peek());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
