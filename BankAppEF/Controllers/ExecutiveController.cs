using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : ControllerBase
    {
        private readonly IExecutiveDTO executiveObjDl;
        public ExecutiveController(IExecutiveDTO executiveObjDl)
        {
            this.executiveObjDl = executiveObjDl;
        }
        // GET: api/<ExecutiveController>
        [HttpGet]
        public async Task<IEnumerable<ExecutiveModel>> Get()
        {
            return await this.executiveObjDl.GetExecutiveDl();
        }

        // GET api/<ExecutiveController>/5
        [HttpGet("{id}")]
        public async Task<ExecutiveModel> GetByID(int id)
        {
            return await this.executiveObjDl.GetExecutiveById(id);
        }

        // POST api/<ExecutiveController>
        [HttpPost]
        public IActionResult Post(ExecutiveModel exe)
        {
            executiveObjDl.InsertExecutive(exe);
            return Ok();
        }

        // PUT api/<ExecutiveController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ExecutiveModel exe)
        {
            executiveObjDl.UpdateExecutive(exe);
            return Ok();
        }

        // DELETE api/<ExecutiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            executiveObjDl.DeleteById(id);
        }
    }
}
