
using HCQ2_Model.APPModel.ResultApiModel;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  APP用户业务接口
    /// </summary>
    public partial interface IT_UserBLL
    {
        /// <summary>
        ///  农民工app注册
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message">返回消息</param>
        /// <returns></returns>
        string RegUser(HCQ2_Model.APPModel.ParamModel.SysUserModel user,out string message);
        /// <summary>
        ///  根据用户guid获取用户信息
        /// </summary>
        /// <param name="user_guid">guid</param>
        /// <returns></returns>
        AppUserModel GetUserModel(string user_guid);
        /// <summary>
        ///  编辑app用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int EditAPPUserMsg(HCQ2_Model.APPModel.ParamModel.BaseUser user,out string msg);
    }
}
