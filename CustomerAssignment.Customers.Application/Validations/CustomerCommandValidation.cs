using CustomerAssignment.Common.Application.Validations;
using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Validations
{
    public class CustomerCommandValidation : ValidationBase, ICustomerCommandValidation
    {
        public void Validate(CreateCustomerRequest request)
        {
            ValidateProperties(request);
        }

        public void Validate(UpdateCustomerAddressRequest request)
        {
            ValidateProperties(request);
        }

        public void Validate(UpdateCustomerNameRequest request)
        {
            ValidateProperties(request);
        }

        public void Validate(UpdateCustomerContactInfoRequest request)
        {
            ValidateProperties(request);
        }
    }
}
