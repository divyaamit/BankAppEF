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
            Transaction transactionsById = (Transaction)await genericRepository.GetById(id);
            TransactionsModel translist = AppMapper<Transaction, TransactionsModel>.Map(transactionsById);
            return translist;
        }

        public async Task<IEnumerable<TransactionsModel>> GetTransactionsDl()
        {
            IEnumerable<Transaction> allTransacttion = (await genericRepository.GetAll()).ToList();
            IEnumerable<TransactionsModel> translist = AppMapper<Transaction, TransactionsModel>.Map(allTransacttion);
            return translist;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateTransactions(TransactionsModel transactions)
        {
            Transaction transList = AppMapper<TransactionsModel, Transaction>.Map(transactions);
            genericRepository.Update(transList);
        }

        public void InsertTransactions(TransactionsModel transactions)
        {
            Transaction transList = AppMapper<TransactionsModel, Transaction>.Map(transactions);
            genericRepository.Insert(transList);
        }
    }
}
