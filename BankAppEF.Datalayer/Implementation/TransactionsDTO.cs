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
        private IDBRepository<Transactions> genericRepository;
        private readonly CustomerDbContext dbContext;

        public TransactionsDTO(CustomerDbContext dbContextref)
        {
            this.genericRepository = new DBRepository<Transactions>(dbContextref);
            this.dbContext = dbContextref;
        }
        public async Task<TransactionsModel> GetTransactionsById(int id)
        {
            Transactions TransactionsById = (Transactions)await genericRepository.GetById(id);
            var translist = Helper<Transactions, TransactionsModel>.Map(TransactionsById);
            return translist;
        }

        public async Task<IEnumerable<TransactionsModel>> GetTransactionsDl()
        {
            IEnumerable<Transactions> AllTransacttion = (await genericRepository.GetAll()).ToList();
            var translist = Helper<Transactions, TransactionsModel>.Map(AllTransacttion);
            return translist;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateTransactions(TransactionsModel transactions)
        {
            Transactions translist = Helper<TransactionsModel, Transactions>.Map(transactions);
            genericRepository.Update(translist);
        }

        public void InsertTransactions(TransactionsModel transactions)
        {
            Transactions translist = Helper<TransactionsModel, Transactions>.Map(transactions);
            genericRepository.Insert(translist);
        }
    }
}
