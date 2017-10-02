using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Events
{
    public class CustomerAddressUpdatedEvent : EventBase
    {
        public Address NewAddress { get; set; }

        public CustomerAddressUpdatedEvent(Address newAddress)
        {
            NewAddress = newAddress;
        }
    }
}
