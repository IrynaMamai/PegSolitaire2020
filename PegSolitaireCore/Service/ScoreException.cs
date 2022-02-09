using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    class ScoreException : Exception
    {
        public ScoreException(string message) : base(message)
        {
        }

        public ScoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
