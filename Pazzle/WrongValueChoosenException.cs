using System;

namespace Puzzle
{
    public class WrongValueChoosenException : Exception
    {
        public WrongValueChoosenException() { }
        public WrongValueChoosenException(string message) : base(message) { }
        public WrongValueChoosenException(string message, Exception inner) : base(message, inner) { }
    }
}
