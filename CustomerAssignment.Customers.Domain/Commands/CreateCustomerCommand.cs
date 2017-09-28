using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Customers.Domain.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
