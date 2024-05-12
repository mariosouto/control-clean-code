using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidDeleteMobileUnitException : Exception
    {
        public InvalidDeleteMobileUnitException(string message = "It's not possible to delete this Mobile Unit " +
            "because it is on an Emergency Call.") : base(message)
        {
        }
    }
}
