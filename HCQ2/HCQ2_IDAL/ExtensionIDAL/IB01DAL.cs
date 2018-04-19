using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  单位表 数据层接口
    ///  创建人：Joychen
    ///  创建时间：2016-12-15
    /// </summary>
    public partial interface IB01DAL
    {
        /// <summary>
        ///  根据单位代码获取子单位信息集合
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        List<HCQ2_Model.B01> GetB01Info(int user_id,string unitID=null);
        /// <summary>
        ///  获取项目月增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectMonthGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);
        /// <summary>
        ///  获取项目总增长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.ChartProject> GetProjectAllGrow(HCQ2_Model.APPModel.ParamModel.DebtAllGrantModel model);

        /// <summary>
        /// 根据年月获取采集数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        int GetSaveByYearMonth(int year, int month);
    }
}
