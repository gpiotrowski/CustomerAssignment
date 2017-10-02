using System;
using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Customers.Domain.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
