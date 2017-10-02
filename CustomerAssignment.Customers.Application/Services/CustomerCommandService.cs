using System;
using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Application.Validations;
using CustomerAssignment.Customers.Domain.Buses;
using CustomerAssignment.Customers.Domain.Commands;

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

        public Guid CreateNewCustomer(CreateCustomerRequest request)
        {
            _customerCommandValidation.Validate(request);

            var createCustomerCommand = _customerCommandMapper.Map(request);
            createCustomerCommand.CustomerId = Guid.NewGuid();

            _customerCommandBus.Send(createCustomerCommand);

            return createCustomerCommand.CustomerId;
        }

        public void UpdateCustomerAddress(UpdateCustomerAddressRequest request)
        {
            _customerCommandValidation.Validate(request);

            var updateCustomerAddressCommand = _customerCommandMapper.Map(request);

            _customerCommandBus.Send(updateCustomerAddressCommand);
        }

        public void UpdateCustomerName(UpdateCustomerNameRequest request)
        {
            _customerCommandValidation.Validate(request);

            var updateCustomerNameCommand = _customerCommandMapper.Map(request);

            _customerCommandBus.Send(updateCustomerNameCommand);
        }

        public void UpdateCustomerContactInfo(UpdateCustomerContactInfoRequest request)
        {
            _customerCommandValidation.Validate(request);

            var updateCustomerContactInfoCommand = _customerCommandMapper.Map(request);

            _customerCommandBus.Send(updateCustomerContactInfoCommand);
        }

        public void DeleteCustomer(Guid customerId)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand(customerId);

            _customerCommandBus.Send(deleteCustomerCommand);
        }
    }
}
