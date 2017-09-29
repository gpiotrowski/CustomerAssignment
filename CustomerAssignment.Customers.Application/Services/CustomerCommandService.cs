﻿using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Application.Validations;
using CustomerAssignment.Customers.Domain.Buses;

namespace CustomerAssignment.Customers.Application.Services
{
    public class CustomerCommandService : ICustomerCommandService
    {
        private readonly ICustomerCommandMapper _customerCommandMapper;
        private readonly ICustomerCommandValidation _customerCommandValidation;
        private readonly ICustomerCommandBus _customerCommandBus;

        public CustomerCommandService(ICustomerCommandMapper customerCommandMapper, ICustomerCommandValidation customerCommandValidation, ICustomerCommandBus customerCommandBus)
        {
            _customerCommandMapper = customerCommandMapper;
            _customerCommandValidation = customerCommandValidation;
            _customerCommandBus = customerCommandBus;
        }

        public void CreateNewCustomer(CreateCustomerRequest request)
        {
            _customerCommandValidation.Validate(request);

            var createCustomerCommand = _customerCommandMapper.Map(request);
            _customerCommandBus.Send(createCustomerCommand);
        }
    }
}
