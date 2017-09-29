using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Aggregates
{
    public class Customer : AggregateRoot
    {
        public Name Name { get; set; }
        public Address Address { get; set; }
        public ContactPhone ContactPhone { get; set; }
    }
}
