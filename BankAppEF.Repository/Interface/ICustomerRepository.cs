using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Repository.Interface
{
    public interface ICustomerRepository : IDBRepository<Customer>
    {
        
    }
}
