using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Domain.Commands;

namespace CustomerAssignment.Customers.Application.Mappers
{
    public interface ICustomerCommandMapper
    {
        CreateCustomerCommand Map(CreateCustomerRequest request);
        UpdateCustomerAddressCommand Map(UpdateCustomerAddressRequest request);
    }
}