using HCQ2_Model;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IWGJG02BLL
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<WGJG02> GetWGJG02();

        /// <summary>
        /// 获取发放信息
        /// </summary>
        /// <returns></returns>
        DataTable GetWGJG02DataTable();
        /// <summary>
        ///  获取欠薪金额趋势数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<DebtMoneyModel> GetPayMoneyByDate(DebtChartByYearModel model);
    }
}
