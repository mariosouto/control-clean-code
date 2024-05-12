using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidAddMobileUnitException : Exception
    {
        public InvalidAddMobileUnitException(string message = "There is another Mobile Unit with that name.") : base(message)
        {
        }
    }
}
