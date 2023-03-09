using BankApp.Repository.Implementation;
using BankApp.Repository.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context;
        public UnitOfWork(AppDbContext context) 
        {
            this.context = context;
            customer = new CustomerRepository(this.context);
            executive = new ExecutiveRepository(this.context);
            admin = new AdminRepository(this.context);
            transaction = new TransactionRepository(this.context);
        }
        public ICustomerRepository customer
        {
            get; 
            private set;
        } 
       

        public IExecutiveRepository executive
        {
            get;
            private set;
        }

        public IAdminRepository admin
        {
            get;
            private set;
        }

        public ITransactionRepository transaction
        {
            get;
            private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
