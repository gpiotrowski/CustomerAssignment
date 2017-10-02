using System;
using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Customers.Domain.Events;
using CustomerAssignment.Customers.Domain.Exceptions;
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

        public void UpdateName(Name newName)
        {
            var customerNameUpdatedEvent = new CustomerNameUpdatedEvent(newName);
            ApplyChange(customerNameUpdatedEvent);
        }

        public void UpdateContactPhone(ContactPhone newContactPhone)
        {
            var customerContactPhoneUpdatedEvent = new CustomerContactPhoneUpdatedEvent(newContactPhone);
            ApplyChange(customerContactPhoneUpdatedEvent);
        }

        public void DeleteCustomer()
        {
            if (SoftDelete)
            {
                throw new ClientAlreadyDeletedException(Id);
            }

            var customerDeletedEvent = new CustomerDeletedEvent();
            ApplyChange(customerDeletedEvent);
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

        private void Apply(CustomerNameUpdatedEvent e)
        {
            _name = e.NewName;
        }

        private void Apply(CustomerContactPhoneUpdatedEvent e)
        {
            _contactPhone = e.ContactPhone;
        }

        private void Apply(CustomerDeletedEvent e)
        {
            SoftDelete = true;
        }
    }
}
