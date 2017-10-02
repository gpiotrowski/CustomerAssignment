using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Events
{
    public class CustomerContactPhoneUpdatedEvent : EventBase
    {
        public ContactPhone ContactPhone { get; set; }

        public CustomerContactPhoneUpdatedEvent(ContactPhone contactPhone)
        {
            ContactPhone = contactPhone;
        }
    }
}
