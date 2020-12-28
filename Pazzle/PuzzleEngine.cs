using System.Collections.Generic;

namespace Puzzle
{
    public enum Direction
    {
        Vertical,
        Horizontal
    }
    public class PuzzleEngine
    {
        public string[][] PuzzleMatrix { get; private set; }
        private int CurrentLine { get; set; }
        private Direction Direction { get; set; }
        public List<string> Choosen { get; private set; }
        private string[] AnswerSeq { get; set; }
        public PuzzleEngine(string[][] puzzleMatrix, string[] answerSequence)
        {
            PuzzleMatrix = puzzleMatrix;
            CurrentLine = 0;
            Direction = Direction.Horizontal;
            AnswerSeq = answerSequence;
            Choosen = new List<string>();
        }
        public void Select(int row, int index)
        {
            if (row >= PuzzleMatrix.Length || index >= PuzzleMatrix[0].Length) throw new WrongValueChoosenException("Wrong row or index value of matrix was choosen!");

            string answerValue = AnswerSeq[Choosen.Count];
            string choosenValue = PuzzleMatrix[row][index];

            if (!answerValue.Equals(choosenValue)) throw new WrongValueChoosenException("Choosen value doesn't equals to next value in answer sequence!");
            if (Direction == Direction.Horizontal && row == CurrentLine) ChangeState(index, Direction.Vertical, choosenValue);
            else if (Direction == Direction.Vertical && index == CurrentLine) ChangeState(row, Direction.Horizontal, choosenValue);
            else throw new WrongValueChoosenException("Wrong row or index value of matrix was choosen!");
        }
        private void ChangeState(int line, Direction direction, string value)
        {
            Choosen.Add(value);
            CurrentLine = line;
            Direction = direction;
        }
    }
}
