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
    public class ExecutiveDTO : IExecutiveDTO
    {
        private IDBRepository<Executive> genericRepository;
        private readonly CustomerDbContext dbContext;

        public ExecutiveDTO(CustomerDbContext dbContextref)
        {
            this.genericRepository = new DBRepository<Executive>(dbContextref);
            this.dbContext = dbContextref;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public async Task<ExecutiveModel> GetExecutiveById(int id)
        {
            Executive ExecutiveById = (Executive)await genericRepository.GetById(id);
            var exelist = Helper<Executive, ExecutiveModel>.Map(ExecutiveById);
            return exelist;
        }

        public async Task<IEnumerable<ExecutiveModel>> GetExecutiveDl()
        {
            IEnumerable<Executive> AllExecutive = (await genericRepository.GetAll()).ToList();
            var exelist = Helper<Executive, ExecutiveModel>.Map(AllExecutive);
            return exelist;
        }

        public void InsertExecutive(ExecutiveModel executive)
        {
            Executive exelist = Helper<ExecutiveModel, Executive>.Map(executive);
            genericRepository.Insert(exelist);
        }

        public void UpdateExecutive(ExecutiveModel executive)
        {
            Executive exelist = Helper<ExecutiveModel, Executive>.Map(executive);
            genericRepository.Update(exelist);
        }
    }
}
