﻿using CustomerAssignment.Common.Core.Commands.RetryPolicy;
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
            ConcurrencyExceptionRetryPolicy.Execute(() =>
            {
                _customerCommandHandler.Handle(command);
            });
        }

        public void Send(UpdateCustomerNameCommand command)
        {
            ConcurrencyExceptionRetryPolicy.Execute(() =>
            {
                _customerCommandHandler.Handle(command);
            });
        }

        public void Send(UpdateCustomerContactInfoCommand command)
        {
            ConcurrencyExceptionRetryPolicy.Execute(() =>
            {
                _customerCommandHandler.Handle(command);
            });
        }

        public void Send(DeleteCustomerCommand command)
        {
            ConcurrencyExceptionRetryPolicy.Execute(() =>
            {
                _customerCommandHandler.Handle(command);
            });
        }
    }
}
