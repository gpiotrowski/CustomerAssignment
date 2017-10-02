using System;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces
{
    public interface ICustomerContactCardRepository
    {
        CustomerContactCardReadModel GetCustomerContactCard(Guid customerId);
        void Save(CustomerContactCardReadModel customerContactCard);
    }
}