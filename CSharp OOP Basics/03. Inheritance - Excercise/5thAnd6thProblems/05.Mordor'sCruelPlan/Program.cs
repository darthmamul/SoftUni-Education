using System;

namespace _05.Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var foods = Console.ReadLine()
                .ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var gandalf = new Gandalf();
            foreach (var food in foods)
            {
                gandalf.EatFood(food);
            }

            Console.WriteLine(gandalf.HappinessPoints);
            Console.WriteLine(gandalf.CalculateMood());
        }
    }
}
