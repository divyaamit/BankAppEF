using BankAppEF.Data.Entities.Models;
using BankAppEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Interface
{
    public interface IAdminRepository : IDBRepository<Admin>
    {
    }
}
