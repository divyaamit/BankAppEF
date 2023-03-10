using BankApp.Data.Entities.Models;
using BankApp.Datalayer.Interface;
using BankApp.Entities.Model;
using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDTO accountObjDl;
        public AccountController(IAccountDTO accountObjDl)
        {
            this.accountObjDl = accountObjDl;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IEnumerable<AccountModel>> Get()
        {
            return await this.accountObjDl.GetAccountDl();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<AccountModel> GetByID(int id)
        {
            return await this.accountObjDl.GetAccountById(id);
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post(AccountModel acc)
        {
            accountObjDl.InsertAccount(acc);
            return Ok();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(AccountModel acc)
        {
            accountObjDl.UpdateAccount(acc);
            return Ok();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            accountObjDl.DeleteById(id);
        }
    }
}
