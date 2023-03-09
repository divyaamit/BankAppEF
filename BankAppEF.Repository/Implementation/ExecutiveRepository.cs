using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Models;
using BankAppEF.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Implementation
{
    public class ExecutiveRepository : DBRepository<Executive>, IExecutiveRepository
    {
        public ExecutiveRepository(AppDbContext context) : base(context)
        {
        }
    }
}
