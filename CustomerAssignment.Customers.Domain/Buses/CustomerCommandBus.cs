using CustomerAssignment.Customers.Domain.Commands;
using CustomerAssignment.Customers.Domain.Handlers;

namespace CustomerAssignment.Customers.Domain.Buses
{
    public class CustomerCommandBus : ICustomerCommandBus
    {
        private readonly ICustomerCommandHandler _customerCommandHandler;

        public CustomerCommandBus(ICustomerCommandHandler customerCommandHandler)
        {
            _customerCommandHandler = customerCommandHandler;
        }

        public void Send(CreateCustomerCommand command)
        {
            _customerCommandHandler.Handle(command);
        }

        public void Send(UpdateCustomerAddressCommand command)
        {
            _customerCommandHandler.Handle(command);
        }

        public void Send(UpdateCustomerNameCommand command)
        {
            _customerCommandHandler.Handle(command);
        }
    }
}
