using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class DuplicateCustomerException: ApplicationException
    {
        public DuplicateCustomerException() { }
        public DuplicateCustomerException(string message) : base(message) { }
    }
}
