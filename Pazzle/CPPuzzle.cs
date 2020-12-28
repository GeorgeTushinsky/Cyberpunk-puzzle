using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    public class CPPuzzle
    {
        PuzzleEngine _puzzleEngine;
        private int _selectionCount;
        private string[] _answerSeq;
        private List<int[]> _selectedIndices;

        public CPPuzzle(string[][] puzzleMatrix, string[] answerSeq)
        {
            _puzzleEngine = new PuzzleEngine(puzzleMatrix, answerSeq);
            _answerSeq = answerSeq;
            _selectionCount = 0;
            _selectedIndices = new List<int[]>();
        }

        public void RunPuzzle()
        {
            while (_selectionCount < _answerSeq.Length)
            {
                Console.Clear();
                PrintMatrix();
                PrintTargetSeq();
                int[] input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

                _puzzleEngine.Select(input[0], input[1]);
                _selectedIndices.Add(new int[] { input[0], input[1] });
                _selectionCount++;

                if (_answerSeq.SequenceEqual(_puzzleEngine.Choosen))
                {
                    Console.WriteLine("You win!");
                }
                else if (_selectionCount == _answerSeq.Length)
                {
                    Console.WriteLine("You lost!");
                }
            }
        }

        public void PrintMatrix()
        {
            int answerIndex = 0;
            for (int i = 0; i < _puzzleEngine.PuzzleMatrix.Length; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < _puzzleEngine.PuzzleMatrix[0].Length; j++)
                {
                    if (answerIndex < _selectedIndices.Count && i == _selectedIndices[answerIndex][0] && j == _selectedIndices[answerIndex][1])
                    {
                        answerIndex++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(_puzzleEngine.PuzzleMatrix[i][j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write(_puzzleEngine.PuzzleMatrix[i][j]);

                    if (j < _puzzleEngine.PuzzleMatrix[0].Length - 1) Console.Write(", ");
                }
                Console.WriteLine(" ]");
            }
            Console.WriteLine();
        }
        public void PrintTargetSeq()
        {
            Console.WriteLine($"Target sequence: [{String.Join(", ", _answerSeq)}]");
        }
    }
}
