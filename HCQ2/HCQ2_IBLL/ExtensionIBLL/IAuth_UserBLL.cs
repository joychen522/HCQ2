using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.EnumModel;
using HCQ2_Model.JsonData;

namespace HCQ2_IBLL
{
    /// <summary>
    ///  业务接口：用户信息
    /// </summary>
    public partial interface IAuth_UserBLL
    {
        /// <summary>
        ///  登录事件
        ///  返回登录结果Json数据
        /// </summary>
        /// <param name="login_name">登录名</param>
        /// <param name="user_pwd">密码</param>
        /// <returns></returns>
        JsonModel Login(string loginName, string loginPwd);

        /// <summary>
        ///  根据登录名获取对象
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        Auth_User GetByUser(string loginName);
        /// <summary>
        ///  根据登录名，密码获取登录对象
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        Auth_User GetByUser(string loginName, string loginPwd);
    }
}
