using AutoMapper;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using BankAppEF.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Repository.Implementation
{
    public class CustomerRepository : ICustomeRepository
    {
        private Datalayer.Models.CustomerDbContext customerDbContext;
        private IMapper mapper;

        public CustomerRepository(Datalayer.Models.CustomerDbContext dbContext, IMapper  _mapper)
        {
            customerDbContext = dbContext;
            mapper = _mapper;
        }

        public async void AddCustomerRepo(Customer customer)
        {
            await customerDbContext.Customers.AddAsync(customer);
            customerDbContext.SaveChanges();
        }

        public void DeleteCustomerById(int id)
        {
            customerDbContext.Remove(customerDbContext.Customers.FirstOrDefault(c=>c.CustomerId==id));
            customerDbContext.SaveChanges();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var custo = await customerDbContext.Customers.ToListAsync();
            IEnumerable<CustomerModel> customerlist = mapper.Map<CustomerModel[]>(custo);
            return customerlist;
        }

        public async Task<CustomerModel> GetCustomerByIdRepo(int id)
        {
            var custo = await customerDbContext.Customers.FirstOrDefaultAsync(c=>c.CustomerId==id);
            return mapper.Map<CustomerModel>(custo);
        }

        public void UpdateCustomer(int id, Customer customerModel)
        {
            var dbdata = customerDbContext.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);
            if (dbdata != null)
            {
                customerDbContext.Entry(customerModel).State = EntityState.Modified;
            }
            customerDbContext.SaveChanges();
        }
    }
}
