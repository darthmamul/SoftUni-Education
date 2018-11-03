using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var buyers = GetBuyers();
            BuyFood(buyers);
            GetFoodBought(buyers);
        }

        private static void GetFoodBought(List<IBuyer> buyers)
        {
            var foodBought = buyers.Sum(b => b.Food);
            Console.WriteLine(foodBought);
        }

        private static void BuyFood(List<IBuyer> buyers)
        {
            while (true)
            {
                var inputName = Console.ReadLine();
                if (inputName == "End")
                {
                    break;
                }

                var buyer = buyers.FirstOrDefault(b => b.Name == inputName);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }

        private static List<IBuyer> GetBuyers()
        {
            var buyers = new List<IBuyer>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var tokens = ParseInput(Console.ReadLine());
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                switch (tokens.Length)
                {
                    case 3:
                        string group = tokens[2];
                        buyers.Add(new Rebel(name, age, group));
                        break;
                    case 4:
                        string id = tokens[2];
                        string birthdate = tokens[3];
                        buyers.Add(new Citizen(id, name, age, birthdate));
                        break;
                    default:
                        break;
                }
            }

            return buyers;
        }

        private static string[] ParseInput(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
