using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using HCQ2_Model.EnumModel;
using HCQ2_Model.JsonData;
using HCQ2_Common;
using HCQ2_IBLL;

namespace HCQ2_BLL
{
    public partial class Auth_UserBLL : IAuth_UserBLL
    {
        /// <summary>
        ///  登录验证事件
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public LoginEnum.LoginResult GetLoginResult(string loginName, string loginPwd)
        {
            var user = this.GetByUser(loginName);
            if (user == null)
                return LoginEnum.LoginResult.用户名不存在;
            if (user.Password == Encrypt(loginPwd,0))
                return LoginEnum.LoginResult.登陆成功;
            return LoginEnum.LoginResult.密码错误;
        }

        /// <summary>
        ///  登录事件
        /// </summary>
        /// <param name="login_name">登录名</param>
        /// <param name="user_pwd">密码</param>
        /// <returns></returns> 
        public JsonModel Login(string loginName, string loginPwd)
        {
            LoginEnum.LoginResult result = this.GetLoginResult(loginName, loginPwd);
            JsonModel jm = new JsonModel()
            {
                Statu = (int)Enum.Parse(typeof(LoginEnum.LoginResult), result.ToString(), true),
                Msg = this.GetLoginResult(loginName, loginPwd).ToString()
            };
            if (jm.Statu == 0)
                jm.Url = "../SysMain/Main";
            return jm;
        }
        /// <summary>
        ///  获取登录用户对象
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public Auth_User GetByUser(string loginName)
        {
            return base.Select(o => o.UserName == loginName).FirstOrDefault();
        }

        /// <summary>
        ///  根据登录名，密码获取登录对象
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public Auth_User GetByUser(string loginName, string loginPwd)
        {
            return
                Select(o => o.UserName == loginName && o.Password == loginPwd).FirstOrDefault();
        }

        /// <summary>
        ///  加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pwd_type"></param>
        /// <returns></returns>
        private string Encrypt(string str, int pwd_type)
        {
            str += "HCQ2";
            if (string.IsNullOrEmpty(str))
                return "";
            if (pwd_type == 0)
                return HCQ2_Common.Encrypt.EncryptHelper.Md5Encryption(str);
            return HCQ2_Common.Encrypt.EncryptHelper.EncryptDouble(str + "TaiJieR", str + "KingwayFrom2011");
        }
    }
}
