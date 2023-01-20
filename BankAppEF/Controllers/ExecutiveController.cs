using BankAppEF.Datalayer.Interface;
using BankAppEF.Entities.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : ControllerBase
    {
        private readonly IExecutiveDTO executiveDL;
        public ExecutiveController(IExecutiveDTO _executiveDL)
        {
            this.executiveDL = _executiveDL;
        }
        // GET: api/<ExecutiveController>
        [HttpGet]
        public async Task<IEnumerable<ExecutiveModel>> Get()
        {
            return await executiveDL.GetExecutiveDl();
        }

        // GET api/<ExecutiveController>/5
        [HttpGet("{id}")]
        public async Task<ExecutiveModel> GetByID(int id)
        {
            return await this.executiveDL.GetExecutiveById(id);
        }

        // POST api/<ExecutiveController>
        [HttpPost]
        public IActionResult Post(ExecutiveModel exe)
        {
            this.executiveDL.InsertExecutive(exe);
            return Ok();
        }

        // PUT api/<ExecutiveController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ExecutiveModel exe)
        {
            this.executiveDL.UpdateExecutive(exe);
            return Ok();
        }

        // DELETE api/<ExecutiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.executiveDL.DeleteById(id);
        }
    }
}
