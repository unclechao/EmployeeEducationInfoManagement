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
    public class EducationInfoService : IEducationInfoService
    {
        IEducationInfoDao educationInfoDao = DaoFactory.DaoFactory.GetEducationInfoDao();
        public IEnumerable<Model.EducationInfo> GetAllEducationInfos()
        {
            return educationInfoDao.GetAllEntities();
        }

        public Model.EducationInfo GetEducationInfoById(int id)
        {
            return educationInfoDao.GetEntityById(id);
        }

        public bool InsertEducationInfo(Model.EducationInfo educationInfo)
        {
            return educationInfoDao.InsertEntity(educationInfo);
        }

        public bool UpdateEducationInfo(Model.EducationInfo educationInfo)
        {
            return educationInfoDao.UpdateEntity(educationInfo);
        }

        public bool DeleteEducationInfo(Model.EducationInfo educationInfo)
        {
            return educationInfoDao.DeleteEntity(educationInfo);
        }

        public bool DeleteEducationInfoById(int id)
        {
            return educationInfoDao.DeleteEntityById(id);
        }
    }
}
