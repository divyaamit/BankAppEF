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
        private readonly IUnitOfWork unitOfWork;
        public ExecutiveController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<ExecutiveController>
        [HttpGet]
        public async Task<IEnumerable<ExecutiveModel>> Get()
        {
            IEnumerable<Executive> allExecutive = await unitOfWork.executive.GetAll();
            return AppMapper<Executive, ExecutiveModel>.Map(allExecutive);
        }

        // GET api/<ExecutiveController>/5
        [HttpGet("{id}")]
        public async Task<ExecutiveModel> GetByID(int id)
        {
            Executive executiveById = await this.unitOfWork.executive.GetById(id);
            return AppMapper<Executive, ExecutiveModel>.Map(executiveById);
        }

        // POST api/<ExecutiveController>
        [HttpPost]
        public IActionResult Post(ExecutiveModel exe)
        {
            Executive executiveDetails = AppMapper<ExecutiveModel, Executive >.Map(exe);
            this.unitOfWork.executive.Insert(executiveDetails);
            return Ok();
        }

        // PUT api/<ExecutiveController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ExecutiveModel exe)
        {
            Executive executiveDetails = AppMapper<ExecutiveModel, Executive>.Map(exe);
            this.unitOfWork.executive.Update(executiveDetails);
            return Ok();
        }

        // DELETE api/<ExecutiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.unitOfWork.executive.DeleteById(id);
        }
    }
}
