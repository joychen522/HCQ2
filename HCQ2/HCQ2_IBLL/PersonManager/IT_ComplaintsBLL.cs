using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IBLL
{
    public partial interface IT_ComplaintsBLL
    {
        /// <summary>
        /// 获取所有的投诉举报
        /// </summary>
        /// <returns></returns>
        List<T_Complaints> GetComplaint();

        /// <summary>
        /// 根据guid获取投诉信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        List<T_Complaints> GetByGuid(string guid);

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        bool AddComplaints(HCQ2_Model.AppModel.Complaints com);

        /// <summary>
        /// 根据ID获取头绪信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        T_Complaints GetByComId(int com_id);

        /// <summary>
        /// 分页获取投诉信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        List<HCQ2_Model.AppModel.ComReType> GetComplaintsPageRow(HCQ2_Model.AppModel.ComReTypeInter com);

        /// <summary>
        /// 处理投诉举报
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        bool SolveComplaints(HCQ2_Model.AppModel.ComSove com);
    }
}
