using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using System.Web.Mvc;

namespace HCQ2_BLL
{
    public partial class T_ImplementBLL : HCQ2_IBLL.IT_ImplementBLL
    {
        /// <summary>
        /// 获取所有的实施记录
        /// </summary>
        /// <returns></returns>
        public List<T_Implement> GetImplement()
        {
            return base.Select(o => o.imp_id > 0);
        }

        /// <summary>
        /// 根据ID获取实施记录
        /// </summary>
        /// <param name="implement_id"></param>
        /// <returns></returns>
        public T_Implement GetByID(int implement_id)
        {
            return base.Select(o => o.imp_id == implement_id).FirstOrDefault();
        }

        /// <summary>
        /// 保存实施记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SaveImplement(object obj)
        {
            FormCollection param = (FormCollection)obj;

            T_Implement im = new T_Implement();
            im.B0001 = param["B0001"];
            im.B0002 = param["B0002"];
            im.B000201 = param["B000201"];
            im.owner_name = param["owner_name"];
            im.respon_name = param["respon_name"];
            im.respon_phone = param["respon_phone"];
            im.install_date = Convert.ToDateTime(param["install_date"]);
            im.collect_date = Convert.ToDateTime(param["collect_date"]);
            im.cost_money = Convert.ToDecimal(param["cost_money"]);
            im.use_status = param["use_status"];
            im.cost_date = Convert.ToDateTime(param["cost_date"]);
            im.impl_note = param["impl_note"];

            bool isAccess = false;
            if (!string.IsNullOrEmpty(param["JianDieImplement"]))
            {
                int imp_id = int.Parse(param["JianDieImplement"]);
                isAccess = base.Modify(im, o => o.imp_id == imp_id, "B0001", "B0002"
                    , "B000201", "owner_name", "respon_name", "respon_phone", "install_date"
                    , "collect_date", "cost_money", "use_status", "cost_date", "impl_note") > 0;
            }
            else
            {
                isAccess = base.Add(im) > 0;
            }


            return isAccess;
        }
    }
}
