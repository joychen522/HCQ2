using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2WebAPI_Logic.BaseAPIController;
using HCQ2_Common.Constant;
using HCQ2_Model.WeiXinApiModel.ParamModel;
using HCQ2_Model.WeiXinApiModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.WeiXinController
{
    /// <summary>
    ///  征信信息查询控制器
    /// </summary>
    public class CompanyController:BaseWeiXinApiLogic
    {
        #region 1.0 企业征信查询 + object SelComEnterprise(CompanyModel model)
        /// <summary>
        ///  1.0 企业征信查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object SelComEnterprise(CompanyModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<CompanyEnterResultModel> list = operateContext.bllSession.WGJG_ZX.GetComEnterByName(model);
            if(null==list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion

        #region 1.2 个人征信查询 + object SelComOwnprise(CompanyModel model)
        /// <summary>
        ///  1.2 个人征信查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object SelComOwnprise(CompanyModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), false);
            List<CompanyOwnResultModel> list = operateContext.bllSession.WGJG_GRZX.GetComOwnByName(model);
            if (null == list)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作异常.ToString(), false);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        } 
        #endregion
    }
}
