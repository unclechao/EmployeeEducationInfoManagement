using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.IBLL
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 获取所有Employee实体
        /// </summary>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// 根据ID获取Employee实体
        /// </summary>
        Employee GetEmployeeById(int id);

        /// <summary>
        /// 增加Employee实体
        /// </summary>
        bool InsertEmployee(Employee employee);

        /// <summary>
        /// 更新Employee实体
        /// </summary>
        bool UpdateEmployee(Employee employee);

        /// <summary>
        /// 删除Employee实体
        /// </summary>
        bool DeleteEmployee(Employee employee);

        /// <summary>
        /// 根据ID删除Employee实体
        /// </summary>
        bool DeleteEmployeeoById(int id);
    }
}
