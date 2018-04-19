using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HCQ2WebAPI_Logic.BaseAPIController;
using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.APPController
{
    /// <summary>
    /// 企业征信
    /// </summary>
    public class CompanyProjectController : BaseWeiXinApiLogic
    {
        #region 1.0 企业征信查询 + object SelComEnterprise(CompanyModel model)
        /// <summary>
        ///  1.0 企业征信查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetComEnterprise(HCQ2_Model.WeiXinApiModel.ParamModel.CompanyModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<EnterCompanyResult> list = operateContext.bllSession.WGJG_ZX.GetCompayEnter(model);
            if (null == list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion

        #region 1.0 获取企业征信明细 + object GetComEnterDetail(CompanyModel model)
        /// <summary>
        ///  1.1 获取企业征信明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetComEnterDetail(HCQ2_Model.WeiXinApiModel.ParamModel.CompanyDetailModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<EnterCompanyDetail> list = operateContext.bllSession.WGJG_ZX.GetCompayEnterDetail(model);
            if (null == list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), null);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion
    }
}
