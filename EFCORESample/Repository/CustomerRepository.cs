using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFCORESample.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        ICustomerDbContext customerDbContext = null;

        public CustomerRepository(ICustomerDbContext context)
        {
            customerDbContext = context;
        }

        public bool AddCustomer(Customer customer)
        {
            customerDbContext.Customers.Add(customer);
            int result= customerDbContext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public List<Customer> GetCustomers()
        {
            return customerDbContext.Customers.ToList();
        }
    }
}
