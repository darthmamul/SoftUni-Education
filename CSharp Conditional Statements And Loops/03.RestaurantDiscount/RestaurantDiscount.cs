using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RestaurantDiscount
{
    class RestaurantDiscount
    {
        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var package = Console.ReadLine().ToLower().Trim();

            var discountMultiplier = 0.0;
            var hall = String.Empty;
            var price = 0;

            if (people <= 50)
            {
                hall = "Small Hall";
                price += 2500;
            }
            else if (people <= 100)
            {
                hall = "Terrace";
                price += 5000;
            }
            else if (people <= 120)
            {
                hall = "Great Hall";
                price += 7500;
            }

            if (package == "normal")
            {
                discountMultiplier = 0.95;
                price += 500;
            }
            else if (package =="gold")
            {
                discountMultiplier = 0.90;
                price += 750;
            }
            else if (package == "platinum")
            {
                discountMultiplier = 0.85;
                price += 1000;
            }
            if (people > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                Console.WriteLine($"We can offer you the {hall}");
                Console.WriteLine("The price per person is {0:F2}$", (price * discountMultiplier) / people);
            }
        }
    }
}
