using System;
using System.Linq;

namespace _04.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] cells = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            long maxSum = 0;
            long currentSum = 0;
            int[,] resultMatrix = new int[3, 3];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        resultMatrix[0, 0] = matrix[row, col];
                        resultMatrix[0, 1] = matrix[row, col + 1];
                        resultMatrix[0, 2] = matrix[row, col + 2];
                        resultMatrix[1, 0] = matrix[row + 1, col];
                        resultMatrix[1, 1] = matrix[row + 1, col + 1];
                        resultMatrix[1, 2] = matrix[row + 1, col + 2];
                        resultMatrix[2, 0] = matrix[row + 2, col];
                        resultMatrix[2, 1] = matrix[row + 2, col + 1];
                        resultMatrix[2, 2] = matrix[row + 2, col + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine(resultMatrix[row, 2]);
            }
        }
    }
}
