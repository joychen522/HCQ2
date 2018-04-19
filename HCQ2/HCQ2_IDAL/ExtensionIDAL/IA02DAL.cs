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
    ///  考勤数据层接口定义
    /// </summary>
    public partial interface IA02DAL
    {
        /// <summary>
        ///  获取月趋势图数据
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.A02Model> SelectA02CheckByMonthData(HCQ2_Model.SelectModel.A02Model model);
        /// <summary>
        ///  查询人员详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.PunchCardModel> SelectCardPersons(HCQ2_Model.SelectModel.A02Model model);
        /// <summary>
        ///  获取工种分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WorkTypeCount> GetWorkType(OrgModel model);
    }
}
