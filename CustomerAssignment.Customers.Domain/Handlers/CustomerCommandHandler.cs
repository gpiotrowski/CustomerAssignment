using CustomerAssignment.Common.Core.Repositories;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.Commands;
using CustomerAssignment.Customers.Domain.Factories;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public class CustomerCommandHandler : ICustomerCommandHandler
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerCommandHandler(ICustomerFactory customerFactory, IRepository<Customer> customerRepository)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public void Handle(CreateCustomerCommand message)
        {
            var customerName = new Name()
            {
                FirstName = message.CustomerFirstName,
                LastName = message.CustomerLastName
            };

            var customer = _customerFactory.CreateCustomer(customerName);
            _customerRepository.Save(customer);
        }
    }
}
