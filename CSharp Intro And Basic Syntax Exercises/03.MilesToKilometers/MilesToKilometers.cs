using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MilesToKilometers
{
    class MilesToKilometers
    {
        static void Main(string[] args)
        {
            var miles = double.Parse(Console.ReadLine());

            Console.WriteLine("{0:F2}", miles * 1.60934);
        }
    }
}
