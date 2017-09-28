using System;
using System.Collections.Generic;
using CustomerAssignment.Common.Application.Validations;

namespace CustomerAssignment.Common.Application.Exceptions
{
    public class InvalidRequestPropertiesException : Exception
    {
        public readonly ICollection<FailedValidation> FailedValidationResults;

        public InvalidRequestPropertiesException(List<FailedValidation> failedValidations) : base("Invalid request properties")
        {
            FailedValidationResults = failedValidations;
        }
    }
}
