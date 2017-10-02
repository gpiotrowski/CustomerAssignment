using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CustomerAssignment.Common.Application.Exceptions;

namespace CustomerAssignment.Common.Application.Validations
{
    public class ValidationBase
    {
        protected void ValidateProperties(object objectToValidate)
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            var vc = new ValidationContext(objectToValidate, null, null);
            Validator.TryValidateObject(objectToValidate, vc, validationResults, true);

            var failedValidations = MapToFailedValidation(validationResults);

            if (failedValidations.Any())
            {
                throw new InvalidRequestPropertiesException(failedValidations);
            }
        }

        private List<FailedValidation> MapToFailedValidation(ICollection<ValidationResult> validationResults)
        {
            var failedValidations = new List<FailedValidation>();
            foreach (var validationResult in validationResults)
            {
                foreach (var validationResultMemberName in validationResult.MemberNames)
                {
                    var failedValidation = new FailedValidation()
                    {
                        MemberName = validationResultMemberName,
                        ErrorMessage = validationResult.ErrorMessage
                    };
                    failedValidations.Add(failedValidation);
                };
            }

            return failedValidations;
        }
    }
}
