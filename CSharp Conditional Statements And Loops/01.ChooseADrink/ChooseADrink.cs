using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ChooseADrink
{
    class ChooseADrink
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine().ToLower().Trim();
            var drink = String.Empty;

            switch (profession)
            {
                case "athlete": drink = "Water";
                    break;
                case "businessman":
                case "businesswoman": drink = "Coffee";
                    break;
                case "softuni student": drink = "Beer";
                    break;
                default: drink = "Tea";
                    break;
            }
            Console.WriteLine(drink);
        }
    }
}
