using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.InMemory
{
    public class CustomerContactCardRepository : ICustomerContactCardRepository
    {
        private ConcurrentDictionary<Guid, CustomerContactCardReadModel> _customerContactCardSource;

        public CustomerContactCardRepository()
        {
            InitializeSources();
        }

        private void InitializeSources()
        {
            _customerContactCardSource = new ConcurrentDictionary<Guid, CustomerContactCardReadModel>();
        }

        public CustomerContactCardReadModel GetCustomerContactCard(Guid customerId)
        {
            return _customerContactCardSource.GetValueOrDefault(customerId);
        }

        public void Save(CustomerContactCardReadModel customerContactCard)
        {
            _customerContactCardSource.AddOrUpdate(customerContactCard.CustomerId, customerContactCard, (guid, model) => model);
        }
    }
}
