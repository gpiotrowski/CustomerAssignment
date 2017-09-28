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
                CustomerName = request.Name,
                CustomerSurname = request.Surname
            };

            return command;
        }
    }
}
