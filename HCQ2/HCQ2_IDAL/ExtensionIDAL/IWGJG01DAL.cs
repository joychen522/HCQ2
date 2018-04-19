using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  工资发放数据层接口定义
    /// </summary>
    public partial interface IWGJG01DAL
    {
        /// <summary>
        ///  根据单位id获取工资发放数据
        /// </summary>
        /// <param name="unitID">单位代码</param>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.WGJG01Model> GetWageListDataByUnit(HCQ2_Model.SelectModel.WGJG01ChartModel model);
        /// <summary>
        ///  获取最大的排序字段
        /// </summary>
        /// <returns></returns>
        int SelMaxOrder();
        /// <summary>
        ///  APP根据单位 时间获取工资发放信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtWGJG01Model> GetGrantInfoByUnit(DebtSelGrantModel model);
    }
}
