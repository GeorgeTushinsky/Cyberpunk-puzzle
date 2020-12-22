using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle;
using System;
using System.Collections.Generic;

namespace Pazzle.Test
{
    public static class Extension
    {
        public static string JoinArray(this List<string> arr, string separator)
        {
            return String.Join(separator, arr);
        }
    }

    [TestClass]
    public class PuzzleEngineTest
    {
        string[][] sampleArray = new string[][]
        {
            new string[]{ "1C", "F7", "55", "E9", "B1" },
            new string[]{ "55", "E9", "1C", "F7", "B1" },
            new string[]{ "55", "E9", "F7", "B1", "1C" },
            new string[]{ "F7", "55", "B1", "1C", "E9" },
            new string[]{ "E9", "B1", "55", "1C", "1C" }
        };

        [TestMethod]
        [ExpectedException(typeof(WrongValueChoosenException))]
        public void Turn1Choosen1Row0ColumnException()
        {
            PuzzleEngine puzzle = new PuzzleEngine(sampleArray, new string[] { "1C", "55", "B1", "1C" });

            puzzle.Select(1,0);
        }

        [TestMethod]
        public void Turn1Choosen0Row0ColumnReturnTrue()
        {
            PuzzleEngine puzzle = new PuzzleEngine(sampleArray, new string[] { "1C", "55", "B1", "1C" });
            string answer = "1C";

            puzzle.Select(0, 0);

            Assert.AreEqual(answer, puzzle.GetCurrentAnswerSequence().JoinArray(", "));

        }

        [TestMethod]
        public void Turn2Choosen2Row0ColumnReturnTrue()
        {
            PuzzleEngine puzzle = new PuzzleEngine(sampleArray, new string[] { "1C", "55", "B1", "1C" });
            puzzle.Select(0, 0);

            puzzle.Select(2, 0);
        }

        [TestMethod]
        public void PuzzleShouldBeSolved()
        {
            PuzzleEngine puzzle = new PuzzleEngine(sampleArray, new string[] { "1C", "55", "B1", "1C" });

            int[,] answerSequence = new int[,] { { 0, 0 }, { 2, 0 }, { 2, 3 }, { 3, 3 } };
            string answer = "1C, 55, B1, 1C";

            for (int i = 0; i < answerSequence.GetLength(0); i++)
            {
                puzzle.Select(answerSequence[i, 0], answerSequence[i, 1]);
            }

            Assert.AreEqual(answer, puzzle.GetCurrentAnswerSequence().JoinArray(", "));
        }  

        [TestMethod]
        [ExpectedException(typeof(WrongValueChoosenException))]
        public void Turn3WrongValueException()
        {
            PuzzleEngine puzzle = new PuzzleEngine(sampleArray, new string[] { "1C", "55", "B1", "1C" });

            int[,] answerSequence = new int[,] { { 0, 0 }, { 2, 0 }, { 2, 2 }, { 3, 3 } };
            int selectionTimes = 0;

            for (int i = 0; i < answerSequence.GetLength(0); i++)
            {
                puzzle.Select(answerSequence[i, 0], answerSequence[i, 1]);
                selectionTimes++;
            }

            Assert.AreEqual(2, selectionTimes);
        }
    }
}
