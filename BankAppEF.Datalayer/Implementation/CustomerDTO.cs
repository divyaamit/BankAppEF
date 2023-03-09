using AutoMapper;
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
        private DBRepository<Customer> genericRepository;
        private readonly AppDbContext dbContext;


        public CustomerDTO(AppDbContext dbContextref)
        {
            this.genericRepository = new DBRepository<Customer>(dbContextref);
            this.dbContext = dbContextref;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerDl()
        {
            IEnumerable<Customer> allCustomer = (await genericRepository.GetAll()).ToList();
            IEnumerable<CustomerModel> custlist = AppMapper<Customer, CustomerModel>.Map(allCustomer);
            return custlist;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            Customer customerById = await genericRepository.GetById(id);
            CustomerModel custlist = AppMapper<Customer, CustomerModel>.Map(customerById);
            return custlist;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
             Customer custlist = AppMapper<CustomerModel, Customer>.Map(customer);
             genericRepository.Update(custlist);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            Customer custlist = AppMapper<CustomerModel, Customer>.Map(customer);
            genericRepository.Insert(custlist);
        }
    }
}
