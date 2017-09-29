using CustomerAssignment.Customers.Domain.Commands;
using CustomerAssignment.Customers.Domain.Factories;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public class CustomerCommandHandler : ICustomerCommandHandler
    {
        private readonly ICustomerFactory _customerFactory;

        public CustomerCommandHandler(ICustomerFactory customerFactory)
        {
            _customerFactory = customerFactory;
        }

        public void Handle(CreateCustomerCommand message)
        {
            var customerName = new Name()
            {
                FirstName = message.CustomerFirstName,
                LastName = message.CustomerLastName
            };

            var customer = _customerFactory.CreateCustomer(customerName);
        }
    }
}
