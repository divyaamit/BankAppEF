using BankAppEF.Entities.Model;

namespace BankAppEF.Datalayer.Interface
{
    public interface IExecutiveDTO
    {
        public Task<IEnumerable<ExecutiveModel>> GetExecutiveDl();
        public Task<ExecutiveModel> GetExecutiveById(int id);
        public void DeleteById(int id);
        public void UpdateExecutive(ExecutiveModel executive);
        public void InsertExecutive(ExecutiveModel executive);
    }
}
