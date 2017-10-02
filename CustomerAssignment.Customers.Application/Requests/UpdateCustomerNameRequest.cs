using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAssignment.Customers.Application.Requests
{
    public class UpdateCustomerNameRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
