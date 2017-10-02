using System;
using System.Collections.Generic;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces
{
    public interface ICustomerListRepository
    {
        void Save(CustomerListEntryReadModel customer);
        CustomerListEntryReadModel GetCustomerListEntry(Guid customerId);
        List<CustomerListEntryReadModel> GetCustomerList();
    }
}