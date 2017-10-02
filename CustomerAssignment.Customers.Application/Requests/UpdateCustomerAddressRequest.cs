using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAssignment.Customers.Application.Requests
{
    public class UpdateCustomerAddressRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string AppartmentNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
