using System;

namespace BerlinClock.Exceptions
{
    public class InvalidTimeException : Exception
    {
        public InvalidTimeException(string message) : base(message)
        {

        }
    }
}
