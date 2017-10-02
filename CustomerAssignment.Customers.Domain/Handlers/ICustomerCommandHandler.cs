using CustomerAssignment.Common.Core.Commands;
using CustomerAssignment.Customers.Domain.Commands;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public interface ICustomerCommandHandler : 
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<UpdateCustomerAddressCommand>,
        ICommandHandler<UpdateCustomerNameCommand>,
        ICommandHandler<UpdateCustomerContactInfoCommand>
    {
    }
}