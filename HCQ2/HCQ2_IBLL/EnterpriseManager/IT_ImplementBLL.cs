using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IBLL
{
    public partial interface IT_ImplementBLL
    {
        /// <summary>
        /// 获取所有的实施记录
        /// </summary>
        /// <returns></returns>
        List<T_Implement> GetImplement();

        /// <summary>
        /// 根据ID获取实施记录
        /// </summary>
        /// <param name="implement_id"></param>
        /// <returns></returns>
        T_Implement GetByID(int implement_id);

        /// <summary>
        /// 保存实施记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SaveImplement(object obj);

    }
}
