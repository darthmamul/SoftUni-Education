using System;

namespace _03.Ferraris
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = Console.ReadLine();
            var ferrari = new Ferrari("488-Spider", driver);
            Console.WriteLine(ferrari.ToString());

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
