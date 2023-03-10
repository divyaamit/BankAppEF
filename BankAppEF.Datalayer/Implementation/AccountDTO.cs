using BankApp.Data.Entities.Models;
using BankApp.Datalayer.Interface;
using BankApp.Entities.Model;
using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using BankAppEF.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Datalayer.Implementation
{
    public class AccountDTO : IAccountDTO
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountDTO(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AccountModel>> GetAccountDl()
        {
            IEnumerable<Account> allAccount = (await unitOfWork.account.GetAll()).ToList();
            IEnumerable<AccountModel> acclist = AppMapper<Account, AccountModel>.Map(allAccount);
            return acclist;
        }
        public async Task<AccountModel> GetAccountById(int id)
        {
            Account accountById = await unitOfWork.account.GetById(id);
            AccountModel acclist = AppMapper<Account, AccountModel>.Map(accountById);
            return acclist;
        }
        public void DeleteById(int id)
        {
            this.unitOfWork.account.DeleteById(id);
        }
        public void UpdateAccount(AccountModel account)
        {
            Account acclist = AppMapper<AccountModel, Account>.Map(account);
            unitOfWork.account.Update(acclist);
        }

        public void InsertAccount(AccountModel account)
        {
            Account acclist = AppMapper<AccountModel, Account>.Map(account);
            unitOfWork.account.Insert(acclist);
        }
    }
}
