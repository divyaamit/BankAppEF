using AutoMapper;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Implementation
{
    public class CustomerDL : ICustomerDL
    {
        private IGenericRepository<Customer> genericRepository;
        private readonly CustomerDbContext dbContext;


        public CustomerDL(CustomerDbContext dbContextref)
        {
            this.genericRepository = new GenericRepository<Customer>(dbContextref);
            this.dbContext = dbContextref;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerDl()
        {
            var abc = await genericRepository.GetAll();
            var mapconfig = new MapperConfiguration(options => options.CreateMap<Customer, CustomerModel>());
            IMapper mapper = mapconfig.CreateMapper();
            IEnumerable<CustomerModel> list = mapper.Map<CustomerModel[]>(abc);
            return list;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var abc = await genericRepository.GetById(id);
            var mapconfig = new MapperConfiguration(options => options.CreateMap<Customer, CustomerModel>());
            IMapper mapper = mapconfig.CreateMapper();
            return mapper.Map<CustomerModel>(abc);
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var mapconfig2 = new MapperConfiguration(options => options.CreateMap<CustomerModel, Customer>());
            AutoMapper.IMapper mapper2 = mapconfig2.CreateMapper();
            Customer list = mapper2.Map<Customer>(customer);
            genericRepository.Update(list);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            var mapconfig3 = new MapperConfiguration(options => options.CreateMap<CustomerModel, Customer>());
            AutoMapper.IMapper mapper3 = mapconfig3.CreateMapper();
            Customer list = mapper3.Map<Customer>(customer);
            genericRepository.Insert(list);
        }
    }
}
