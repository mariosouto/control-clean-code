using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLatitudeException : Exception
    {
        public InvalidLatitudeException(string message = "It is not a valid plate, the lenght has to be 7.") : base(message)
        {
        }
    }
}
