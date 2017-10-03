using CustomerAssignment.Common.Core.EventBus;
using CustomerAssignment.Customers.Domain.Events;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Models;

namespace CustomerAssignment.Customers.Domain.Handlers
{
    public class CustomerEventHandler : EventBusHandler, ICustomerEventHandler
    {
        private readonly ICustomerListRepository _customerListRepository;
        private readonly ICustomerContactCardRepository _customerContactCardRepository;

        public CustomerEventHandler(IEventBus eventBus, ICustomerListRepository customerListRepository, ICustomerContactCardRepository customerContactCardRepository) : base(eventBus)
        {
            _customerListRepository = customerListRepository;
            _customerContactCardRepository = customerContactCardRepository;
        }

        protected override void RegisterHandlers()
        {
            _eventBus.RegisterHandler<CustomerCreatedEvent>(Handle);
            _eventBus.RegisterHandler<CustomerNameUpdatedEvent>(Handle);
            _eventBus.RegisterHandler<CustomerAddressUpdatedEvent>(Handle);
            _eventBus.RegisterHandler<CustomerContactPhoneUpdatedEvent>(Handle);
            _eventBus.RegisterHandler<CustomerDeletedEvent>(Handle);
        }

        public void Handle(CustomerCreatedEvent @event)
        {
            var customerListEntry = new CustomerListEntryReadModel()
            {
                CustomerId = @event.Id,
                CustomerFirstName = @event.Name.FirstName,
                CustomerLastName = @event.Name.LastName
            };
            _customerListRepository.Save(customerListEntry);

            var customerContactCard = new CustomerContactCardReadModel()
            {
                CustomerId = @event.Id,
                Name = new CustomerNameReadModel()
                {
                    FirstName = @event.Name.FirstName,
                    LastName = @event.Name.LastName
                }
            };
            _customerContactCardRepository.Save(customerContactCard);
        }


        public void Handle(CustomerNameUpdatedEvent @event)
        {
            var customerListEntry = _customerListRepository.GetCustomerListEntry(@event.Id);
            customerListEntry.CustomerFirstName = @event.NewName.FirstName;
            customerListEntry.CustomerLastName = @event.NewName.LastName;
            _customerListRepository.Save(customerListEntry);

            var customerContactCard = _customerContactCardRepository.GetCustomerContactCard(@event.Id);
            customerContactCard.Name = new CustomerNameReadModel()
            {
                FirstName = @event.NewName.FirstName,
                LastName = @event.NewName.LastName
            };
            _customerContactCardRepository.Save(customerContactCard);
        }

        public void Handle(CustomerAddressUpdatedEvent @event)
        {
            var customerContactCard = _customerContactCardRepository.GetCustomerContactCard(@event.Id);
            customerContactCard.Address = new CustomerAddressReadModel()
            {
                AppartmentNumber = @event.NewAddress.AppartmentNumber,
                Country = @event.NewAddress.Country,
                Street = @event.NewAddress.Street,
                City = @event.NewAddress.City,
                ZipCode = @event.NewAddress.ZipCode,
                HouseNumber = @event.NewAddress.HouseNumber
            };

            _customerContactCardRepository.Save(customerContactCard);
        }

        public void Handle(CustomerContactPhoneUpdatedEvent @event)
        {
            var customerContactCard = _customerContactCardRepository.GetCustomerContactCard(@event.Id);
            customerContactCard.ContactPhone = new CustomerContactPhoneReadModel()
            {
                CountryCode = @event.ContactPhone.CountryCode,
                PhoneNumber = @event.ContactPhone.PhoneNumber,
            };

            _customerContactCardRepository.Save(customerContactCard);
        }

        public void Handle(CustomerDeletedEvent @event)
        {
            _customerListRepository.Delete(@event.Id);
            _customerContactCardRepository.Delete(@event.Id);
        }
    }
}
