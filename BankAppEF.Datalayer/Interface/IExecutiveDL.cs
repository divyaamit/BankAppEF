using BankAppEF.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Datalayer.Interface
{
    public interface IExecutiveDL
    {
        public Task<IEnumerable<ExecutiveModel>> GetExecutiveDl();
        public Task<ExecutiveModel> GetExecutiveById(int id);
        public void DeleteById(int id);
        public void UpdateExecutive(ExecutiveModel executive);
        public void InsertExecutive(ExecutiveModel executive);
    }
}
