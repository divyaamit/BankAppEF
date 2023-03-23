using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDTO customerObjDl;

        public CustomerController(ICustomerDTO customerObjDl)
        {
            this.customerObjDl = customerObjDl;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            return await this.customerObjDl.GetCustomerDl();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerModel> GetByID(int id)
        {

            return await this.customerObjDl.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CustomerModel cus)
        {

            customerObjDl.InsertCustomer(cus);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(CustomerModel cus)
        {
            customerObjDl.UpdateCustomer(cus);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerObjDl.DeleteById(id);
        }
    }
}
