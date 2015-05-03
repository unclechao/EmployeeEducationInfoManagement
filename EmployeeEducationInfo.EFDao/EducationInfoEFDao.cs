using EmployeeEducationInfo.IDao;
using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.EFDao
{
    public class EducationInfoEFDao : IEducationInfoDao
    {
        private EmployeeEducationInfoContainer EmployeeEducationInfoDB = new EmployeeEducationInfoContainer();
        public IEnumerable<Model.EducationInfo> GetAllEntities()
        {
            return EmployeeEducationInfoDB.EducationInfoSet.Where(edu => edu.IsDel == false);
        }

        public Model.EducationInfo GetEntityById(object id)
        {
            var uid = Convert.ToInt32(id);
            return EmployeeEducationInfoDB.EducationInfoSet.Where(admin => admin.Id == uid).SingleOrDefault();
        }

        public bool InsertEntity(Model.EducationInfo entity)
        {
            bool flag = false;
            EmployeeEducationInfoDB.EducationInfoSet.Add(entity);
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool UpdateEntity(Model.EducationInfo entity)
        {
            bool flag = false;
            var old = EmployeeEducationInfoDB.EducationInfoSet.Where(s => s.Id == entity.Id).SingleOrDefault();
            old.IsDel = entity.IsDel;
            old.StartTime = entity.StartTime;
            old.EndTime = entity.EndTime;
            old.EmployeeId = entity.EmployeeId;
            old.Education = entity.Education;
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntity(Model.EducationInfo entity)
        {
            return DeleteEntityById(entity.Id);
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            var uid = Convert.ToInt32(id);
            EducationInfo education = EmployeeEducationInfoDB.EducationInfoSet.Where(edu => edu.Id == uid).SingleOrDefault();
            education.IsDel = true;
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }
    }
}
