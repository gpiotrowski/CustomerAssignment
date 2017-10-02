using CustomerAssignment.Common.Core.EventBus;
using CustomerAssignment.Customers.Domain.Events;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public interface ICustomerEventHandler : 
        IEventHandler<CustomerCreatedEvent>,
        IEventHandler<CustomerNameUpdatedEvent>,
        IEventHandler<CustomerAddressUpdatedEvent>,
        IEventHandler<CustomerContactPhoneUpdatedEvent>
    {
    }
}