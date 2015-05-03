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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeDao employeeDao = DaoFactory.DaoFactory.GetEmployeeDao();
        public IEnumerable<Model.Employee> GetAllEmployees()
        {
            return employeeDao.GetAllEntities();
        }

        public Model.Employee GetEmployeeById(int id)
        {
            return employeeDao.GetEntityById(id);
        }

        public bool InsertEmployee(Model.Employee employee)
        {
            return employeeDao.InsertEntity(employee);
        }

        public bool UpdateEmployee(Model.Employee employee)
        {
            return employeeDao.UpdateEntity(employee);
        }

        public bool DeleteEmployee(Model.Employee employee)
        {
            return employeeDao.DeleteEntity(employee);
        }

        public bool DeleteEmployeeoById(int id)
        {
            return employeeDao.DeleteEntityById(id);
        }
    }
}
