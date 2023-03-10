using BankAppEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository customer { get; }
        IExecutiveRepository executive { get; }
        IAdminRepository admin { get; }
        IAccountRepository account { get; }
        ITransactionRepository transaction { get; }

        int save();
    }
}
