using BankAppEF.Datalayer.Models;
using BankAppEF.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankAppEF.Repository.Implementation
{
    public class DBRepository<T> : IDBRepository<T>
        where T : class
    {
        private readonly Datalayer.Models.AppDbContext DBContext;
        private readonly DbSet<T> dbEntity;

        public DBRepository(Datalayer.Models.AppDbContext context)
        {
            if (context != null)
            {
                DBContext = context;
                dbEntity = context.Set<T>();
            }

        }

        public void DeleteById(int id)
        {
            T model = dbEntity.Find(id);
            if (model == null)
            {
                throw new KeyNotFoundException();
            }
            dbEntity.Remove(model);
            DBContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbEntity.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbEntity.FindAsync(id);
        }

        public void Insert(T item)
        {
            dbEntity.Add(item);
            DBContext.SaveChanges();
        }

        public void Update(T item)
        {
            DBContext.Entry(item).State= EntityState.Modified;
            DBContext.SaveChanges();
        }
    }
}
