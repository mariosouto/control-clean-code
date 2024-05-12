using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLevelOfUrgencyException : Exception
    {
        public InvalidLevelOfUrgencyException(string message = "It is not a valid latitude, it must be between 90 and -90") : base(message)
        {
        }
    }
}
