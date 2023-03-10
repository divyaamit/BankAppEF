using AutoMapper;
using BankApp.Repository.Interface;
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
        private readonly IUnitOfWork unitOfWork;

        public ExecutiveDTO(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeleteById(int id)
        {
            this.unitOfWork.executive.DeleteById(id);
        }

        public async Task<ExecutiveModel> GetExecutiveById(int id)
        {
            Executive executiveById = await unitOfWork.executive.GetById(id);
            ExecutiveModel exelist = AppMapper<Executive, ExecutiveModel>.Map(executiveById);
            return exelist;
        }

        public async Task<IEnumerable<ExecutiveModel>> GetExecutiveDl()
        {
            IEnumerable<Executive> allExecutive = (await unitOfWork.executive.GetAll()).ToList();
            IEnumerable<ExecutiveModel> exelist = AppMapper<Executive, ExecutiveModel>.Map(allExecutive);
            return exelist;
        }

        public void InsertExecutive(ExecutiveModel executive)
        {
            Executive exelist = AppMapper<ExecutiveModel, Executive>.Map(executive);
            unitOfWork.executive.Insert(exelist);
        }

        public void UpdateExecutive(ExecutiveModel executive)
        {
            Executive exeList = AppMapper<ExecutiveModel, Executive>.Map(executive);
            unitOfWork.executive.Update(exeList);
        }
    }
}
