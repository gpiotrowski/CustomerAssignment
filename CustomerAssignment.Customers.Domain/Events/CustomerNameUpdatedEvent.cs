using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Events
{
    public class CustomerNameUpdatedEvent : EventBase
    {
        public Name NewName { get; set; }

        public CustomerNameUpdatedEvent(Name newName)
        {
            NewName = newName;
        }
    }
}
