using System;

namespace _02.GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var element = int.Parse(Console.ReadLine());
                var box = new Box<int>(element);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
