using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<AdminModel>> Get()
        {
            IEnumerable<Admin> allAdmin = await unitOfWork.admin.GetAll();
            return AppMapper<Admin, AdminModel>.Map(allAdmin); 
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<AdminModel> GetByID(int id)
        {
            Admin adminById = await this.unitOfWork.admin.GetById(id);
            
            return AppMapper<Admin, AdminModel>.Map(adminById);
        }

        // POST api/<AdminController>
        [HttpPost]
        public IActionResult Post(AdminModel adm)
        {
            Admin adminDetails = AppMapper<AdminModel, Admin>.Map(adm);
            this.unitOfWork.admin.Insert(adminDetails);
            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public IActionResult Put(AdminModel adm)
        {
            Admin adminDetails = AppMapper<AdminModel, Admin>.Map(adm);
            this.unitOfWork.admin.Update(adminDetails);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.unitOfWork.admin.DeleteById(id);
        }
    }
}
