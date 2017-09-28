using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAssignment.Customers.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAssignment.Customers.API.Controllers
{
    [Produces("application/json")]
    public class CustomersController : Controller
    {
        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CreateCustomerRequest createCustomerRequest)
        {
            return Ok();
        }
    }
}