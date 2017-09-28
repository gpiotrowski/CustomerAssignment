using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Services
{
    public class CustomerCommandService : ICustomerCommandService
    {
        private readonly ICustomerCommandMapper _customerCommandMapper;

        public CustomerCommandService(ICustomerCommandMapper customerCommandMapper)
        {
            _customerCommandMapper = customerCommandMapper;
        }

        public void CreateNewCustomer(CreateCustomerRequest request)
        {
            var createCustomerCommand = _customerCommandMapper.Map(request);
        }
    }
}
