using System;
using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Customers.Domain.Commands
{
    public class UpdateCustomerContactInfoCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public int CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
