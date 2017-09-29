using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer CreateCustomer(Name name)
        {
            var customer = new Customer(name);

            return customer;
        }
    }
}
