using AutoMapper;
using BankApp.Repository.Interface;
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
        private readonly IUnitOfWork unitOfWork;

        public TransactionsDTO(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<TransactionsModel> GetTransactionsById(int id)
        {
            Transaction transactionsById = await unitOfWork.transaction.GetById(id);
            TransactionsModel translist = AppMapper<Transaction, TransactionsModel>.Map(transactionsById);
            return translist;
        }

        public async Task<IEnumerable<TransactionsModel>> GetTransactionsDl()
        {
            IEnumerable<Transaction> allTransacttion = (await unitOfWork.transaction.GetAll()).ToList();
            IEnumerable<TransactionsModel> translist = AppMapper<Transaction, TransactionsModel>.Map(allTransacttion);
            return translist;
        }

        public void DeleteById(int id)
        {
            this.unitOfWork.transaction.DeleteById(id);
        }

        public void UpdateTransactions(TransactionsModel transactions)
        {
            Transaction transList = AppMapper<TransactionsModel, Transaction>.Map(transactions);
            unitOfWork.transaction.Update(transList);
        }

        public void InsertTransactions(TransactionsModel transactions)
        {
            Transaction transList = AppMapper<TransactionsModel, Transaction>.Map(transactions);
            unitOfWork.transaction.Insert(transList);
        }
    }
}
