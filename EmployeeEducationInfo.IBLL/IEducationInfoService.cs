using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEducationInfo.IBLL
{
    public interface IEducationInfoService
    {
        /// <summary>
        /// 获取所有EducationInfo实体
        /// </summary>
        IEnumerable<EducationInfo> GetAllEducationInfos();

        /// <summary>
        /// 根据ID获取EducationInfo实体
        /// </summary>
        EducationInfo GetEducationInfoById(int id);

        /// <summary>
        /// 增加EducationInfo实体
        /// </summary>
        bool InsertEducationInfo(EducationInfo educationInfo);

        /// <summary>
        /// 更新EducationInfo实体
        /// </summary>
        bool UpdateEducationInfo(EducationInfo educationInfo);

        /// <summary>
        /// 删除EducationInfo实体
        /// </summary>
        bool DeleteEducationInfo(EducationInfo educationInfo);

        /// <summary>
        /// 根据ID删除EducationInfo实体
        /// </summary>
        bool DeleteEducationInfoById(int id);
    }
}
