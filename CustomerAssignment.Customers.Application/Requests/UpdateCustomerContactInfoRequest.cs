using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAssignment.Customers.Application.Requests
{
    public class UpdateCustomerContactInfoRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
