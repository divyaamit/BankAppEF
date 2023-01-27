using AutoMapper;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;

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
            IEnumerable<Customer> AllCustomer = (await genericRepository.GetAll()).ToList();
            var custlist = Helper<Customer, CustomerModel>.Map(AllCustomer);
            return custlist;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            Customer CustomerById = (Customer)await genericRepository.GetById(id);
            var custlist = Helper<Customer, CustomerModel>.Map(CustomerById);
            return custlist;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
             var custlist = Helper<CustomerModel, Customer>.Map(customer);
             genericRepository.Update(custlist);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            var custlist = Helper<CustomerModel, Customer>.Map(customer);
            genericRepository.Insert(custlist);
        }
    }
}
