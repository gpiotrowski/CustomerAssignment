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
            var customerId = _customerCommandService.CreateNewCustomer(createCustomerRequest);
            return Ok(customerId);
        }

        [HttpPost]
        public IActionResult UpdateCustomerAddress([FromBody]UpdateCustomerAddressRequest updateCustomerAddressRequest)
        {
            _customerCommandService.UpdateCustomerAddress(updateCustomerAddressRequest);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateCustomerName([FromBody]UpdateCustomerNameRequest updateCustomerNameRequest)
        {
            _customerCommandService.UpdateCustomerName(updateCustomerNameRequest);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateCustomerContactInfo([FromBody]UpdateCustomerContactInfoRequest updateCustomerContactInfoRequest)
        {
            _customerCommandService.UpdateCustomerContactInfo(updateCustomerContactInfoRequest);
            return Ok();
        }
    }
}