using System;

namespace _00.GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<string> boxStr = new Box<string>(Console.ReadLine());
            Console.WriteLine(boxStr);

            Box<int> boxInt = new Box<int>(int.Parse(Console.ReadLine()));

            Console.WriteLine(boxInt);
        }
    }
}
