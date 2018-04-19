using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IA03BLL
    {
        /// <summary>
        /// 获取所有的工资发放登记
        /// </summary>
        /// <returns></returns>
        List<A03> GetA03Info();

        /// <summary>
        /// 根据PersonID获取员工工资发放登记
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        List<A03> GetByPersonID(string PersonID);

        /// <summary>
        /// 添加、编辑员工工资发放登记
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool OperWage(object obj);
    }
}
