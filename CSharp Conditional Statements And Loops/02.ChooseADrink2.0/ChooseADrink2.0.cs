using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChooseADrink2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            double quanity = int.Parse(Console.ReadLine());
            var drink = String.Empty;
            var water = 0.70;
            var coffee = 1.00;
            var beer = 1.70;
            var tea = 1.20;
            var price = 0.0;

            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    price = water * quanity;
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    price = coffee * quanity;
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    price = beer * quanity;
                    break;
                default:
                    drink = "Tea";
                    price = tea * quanity;
                    break;
            }
            Console.WriteLine($"The {profession} has to pay {price:F2}.");
        }
    }
}
