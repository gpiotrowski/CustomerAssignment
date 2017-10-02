using System;
using CustomerAssignment.Customers.Application.Requests;
using CustomerAssignment.Customers.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAssignment.Customers.API.Controllers
{
    [Produces("application/json")]
    public class CustomersController : Controller
    {
        private readonly ICustomerCommandService _customerCommandService;
        private readonly ICustomerQueryService _customerQueryService;

        public CustomersController(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService)
        {
            _customerCommandService = customerCommandService;
            _customerQueryService = customerQueryService;
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

        [HttpDelete]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            _customerCommandService.DeleteCustomer(customerId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCustomerList()
        {
            var customerList = _customerQueryService.GetCustomerList();
            return Ok(customerList);
        }

        [HttpGet]
        public IActionResult GetCustomerContactCard(Guid customerId)
        {
            var customerContactCard = _customerQueryService.GetContactCard(customerId);
            return Ok(customerContactCard);
        }
    }
}