using System.Collections.Generic;
using System.Web.Http;
using HCQ2_Common.Constant;
using HCQ2_Model.WebApiModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.WageAPIController
{
    /// <summary>
    ///  组织结构Service控制器
    /// </summary>
    public class OrgManagerController:BaseApiLogic
    {
        #region 1.0 组织结构下发 + object OrgSentDown([FromBody] string userid)
        /// <summary>
        ///  组织结构下发
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object OrgSentDown()
        {
            string userid = HCQ2_Common.Helper.ToString(request["userid"]);
            if (string.IsNullOrEmpty(userid))
                return operateContext.RedirectWebApi(WebResultCode.Exception, GlobalConstant.参数异常.ToString(), null);
            List<OrgModel> list = operateContext.bllSession.B01.GetOrgDataById(userid);
            return operateContext.RedirectWebApi(WebResultCode.Ok, GlobalConstant.操作成功.ToString(), list);
        } 
        #endregion
    }
}
