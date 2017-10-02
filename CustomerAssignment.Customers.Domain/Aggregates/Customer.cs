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

        private Customer()
        {
        }

        internal Customer(Guid id, Name name)
        {
            ApplyChange(new CustomerCreatedEvent(id, name));
        }


        public void UpdateAddress(Address newAddress)
        {
            var customerAddressUpdatedEvent = new CustomerAddressUpdatedEvent(newAddress);
            ApplyChange(customerAddressUpdatedEvent);
        }

        private void Apply(CustomerCreatedEvent e)
        {
            Id = e.Id;
            _name = e.Name;
        }

        private void Apply(CustomerAddressUpdatedEvent e)
        {
            _address = e.NewAddress;
        }
    }
}
