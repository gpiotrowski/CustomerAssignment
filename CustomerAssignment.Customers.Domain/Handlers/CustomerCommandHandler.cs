using CustomerAssignment.Common.Core.Repositories;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.Commands;
using CustomerAssignment.Customers.Domain.Factories;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public class CustomerCommandHandler : ICustomerCommandHandler
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerCommandHandler(ICustomerFactory customerFactory, IRepository<Customer> customerRepository)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public void Handle(CreateCustomerCommand message)
        {
            var customerName = new Name()
            {
                FirstName = message.CustomerFirstName,
                LastName = message.CustomerLastName
            };

            var customer = _customerFactory.CreateCustomer(message.CustomerId, customerName);
            _customerRepository.Save(customer);
        }

        public void Handle(UpdateCustomerAddressCommand message)
        {
            var customer = _customerRepository.GetById(message.CustomerId);
            var newAddress = new Address()
            {
                AppartmentNumber = message.AppartmentNumber,
                Country = message.Country,
                City = message.City,
                Street = message.Street,
                ZipCode = message.ZipCode,
                HouseNumber = message.HouseNumber
            };

            customer.UpdateAddress(newAddress);

            _customerRepository.Save(customer);
        }

        public void Handle(UpdateCustomerNameCommand message)
        {
            var customer = _customerRepository.GetById(message.CustomerId);
            var newName = new Name()
            {
                FirstName = message.FirstName,
                LastName = message.LastName
            };

            customer.UpdateName(newName);

            _customerRepository.Save(customer);
        }

        public void Handle(UpdateCustomerContactInfoCommand message)
        {
            var customer = _customerRepository.GetById(message.CustomerId);
            var newContactPhone = new ContactPhone()
            {
                PhoneNumber = message.PhoneNumber,
                CountryCode = message.CountryCode
            };

            customer.UpdateContactPhone(newContactPhone);

            _customerRepository.Save(customer);
        }
    }
}
