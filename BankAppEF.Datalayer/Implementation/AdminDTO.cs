using AutoMapper;
using BankAppEF.Data.Entities.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Models;
using BankAppEF.Entities.Model;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;

namespace BankAppEF.Datalayer.Implementation
{
    public class AdminDTO : IAdminDTO
    {
        private IDBRepository<Admin> genericRepository;
        private readonly AppDbContext dbContext;

        public AdminDTO(AppDbContext dbContextref)
        {
            this.genericRepository = new DBRepository<Admin>(dbContextref);
            this.dbContext = dbContextref;
        }

        public void DeleteById(int id)
        {
            this.genericRepository.DeleteById(id);
        }

        public async Task<AdminModel> GetAdminById(int id)
        {
            Admin AdminById = (Admin)await genericRepository.GetById(id);
            var adminlist = Helper<Admin, AdminModel>.Map(AdminById);
            return adminlist;
        }

        public async Task<IEnumerable<AdminModel>> GetAdminDl()
        {
            IEnumerable<Admin> AllAdmin = (await genericRepository.GetAll()).ToList();
            var adminlist = Helper<Admin, AdminModel>.Map(AllAdmin);
            return adminlist;
        }

        public void InsertAdmin(AdminModel admin)
        {
            Admin adminlist = Helper<AdminModel, Admin>.Map(admin);
            genericRepository.Update(adminlist);
        }

        public void UpdateAdmin(AdminModel admin)
        {
            Admin adminlist = Helper<AdminModel, Admin>.Map(admin);
            genericRepository.Update(adminlist);
        }
    }
}
