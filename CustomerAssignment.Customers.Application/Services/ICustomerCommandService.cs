using System;
using CustomerAssignment.Customers.Application.Requests;

namespace CustomerAssignment.Customers.Application.Services
{
    public interface ICustomerCommandService
    {
        Guid CreateNewCustomer(CreateCustomerRequest request);
        void UpdateCustomer(UpdateCustomerAddressRequest request);
    }
}