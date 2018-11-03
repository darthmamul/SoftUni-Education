using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var startLetter = char.Parse(Console.ReadLine());
            var endLetter = char.Parse(Console.ReadLine());
            var magicLetter = char.Parse(Console.ReadLine());

            for (char firstLetter = startLetter; firstLetter <= endLetter; firstLetter++)
            {
                for (char seconLetter = startLetter; seconLetter <= endLetter; seconLetter++)
                {
                    for (char thirdLetter = startLetter; thirdLetter <= endLetter; thirdLetter++)
                    {
                        string word = "" + firstLetter + seconLetter + thirdLetter;
                        if (!word.Contains(magicLetter))
                        {
                            Console.Write(word + " ");
                        }
                    }
                }
            }
        }
    }
}
