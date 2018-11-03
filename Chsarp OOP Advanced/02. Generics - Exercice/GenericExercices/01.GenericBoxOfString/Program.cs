using System;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var element = Console.ReadLine();
                var box = new Box<string>(element);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
