using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;

namespace HCQ2_IDAL
{
    public partial interface IAuth_UserDAL
    {
        /// <summary>
        ///  数据层登录方法 接口
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        Auth_User GetByUser(string loginName);
    }
}
