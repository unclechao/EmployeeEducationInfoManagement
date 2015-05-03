using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.IDao
{
    public interface IBaseDao<T> where T : class
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        IEnumerable<T> GetAllEntities();

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        T GetEntityById(object id);

        /// <summary>
        /// 增加实体
        /// </summary>
        bool InsertEntity(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        bool DeleteEntityById(object id);
    }
}
