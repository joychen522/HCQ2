using System.Collections.Generic;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WebApiModel.ParamModel;

namespace HCQ2WebAPI_Logic.WageAPIController
{
    /// <summary>
    ///  工资维护
    /// </summary>
    public class WageManagerController:BaseApiLogic
    {
        //***************************工资********************************

        #region 1.0 工资下发 + object WageSentDown(BaseModel wage)
        /// <summary>
        ///  1.0 工资下发
        /// </summary>
        /// <param name="wage"></param>
        /// <returns></returns>
        [HttpPost]
        public object WageSentDown(BaseModel wage)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<HCQ2_Model.WebApiModel.ResultApiModel.WageSentDownModel> list =
                operateContext.bllSession.WGJG02.GetWageSentDownByOrgId(wage.orgid);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        }
        #endregion

        #region 1.1 工资登记 + object WageRegister(WageRegisterModel model)
        /// <summary>
        ///  1.1 工资登记 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object WageRegister(WageRegisterModel model)
        {
            if (!ModelState.IsValid)
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            string mark = operateContext.bllSession.WGJG02.EditAffirmWageByPerson(model);
            if (!string.IsNullOrEmpty(mark))
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("salarysignid", mark);
                return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), result);
            }
            return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.操作失败.ToString(), null);
        }
        #endregion 
    }
}
