using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Exceptions;
using EFCORESample;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        private string ServerError = "There is something wrong! Please contact admin";
        public CustomerController(ICustomerService customer)
        {
            this.service = customer;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetAllCustomers());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ServerError);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id<=0)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Id is not a valid value");
                }
                return Ok(service.GetCustomerById(id));
            }
            catch(CustomerNotFoundException cnf)
            {
                return StatusCode((int) HttpStatusCode.NotFound, cnf.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ServerError);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Data passed for customer is not valid");
                }
                service.AddCustomer(customer);
                return Created("/api/customer", customer);
             }
            catch(DuplicateCustomerException dce)
            {
                return Conflict(dce.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ServerError);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
