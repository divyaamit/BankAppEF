using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Entities.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAppEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminDTO adminDL;
        public AdminController(IAdminDTO _adminDL)
        {
            this.adminDL = _adminDL;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<AdminModel>> Get()
        {
            return await adminDL.GetAdminDl();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<AdminModel> GetByID(int id)
        {
            return await this.adminDL.GetAdminById(id);
        }

        // POST api/<AdminController>
        [HttpPost]
        public IActionResult Post(AdminModel adm)
        {
            this.adminDL.InsertAdmin(adm);
            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public IActionResult Put(AdminModel adm)
        {
            this.adminDL.UpdateAdmin(adm);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.adminDL.DeleteById(id);
        }
    }
}
