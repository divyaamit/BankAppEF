using AutoMapper;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities.Model;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Implementation
{
    public class TransactionsDTO : ITransactionsDTO
    {
        private IDBRepository<Transaction> genericRepository;
        private readonly AppDbContext dbContext;

        public TransactionsDTO(AppDbContext dbContextref)
        {
            this.genericRepository = new DBRepository<Transaction>(dbContextref);
            this.dbContext = dbContextref;
        }
        public async Task<TransactionsModel> GetTransactionsById(int id)
        {
            Transaction TransactionsById = (Transaction)await genericRepository.GetById(id);
            var translist = Helper<Transaction, TransactionsModel>.Map(TransactionsById);
            return translist;
        }

        public async Task<IEnumerable<TransactionsModel>> GetTransactionsDl()
        {
            IEnumerable<Transaction> AllTransacttion = (await genericRepository.GetAll()).ToList();
            var translist = Helper<Transaction, TransactionsModel>.Map(AllTransacttion);
            return translist;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateTransactions(TransactionsModel transactions)
        {
            Transaction translist = Helper<TransactionsModel, Transaction>.Map(transactions);
            genericRepository.Update(translist);
        }

        public void InsertTransactions(TransactionsModel transactions)
        {
            Transaction translist = Helper<TransactionsModel, Transaction>.Map(transactions);
            genericRepository.Insert(translist);
        }
    }
}
