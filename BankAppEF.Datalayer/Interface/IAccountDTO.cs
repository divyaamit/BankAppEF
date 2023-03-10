using BankApp.Entities.Model;
using BankAppEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Datalayer.Interface
{
    public interface IAccountDTO
    {
        public Task<IEnumerable<AccountModel>> GetAccountDl();
        public Task<AccountModel> GetAccountById(int id);
        public void DeleteById(int id);
        public void UpdateAccount(AccountModel account);
        public void InsertAccount(AccountModel account);
    }
}
