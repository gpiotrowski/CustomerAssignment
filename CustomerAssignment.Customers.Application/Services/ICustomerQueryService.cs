using System;
using System.Collections.Generic;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Application.Services
{
    public interface ICustomerQueryService
    {
        List<CustomerListEntryReadModel> GetCustomerList();
        CustomerContactCardReadModel GetContactCard(Guid customerId);
    }
}