using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Exceptions
{
    public class InvalidTimeException : Exception
    {
        public InvalidTimeException(string message) : base(message)
        {

        }
    }
}
