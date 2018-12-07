using System;
using System.Collections.Generic;
using System.Text;

namespace EFCORESample.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        bool AddCustomer(Customer customer);
        Customer GetCustomer(int Id);
    }
}
