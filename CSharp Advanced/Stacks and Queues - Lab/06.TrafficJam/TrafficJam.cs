using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            var carsPerGreenLight = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var carsQueue = new Queue<string>();
            int carsThatPassedTotal = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    var carsThatCanPass = Math.Min(carsQueue.Count, carsPerGreenLight);
                    for (int counter = 0; counter < carsThatCanPass; counter++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        carsThatPassedTotal++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"{carsThatPassedTotal} cars passed the crossroads.");
        }
    }
}
