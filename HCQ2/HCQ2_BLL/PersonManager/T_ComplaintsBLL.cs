using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCQ2_Model;
using System.Data;

namespace HCQ2_BLL
{
    public partial class T_ComplaintsBLL : HCQ2_IBLL.IT_ComplaintsBLL
    {
        /// <summary>
        /// 获取所有的投诉举报
        /// </summary>
        /// <returns></returns>
        public List<T_Complaints> GetComplaint()
        {
            return Select(o => o.c_id > 0);
        }

        /// <summary>
        /// 根据guid获取投诉信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public List<T_Complaints> GetByGuid(string guid)
        {
            T_User user = new T_UserBLL().Select(o => o.user_guid == guid).FirstOrDefault();
            return Select(o => o.create_identifycode == user.user_identify);
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public bool AddComplaints(HCQ2_Model.AppModel.Complaints com)
        {
            T_Complaints aCom = new T_Complaints();
            T_User user = new T_UserBLL().Select(o => o.user_guid == com.userid).FirstOrDefault();
            aCom.c_title = com.title;
            aCom.c_content = com.content;
            if (com.image != null)
                aCom.c_image = Convert.FromBase64String(com.image);
            aCom.create_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            aCom.create_guid = com.userid;
            A01 data = new A01BLL().Select(o => o.A0177 == user.user_identify)[0];
            aCom.create_identifycode = user.user_identify;
            aCom.create_personid = data.A0101;

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("select top 1 * from a01 where a0177='{0}'", user.user_identify);
            DataTable dt = HCQ2_Common.SQL.SqlHelper.ExecuteDataTable(sbSql.ToString());
            if (dt != null)
            {
                sbSql = new StringBuilder();
                if (!string.IsNullOrEmpty(dt.Rows[0]["B0002"].ToString()))
                {
                    sbSql.AppendFormat("select UnitName from B01 where UnitID='{0}'", dt.Rows[0]["B0002"]);
                }
                else
                    sbSql.AppendFormat("select UnitName from B01 where UnitID='{0}'", dt.Rows[0]["B0001"]);
                aCom.unit_name = HCQ2_Common.SQL.SqlHelper.ExecuteScalar(sbSql.ToString()).ToString();
            }

            return Add(aCom) > 0;
        }

        /// <summary>
        /// 根据ID获取头绪信息
        /// </summary>
        /// <param name="com_id"></param>
        /// <returns></returns>
        public T_Complaints GetByComId(int com_id)
        {
            return Select(o => o.c_id == com_id).FirstOrDefault();
        }

        /// <summary>
        /// 分页获取投诉信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public List<HCQ2_Model.AppModel.ComReType> GetComplaintsPageRow(HCQ2_Model.AppModel.ComReTypeInter com)
        {
            List<HCQ2_Model.AppModel.ComReType> rList = new List<HCQ2_Model.AppModel.ComReType>();
            HCQ2_Model.AppModel.ComReType rCom = new HCQ2_Model.AppModel.ComReType();
            List<T_Complaints> comList = new List<T_Complaints>();
            if (com.type == "0")
            {
                comList = Select(o => o.re_date == null);
            }
            else
            {
                comList = Select(o => o.re_date != null);
            }
            var data = comList.Skip((com.rows * com.page) - com.rows).Take(com.rows);
            if (data.Count() > 0)
            {
                comList = data.ToList();
                foreach (var item in comList)
                {
                    rCom = new HCQ2_Model.AppModel.ComReType();
                    rCom.com_id = item.c_id;
                    rCom.com_title = item.c_title;
                    rCom.com_person = item.create_personid;
                    rCom.com_date = Convert.ToDateTime(item.create_date).ToString("yyyy-MM-dd");
                    rList.Add(rCom);
                }
            }

            return rList;
        }

        /// <summary>
        /// 处理投诉举报
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public bool SolveComplaints(HCQ2_Model.AppModel.ComSove com)
        {
            T_Complaints dCom = new T_Complaints();
            dCom.re_note = com.re_note;
            dCom.re_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            dCom.re_user_id = new T_UserBLL().Select(o => o.user_guid == com.userid).FirstOrDefault().user_id.ToString();
            int id = Convert.ToInt32(com.id);
            return Modify(dCom, o => o.c_id == id, "re_note", "re_date", "re_user_id") > 0;
        }
    }
}
