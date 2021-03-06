﻿using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Validations
{
    public interface ICustomerCommandValidation
    {
        void Validate(CreateCustomerRequest request);
        void Validate(UpdateCustomerAddressRequest request);
        void Validate(UpdateCustomerNameRequest request);
        void Validate(UpdateCustomerContactInfoRequest request);
    }
}