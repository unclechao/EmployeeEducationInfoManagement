using EmployeeEducationInfo.IDao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.DaoFactory
{
    public static class DaoFactory
    {
        private static readonly string dllName = ConfigurationManager.AppSettings["DaoPath"].ToString();

        public static object CreateDao(string daoType)
        {
            return Assembly.Load(dllName).CreateInstance(daoType);
        }

        public static IAdminDao GetAdminDao()
        {
            var temparr = dllName.Split('.');
            StringBuilder param = new StringBuilder(dllName);
            param.Append(".Admin").Append(temparr[temparr.Length-1]);
            return CreateDao(param.ToString()) as IAdminDao;
        }

        public static IEmployeeDao GetEmployeeDao()
        {
            var temparr = dllName.Split('.');
            StringBuilder param = new StringBuilder(dllName);
            param.Append(".Employee").Append(temparr[temparr.Length - 1]);
            return CreateDao(param.ToString()) as IEmployeeDao;
        }

        public static IEducationInfoDao GetEducationInfoDao()
        {
            var temparr = dllName.Split('.');
            StringBuilder param = new StringBuilder(dllName);
            param.Append(".EducationInfo").Append(temparr[temparr.Length - 1]);
            return CreateDao(param.ToString()) as IEducationInfoDao;
        }
    }
}
