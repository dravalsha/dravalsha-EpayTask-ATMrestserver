using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTserver.Models;
using RESTserver.Service;
using System.Collections.Generic;

namespace RESTserver.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomersDetails()
        {
            var customers = _customerService.GetCustomersDetails();
            return Ok(customers);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<Customer>> AddCustomerData([FromBody] List<Customer> customers)
        {
            var customerList = _customerService.AddCustomerData(customers);
            return Ok(customerList);
        }
    }
}
