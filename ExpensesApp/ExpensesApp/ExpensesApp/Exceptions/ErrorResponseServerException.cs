using System;

namespace ExpensesApp.Exceptions
{
    public class ErrorResponseServerException : Exception
    {
        public ErrorResponseServerException()
        {
        }

        public ErrorResponseServerException(string message)
            : base(message)
        {
        }

        public ErrorResponseServerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
