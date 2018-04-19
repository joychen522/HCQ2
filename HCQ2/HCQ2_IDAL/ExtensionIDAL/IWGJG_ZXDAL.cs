using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;
using System.Data;

namespace HCQ2_IDAL
{
    /// <summary>
    ///  企业征信数据层接口
    /// </summary>
    public partial interface IWGJG_ZXDAL
    {
        /// <summary>
        ///  根据名称查询
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页记录数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        List<HCQ2_Model.WGJG_ZX> SelUnitDataByName(int page,int rows,string keyword);
        /// <summary>
        ///  统计数量
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int SelCountByName(string keyword);

        //****************************************WebChat Service***************************************
        /// <summary>
        ///  通过名称查询企业征信信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<CompanyEnterResultModel> GetComEnterByName(CompanyModel model);

        /// <summary>
        /// 获取企业征信
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.CreditModelResult> GetCompayProobjectList(CompanyModel com);
        /// <summary>
        /// 获取企业征信明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.EnterCompanyDetail> GetCompayEnterDetail(CompanyDetailModel model);
    }
}
