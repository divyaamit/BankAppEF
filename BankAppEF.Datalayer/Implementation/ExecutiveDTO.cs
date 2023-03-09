﻿using AutoMapper;
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
        private readonly AppDbContext dbContext;

        public ExecutiveDTO(AppDbContext dbContextref)
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
            Executive executiveById = (Executive)await genericRepository.GetById(id);
            ExecutiveModel exelist = AppMapper<Executive, ExecutiveModel>.Map(executiveById);
            return exelist;
        }

        public async Task<IEnumerable<ExecutiveModel>> GetExecutiveDl()
        {
            IEnumerable<Executive> allExecutive = (await genericRepository.GetAll()).ToList();
            IEnumerable<ExecutiveModel> exelist = AppMapper<Executive, ExecutiveModel>.Map(allExecutive);
            return exelist;
        }

        public void InsertExecutive(ExecutiveModel executive)
        {
            Executive exelist = AppMapper<ExecutiveModel, Executive>.Map(executive);
            genericRepository.Insert(exelist);
        }

        public void UpdateExecutive(ExecutiveModel executive)
        {
            Executive exeList = AppMapper<ExecutiveModel, Executive>.Map(executive);
            genericRepository.Update(exeList);
        }
    }
}
