using BankApp.Data.Entities.Models;
using BankApp.Repository.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Implementation
{
    public class AccountRepository : DBRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
