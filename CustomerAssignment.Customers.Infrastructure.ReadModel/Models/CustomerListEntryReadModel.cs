using System;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.Models
{
    public class CustomerListEntryReadModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
