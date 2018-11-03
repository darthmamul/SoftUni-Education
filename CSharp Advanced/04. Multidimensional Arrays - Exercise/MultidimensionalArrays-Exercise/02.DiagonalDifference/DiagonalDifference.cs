using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            long primarySum = 0;

            for (int row = 0; row < n; row++)
            {
                primarySum += matrix[row][row];
            }

            long secondarySum = 0;

            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondarySum += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
