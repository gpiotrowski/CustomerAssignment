using System.ComponentModel.DataAnnotations;

namespace CustomerAssignment.Customers.Application.Requests
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
