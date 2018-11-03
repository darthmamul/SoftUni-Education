using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._3CaloriesCounter
{
    class CaloriesCounter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int calloriesCounter = 0;
            for (int i = 0; i < n; i++)
            {
                string ingredients = Console.ReadLine().ToLower();
                if (ingredients == "tomato sauce")
                {
                    calloriesCounter += 150;
                }
                if (ingredients == "cheese")
                {
                    calloriesCounter += 500;
                }
                if (ingredients == "salami")
                {
                    calloriesCounter += 600;
                }
                if (ingredients == "pepper")
                {
                    calloriesCounter += 50;
                }
            }
            Console.WriteLine("Total calories: " + calloriesCounter);
        }
    }
}
