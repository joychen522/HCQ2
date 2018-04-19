using HCQ2_Common.Encrypt;
using HCQ2_Model;
using HCQ2_Model.APPModel.ParamModel;
using HCQ2_Model.APPModel.ResultApiModel;
using System;
using System.Collections.Generic;

namespace HCQ2_BLL
{
    public partial class T_UserBLL: HCQ2_IBLL.IT_UserBLL
    {
        /// <summary>
        ///  app注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string RegUser(SysUserModel user,out string message)
        {
            message = string.Empty;
            if (null == user)
                return null;
            //1.判断当前用户在A01表是否存在记录
            List<A01> a01 = DBSession.IA01DAL.Select(s => s.A0177.Equals(user.user_identify));
            if (a01 == null || a01.Count <= 0)
            {
                message = "当前注册用户非系统工人，系统拒绝注册！";
                return null;
            }
            //2.判断当前用户是否注册过
            List<T_User> lu = Select(s => s.user_identify.Equals(user.user_identify));
            if(null!=lu && lu.Count>0)
            {
                message = "注册失败，当前身份证已注册过！";
                return null;
            }
            //3.判断登录名是否被占用
            List<T_User> au = Select(s => s.login_name.Equals(user.login_name));
            if(au!=null && au.Count>0)
            {
                message = "当前登录名已被占用，请重新设置！";
                return null;
            }
            //4.构建用户对象
            T_User t_user = new T_User()
            {
                user_name = user.user_name,
                login_name = user.login_name,
                user_pwd = EncryptHelper.Md5Encryption(user.user_password),
                user_identify = user.user_identify,
                user_phone = user.user_phone,
                user_sex = "男",
                user_type="01",//默认注册农民工
                user_guid = EncryptHelper.CreateGuidValue(),
                reg_from = 1//接口默认注册来源为APP
            };
            int mark = Add(t_user);
            //5.将人员注册到具体单位下面
            DBSession.IT_Org_UserDAL.Add(new T_Org_User() { user_id = t_user.user_id, UnitID = a01[0].UnitID });
            if (mark > 0)
                return t_user.user_guid;
            return null;
        }
        /// <summary>
        ///  获取信息
        /// </summary>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public AppUserModel GetUserModel(string user_guid)
        {
            if (string.IsNullOrEmpty(user_guid))
                return null;
           List<T_User> user = Select(s => s.user_guid == user_guid);
            if(user.Count<=0)
                return null;
            return new AppUserModel
            {
                user_name = user[0].user_name,
                login_name = user[0].login_name,
                user_identify = user[0].user_identify,
                user_phone = user[0].user_phone
            };
        }
        /// <summary>
        ///  编辑app用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public int EditAPPUserMsg(BaseUser user, out string msg)
        {
            msg = string.Empty;
            if (null == user)
                return 0;
            List<T_User> uModel = Select(s => s.login_name == user.login_name && !s.user_guid.Equals(user.userid));
            if (null != uModel && uModel.Count > 0)
            {
                msg = "当前登录名已被占用，请重新设置~";
                return 0;
            }
            T_User u = new T_User
            {
                login_name = user.login_name,
                user_phone = user.user_phone,
                user_pwd = user.user_password
            };
            return Modify(u, s => s.user_guid == user.userid, "login_name", "user_phone", "user_pwd");
        }
    }
}
