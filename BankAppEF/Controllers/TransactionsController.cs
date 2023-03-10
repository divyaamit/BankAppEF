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
        private readonly ITransactionsDTO transactionObjDl;
        public TransactionsController(ITransactionsDTO transactionObjDl)
        {
            this.transactionObjDl = transactionObjDl;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<IEnumerable<TransactionsModel>> Get()
        {
            return await this.transactionObjDl.GetTransactionsDl();
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<TransactionsModel> GetByID(int id)
        {
            return await this.transactionObjDl.GetTransactionsById(id);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public IActionResult Post(TransactionsModel tra)
        {
            transactionObjDl.InsertTransactions(tra);
            return Ok();
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(TransactionsModel tra)
        {
            transactionObjDl.UpdateTransactions(tra);
            return Ok();
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            transactionObjDl.DeleteById(id);
        }
    }
}
