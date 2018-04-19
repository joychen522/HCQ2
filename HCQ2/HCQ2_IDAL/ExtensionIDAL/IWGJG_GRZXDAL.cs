using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  个人征信数据层接口
    /// </summary>
    public partial interface IWGJG_GRZXDAL
    {
        /// <summary>
        ///  获取个人征信数据
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        List<HCQ2_Model.WGJG_GRZX> SelectOwnDataByName(int page, int rows, string userName);
        /// <summary>
        ///  统计数据
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int SelectCountOwnData(string userName);
        /// <summary>
        ///  通过名称查询个人征信信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<CompanyOwnResultModel> GetComOwnByName(CompanyModel model);
    }
}
