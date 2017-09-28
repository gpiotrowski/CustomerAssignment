using System.Linq;
using CustomerAssignment.Common.Application.Exceptions;
using CustomerAssignment.Common.Application.Validations;
using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Validations
{
    public class CustomerCommandValidation : ValidationBase, ICustomerCommandValidation
    {
        public void Validate(CreateCustomerRequest request)
        {
            var failedValidations = ValidateProperties(request);
            if (failedValidations.Any())
            {
                throw new InvalidRequestPropertiesException(failedValidations);
            }
        }
    }
}
