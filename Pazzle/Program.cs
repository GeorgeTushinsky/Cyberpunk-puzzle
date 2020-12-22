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
    }
}
