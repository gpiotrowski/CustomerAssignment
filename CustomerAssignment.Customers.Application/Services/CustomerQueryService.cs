using System;
using System.Collections.Generic;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Application.Services
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerListRepository _customerListRepository;
        private readonly ICustomerContactCardRepository _customerContactCardRepository;

        public CustomerQueryService(ICustomerListRepository customerListRepository, ICustomerContactCardRepository customerContactCardRepository)
        {
            _customerListRepository = customerListRepository;
            _customerContactCardRepository = customerContactCardRepository;
        }


        public List<CustomerListEntryReadModel> GetCustomerList()
        {
            var customerList = _customerListRepository.GetCustomerList();

            return customerList;
        }

        public CustomerContactCardReadModel GetContactCard(Guid customerId)
        {
            var customerContactCard = _customerContactCardRepository.GetCustomerContactCard(customerId);

            return customerContactCard;
        }
    }
}
