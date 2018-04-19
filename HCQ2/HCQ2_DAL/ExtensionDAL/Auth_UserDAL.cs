using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_IDAL;
using HCQ2_Model;

namespace HCQ2_DAL_MSSQL
{
    public partial class Auth_UserDAL : IAuth_UserDAL
    {
        /// <summary>
        ///  登录方法的实现
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public Auth_User GetByUser(string loginName)
        {
            return base.Select<int?>(o => o.UserName == loginName, o => o.DispOrder).FirstOrDefault();
            //var query1 = from o in db.Set<HCQ2_Model.Auth_User>() where o.UserName == loginName select o;
            //var query2 db.Set<T_UserInfo>().Where(o => o.login_name == loginName).FirstOrDefault();    
        }
    }
}
