using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IBLL
{
    public partial interface IT_EnterDetailBLL
    {
        /// <summary>
        /// 根据用户ID获取所分配权限项目的所有征信记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        List<T_EnterDetail> GetEnterByUserid(int user_id);

        /// <summary>
        /// 获取失信企业以及记录事件数量
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> GetDataApiView();

        /// <summary>
        /// 获取失信企业信息
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetCompay();

        /// <summary>
        /// 获取征信记录事件信息
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetEvent();

        /// <summary>
        /// 处理案件事件统计
        /// </summary>
        List<Dictionary<string, object>> SolveCount();
    }
}
