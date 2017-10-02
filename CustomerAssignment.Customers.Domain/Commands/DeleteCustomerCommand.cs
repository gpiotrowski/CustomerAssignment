using System;
using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Customers.Domain.Commands
{
    public class DeleteCustomerCommand : ICommand
    {
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
