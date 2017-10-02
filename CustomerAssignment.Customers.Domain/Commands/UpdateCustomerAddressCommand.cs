using System;
using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Customers.Domain.Commands
{
    public class UpdateCustomerAddressCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string AppartmentNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
