using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixSize[0];
            int colsCount = matrixSize[1];

            int[,] matrix = FillMatrix(rowsCount, colsCount);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoStartPosition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilStartPosition = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilStartPosition[0];
                int evilCol = evilStartPosition[1];

                ClearEvilPosition(matrix, evilRow, evilCol);

                int ivoRow = ivoStartPosition[0];
                int ivoCol = ivoStartPosition[1];

                sum += CalculateIvosPoints(matrix, ivoRow, ivoCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long CalculateIvosPoints(int[,] matrix, int ivoRow, int ivoCol)
        {
            long sum = 0;
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }

        private static void ClearEvilPosition(int[,] matrix, int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static int[,] FillMatrix(int rowsCount, int colsCount)
        {
            int[,] matrix = new int[rowsCount, colsCount];

            int value = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            return matrix;
        }
    }
}
