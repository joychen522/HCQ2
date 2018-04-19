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
    ///  企业征信业务层接口定义
    /// </summary>
    public partial interface IWGJG_ZXBLL
    {
        /// <summary>
        ///  获取企业征信信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<HCQ2_Model.WGJG_ZX> SelectUnitDataByName(int page,int rows,string keyword);
        /// <summary>
        ///  统计记录数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int SelCountData(string keyword);
        /// <summary>
        ///  编辑对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ModifyData(HCQ2_Model.WGJG_ZX model,string rowID);
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
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.EnterCompanyResult> GetCompayEnter(CompanyModel model);
        /// <summary>
        /// 获取企业征信明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<HCQ2_Model.APPModel.ResultApiModel.EnterCompanyDetail> GetCompayEnterDetail(CompanyDetailModel model);
    }
}
