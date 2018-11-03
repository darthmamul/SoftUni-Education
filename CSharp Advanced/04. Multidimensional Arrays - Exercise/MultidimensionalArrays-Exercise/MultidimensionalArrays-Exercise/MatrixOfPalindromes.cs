using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = input[0];
            int c = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    int colIndex = col + row;
                    Console.Write($"{alphabet[row]}{alphabet[colIndex]}{alphabet[row]} ");
                }

                Console.WriteLine();
            }

        }
    }
}
