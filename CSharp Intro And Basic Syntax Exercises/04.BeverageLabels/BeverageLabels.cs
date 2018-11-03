using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeverageLabels
{
    class BeverageLabels
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var sugar = int.Parse(Console.ReadLine());

            var coeficient = (double) volume / 100;
            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine("{0}kcal, {1}g sugars",
                energy * coeficient, sugar * coeficient);
        }
    }
}
