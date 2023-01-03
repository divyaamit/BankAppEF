using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Repository.Interface
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        public void Insert(T item);

        public void Update(T item);
        public void DeleteById(int id);
        public Task<T> GetById(int id);
    }
}
