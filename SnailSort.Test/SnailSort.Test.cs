using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SnailSort.Program;

namespace SnailSort.Test
{
    [TestClass]
    public class SnailSortTest
    {
        [TestMethod]
        public void ExpandSnailReturnsCorrectResult()
        {
            int[][] snailArr = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };
            int[] answer = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };

            int[] sortedArr = ExpandSnail(snailArr);

            CollectionAssert.AreEqual(answer, sortedArr);
        }
        [TestMethod]
        public void ExpandSnailInputLength0ReturnsEmptyJaggedArray()
        {
            int[][] snailArr = new int[0][];
            int[] answer = new int[0];

            int[] sortedArr = ExpandSnail(snailArr);

            CollectionAssert.AreEqual(answer, sortedArr);
        }

        [TestMethod]
        public void RotateMatrixReturnCorrectlyRotatedArray()
        {
            int[][] arr = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };
            int[][] answer = new int[][] {
                new int[] { 3, 6, 9 },
                new int[] { 2, 5, 8 },
                new int[] { 1, 4, 7 }
            };

            int[][] rotatedArr = RotateMatrix(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                CollectionAssert.AreEqual(answer[i], rotatedArr[i]);
            }
        }
    }
}
