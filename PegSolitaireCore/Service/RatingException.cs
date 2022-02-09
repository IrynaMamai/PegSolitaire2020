using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    class RatingException : Exception
    {
        public RatingException(string message) : base(message)
        {
        }

        public RatingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
