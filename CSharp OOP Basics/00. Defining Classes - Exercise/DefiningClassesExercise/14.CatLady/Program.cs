using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            var cats = new List<Cat>();

            var input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                var catInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var breed = catInfo[0];
                var name = catInfo[1];
                var property = double.Parse(catInfo[2]);

                var cat = new Cat(breed, name);
                if (breed.Equals("StreetExtraordinaire"))
                {
                    cat.Decibels = property;
                }
                else if (breed.Equals("Siamese"))
                {
                    cat.EarSize = property;
                }
                else
                {
                    cat.FurLength = property;
                }

                cats.Add(cat);
                input = Console.ReadLine();
            }

            var catName = Console.ReadLine().Trim();
            var catResult = cats.FirstOrDefault(c => c.Name.Equals(catName));
            Console.WriteLine(catResult);
        }
    }
}
