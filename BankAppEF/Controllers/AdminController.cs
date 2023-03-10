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
        private readonly IAdminDTO adminObjDl;
        public AdminController(IAdminDTO adminObjDl)
        {
            this.adminObjDl = adminObjDl;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<AdminModel>> Get()
        {
            return await this.adminObjDl.GetAdminDl();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<AdminModel> GetByID(int id)
        {
            return await this.adminObjDl.GetAdminById(id);
        }

        // POST api/<AdminController>
        [HttpPost]
        public IActionResult Post(AdminModel adm)
        {
            adminObjDl.InsertAdmin(adm);
            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public IActionResult Put(AdminModel adm)
        {
            adminObjDl.UpdateAdmin(adm);
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            adminObjDl.DeleteById(id);
        }
    }
}
