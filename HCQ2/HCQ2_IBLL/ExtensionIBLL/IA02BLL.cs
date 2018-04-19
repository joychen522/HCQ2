using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.SelectModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  考勤业务层接口定义
    /// </summary>
    public partial interface IA02BLL
    {
        /// <summary>
        ///  查询考勤数据
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <returns></returns>
        List<HCQ2_Model.ExtendsionModel.A02Model> SelectA02Data(HCQ2_Model.SelectModel.A02Model model);
        /// <summary>
        ///  获取图表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        HCQ2_Model.ViewModel.EchartsVo GetMonthChartData(HCQ2_Model.SelectModel.A02Model model);

        /// <summary>
        ///  查询人员详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.ViewModel.PunchCardModel> SelectCardPersons(HCQ2_Model.SelectModel.A02Model model);
    }
}
