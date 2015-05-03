using EmployeeEducationInfo.IDao;
using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.EFDao
{
    public class AdminEFDao : IAdminDao
    {
        private EmployeeEducationInfoContainer EmployeeEducationInfoDB = new EmployeeEducationInfoContainer();
        public IEnumerable<Model.Admin> GetAllEntities()
        {
            return EmployeeEducationInfoDB.AdminSet.Where(adm => adm.IsDel == false);
        }

        public Model.Admin GetEntityById(object id)
        {
            var uid = Convert.ToInt32(id);
            return EmployeeEducationInfoDB.AdminSet.Where(admin => admin.Id == uid).SingleOrDefault();
        }

        public bool InsertEntity(Model.Admin entity)
        {
            bool flag = false;
            EmployeeEducationInfoDB.AdminSet.Add(entity);
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool UpdateEntity(Model.Admin entity)
        {
            bool flag = false;
            EmployeeEducationInfoDB.AdminSet.Attach(entity);
            EmployeeEducationInfoDB.Entry(entity).State = System.Data.EntityState.Modified;
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntity(Model.Admin entity)
        {
            return DeleteEntityById(entity.Id);
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            var uid = Convert.ToInt32(id);
            Admin admin = EmployeeEducationInfoDB.AdminSet.Where(adm => adm.Id == uid).SingleOrDefault();        
            EmployeeEducationInfoDB.AdminSet.Attach(admin);
            admin.IsDel = true;
            EmployeeEducationInfoDB.Entry(admin).State = System.Data.EntityState.Modified;
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }
    }
}
