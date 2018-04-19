using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IBLL
{
    public partial interface IA01BLL
    {
        /// <summary>
        ///  根据单位代码获取单位人员集合
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        List<HCQ2_Model.SelectModel.ListBoxModel> GetPersonsByB0002(string unitID);
        /// <summary>
        ///  获取人员月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
        /// <summary>
        ///  获取人员总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartPerson> GetPersonAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
    }
}
