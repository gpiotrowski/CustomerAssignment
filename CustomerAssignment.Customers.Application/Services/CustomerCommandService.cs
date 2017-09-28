using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Application.Validations;

namespace CustomerAssignment.Customers.Application.Services
{
    public class CustomerCommandService : ICustomerCommandService
    {
        private readonly ICustomerCommandMapper _customerCommandMapper;
        private readonly ICustomerCommandValidation _customerCommandValidation;

        public CustomerCommandService(ICustomerCommandMapper customerCommandMapper, ICustomerCommandValidation customerCommandValidation)
        {
            _customerCommandMapper = customerCommandMapper;
            _customerCommandValidation = customerCommandValidation;
        }

        public void CreateNewCustomer(CreateCustomerRequest request)
        {
            _customerCommandValidation.Validate(request);

            var createCustomerCommand = _customerCommandMapper.Map(request);
        }
    }
}
