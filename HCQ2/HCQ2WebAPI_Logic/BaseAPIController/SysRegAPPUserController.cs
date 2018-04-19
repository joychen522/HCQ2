using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2UI_Helper;
using System.Web.Http;

namespace HCQ2WebAPI_Logic.BaseAPIController
{
    /// <summary>
    ///  APP注册控制器
    /// </summary>
    [HCQ2_Common.Attributes.SkipApi]
    public class SysRegAPPUserController : BaseWeiXinApiLogic
    {
        #region 1.0 农民工注册 + object RegUser(SysUserModel model)
        /// <summary>
        ///  1.0 农民工注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object RegUser(SysUserModel model)
        {
            if (!ModelState.IsValid)
                return OperateContext.Current.RedirectWebApi(
                    WebResultCode.Exception, "参数验证失败", null);
            string message = string.Empty;
            string mark = OperateContext.Current.bllSession.T_User.RegUser(model, out message);
            if (string.IsNullOrEmpty(mark))
                return OperateContext.Current.RedirectWebApi(WebResultCode.Error, "注册失败", message);
            return OperateContext.Current.RedirectWebApi(WebResultCode.Ok, "注册成功", mark);
        }
        #endregion
    }
}
