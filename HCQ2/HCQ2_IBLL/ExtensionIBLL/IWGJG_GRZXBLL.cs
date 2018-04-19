using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  个人征信业务层接口定义
    /// </summary>
    public partial interface IWGJG_GRZXBLL
    {
        /// <summary>
        ///  获取个人征信数据
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页数量</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        List<HCQ2_Model.WGJG_GRZX> SelectOwnDataByName(int page,int rows,string userName);
        /// <summary>
        ///  统计数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int SelectCountOwnData(string userName);
        /// <summary>
        ///  修改个人征信
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ModifyData(HCQ2_Model.WGJG_GRZX model);
        /// <summary>
        ///  通过名称查询个人征信信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<CompanyOwnResultModel> GetComOwnByName(CompanyModel model);
    }
}
