using System;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer CreateCustomer(Guid customerId, Name name)
        {
            var customer = new Customer(customerId, name);

            return customer;
        }
    }
}
