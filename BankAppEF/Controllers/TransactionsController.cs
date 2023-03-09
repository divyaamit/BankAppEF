using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Entities.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TransactionsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<IEnumerable<TransactionsModel>> Get()
        {
            IEnumerable<Transaction> transactionDetails = await unitOfWork.transaction.GetAll();
            return AppMapper<Transaction, TransactionsModel>.Map(transactionDetails);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<TransactionsModel> GetByID(int id)
        {
            Transaction transactionById = await this.unitOfWork.transaction.GetById(id);
            return AppMapper<Transaction, TransactionsModel>.Map(transactionById);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public IActionResult Post(TransactionsModel tra)
        {
            Transaction transactionDetails = AppMapper<TransactionsModel,Transaction>.Map(tra);
            this.unitOfWork.transaction.Insert(transactionDetails);
            return Ok();
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(TransactionsModel tra)
        {
            Transaction transactionDetails = AppMapper<TransactionsModel, Transaction>.Map(tra);
            this.unitOfWork.transaction.Update(transactionDetails);
            return Ok();
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.unitOfWork.transaction.DeleteById(id);
        }
    }
}
