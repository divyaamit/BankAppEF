using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDL CustomerobjDL;

        public CustomerController(ICustomerDL customerobjDL)
        {
            this.CustomerobjDL = customerobjDL;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            return await this.CustomerobjDL.GetCustomerDl();   
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerModel> GetByID(int id)
        {
            return await this.CustomerobjDL.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CustomerModel cus)
        {
            CustomerobjDL.InsertCustomer(cus);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(CustomerModel customerModel)
        {
            this.CustomerobjDL.UpdateCustomer(customerModel);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            CustomerobjDL.DeleteById(id);
        }
    }
}
