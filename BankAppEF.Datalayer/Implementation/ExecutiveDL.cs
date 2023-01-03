using AutoMapper;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities;
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
    public class ExecutiveDL : IExecutiveDL
    {
        private IGenericRepository<Executive> genericRepository;
        private readonly CustomerDbContext dbContext;
        private IMapper mapper1;

        public ExecutiveDL(CustomerDbContext dbContextref, IMapper _mapper1)
        {
            this.genericRepository = new GenericRepository<Executive>(dbContextref);
            this.dbContext = dbContextref;
            this.mapper1 = _mapper1;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public async Task<ExecutiveModel> GetExecutiveById(int id)
        {
            var abc = await genericRepository.GetById(id);
            return mapper1.Map<ExecutiveModel>(abc);
        }

        public async Task<IEnumerable<ExecutiveModel>> GetExecutiveDl()
        {
            var abc = await genericRepository.GetAll();
            var mapconfig = new MapperConfiguration(options => options.CreateMap<Executive, ExecutiveModel>());
            AutoMapper.IMapper mapper1 = mapconfig.CreateMapper();
            IEnumerable<ExecutiveModel> list = mapper1.Map<ExecutiveModel[]>(abc);
            return list;
        }

        public void InsertExecutive(ExecutiveModel executive)
        {
            var mapconfig2 = new MapperConfiguration(options => options.CreateMap<ExecutiveModel, Executive>());
            AutoMapper.IMapper mapper2 = mapconfig2.CreateMapper();
            Executive list = mapper2.Map<Executive>(executive);
            genericRepository.Insert(list);
        }

        public void UpdateExecutive(ExecutiveModel executive)
        {
            var mapconfig2 = new MapperConfiguration(options => options.CreateMap<ExecutiveModel, Executive>());
            AutoMapper.IMapper mapper2 = mapconfig2.CreateMapper();
            Executive list = mapper2.Map<Executive>(executive);
            genericRepository.Update(list);
        }
    }
}
