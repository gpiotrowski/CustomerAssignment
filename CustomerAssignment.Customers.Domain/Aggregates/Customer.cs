using System;
using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Customers.Domain.Events;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Aggregates
{
    public class Customer : AggregateRoot
    {
        private Name _name { get; set; }
        private Address _address { get; set; }
        private ContactPhone _contactPhone { get; set; }

        internal Customer(Name name)
        {
            ApplyChange(new CustomerCreatedEvent(Guid.NewGuid(), name));
        }

        private void Apply(CustomerCreatedEvent e)
        {
            Id = e.Id;
            Version = e.Version;
            _name = e.Name;
        }
    }
}
