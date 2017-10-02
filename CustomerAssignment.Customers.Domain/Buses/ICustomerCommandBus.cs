using CustomerAssignment.Common.Core.Buses;
using CustomerAssignment.Customers.Domain.Commands;

namespace CustomerAssignment.Customers.Domain.Buses
{
    public interface ICustomerCommandBus : 
        ICommandSender<CreateCustomerCommand>,
        ICommandSender<UpdateCustomerAddressCommand>,
        ICommandSender<UpdateCustomerNameCommand>
    {
    }
}