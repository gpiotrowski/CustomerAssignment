using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAssignment.Customers.API.Controllers
{
    [Produces("application/json")]
    public class CustomersController : Controller
    {
        private readonly ICustomerCommandService _customerCommandService;

        public CustomersController(ICustomerCommandService customerCommandService)
        {
            _customerCommandService = customerCommandService;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CreateCustomerRequest createCustomerRequest)
        {
            _customerCommandService.CreateNewCustomer(createCustomerRequest);
            return Ok();
        }
    }
}