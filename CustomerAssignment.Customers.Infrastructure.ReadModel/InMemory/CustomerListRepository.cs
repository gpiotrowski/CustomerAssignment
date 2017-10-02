using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.InMemory
{
    public class CustomerListRepository : ICustomerListRepository
    {
        private ConcurrentDictionary<Guid, CustomerListEntryReadModel> _customerListSource;
        

        public CustomerListRepository()
        {
            InitializeSources();
        }

        private void InitializeSources()
        {
            _customerListSource = new ConcurrentDictionary<Guid, CustomerListEntryReadModel>();
        }

        public CustomerListEntryReadModel GetCustomerListEntry(Guid customerId)
        {
            return _customerListSource.GetValueOrDefault(customerId);
        }

        public void Save(CustomerListEntryReadModel customer)
        {
            _customerListSource.AddOrUpdate(customer.CustomerId, customer, (id, model) => model);
        }
    }
}
