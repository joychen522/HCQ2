using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.ViewModel;
using HCQ2_Model.APPModel.ResultApiModel;
using HCQ2_Model.APPModel.ParamModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  工资发放业务层接口定义
    /// </summary>
    public partial interface IWGJG01BLL
    {
        /// <summary>
        ///  根据单位代码获取数据
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<WGJG01Model> GetWageListDataByUnit(HCQ2_Model.SelectModel.WGJG01ChartModel model);
        /// <summary>
        ///  编辑对象
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int EditWGJG01(HCQ2_Model.WGJG01 model);
        /// <summary>
        ///  获取工资汇总统计图表数据
        /// </summary>
        /// <param name="model">查询模型对象</param>
        /// <returns></returns>
        EchartsVo GetChartData(HCQ2_Model.SelectModel.WGJG01ChartModel model);

        //*********************************APP Service*********************************
        /// <summary>
        ///  根据单位获取工资发放信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtWGJG01Model> GetGrantInfoByUnit(DebtSelGrantModel model);
    }
}
