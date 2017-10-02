using System;

namespace CustomerAssignment.Customers.Infrastructure.ReadModel.Models
{
    public class CustomerContactCardReadModel
    {
        public Guid CustomerId { get; set; }
        public CustomerNameReadModel Name { get; set; }
        public CustomerAddressReadModel Address { get; set; }
        public CustomerContactPhoneReadModel ContactPhone { get; set; }
    }
}
