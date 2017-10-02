using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Domain.Commands;

namespace CustomerAssignment.Customers.Application.Mappers
{
    public class CustomerCommandMapper : ICustomerCommandMapper
    {
        public CreateCustomerCommand Map(CreateCustomerRequest request)
        {
            var command = new CreateCustomerCommand()
            {
                CustomerFirstName = request.FirstName,
                CustomerLastName = request.LastName
            };

            return command;
        }

        public UpdateCustomerAddressCommand Map(UpdateCustomerAddressRequest request)
        {
            var command = new UpdateCustomerAddressCommand()
            {
                CustomerId = request.CustomerId,
                AppartmentNumber = request.AppartmentNumber,
                City = request.City,
                Country = request.Country,
                HouseNumber = request.HouseNumber,
                Street = request.Street,
                ZipCode = request.ZipCode
            };

            return command;
        }

        public UpdateCustomerNameCommand Map(UpdateCustomerNameRequest request)
        {
            var command = new UpdateCustomerNameCommand()
            {
                CustomerId = request.CustomerId,
                LastName = request.LastName,
                FirstName = request.FirstName
            };

            return command;
        }
    }
}
