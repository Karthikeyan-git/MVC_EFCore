using System;
using System.Collections.Generic;
using BusinessLogic.Exceptions;
using EFCORESample;
using EFCORESample.Repository;

namespace BusinessLogic
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository)
        {
            this.repository = _repository;
        }

        public List<Customer> GetAllCustomers()
        {
            return repository.GetCustomers();
        }

        public bool AddCustomer(Customer customer)
        {
            var fetchedCustomer = repository.GetCustomer(customer.Id);
            if (fetchedCustomer == null)
            {
                return repository.AddCustomer(customer);
            }
            else
            {
                throw new DuplicateCustomerException($"Customer with id {customer.Id} already exists");
            }
        }

        public Customer GetCustomerById(int id)
        {
            var customer = repository.GetCustomer(id);
            if(customer!=null)
            {
                return customer;
            }
            else
            {
                throw new CustomerNotFoundException($"Customer with id {id} does not exist");
            }
        }
    }
}
