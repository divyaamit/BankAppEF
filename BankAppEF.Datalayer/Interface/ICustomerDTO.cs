using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Interface
{
    public interface ICustomerDTO
    {
        public Task<IEnumerable<CustomerModel>> GetCustomerDl();
        public Task<CustomerModel> GetCustomerById(int id);
        public void DeleteById(int id);
        public void UpdateCustomer(CustomerModel customer);
        public void InsertCustomer(CustomerModel customer);
    }
}
