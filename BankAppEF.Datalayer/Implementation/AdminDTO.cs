using AutoMapper;
using BankApp.Repository.Interface;
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
        private IUnitOfWork _uow;
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
            Admin adminById = (Admin)await genericRepository.GetById(id);
            AdminModel adminlist = AppMapper<Admin, AdminModel>.Map(adminById);
            return adminlist;
        }

        public async Task<IEnumerable<AdminModel>> GetAdminDl()
        {
            IEnumerable<Admin> allAdmin = (await genericRepository.GetAll()).ToList();
            IEnumerable<AdminModel> adminlist = AppMapper<Admin, AdminModel>.Map(allAdmin);
            return adminlist;
        }

        public void InsertAdmin(AdminModel admin)
        {
            Admin adminList = AppMapper<AdminModel, Admin>.Map(admin);
            genericRepository.Update(adminList);
        }

        public void UpdateAdmin(AdminModel admin)
        {
            Admin adminList = AppMapper<AdminModel, Admin>.Map(admin);
            genericRepository.Update(adminList);
        }

        //public void RecallLastTransaction(int userid)
        //{
        //    var transac = _uow.transaction.GetAll().Result.FirstOrDefault(t => t.SenderId == userid);
        //    var customer = _uow.customer.GetAll().Result.FirstOrDefault(c=>c.CustomerAccountNo == transac.TransactionAmount)

        //}
    }
}
