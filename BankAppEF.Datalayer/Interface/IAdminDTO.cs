using BankAppEF.Data.Entities.Models;
using BankAppEF.Entities;
using BankAppEF.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Interface
{
    public interface IAdminDTO
    {
        public Task<IEnumerable<AdminModel>> GetAdminDl();
        public Task<AdminModel> GetAdminById(int id);
        public void DeleteById(int id);
        public void UpdateAdmin(AdminModel admin);
        public void InsertAdmin(AdminModel admin);
    }
}
