using System;
using System.Collections.Generic;
using System.Text;
using EFCORESample;

namespace BusinessLogic
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
    }
}
