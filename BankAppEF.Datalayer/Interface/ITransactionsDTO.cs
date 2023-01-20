using BankAppEF.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Interface
{
    public interface ITransactionsDTO
    {
        public Task<IEnumerable<TransactionsModel>> GetTransactionsDl();
        public Task<TransactionsModel> GetTransactionsById(int id);
        public void DeleteById(int id);
        public void UpdateTransactions(TransactionsModel transactions);
        public void InsertTransactions(TransactionsModel transactions);
    }
}
