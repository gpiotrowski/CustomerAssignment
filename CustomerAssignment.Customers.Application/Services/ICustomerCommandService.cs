using System;
using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Services
{
    public interface ICustomerCommandService
    {
        Guid CreateNewCustomer(CreateCustomerRequest request);
        void UpdateCustomerAddress(UpdateCustomerAddressRequest request);
        void UpdateCustomerName(UpdateCustomerNameRequest request);
        void UpdateCustomerContactInfo(UpdateCustomerContactInfoRequest updateCustomerContactInfoRequest);
    }
}