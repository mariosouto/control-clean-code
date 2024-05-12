using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLongitudeException : Exception
    {
        public InvalidLongitudeException(string message = "It is not a valid longitude, must be between 180 and -180") : base(message)
        {
        }
    }
}
