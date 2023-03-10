using AutoMapper;
using BankApp.Repository.Interface;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using System.Linq;

namespace BankAppEF.Datalayer.Implementation
{
    public class CustomerDTO : ICustomerDTO
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerDTO(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerDl()
        {
            IEnumerable<Customer> allCustomer = (await unitOfWork.customer.GetAll()).ToList();
            IEnumerable<CustomerModel> custlist = AppMapper<Customer, CustomerModel>.Map(allCustomer);
            return custlist;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            Customer customerById = await unitOfWork.customer.GetById(id);
            CustomerModel custlist = AppMapper<Customer, CustomerModel>.Map(customerById);
            return custlist;
        }

        public void DeleteById(int id)
        {
            this.unitOfWork.customer.DeleteById(id);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
             Customer custlist = AppMapper<CustomerModel, Customer>.Map(customer);
             unitOfWork.customer.Update(custlist);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            Customer custlist = AppMapper<CustomerModel, Customer>.Map(customer);
            unitOfWork.customer.Insert(custlist);
        }
    }
}
