using System;
using System.Linq;

namespace _06.TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            char[,] matrix = GetMatrix();
            matrix = GetHitMatrix(matrix);
            matrix = GetCollapseMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] GetCollapseMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string collapsedCol = "";
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (matrix[row, col] != ' ')
                    {
                        collapsedCol += matrix[row, col];
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    if (i >= collapsedCol.Length)
                    {
                        matrix[rows - 1 - i, col] = ' ';
                    }
                    else
                    {
                        matrix[rows - 1 - i, col] = collapsedCol[i];
                    }
                }
            }

            return matrix;
        }

        private static char[,] GetHitMatrix(char[,] matrix)
        {
            int[] shootingData = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int shotRow = shootingData[0];
            int shotCol = shootingData[1];
            int radius = shootingData[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isWithinRange = Math.Sqrt(Math.Pow(Math.Abs(shotRow - row), 2)
                        + Math.Pow(Math.Abs(shotCol - col), 2)) <= radius;
                    if (isWithinRange)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static char[,] GetMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            string text = Console.ReadLine();
            int index = 0;
            bool leftDirection = true;
            for (int row = rows - 1; row >= 0; row--)
            {
                if (leftDirection)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = text[index++];
                        if (index == text.Length)
                        {
                            index = 0;
                        }
                    }
                    leftDirection = false;
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = text[index++];
                        if (index == text.Length)
                        {
                            index = 0;
                        }
                    }
                    leftDirection = true;
                }
            }

            return matrix;
        }
    }
}
