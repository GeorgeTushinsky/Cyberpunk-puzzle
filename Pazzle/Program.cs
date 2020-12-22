using System;
using Puzzle;

namespace Pazzle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] sampleArray = new string[][]
            {
                new string[]{ "1C", "F7", "55", "E9", "B1" },
                new string[]{ "55", "E9", "1C", "F7", "B1" },
                new string[]{ "55", "E9", "F7", "B1", "1C" },
                new string[]{ "F7", "55", "B1", "1C", "E9" },
                new string[]{ "E9", "B1", "55", "1C", "1C" }
            };
            string[] answerArray = new string[] { "1C", "55", "B1", "1C" };
            CPPuzzle puzzle = new CPPuzzle(sampleArray, answerArray);
            puzzle.RunPuzzle();
        }

        public static void PrintPuzzleMatrix(string[][] sampleArray, int[,] answerSequence)
        {
            int answerIndex = 0;
            for (int i = 0; i < sampleArray.Length; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < sampleArray[0].Length; j++)
                {
                    if (answerIndex < answerSequence.GetLength(0) && i == answerSequence[answerIndex, 0] && j == answerSequence[answerIndex, 1])
                    {
                        answerIndex++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sampleArray[i][j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write(sampleArray[i][j]);

                    if (j < sampleArray[0].Length - 1) Console.Write(", ");
                }
                Console.WriteLine(" ]");
            }
            Console.WriteLine();
        }
    }
}
