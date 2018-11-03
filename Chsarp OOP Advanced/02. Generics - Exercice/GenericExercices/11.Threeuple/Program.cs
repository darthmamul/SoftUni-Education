﻿using System;

namespace _11.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var tuple1 = new Threeuple<string, string, string>(
                $"{input[0]} {input[1]}",
                input[2],
                input[3]);

            input = Console.ReadLine().Split(' ');
            var tuple2 = new Threeuple<string, int, bool>(
                input[0],
                int.Parse(input[1]), 
                input[2] == "drunk" ? true : false);

            input = Console.ReadLine().Split(' ');
            var tuple3 = new Threeuple<string, double, string>(
                input[0],
                double.Parse(input[1]),
                input[2]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
