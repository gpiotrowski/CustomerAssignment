using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Services
{
    public interface ICustomerCommandService
    {
        void CreateNewCustomer(CreateCustomerRequest request);
    }
}