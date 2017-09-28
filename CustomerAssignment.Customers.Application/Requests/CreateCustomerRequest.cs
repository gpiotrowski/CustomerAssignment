using System.ComponentModel.DataAnnotations;

namespace CustomerAssignment.Customers.Application.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
