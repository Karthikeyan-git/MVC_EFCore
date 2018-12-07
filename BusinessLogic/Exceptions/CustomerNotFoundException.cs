using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class CustomerNotFoundException: ApplicationException
    {
        public CustomerNotFoundException() { }
        public CustomerNotFoundException(string message) : base(message) { }
    }
}
