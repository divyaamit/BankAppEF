//using BankApp.Repository.Interface;
//using BankAppEF.Datalayer.Implementation;
//using BankAppEF.Datalayer.Interface;
//using BankAppEF.Datalayer.Models;
//using BankAppEF.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace BankAppEF.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly IUnitOfWork unitOfWork;

//        public CustomerController(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }
//        // GET: api/<CustomerController>
//        [HttpGet]
//        public async Task<IEnumerable<CustomerModel>> Get()
//        {
//            IEnumerable<Customer> customers = await this.unitOfWork.customer.GetAll();
//            return AppMapper<Customer, CustomerModel>.Map(customers);
//        }

//        // GET api/<CustomerController>/5
//        [HttpGet("{id}")]
//        public async Task<CustomerModel> GetByID(int id)
//        {
//            Customer customerByID = await this.unitOfWork.customer.GetById(id);
//            return AppMapper<Customer,CustomerModel>.Map(customerByID);
//        }

//        // POST api/<CustomerController>
//        [HttpPost]
//        public IActionResult Post(CustomerModel cus)
//        {
//            Customer customerDetails = AppMapper<CustomerModel,Customer>.Map(cus);
//            unitOfWork.customer.Insert(customerDetails);
//            return Ok();
//        }

//        // PUT api/<CustomerController>/5
//        [HttpPut("{id}")]
//        public IActionResult Put(CustomerModel customerModel)
//        {
//            Customer customerdetails = AppMapper<CustomerModel, Customer>.Map(customerModel);
//            unitOfWork.customer.Update(customerdetails);
//            return Ok();
//        }

//        // DELETE api/<CustomerController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            unitOfWork.customer.DeleteById(id);
//        }
//    }
//}
