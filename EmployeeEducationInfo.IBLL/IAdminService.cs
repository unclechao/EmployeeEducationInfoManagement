using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.IBLL
{
    public interface IAdminService
    {
        /// <summary>
        /// 获取所有Admin实体
        /// </summary>
        IEnumerable<Admin> GetAllAdmins();

        /// <summary>
        /// 根据ID获取Admin实体
        /// </summary>
        Admin GetAdminById(int id);

        /// <summary>
        /// 增加Admin实体
        /// </summary>
        bool InsertAdmin(Admin admin);

        /// <summary>
        /// 更新Admin实体
        /// </summary>
        bool UpdateAdmin(Admin admin);

        /// <summary>
        /// 删除Admin实体
        /// </summary>
        bool DeleteAdmin(Admin admin);

        /// <summary>
        /// 根据ID删除Admin实体
        /// </summary>
        bool DeleteAdminById(int id);
    }
}
