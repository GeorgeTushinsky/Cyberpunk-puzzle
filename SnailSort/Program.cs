using System;
using System.Collections.Generic;
using System.Linq;

namespace SnailSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] sortedArray = ExpandSnail(new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            });

            Console.WriteLine(String.Join(", ", sortedArray.Select(arr => String.Join(", ", arr))));
        }

        public static int[] ExpandSnail(int[][] array)
        {
            List<int> result = new List<int>();

            while (array.Length > 0)
            {
                result.AddRange(array[0]);
                array = RotateMatrix(array.Skip(1).ToArray());
            }

            return result.ToArray();
        }

        public static int[][] RotateMatrix(int[][] array)
        {
            if (array.Length == 0) return new int[0][];

            int rows = array[0].Length;
            int cols = array.Length;
            int[][] rotatedArray = new int[rows][];

            for (int i = rows - 1, j = 0; i >= 0; i--, j++)
            {
                rotatedArray[j] = new int[cols];
                for (int k = 0; k < cols; k++)
                {
                    rotatedArray[j][k] = array[k][i];
                }
            }
            return rotatedArray;
        }
    }
}
