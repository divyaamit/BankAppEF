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
        private readonly IUnitOfWork unitOfWork;

        public AdminDTO(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeleteById(int id)
        {
            this.unitOfWork.admin.DeleteById(id);
        }

        public async Task<AdminModel> GetAdminById(int id)
        {
            Admin adminById = (Admin)await unitOfWork.admin.GetById(id);
            AdminModel adminlist = AppMapper<Admin, AdminModel>.Map(adminById);
            return adminlist;
        }

        public async Task<IEnumerable<AdminModel>> GetAdminDl()
        {
            IEnumerable<Admin> allAdmin = (await unitOfWork.admin.GetAll()).ToList();
            IEnumerable<AdminModel> adminlist = AppMapper<Admin, AdminModel>.Map(allAdmin);
            return adminlist;
        }

        public void InsertAdmin(AdminModel admin)
        {
            Admin adminList = AppMapper<AdminModel, Admin>.Map(admin);
            unitOfWork.admin.Update(adminList);
        }

        public void UpdateAdmin(AdminModel admin)
        {
            Admin adminList = AppMapper<AdminModel, Admin>.Map(admin);
            unitOfWork.admin.Update(adminList);
        }

        //public void RecallLastTransaction(int userid)
        //{
        //    var transac = _uow.transaction.GetAll().Result.FirstOrDefault(t => t.SenderId == userid);
        //    var customer = _uow.customer.GetAll().Result.FirstOrDefault(c=>c.CustomerAccountNo == transac.TransactionAmount)

        //}
    }
}
