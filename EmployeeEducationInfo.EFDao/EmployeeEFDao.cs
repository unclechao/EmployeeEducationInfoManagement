using EmployeeEducationInfo.IDao;
using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.EFDao
{
    public class EmployeeEFDao : IEmployeeDao
    {
        private EmployeeEducationInfoContainer EmployeeEducationInfoDB = new EmployeeEducationInfoContainer();
        public IEnumerable<Model.Employee> GetAllEntities()
        {
            return EmployeeEducationInfoDB.EmployeeSet.Where(emp => emp.IsDel == false);
        }

        public Model.Employee GetEntityById(object id)
        {
            var uid = Convert.ToInt32(id);
            return EmployeeEducationInfoDB.EmployeeSet.Where(admin => admin.Id == uid).SingleOrDefault();
        }

        public bool InsertEntity(Model.Employee entity)
        {
            bool flag = false;
            EmployeeEducationInfoDB.EmployeeSet.Add(entity);
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool UpdateEntity(Model.Employee entity)
        {
            bool flag = false;
            var oldentity = EmployeeEducationInfoDB.EmployeeSet.Where(oldEntity => oldEntity.Id == entity.Id).SingleOrDefault();
            oldentity.Age = entity.Age;
            oldentity.IsDel = entity.IsDel;
            oldentity.Name = entity.Name;
            oldentity.Seniority = entity.Seniority;
            ICollection<EducationInfo> collection = entity.EducationInfo;
            int count = collection.Count;
            for (int i = 0; i < collection.Count; i++)
            {
                EducationInfo eduInfo = collection.Skip(i).Take<EducationInfo>(1).SingleOrDefault();
                var res = new EducationInfoEFDao().GetEntityById(eduInfo.Id);
                if (res != null)
                {
                    //exist
                    var oldEducationInfo = EmployeeEducationInfoDB.EducationInfoSet.Where(s => s.Id == eduInfo.Id).SingleOrDefault();
                    oldEducationInfo.IsDel = eduInfo.IsDel;
                    oldEducationInfo.StartTime = eduInfo.StartTime;
                    oldEducationInfo.EndTime = eduInfo.EndTime;
                    oldEducationInfo.Education = eduInfo.Education;
                }
                else
                {
                    //need to add
                    EducationInfo educationInfo = new EducationInfo();
                    educationInfo.Id = eduInfo.Id;
                    educationInfo.IsDel = eduInfo.IsDel;
                    educationInfo.StartTime = eduInfo.StartTime;
                    educationInfo.EndTime = eduInfo.EndTime;
                    educationInfo.Education = eduInfo.Education;
                    educationInfo.EmployeeId = eduInfo.EmployeeId;
                    new EducationInfoEFDao().InsertEntity(educationInfo);
                }
            }
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntity(Model.Employee entity)
        {
            return DeleteEntityById(entity.Id);
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            var uid = Convert.ToInt32(id);
            Employee employee = EmployeeEducationInfoDB.EmployeeSet.Where(emp => emp.Id == uid).SingleOrDefault();
            employee.IsDel = true;
            //将Employee对应下的Education Info一并删除
            foreach (var item in employee.EducationInfo)
            {
                item.IsDel = true;
            }
            if (EmployeeEducationInfoDB.SaveChanges() > 0) flag = true;
            return flag;
        }
    }
}
