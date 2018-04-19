using HCQ2_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IA19BLL
    {
        /// <summary>
        /// 获取所有工作经历信息
        /// </summary>
        /// <returns></returns>
        List<A19> GetA19Info();

        /// <summary>
        /// 根据PersonID获取工作经历信息
        /// </summary>
        /// <returns></returns>
        List<A19> GetByPersonID(string PersonID);

        /// <summary>
        /// 保存或者编辑工作经历
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool OperWork(object obj);
    }
}
