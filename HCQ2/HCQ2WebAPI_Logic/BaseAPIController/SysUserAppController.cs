using System.Web.Http;
using HCQ2UI_Helper;
using HCQ2_Common.Constant;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2WebAPI_Logic.BaseAPIController
{
    /// <summary>
    ///  APP用户管理控制器
    /// </summary>
    public class SysUserAppController: BaseWeiXinApiLogic
    {
        #region 1.1 获取用户信息 + object GetUser(BaseWeiXinModel model)
        /// <summary>
        ///  1.1 获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetUser(BaseAPI model)
        {
            if (!ModelState.IsValid)
                return OperateContext.Current.RedirectWebApi(
                    WebResultCode.Exception, "参数验证失败", null);
            AppUserModel user = OperateContext.Current.bllSession.T_User.GetUserModel(model.userid);
            if(null==user)
                return OperateContext.Current.RedirectWebApi(WebResultCode.Error, "获取数据失败", "");
            return OperateContext.Current.RedirectWebApi(WebResultCode.Ok, "获取数据成功", user);
        }
        #endregion

        #region 1.2 修改用户数据 + object ModifyUser(BaseUser user)
        /// <summary>
        ///  1.2 修改用户数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public object ModifyUser(BaseUser user)
        {
            if (!ModelState.IsValid)
                return OperateContext.Current.RedirectWebApi(
                    WebResultCode.Exception, "参数验证失败", null);
            string message = string.Empty;
            int mark = OperateContext.Current.bllSession.T_User.EditAPPUserMsg(user,out message);
            if (mark>0)
                return OperateContext.Current.RedirectWebApi(WebResultCode.Ok, "编辑数据成功", "");
            return OperateContext.Current.RedirectWebApi(WebResultCode.Error, "编辑信息失败", message);
        } 
        #endregion
    }
}
