using System;

namespace ExpensesApp.Exceptions
{
    public class WarningResponseServerException : Exception
    {
        public WarningResponseServerException()
        {
        }

        public WarningResponseServerException(string message)
            : base(message)
        {
        }

        public WarningResponseServerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
