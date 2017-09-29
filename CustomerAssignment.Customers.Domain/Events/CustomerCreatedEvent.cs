using System;
using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Events
{
    public class CustomerCreatedEvent : EventBase
    {
        public Name Name { get; set; }

        public CustomerCreatedEvent(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}
