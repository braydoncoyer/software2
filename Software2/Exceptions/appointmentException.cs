using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Exceptions
{
    public class appointmentException: Exception
    {
        // default constructor
        public appointmentException()
           : base("Please check all fields to ensure they are valid.")
        {
            // empty body
        }

        // constructor for customizing error message
        public appointmentException(string messageValue)
           : base(messageValue)
        {
            // empty body
        }

        // constructor for customizing the exception's error
        // message and specifying the InnerException object
        public appointmentException(string messageValue, Exception inner)
        : base(messageValue, inner)
        {
            // empty body
        }
    }
}
