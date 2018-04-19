using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCQ2_DAL_MSSQL
{
   public partial class BB_ServiceUserDAL:HCQ2_IDAL.IBB_ServiceUserDAL
    {
        /// <summary>
        ///  获取所有已被分配的售后人员数据集合
        /// </summary>
        /// <returns></returns>
        public List<HCQ2_Model.ExtendsionModel.ServiceUserModel> GetServiceUser()
        {
            var query = (from o in db.Set<HCQ2_Model.BB_ServiceUser>()
                         join s in db.Set<HCQ2_Model.T_User>()
                         on o.user_id equals s.user_id
                         select new
                         {
                             o.su_id,
                             s.user_id,
                             s.user_name,
                             s.login_name,
                             s.user_qq,
                             s.user_phone,
                             s.user_email
                         }).ToList();
            if (query == null || query.Count <= 0)
                return null;
            List<HCQ2_Model.ExtendsionModel.ServiceUserModel> list = new List<HCQ2_Model.ExtendsionModel.ServiceUserModel>();
            foreach (var item in query)
                list.Add(new HCQ2_Model.ExtendsionModel.ServiceUserModel
                {
                    su_id = item.su_id,
                    user_id = item.user_id,
                    user_name = item.user_name,
                    login_name = item.login_name,
                    user_qq = item.user_qq,
                    user_phone = item.user_phone,
                    user_email = item.user_email
                });
            return list;
        }
    }
}
