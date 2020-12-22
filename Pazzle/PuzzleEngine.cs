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
        private int _currentLine;
        private Direction _direction;
        private List<string> _choosen;
        private string[] _answerSequence;
        public PuzzleEngine(string[][] puzzleMatrix, string[] answerSequence)
        {
            PuzzleMatrix = puzzleMatrix;
            _currentLine = 0;
            _direction = Direction.Horizontal;
            _answerSequence = answerSequence;
            _choosen = new List<string>();
        }
        public void Select(int row, int index)
        {
            if (row >= PuzzleMatrix.Length || index >= PuzzleMatrix[0].Length) throw new WrongValueChoosenException("Wrong row or index value of matrix was choosen!");

            string answerValue = _answerSequence[_choosen.Count];
            string choosenValue = PuzzleMatrix[row][index];

            if (!answerValue.Equals(choosenValue)) throw new WrongValueChoosenException("Choosen value doesn't equals to next value in answer sequence!");

            if (_direction == Direction.Horizontal && row == _currentLine)
            {
                ChangeState(index, Direction.Vertical, choosenValue);
            }
            else if (_direction == Direction.Vertical && index == _currentLine)
            {
                ChangeState(row, Direction.Horizontal, choosenValue);
            }
            else throw new WrongValueChoosenException("Wrong row or index value of matrix was choosen!");
        }
        private void ChangeState(int line, Direction direction, string value)
        {
            _choosen.Add(value);
            _currentLine = line;
            _direction = direction;
        }
        public List<string> GetCurrentAnswerSequence()
        {
            return _choosen;
        }
    }
}
