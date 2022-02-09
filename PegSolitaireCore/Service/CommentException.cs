using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    class CommentException : Exception
    {
        public CommentException(string message) : base(message)
        {
        }

        public CommentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
