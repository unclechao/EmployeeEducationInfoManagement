using EmployeeEducationInfo.EFDao;
using EmployeeEducationInfo.IBLL;
using EmployeeEducationInfo.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.BLL
{
    public class AdminService : IAdminService
    {
        IAdminDao adminDao = DaoFactory.DaoFactory.GetAdminDao();
        public IEnumerable<Model.Admin> GetAllAdmins()
        {
            return adminDao.GetAllEntities();
        }

        public Model.Admin GetAdminById(int id)
        {
            return adminDao.GetEntityById(id);
        }

        public bool InsertAdmin(Model.Admin admin)
        {
            return adminDao.InsertEntity(admin);
        }

        public bool UpdateAdmin(Model.Admin admin)
        {
            return adminDao.UpdateEntity(admin);
        }

        public bool DeleteAdmin(Model.Admin admin)
        {
            return adminDao.DeleteEntity(admin);
        }

        public bool DeleteAdminById(int id)
        {
            return adminDao.DeleteEntityById(id);
        }
    }
}
