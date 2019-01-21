using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Exceptions
{
    public class CustomerExceptions: Exception
    {
        // default constructor
        public CustomerExceptions()
           : base("Please check all fields to ensure they are valid.")
        {
        }

        // constructor for customizing error message
        public CustomerExceptions(string messageValue)
           : base(messageValue)
        {
        }

        public CustomerExceptions(string messageValue, Exception inner)
        : base(messageValue, inner)
        {
        }
    }
}
