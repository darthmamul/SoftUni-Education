using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5DifferentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var min = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());

            if (max - min < 4)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int firstDigit = min; firstDigit <= max; firstDigit++)
                {
                    for (int secondDigit = min; secondDigit <= max; secondDigit++)
                    {
                        for (int thirdDigit = min; thirdDigit <= max; thirdDigit++)
                        {
                            for (int fourthDigit = min; fourthDigit <= max; fourthDigit++)
                            {
                                for (int fifthDigit = min; fifthDigit <= max; fifthDigit++)
                                {
                                    if (firstDigit < secondDigit && secondDigit < thirdDigit
                                        && thirdDigit < fourthDigit && fourthDigit < fifthDigit)
                                    {
                                        Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit} {fourthDigit} {fifthDigit}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
