using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  出工
    /// </summary>
    public  partial interface IView_A02BLL
    {
        /// <summary>
        ///  获取个人月出工记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkMonthResult> GetMonthWorkData(WorkMonthList model);
        /// <summary>
        ///  根据年份统计具体人员每月出工情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkAllResult> GetAllWorkDays(WorkAllList model);
        /// <summary>
        ///  获取当月打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetMonthByCard(BaseAPI model);
        /// <summary>
        ///  获取总的打卡天数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int GetAllByCard(BaseAPI model);
    }
}
