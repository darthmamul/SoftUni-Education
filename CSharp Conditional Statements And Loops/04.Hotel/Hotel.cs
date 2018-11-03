using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Hotel
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine().ToLower();
            var nights = int.Parse(Console.ReadLine());

            var studioPrice = 0.0;
            var doublePrice = 0.0;
            var suitePrice = 0.0;
            

            switch (month)
            {
                case "may":
                case "october":
                    studioPrice = 50;
                    doublePrice = 65;
                    suitePrice = 75;
                    break;
                case "june":
                case "september":
                    studioPrice = 60;
                    doublePrice = 72;
                    suitePrice = 82;
                    break;
                case "july":
                case "august":
                case "december":
                    studioPrice = 68;
                    doublePrice = 77;
                    suitePrice = 89;
                    break;
            }

            if (nights > 7 && (month == "may" || month == "october"))
            {
                studioPrice *= 0.95;
            }
            else if (nights > 14 && (month == "june" || month == "september"))
            {
                doublePrice *= 0.9;
            }
            else if (nights > 14 && (month == "july" || month == "august" || month == "december"))
            {
                suitePrice *= 0.85;
            }

            var totalStudioPrice = studioPrice * nights;
            var totalDoublePrice = doublePrice * nights;
            var totalSuitePrice = suitePrice * nights;

            if (nights > 7 && (month == "september" || month == "october"))
            {
                totalStudioPrice -= studioPrice;
            }

            Console.WriteLine($"Studio: {totalStudioPrice:F2} lv.");
            Console.WriteLine($"Double: {totalDoublePrice:F2} lv.");
            Console.WriteLine($"Suite: {totalSuitePrice:F2} lv.");
        }
    }
}
